using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonBed : RestClient
    {
        public string roomCode { get; set; }
        public string roomName { get; set; }
        public string bedCode { get; set; }
        public int status { get; set; }

        public JsonBed()
        {
            EndPoint = Settings.Default.RestURL + "bed";
            RoutesJSON = "bed";
        }

        public string AddBeds(JsonBed json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [bed] :" + ex.Message);
            }
        }
    }
}