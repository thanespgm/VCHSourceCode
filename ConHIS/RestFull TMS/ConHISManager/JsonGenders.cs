using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS.ConHISManager
{
    internal class JsonGenders : RestClient
    {
        public string Name { get; set; }

        public JsonGenders()
        {
            EndPoint = Settings.Default.RestURL + "v1/genders";
            RoutesJSON = "gender";
        }

        public string AddGenders(JsonGenders json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [v1/genders] :" + ex.Message);
            }
        }
    }
}