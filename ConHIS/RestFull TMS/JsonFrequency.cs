using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonFrequency : RestClient
    {
        public string frequencyCode { get; set; }
        public string frequencyName { get; set; }

        public JsonFrequency()
        {
            EndPoint = Settings.Default.RestURL + "frequency";
            RoutesJSON = "frequency";
        }

        public string AddFrequecy(JsonFrequency json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [frequency] :" + ex.Message);
            }
        }
    }
}