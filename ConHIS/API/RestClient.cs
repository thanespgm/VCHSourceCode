using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConHIS.API
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
        TOKEN
    }

    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }

        public string AccessToken { get; set; }
        public string PostJSON { get; set; }

        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        protected string makeRequest(string token)
        {
            AccessToken = token;

            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            request.Method = HttpMethod.ToString();

            switch (request.Method.ToString())
            {
                case "GET":
                    GetRequest(request);
                    break;
                case "POST":
                    PostRequest(request);
                    break;
                case "PUT":
                    PutRequest(request);
                    break;
                case "DELETE":
                    DeleteRequest(request);
                    break;
                case "TOKEN":
                    TokenRequest(request);
                    break;
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
                    case HttpStatusCode.Unauthorized:
                        break;
                }
                //Process the response strem ... (could be JSON,XML or HTML etc...)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        } //End of StreamReader
                    }
                } // End of using ResponseStream
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessage\":\"" + ex.Message.ToString() + "\",\"error\":{}}";
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

        protected void GetRequest(HttpWebRequest request)
        {
            if (PostJSON != string.Empty)
            {
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                request.ContentLength = 0;
                request.Accept = "*/*";
                request.ContentType = "application/json";
            }
        }

        protected void TokenRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json";
            using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
            {
                swJSONPayload.Write(PostJSON);
                swJSONPayload.Close();
            }
        }

        protected void PostRequest(HttpWebRequest request)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteJson = encoding.GetBytes(PostJSON);

            if (PostJSON != string.Empty)
            {
                request.ContentType = "application/json";
                request.ContentLength = byteJson.Length;
                request.Accept = "*/*";
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                try
                {
                    Stream swJSONPayload = request.GetRequestStream();
                    swJSONPayload.Write(byteJson, 0, byteJson.Length);
                    swJSONPayload.Close();
                }
                catch (Exception e) { throw new Exception("Error Write Json <MakeRequset Function> : " + e.Message); }
            }
        }

        protected void PutRequest(HttpWebRequest request)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteJson = encoding.GetBytes(PostJSON);

            if (PostJSON != string.Empty)
            {
                request.ContentType = "application/json";
                request.ContentLength = byteJson.Length;
                request.Accept = "*/*";
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                try
                {
                    Stream swJSONPayload = request.GetRequestStream();
                    swJSONPayload.Write(byteJson, 0, byteJson.Length);
                    swJSONPayload.Close();
                }
                catch (Exception e) { throw new Exception("Error Write Json <MakeRequset Function> : " + e.Message); }
            }
        }

        protected void DeleteRequest(HttpWebRequest request)
        {
            if (PostJSON != string.Empty)
            {
                request.PreAuthenticate = true;
                request.Headers.Add("Authorization", "Bearer " + AccessToken);
                request.ContentLength = 0;
                request.Accept = "*/*";
                request.ContentType = "application/json";
            }
        }

    }
}