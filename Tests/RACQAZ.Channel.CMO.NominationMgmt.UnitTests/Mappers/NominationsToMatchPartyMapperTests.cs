using AutoFixture;
using Boxed.Mapping;
using FluentAssertions;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.MatchParty;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests.Mappers
{
    public class NominationsToMatchPartyMapperTests : MappingTestsBase
    {
        public NominationsToMatchPartyMapperTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private readonly ITestOutputHelper output;

        [Fact]
        public void MapMatchPartyRequest_WhenSourceIsPopulated_ShouldMap()
        {
            // Arrange
            var mapper = new NominationsToMatchPartyMapper();
            var source = new Fixture().Create<Nominations>();
            Nomination sourceNomination = source.DataArea.Nomination;

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();

            destination.ApplicationArea.Interaction.Originator.SystemId.Should().Be("API");
            destination.ApplicationArea.Interaction.Originator.SystemComponentId.Should().Be("RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1");
            destination.ApplicationArea.Interaction.Originator.SystemReferenceId.Should().Be($"Nomination: {sourceNomination.NominationID} {sourceNomination.NominationDate}");

            destination.DataArea.MatchCriteria.Party.Membership.MembershipCardNumber.Should().Be(sourceNomination.ExistingClubMembershipNumber);
            destination.DataArea.MatchCriteria.Party.Person.BirthDate.Should().Be(sourceNomination.DOB);
            destination.DataArea.MatchCriteria.Party.Person.PersonName.FirstName.Should().Be(sourceNomination.FirstName);
            destination.DataArea.MatchCriteria.Party.Person.PersonName.LastName.Should().Be(sourceNomination.Surname);
            destination.DataArea.MatchCriteria.Party.Email.Single().EmailAddress.Should().Be(sourceNomination.Email);

            destination.DataArea.MatchCriteria.Party.Telephone[0].TelephoneNumber.Should().Be(sourceNomination.HomePhone);
            destination.DataArea.MatchCriteria.Party.Telephone[1].TelephoneNumber.Should().Be(sourceNomination.BusinessPhone);
            destination.DataArea.MatchCriteria.Party.Telephone[2].TelephoneNumber.Should().Be(sourceNomination.MobilePhone);

            var destAddress = destination.DataArea.MatchCriteria.Party.Address[0];
            destAddress.StreetName.Should().Be(sourceNomination.AddressLine1);
            destAddress.SuburbName.Should().Be(sourceNomination.City);
            destAddress.StateTerritory.Should().Be(sourceNomination.State);
            destAddress.PostCode.Should().Be(sourceNomination.Postcode);

            var destPostalAddress = destination.DataArea.MatchCriteria.Party.Address[1];
            destPostalAddress.StreetName.Should().Be(sourceNomination.PostalAddressLine1);
            destPostalAddress.SuburbName.Should().Be(sourceNomination.PostalCity);
            destPostalAddress.StateTerritory.Should().Be(sourceNomination.PostalState);
            destPostalAddress.PostCode.Should().Be(sourceNomination.PostalPostcode);

            destination.DataArea.MatchCriteria.Party.Organisation.OrganisationNameList.Single().OrganisationName.Should().Be(sourceNomination.BusinessName);

            destination.DataArea.MatchCriteria.Party.ExternalIdentifiers[1].IdentifierType.Should().Be("VehicleRegistrationNumber");
            destination.DataArea.MatchCriteria.Party.ExternalIdentifiers[1].Id.Should().Be(sourceNomination.Rego);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(11)]
        public void MapMatchPartyRequest_WhenABNIsPopulated_ShouldMap(int abnLength)
        {
            // Arrange
            var mapper = new NominationsToMatchPartyMapper();
            var source = new Fixture().Create<Nominations>();
            Nomination sourceNomination = source.DataArea.Nomination;
            sourceNomination.ABN = sourceNomination.ABN.Substring(0, abnLength);

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();

            destination.DataArea.MatchCriteria.Party.ExternalIdentifiers[0].IdentifierType.Should().Be(abnLength == 9 ? "ACN" : "ABN");
            destination.DataArea.MatchCriteria.Party.ExternalIdentifiers[0].Id.Should().Be(sourceNomination.ABN);
        }

        [Fact]
        public void MapMatchPartyRequest_WhenSourceValuesAreNull_ShouldNotMap()
        {
            // Arrange
            var mapper = new NominationsToMatchPartyMapper();
            var source = new Fixture().Create<Nominations>();

            Nomination sourceNomination = source.DataArea.Nomination;
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

            // Act
            var destination = mapper.Map(source);

            // Assert
            destination.IsNotNull();

            destination.DataArea.MatchCriteria.Party.Membership.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.Person.BirthDate.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.Person.PersonName.FirstName.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.Person.PersonName.LastName.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.Email.Should().BeNull();

            destination.DataArea.MatchCriteria.Party.Address.Should().HaveCount(1);

            var destAddress = destination.DataArea.MatchCriteria.Party.Address[0];
            destAddress.StreetName.Should().BeNull();
            destAddress.SuburbName.Should().BeNull();
            destAddress.StateTerritory.Should().BeNull();
            destAddress.PostCode.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.ExternalIdentifiers.Should().BeNull();
            destination.DataArea.MatchCriteria.Party.Organisation.Should().BeNull();
        }
    }
}