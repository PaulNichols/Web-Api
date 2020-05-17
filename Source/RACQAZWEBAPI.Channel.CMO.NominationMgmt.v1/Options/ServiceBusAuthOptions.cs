namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    /// <summary>
    ///     The dynamic response compression options for the application.
    /// </summary>
    public class ServiceBusAuthOptions
    {
        public string EntityPath { get; set; }
        public string TransportType { get; set; }
        public string Endpoint { get; set; }
        public string SharedAccessKey { get; set; }
    }
}