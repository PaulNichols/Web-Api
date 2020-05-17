namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    using Microsoft.Extensions.Configuration;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class PartyMatchManagementAuthenticationHandler : DelegatingHandler
    {
        private readonly PartyMatchManagementAuthOptions partyMatchManagementAuthOptions;
        private readonly IConfiguration configuration;

        public PartyMatchManagementAuthenticationHandler(
            PartyMatchManagementAuthOptions partyMatchManagementAuthOptions,
            IConfiguration configuration
            )
        {
            this.partyMatchManagementAuthOptions = partyMatchManagementAuthOptions;
            this.configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", configuration[configuration["PartyMatchManagementAuth:ApimSubscriptionKeyKVSecretName"]]);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}