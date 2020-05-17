namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands
{
    using Boxed.Mapping;
    using Constants;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using QuoteManagement.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services;
    using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ServiceBusMessaging;
    using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation;
    using Serilog;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MatchPartyRequest = MatchParty.Models.Request;
    using MatchPartyResponse = MatchParty.Models.Response;

    public class ProcessCMONominationsCommand : IProcessCMONominationsCommand
    {
        private readonly IPartyMatchClient partyMatchClient;
        private readonly ICartManagementClient cartManagementClient;
        private readonly IQuoteManagementClient quoteManagementClient;
        private readonly IPartyManagementClient partyManagementClient;
        private readonly IServiceBusSender serviceBusSender;

        private readonly IMapper<Nominations, MatchPartyRequest.MatchPartyRequest> partyMatchMapper;
        private readonly IMapper<Nominations, PartyRequest> createPartyMapper;
        private readonly IMapper<Tuple<Nominations, PartyManagement.Response.IdentifierIdentificationType>, ApttusQuote> createQuoteMapper;
        private readonly IMapper<ApttusQuote, ApttusCartRequest> createQuoteRequestToFinaliseQuoteMapper;

        private readonly IValidator<Nomination> nominationValidatior;

        public ProcessCMONominationsCommand(
            IPartyMatchClient partyMatchClient,
            ICartManagementClient cartManagementClient,
            IQuoteManagementClient quoteManagementClient,
            IPartyManagementClient partyManagementClient,
            IServiceBusSender serviceBusSender,
            IMapper<Nominations, MatchPartyRequest.MatchPartyRequest> partyMatchMapper,
            IMapper<Nominations, PartyRequest> createPartyMapper,
            IMapper<Tuple<Nominations, PartyManagement.Response.IdentifierIdentificationType>, ApttusQuote> createQuoteMapper,
            IMapper<ApttusQuote, ApttusCartRequest> createQuoteRequestToFinaliseQuoteMapper,
            IValidator<Nomination> nominationValidatior)
        {
            _ = partyMatchClient ?? throw new ArgumentNullException(nameof(partyMatchClient));
            _ = cartManagementClient ?? throw new ArgumentNullException(nameof(cartManagementClient));
            _ = quoteManagementClient ?? throw new ArgumentNullException(nameof(quoteManagementClient));
            _ = partyManagementClient ?? throw new ArgumentNullException(nameof(partyManagementClient));
            _ = serviceBusSender ?? throw new ArgumentNullException(nameof(serviceBusSender));
            _ = partyMatchMapper ?? throw new ArgumentNullException(nameof(partyMatchMapper));
            _ = createPartyMapper ?? throw new ArgumentNullException(nameof(createPartyMapper));
            _ = createQuoteMapper ?? throw new ArgumentNullException(nameof(createQuoteMapper));
            _ = createQuoteRequestToFinaliseQuoteMapper ?? throw new ArgumentNullException(nameof(createQuoteRequestToFinaliseQuoteMapper));
            _ = nominationValidatior ?? throw new ArgumentNullException(nameof(nominationValidatior));

            this.partyMatchClient = partyMatchClient;
            this.partyManagementClient = partyManagementClient;
            this.cartManagementClient = cartManagementClient;
            this.quoteManagementClient = quoteManagementClient;
            this.partyMatchMapper = partyMatchMapper;
            this.createPartyMapper = createPartyMapper;
            this.createQuoteMapper = createQuoteMapper;
            this.createQuoteRequestToFinaliseQuoteMapper = createQuoteRequestToFinaliseQuoteMapper;
            this.serviceBusSender = serviceBusSender;
            this.nominationValidatior = nominationValidatior;
        }

        public async Task<IActionResult> ExecuteAsync(Nominations request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            LogRequest(request);

            PartyManagement.Response.IdentifierIdentificationType partyResponse = null;

            var matchPartyResult = await MatchParty(request).ConfigureAwait(false);

            if (matchPartyResult.IsFullMatch())
            {
                if (matchPartyResult.IsPartyDead())
                {
                    await HandleError($"(Party match successful, party is deceased) (D365 Party ID: {matchPartyResult.GetD365Id()})(Apttus ID: {matchPartyResult.GetApttusId()})", request);
                    return new OkResult();
                }
                else
                {
                    // just mapping?
                    partyResponse = ProcessPartyDataFullMatch(matchPartyResult);
                }
            }
            else if (matchPartyResult.IsPartialMatch())
            {
                await HandleError("Party match failure - Matching returned 'partial'", request);
                return new OkResult();
            }
            else if (matchPartyResult.IsNoMatch())
            {
                partyResponse = await CreateParty(request).ConfigureAwait(false);
            }

            if (request.DataArea.Nomination.StatusCode == MappingConstants.Error)
            {
                Log.Information($"Validate Nomination to see if required fields exist");
                string validationResult = nominationValidatior.Validate(request.DataArea.Nomination);

                if (validationResult != null)
                {
                    await Reject(validationResult, request);
                }
                else
                {
                    await HandleError(null, request);
                }

                return new OkResult();
            }

            var newQuote = await CreateQuote(request, partyResponse).ConfigureAwait(false);

            await FinaliseQuote(request, newQuote).ConfigureAwait(false);

            return new OkResult();
        }

        private static void LogRequest(Nominations request)
        {
            Log.Information($"Initiate CMO Sequence");
            Log.Debug($"\n{JsonConvert.SerializeObject(request, Formatting.Indented)}");
        }

        private async Task Reject(string statusExtraDetail, Nominations request)
        {
            request.DataArea.Nomination.StatusExtraDetail = statusExtraDetail;
            await HandleError($"Append, with a leading space, on to any existing value: (Validation error {statusExtraDetail})", request, MappingConstants.Rejected);
        }

        private async Task HandleError(string errorDescription, Nominations request, string statusCode = MappingConstants.Error)
        {
            Log.Information(errorDescription);

            request.DataArea.Nomination.StatusCode = statusCode;
            request.DataArea.Nomination.StatusTimeStamp = DateTime.Now.ToLocalTime().ToString();
            request.DataArea.Nomination.StatusDescription = errorDescription ?? request.DataArea.Nomination.StatusDescription;

            await serviceBusSender.SendMessage(request).ConfigureAwait(false);
        }

        private PartyManagement.Response.IdentifierIdentificationType ProcessPartyDataFullMatch(MatchPartyResponse.MatchPartyResponse matchPartyResponse)
        {
            var partyResponse = new PartyManagement.Response.IdentifierIdentificationType();
            var matchedPartyResponse = new MatchPartyResponse.IdentifierIdentificationType();
            var matchedParty = matchPartyResponse.DataArea.Party;

            if (matchedParty.IdentifierIdentification.Count > 0)
            {
                matchedPartyResponse = matchedParty.IdentifierIdentification.FirstOrDefault(x => string.Equals(x.IdentificationSchemeAgencyIdentifier, MappingConstants.ApttusAgencyIdentifier, StringComparison.OrdinalIgnoreCase));

                if (matchedPartyResponse != null)
                {
                    partyResponse.IdentificationSchemeAgencyIdentifier = matchedPartyResponse.IdentificationSchemeAgencyIdentifier;
                    partyResponse.IdentificationSchemeAgencyName = matchedPartyResponse.IdentificationSchemeAgencyName;
                    partyResponse.Designation = matchedPartyResponse.Designation;
                }
            }

            return partyResponse;
        }

        private async Task<PartyManagement.Response.IdentifierIdentificationType> CreateParty(Nominations request)
        {
            if (request != null)
            {
                try
                {
                    var mappedRequest = MappingHelper.Map(createPartyMapper, request, "Mapping to a Create Party Request");

                    var createPartyResponse = await partyManagementClient.CreateNewPartyAsync(mappedRequest).ConfigureAwait(false);

                    if (createPartyResponse?.PartyResponse?.Result?.ResultCode != MappingConstants.Success)
                    {
                        var errorData = createPartyResponse?.PartyResponse?.Message?.Errors?.FirstOrDefault();

                        request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                        request.DataArea.Nomination.StatusDescription = $"Error encountered while creating the new party. System: {errorData?.System}, Code:{errorData?.Code}, Description:{errorData?.Description} - {errorData?.ExtraDetail}";
                    }

                    return createPartyResponse?.PartyResponse?.Result?.Party?.IdentifierIdentification?.FirstOrDefault(x => string.Equals(x?.IdentificationSchemeAgencyIdentifier, MappingConstants.ApttusAgencyIdentifier, StringComparison.OrdinalIgnoreCase));
                }
                catch (Exception ex)
                {
                    request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                    request.DataArea.Nomination.StatusDescription = ex.Message;
                }
            }
            return null;
        }

        private async Task<ApttusQuote> CreateQuote(Nominations request, PartyManagement.Response.IdentifierIdentificationType partyIdentifierIdentification)
        {
            if (request != null && partyIdentifierIdentification != null)
            {
                try
                {
                    var mappedQuoteRequest = MappingHelper.Map(createQuoteMapper, new Tuple<Nominations, PartyManagement.Response.IdentifierIdentificationType>(request, partyIdentifierIdentification), "Mapping to a Create Quote Request");

                    var createQuoteResponse = await quoteManagementClient.CreateQuoteAsync(mappedQuoteRequest).ConfigureAwait(false);

                    if (createQuoteResponse?.Result?.ResultCode != MappingConstants.Success)
                    {
                        var errorData = createQuoteResponse?.Result?.Message?.Errors?.FirstOrDefault();

                        request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                        request.DataArea.Nomination.StatusDescription = $"Error encountered while creating the quote in Apttus. System: {errorData?.System}, Code:{errorData?.Code}, Description:{errorData?.Description} - {errorData?.ExtraDetail}";

                        return null;
                    }

                    return createQuoteResponse;
                }
                catch (Exception ex)
                {
                    request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                    request.DataArea.Nomination.StatusDescription = ex.Message;
                }
            }
            return null;
        }

        private async Task<MatchPartyResponse.MatchPartyResponse> MatchParty(Nominations request)
        {
            if (request != null)
            {
                try
                {
                    var mappedRequest = MappingHelper.Map(partyMatchMapper, request, "Mapping to a Match Party Request");
                    return await partyMatchClient.MatchPartyAsync(mappedRequest).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                    request.DataArea.Nomination.StatusDescription = ex.Message;
                }
            }
            return null;
        }

        private async Task FinaliseQuote(Nominations request, ApttusQuote newQuote)
        {
            try
            {
                if (newQuote == null)
                {
                    return;
                }

                var apttusCartRequest = MappingHelper.Map(createQuoteRequestToFinaliseQuoteMapper, newQuote, "Mapping to a Finalise Quote Request");

                var apttusCartResponse = await cartManagementClient.FinalizeQuotebyCartIdAsync(apttusCartRequest).ConfigureAwait(false);

                if (apttusCartResponse?.Result?.ResultCode == MappingConstants.Success)
                {
                    request.DataArea.Nomination.StatusDescription = $"Apttus product created, policy ID: {apttusCartResponse?.DataArea?.ProductQuoteReference?.FirstOrDefault()?.PolicyNumber}";
                    request.DataArea.Nomination.StatusCode = MappingConstants.Success;

                    await serviceBusSender.SendMessage(request).ConfigureAwait(false);
                }
                else
                {
                    var errorData = apttusCartResponse?.Result?.Message?.Errors?.FirstOrDefault();
                    request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                    request.DataArea.Nomination.StatusDescription = $"Error encountered while finalising the quote in Apttus. System: {errorData?.System}, Code:{errorData?.Code}, Description:{errorData?.Description} - {errorData?.ExtraDetail}";
                }
            }
            catch (Exception ex)
            {
                request.DataArea.Nomination.StatusCode = MappingConstants.Error;
                request.DataArea.Nomination.StatusDescription = ex.Message;
            }
        }
    }
}