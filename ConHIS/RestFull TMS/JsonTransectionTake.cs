using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonTransectionTake : RestClient
    {
        public string prescriptionNo { get; set; }
        public int seq { get; set; }
        public DateTime dateTake { get; set; }
        public string timeTake { get; set; }
        public int statusTake { get; set; }
        public string userAcceptTake { get; set; }
        public decimal dosageDispense { get; set; }

        public JsonTransectionTake()
        {
            EndPoint = Settings.Default.RestURL + "transectionTake";
            RoutesJSON = "transectionTake";
        }

        public string AddTransectionTake(JsonTransectionTake json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [transectionTake] :" + ex.Message);
            }
        }
    }
}