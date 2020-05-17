namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Helper.Library.Options;

    public class QuoteManagementAuthOptions : AzureAdOptions
    {
        public string ApimSubscriptionKeyKVSecretName { get; set; }
    }
}