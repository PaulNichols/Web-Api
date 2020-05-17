namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public class ConfigurePartyManagementAuthOptions : IConfigureOptions<PartyManagementAuthOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigurePartyManagementAuthOptions(IConfiguration configuration) => this.configuration = configuration;

        public void Configure(PartyManagementAuthOptions options) => options.ClientSecret = configuration[configuration["PartyManagementAuth:SecretKVSecretName"]];
    }
}