using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS.ConHISManager
{
    internal class JsonLanguages : RestClient
    {
        public string Name { get; set; }

        public JsonLanguages()
        {
            EndPoint = Settings.Default.RestURL + "v1/languages";
            RoutesJSON = "language";
        }

        public string AddLanguages(JsonLanguages json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [v1/languages] :" + ex.Message);
            }
        }
    }
}