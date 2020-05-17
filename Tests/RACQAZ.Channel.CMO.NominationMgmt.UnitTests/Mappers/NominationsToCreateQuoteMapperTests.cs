using AutoFixture;
using Boxed.Mapping;
using FluentAssertions;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateQuote;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response;
using System;
using System.Linq;
using Xunit;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests.Mappers
{
    public class NominationsToCreateQuoteMapperTests
    {
        private NominationsToCreateQuoteMapper CreateNominationsToCreateQuoteMapper()
        {
            return new NominationsToCreateQuoteMapper();
        }

        [Fact]
        public void MapCreateQuoteRequest_WhenSourceIsPopulated_ShouldMap()
        {
            // Arrange
            var mapper = CreateNominationsToCreateQuoteMapper();
            var source = new Fixture().Create<Tuple<Nominations, IdentifierIdentificationType>>();
            var sourceNomination = source.Item1.DataArea.Nomination;
            var sourceIds = source.Item2;

            sourceNomination.NominationDate = "24/10/2019";
            sourceNomination.ProgramCode = "FCM";

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.Should().NotBeNull();

            destination.ApplicationArea.Message.Sender.SystemId.Should().Be("API");
            destination.ApplicationArea.Message.Sender.SystemComponentId.Should().Be("RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1");
            destination.ApplicationArea.Message.Sender.SystemReferenceId.Should().Be($"Nomination: {sourceNomination.NominationID} {sourceNomination.NominationDate}");
            //destination.ApplicationArea.Message.CreationDateTime.Should().NullIf($"Nomination: {sourceNomination.NominationID} {sourceNomination.NominationDate}");

            var destinationProductAgreement = destination.DataArea.ProductAgreementList.Single();
            var destinationProductAgreementReference = destinationProductAgreement.ProductAgreementReference.Single();

            destinationProductAgreement.AgreementStartDate.Should().Be("2019-10-24");
            destinationProductAgreementReference.TypeCode.Should().Be("ProductName");

            var destinationVehicle = destinationProductAgreement.VehicleCoverableList.Single().Vehicle;

            destinationVehicle.Manufacturer.BrandName.Should().Be(sourceNomination.Make);
            destinationVehicle.Manufacturer.ModelName.Should().Be(sourceNomination.Model);
            //destinationVehicle.Manufacturer.ModelSeries.Should().Be(sourceNomination.Series);
            //destinationVehicle.Manufacturer.ModelVariant.Should().Be(sourceNomination.Series);
            destinationVehicle.Manufacturer.ModelYear.Should().Be(sourceNomination.YearOfRelease);

            destinationVehicle.RegistrationNumber.Single().Id.Should().Be(sourceNomination.Rego);
            destinationVehicle.RegistrationNumber.Single().JurisdictionCode.Should().Be(sourceNomination.State);

            destinationVehicle.VehicleBody.Colour.Should().Be(sourceNomination.Colour);
            destinationVehicle.VehicleBody.Description.Should().Be(sourceNomination.Description);
            destinationVehicle.Status.Should().Be("User preferred");

            destinationProductAgreement.IdentifierIdentification.Single().Designation.Should().Be(sourceIds.Designation);
            destinationProductAgreement.IdentifierIdentification.Single().IdentificationSchemeAgencyIdentifier.Should().Be(sourceIds.IdentificationSchemeAgencyIdentifier);
            destinationProductAgreement.IdentifierIdentification.Single().IdentificationSchemeAgencyName.Should().Be(sourceIds.IdentificationSchemeAgencyName);
        }

        [Theory]
        [InlineData("FCM", "Ford CMO (FCM)")]
        [InlineData("FDC", "Ford Dealer Service CMO (FDC)")]
        [InlineData("MCM", "Mitsubishi CMO (MCM)")]
        [InlineData("MDC", "Mitsubishi Dealer Service CMO (MDC)")]
        [InlineData("SCM", "Subaru CMO (SCM)")]
        [InlineData("SMY", "Subaru Multi Year CMO (SMY)")]
        public void MapCreateQuoteRequest_WhenProgramCodeIsSetToSpecifiedValue_ProductAgreementReferenceCodeShouldMapToExpectedValue(string programCode, string expectedValue)
        {
            // Arrange
            var mapper = CreateNominationsToCreateQuoteMapper();
            var source = new Fixture().Create<Tuple<Nominations, IdentifierIdentificationType>>();
            var sourceNomination = source.Item1.DataArea.Nomination;
            sourceNomination.NominationDate = "24/10/2019";

            sourceNomination.ProgramCode = programCode;

            // Act
            var destination = mapper.Map(source);

            // Assert
            var destinationProductAgreement = destination.DataArea.ProductAgreementList.Single();
            var destinationProductAgreementReference = destinationProductAgreement.ProductAgreementReference.Single();

            destinationProductAgreementReference.Id.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("FCM", "ARF001")]
        [InlineData("FDC", "ARF002")]
        [InlineData("MCM", "ARM001")]
        [InlineData("MDC", "ARM002")]
        [InlineData("SCM", "ARS001")]
        [InlineData("SMY", "ARS002")]
        public void MapCreateQuoteRequest_WhenProgramCodeIsSetToSpecifiedValue_ProductAgreementListProductTypeCodeShouldMapToExpectedValue(string programCode, string expectedValue)
        {
            // Arrange
            var mapper = CreateNominationsToCreateQuoteMapper();
            var source = new Fixture().Create<Tuple<Nominations, IdentifierIdentificationType>>();
            var sourceNomination = source.Item1.DataArea.Nomination;
            sourceNomination.NominationDate = "24/10/2019";

            sourceNomination.ProgramCode = programCode;

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.DataArea.ProductAgreementList.Single().ProductTypeCode.Should().Be(expectedValue);
        }
    }
}