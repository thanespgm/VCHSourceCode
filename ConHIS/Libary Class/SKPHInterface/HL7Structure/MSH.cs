using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.SKPHInterface.HL7Structure
{
    public class MSH
    {
        private string mSH_KEY;
        private string mSH_1;
        private string mSH_2;
        private string mSH_3;
        private string mSH_4;
        private string mSH_5;
        private string mSH_6;
        private string mSH_7;
        private string mSH_8;
        private string mSH_9;
        private string mSH_10;
        private string mSH_11;
        private string mSH_12;
        private string mSH_13;
        private string mSH_14;
        private string mSH_15;
        private string mSH_16;
        private string mSH_17;
        private string mSH_18;
        private string mSH_19;
        private string sET_CODE;
        private DateTime createdAt;


        //Properties
        public string MSH_KEY { get => mSH_KEY; set => mSH_KEY = value; }

        //[Required(ErrorMessage = "MSH.1 - Field Separator : ไม่พบข้อมูล")]
        public string MSH_1 { get => mSH_1; set => mSH_1 = value; }

        //[Required(ErrorMessage = "MSH.2 - Encoding Characters : ไม่พบข้อมูล")]
        public string MSH_2 { get => mSH_2; set => mSH_2 = value; }

        //[Required(ErrorMessage = "MSH.3 - Sending Application : ไม่พบข้อมูล")]
        public string MSH_3 { get => mSH_3; set => mSH_3 = value; }

        //[Required(ErrorMessage = "MSH.4 - Sending Facility : ไม่พบข้อมูล")]
        public string MSH_4 { get => mSH_4; set => mSH_4 = value; }

       // [Required(ErrorMessage = "MSH.5 - Receiving Application : ไม่พบข้อมูล")]
        public string MSH_5 { get => mSH_5; set => mSH_5 = value; }

        //[Required(ErrorMessage = "MSH.6 - Receiving Facility : ไม่พบข้อมูล")]
        public string MSH_6 { get => mSH_6; set => mSH_6 = value; }

        //[Required(ErrorMessage = "MSH.7 - Date/Time Of Message : ไม่พบข้อมูล")]
        public string MSH_7 { get => mSH_7; set => mSH_7 = value; }

        public string MSH_8 { get => mSH_8; set => mSH_8 = value; }

        //[Required(ErrorMessage = "MSH.9 - Message Type : ไม่พบข้อมูล")]
        public string MSH_9 { get => mSH_9; set => mSH_9 = value; }

       // [Required(ErrorMessage = "MSH.10 - Message Control Id : ไม่พบข้อมูล")]
        public string MSH_10 { get => mSH_10; set => mSH_10 = value; }

        //[Required(ErrorMessage = "MSH.11 - Processing Id : ไม่พบข้อมูล")]
        public string MSH_11 { get => mSH_11; set => mSH_11 = value; }

        //[Required(ErrorMessage = "MSH.12 - Version Id : ไม่พบข้อมูล")]
        public string MSH_12 { get => mSH_12; set => mSH_12 = value; }

        public string MSH_13 { get => mSH_13; set => mSH_13 = value; }
        public string MSH_14 { get => mSH_14; set => mSH_14 = value; }
        public string MSH_15 { get => mSH_15; set => mSH_15 = value; }
        public string MSH_16 { get => mSH_16; set => mSH_16 = value; }
        public string MSH_17 { get => mSH_17; set => mSH_17 = value; }
        public string MSH_18 { get => mSH_18; set => mSH_18 = value; }
        public string MSH_19 { get => mSH_19; set => mSH_19 = value; }
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public MSH()
        {
  
        }

        private string InsertMSH()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_MSH( ";
            SQL += "dbo.HL7_MSH.SET_CODE,";
            SQL += "dbo.HL7_MSH.MSH_1,";
            SQL += "dbo.HL7_MSH.MSH_2,";
            SQL += "dbo.HL7_MSH.MSH_3,";
            SQL += "dbo.HL7_MSH.MSH_4,";
            SQL += "dbo.HL7_MSH.MSH_5,";
            SQL += "dbo.HL7_MSH.MSH_6,";
            SQL += "dbo.HL7_MSH.MSH_7,";
            SQL += "dbo.HL7_MSH.MSH_8,";
            SQL += "dbo.HL7_MSH.MSH_9,";
            SQL += "dbo.HL7_MSH.MSH_10,";
            SQL += "dbo.HL7_MSH.MSH_11,";
            SQL += "dbo.HL7_MSH.MSH_12,";
            SQL += "dbo.HL7_MSH.MSH_13,";
            SQL += "dbo.HL7_MSH.MSH_14,";
            SQL += "dbo.HL7_MSH.MSH_15,";
            SQL += "dbo.HL7_MSH.MSH_16,";
            SQL += "dbo.HL7_MSH.MSH_17,";
            SQL += "dbo.HL7_MSH.MSH_18,";
            SQL += "dbo.HL7_MSH.MSH_19,";
            SQL += "dbo.HL7_MSH.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@MSH_1,";
            SQL += "@MSH_2,";
            SQL += "@MSH_3,";
            SQL += "@MSH_4,";
            SQL += "@MSH_5,";
            SQL += "@MSH_6,";
            SQL += "@MSH_7,";
            SQL += "@MSH_8,";
            SQL += "@MSH_9,";
            SQL += "@MSH_10,";
            SQL += "@MSH_11,";
            SQL += "@MSH_12,";
            SQL += "@MSH_13,";
            SQL += "@MSH_14,";
            SQL += "@MSH_15,";
            SQL += "@MSH_16,";
            SQL += "@MSH_17,";
            SQL += "@MSH_18,";
            SQL += "@MSH_19,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectMSH(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_MSH.MSH_KEY,";
            SQL += "dbo.HL7_MSH.SET_CODE,";
            SQL += "dbo.HL7_MSH.MSH_1,";
            SQL += "dbo.HL7_MSH.MSH_2,";
            SQL += "dbo.HL7_MSH.MSH_3,";
            SQL += "dbo.HL7_MSH.MSH_4,";
            SQL += "dbo.HL7_MSH.MSH_5,";
            SQL += "dbo.HL7_MSH.MSH_6,";
            SQL += "dbo.HL7_MSH.MSH_7,";
            SQL += "dbo.HL7_MSH.MSH_8,";
            SQL += "dbo.HL7_MSH.MSH_9,";
            SQL += "dbo.HL7_MSH.MSH_10,";
            SQL += "dbo.HL7_MSH.MSH_11,";
            SQL += "dbo.HL7_MSH.MSH_12,";
            SQL += "dbo.HL7_MSH.MSH_13,";
            SQL += "dbo.HL7_MSH.MSH_14,";
            SQL += "dbo.HL7_MSH.MSH_15,";
            SQL += "dbo.HL7_MSH.MSH_16,";
            SQL += "dbo.HL7_MSH.MSH_17,";
            SQL += "dbo.HL7_MSH.MSH_18,";
            SQL += "dbo.HL7_MSH.MSH_19 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_MSH ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_MSH.SET_CODE =@SET_CODE ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(MSH entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertMSH()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@MSH_1", entity.MSH_1);
                cmd.Parameters.AddWithValue("@MSH_2", entity.MSH_2);
                cmd.Parameters.AddWithValue("@MSH_3", entity.MSH_3);
                cmd.Parameters.AddWithValue("@MSH_4", entity.MSH_4);
                cmd.Parameters.AddWithValue("@MSH_5", entity.MSH_5);
                cmd.Parameters.AddWithValue("@MSH_6", entity.MSH_6);
                cmd.Parameters.AddWithValue("@MSH_7", entity.MSH_7);
                cmd.Parameters.AddWithValue("@MSH_8", entity.MSH_8);
                cmd.Parameters.AddWithValue("@MSH_9", entity.MSH_9);
                cmd.Parameters.AddWithValue("@MSH_10", entity.MSH_10);
                cmd.Parameters.AddWithValue("@MSH_11", entity.MSH_11);
                cmd.Parameters.AddWithValue("@MSH_12", entity.MSH_12);
                cmd.Parameters.AddWithValue("@MSH_13", entity.MSH_13);
                cmd.Parameters.AddWithValue("@MSH_14", entity.MSH_14);
                cmd.Parameters.AddWithValue("@MSH_15", entity.MSH_15);
                cmd.Parameters.AddWithValue("@MSH_16", entity.MSH_16);
                cmd.Parameters.AddWithValue("@MSH_17", entity.MSH_17);
                cmd.Parameters.AddWithValue("@MSH_18", entity.MSH_18);
                cmd.Parameters.AddWithValue("@MSH_19", entity.MSH_19);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}