namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services
{
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartResponse;
    using System.Threading.Tasks;

    public interface ICartManagementClient
    {
        Task<ApttusCartResponse> FinalizeQuotebyCartIdAsync(ApttusCartRequest request);
    }
}