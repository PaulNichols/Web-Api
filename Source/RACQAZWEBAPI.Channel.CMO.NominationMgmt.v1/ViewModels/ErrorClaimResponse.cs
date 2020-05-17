using RACQAZWEBAPI.ClaimNumber.v1.ViewModels;
using System.Collections.Generic;

namespace RACQAZWEBAPI.ClaimCenter.ClaimsMgmt.v1.ViewModels
{

    public class ClaimErrorResponse
    {
        public Dataarea DataArea { get; set; }
    }

    public class Dataarea
    {
        public Results Results { get; set; }
        public Message Message { get; set; }
    }

    public class Results
    {
        public string ResultCode { get; set; }
    }

    public class Message
    {
        [Newtonsoft.Json.JsonProperty("Errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<Errors> Errors { get; set; }

        [Newtonsoft.Json.JsonProperty("Warnings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<Warnings> Warnings { get; set; }

        [Newtonsoft.Json.JsonProperty("InformationList", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.List<InformationList> InformationList { get; set; }


    }

    public class Errors
    {
        public string TimeStamp { get; set; }
        public string System { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ExtraDetail { get; set; }
    }

    //public class ClaimErrorResponse
    //{

    //    public Messages Message { get; set; }
    //    public Result ErrorResult { get; set; }

    //    public class Messages
    //    {
    //        public List<Errors> Errors { get; set; }
    //    }

    //    public class Errors
    //    {
    //        public string Code { get; set; }
    //        public string System { get; set; }
    //        public DateTime Timestamp { get; set; }
    //        public string Description { get; set; }
    //        public string ExtraDetail { get; set; }
    //    }

    //    public class Result
    //    {
    //        public string ResultCode { get; set; }
    //    }

    //}
}
