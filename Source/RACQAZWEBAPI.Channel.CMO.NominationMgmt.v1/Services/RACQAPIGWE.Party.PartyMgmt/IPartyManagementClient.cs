namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response;
    using System.Threading.Tasks;

    public interface IPartyManagementClient
    {
        Task<CreatePartyResponse> CreateNewPartyAsync(PartyRequest request);
    }
}