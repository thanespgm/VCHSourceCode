using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPrescriptionOrders : RestClient
    {
        public string orderControl { get; set; }                //Field 01
        public string prescriptionNo { get; set; }              //Field 02
        public string presType { get; set; }                    //Field 03
        public int orderStatus { get; set; }                    //Field 04
        public DateTime prescriptionDate { get; set; }          //Field 05
        public string userAcceptBy { get; set; }                //Field 06
        public string enterLocation { get; set; }               //Field 07
        public string enterDevice { get; set; }                 //Field 08
        public string userCreatedBy { get; set; }               //Field 09
        public string userActionBy { get; set; }                //Field 10
        public string hn { get; set; }                          //Field 11

        public JsonPrescriptionOrders()
        {
            EndPoint = Settings.Default.RestURL + "prescriptionOrder";
            RoutesJSON = "prescriptionOrder";
        }

        public string AddPrescriptionOrders(JsonPrescriptionOrders json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [prescriptionOrder] :" + ex.Message);
            }
        }
    }
}