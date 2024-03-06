using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPatientType : RestClient
    {
        public string patTypeCode { get; set; }
        public string typeName { get; set; }

        public JsonPatientType()
        {
            EndPoint = Settings.Default.RestURL + "patientType";
            RoutesJSON = "patientType";
        }

        public string AddPatientType(JsonPatientType json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [patientType] :" + ex.Message);
            }
        }
    }
}