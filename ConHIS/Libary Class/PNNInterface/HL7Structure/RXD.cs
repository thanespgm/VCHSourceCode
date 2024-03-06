using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.PNNInterface.HL7Structure
{
    public class RXD
    {
        private string rXD_KEY;
        private string rXD_1;
        private string rXD_2;
        private string rXD_3;
        private string rXD_4;
        private string rXD_5;
        private string rXD_6;
        private string rXD_7;
        private string rXD_8;
        private string rXD_9;
        private string rXD_10;
        private string rXD_11;
        private string rXD_12;
        private string rXD_13;
        private string rXD_14;
        private string rXD_15;
        private string rXD_16;
        private string rXD_17;
        private string rXD_18;
        private string rXD_19;
        private string rXD_20;
        private string rXD_21;
        private string rXD_22;
        private string rXD_23;
        private string rXD_24;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties

        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public string RXD_KEY { get => rXD_KEY; set => rXD_KEY = value; }

        //[Required(ErrorMessage = "RXD.1 - Dispense Sub-id Counter : Thanes Required -> f_seqno")]
        public string RXD_1 { get => rXD_1; set => rXD_1 = value; }

        //[Required(ErrorMessage = "RXD.2 - Dispense/Give Code : Thanes Required -> f_orderitemcode, f_orderitemname")]
        public string RXD_2 { get => rXD_2; set => rXD_2 = value; }

        //[Required(ErrorMessage = "RXD.3 - Date/Time Dispensed : Thanes Required -> f_lastmodified")]
        public string RXD_3 { get => rXD_3; set => rXD_3 = value; }

        public string RXD_4 { get => rXD_4; set => rXD_4 = value; }

        //[Required(ErrorMessage = "RXD.5 - Actual Dispense Units : Thanes Required -> f_unitcode,f_unitdesc")]
        public string RXD_5 { get => rXD_5; set => rXD_5 = value; }

        //[Required(ErrorMessage = "RXD.6 - Actual Dosage Form : Thanes Required -> รูปแบบยาหรือเวชภัณฑ์")]
        public string RXD_6 { get => rXD_6; set => rXD_6 = value; }

        //[Required(ErrorMessage = "RXD.7 - Prescription Number : Thanes Required -> f_prescriptionno")]
        public string RXD_7 { get => rXD_7; set => rXD_7 = value; }

        //[Required(ErrorMessage = "RXD.8 - Number Of Refills Remaining : Thanes Required -> f_instructioncode ไม่ตรงความหมายแต่ใช้ทดแทน")]
        public string RXD_8 { get => rXD_8; set => rXD_8 = value; }

        //[Required(ErrorMessage = "RXD.9 - Dispense Notes : Thanes Required -> f_instructiondesc")]
        public string RXD_9 { get => rXD_9; set => rXD_9 = value; }
        public string RXD_10 { get => rXD_10; set => rXD_10 = value; } 
        public string RXD_11 { get => rXD_11; set => rXD_11 = value; }

        //[Required(ErrorMessage = "RXD.12 - Total Daily Dose : Thanes Required -> f_dosage,f_dosageunit")]
        public string RXD_12 { get => rXD_12; set => rXD_12 = value; }

        public string RXD_13 { get => rXD_13; set => rXD_13 = value; }
        public string RXD_14 { get => rXD_14; set => rXD_14 = value; }

        //[Required(ErrorMessage = "RXD.15 - Pharmacy/Treatment Supplier's Special Dispensing Instructions -> extention.druglabel")]
        public string RXD_15 { get => rXD_15; set => rXD_15 = value; }

        public string RXD_16 { get => rXD_16; set => rXD_16 = value; }
        public string RXD_17 { get => rXD_17; set => rXD_17 = value; }

       // [Required(ErrorMessage = "RXD.18 - Substance Lot Number : Thanes Required -> f_itemlotno")]
        public string RXD_18 { get => rXD_18; set => rXD_18 = value; }

       // [Required(ErrorMessage = "RXD.19 - Substance Expiration Date : Thanes Required -> f_itemlotexpire")]
        public string RXD_19 { get => rXD_19; set => rXD_19 = value; }
        public string RXD_20 { get => rXD_20; set => rXD_20 = value; }
        public string RXD_21 { get => rXD_21; set => rXD_21 = value; }
        public string RXD_22 { get => rXD_22; set => rXD_22 = value; }
        public string RXD_23 { get => rXD_23; set => rXD_23 = value; }

        //[Required(ErrorMessage = "RXD.24 - Dispense Package Method : Thanes Required -> สถานะการจ่ายยา ค่าคงที่ AD = Automatic Dispensing")]
        public string RXD_24 { get => rXD_24; set => rXD_24 = value; }

        //public string RXD_25 { get => rXD_25; set => rXD_25 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public RXD()
        {
        }

        private string InsertRXD()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_RXD( ";
            SQL += "dbo.HL7_RXD.SET_CODE,";
            SQL += "dbo.HL7_RXD.RXD_1,";
            SQL += "dbo.HL7_RXD.RXD_2,";
            SQL += "dbo.HL7_RXD.RXD_3,";
            SQL += "dbo.HL7_RXD.RXD_4,";
            SQL += "dbo.HL7_RXD.RXD_5,";
            SQL += "dbo.HL7_RXD.RXD_6,";
            SQL += "dbo.HL7_RXD.RXD_7,";
            SQL += "dbo.HL7_RXD.RXD_8,";
            SQL += "dbo.HL7_RXD.RXD_9,";
            SQL += "dbo.HL7_RXD.RXD_10,";
            SQL += "dbo.HL7_RXD.RXD_11,";
            SQL += "dbo.HL7_RXD.RXD_12,";
            SQL += "dbo.HL7_RXD.RXD_13,";
            SQL += "dbo.HL7_RXD.RXD_14,";
            SQL += "dbo.HL7_RXD.RXD_15,";
            SQL += "dbo.HL7_RXD.RXD_16,";
            SQL += "dbo.HL7_RXD.RXD_17,";
            SQL += "dbo.HL7_RXD.RXD_18,";
            SQL += "dbo.HL7_RXD.RXD_19,";
            SQL += "dbo.HL7_RXD.RXD_20,";
            SQL += "dbo.HL7_RXD.RXD_21,";
            SQL += "dbo.HL7_RXD.RXD_22,";
            SQL += "dbo.HL7_RXD.RXD_23,";
            SQL += "dbo.HL7_RXD.RXD_24,";
            SQL += "dbo.HL7_RXD.EVEN,";
            SQL += "dbo.HL7_RXD.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@RXD_1,";
            SQL += "@RXD_2,";
            SQL += "@RXD_3,";
            SQL += "@RXD_4,";
            SQL += "@RXD_5,";
            SQL += "@RXD_6,";
            SQL += "@RXD_7,";
            SQL += "@RXD_8,";
            SQL += "@RXD_9,";
            SQL += "@RXD_10,";
            SQL += "@RXD_11,";
            SQL += "@RXD_12,";
            SQL += "@RXD_13,";
            SQL += "@RXD_14,";
            SQL += "@RXD_15,";
            SQL += "@RXD_16,";
            SQL += "@RXD_17,";
            SQL += "@RXD_18,";
            SQL += "@RXD_19,";
            SQL += "@RXD_20,";
            SQL += "@RXD_21,";
            SQL += "@RXD_22,";
            SQL += "@RXD_23,";
            SQL += "@RXD_24,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectRXD(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_RXD.RXD_KEY,";
            SQL += "dbo.HL7_RXD.SET_CODE,";
            SQL += "dbo.HL7_RXD.RXD_1,";
            SQL += "dbo.HL7_RXD.RXD_2,";
            SQL += "dbo.HL7_RXD.RXD_3,";
            SQL += "dbo.HL7_RXD.RXD_4,";
            SQL += "dbo.HL7_RXD.RXD_5,";
            SQL += "dbo.HL7_RXD.RXD_6,";
            SQL += "dbo.HL7_RXD.RXD_7,";
            SQL += "dbo.HL7_RXD.RXD_8,";
            SQL += "dbo.HL7_RXD.RXD_9,";
            SQL += "dbo.HL7_RXD.RXD_10,";
            SQL += "dbo.HL7_RXD.RXD_11,";
            SQL += "dbo.HL7_RXD.RXD_12,";
            SQL += "dbo.HL7_RXD.RXD_13,";
            SQL += "dbo.HL7_RXD.RXD_14,";
            SQL += "dbo.HL7_RXD.RXD_15,";
            SQL += "dbo.HL7_RXD.RXD_16,";
            SQL += "dbo.HL7_RXD.RXD_17,";
            SQL += "dbo.HL7_RXD.RXD_18,";
            SQL += "dbo.HL7_RXD.RXD_19,";
            SQL += "dbo.HL7_RXD.RXD_20,";
            SQL += "dbo.HL7_RXD.RXD_21,";
            SQL += "dbo.HL7_RXD.RXD_22,";
            SQL += "dbo.HL7_RXD.RXD_23,";
            SQL += "dbo.HL7_RXD.RXD_24 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_RXD ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXD.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXD.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(RXD entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertRXD()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@RXD_1", entity.RXD_1);
                cmd.Parameters.AddWithValue("@RXD_2", entity.RXD_2);
                cmd.Parameters.AddWithValue("@RXD_3", entity.RXD_3);
                cmd.Parameters.AddWithValue("@RXD_4", entity.RXD_4);
                cmd.Parameters.AddWithValue("@RXD_5", entity.RXD_5);
                cmd.Parameters.AddWithValue("@RXD_6", entity.RXD_6);
                cmd.Parameters.AddWithValue("@RXD_7", entity.RXD_7);
                cmd.Parameters.AddWithValue("@RXD_8", entity.RXD_8);
                cmd.Parameters.AddWithValue("@RXD_9", entity.RXD_9);
                cmd.Parameters.AddWithValue("@RXD_10", entity.RXD_10);
                cmd.Parameters.AddWithValue("@RXD_11", entity.RXD_11);
                cmd.Parameters.AddWithValue("@RXD_12", entity.RXD_12);
                cmd.Parameters.AddWithValue("@RXD_13", entity.RXD_13);
                cmd.Parameters.AddWithValue("@RXD_14", entity.RXD_14);
                cmd.Parameters.AddWithValue("@RXD_15", entity.RXD_15);
                cmd.Parameters.AddWithValue("@RXD_16", entity.RXD_16);
                cmd.Parameters.AddWithValue("@RXD_17", entity.RXD_17);
                cmd.Parameters.AddWithValue("@RXD_18", entity.RXD_18);
                cmd.Parameters.AddWithValue("@RXD_19", entity.RXD_19);
                cmd.Parameters.AddWithValue("@RXD_20", entity.RXD_20);
                cmd.Parameters.AddWithValue("@RXD_21", entity.RXD_21);
                cmd.Parameters.AddWithValue("@RXD_22", entity.RXD_22);
                cmd.Parameters.AddWithValue("@RXD_23", entity.RXD_23);
                cmd.Parameters.AddWithValue("@RXD_24", entity.RXD_24);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode, string seq)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_RXD SET ";
            SQL += "dbo.HL7_RXD.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXD.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXD.RXD_1 =@RXD_1 ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@RXD_1", seq);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}