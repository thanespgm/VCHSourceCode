using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS.ConHISManager
{
    internal class JsonPatients : RestClient
    {
        public string Hn { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        public int GenderId { get; set; }
        public int LanguageId { get; set; }

        public JsonPatients()
        {
            EndPoint = Settings.Default.RestURL + "v1/patients";
            RoutesJSON = "patient";
        }

        public string AddPatients(JsonPatients json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [v1/patient] :" + ex.Message);
            }
        }
    }
}