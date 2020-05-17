namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty
{
    using Boxed.Mapping;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NominationsToCreatePartyMapper : IMapper<Nominations, PartyRequest>
    {
        public void Map(API.Nominations.Model.Nominations source, PartyRequest destination)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = destination ?? throw new ArgumentNullException(nameof(destination));

            destination.PartyRequest1 = new PartyRequest1
            {
                DataArea = new PartyManagement.Request.DataArea
                {
                    Party = MapParty(source.DataArea.Nomination)
                }
            };
        }

        private static Party2 MapParty(API.Nominations.Model.Nomination source)
        {
            return new Party2
            {
                Type = source.OwnerType == "P" ? PartyType.Person : PartyType.Organisation,
                SpecifiedPerson = source.OwnerType == "P" ? MapSpecifiedPerson(source) : null,
                SpecifiedOrganisation = source.OwnerType == "B1" ? MapSpecifiedOrganisation(source) : null,
            };
        }

        private static SpecifiedPerson MapSpecifiedPerson(Nomination source) => new SpecifiedPerson
        {
            ContactInternet = MapContactInternet(source),
            ContactTelephone = MapContactTelephone(source),
            Address = MapAddresses(source),
            BirthDate = source.DOB,
            SpecifiedPersonName = MapSpecifiedPersonName(source),
            Communication = MapCommunications()
        };

        private static SpecifiedOrganisationType MapSpecifiedOrganisation(Nomination source) => new SpecifiedOrganisationType
        {
            SpecifiedOrganisationName = MapSpecifiedOrganisationName(source),
            ContactTelephone = MapContactTelephone(source),
            ContactInternet = MapContactInternet(source),
            Address = MapAddresses(source),
            Communication = MapCommunications(),
            IdentifierIdentification = MapIdentifierIdentification(source),
            ContactPerson = MapContactPerson(source),
        };

        private static ContactPerson MapContactPerson(Nomination source)
        {
            return new ContactPerson
            {
                FullName = $"{source.FirstName} {source.Surname}"
            };
        }

        private static List<SpecifiedOrganisationName> MapSpecifiedOrganisationName(Nomination source) => new List<SpecifiedOrganisationName> { new SpecifiedOrganisationName { Name = source.BusinessName } };

        private static List<SpecifiedPersonName> MapSpecifiedPersonName(Nomination source) => new List<SpecifiedPersonName> {
            new SpecifiedPersonName
            {
                GivenName = MapGivenName(source),
                FamilyName = source.Surname,
                UsageType = SpecifiedPersonNameUsageType.LGL
            }};

        private static List<GivenName> MapGivenName(Nomination source)
        {
            return new List<GivenName> { new GivenName { SequenceNumber = 1, Name = source.FirstName } };
        }

        private static List<IdentifierIdentificationType> MapIdentifierIdentification(Nomination source) => new List<IdentifierIdentificationType>{
                new IdentifierIdentificationType
                {
                    Designation = source.ABN,
                    IdentificationSchemeAgencyIdentifier =  source.ABN.Replace(" ","").Length == MappingConstants.OrgACNDigits ? MappingConstants.OrgABN:MappingConstants.OrgACN
                }};

        private static List<ContactTelephone> MapContactTelephone(Nomination source)
        {
            var contactTelephoneList = new List<ContactTelephone>();

            if (!string.IsNullOrWhiteSpace(source.HomePhone))
            {
                contactTelephoneList.Add(new ContactTelephone
                {
                    Usage = ContactTelephoneUsage._01,
                    TelephoneNumber = source.HomePhone
                });
            }
            if (!string.IsNullOrWhiteSpace(source.BusinessPhone))
            {
                contactTelephoneList.Add(new ContactTelephone
                {
                    Usage = ContactTelephoneUsage._02,
                    TelephoneNumber = source.BusinessPhone
                });
            }
            if (!string.IsNullOrWhiteSpace(source.MobilePhone))
            {
                contactTelephoneList.Add(new ContactTelephone
                {
                    Usage = ContactTelephoneUsage._03,
                    TelephoneNumber = source.MobilePhone
                });
            }

            return contactTelephoneList;
        }

        private static List<ContactInternet> MapContactInternet(Nomination source)
        {
            if (string.IsNullOrWhiteSpace(source.Email))
            {
                return null;
            }

            return new List<ContactInternet>{new ContactInternet
            {
                Usage =ContactInternetUsage._01,
                EmailAddress = source.Email
            }};
        }

        private static List<Address> MapAddresses(Nomination source)
        {
            var addressses = new List<Address>
            {
                new Address
                {
                    Usage = MappingConstants.AddressUsageResidential,
                    Line1 = $"{source.AddressLine1} {source.AddressLine2}",
                    LocalityName = source.City,
                    StateTerritory = source.State,
                    PostCode = source.Postcode,
                    CountryName = MappingConstants.AddressCountryName,
                }
            };

            if (!string.IsNullOrWhiteSpace(source.PostalAddressLine1))
            {
                addressses.Add(new Address
                {
                    Usage = MappingConstants.AddressUsagePostal,
                    Line1 = $"{source.PostalAddressLine1} {source.PostalAddressLine2}",
                    LocalityName = source.PostalCity,
                    StateTerritory = source.PostalState,
                    PostCode = source.PostalPostcode,
                    CountryName = MappingConstants.AddressCountryName,
                });
            }

            return addressses.Any() ? addressses : null;
        }

        private static List<Communication> MapCommunications()
        {
            var communications = new List<Communication>();

            foreach (var deliveryChannel in MappingConstants.DeliveryChannels)
            {
                communications.Add(new Communication
                {
                    DeliverySubscription = deliveryChannel,
                    CommunicationPreference = MappingConstants.CommunicationPreferencePostal
                });
            }

            return communications;
        }
    }
}