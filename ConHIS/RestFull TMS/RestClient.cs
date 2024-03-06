using ConHIS.Properties;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConHIS.RestFull_TMS
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    internal class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string PostJSON { get; set; }
        public string RoutesJSON { get; set; }

        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        public string MakeRequset()
        {
            string AccessToken = Settings.Default.AccessToken.ToString();
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = HttpMethod.ToString();


            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteJson = encoding.GetBytes(PostJSON);

            if (request.Method == "POST" && PostJSON != string.Empty && RoutesJSON == "LOGIN")
            {
                request.ContentType = "application/json";
                using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                {
                    swJSONPayload.Write(PostJSON);
                    swJSONPayload.Close();
                }
            }
            else if (request.Method == "POST" && PostJSON != string.Empty && RoutesJSON != "LOGIN")
            {
                //request.UseDefaultCredentials = true;
                //request.CookieContainer = cookies;
                request.ContentType = "application/json";
                request.ContentLength = byteJson.Length;
                request.Accept = "*/*";
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                try
                {
                    //using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                    //{
                    //    swJSONPayload.Write(PostJSON);
                    //    swJSONPayload.Close();
                    //}
                    Stream swJSONPayload = request.GetRequestStream();
                    swJSONPayload.Write(byteJson, 0, byteJson.Length);
                    swJSONPayload.Close();
                }
                catch (Exception e) { throw new Exception("Error Write Json <MakeRequset Function> : " + e.Message); }
            }
            else if (request.Method == "GET" && PostJSON != string.Empty)
            {
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                request.ContentLength = 0;
                request.Accept = "*/*";
                request.ContentType = "application/json";
                //using StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream());
                //swJSONPayload.Write(PostJSON);
                //swJSONPayload.Close();
            }

            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        break;

                    case HttpStatusCode.Created:
                        break;

                    case HttpStatusCode.BadRequest:
                        throw new ApplicationException("error code : " + response.StatusCode.ToString());
                    case HttpStatusCode.BadGateway:
                        throw new ApplicationException("error code : " + response.StatusCode.ToString());
                }

                // Process the response stream...(could be JSON,XML or HTML etc...)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                            strResponseValue = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessage\":\"[" + ex.Message + "]\",\"error\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }
            return strResponseValue;
        }
    }
}