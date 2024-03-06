using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonAllergy : RestClient
    {
        public string hn { get; set; }
        public string typeCode { get; set; }
        public string allergyName { get; set; }
        public string allergyReaction { get; set; }
        public DateTime reportDate { get; set; }

        public JsonAllergy()
        {
            EndPoint = Settings.Default.RestURL + "allergy";
            RoutesJSON = "allergy";
        }

        public string AddAllergy(JsonAllergy json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [Allergy] :" + ex.Message);
            }
        }
    }
}