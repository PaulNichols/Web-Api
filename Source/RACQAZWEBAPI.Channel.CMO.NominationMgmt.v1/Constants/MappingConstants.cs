namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class MappingConstants
    {
        public const string ApttusAgencyIdentifier = "APTTUS";
        public const string D365AgencyIdentifier = "D365";
        public const string ApttusAIdentificationSchemeAgencyName = "Royal Automobile Club of Queensland";

        public const string Country = "Australia";

        public const string SystemId = "API";
        public const string SystemComponentId = "RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1";

        public const string OrgABN = "ABN";
        public const string OrgACN = "ACN";
        public const int OrgACNDigits = 11;
        public const string FullMatch = "100";
        public const string PartialMatch = "Partial";
        public const string PartyMatchedAlive = "Alive";

        public const string PartyOwnerTypeP = "Person";
        public const string PartyOwnerTypeB1 = "Organisation";
        public const string AddressUsageResidential = "Residential";
        public const string AddressUsagePostal = "Postal";
        public const string AddressCountryName = "AUS";
        public const string NominationProductName = "ProductName";
        public const string APTTUSQuoteReferenceTypeCodeQuote = "APTTUSQuoteID";
        public const string APTTUSQuoteReferenceTypeCodeCart = "APTTUSCartID";
        public const string APTTUSQuoteDefaultStatus = "User preferred";

        public static ReadOnlyCollection<string> DeliveryChannels => new List<string> { "DeliveryChannelGlobal", "DeliveryChannelAGM", "DeliveryChannelMembershipCard", "DeliveryChannelNotices", "DeliveryChannelTRA" }.AsReadOnly();

        public const string CommunicationPreferenceEmail = "Email";
        public const string CommunicationPreferencePostal = "Postal Address";
        public const string CommunicationPreferenceNone = " None";

        public static readonly Dictionary<string, string> ProgramCodes = new Dictionary<string, string>
                        {
                            { "FCM", "ARF001" },
                            { "FDC", "ARF002" },
                            { "MCM", "ARM001" },
                            { "MDC", "ARM002" },
                            { "SCM", "ARS001" },
                            { "SMY", "ARS002" }
                        };

        public static readonly Dictionary<string, string> ProductAgreementReferenceCodes = new Dictionary<string, string>
                        {
                            { "FCM", "Ford CMO (FCM)" },
                            { "FDC", "Ford Dealer Service CMO (FDC)" },
                            { "MCM", "Mitsubishi CMO (MCM)" },
                            { "MDC", "Mitsubishi Dealer Service CMO (MDC)" },
                            { "SCM", "Subaru CMO (SCM)" },
                            { "SMY", "Subaru Multi Year CMO (SMY)" }
                        };

        public static readonly Dictionary<string, string> PartyResponseValidationErrors = new Dictionary<string, string>
                        {
                            { "ProgramCode","106 - ProgramCode must be provided" },
                            { "Trans_Type","110 - Trans_Type must be provided" },
                            { "NominationDate","112 - NominationDate must be provided" },
                            { "ServiceDate","114 - ServiceDate must be provided for DSR" },
                            { "VIN","116 - VIN must be provided" },
                            { "Description","118 - Vehicle Description must be provided" },
                            { "Make","120 - Vehicle Make must be provided" },
                            { "Model","122 - Vehicle Model must be provided" },
                            { "BodyType","124 - Vehicle BodyType must be provided" },
                            { "Colour","126 - Vehicle Colour must be provided" },
                            { "Rego","128 - Vehicle Rego must be provided" },
                            { "OwnerType","130 - OwnerType must be provided" },
                            { "FirstName","134 - FirstName must be provided" },
                            { "Surname","136 - Surname must be provided" },
                            { "DOB","138 - DOB must be provided" },
                            { "Phone","140 - At least one Phone Number must be provided" },
                            { "StateofMembership","150 - StateofMembership must be provided" },
                            { "City","156 - City must be provided" },
                            { "State","158 - State must be provided" },
                            { "NominationID","162 - NominationID must be provided" },
                            { "StartDate","114 - StartDate must be provided" },
                            { "AddressLine1","154 - AddressLine1 must be provided" },
                            { "Postcode","160 - Postcode must be provided" }
                        };

        public const string regoIdentifierType = "VehicleRegistrationNumber";

        public const string Success = "Success";
        public const string Error = "Error";
        public const string Rejected = "Rejected";
    }
}