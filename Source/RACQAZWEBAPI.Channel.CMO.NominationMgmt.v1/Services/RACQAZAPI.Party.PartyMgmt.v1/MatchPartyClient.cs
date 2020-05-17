namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using MatchParty.Models.Request;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZWEBAPI.Platform.RestClient;
    using Serilog;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MatchResponse = MatchParty.Models.Response;

    public class PartyMatchClient : BaseRestClient, IPartyMatchClient
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly PartyMatchManagementOptions partyMatchManagementOptions;

        public PartyMatchClient(
            PartyMatchManagementOptions partyMatchManagementOptions,
            HttpClient httpClient,
            IActionContextAccessor actionContextAccessor) : base(httpClient)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.partyMatchManagementOptions = partyMatchManagementOptions;
        }

        public async Task<MatchResponse.MatchPartyResponse> MatchPartyAsync(MatchPartyRequest request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));
            Log.Information("Calling MatchParty to match 100%");
            var response = await PostAsync<MatchPartyRequest, MatchResponse.MatchPartyResponse>(
                request,
                partyMatchManagementOptions.Path,
                actionContextAccessor.ActionContext.HttpContext.GetXCorrelationId()).ConfigureAwait(false);
            Log.Information("Response received from MatchParty for 100% match");
            return response;
        }
    }
}