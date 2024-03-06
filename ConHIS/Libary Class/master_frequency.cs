using System;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class master_frequency
    {
        //Fields And Properties
        private string frequencyCode;

        private string frequencyDesc;
        private string frequencyDesc1;
        private string frequencyDesc2;
        private string frequencyDesc3;
        private string frequencyDesc4;
        private decimal dose;
        private string doseAgeDispense;
        private decimal frequencyCounter;
        private string frequencyTakeTime;
        private decimal status;
        private DateTime lastModified;
        private int printForCounter;
        private int statusCheMo;

        //Properties

        #region "Properties/ViewModel/Data Validation"

        public string FrequencyCode { get => frequencyCode; set => frequencyCode = value; }
        public string FrequencyDesc { get => frequencyDesc; set => frequencyDesc = value; }
        public string FrequencyDesc1 { get => frequencyDesc1; set => frequencyDesc1 = value; }
        public string FrequencyDesc2 { get => frequencyDesc2; set => frequencyDesc2 = value; }
        public string FrequencyDesc3 { get => frequencyDesc3; set => frequencyDesc3 = value; }
        public string FrequencyDesc4 { get => frequencyDesc4; set => frequencyDesc4 = value; }
        public decimal Dose { get => dose; set => dose = value; }
        public string DoseAgeDispense { get => doseAgeDispense; set => doseAgeDispense = value; }
        public decimal FrequencyCounter { get => frequencyCounter; set => frequencyCounter = value; }
        public string FrequencyTakeTime { get => frequencyTakeTime; set => frequencyTakeTime = value; }
        public decimal Status { get => status; set => status = value; }
        public DateTime LastModified { get => lastModified; set => lastModified = value; }
        public int PrintForCounter { get => printForCounter; set => printForCounter = value; }
        public int StatusCheMo { get => statusCheMo; set => statusCheMo = value; }

        #endregion "Properties/ViewModel/Data Validation"

        private System_logfile logs;

        //Constructor
        public master_frequency()
        {
            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridViewFullDetail(string frequencyCode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Frequency.f_frequencycode,";
            SQL += "dbo.M_Frequency.f_frequencydesc,";
            SQL += "dbo.M_Frequency.f_frequencydesc1,";
            SQL += "dbo.M_Frequency.f_frequencydesc2,";
            SQL += "dbo.M_Frequency.f_frequencydesc3,";
            SQL += "dbo.M_Frequency.f_frequencydesc4,";
            SQL += "dbo.M_Frequency.f_dose,";
            SQL += "dbo.M_Frequency.f_doseagedispense,";
            SQL += "dbo.M_Frequency.f_frequencycounter,";
            SQL += "dbo.M_Frequency.f_frequencytaketime,";
            SQL += "dbo.M_Frequency.f_status,";
            SQL += "dbo.M_Frequency.f_lastmodified,";
            SQL += "dbo.M_Frequency.f_printforcounter,";
            SQL += "dbo.M_Frequency.f_status_chemo ";
            SQL += "FROM ";
            SQL += "dbo.M_Frequency ";
            SQL += "WHERE ";
            SQL += "dbo.M_Frequency.f_frequencycode =@f_frequencycode ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", frequencyCode));
                return conn.FillSQL(cmd);
            }
        }
    }
}