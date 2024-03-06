using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonUsage : RestClient
    {
        public string timeCode { get; set; }
        public string timeName { get; set; }

        public JsonUsage()
        {
            EndPoint = Settings.Default.RestURL + "usage";
            RoutesJSON = "usage";
        }

        public string AddUsage(JsonUsage json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [usage] :" + ex.Message);
            }
        }
    }
}