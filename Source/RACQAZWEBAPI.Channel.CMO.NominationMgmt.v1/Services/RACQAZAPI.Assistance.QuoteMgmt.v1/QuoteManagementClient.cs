namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
    using RACQAZWEBAPI.Platform.ErrorHandling.Extensions;
    using RACQAZWEBAPI.Platform.RestClient;
    using Serilog;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class QuoteManagementClient : BaseRestClient, IQuoteManagementClient
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private const string path = "v1/assistance/product/quote/";

        public QuoteManagementClient(
            HttpClient httpClient,
            IActionContextAccessor actionContextAccessor) : base(httpClient)
        {
            this.actionContextAccessor = actionContextAccessor;
        }

        public async Task<ApttusQuote> CreateQuoteAsync(ApttusQuote request)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            Log.Information("Calling QuoteManagement-CreateQuote  to create a new Apttus Quote");
            var response = await PostAsync<ApttusQuote, ApttusQuote>(
            request,
            path,
            actionContextAccessor.ActionContext.HttpContext.GetXCorrelationId()).ConfigureAwait(false);

            Log.Information("Response received from QuoteManagement-CreateQuote for Creating a new Apttus Quote");

            return response;
        }
    }
}