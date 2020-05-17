namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.Request
{
    using System;

    public class CreateCartRequest
    {
        /// <summary>
        /// APTTUS Quote Id GUID returned after Create Quote Service is executed
        /// </summary>
        public Guid QuoteId { get; set; }

        /// <summary>
        /// APTTUS Cart Id GUID returned after Create Quote Service is executed
        /// </summary>
        public Guid CartId { get; set; }
    }
}