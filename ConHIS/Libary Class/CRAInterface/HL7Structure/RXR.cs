using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.CRAInterface.HL7Structure
{
    public class RXR
    {
        private string rXR_KEY;
        private string rXR_1;
        private string rXR_2;
        private string rXR_3;
        private string rXR_4;
        private string rXR_5;
        private string rXR_6;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string RXR_KEY { get => rXR_KEY; set => rXR_KEY = value; }

        [Required(ErrorMessage = "RXR.1 - Route : Thanes Required -> f_orderitemcode")]
        public string RXR_1 { get => rXR_1; set => rXR_1 = value; }

        [Required(ErrorMessage = "RXR.2 - Administration Site : Thanes Required -> f_pharmacylocationcode, f_pharmacylocationdesc")]
        public string RXR_2 { get => rXR_2; set => rXR_2 = value; }

        [Required(ErrorMessage = "RXR.3 - Administration Device : Thanes Required -> f_tomachineno")]
        public string RXR_3 { get => rXR_3; set => rXR_3 = value; }
        public string RXR_4 { get => rXR_4; set => rXR_4 = value; }
        public string RXR_5 { get => rXR_5; set => rXR_5 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public string RXR_6 { get => rXR_6; set => rXR_6 = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public RXR()
        {
        }

        private string InsertRXR()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_RXR( ";
            SQL += "dbo.HL7_RXR.SET_CODE,";
            SQL += "dbo.HL7_RXR.RXR_1,";
            SQL += "dbo.HL7_RXR.RXR_2,";
            SQL += "dbo.HL7_RXR.RXR_3,";
            SQL += "dbo.HL7_RXR.RXR_4,";
            SQL += "dbo.HL7_RXR.RXR_5,";
            SQL += "dbo.HL7_RXR.RXR_6,";
            SQL += "dbo.HL7_RXR.EVEN,";
            SQL += "dbo.HL7_RXR.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@RXR_1,";
            SQL += "@RXR_2,";
            SQL += "@RXR_3,";
            SQL += "@RXR_4,";
            SQL += "@RXR_5,";
            SQL += "@RXR_6,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";

            return SQL;
        }

        public DataSet SelectRXR(string SetCode, string DrugCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_RXR.RXR_KEY,";
            SQL += "dbo.HL7_RXR.SET_CODE,";
            SQL += "dbo.HL7_RXR.RXR_1,";
            SQL += "dbo.HL7_RXR.RXR_2,";
            SQL += "dbo.HL7_RXR.RXR_3,";
            SQL += "dbo.HL7_RXR.RXR_4,";
            SQL += "dbo.HL7_RXR.RXR_5,";
            SQL += "dbo.HL7_RXR.RXR_6 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_RXR ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXR.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXR.RXR_1 Like '%" + DrugCode + "%'";
            SQL += "AND ";
            SQL += "dbo.HL7_RXR.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@RXR_1", DrugCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(RXR entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertRXR()))
            {
                //cmd.Parameters.AddWithValue("@RXR_KEY", entity.RXR_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@RXR_1", entity.RXR_1);
                cmd.Parameters.AddWithValue("@RXR_2", entity.RXR_2);
                cmd.Parameters.AddWithValue("@RXR_3", entity.RXR_3);
                cmd.Parameters.AddWithValue("@RXR_4", entity.RXR_4);
                cmd.Parameters.AddWithValue("@RXR_5", entity.RXR_5);
                cmd.Parameters.AddWithValue("@RXR_6", entity.RXR_6);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode, string DrugCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_RXR SET ";
            SQL += "dbo.HL7_RXR.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXR.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXR.RXR_1 =@RXR_1 ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@RXR_1", DrugCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}