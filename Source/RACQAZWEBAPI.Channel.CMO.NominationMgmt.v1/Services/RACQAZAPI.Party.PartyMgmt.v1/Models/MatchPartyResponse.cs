//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.1.6.0 (NJsonSchema v10.0.28.0 (Newtonsoft.Json v11.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."

namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Response
{
    using System;
    using System = global::System;


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MatchPartyResponse
    {
        [Newtonsoft.Json.JsonProperty("ApplicationArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ApplicationAreaType ApplicationArea { get; set; }

        [Newtonsoft.Json.JsonProperty("DataArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DataAreaType DataArea { get; set; }

        [Newtonsoft.Json.JsonProperty("Result", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ResultType Result { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class SystemType
    {
        [Newtonsoft.Json.JsonProperty("SystemId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemId { get; set; }

        [Newtonsoft.Json.JsonProperty("SystemComponentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemComponentId { get; set; }

        [Newtonsoft.Json.JsonProperty("SystemReferenceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemReferenceId { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class InteractionType
    {
        [Newtonsoft.Json.JsonProperty("Originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SystemType Originator { get; set; }

        [Newtonsoft.Json.JsonProperty("InteractionDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? InteractionDateTime { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ApplicationAreaType
    {
        [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MessageType Message { get; set; }

        [Newtonsoft.Json.JsonProperty("Interaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public InteractionType Interaction { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Error
    {
        [Newtonsoft.Json.JsonProperty("TimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TimeStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("System", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string System { get; set; }

        [Newtonsoft.Json.JsonProperty("Code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("ExtraDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExtraDetail { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Warning
    {
        [Newtonsoft.Json.JsonProperty("TimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TimeStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("System", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string System { get; set; }

        [Newtonsoft.Json.JsonProperty("Code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("ExtraDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExtraDetail { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Information
    {
        [Newtonsoft.Json.JsonProperty("TimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TimeStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("System", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string System { get; set; }

        [Newtonsoft.Json.JsonProperty("Code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Code { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("ExtraDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExtraDetail { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MessageType
    {
        [Newtonsoft.Json.JsonProperty("Sender", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SystemType Sender { get; set; }

        /// <summary>he date time stamp that the Sender created this message</summary>
        [Newtonsoft.Json.JsonProperty("CreationDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CreationDateTime { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ResultType
    {
        [Newtonsoft.Json.JsonProperty("ResultCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResultCode { get; set; }

        [Newtonsoft.Json.JsonProperty("MatchPercent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MatchPercent { get; set; }

        [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Message Message { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DataAreaType
    {
        /// <summary>The details of the party</summary>
        [Newtonsoft.Json.JsonProperty("Party", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Party Party { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class MemebershipType
    {
        [Newtonsoft.Json.JsonProperty("MembershipCardNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipCardNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("MembershipNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("MembershipTypeCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipTypeCode { get; set; }

        [Newtonsoft.Json.JsonProperty("LoyaltyLevelCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LoyaltyLevelCode { get; set; }

        [Newtonsoft.Json.JsonProperty("MembershipCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipCategory { get; set; }

        [Newtonsoft.Json.JsonProperty("MembershipStatusCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipStatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("MembershipJoinedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MembershipJoinedDate { get; set; }

        [Newtonsoft.Json.JsonProperty("EffectiveFromDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EffectiveFromDate { get; set; }

        [Newtonsoft.Json.JsonProperty("EffectiveToDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EffectiveToDate { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ExternalIdentifierType
    {
        [Newtonsoft.Json.JsonProperty("Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("IdentifierTypeCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdentifierTypeCode { get; set; }


    }

    /// <summary>A number or code assigned to a party by an organisation, establishment or agency in order to uniquely identify that party. The possible values are not standardized or codified, as the data is dependent on the
    /// issuer and type of identifier.
    /// Examples:
    /// A businesses Australian business number (ABN): 85 087 326 690
    /// An individuals Medicare card number (MCN): 2345 56789 8</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class IdentifierIdentificationType
    {
        [Newtonsoft.Json.JsonProperty("IdentificationSchemeAgencyIdentifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdentificationSchemeAgencyIdentifier { get; set; }

        [Newtonsoft.Json.JsonProperty("IdentificationSchemeAgencyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IdentificationSchemeAgencyName { get; set; }

        [Newtonsoft.Json.JsonProperty("Designation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Designation { get; set; }

        [Newtonsoft.Json.JsonProperty("LinkedPartyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LinkedPartyId { get; set; }

        [Newtonsoft.Json.JsonProperty("LastModifiedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LastModifiedDate { get; set; }


    }

    /// <summary>Party details</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Party
    {
        /// <summary>Type of party - person or organisation</summary>
        [Newtonsoft.Json.JsonProperty("Type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>The date when a person was born</summary>
        [Newtonsoft.Json.JsonProperty("BirthDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BirthDate { get; set; }

        /// <summary>RACQ - Used to indicate the status of a person eg. Alive, Deceased</summary>
        [Newtonsoft.Json.JsonProperty("PersonStatusIndicator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PersonStatusIndicator { get; set; }

        [Newtonsoft.Json.JsonProperty("IdentifierIdentification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<IdentifierIdentificationType> IdentifierIdentification { get; set; }

        [Newtonsoft.Json.JsonProperty("Membership", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MemebershipType Membership { get; set; }

        [Newtonsoft.Json.JsonProperty("ExternalIdentifierList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ExternalIdentifierType> ExternalIdentifierList { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Message
    {
        [Newtonsoft.Json.JsonProperty("Errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Error> Errors { get; set; }

        [Newtonsoft.Json.JsonProperty("Warnings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Warning> Warnings { get; set; }

        [Newtonsoft.Json.JsonProperty("InformationList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Information> InformationList { get; set; }


    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108