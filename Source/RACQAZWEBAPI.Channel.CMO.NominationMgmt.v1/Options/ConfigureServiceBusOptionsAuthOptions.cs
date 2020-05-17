namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    public class ConfigureServiceBusOptionsAuthOptions : IConfigureOptions<ServiceBusAuthOptions>
    {
        private readonly IConfiguration configuration;

        public ConfigureServiceBusOptionsAuthOptions(IConfiguration configuration) => this.configuration = configuration;

        public void Configure(ServiceBusAuthOptions options)
        {
            options.SharedAccessKey = configuration[configuration["ServiceBusAuth:SharedAccessKeyKVSecretName"]];
        }
    }
}