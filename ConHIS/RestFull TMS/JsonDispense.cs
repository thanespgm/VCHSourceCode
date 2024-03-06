using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonDispense : RestClient
    {
        public decimal seq { get; set; }
        public string drugCode { get; set; }
        public string prescriptionNo { get; set; }
        public string userAcceptBy { get; set; }
        public decimal qty { get; set; }
        public decimal dosage { get; set; }
        public string instructionCode { get; set; }
        public string dosageForm { get; set; }
        public string unitCode { get; set; }
        public string frequencyCode { get; set; }
        public string timeCode { get; set; }
        public string strengthUnit { get; set; }
        public string wardCode { get; set; }
        public string doctorCode { get; set; }
        public string subStand { get; set; }
        public string priorityCode { get; set; }
        public string continueStartDate { get; set; }
        public string continueEndDate { get; set; }
        public DateTime orderTargetDate { get; set; }
        public decimal orderFrequency { get; set; }
        public int dispenseStatus { get; set; }
        public string lotNumber { get; set; }
        public DateTime expireDate { get; set; }
        public int status { get; set; }

        public JsonDispense()
        {
            EndPoint = Settings.Default.RestURL + "dispense";
            RoutesJSON = "dispense";
        }

        public string AddDispense(JsonDispense json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [dispense] :" + ex.Message);
            }
        }
    }
}