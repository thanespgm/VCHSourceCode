using ConHIS.API.Models;
using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.API.Controllers
{
    public class JsonMiddle : RestClient
    {
        string strEndPoint = "middle";

        public JsonMiddle()
        {
            EndPoint = strEndPoint;
        }

        public string AddMiddle(Middle middle)
        {
            try
            {
                EndPoint = Settings.Default.RestURL + strEndPoint;
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(middle,Formatting.Indented);
                return makeRequest(Settings.Default.AccessToken);
            }
            catch (Exception ex)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(ex.Message);
                throw new Exception(ErrorMessage);
            }
        }

    }
}
