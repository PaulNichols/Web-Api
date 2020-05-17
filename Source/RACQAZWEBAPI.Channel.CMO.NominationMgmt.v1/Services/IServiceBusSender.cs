namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ServiceBusMessaging
{
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using System.Threading.Tasks;

    public interface IServiceBusSender
    {
        Task SendMessage(Nominations request);
    }
}