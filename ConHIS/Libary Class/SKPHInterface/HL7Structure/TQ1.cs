using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.SKPHInterface.HL7Structure
{
    internal class TQ1
    {
        private string tQ1_KEY;
        private string tQ1_1;
        private string tQ1_2;
        private string tQ1_3;
        private string tQ1_4;
        private string tQ1_5;
        private string tQ1_6;
        private string tQ1_7;
        private string tQ1_8;
        private string tQ1_9;
        private string tQ1_10;
        private string tQ1_11;
        private string tQ1_12;
        private string tQ1_13;
        private string tQ1_14;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public string TQ1_KEY { get => tQ1_KEY; set => tQ1_KEY = value; }

        [Required(ErrorMessage = "TQ1.1 - Set Id - Tq1 : Thanes Required -> RXD.1 - Dispense Sub-id Counter (f_seqno)")]
        public string TQ1_1 { get => tQ1_1; set => tQ1_1 = value; }

        [Required(ErrorMessage = "TQ1.2 - Quantity : Thanes Required -> f_orderqty,f_orderunitdesc")]
        public string TQ1_2 { get => tQ1_2; set => tQ1_2 = value; }

        //[Required(ErrorMessage = "TQ1.3 - Repeat Pattern : Thanes Required -> f_frequencycode,  f_frequencydesc")]
        public string TQ1_3 { get => tQ1_3; set => tQ1_3 = value; }

       // [Required(ErrorMessage = "TQ1.4 - Explicit Time : Thanes Required -> f_frequencyTime")]
        public string TQ1_4 { get => tQ1_4; set => tQ1_4 = value; }
        public string TQ1_5 { get => tQ1_5; set => tQ1_5 = value; }
        public string TQ1_6 { get => tQ1_6; set => tQ1_6 = value; }

        [Required(ErrorMessage = "TQ1.7 - Start Date/Time : Thanes Required -> f_ordertargetdate, f_ordertargettime")]
        public string TQ1_7 { get => tQ1_7; set => tQ1_7 = value; }

        //[Required(ErrorMessage = "TQ1.8 - End Date/Time : Thanes Required -> วันเวลาที่สิ้นสุดการใช้งานยาหรือเวชภัณฑ์")]
        public string TQ1_8 { get => tQ1_8; set => tQ1_8 = value; }

        [Required(ErrorMessage = "TQ1.9 - Priority : Thanes Required -> f_priortycode, f_priortydesc")]
        public string TQ1_9 { get => tQ1_9; set => tQ1_9 = value; }

        //[Required(ErrorMessage = "TQ1.10 - Condition Text : Thanes Required -> f_noteprocessing")]
        public string TQ1_10 { get => tQ1_10; set => tQ1_10 = value; }

        //[Required(ErrorMessage = "TQ1.11 - Text Instruction : Thanes Required -> f_comment")]
        public string TQ1_11 { get => tQ1_11; set => tQ1_11 = value; }
        public string TQ1_12 { get => tQ1_12; set => tQ1_12 = value; }

        [Required(ErrorMessage = "TQ1.13 - Occurrence Duration : Thanes Required -> f_durationcode")]
        public string TQ1_13 { get => tQ1_13; set => tQ1_13 = value; }
        public string TQ1_14 { get => tQ1_14; set => tQ1_14 = value; }

        public TQ1()
        {
        }

        private string InsertTQ1()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_TQ1( ";
            SQL += "dbo.HL7_TQ1.SET_CODE,";
            SQL += "dbo.HL7_TQ1.TQ1_1,";
            SQL += "dbo.HL7_TQ1.TQ1_2,";
            SQL += "dbo.HL7_TQ1.TQ1_3,";
            SQL += "dbo.HL7_TQ1.TQ1_4,";
            SQL += "dbo.HL7_TQ1.TQ1_5,";
            SQL += "dbo.HL7_TQ1.TQ1_6,";
            SQL += "dbo.HL7_TQ1.TQ1_7,";
            SQL += "dbo.HL7_TQ1.TQ1_8,";
            SQL += "dbo.HL7_TQ1.TQ1_9,";
            SQL += "dbo.HL7_TQ1.TQ1_10,";
            SQL += "dbo.HL7_TQ1.TQ1_11,";
            SQL += "dbo.HL7_TQ1.TQ1_12,";
            SQL += "dbo.HL7_TQ1.TQ1_13,";
            SQL += "dbo.HL7_TQ1.TQ1_14,";
            SQL += "dbo.HL7_TQ1.EVEN,";
            SQL += "dbo.HL7_TQ1.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@TQ1_1,";
            SQL += "@TQ1_2,";
            SQL += "@TQ1_3,";
            SQL += "@TQ1_4,";
            SQL += "@TQ1_5,";
            SQL += "@TQ1_6,";
            SQL += "@TQ1_7,";
            SQL += "@TQ1_8,";
            SQL += "@TQ1_9,";
            SQL += "@TQ1_10,";
            SQL += "@TQ1_11,";
            SQL += "@TQ1_12,";
            SQL += "@TQ1_13,";
            SQL += "@TQ1_14,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";

            return SQL;
        }

        public DataSet SelectTQ1(string SetCode,string SeqNo)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_TQ1.TQ1_KEY,";
            SQL += "dbo.HL7_TQ1.SET_CODE,";
            SQL += "dbo.HL7_TQ1.TQ1_1,";
            SQL += "dbo.HL7_TQ1.TQ1_2,";
            SQL += "dbo.HL7_TQ1.TQ1_3,";
            SQL += "dbo.HL7_TQ1.TQ1_4,";
            SQL += "dbo.HL7_TQ1.TQ1_5,";
            SQL += "dbo.HL7_TQ1.TQ1_6,";
            SQL += "dbo.HL7_TQ1.TQ1_7,";
            SQL += "dbo.HL7_TQ1.TQ1_8,";
            SQL += "dbo.HL7_TQ1.TQ1_9,";
            SQL += "dbo.HL7_TQ1.TQ1_10,";
            SQL += "dbo.HL7_TQ1.TQ1_11,";
            SQL += "dbo.HL7_TQ1.TQ1_12,";
            SQL += "dbo.HL7_TQ1.TQ1_13,";
            SQL += "dbo.HL7_TQ1.TQ1_14 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_TQ1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_TQ1.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_TQ1.TQ1_1 =@TQ1_1 ";
            SQL += "AND ";
            SQL += "dbo.HL7_TQ1.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@TQ1_1", SeqNo);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(TQ1 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertTQ1()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@TQ1_1", entity.TQ1_1);
                cmd.Parameters.AddWithValue("@TQ1_2", entity.TQ1_2);
                cmd.Parameters.AddWithValue("@TQ1_3", entity.TQ1_3);
                cmd.Parameters.AddWithValue("@TQ1_4", entity.TQ1_4);
                cmd.Parameters.AddWithValue("@TQ1_5", entity.TQ1_5);
                cmd.Parameters.AddWithValue("@TQ1_6", entity.TQ1_6);
                cmd.Parameters.AddWithValue("@TQ1_7", entity.TQ1_7);
                cmd.Parameters.AddWithValue("@TQ1_8", entity.TQ1_8);
                cmd.Parameters.AddWithValue("@TQ1_9", entity.TQ1_9);
                cmd.Parameters.AddWithValue("@TQ1_10", entity.TQ1_10);
                cmd.Parameters.AddWithValue("@TQ1_11", entity.TQ1_11);
                cmd.Parameters.AddWithValue("@TQ1_12", entity.TQ1_12);
                cmd.Parameters.AddWithValue("@TQ1_13", entity.TQ1_13);
                cmd.Parameters.AddWithValue("@TQ1_14", entity.TQ1_14);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode, string SeqNo)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_TQ1 SET ";
            SQL += "dbo.HL7_TQ1.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_TQ1.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_TQ1.TQ1_1 =@TQ1_1 ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@TQ1_1", SeqNo);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}