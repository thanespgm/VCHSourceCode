using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.SKPHInterface.HL7Structure
{
    public class EVN
    {
        private string eVN_KEY;
        private string eVN_1;
        private string eVN_2;
        private string eVN_3;
        private string eVN_4;
        private string eVN_5;
        private string eVN_6;
        private string eVN_7;
        private int sTATUS;
        private string sET_CODE;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string EVN_KEY { get => eVN_KEY; set => eVN_KEY = value; }

        [Required(ErrorMessage = "EVN.1 - Event Type Code : Thanes Required -> สถานะ A01 = Admit, A02 = Tranfer, A03 = Discharge")]
        public string EVN_1 { get => eVN_1; set => eVN_1 = value; }

        [Required(ErrorMessage = "EVN.2 - Recorded Date/Time : Thanes Required -> lastmodified")]
        public string EVN_2 { get => eVN_2; set => eVN_2 = value; }
        public string EVN_3 { get => eVN_3; set => eVN_3 = value; }

        [Required(ErrorMessage = "EVN.4 - Event Reason Code : Thanes Required -> ค่าคงที่ O = Others")]
        public string EVN_4 { get => eVN_4; set => eVN_4 = value; }
        public string EVN_5 { get => eVN_5; set => eVN_5 = value; }
        public string EVN_6 { get => eVN_6; set => eVN_6 = value; }
        public string EVN_7 { get => eVN_7; set => eVN_7 = value; }

        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public EVN()
        {
        }

        private string InsertEVN()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_EVN( ";
            SQL += "dbo.HL7_EVN.SET_CODE,";
            SQL += "dbo.HL7_EVN.EVN_1,";
            SQL += "dbo.HL7_EVN.EVN_2,";
            SQL += "dbo.HL7_EVN.EVN_3,";
            SQL += "dbo.HL7_EVN.EVN_4,";
            SQL += "dbo.HL7_EVN.EVN_5,";
            SQL += "dbo.HL7_EVN.EVN_6,";
            SQL += "dbo.HL7_EVN.EVN_7) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@EVN_1,";
            SQL += "@EVN_2,";
            SQL += "@EVN_3,";
            SQL += "@EVN_4,";
            SQL += "@EVN_5,";
            SQL += "@EVN_6,";
            SQL += "@EVN_7)";
            return SQL;
        }

        public DataSet SelectEVN(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_EVN.EVN_KEY,";
            SQL += "dbo.HL7_EVN.SET_CODE,";
            SQL += "dbo.HL7_EVN.EVN_1,";
            SQL += "dbo.HL7_EVN.EVN_2,";
            SQL += "dbo.HL7_EVN.EVN_3,";
            SQL += "dbo.HL7_EVN.EVN_4,";
            SQL += "dbo.HL7_EVN.EVN_5, ";
            SQL += "dbo.HL7_EVN.EVN_6,";
            SQL += "dbo.HL7_EVN.EVN_7 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_EVN ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_EVN.SET_CODE =@SET_CODE ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(EVN entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertEVN()))
            {
                //cmd.Parameters.AddWithValue("@EVN_KEY", entity.EVN_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@EVN_1", entity.EVN_1);
                cmd.Parameters.AddWithValue("@EVN_2", entity.EVN_2);
                cmd.Parameters.AddWithValue("@EVN_3", entity.EVN_3);
                cmd.Parameters.AddWithValue("@EVN_4", entity.EVN_4);
                cmd.Parameters.AddWithValue("@EVN_5", entity.EVN_5);
                cmd.Parameters.AddWithValue("@EVN_6", entity.EVN_6);
                cmd.Parameters.AddWithValue("@EVN_7", entity.EVN_7);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}
