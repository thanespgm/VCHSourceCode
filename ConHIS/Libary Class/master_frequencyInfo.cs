using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class master_frequencyInfo
    {
        //Fields And Properties
        private string frequencyCode;                //Field 01
        private string frequencyDesc;                //Field 02
        private string frequencyTime;                //Field 03
        private DateTime createdAt;                  //Field 04
        private DateTime updatedAt;                  //Field 05
        private int accept;                          //Field 06

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [StringLength(120, ErrorMessage = "FrequencyCode : ขนาดข้อมูลเกิน 120 ตัวอักษร ")]
        public string FrequencyCode { get => frequencyCode; set => frequencyCode = value; }

        [StringLength(240, ErrorMessage = "FrequencyDesc : ขนาดข้อมูลเกิน 240 ตัวอักษร ")]
        public string FrequencyDesc { get => frequencyDesc; set => frequencyDesc = value; }

        [StringLength(100, ErrorMessage = "FrequencyTime : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string FrequencyTime { get => frequencyTime; set => frequencyTime = value; }
        
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }
        public int Accept { get => accept; set => accept = value; }
        #endregion

        private System_logfile logs;

        public master_frequencyInfo()
        {
            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridView(string c, string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_FrequencyInfo.id, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencycode, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencytime, ";
            SQL += "dbo.M_FrequencyInfo.accept, ";
            SQL += "dbo.M_FrequencyInfo.createdAt, ";
            SQL += "dbo.M_FrequencyInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_FrequencyInfo ";

            switch (c)
            {
                case "All":
                    SQL += "WHERE ";
                    SQL += "dbo.M_FrequencyInfo.accept = 1 ";
                    break;
                case "New":
                    SQL += "WHERE ";
                    SQL += "dbo.M_FrequencyInfo.accept = 0 ";
                    break;
                case "FromBy":
                    SQL += "WHERE ";
                    SQL += "(dbo.M_FrequencyInfo.f_frequencycode LIKE '%" + condition + "%' OR ";
                    SQL += "dbo.M_FrequencyInfo.f_frequencydesc LIKE '%" + condition + "%') ";
                    SQL += "AND ";
                    SQL += "dbo.M_FrequencyInfo.accept = 1 ";
                    break;
            }
            SQL += "ORDER BY ";
            SQL += "dbo.M_FrequencyInfo.f_frequencycode ASC ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayDataDetail(string f_frequencydesc)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_FrequencyInfo.id, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencycode, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencytime, ";
            SQL += "dbo.M_FrequencyInfo.accept, ";
            SQL += "dbo.M_FrequencyInfo.createdAt, ";
            SQL += "dbo.M_FrequencyInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_FrequencyInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc =@f_frequencydesc ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", f_frequencydesc));
                return conn.FillSQL(cmd);
            }
        }

        public bool UpdateAcceptData()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_FrequencyInfo SET ";
            SQL += "dbo.M_FrequencyInfo.accept =@accept ";
            SQL += "WHERE ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc =@f_frequencydesc";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@accept", Accept));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", FrequencyDesc));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool InsertDataFrequency()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_FrequencyInfo (";
            SQL += "dbo.M_FrequencyInfo.f_frequencycode, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencytime, ";
            SQL += "dbo.M_FrequencyInfo.accept, ";
            SQL += "dbo.M_FrequencyInfo.createdAt, ";
            SQL += "dbo.M_FrequencyInfo.updatedAt) ";
            SQL += "VALUES (";
            SQL += "@f_frequencycode, ";
            SQL += "@f_frequencydesc, ";
            SQL += "@f_frequencytime, ";
            SQL += "0, ";
            SQL += "GETDATE(), ";
            SQL += "GETDATE())";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", FrequencyCode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", FrequencyDesc));
                cmd.Parameters.Add(new SqlParameter("@f_frequencytime", FrequencyTime));
                
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDataFrequency(int id)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_FrequencyInfo SET ";
            SQL += "dbo.M_FrequencyInfo.f_frequencycode =@f_frequencycode, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc =@f_frequencydesc, ";
            SQL += "dbo.M_FrequencyInfo.f_frequencytime =@f_frequencytime, ";
            SQL += "dbo.M_FrequencyInfo.accept = 1, ";
            SQL += "dbo.M_FrequencyInfo.updatedAt =GETDATE() ";
            SQL += "WHERE ";
            SQL += "dbo.M_FrequencyInfo.id =@id ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", FrequencyCode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", FrequencyDesc));
                cmd.Parameters.Add(new SqlParameter("@f_frequencytime", FrequencyTime));

                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public int GetFrequencyCheck(string f_frequencydesc)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.M_FrequencyInfo.f_frequencydesc)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_FrequencyInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_FrequencyInfo.f_frequencydesc = @f_frequencydesc ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", f_frequencydesc));
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}
