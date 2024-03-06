using Newtonsoft.Json;
using System;

namespace ConHIS.API.Models
{
    public partial class Middle
    {
        public string f_prescriptionno { get; set; }
        public decimal f_seq { get; set; }
        public decimal f_seqmax { get; set; }
        public string f_runningno { get; set; }
        public string f_prescriptiondate { get; set; }
        public DateTime f_ordercreatedate { get; set; }
        public string f_ordertargetdate { get; set; }
        public string f_ordertargettime { get; set; }
        public string f_pharmacylocationcode { get; set; }
        public string f_pharmacylocationdesc { get; set; }
        public string f_userorderby { get; set; }
        public string f_useracceptby { get; set; }
        public DateTime? f_orderacceptdate { get; set; }
        public string f_orderacceptfromip { get; set; }
        public decimal? f_dispensestatus { get; set; }
        public decimal? f_status { get; set; }
        public decimal? f_printstatus { get; set; }
        public string f_hn { get; set; }
        public string f_an { get; set; }
        public string f_vn { get; set; }
        public string f_patientname { get; set; }
        public string f_sex { get; set; }
        public DateTime? f_patientdob { get; set; }
        public string f_wardcode { get; set; }
        public string f_warddesc { get; set; }
        public string f_roomcode { get; set; }
        public string f_roomdesc { get; set; }
        public string f_bedcode { get; set; }
        public string f_drugallergy { get; set; }
        public string f_doctorcode { get; set; }
        public string f_doctorname { get; set; }
        public decimal? f_tomachineno { get; set; }
        public string f_orderitemcode { get; set; }
        public string f_orderitemname { get; set; }
        public decimal f_orderqty { get; set; }
        public string f_orderunitcode { get; set; }
        public string f_orderunitdesc { get; set; }
        public decimal f_dosage { get; set; }
        public string f_dosageunit { get; set; }
        public string f_binlocation { get; set; }
        public string f_itemidentify { get; set; }
        public string f_itemlotno { get; set; }
        public DateTime? f_itemlotexpire { get; set; }
        public string f_instructioncode { get; set; }
        public string f_instructiondesc { get; set; }
        public string f_drugformcode { get; set; }
        public string f_drugformdesc { get; set; }
        public decimal? f_highalertdrug { get; set; }
        public decimal? f_prnstat { get; set; }
        public string f_prioritycode { get; set; }
        public string f_prioritydesc { get; set; }
        public string f_frequencycode { get; set; }
        public string f_frequencydesc { get; set; }
        public string f_frequencytime { get; set; }
        public string f_dosagedispense { get; set; }
        public decimal? f_language { get; set; }
        public decimal? f_durationcode { get; set; }
        public string f_noteprocessing { get; set; }
        public string f_barcodebyhis { get; set; }
        public string f_excludeipfill { get; set; }
        public DateTime? f_lastmodified { get; set; }
        public string f_comment { get; set; }
        public decimal? f_drugbagsplit { get; set; }
        public decimal? f_opd_adminstatus { get; set; }
        public DateTime? f_opd_admindatetime { get; set; }
        public string f_opd_adminby { get; set; }
        public string f_opd_adminremark { get; set; }
        public string f_opd_adminlocation { get; set; }
        public decimal? f_opd_admincontinue { get; set; }
        public string RowId { get; set; }
    }
}

