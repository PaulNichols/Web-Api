namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers
{
    using Boxed.Mapping;
    using Newtonsoft.Json;
    using RACQAZWEBAPI.Platform.ErrorHandling.Exceptions;
    using Serilog;
    using System;

    public static class MappingHelper
    {
        public static TDestinationU Map<TSource, TDestinationU>(IMapper<TSource, TDestinationU> mapper, TSource src, string messsage) where TDestinationU : new()
        {
            try
            {
                Log.Information(messsage);
                Log.Debug($"Unmapped object is type '{typeof(TSource)}'");
                Log.Debug($"\n{JsonConvert.SerializeObject(src, Formatting.Indented)}");
            }
            catch 
            {
            }

            try
            {
                var dest = mapper.Map(src);

                try
                {
                    Log.Debug($"Mapped object is type '{typeof(TDestinationU)}'");
                    Log.Debug($"\n{JsonConvert.SerializeObject(dest, Formatting.Indented)}");
                }
                catch
                {

                   
                }

                return dest;
            }
            catch (Exception ex)
            {
                var realExcetion = ex.GetBaseException();
                if (realExcetion is BusinessException)
                {
                    throw realExcetion;
                }
                throw;
            }
        }
    }
}