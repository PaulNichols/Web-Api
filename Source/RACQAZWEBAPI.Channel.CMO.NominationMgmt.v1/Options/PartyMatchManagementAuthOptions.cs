namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Helper.Library.Options;

    public class PartyMatchManagementAuthOptions : AzureAdOptions
    {
        public string ApimSubscriptionKeyKVSecretName { get; set; }
    }
}