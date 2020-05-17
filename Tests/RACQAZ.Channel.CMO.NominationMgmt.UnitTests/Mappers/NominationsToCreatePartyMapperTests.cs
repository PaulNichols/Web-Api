using AutoFixture;
using Boxed.Mapping;
using FluentAssertions;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests.Mappers
{
    public class NominationsToCreatePartyMapperTests : MappingTestsBase
    {
        public NominationsToCreatePartyMapperTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;

        [Fact]
        public void MapCreatePartyRequest_WhenSourceIsAPerson_ShouldMap()
        {
            // Arrange
            var mapper = new NominationsToCreatePartyMapper();
            var source = new Fixture().Create<Nominations>();
            var sourceNomination = source.DataArea.Nomination;

            source.DataArea.Nomination.OwnerType = "P";

            // Act
            PartyRequest destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();

            destination.PartyRequest1.DataArea.Party.Type.Should().Be(PartyType.Person);

            var firstname = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.SpecifiedPersonName.SingleOrDefault(x => x.GivenName.First().Name == sourceNomination.FirstName);
            firstname.Should().NotBeNull();

            var surname = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.SpecifiedPersonName.SingleOrDefault(x => x.FamilyName == sourceNomination.Surname);
            surname.Should().NotBeNull();
            surname.UsageType.Should().Be(SpecifiedPersonNameUsageType.LGL);

            destination.PartyRequest1.DataArea.Party.SpecifiedPerson.BirthDate.Should().Be(sourceNomination.DOB);

            var home = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._01);
            home.TelephoneNumber.Should().Be(sourceNomination.HomePhone);

            var business = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._02);
            business.TelephoneNumber.Should().Be(sourceNomination.BusinessPhone);

            var mobile = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._03);
            mobile.TelephoneNumber.Should().Be(sourceNomination.MobilePhone);

            var email = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.ContactInternet.SingleOrDefault(x => x.Usage == ContactInternetUsage._01);
            email.EmailAddress.Should().Be(sourceNomination.Email);

            var residential = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Address.SingleOrDefault(x => x.Usage == "Residential");
            residential.Line1.Should().Be($"{sourceNomination.AddressLine1} {sourceNomination.AddressLine2}");
            residential.LocalityName.Should().Be(sourceNomination.City);
            residential.StateTerritory.Should().Be(sourceNomination.State);
            residential.PostCode.Should().Be(sourceNomination.Postcode);
            residential.CountryName.Should().Be("AUS");

            var postal = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Address.SingleOrDefault(x => x.Usage == "Postal");
            postal.Line1.Should().Be($"{sourceNomination.PostalAddressLine1} {sourceNomination.PostalAddressLine2}");
            postal.LocalityName.Should().Be(sourceNomination.PostalCity);
            postal.StateTerritory.Should().Be(sourceNomination.PostalState);
            postal.PostCode.Should().Be(sourceNomination.PostalPostcode);
            postal.CountryName.Should().Be("AUS");

            var communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelGlobal" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelAGM" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelMembershipCard" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelTRA" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();
        }

        [Theory]
        [InlineData(9, "ACN")]
        [InlineData(11, "ABN")]
        public void MapCreatePartyRequest_WhenAbnIsPopulated_ShouldMapWithTheCorrectIdentifier(int length, string expectedIdentifier)
        {
            // Arrange
            var mapper = new NominationsToCreatePartyMapper();
            var source = new Fixture().Create<Nominations>();
            var sourceNomination = source.DataArea.Nomination;

            source.DataArea.Nomination.OwnerType = "B1";
            source.DataArea.Nomination.ABN = source.DataArea.Nomination.ABN.Substring(0, length);

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();
            destination.PartyRequest1.DataArea.Party.Type.Should().Be(PartyType.Organisation);

            var id = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.IdentifierIdentification.SingleOrDefault(x => x.IdentificationSchemeAgencyIdentifier == expectedIdentifier && x.Designation == source.DataArea.Nomination.ABN);
            id.Should().NotBeNull();
        }

        [Fact]
        public void MapCreatePartyRequest_WhenSourceIsAnOrganisation_ShouldMap()
        {
            // Arrange
            var mapper = new NominationsToCreatePartyMapper();
            var source = new Fixture().Create<Nominations>();
            var sourceNomination = source.DataArea.Nomination;

            source.DataArea.Nomination.OwnerType = "B1";

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();

            destination.PartyRequest1.DataArea.Party.Type.Should().Be(PartyType.Organisation);
            destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.ContactPerson.FullName.Should().Be($"{sourceNomination.FirstName} {sourceNomination.Surname}");

            var home = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._01);
            home.TelephoneNumber.Should().Be(sourceNomination.HomePhone);

            var business = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._02);
            business.TelephoneNumber.Should().Be(sourceNomination.BusinessPhone);

            var mobile = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.ContactTelephone.SingleOrDefault(x => x.Usage == ContactTelephoneUsage._03);
            mobile.TelephoneNumber.Should().Be(sourceNomination.MobilePhone);

            var email = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.ContactInternet.SingleOrDefault(x => x.Usage == ContactInternetUsage._01);
            email.EmailAddress.Should().Be(sourceNomination.Email);

            var residential = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Address.SingleOrDefault(x => x.Usage == "Residential");
            residential.Line1.Should().Be($"{sourceNomination.AddressLine1} {sourceNomination.AddressLine2}");
            residential.LocalityName.Should().Be(sourceNomination.City);
            residential.StateTerritory.Should().Be(sourceNomination.State);
            residential.PostCode.Should().Be(sourceNomination.Postcode);
            residential.CountryName.Should().Be("AUS");

            var postal = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Address.SingleOrDefault(x => x.Usage == "Postal");
            postal.Line1.Should().Be($"{sourceNomination.PostalAddressLine1} {sourceNomination.PostalAddressLine2}");
            postal.LocalityName.Should().Be(sourceNomination.PostalCity);
            postal.StateTerritory.Should().Be(sourceNomination.PostalState);
            postal.PostCode.Should().Be(sourceNomination.PostalPostcode);
            postal.CountryName.Should().Be("AUS");

            var communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelGlobal" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelAGM" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelMembershipCard" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();

            communicationItem = destination.PartyRequest1.DataArea.Party.SpecifiedOrganisation.Communication.SingleOrDefault(x => x.DeliverySubscription == "DeliveryChannelTRA" && x.CommunicationPreference == "Postal Address");
            communicationItem.Should().NotBeNull();
        }

        [Fact]
        public void MapCreatePartyRequest_WhenSourceValuesAreNull_ShouldNotMap()
        {
            // Arrange
            var mapper = new NominationsToCreatePartyMapper();
            var source = new Fixture().Create<Nominations>();

            Nomination sourceNomination = source.DataArea.Nomination;

            sourceNomination.OwnerType = "P";

            sourceNomination.ExistingClubMembershipNumber = null;
            sourceNomination.DOB = null;
            sourceNomination.FirstName = null;
            sourceNomination.Surname = null;
            sourceNomination.Email = null;
            sourceNomination.City = null;
            sourceNomination.State = null;
            sourceNomination.Postcode = null;
            sourceNomination.AddressLine1 = null;
            sourceNomination.PostalAddressLine1 = null;
            sourceNomination.PostalCity = null;
            sourceNomination.PostalState = null;
            sourceNomination.PostalPostcode = null;
            sourceNomination.ABN = null;
            sourceNomination.Rego = null;
            sourceNomination.BusinessName = null;
            sourceNomination.BusinessPhone = null;
            sourceNomination.MobilePhone = null;
            sourceNomination.HomePhone = null;

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();
            destination.PartyRequest1.DataArea.Party.SpecifiedPerson.ContactTelephone.Should().NotBeNull();
            destination.PartyRequest1.DataArea.Party.SpecifiedPerson.Address.Should().NotBeNull();
        }
    }
}