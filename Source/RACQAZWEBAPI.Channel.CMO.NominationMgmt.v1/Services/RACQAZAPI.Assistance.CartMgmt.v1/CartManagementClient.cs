namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartResponse;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZWEBAPI.Platform.RestClient;
    using Serilog;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CartManagementClient : BaseRestClient, ICartManagementClient
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly CartManagementOptions cartManagementOptions;

        public CartManagementClient(
            HttpClient httpClient,
            CartManagementOptions cartManagementOptions,
            IActionContextAccessor actionContextAccessor) : base(httpClient)
        {
            this.actionContextAccessor = actionContextAccessor;
            this.cartManagementOptions = cartManagementOptions;
        }

        public async Task<ApttusCartResponse> FinalizeQuotebyCartIdAsync(ApttusCartRequest request)
        {
            Log.Information($"Calling CartManagement-FinalizeQuotebyCartId to finalize the Apttus - Quote (QuoteId:{request.QuoteID})");

            var response = await PostAsync<ApttusCartRequest, ApttusCartResponse>(
                 request,
                 $"{cartManagementOptions.Path}?quoteId={request.QuoteID}&cartId={request.CartID}",
                 actionContextAccessor.ActionContext.HttpContext.GetXCorrelationId()).ConfigureAwait(false);

            Log.Information($"Response received from CartManagement-FinalizeQuotebyCartId for finalising the Apttus - Quote (QuoteId:{request.QuoteID})");

            return response;
        }
    }
}