using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.PNNInterface.HL7Structure
{
    public class RXE
    {
        private string rXE_KEY;
        private string rXE_1;
        private string rXE_2;
        private string rXE_3;
        private string rXE_4;
        private string rXE_5;
        private string rXE_6;
        private string rXE_7;
        private string rXE_8;
        private string rXE_9;
        private string rXE_10;
        private string rXE_11;
        private string rXE_12;
        private string rXE_13;
        private string rXE_14;
        private string rXE_15;
        private string rXE_16;
        private string rXE_17;
        private string rXE_18;
        private string rXE_19;
        private string rXE_20;
        private string rXE_21;
        private string rXE_22;
        private string rXE_23;
        private string rXE_24;
        private string rXE_25;
        private string rXE_26;
        private string rXE_27;
        private string rXE_28;
        private string rXE_29;
        private string rXE_30;
        private string rXE_31;
        private string rXE_32;
        private string rXE_33;
        private string rXE_34;
        private string rXE_35;
        private string rXE_36;
        private string rXE_37;
        private string rXE_38;
        private string rXE_39;
        private string rXE_40;
        private string rXE_41;
        private string rXE_42;
        private string rXE_43;
        private string rXE_44;
        private string rXE_45;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;

        //Properties

        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public string RXE_KEY { get => rXE_KEY; set => rXE_KEY = value; }

        //[Required(ErrorMessage = "rXE.1 - Dispense Sub-id Counter : Thanes Required -> f_seqno")]
        public string RXE_1 { get => rXE_1; set => rXE_1 = value; }

        //[Required(ErrorMessage = "rXE.2 - Dispense/Give Code : Thanes Required -> f_orderitemcode, f_orderitemname")]
        public string RXE_2 { get => rXE_2; set => rXE_2 = value; }

        //[Required(ErrorMessage = "rXE.3 - Date/Time Dispensed : Thanes Required -> f_lastmodified")]
        public string RXE_3 { get => rXE_3; set => rXE_3 = value; }

        public string RXE_4 { get => rXE_4; set => rXE_4 = value; }

        //[Required(ErrorMessage = "rXE.5 - Actual Dispense Units : Thanes Required -> f_unitcode,f_unitdesc")]
        public string RXE_5 { get => rXE_5; set => rXE_5 = value; }

        //[Required(ErrorMessage = "rXE.6 - Actual Dosage Form : Thanes Required -> รูปแบบยาหรือเวชภัณฑ์")]
        public string RXE_6 { get => rXE_6; set => rXE_6 = value; }

        //[Required(ErrorMessage = "rXE.7 - Prescription Number : Thanes Required -> f_prescriptionno")]
        public string RXE_7 { get => rXE_7; set => rXE_7 = value; }

        //[Required(ErrorMessage = "rXE.8 - Number Of Refills Remaining : Thanes Required -> f_instructioncode ไม่ตรงความหมายแต่ใช้ทดแทน")]
        public string RXE_8 { get => rXE_8; set => rXE_8 = value; }

        //[Required(ErrorMessage = "rXE.9 - Dispense Notes : Thanes Required -> f_instructiondesc")]
        public string RXE_9 { get => rXE_9; set => rXE_9 = value; }
        public string RXE_10 { get => rXE_10; set => rXE_10 = value; } 
        public string RXE_11 { get => rXE_11; set => rXE_11 = value; }

        //[Required(ErrorMessage = "rXE.12 - Total Daily Dose : Thanes Required -> f_dosage,f_dosageunit")]
        public string RXE_12 { get => rXE_12; set => rXE_12 = value; }

        public string RXE_13 { get => rXE_13; set => rXE_13 = value; }
        public string RXE_14 { get => rXE_14; set => rXE_14 = value; }

        //[Required(ErrorMessage = "rXE.15 - Pharmacy/Treatment Supplier's Special Dispensing Instructions -> extention.druglabel")]
        public string RXE_15 { get => rXE_15; set => rXE_15 = value; }

        public string RXE_16 { get => rXE_16; set => rXE_16 = value; }
        public string RXE_17 { get => rXE_17; set => rXE_17 = value; }

       // [Required(ErrorMessage = "rXE.18 - Substance Lot Number : Thanes Required -> f_itemlotno")]
        public string RXE_18 { get => rXE_18; set => rXE_18 = value; }

       // [Required(ErrorMessage = "rXE.19 - Substance Expiration Date : Thanes Required -> f_itemlotexpire")]
        public string RXE_19 { get => rXE_19; set => rXE_19 = value; }
        public string RXE_20 { get => rXE_20; set => rXE_20 = value; }
        public string RXE_21 { get => rXE_21; set => rXE_21 = value; }
        public string RXE_22 { get => rXE_22; set => rXE_22 = value; }
        public string RXE_23 { get => rXE_23; set => rXE_23 = value; }

        //[Required(ErrorMessage = "rXE.24 - Dispense Package Method : Thanes Required -> สถานะการจ่ายยา ค่าคงที่ AD = Automatic Dispensing")]
        public string RXE_24 { get => rXE_24; set => rXE_24 = value; }

        public string RXE_25 { get => rXE_25; set => rXE_25 = value; }
        public string RXE_26 { get => rXE_26; set => rXE_26 = value; }
        public string RXE_27 { get => rXE_27; set => rXE_27 = value; }
        public string RXE_28 { get => rXE_28; set => rXE_28 = value; }
        public string RXE_29 { get => rXE_29; set => rXE_29 = value; }
        public string RXE_30 { get => rXE_30; set => rXE_30 = value; }
        public string RXE_31 { get => rXE_31; set => rXE_31 = value; }
        public string RXE_32 { get => rXE_32; set => rXE_32 = value; }
        public string RXE_33 { get => rXE_33; set => rXE_33 = value; }
        public string RXE_34 { get => rXE_34; set => rXE_34 = value; }
        public string RXE_35 { get => rXE_35; set => rXE_35 = value; }
        public string RXE_36 { get => rXE_36; set => rXE_36 = value; }
        public string RXE_37 { get => rXE_37; set => rXE_37 = value; }
        public string RXE_38 { get => rXE_38; set => rXE_38 = value; }
        public string RXE_39 { get => rXE_39; set => rXE_39 = value; }
        public string RXE_40 { get => rXE_40; set => rXE_40 = value; }
        public string RXE_41 { get => rXE_41; set => rXE_41 = value; }
        public string RXE_42 { get => rXE_42; set => rXE_42 = value; }
        public string RXE_43 { get => rXE_43; set => rXE_43 = value; }
        public string RXE_44 { get => rXE_44; set => rXE_44 = value; }
        public string RXE_45 { get => rXE_45; set => rXE_45 = value; }

        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        public RXE()
        {
        }

        private string InsertrXE()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_RXE( ";
            SQL += "dbo.HL7_RXE.SET_CODE,";
            SQL += "dbo.HL7_RXE.RXE_1,";
            SQL += "dbo.HL7_RXE.RXE_2,";
            SQL += "dbo.HL7_RXE.RXE_3,";
            SQL += "dbo.HL7_RXE.RXE_4,";
            SQL += "dbo.HL7_RXE.RXE_5,";
            SQL += "dbo.HL7_RXE.RXE_6,";
            SQL += "dbo.HL7_RXE.RXE_7,";
            SQL += "dbo.HL7_RXE.RXE_8,";
            SQL += "dbo.HL7_RXE.RXE_9,";
            SQL += "dbo.HL7_RXE.RXE_10,";
            SQL += "dbo.HL7_RXE.RXE_11,";
            SQL += "dbo.HL7_RXE.RXE_12,";
            SQL += "dbo.HL7_RXE.RXE_13,";
            SQL += "dbo.HL7_RXE.RXE_14,";
            SQL += "dbo.HL7_RXE.RXE_15,";
            SQL += "dbo.HL7_RXE.RXE_16,";
            SQL += "dbo.HL7_RXE.RXE_17,";
            SQL += "dbo.HL7_RXE.RXE_18,";
            SQL += "dbo.HL7_RXE.RXE_19,";
            SQL += "dbo.HL7_RXE.RXE_20,";
            SQL += "dbo.HL7_RXE.RXE_21,";
            SQL += "dbo.HL7_RXE.RXE_22,";
            SQL += "dbo.HL7_RXE.RXE_23,";
            SQL += "dbo.HL7_RXE.RXE_24,";
            SQL += "dbo.HL7_RXE.RXE_25,";
            SQL += "dbo.HL7_RXE.RXE_26,";
            SQL += "dbo.HL7_RXE.RXE_27,";
            SQL += "dbo.HL7_RXE.RXE_28,";
            SQL += "dbo.HL7_RXE.RXE_29,";
            SQL += "dbo.HL7_RXE.RXE_30,";
            //SQL += "dbo.HL7_RXE.RXE_31,";
            //SQL += "dbo.HL7_RXE.RXE_32,";
            //SQL += "dbo.HL7_RXE.RXE_33,";
            //SQL += "dbo.HL7_RXE.RXE_34,";
            //SQL += "dbo.HL7_RXE.RXE_35,";
            //SQL += "dbo.HL7_RXE.RXE_36,";
            //SQL += "dbo.HL7_RXE.RXE_37,";
            //SQL += "dbo.HL7_RXE.RXE_38,";
            //SQL += "dbo.HL7_RXE.RXE_39,";
            //SQL += "dbo.HL7_RXE.RXE_40,";
            //SQL += "dbo.HL7_RXE.RXE_41,";
            //SQL += "dbo.HL7_RXE.RXE_42,";
            //SQL += "dbo.HL7_RXE.RXE_43,";
            //SQL += "dbo.HL7_RXE.RXE_44,";
            //SQL += "dbo.HL7_RXE.RXE_45,";
            SQL += "dbo.HL7_RXE.EVEN,";
            SQL += "dbo.HL7_RXE.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@RXE_1,";
            SQL += "@RXE_2,";
            SQL += "@RXE_3,";
            SQL += "@RXE_4,";
            SQL += "@RXE_5,";
            SQL += "@RXE_6,";
            SQL += "@RXE_7,";
            SQL += "@RXE_8,";
            SQL += "@RXE_9,";
            SQL += "@RXE_10,";
            SQL += "@RXE_11,";
            SQL += "@RXE_12,";
            SQL += "@RXE_13,";
            SQL += "@RXE_14,";
            SQL += "@RXE_15,";
            SQL += "@RXE_16,";
            SQL += "@RXE_17,";
            SQL += "@RXE_18,";
            SQL += "@RXE_19,";
            SQL += "@RXE_20,";
            SQL += "@RXE_21,";
            SQL += "@RXE_22,";
            SQL += "@RXE_23,";
            SQL += "@RXE_24,";
            SQL += "@RXE_25,";
            SQL += "@RXE_26,";
            SQL += "@RXE_27,";
            SQL += "@RXE_28,";
            SQL += "@RXE_29,";
            SQL += "@RXE_30,";
            //SQL += "@RXE_31,";
            //SQL += "@RXE_32,";
            //SQL += "@RXE_33,";
            //SQL += "@RXE_34,";
            //SQL += "@RXE_35,";
            //SQL += "@RXE_36,";
            //SQL += "@RXE_37,";
            //SQL += "@RXE_38,";
            //SQL += "@RXE_39,";
            //SQL += "@RXE_40,";
            //SQL += "@RXE_41,";
            //SQL += "@RXE_42,";
            //SQL += "@RXE_43,";
            //SQL += "@RXE_44,";
            //SQL += "@RXE_45,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectRXE(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_RXE.RXE_KEY,";
            SQL += "dbo.HL7_RXE.SET_CODE,";
            SQL += "dbo.HL7_RXE.RXE_1,";
            SQL += "dbo.HL7_RXE.RXE_2,";
            SQL += "dbo.HL7_RXE.RXE_3,";
            SQL += "dbo.HL7_RXE.RXE_4,";
            SQL += "dbo.HL7_RXE.RXE_5,";
            SQL += "dbo.HL7_RXE.RXE_6,";
            SQL += "dbo.HL7_RXE.RXE_7,";
            SQL += "dbo.HL7_RXE.RXE_8,";
            SQL += "dbo.HL7_RXE.RXE_9,";
            SQL += "dbo.HL7_RXE.RXE_10,";
            SQL += "dbo.HL7_RXE.RXE_11,";
            SQL += "dbo.HL7_RXE.RXE_12,";
            SQL += "dbo.HL7_RXE.RXE_13,";
            SQL += "dbo.HL7_RXE.RXE_14,";
            SQL += "dbo.HL7_RXE.RXE_15,";
            SQL += "dbo.HL7_RXE.RXE_16,";
            SQL += "dbo.HL7_RXE.RXE_17,";
            SQL += "dbo.HL7_RXE.RXE_18,";
            SQL += "dbo.HL7_RXE.RXE_19,";
            SQL += "dbo.HL7_RXE.RXE_20,";
            SQL += "dbo.HL7_RXE.RXE_21,";
            SQL += "dbo.HL7_RXE.RXE_22,";
            SQL += "dbo.HL7_RXE.RXE_23,";
            SQL += "dbo.HL7_RXE.RXE_24, ";
            SQL += "dbo.HL7_RXE.RXE_26,";
            SQL += "dbo.HL7_RXE.RXE_27,";
            SQL += "dbo.HL7_RXE.RXE_28,";
            SQL += "dbo.HL7_RXE.RXE_29,";
            SQL += "dbo.HL7_RXE.RXE_30,";
            SQL += "dbo.HL7_RXE.RXE_31,";
            SQL += "dbo.HL7_RXE.RXE_32,";
            SQL += "dbo.HL7_RXE.RXE_33,";
            SQL += "dbo.HL7_RXE.RXE_34,";
            SQL += "dbo.HL7_RXE.RXE_35,";
            SQL += "dbo.HL7_RXE.RXE_36,";
            SQL += "dbo.HL7_RXE.RXE_37,";
            SQL += "dbo.HL7_RXE.RXE_38,";
            SQL += "dbo.HL7_RXE.RXE_39,";
            SQL += "dbo.HL7_RXE.RXE_40,";
            SQL += "dbo.HL7_RXE.RXE_41,";
            SQL += "dbo.HL7_RXE.RXE_42,";
            SQL += "dbo.HL7_RXE.RXE_43,";
            SQL += "dbo.HL7_RXE.RXE_44,";
            SQL += "dbo.HL7_RXE.RXE_45 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_RXE ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXE.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public DataSet SelectRXEByDrugCode(string SetCode, string drugcode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_RXE.RXE_KEY,";
            SQL += "dbo.HL7_RXE.SET_CODE,";
            SQL += "dbo.HL7_RXE.RXE_1,";
            SQL += "dbo.HL7_RXE.RXE_2,";
            SQL += "dbo.HL7_RXE.RXE_3,";
            SQL += "dbo.HL7_RXE.RXE_4,";
            SQL += "dbo.HL7_RXE.RXE_5,";
            SQL += "dbo.HL7_RXE.RXE_6,";
            SQL += "dbo.HL7_RXE.RXE_7,";
            SQL += "dbo.HL7_RXE.RXE_8,";
            SQL += "dbo.HL7_RXE.RXE_9,";
            SQL += "dbo.HL7_RXE.RXE_10,";
            SQL += "dbo.HL7_RXE.RXE_11,";
            SQL += "dbo.HL7_RXE.RXE_12,";
            SQL += "dbo.HL7_RXE.RXE_13,";
            SQL += "dbo.HL7_RXE.RXE_14,";
            SQL += "dbo.HL7_RXE.RXE_15,";
            SQL += "dbo.HL7_RXE.RXE_16,";
            SQL += "dbo.HL7_RXE.RXE_17,";
            SQL += "dbo.HL7_RXE.RXE_18,";
            SQL += "dbo.HL7_RXE.RXE_19,";
            SQL += "dbo.HL7_RXE.RXE_20,";
            SQL += "dbo.HL7_RXE.RXE_21,";
            SQL += "dbo.HL7_RXE.RXE_22,";
            SQL += "dbo.HL7_RXE.RXE_23,";
            SQL += "dbo.HL7_RXE.RXE_24, ";
            SQL += "dbo.HL7_RXE.RXE_26,";
            SQL += "dbo.HL7_RXE.RXE_27,";
            SQL += "dbo.HL7_RXE.RXE_28,";
            SQL += "dbo.HL7_RXE.RXE_29,";
            SQL += "dbo.HL7_RXE.RXE_30,";
            SQL += "dbo.HL7_RXE.RXE_31,";
            SQL += "dbo.HL7_RXE.RXE_32,";
            SQL += "dbo.HL7_RXE.RXE_33,";
            SQL += "dbo.HL7_RXE.RXE_34,";
            SQL += "dbo.HL7_RXE.RXE_35,";
            SQL += "dbo.HL7_RXE.RXE_36,";
            SQL += "dbo.HL7_RXE.RXE_37,";
            SQL += "dbo.HL7_RXE.RXE_38,";
            SQL += "dbo.HL7_RXE.RXE_39,";
            SQL += "dbo.HL7_RXE.RXE_40,";
            SQL += "dbo.HL7_RXE.RXE_41,";
            SQL += "dbo.HL7_RXE.RXE_42,";
            SQL += "dbo.HL7_RXE.RXE_43,";
            SQL += "dbo.HL7_RXE.RXE_44,";
            SQL += "dbo.HL7_RXE.RXE_45 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_RXE ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXE.RXE_2 Like '%" + drugcode + "%' ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXE.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(RXE entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertrXE()))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@RXE_1", entity.RXE_1);
                cmd.Parameters.AddWithValue("@RXE_2", entity.RXE_2);
                cmd.Parameters.AddWithValue("@RXE_3", entity.RXE_3);
                cmd.Parameters.AddWithValue("@RXE_4", entity.RXE_4);
                cmd.Parameters.AddWithValue("@RXE_5", entity.RXE_5);
                cmd.Parameters.AddWithValue("@RXE_6", entity.RXE_6);
                cmd.Parameters.AddWithValue("@RXE_7", entity.RXE_7);
                cmd.Parameters.AddWithValue("@RXE_8", entity.RXE_8);
                cmd.Parameters.AddWithValue("@RXE_9", entity.RXE_9);
                cmd.Parameters.AddWithValue("@RXE_10", entity.RXE_10);
                cmd.Parameters.AddWithValue("@RXE_11", entity.RXE_11);
                cmd.Parameters.AddWithValue("@RXE_12", entity.RXE_12);
                cmd.Parameters.AddWithValue("@RXE_13", entity.RXE_13);
                cmd.Parameters.AddWithValue("@RXE_14", entity.RXE_14);
                cmd.Parameters.AddWithValue("@RXE_15", entity.RXE_15);
                cmd.Parameters.AddWithValue("@RXE_16", entity.RXE_16);
                cmd.Parameters.AddWithValue("@RXE_17", entity.RXE_17);
                cmd.Parameters.AddWithValue("@RXE_18", entity.RXE_18);
                cmd.Parameters.AddWithValue("@RXE_19", entity.RXE_19);
                cmd.Parameters.AddWithValue("@RXE_20", entity.RXE_20);
                cmd.Parameters.AddWithValue("@RXE_21", entity.RXE_21);
                cmd.Parameters.AddWithValue("@RXE_22", entity.RXE_22);
                cmd.Parameters.AddWithValue("@RXE_23", entity.RXE_23);
                cmd.Parameters.AddWithValue("@RXE_24", entity.RXE_24);
                cmd.Parameters.AddWithValue("@RXE_25", entity.RXE_25);
                cmd.Parameters.AddWithValue("@RXE_26", entity.RXE_26);
                cmd.Parameters.AddWithValue("@RXE_27", entity.RXE_27);
                cmd.Parameters.AddWithValue("@RXE_28", entity.RXE_28);
                cmd.Parameters.AddWithValue("@RXE_29", entity.RXE_29);
                cmd.Parameters.AddWithValue("@RXE_30", entity.RXE_30);
                //cmd.Parameters.AddWithValue("@RXE_31", entity.RXE_31);
                //cmd.Parameters.AddWithValue("@RXE_32", entity.RXE_32);
                //cmd.Parameters.AddWithValue("@RXE_33", entity.RXE_33);
                //cmd.Parameters.AddWithValue("@RXE_34", entity.RXE_34);
                //cmd.Parameters.AddWithValue("@RXE_35", entity.RXE_35);
                //cmd.Parameters.AddWithValue("@RXE_36", entity.RXE_36);
                //cmd.Parameters.AddWithValue("@RXE_37", entity.RXE_37);
                //cmd.Parameters.AddWithValue("@RXE_38", entity.RXE_38);
                //cmd.Parameters.AddWithValue("@RXE_39", entity.RXE_39);
                //cmd.Parameters.AddWithValue("@RXE_40", entity.RXE_40);
                //cmd.Parameters.AddWithValue("@RXE_41", entity.RXE_41);
                //cmd.Parameters.AddWithValue("@RXE_42", entity.RXE_42);
                //cmd.Parameters.AddWithValue("@RXE_43", entity.RXE_43);
                //cmd.Parameters.AddWithValue("@RXE_44", entity.RXE_44);
                //cmd.Parameters.AddWithValue("@RXE_45", entity.RXE_45);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode, string drugcode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_RXE SET ";
            SQL += "dbo.HL7_RXE.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_RXE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_RXE.RXE_2 Like '%" + drugcode + "%' ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                cmd.Parameters.AddWithValue("@RXE_2", drugcode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}