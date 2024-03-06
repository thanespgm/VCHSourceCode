using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonRobots : RestClient
    {
        public decimal toMachineNo { get; set; }
        public string machineName { get; set; }
        public string locationName { get; set; }
        public string serialNumber { get; set; }
        public string versionNumber { get; set; }

        public JsonRobots()
        {
            EndPoint = Settings.Default.RestURL + "robots";
            RoutesJSON = "robots";
        }

        public string AddRobots(JsonRobots json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [robots] :" + ex.Message);
            }
        }
    }
}