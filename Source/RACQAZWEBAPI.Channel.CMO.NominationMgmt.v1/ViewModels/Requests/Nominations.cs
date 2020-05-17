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

namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model
{
    using System = global::System;



    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nominations
    {
        [Newtonsoft.Json.JsonProperty("ApplicationArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ApplicationArea ApplicationArea { get; set; }

        [Newtonsoft.Json.JsonProperty("DataArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DataArea DataArea { get; set; }

        [Newtonsoft.Json.JsonProperty("Result", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ResultType Result { get; set; }


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
    public partial class ApplicationArea
    {
        [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MessageType Message { get; set; }

        [Newtonsoft.Json.JsonProperty("Interaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Interaction Interaction { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class DataArea
    {
        [Newtonsoft.Json.JsonProperty("Nomination", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Nomination Nomination { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class Nomination
    {
        [Newtonsoft.Json.JsonProperty("Identifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Identifier { get; set; }

        [Newtonsoft.Json.JsonProperty("Batch_No", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Batch_No { get; set; }

        [Newtonsoft.Json.JsonProperty("Batch_Type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Batch_Type { get; set; }

        [Newtonsoft.Json.JsonProperty("ProgramCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProgramCode { get; set; }

        [Newtonsoft.Json.JsonProperty("ClientCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClientCode { get; set; }

        [Newtonsoft.Json.JsonProperty("Trans_Type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Trans_Type { get; set; }

        [Newtonsoft.Json.JsonProperty("NominationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NominationDate { get; set; }

        [Newtonsoft.Json.JsonProperty("ServiceDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ServiceDate { get; set; }

        [Newtonsoft.Json.JsonProperty("VIN", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VIN { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("Make", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Make { get; set; }

        [Newtonsoft.Json.JsonProperty("Model", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Model { get; set; }

        [Newtonsoft.Json.JsonProperty("BodyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BodyType { get; set; }

        [Newtonsoft.Json.JsonProperty("Series", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Series { get; set; }

        [Newtonsoft.Json.JsonProperty("Variant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Variant { get; set; }

        [Newtonsoft.Json.JsonProperty("Colour", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Colour { get; set; }

        [Newtonsoft.Json.JsonProperty("Transmission", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Transmission { get; set; }

        [Newtonsoft.Json.JsonProperty("YearOfRelease", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string YearOfRelease { get; set; }

        [Newtonsoft.Json.JsonProperty("Rego", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Rego { get; set; }

        [Newtonsoft.Json.JsonProperty("OwnerType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OwnerType { get; set; }

        [Newtonsoft.Json.JsonProperty("Title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("FirstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("Surname", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Surname { get; set; }

        [Newtonsoft.Json.JsonProperty("BusinessName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessName { get; set; }

        [Newtonsoft.Json.JsonProperty("ABN", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ABN { get; set; }

        [Newtonsoft.Json.JsonProperty("DOB", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? DOB { get; set; }

        [Newtonsoft.Json.JsonProperty("HomePhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HomePhone { get; set; }

        [Newtonsoft.Json.JsonProperty("BusinessPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessPhone { get; set; }

        [Newtonsoft.Json.JsonProperty("MobilePhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MobilePhone { get; set; }

        [Newtonsoft.Json.JsonProperty("Email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("Privacy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Privacy { get; set; }

        [Newtonsoft.Json.JsonProperty("Consent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Consent { get; set; }

        [Newtonsoft.Json.JsonProperty("StateofMembership", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StateofMembership { get; set; }

        [Newtonsoft.Json.JsonProperty("ExistingClubMembership", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExistingClubMembership { get; set; }

        [Newtonsoft.Json.JsonProperty("ExistingClubMembershipNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExistingClubMembershipNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("ReplacementVehicleRego", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReplacementVehicleRego { get; set; }

        [Newtonsoft.Json.JsonProperty("AddressLine1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddressLine1 { get; set; }

        [Newtonsoft.Json.JsonProperty("AddressLine2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        [Newtonsoft.Json.JsonProperty("City", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty("State", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string State { get; set; }

        [Newtonsoft.Json.JsonProperty("Postcode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Postcode { get; set; }

        [Newtonsoft.Json.JsonProperty("PostalAddressLine1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PostalAddressLine1 { get; set; }

        [Newtonsoft.Json.JsonProperty("PostalAddressLine2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PostalAddressLine2 { get; set; }

        [Newtonsoft.Json.JsonProperty("PostalCity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PostalCity { get; set; }

        [Newtonsoft.Json.JsonProperty("PostalState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PostalState { get; set; }

        [Newtonsoft.Json.JsonProperty("PostalPostcode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PostalPostcode { get; set; }

        [Newtonsoft.Json.JsonProperty("NominationID", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NominationID { get; set; }

        [Newtonsoft.Json.JsonProperty("PlanCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlanCode { get; set; }

        [Newtonsoft.Json.JsonProperty("ClubPlan", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClubPlan { get; set; }

        [Newtonsoft.Json.JsonProperty("ClubPlanCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClubPlanCode { get; set; }

        [Newtonsoft.Json.JsonProperty("StartDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("ExpirationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExpirationDate { get; set; }

        [Newtonsoft.Json.JsonProperty("StatusCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty("StatusDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StatusDescription { get; set; }

        [Newtonsoft.Json.JsonProperty("StatusTimeStamp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StatusTimeStamp { get; set; }

        [Newtonsoft.Json.JsonProperty("StatusExtraDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StatusExtraDetail { get; set; }


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
    public partial class Interaction
    {
        [Newtonsoft.Json.JsonProperty("Originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SystemType Originator { get; set; }

        [Newtonsoft.Json.JsonProperty("InteractionDateTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? InteractionDateTime { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.28.0 (Newtonsoft.Json v11.0.0.0)")]
    public partial class ResultType
    {
        [Newtonsoft.Json.JsonProperty("Message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Message Message { get; set; }

        [Newtonsoft.Json.JsonProperty("ResultCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResultCode { get; set; }


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