using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Response;
using System.Linq;

namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models
{
    public static class MatchPartyResponseExtensions
    {
        public static bool IsFullMatch(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.Result?.MatchPercent == MappingConstants.FullMatch;
        }

        public static bool IsPartyDead(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.DataArea?.Party?.PersonStatusIndicator != MappingConstants.PartyMatchedAlive;
        }

        public static bool IsNoMatch(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.Result?.MatchPercent == "0";
        }

        public static bool IsPartialMatch(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.Result?.MatchPercent == MappingConstants.PartialMatch;
        }

        public static string GetD365Id(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.DataArea?.Party?.IdentifierIdentification?.FirstOrDefault(x => x?.IdentificationSchemeAgencyIdentifier == MappingConstants.D365AgencyIdentifier)?.Designation;
        }

        public static string GetApttusId(this MatchPartyResponse matchPartyResponse)
        {
            return matchPartyResponse?.DataArea?.Party?.IdentifierIdentification?.FirstOrDefault(x => x?.IdentificationSchemeAgencyIdentifier == MappingConstants.ApttusAgencyIdentifier)?.Designation;
        }
    }
}