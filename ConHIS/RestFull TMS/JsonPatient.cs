using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPatient : RestClient
    {
        public string hn { get; set; }
        public string patientName { get; set; }
        public DateTime patientDOB { get; set; }
        public string sex { get; set; }

        public JsonPatient()
        {
            EndPoint = Settings.Default.RestURL + "patient";
            RoutesJSON = "patient";
        }

        public string AddPatient(JsonPatient json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [patient] :" + ex.Message);
            }
        }
    }
}