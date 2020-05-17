namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation
{
    public interface IValidator<in T>
    {
        string Validate(T instance);
    }
}