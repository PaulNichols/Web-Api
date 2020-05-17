namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands
{
    using Boxed.AspNetCore;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;

    public interface IProcessCMONominationsCommand : IAsyncCommand<Nominations>
    {
    }
}