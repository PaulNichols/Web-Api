namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public class ConfigureQuoteManagementAuthOptions : IConfigureOptions<QuoteManagementAuthOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigureQuoteManagementAuthOptions(IConfiguration configuration) => this.configuration = configuration;

        public void Configure(QuoteManagementAuthOptions options) => options.ClientSecret = configuration[configuration["QuoteManagementAuth:SecretKVSecretName"]];
    }
}