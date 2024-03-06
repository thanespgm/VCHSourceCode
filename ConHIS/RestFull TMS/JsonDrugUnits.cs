using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonDrugUnits : RestClient
    {
        public string unitCode { get; set; }
        public string unitName { get; set; }

        public JsonDrugUnits()
        {
            EndPoint = Settings.Default.RestURL + "drugUnits";
            RoutesJSON = "drugUnits";
        }

        public string AddDrugUnits(JsonDrugUnits json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [drugUnits] :" + ex.Message);
            }
        }
    }
}