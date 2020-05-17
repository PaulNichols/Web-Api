namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public class ConfigurePartyMatchManagementAuthOptions : IConfigureOptions<PartyMatchManagementAuthOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigurePartyMatchManagementAuthOptions(IConfiguration configuration) => this.configuration = configuration;

        public void Configure(PartyMatchManagementAuthOptions options) => options.ClientSecret = configuration[configuration["PartyMatchManagementAuth:SecretKVSecretName"]];
    }
}