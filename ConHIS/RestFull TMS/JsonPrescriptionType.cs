using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPrescriptionType : RestClient
    {
        public string presType { get; set; }
        public string typeName { get; set; }

        public JsonPrescriptionType()
        {
            EndPoint = Settings.Default.RestURL + "prescriptionType";
            RoutesJSON = "prescriptionType";
        }

        public string AddPrescriptionType(JsonPrescriptionType json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [prescriptionType] :" + ex.Message);
            }
        }
    }
}