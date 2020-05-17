namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    using Microsoft.Extensions.Configuration;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZWEBAPI.Vehicle.InformationMgmt.v1;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class QuoteManagementAuthenticationHandler : AzureADAuthenticationDelegatingHandler
    {
        private readonly QuoteManagementAuthOptions quoteManagementAuthOptions;
        private readonly IConfiguration configuration;

        public QuoteManagementAuthenticationHandler(
            QuoteManagementOptions quoteManagementOptions,
            QuoteManagementAuthOptions quoteManagementAuthOptions,
            IConfiguration configuration)
            : base(quoteManagementOptions, quoteManagementAuthOptions)
        {
            this.quoteManagementAuthOptions = quoteManagementAuthOptions;
            this.configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {

            request.Headers.Add("Ocp-Apim-Subscription-Key", configuration[configuration["QuoteManagementAuth:ApimSubscriptionKeyKVSecretName"]]);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}