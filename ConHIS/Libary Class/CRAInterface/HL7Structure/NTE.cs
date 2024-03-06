using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.CRAInterface.HL7Structure
{
    public class NTE
    {
        private string nTE_KEY;
        private string nTE_1;
        private string nTE_2;
        private string nTE_3;
        private string nTE_4;
        private string nTE_5;
        private string nTE_6;
        private string nTE_7;
        private string nTE_8;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string NTE_KEY { get => nTE_KEY; set => nTE_KEY = value; }

        //[Required(ErrorMessage = "NTE.1 - Set Id - Nte : Thanes Required -> ลำดับของ Comment")]
        public string NTE_1 { get => nTE_1; set => nTE_1 = value; }

        public string NTE_2 { get => nTE_2; set => nTE_2 = value; }

        // [Required(ErrorMessage = "NTE.3 - Comment : Thanes Required -> f_comment")]
        public string NTE_3 { get => nTE_3; set => nTE_3 = value; }

        
        public string EVEN { get => eVEN; set => eVEN = value; }
        public string NTE_4 { get => nTE_4; set => nTE_4 = value; }
        public string NTE_5 { get => nTE_5; set => nTE_5 = value; }

        // [Required(ErrorMessage = "NTE.6 - Entered Date/Time : Thanes Required -> วันเวลาที่เพิ่ม Comment")]
        public string NTE_6 { get => nTE_6; set => nTE_6 = value; }
        public string NTE_7 { get => nTE_7; set => nTE_7 = value; }
        public string NTE_8 { get => nTE_8; set => nTE_8 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public NTE()
        {
        }

        private string InsertNTE()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_NTE( ";
            SQL += "dbo.HL7_NTE.SET_CODE,";
            SQL += "dbo.HL7_NTE.NTE_1,";
            SQL += "dbo.HL7_NTE.NTE_2,";
            SQL += "dbo.HL7_NTE.NTE_3,";
            SQL += "dbo.HL7_NTE.NTE_4,";
            SQL += "dbo.HL7_NTE.NTE_5,";
            SQL += "dbo.HL7_NTE.NTE_6,";
            SQL += "dbo.HL7_NTE.NTE_7,";
            SQL += "dbo.HL7_NTE.NTE_8,";
            SQL += "dbo.HL7_NTE.EVEN,";
            SQL += "dbo.HL7_NTE.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@NTE_1,";
            SQL += "@NTE_2,";
            SQL += "@NTE_3,";
            SQL += "@NTE_4,";
            SQL += "@NTE_5,";
            SQL += "@NTE_6,";
            SQL += "@NTE_7,";
            SQL += "@NTE_8,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectNTE(string SetCode, string SeqNo)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_NTE.NTE_KEY,";
            SQL += "dbo.HL7_NTE.SET_CODE,";
            SQL += "dbo.HL7_NTE.NTE_1,";
            SQL += "dbo.HL7_NTE.NTE_2,";
            SQL += "dbo.HL7_NTE.NTE_3,";
            SQL += "dbo.HL7_NTE.NTE_4,";
            SQL += "dbo.HL7_NTE.NTE_5,";
            SQL += "dbo.HL7_NTE.NTE_6,";
            SQL += "dbo.HL7_NTE.NTE_7,";
            SQL += "dbo.HL7_NTE.NTE_8 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_NTE ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_NTE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_NTE.NTE_1 =@NTE_1 ";
            SQL += "AND ";
            SQL += "dbo.HL7_NTE.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@NTE_1", SeqNo);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(NTE entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertNTE()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@NTE_1", entity.NTE_1);
                cmd.Parameters.AddWithValue("@NTE_2", entity.NTE_2);
                cmd.Parameters.AddWithValue("@NTE_3", entity.NTE_3);
                cmd.Parameters.AddWithValue("@NTE_4", entity.NTE_4);
                cmd.Parameters.AddWithValue("@NTE_5", entity.NTE_5);
                cmd.Parameters.AddWithValue("@NTE_6", entity.NTE_6);
                cmd.Parameters.AddWithValue("@NTE_7", entity.NTE_7);
                cmd.Parameters.AddWithValue("@NTE_8", entity.NTE_8);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode, string SeqNo)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_NTE SET ";
            SQL += "dbo.HL7_NTE.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_NTE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_NTE.NTE_1 =@NTE_1 ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@NTE_1", SeqNo);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}