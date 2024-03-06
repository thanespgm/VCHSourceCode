using ConHIS.Properties;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonSignIn : RestClient
    {
        public string email { get; set; }
        public string password { get; set; }

        public JsonSignIn()
        {
           
        }
    }

}