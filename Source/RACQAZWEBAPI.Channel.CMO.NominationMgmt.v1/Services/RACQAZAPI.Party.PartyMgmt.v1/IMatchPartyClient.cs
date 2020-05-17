using System.Threading.Tasks;
using MatchRequest = RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Request;
using MatchResponse = RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Response;

public interface IPartyMatchClient
{
    Task<MatchResponse.MatchPartyResponse> MatchPartyAsync(MatchRequest.MatchPartyRequest request);
}

