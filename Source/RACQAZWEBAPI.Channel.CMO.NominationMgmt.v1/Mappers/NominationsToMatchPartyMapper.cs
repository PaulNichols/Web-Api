namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.MatchParty
{
    using Boxed.Mapping;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NominationsToMatchPartyMapper : IMapper<Nominations, MatchPartyRequest>
    {
        public void Map(Nominations source, MatchPartyRequest destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (destination == null) throw new ArgumentNullException(nameof(destination));

            var localTime = DateTime.Now;
            var localTimeAndOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));

            destination.ApplicationArea = new API.MatchParty.Models.Request.ApplicationArea
            {
                Interaction = new API.MatchParty.Models.Request.Interaction
                {
                    InteractionDateTime = localTimeAndOffset,
                    Originator = new Originator
                    {
                        SystemComponentId = MappingConstants.SystemComponentId,
                        SystemReferenceId = $"Nomination: {source.DataArea.Nomination.NominationID} {source.DataArea.Nomination.NominationDate}",
                        SystemId = MappingConstants.SystemId,
                    }
                },
            };

            destination.DataArea = new API.MatchParty.Models.Request.DataArea
            {
                MatchCriteria = new MatchCriteria
                {
                    Party = new Party
                    {
                        PartyType = source.DataArea.Nomination.OwnerType == "P" ? MappingConstants.PartyOwnerTypeP : MappingConstants.PartyOwnerTypeB1,
                        Person = MapPerson(source.DataArea.Nomination),
                        Email = MapEmail(source),
                        Telephone = MapTelephone(source.DataArea.Nomination),
                        Address = MapAddresses(source.DataArea.Nomination),
                        ExternalIdentifiers = MapExternalIdentifiers(source.DataArea.Nomination),
                        Membership = MapMembership(source.DataArea.Nomination),
                        Organisation = MapOrganisation(source.DataArea.Nomination)
                    },
                }
            };
        }

        private static EmailType MapEmail(Nominations source)
        {
            if (string.IsNullOrWhiteSpace(source.DataArea.Nomination.Email))
            {
                return null;
            }

            return new EmailType { new Email { EmailAddress = source.DataArea.Nomination.Email } };
        }

        private static Membership MapMembership(Nomination nomination)
        {
            if (string.IsNullOrWhiteSpace(nomination.ExistingClubMembershipNumber))
            {
                return null;
            }

            return new Membership
            {
                MembershipCardNumber = nomination.ExistingClubMembershipNumber
            };
        }

        private static Person MapPerson(Nomination source)
        {
            return new Person
            {
                PersonName = new PersonName
                {
                    FirstName = source.FirstName,
                    LastName = source.Surname
                },
                BirthDate = source.DOB,
            };
        }

        private static AddressType MapAddresses(Nomination source)
        {
            var addresses = new AddressType();

            var address = new Address
            {
                StreetName = source.AddressLine1,
                SuburbName = source.City,
                StateTerritory = source.State,
                PostCode = source.Postcode,
                Country = MappingConstants.Country
            };

            addresses.Add(address);

            if (!string.IsNullOrWhiteSpace(source.PostalAddressLine1))
            {
                address = new Address
                {
                    StreetName = source.PostalAddressLine1,
                    SuburbName = source.PostalCity,
                    StateTerritory = source.PostalState,
                    PostCode = source.PostalPostcode,
                    Country = MappingConstants.Country
                };

                addresses.Add(address);
            }

            return addresses.Any() ? addresses : null;
        }

        private static TelephoneType MapTelephone(Nomination source)
        {
            var phones = new TelephoneType
            {
                MapPhone(source.HomePhone),
                MapPhone(source.BusinessPhone),
                MapPhone(source.MobilePhone),
            };

            phones.RemoveWhere(x => x == null);
            return phones.Any() ? phones : null;
        }

        private static Telephone MapPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return null;
            }

            return new Telephone
            {
                TelephoneNumber = phoneNumber
            };
        }

        private static ExternalIdentifiersType MapExternalIdentifiers(Nomination source)
        {
            var identifiers = new ExternalIdentifiersType();

            if (!string.IsNullOrWhiteSpace(source.ABN))
            {
                identifiers.Add(new ExternalIdentifiers
                {
                    Id = source.ABN,
                    IdentifierType = source.ABN.Replace(" ", "").Length == 9 ? MappingConstants.OrgACN : MappingConstants.OrgABN
                });
            }

            if (!string.IsNullOrWhiteSpace(source.Rego))
            {
                identifiers.Add(new ExternalIdentifiers
                {
                    Id = source.Rego,
                    IdentifierType = MappingConstants.regoIdentifierType
                });
            }

            return identifiers.Any() ? identifiers : null;
        }

        private static Organisation MapOrganisation(Nomination source)
        {
            if (string.IsNullOrWhiteSpace(source.BusinessName))
            {
                return null;
            }

            return new Organisation
            {
                OrganisationNameList = new List<OrganisationNames>
                {
                    new OrganisationNames
                    {
                        OrganisationName = source.BusinessName,
                        OrganisationNameType = string.Empty
                    }
                },
                OragnisationTypeCode = string.Empty
            };
        }
    }
}