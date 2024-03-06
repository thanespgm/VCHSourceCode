using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonInstruction : RestClient
    {
        public string instructionCode { get; set; }
        public string instructionName { get; set; }

        public JsonInstruction()
        {
            EndPoint = Settings.Default.RestURL + "instruction";
            RoutesJSON = "instruction";
        }

        public string AddInstruction(JsonInstruction json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [instruction] :" + ex.Message);
            }
        }
    }
}