namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API
{
    using Boxed.Mapping;
    using Helper.Library.Options;
    using Microsoft.Extensions.DependencyInjection;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateQuote;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.MatchParty;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services;
    using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ServiceBusMessaging;
    using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation;
    using System;
    using System.Net.Http;

    /// <summary>
    ///     <see cref="IServiceCollection" /> extension methods add project services.
    /// </summary>
    /// <remarks>
    ///     AddSingleton - Only one instance is ever created and returned.
    ///     AddScoped - A new instance is created and returned for each request/response cycle.
    ///     AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IProcessCMONominationsCommand, ProcessCMONominationsCommand>();

        public static IServiceCollection AddProjectMappers(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IMapper<Nominations, MatchPartyRequest>, NominationsToMatchPartyMapper>()
                    .AddSingleton<IMapper<Nominations, PartyRequest>, NominationsToCreatePartyMapper>()
                    .AddSingleton<IMapper<ApttusQuote, ApttusCartRequest>, CreateQuoteRequestToFinaliseQuoteMapper>()
                    .AddSingleton<IMapper<Tuple<Nominations, RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response.IdentifierIdentificationType>, ApttusQuote>, NominationsToCreateQuoteMapper>();
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // PartyMatchManagement Client
            _ = services
            .AddTransient<UserAgentDelegatingHandler>()
            .AddTransient<PartyMatchManagementAuthenticationHandler>()
            .AddHttpClient<IPartyMatchClient, PartyMatchClient>((serviceProvider, httpClient) =>
            {
                var options = serviceProvider.GetRequiredService<PartyMatchManagementOptions>();
                SetHttpClientConfig(httpClient, options);
            })
            .ConfigurePrimaryHttpMessageHandler(x => new DefaultHttpClientHandler())
            .AddHttpMessageHandler<PartyMatchManagementAuthenticationHandler>()
            .AddHttpMessageHandler<UserAgentDelegatingHandler>();

            //QuoteManagement Client
            _ = services
           .AddTransient<QuoteManagementAuthenticationHandler>()
           .AddHttpClient<IQuoteManagementClient, QuoteManagementClient>((serviceProvider, httpClient) =>
           {
               var options = serviceProvider.GetRequiredService<QuoteManagementOptions>();
               SetHttpClientConfig(httpClient, options);
           })
           .ConfigurePrimaryHttpMessageHandler(x => new DefaultHttpClientHandler())
           .AddHttpMessageHandler<QuoteManagementAuthenticationHandler>()
           .AddHttpMessageHandler<UserAgentDelegatingHandler>();

            //CartManagement Client
            _ = services
           .AddTransient<CartManagementAuthenticationHandler>()
           .AddHttpClient<ICartManagementClient, CartManagementClient>((serviceProvider, httpClient) =>
           {
               var options = serviceProvider.GetRequiredService<CartManagementOptions>();
               SetHttpClientConfig(httpClient, options);
           })
           .ConfigurePrimaryHttpMessageHandler(x => new DefaultHttpClientHandler())
           .AddHttpMessageHandler<CartManagementAuthenticationHandler>()
           .AddHttpMessageHandler<UserAgentDelegatingHandler>();

            //PartyManagement Client
            _ = services
            .AddTransient<PartyManagementBearerTokenAuthenticationHandler>()
            .AddHttpClient()
            .AddHttpClient<IPartyManagementClient, PartyManagementClient>((serviceProvider, httpClient) =>
            {
                var options = serviceProvider.GetRequiredService<PartyManagementOptions>();
                SetHttpClientConfig(httpClient, options);
            })
#if DEBUG
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler
                {
#pragma warning disable SCS0004 // Certificate Validation has been disabled
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
#pragma warning restore SCS0004 // Certificate Validation has been disabled
                };
                return handler;
            })
#else
            .ConfigurePrimaryHttpMessageHandler(x => new DefaultHttpClientHandler())
#endif
            .AddHttpMessageHandler<PartyManagementBearerTokenAuthenticationHandler>()
            .AddHttpMessageHandler<UserAgentDelegatingHandler>();

            services.AddSingleton<IServiceBusSender, ServiceBusSender>();
            services.AddSingleton<IValidator<Nomination>, NominationValidator>();

            return services;
        }

        private static void SetHttpClientConfig(HttpClient httpClient, HttpClientOptions httpClientOptions)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
            httpClient.BaseAddress = new Uri(httpClientOptions.BaseAddress);
            httpClient.Timeout = TimeSpan.Parse(httpClientOptions.Timeout);
        }
    }
}