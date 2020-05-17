namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest
{
    public class ApttusCartRequest
    {
        [Newtonsoft.Json.JsonProperty("CartId")]
        public string CartID { get; set; }


        [Newtonsoft.Json.JsonProperty("QuoteId")]
        public string QuoteID { get; set; }
    }
}
