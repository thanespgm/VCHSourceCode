using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS
{
    internal class JsonPatientVisits : RestClient
    {
        public string assigned_Location { get; set; }
        public string wardCode { get; set; }
        public string roomCode { get; set; }
        public string bedCode { get; set; }
        public string an { get; set; }
        public string vn { get; set; }
        public string doctorCode { get; set; }
        public string doctorName { get; set; }
        public string patTypeCode { get; set; }
        public DateTime admitDate { get; set; }
        public DateTime dischargeDate { get; set; }
        public string hn { get; set; }

        public JsonPatientVisits()
        {
            EndPoint = Settings.Default.RestURL + "patientVisits";
            RoutesJSON = "patientVisits";
        }

        public string AddPatientVisits(JsonPatientVisits json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [patientVisits] :" + ex.Message);
            }
        }
    }
}