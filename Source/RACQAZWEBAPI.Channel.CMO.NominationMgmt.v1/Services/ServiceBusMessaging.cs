namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ServiceBusMessaging
{
    using Microsoft.Azure.ServiceBus;
    using Newtonsoft.Json;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;
    using Serilog;
    using System.Text;
    using System.Threading.Tasks;

    public class ServiceBusSender : IServiceBusSender
    {
        private readonly ServiceBusAuthOptions options;

        public ServiceBusSender(ServiceBusAuthOptions options) => this.options = options;

        public async Task SendMessage(Nominations payload)
        {
            Log.Information("Placing message on the Service bus queue");

            string data = JsonConvert.SerializeObject(payload);
            Microsoft.Azure.ServiceBus.Message message = new Microsoft.Azure.ServiceBus.Message(Encoding.UTF8.GetBytes(data));
            var connectionBuilder = new ServiceBusConnectionStringBuilder($"EntityPath={options.EntityPath};TransportType={options.TransportType};Endpoint={options.Endpoint};SharedAccessKeyName=CMO-Nomination-SharedaccessKey-S;SharedAccessKey={options.SharedAccessKey};EntityPath={options.EntityPath}");
            var sender = new Microsoft.Azure.ServiceBus.Core.MessageSender(connectionBuilder);
            await sender.SendAsync(message).ConfigureAwait(false);
        }
    }
}