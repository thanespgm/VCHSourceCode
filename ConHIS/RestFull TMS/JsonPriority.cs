using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPriority : RestClient
    {
        public string priorityCode { get; set; }
        public string priorityName { get; set; }

        public JsonPriority()
        {
            EndPoint = Settings.Default.RestURL + "priority";
            RoutesJSON = "priority";
        }

        public string AddPriority(JsonPriority json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [priority] :" + ex.Message);
            }
        }
    }
}