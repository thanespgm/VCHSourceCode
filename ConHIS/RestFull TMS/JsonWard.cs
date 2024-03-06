using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonWard : RestClient
    {
        public string wardCode { get; set; }
        public string wardName { get; set; }
        public int status { get; set; }

        public JsonWard()
        {
            EndPoint = Settings.Default.RestURL + "ward";
            RoutesJSON = "ward";
        }

        public string AddWard(JsonWard json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [ward] :" + ex.Message);
            }
        }
    }
}