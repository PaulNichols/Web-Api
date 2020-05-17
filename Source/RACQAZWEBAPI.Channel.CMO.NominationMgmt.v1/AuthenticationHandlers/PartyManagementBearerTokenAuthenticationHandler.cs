namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1
{
    using Helper.Library.Authentication;
    using LazyCache;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options;

    public class PartyManagementBearerTokenAuthenticationHandler : BearerTokenAuthenticationDelegatingHandler
    {
        public PartyManagementBearerTokenAuthenticationHandler(PartyManagementAuthOptions authOptions, IAppCache cache) : base(authOptions, cache)
        {
        }
    }
}