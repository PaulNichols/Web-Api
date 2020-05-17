namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public class ConfigureCartManagementAuthOptions : IConfigureOptions<CartManagementAuthOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigureCartManagementAuthOptions(IConfiguration configuration) => this.configuration = configuration;

        public void Configure(CartManagementAuthOptions options) => options.ClientSecret = configuration[configuration["CartManagementAuth:SecretKVSecretName"]];
    }
}