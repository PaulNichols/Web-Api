namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation
{
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using System;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>")]
    public class NominationValidator : IValidator<Nomination>
    {
        public string Validate(Nomination nomination)
        {
            if (nomination == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(nomination.ProgramCode))
            {
                return MappingConstants.PartyResponseValidationErrors["ProgramCode"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Trans_Type))
            {
                return MappingConstants.PartyResponseValidationErrors["Trans_Type"];
            }

            if (string.IsNullOrWhiteSpace(nomination.NominationDate))
            {
                return MappingConstants.PartyResponseValidationErrors["NominationDate"];
            }

            if ((nomination.ProgramCode == "FDC" || nomination.ProgramCode == "MDC") && string.IsNullOrWhiteSpace(nomination.ServiceDate))
            {
                return MappingConstants.PartyResponseValidationErrors["ServiceDate"];
            }

            if (string.IsNullOrWhiteSpace(nomination.VIN))
            {
                return MappingConstants.PartyResponseValidationErrors["VIN"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Description))
            {
                return MappingConstants.PartyResponseValidationErrors["Description"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Make))
            {
                return MappingConstants.PartyResponseValidationErrors["Make"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Model))
            {
                return MappingConstants.PartyResponseValidationErrors["Model"];
            }

            if (string.IsNullOrWhiteSpace(nomination.BodyType))
            {
                return MappingConstants.PartyResponseValidationErrors["BodyType"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Colour))
            {
                return MappingConstants.PartyResponseValidationErrors["Colour"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Rego))
            {
                return MappingConstants.PartyResponseValidationErrors["Rego"];
            }

            if (string.IsNullOrWhiteSpace(nomination.OwnerType))
            {
                return MappingConstants.PartyResponseValidationErrors["OwnerType"];
            }

            if (string.IsNullOrWhiteSpace(nomination.FirstName))
            {
                return MappingConstants.PartyResponseValidationErrors["FirstName"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Surname))
            {
                return MappingConstants.PartyResponseValidationErrors["Surname"];
            }

            if (nomination.DOB == default(DateTime?))
            {
                return MappingConstants.PartyResponseValidationErrors["DOB"];
            }

            if (string.IsNullOrWhiteSpace(nomination.HomePhone) && string.IsNullOrWhiteSpace(nomination.BusinessPhone) && string.IsNullOrWhiteSpace(nomination.MobilePhone))
            {
                return MappingConstants.PartyResponseValidationErrors["Phone"];
            }

            if (string.IsNullOrWhiteSpace(nomination.StateofMembership))
            {
                return MappingConstants.PartyResponseValidationErrors["StateofMembership"];
            }

            if (string.IsNullOrWhiteSpace(nomination.City))
            {
                return MappingConstants.PartyResponseValidationErrors["City"];
            }

            if (string.IsNullOrWhiteSpace(nomination.State))
            {
                return MappingConstants.PartyResponseValidationErrors["State"];
            }

            if (string.IsNullOrWhiteSpace(nomination.NominationID))
            {
                return MappingConstants.PartyResponseValidationErrors["NominationID"];
            }

            if (nomination.ProgramCode == "SMY" && string.IsNullOrWhiteSpace(nomination.StartDate))
            {
                return MappingConstants.PartyResponseValidationErrors["StartDate"];
            }

            if (string.IsNullOrWhiteSpace(nomination.AddressLine1))
            {
                return MappingConstants.PartyResponseValidationErrors["AddressLine1"];
            }

            if (string.IsNullOrWhiteSpace(nomination.Postcode))
            {
                return MappingConstants.PartyResponseValidationErrors["Postcode"];
            }

            return null;
        }
    }
}