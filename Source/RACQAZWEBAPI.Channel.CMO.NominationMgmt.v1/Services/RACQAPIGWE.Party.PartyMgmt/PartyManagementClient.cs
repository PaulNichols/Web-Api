namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response;
    using RACQAZWEBAPI.Platform.RestClient;
    using Serilog;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class PartyManagementClient : BaseRestClient, IPartyManagementClient
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly PartyManagementOptions options;

        public PartyManagementClient(
            HttpClient httpClient,
            PartyManagementOptions options,
            IActionContextAccessor actionContextAccessor) : base(httpClient)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.options = options;
        }

        public async Task<CreatePartyResponse> CreateNewPartyAsync(PartyRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            Log.Information("Calling PartyManagement-CreateNewParty to create Party");

            var response = await PostAsync<PartyRequest, CreatePartyResponse>(
                request,
                options.Path,
                actionContextAccessor.ActionContext.HttpContext.GetXCorrelationId()).ConfigureAwait(false);

            Log.Information("Response received from PartyManagement-CreateNewParty for Creating a new party");

            return response;
        }
    }
}