using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonDruginfo : RestClient
    {
        public string drugCode { get; set; }
        public string drugName { get; set; }
        public string drugNamePrint { get; set; }
        public string drugNameThai { get; set; }
        public int drugStatus { get; set; }
        public int toMachineNo { get; set; }
        public string NDC { get; set; }
        public string locationBin { get; set; }

        public JsonDruginfo()
        {
            EndPoint = Settings.Default.RestURL + "drug";
            RoutesJSON = "drug";
        }

        public string AddDrugInfo(JsonDruginfo json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [drug] :" + ex.Message);
            }
        }
    }
}