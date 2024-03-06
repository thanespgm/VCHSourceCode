using Newtonsoft.Json;
using ConHIS.API.Models;
using ConHIS.Properties;
using System;

namespace ConHIS.API
{
    public class JsonLogin : RestClient
    {
        string strEndPoint = "user/login";
        
        public JsonLogin()
        {
           
        }

        public string AuthToken(Login json)
        {
            try
            {
                EndPoint = Settings.Default.RestURL + strEndPoint;
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return makeRequest("");
            }
            catch (Exception ex)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(ex.Message);
                throw new Exception(ErrorMessage);
            }
        }
    }
}
