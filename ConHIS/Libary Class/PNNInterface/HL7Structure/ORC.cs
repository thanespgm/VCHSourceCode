using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.PNNInterface.HL7Structure
{ 
    public class ORC
    {
        private string oRC_KEY;
        private string oRC_1;
        private string oRC_2;
        private string oRC_3;
        private string oRC_4;
        private string oRC_5;
        private string oRC_6;
        private string oRC_7;
        private string oRC_8;
        private string oRC_9;
        private string oRC_10;
        private string oRC_11;
        private string oRC_12;
        private string oRC_13;
        private string oRC_14;
        private string oRC_15;
        private string oRC_16;
        private string oRC_17;
        private string oRC_18;
        private string oRC_19;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string ORC_KEY { get => oRC_KEY; set => oRC_KEY = value; }

        //[Required(ErrorMessage = "ORC.1 - Order Control : ใส่ค่าคงที่ NW = New Order , ใส่ค่า RP = Order replace request สำหรับแก้ไข")]
        public string ORC_1 { get => oRC_1; set => oRC_1 = value; }

        //[Required(ErrorMessage = "ORC.2 - Placer Order Number : Thanes Required -> MSH.10 - Message Control Id")]
        public string ORC_2 { get => oRC_2; set => oRC_2 = value; }

        //[Required(ErrorMessage = "ORC.3 - Filler Order Number : Thanes Required -> f_prescriptionno")]
        public string ORC_3 { get => oRC_3; set => oRC_3 = value; }

        public string ORC_4 { get => oRC_4; set => oRC_4 = value; }

        //[Required(ErrorMessage = "ORC.5 - Order Status : Thanes Required -> f_dispensestatus ** ค่าสถานะรอใน HL7 จะเป็น SC")]
        public string ORC_5 { get => oRC_5; set => oRC_5 = value; }

        //[Required(ErrorMessage = "ORC.6 - Response Flag : Thanes Required -> f_status ** ค่าสถานะรอใน HL7 จะเป็น N")]
        public string ORC_6 { get => oRC_6; set => oRC_6 = value; }

        public string ORC_7 { get => oRC_7; set => oRC_7 = value; }
        public string ORC_8 { get => oRC_8; set => oRC_8 = value; }

        //[Required(ErrorMessage = "ORC.9 - Date/Time Of Transaction : Thanes Required -> f_prescriptiondate")]
        public string ORC_9 { get => oRC_9; set => oRC_9 = value; }

        //[Required(ErrorMessage = "ORC.10 - Entered By : Thanes Required -> f_usercreateby")]
        public string ORC_10 { get => oRC_10; set => oRC_10 = value; }

        //[Required(ErrorMessage = "ORC.11 - Verified By : Thanes Required -> f_useracepptby")]
        public string ORC_11 { get => oRC_11; set => oRC_11 = value; }

        //[Required(ErrorMessage = "ORC.12 - Ordering Provider : Thanes Required -> f_doctorcode, f_doctorname")]
        public string ORC_12 { get => oRC_12; set => oRC_12 = value; }

        //[Required(ErrorMessage = "ORC.13 - Enterer's Location : Thanes Required -> f_pharmacylocationcode, f_pharmacylocationdesc")]
        public string ORC_13 { get => oRC_13; set => oRC_13 = value; }
        public string ORC_14 { get => oRC_14; set => oRC_14 = value; }
        public string ORC_15 { get => oRC_15; set => oRC_15 = value; }
        public string ORC_16 { get => oRC_16; set => oRC_16 = value; }
        public string ORC_17 { get => oRC_17; set => oRC_17 = value; }

        //[Required(ErrorMessage = "ORC.18 - Entering Device : ชื่ออุปกรณ์หรือหมายเลขไอพี-ที่สร้างใบยา")]
        public string ORC_18 { get => oRC_18; set => oRC_18 = value; }
        public string ORC_19 { get => oRC_19; set => oRC_19 = value; } 
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public ORC()
        {
        }

        private string InsertORC()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_ORC( ";
            SQL += "dbo.HL7_ORC.SET_CODE,";
            SQL += "dbo.HL7_ORC.ORC_1,";
            SQL += "dbo.HL7_ORC.ORC_2,";
            SQL += "dbo.HL7_ORC.ORC_3,";
            SQL += "dbo.HL7_ORC.ORC_4,";
            SQL += "dbo.HL7_ORC.ORC_5,";
            SQL += "dbo.HL7_ORC.ORC_6,";
            SQL += "dbo.HL7_ORC.ORC_7,";
            SQL += "dbo.HL7_ORC.ORC_8,";
            SQL += "dbo.HL7_ORC.ORC_9,";
            SQL += "dbo.HL7_ORC.ORC_10,";
            SQL += "dbo.HL7_ORC.ORC_11,";
            SQL += "dbo.HL7_ORC.ORC_12,";
            SQL += "dbo.HL7_ORC.ORC_13,";
            SQL += "dbo.HL7_ORC.ORC_14,";
            SQL += "dbo.HL7_ORC.ORC_15,";
            SQL += "dbo.HL7_ORC.ORC_16,";
            SQL += "dbo.HL7_ORC.ORC_17,";
            SQL += "dbo.HL7_ORC.ORC_18,";
            SQL += "dbo.HL7_ORC.ORC_19,";   
            SQL += "dbo.HL7_ORC.EVEN,";
            SQL += "dbo.HL7_ORC.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@ORC_1,";
            SQL += "@ORC_2,";
            SQL += "@ORC_3,";
            SQL += "@ORC_4,";
            SQL += "@ORC_5,";
            SQL += "@ORC_6,";
            SQL += "@ORC_7,";
            SQL += "@ORC_8,";
            SQL += "@ORC_9,";
            SQL += "@ORC_10,";
            SQL += "@ORC_11,";
            SQL += "@ORC_12,";
            SQL += "@ORC_13,";
            SQL += "@ORC_14,";
            SQL += "@ORC_15,";
            SQL += "@ORC_16,";
            SQL += "@ORC_17,";
            SQL += "@ORC_18,";
            SQL += "@ORC_19,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectORC(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_ORC.ORC_KEY,";
            SQL += "dbo.HL7_ORC.SET_CODE,";
            SQL += "dbo.HL7_ORC.ORC_1,";
            SQL += "dbo.HL7_ORC.ORC_2,";
            SQL += "dbo.HL7_ORC.ORC_3,";
            SQL += "dbo.HL7_ORC.ORC_4,";
            SQL += "dbo.HL7_ORC.ORC_5,";
            SQL += "dbo.HL7_ORC.ORC_6,";
            SQL += "dbo.HL7_ORC.ORC_7,";
            SQL += "dbo.HL7_ORC.ORC_8,";
            SQL += "dbo.HL7_ORC.ORC_9,";
            SQL += "dbo.HL7_ORC.ORC_10,";
            SQL += "dbo.HL7_ORC.ORC_11,";
            SQL += "dbo.HL7_ORC.ORC_12,";
            SQL += "dbo.HL7_ORC.ORC_13,";
            SQL += "dbo.HL7_ORC.ORC_14,";
            SQL += "dbo.HL7_ORC.ORC_15,";
            SQL += "dbo.HL7_ORC.ORC_16,";
            SQL += "dbo.HL7_ORC.ORC_17,";
            SQL += "dbo.HL7_ORC.ORC_18,";
            SQL += "dbo.HL7_ORC.ORC_19 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_ORC ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_ORC.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_ORC.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(ORC entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertORC()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@ORC_1", entity.ORC_1);
                cmd.Parameters.AddWithValue("@ORC_2", entity.ORC_2);
                cmd.Parameters.AddWithValue("@ORC_3", entity.ORC_3);
                cmd.Parameters.AddWithValue("@ORC_4", entity.ORC_4);
                cmd.Parameters.AddWithValue("@ORC_5", entity.ORC_5);
                cmd.Parameters.AddWithValue("@ORC_6", entity.ORC_6);
                cmd.Parameters.AddWithValue("@ORC_7", entity.ORC_7);
                cmd.Parameters.AddWithValue("@ORC_8", entity.ORC_8);
                cmd.Parameters.AddWithValue("@ORC_9", entity.ORC_9);
                cmd.Parameters.AddWithValue("@ORC_10", entity.ORC_10);
                cmd.Parameters.AddWithValue("@ORC_11", entity.ORC_11);
                cmd.Parameters.AddWithValue("@ORC_12", entity.ORC_12);
                cmd.Parameters.AddWithValue("@ORC_13", entity.ORC_13);
                cmd.Parameters.AddWithValue("@ORC_14", entity.ORC_14);
                cmd.Parameters.AddWithValue("@ORC_15", entity.ORC_15);
                cmd.Parameters.AddWithValue("@ORC_16", entity.ORC_16);
                cmd.Parameters.AddWithValue("@ORC_17", entity.ORC_17);
                cmd.Parameters.AddWithValue("@ORC_18", entity.ORC_18);
                cmd.Parameters.AddWithValue("@ORC_19", entity.ORC_19);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
              
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_ORC SET ";
            SQL += "dbo.HL7_ORC.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_ORC.SET_CODE =@SET_CODE ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}