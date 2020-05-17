namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    using Microsoft.Extensions.Configuration;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZWEBAPI.Vehicle.InformationMgmt.v1;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class CartManagementAuthenticationHandler : AzureADAuthenticationDelegatingHandler
    {
        private readonly CartManagementAuthOptions cartManagementAuthOptions;
        private readonly IConfiguration configuration;

        public CartManagementAuthenticationHandler(
            CartManagementOptions cartManagementOptions,
            CartManagementAuthOptions cartManagementAuthOptions,
            IConfiguration configuration
            ) : base(cartManagementOptions, cartManagementAuthOptions)
        {
            this.cartManagementAuthOptions = cartManagementAuthOptions;
            this.configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", configuration[configuration["CartManagementAuth:ApimSubscriptionKeyKVSecretName"]]);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}