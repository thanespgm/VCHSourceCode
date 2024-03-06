using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConHIS
{
    internal class Thaneshopmiddle_extentions_Cra
    {
        //filed and properties

        private string runningNo;                    //Field 01
        private string prn_indication;               //Field 02
        private string drug_label_name;              //Field 03
        private string preg_cat;                     //Field 04
        private string freetext1;                    //Field 05
        private string enddate;                      //Field 06
        private string endtime;                      //Field 07
        private string startdate;                    //Field 08
        private string starttime;                    //Field 09

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [Required(ErrorMessage = "RunningNo : ไม่พบข้อมูล")]
        [StringLength(600, ErrorMessage = "RunningNo : ขนาดข้อมูลเกิน 600 ตัวอักษร ")]
        public string RunningNo { get => runningNo; set => runningNo = value; }

        [StringLength(200, ErrorMessage = "PRN_Indication : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string PRN_Indication { get => prn_indication; set => prn_indication = value; }

        [StringLength(200, ErrorMessage = "DrugLabelName : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string DrugLabelName { get => drug_label_name; set => drug_label_name = value; }

        [StringLength(10, ErrorMessage = "PregCat : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string PregCat { get => preg_cat; set => preg_cat = value; }

        [StringLength(300, ErrorMessage = "FreeText1 : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string FreeText1 { get => freetext1; set => freetext1 = value; }

        [StringLength(10, ErrorMessage = "EndDate : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string EndDate { get => enddate; set => enddate = value; }

        [StringLength(10, ErrorMessage = "EndTime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string EndTime { get => endtime; set => endtime = value; }
        /// <summary>
        ///##############
        /// </summary>
        [StringLength(10, ErrorMessage = "Startdate : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string Startdate { get => startdate; set => startdate = value; }

        [StringLength(10, ErrorMessage = "Starttime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string Starttime { get => starttime; set => starttime = value; }

        #endregion "Properties/ViewModel/Data Validation"

        private System_logfile logs;

        //Constructor And Abstract Class
        public Thaneshopmiddle_extentions_Cra()
        {
            logs = new System_logfile();
        }

        //Query Command thanes-hop middle table for Display DataGrid View Full Detail Form
        public DataSet GetAllExtentionsDetail(string p_runningno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle_extention.f_runningno, ";           //Field 01
            SQL += "dbo.tb_thaneshosp_middle_extention.prn_indication, ";        //Field 02
            SQL += "dbo.tb_thaneshosp_middle_extention.drug_label_name, ";       //Field 03
            SQL += "dbo.tb_thaneshosp_middle_extention.preg_cat, ";              //Field 04
            SQL += "dbo.tb_thaneshosp_middle_extention.enddate, ";               //Field 05
            SQL += "dbo.tb_thaneshosp_middle_extention.endtime, ";               //Field 06
            SQL += "dbo.tb_thaneshosp_middle_extention.startdate, ";             //Field 07
            SQL += "dbo.tb_thaneshosp_middle_extention.starttime ";              //Field 08
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle_extention ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle_extention.f_runningno =@f_runningno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_runningno", p_runningno);
                return  conn.FillSQL(cmd);
            }
        }

        public bool InsertDataExtentionsDetail()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle_extention (";
            SQL += "dbo.tb_thaneshosp_middle_extention.f_runningno, ";         //Field 01
            SQL += "dbo.tb_thaneshosp_middle_extention.prn_indication, ";      //Field 02
            SQL += "dbo.tb_thaneshosp_middle_extention.drug_label_name, ";     //Field 03
            SQL += "dbo.tb_thaneshosp_middle_extention.preg_cat, ";            //Field 04
            SQL += "dbo.tb_thaneshosp_middle_extention.enddate, ";             //Field 05
            SQL += "dbo.tb_thaneshosp_middle_extention.endtime, ";            //Field 06
            SQL += "dbo.tb_thaneshosp_middle_extention.startdate, ";           //Field 07
            SQL += "dbo.tb_thaneshosp_middle_extention.starttime) ";           //Field 08
            SQL += "VALUES( ";
            SQL += "@f_runningno,";                                             //Field 01
            SQL += "@prn_indication,";                                          //Field 02
            SQL += "@drug_label_name,";                                         //Field 03
            SQL += "@preg_cat, ";                                               //Field 04
            SQL += "@enddate, ";                                                //Field 05
            SQL += "@endtime, ";                                               //Field 06
            SQL += "@startdate, ";                                              //Field 07
            SQL += "@starttime) ";                                              //Field 08
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_runningno", RunningNo));
                cmd.Parameters.Add(new SqlParameter("@prn_indication", PRN_Indication));
                cmd.Parameters.Add(new SqlParameter("@drug_label_name", DrugLabelName));
                cmd.Parameters.Add(new SqlParameter("@preg_cat", PregCat));
                cmd.Parameters.Add(new SqlParameter("@enddate", EndDate));
                cmd.Parameters.Add(new SqlParameter("@endtime", EndTime));
                cmd.Parameters.Add(new SqlParameter("@startdate", Startdate));
                cmd.Parameters.Add(new SqlParameter("@starttime", Starttime));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}