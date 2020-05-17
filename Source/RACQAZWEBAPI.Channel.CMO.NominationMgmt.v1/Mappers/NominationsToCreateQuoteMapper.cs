namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateQuote
{
    using Boxed.Mapping;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Message = QuoteManagement.Model.Message;

    public class NominationsToCreateQuoteMapper : IMapper<Tuple<Nominations.Model.Nominations, IdentifierIdentificationType>, ApttusQuote>
    {
        public void Map(Tuple<Nominations.Model.Nominations, IdentifierIdentificationType> source, ApttusQuote destination)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = destination ?? throw new ArgumentNullException(nameof(destination));

            _ = source ?? throw new ArgumentNullException(nameof(source));
            var sourceNomination = source.Item1;
            var sourcePartyIdentifierIdentification = source.Item2;

            destination.ApplicationArea = new ApplicationArea
            {
                Message = new Message
                {
                    CreationDateTime = DateTime.Now.ToLocalTime(),
                    Sender = new Sender
                    {
                        SystemComponentId = MappingConstants.SystemComponentId,
                        SystemReferenceId = $"Nomination: {sourceNomination.DataArea.Nomination.NominationID} {sourceNomination.DataArea.Nomination.NominationDate}",
                        SystemId = MappingConstants.SystemId,
                    }
                }
            };
            destination.DataArea = new DataArea
            {
                ProductAgreementList = GetProductAgreementList(sourceNomination.DataArea.Nomination, sourcePartyIdentifierIdentification)
            };
        }

        private static List<ProductAgreement> GetProductAgreementList(Nominations.Model.Nomination sourceNomination, IdentifierIdentificationType sourcePartyIdentifierIdentification)
        {
            var productagreements = new List<ProductAgreement>{
                new ProductAgreement
                {
                    IdentifierIdentification = GetIdentifierIdentification(),
                    AgreementStartDate = DateTime.ParseExact(sourceNomination.NominationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"),
                    ProductAgreementReference = GetProductAgreementReference(sourceNomination),
                    VehicleCoverableList = GetVehicleCoverableList(sourceNomination),
                    ProductTypeCode = MappingConstants.ProgramCodes[sourceNomination.ProgramCode],
                }};

            foreach (var productagreement in productagreements)
            {
                productagreement.IdentifierIdentification = new List<IdentifierIdentification>
                {
                    new IdentifierIdentification
                    {
                        IdentificationSchemeAgencyIdentifier = sourcePartyIdentifierIdentification.IdentificationSchemeAgencyIdentifier,
                        IdentificationSchemeAgencyName = sourcePartyIdentifierIdentification.IdentificationSchemeAgencyName,
                        Designation = sourcePartyIdentifierIdentification.Designation
                    }
                };
            }

            return productagreements;
        }

        private static List<ProductAgreementReference> GetProductAgreementReference(Nominations.Model.Nomination source) => new List<ProductAgreementReference>{
                new ProductAgreementReference
                {
                     TypeCode = MappingConstants.NominationProductName,
                     Id = MappingConstants.ProductAgreementReferenceCodes[source.ProgramCode]
                }};

        private static List<IdentifierIdentification> GetIdentifierIdentification() => new List<IdentifierIdentification>{
                new IdentifierIdentification
                {
                    Designation = string.Empty,
                    IdentificationSchemeAgencyIdentifier =MappingConstants.ApttusAgencyIdentifier,
                    IdentificationSchemeAgencyName=MappingConstants.ApttusAIdentificationSchemeAgencyName,
                }};

        private static List<VehicleCoverable> GetVehicleCoverableList(Nominations.Model.Nomination source) => new List<VehicleCoverable>{
                new VehicleCoverable
                {
                    Vehicle = GetVehicle(source)
                }};

        private static Vehicle GetVehicle(Nominations.Model.Nomination source) => new Vehicle
        {
            Manufacturer = new Manufacturer
            {
                BrandName = source.Make,
                // ManufacturerName = source.Make,
                ModelName = source.Model,
                ModelVariant = source.Series,
                ModelYear = source.YearOfRelease
            },
            RegistrationNumber = GetRegistrationNumber(source),
            Status = MappingConstants.APTTUSQuoteDefaultStatus,
            Measurement = new VehicleMeasurementType { LengthMeasure = new LengthMeasure5 { Measure = 0, UnitCode = "mm" } },
            VehicleBody = new VehicleBody { Colour = source.Colour, Description = source.Description }
        };

        private static List<Registration> GetRegistrationNumber(Nominations.Model.Nomination source) => new List<Registration>{
                new Registration
                {
                    Id = source.Rego,
                    JurisdictionCode=source.State
                }};
    }
}