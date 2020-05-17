namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateQuote
{
    using Boxed.Mapping;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
    using System;
    using System.Linq;

    public class CreateQuoteRequestToFinaliseQuoteMapper : IMapper<ApttusQuote, ApttusCartRequest>
    {
        public void Map(ApttusQuote source, ApttusCartRequest destination)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            destination = null;

            if (source?.DataArea?.ProductAgreementList?.Any() == true)
            {
                var productAgreementReference = source?.DataArea?.ProductAgreementList?.FirstOrDefault().ProductAgreementReference;

                var apttusQuoteID = productAgreementReference.FirstOrDefault(x => x?.TypeCode == MappingConstants.APTTUSQuoteReferenceTypeCodeQuote)?.Id;
                var apttusCartID = productAgreementReference.FirstOrDefault(x => x?.TypeCode == MappingConstants.APTTUSQuoteReferenceTypeCodeCart)?.Id;
                destination = new ApttusCartRequest { QuoteID = apttusQuoteID, CartID = apttusCartID };
            }
        }
    }
}