using ConHIS.Properties;
using Newtonsoft.Json;
using System;

namespace ConHIS.RestFull_TMS.ConHISManager
{
    internal class JsonThaneshopMiddles : RestClient
    {
        public string Prescriptionno { get; set; }
        public decimal Seq { get; set; }
        public decimal Seqmax { get; set; }
        public string Runningno { get; set; }
        public string Prescriptiondate { get; set; }
        public DateTime Ordercreatedate { get; set; }
        public string Ordertargetdate { get; set; }
        public string Ordertargettime { get; set; }
        public string Pharmacylocationcode { get; set; }
        public string Pharmacylocationdesc { get; set; }
        public string Userorderby { get; set; }
        public string Useracceptby { get; set; }
        public DateTime? Orderacceptdate { get; set; }
        public string Orderacceptfromip { get; set; }
        public decimal? Dispensestatus { get; set; }
        public decimal? Status { get; set; }
        public decimal? Printstatus { get; set; }
        public string Hn { get; set; }
        public string An { get; set; }
        public string Vn { get; set; }
        public string Patientname { get; set; }
        public string Sex { get; set; }
        public DateTime? Patientdob { get; set; }
        public string Wardcode { get; set; }
        public string Warddesc { get; set; }
        public string Roomcode { get; set; }
        public string Roomdesc { get; set; }
        public string Bedcode { get; set; }
        public string Drugallergy { get; set; }
        public string Doctorcode { get; set; }
        public string Doctorname { get; set; }
        public decimal? Tomachineno { get; set; }
        public string Orderitemcode { get; set; }
        public string Orderitemname { get; set; }
        public decimal Orderqty { get; set; }
        public string Orderunitcode { get; set; }
        public string Orderunitdesc { get; set; }
        public decimal Dosage { get; set; }
        public string Dosageunit { get; set; }
        public string Binlocation { get; set; }
        public string Itemidentify { get; set; }
        public string Itemlotno { get; set; }
        public DateTime? Itemlotexpire { get; set; }
        public string Instructioncode { get; set; }
        public string Instructiondesc { get; set; }
        public string Drugformcode { get; set; }
        public string Drugformdesc { get; set; }
        public decimal? Highalertdrug { get; set; }
        public decimal? Prnstat { get; set; }
        public string Prioritycode { get; set; }
        public string Prioritydesc { get; set; }
        public string Frequencycode { get; set; }
        public string Frequencydesc { get; set; }
        public string Frequencytime { get; set; }
        public string Dosagedispense { get; set; }
        public decimal? Language { get; set; }
        public decimal? Durationcode { get; set; }
        public string Noteprocessing { get; set; }
        public string Barcodebyhis { get; set; }
        public string Excludeipfill { get; set; }
        public DateTime? Lastmodified { get; set; }
        public string Comment { get; set; }
        public decimal? Drugbagsplit { get; set; }
        public decimal? OpdAdminstatus { get; set; }
        public DateTime? OpdAdmindatetime { get; set; }
        public string OpdAdminby { get; set; }
        public string OpdAdminremark { get; set; }
        public string OpdAdminlocation { get; set; }
        public decimal? OpdAdmincontinue { get; set; }
        public string RowId { get; set; }                           

        public JsonThaneshopMiddles()
        {
            EndPoint = Settings.Default.RestURL + "v1/ThanesMIddles";
            RoutesJSON = "thaneshospmiddle";
        }

        public string AddThaneshopMiddles(JsonThaneshopMiddles json)
        {
            try
            {
                HttpMethod = HttpVerb.POST;
                PostJSON = JsonConvert.SerializeObject(json, Formatting.Indented);
                return MakeRequset();
            }
            catch (Exception ex)
            {
                throw new Exception("API [v1/ThanesMIddles] :" + ex.Message);
            }
        }
    }
}