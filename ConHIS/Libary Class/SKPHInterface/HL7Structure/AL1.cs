using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.SKPHInterface.HL7Structure
{
    public class AL1 
    {
        private string aL1_1;
        private string aL1_2;
        private string aL1_3;
        private string aL1_4;
        private string aL1_5;
        private string aL1_6;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        [Required(ErrorMessage = "AL1.1 - Set Id - Al1 : Thanes Required -> f_hn")]
        public string AL1_1 { get => aL1_1; set => aL1_1 = value; }

        [Required(ErrorMessage = "AL1.2 - Allergen Type Code : Thanes Required -> ค่าคงที่ใส่ DA เพราะไม่มีมาสเตอร์การแพ้ DA = แพ้ยา")]
        public string AL1_2 { get => aL1_2; set => aL1_2 = value; }

        //[Required(ErrorMessage = "AL1.3 - Allergen Code/Mnemonic/Description : Thanes Required -> f_drugallergy")]
        public string AL1_3 { get => aL1_3; set => aL1_3 = value; }

        public string AL1_4 { get => aL1_4; set => aL1_4 = value; }

        //[Required(ErrorMessage = "AL1.5 - Allergy Reaction Code : Thanes Required -> ผลจากการเกิดอาการแพ้")]
        public string AL1_5 { get => aL1_5; set => aL1_5 = value; }

        [Required(ErrorMessage = "AL1.6 - Identification Date : Thanes Required -> วันที่ระบุอาการแพ้")]
        public string AL1_6 { get => aL1_6; set => aL1_6 = value; }

        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public AL1()
        {
        }

        private string InsertAL1()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_AL1( ";
            SQL += "dbo.HL7_AL1.SET_CODE,";
            SQL += "dbo.HL7_AL1.AL1_1,";
            SQL += "dbo.HL7_AL1.AL1_2,";
            SQL += "dbo.HL7_AL1.AL1_3,";
            SQL += "dbo.HL7_AL1.AL1_4,";
            SQL += "dbo.HL7_AL1.AL1_5,";
            SQL += "dbo.HL7_AL1.AL1_6,";
            SQL += "dbo.HL7_AL1.EVEN,";
            SQL += "dbo.HL7_AL1.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@AL1_1,";
            SQL += "@AL1_2,";
            SQL += "@AL1_3,";
            SQL += "@AL1_4,";
            SQL += "@AL1_5,";
            SQL += "@AL1_6,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectAL1(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_AL1.AL1_KEY,";
            SQL += "dbo.HL7_AL1.SET_CODE,";
            SQL += "dbo.HL7_AL1.AL1_1,";
            SQL += "dbo.HL7_AL1.AL1_2,";
            SQL += "dbo.HL7_AL1.AL1_3,";
            SQL += "dbo.HL7_AL1.AL1_4,";
            SQL += "dbo.HL7_AL1.AL1_5,";
            SQL += "dbo.HL7_AL1.AL1_6 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_AL1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_AL1.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_AL1.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(AL1 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertAL1()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@AL1_1", entity.AL1_1);
                cmd.Parameters.AddWithValue("@AL1_2", entity.AL1_2);
                cmd.Parameters.AddWithValue("@AL1_3", entity.AL1_3);
                cmd.Parameters.AddWithValue("@AL1_4", entity.AL1_4);
                cmd.Parameters.AddWithValue("@AL1_5", entity.AL1_5);
                cmd.Parameters.AddWithValue("@AL1_6", entity.AL1_6);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_AL1 SET ";
            SQL += "dbo.HL7_AL1.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_AL1.SET_CODE =@SET_CODE ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}