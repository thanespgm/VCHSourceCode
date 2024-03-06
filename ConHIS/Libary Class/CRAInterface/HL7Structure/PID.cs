using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class.CRAInterface.HL7Structure
{
    public class PID
    {
        private string pID_KEY;
        private string pID_1;
        private string pID_2;
        private string pID_3;
        private string pID_4;
        private string pID_5;
        private string pID_6;
        private string pID_7;
        private string pID_8;
        private string pID_9;
        private string pID_10;
        private string pID_11;
        private string pID_12;
        private string pID_13;
        private string pID_14;
        private string pID_15;
        private string pID_16;
        private string pID_17;
        private string pID_18;
        private string pID_19;
        private string pID_20;
        private string pID_21;
        private string pID_22;
        private string pID_23;
        private string pID_24;
        private string pID_25;
        private string pID_26;
        private string pID_27;
        private string pID_28;
        private string pID_29;
        private string pID_30;
        private string pID_31;
        private string pID_32;
        private string pID_33;
        private string pID_34;
        private string pID_35;
        private string pID_36;
        private string pID_37;
        private string pID_38;
        private string pID_39;
        private string pID_40;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;
        private DateTime createdAt;


        //Properties

        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public string PID_KEY { get => pID_KEY; set => pID_KEY = value; }

        [Required(ErrorMessage = "PID.1 - Set Id - Pid : ใส่ค่าคงที่ 1 ")]
        public string PID_1 { get => pID_1; set => pID_1 = value; }

        [Required(ErrorMessage = "PID.2 - Patient Id : Thanes Required -> f_hn")]
        public string PID_2 { get => pID_2; set => pID_2 = value; }

        [Required(ErrorMessage = "PID.3 - Patient Identifier List : Thanes Required -> f_hn")]
        public string PID_3 { get => pID_3; set => pID_3 = value; }

        public string PID_4 { get => pID_4; set => pID_4 = value; }

        [Required(ErrorMessage = "PID.5 - Patient Name : Thanes Required -> f_patientname")]
        public string PID_5 { get => pID_5; set => pID_5 = value; }

        public string PID_6 { get => pID_6; set => pID_6 = value; }

        [Required(ErrorMessage = "PID.7 - Date/Time Of Birth : Thanes Required -> f_patientdob")]
        public string PID_7 { get => pID_7; set => pID_7 = value; }

        [Required(ErrorMessage = "PID.8 - Administrative Sex : Thanes Required -> f_sex")]
        public string PID_8 { get => pID_8; set => pID_8 = value; }



        public string PID_9 { get => pID_9; set => pID_9 = value; }
        public string PID_10 { get => pID_10; set => pID_10 = value; }
        public string PID_11 { get => pID_11; set => pID_11 = value; }
        public string PID_12 { get => pID_12; set => pID_12 = value; }
        public string PID_13 { get => pID_13; set => pID_13 = value; }
        public string PID_14 { get => pID_14; set => pID_14 = value; }

        [Required(ErrorMessage = "PID.15 - Primary Language : Thanes Required -> f_language")]
        public string PID_15 { get => pID_15; set => pID_15 = value; }

        public string PID_16 { get => pID_16; set => pID_16 = value; }
        public string PID_17 { get => pID_17; set => pID_17 = value; }
        public string PID_18 { get => pID_18; set => pID_18 = value; }
        public string PID_19 { get => pID_19; set => pID_19 = value; }
        public string PID_20 { get => pID_20; set => pID_20 = value; }
        public string PID_21 { get => pID_21; set => pID_21 = value; }
        public string PID_22 { get => pID_22; set => pID_22 = value; }
        public string PID_23 { get => pID_23; set => pID_23 = value; }
        public string PID_24 { get => pID_24; set => pID_24 = value; }
        public string PID_25 { get => pID_25; set => pID_25 = value; }
        public string PID_26 { get => pID_26; set => pID_26 = value; }
        public string PID_27 { get => pID_27; set => pID_27 = value; }
        public string PID_28 { get => pID_28; set => pID_28 = value; }
        public string PID_29 { get => pID_29; set => pID_29 = value; }
        public string PID_30 { get => pID_30; set => pID_30 = value; }
        public string PID_31 { get => pID_31; set => pID_31 = value; }
        public string PID_32 { get => pID_32; set => pID_32 = value; }
        public string PID_33 { get => pID_33; set => pID_33 = value; }
        public string PID_34 { get => pID_34; set => pID_34 = value; }
        public string PID_35 { get => pID_35; set => pID_35 = value; }
        public string PID_36 { get => pID_36; set => pID_36 = value; }
        public string PID_37 { get => pID_37; set => pID_37 = value; }
        public string PID_38 { get => pID_38; set => pID_38 = value; }
        public string PID_39 { get => pID_39; set => pID_39 = value; }
        public string PID_40 { get => pID_40; set => pID_40 = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }

        public PID()
        {

        }

        private string InsertPID()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_PID( ";
            SQL += "dbo.HL7_PID.SET_CODE,";
            SQL += "dbo.HL7_PID.PID_1,";
            SQL += "dbo.HL7_PID.PID_2,";
            SQL += "dbo.HL7_PID.PID_3,";
            SQL += "dbo.HL7_PID.PID_4,";
            SQL += "dbo.HL7_PID.PID_5,";
            SQL += "dbo.HL7_PID.PID_6,";
            SQL += "dbo.HL7_PID.PID_7,";
            SQL += "dbo.HL7_PID.PID_8,";
            SQL += "dbo.HL7_PID.PID_9,";
            SQL += "dbo.HL7_PID.PID_10,";
            SQL += "dbo.HL7_PID.PID_11,";
            SQL += "dbo.HL7_PID.PID_12,";
            SQL += "dbo.HL7_PID.PID_13,";
            SQL += "dbo.HL7_PID.PID_14,";
            SQL += "dbo.HL7_PID.PID_15,";
            SQL += "dbo.HL7_PID.PID_16,";
            SQL += "dbo.HL7_PID.PID_17,";
            SQL += "dbo.HL7_PID.PID_18,";
            SQL += "dbo.HL7_PID.PID_19,";
            SQL += "dbo.HL7_PID.PID_20,";
            SQL += "dbo.HL7_PID.PID_21,";
            SQL += "dbo.HL7_PID.PID_22,";
            SQL += "dbo.HL7_PID.PID_23,";
            SQL += "dbo.HL7_PID.PID_24,";
            SQL += "dbo.HL7_PID.PID_25,";
            SQL += "dbo.HL7_PID.PID_26,";
            SQL += "dbo.HL7_PID.PID_27,";
            SQL += "dbo.HL7_PID.PID_28,";
            SQL += "dbo.HL7_PID.PID_29,";
            SQL += "dbo.HL7_PID.PID_30,";
            SQL += "dbo.HL7_PID.PID_31,";
            SQL += "dbo.HL7_PID.PID_32,";
            SQL += "dbo.HL7_PID.PID_33,";
            SQL += "dbo.HL7_PID.PID_34,";
            SQL += "dbo.HL7_PID.PID_35,";
            SQL += "dbo.HL7_PID.PID_36,";
            SQL += "dbo.HL7_PID.PID_37,";
            SQL += "dbo.HL7_PID.PID_38,";
            SQL += "dbo.HL7_PID.PID_39,";
            SQL += "dbo.HL7_PID.PID_40,";
            SQL += "dbo.HL7_PID.EVEN, ";
            SQL += "dbo.HL7_PID.CreatedAt) ";
            SQL += "VALUES(";
            SQL += "@SET_CODE,";
            SQL += "@PID_1,";
            SQL += "@PID_2,";
            SQL += "@PID_3,";
            SQL += "@PID_4,";
            SQL += "@PID_5,";
            SQL += "@PID_6,";
            SQL += "@PID_7,";
            SQL += "@PID_8,";
            SQL += "@PID_9,";
            SQL += "@PID_10,";
            SQL += "@PID_11,";
            SQL += "@PID_12,";
            SQL += "@PID_13,";
            SQL += "@PID_14,";
            SQL += "@PID_15,";
            SQL += "@PID_16,";
            SQL += "@PID_17,";
            SQL += "@PID_18,";
            SQL += "@PID_19,";
            SQL += "@PID_20,";
            SQL += "@PID_21,";
            SQL += "@PID_22,";
            SQL += "@PID_23,";
            SQL += "@PID_24,";
            SQL += "@PID_25,";
            SQL += "@PID_26,";
            SQL += "@PID_27,";
            SQL += "@PID_28,";
            SQL += "@PID_29,";
            SQL += "@PID_30,";
            SQL += "@PID_31,";
            SQL += "@PID_32,";
            SQL += "@PID_33,";
            SQL += "@PID_34,";
            SQL += "@PID_35,";
            SQL += "@PID_36,";
            SQL += "@PID_37,";
            SQL += "@PID_38,";
            SQL += "@PID_39,";
            SQL += "@PID_40,";
            SQL += "@EVEN,";
            SQL += "GETDATE())";
            return SQL;
        }

        public DataSet SelectPID(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_PID.PID_KEY,";
            SQL += "dbo.HL7_PID.SET_CODE,";
            SQL += "dbo.HL7_PID.PID_1,";
            SQL += "dbo.HL7_PID.PID_2,";
            SQL += "dbo.HL7_PID.PID_3,";
            SQL += "dbo.HL7_PID.PID_4,";
            SQL += "dbo.HL7_PID.PID_5,";
            SQL += "dbo.HL7_PID.PID_6,";
            SQL += "dbo.HL7_PID.PID_7,";
            SQL += "dbo.HL7_PID.PID_8,";
            SQL += "dbo.HL7_PID.PID_9,";
            SQL += "dbo.HL7_PID.PID_10,";
            SQL += "dbo.HL7_PID.PID_11,";
            SQL += "dbo.HL7_PID.PID_12,";
            SQL += "dbo.HL7_PID.PID_13,";
            SQL += "dbo.HL7_PID.PID_14,";
            SQL += "dbo.HL7_PID.PID_15,";
            SQL += "dbo.HL7_PID.PID_16,";
            SQL += "dbo.HL7_PID.PID_17,";
            SQL += "dbo.HL7_PID.PID_18,";
            SQL += "dbo.HL7_PID.PID_19,";
            SQL += "dbo.HL7_PID.PID_20,";
            SQL += "dbo.HL7_PID.PID_21,";
            SQL += "dbo.HL7_PID.PID_22,";
            SQL += "dbo.HL7_PID.PID_23,";
            SQL += "dbo.HL7_PID.PID_24,";
            SQL += "dbo.HL7_PID.PID_25,";
            SQL += "dbo.HL7_PID.PID_26,";
            SQL += "dbo.HL7_PID.PID_27,";
            SQL += "dbo.HL7_PID.PID_28,";
            SQL += "dbo.HL7_PID.PID_29,";
            SQL += "dbo.HL7_PID.PID_30,";
            SQL += "dbo.HL7_PID.PID_31,";
            SQL += "dbo.HL7_PID.PID_32,";
            SQL += "dbo.HL7_PID.PID_33,";
            SQL += "dbo.HL7_PID.PID_34,";
            SQL += "dbo.HL7_PID.PID_35,";
            SQL += "dbo.HL7_PID.PID_36,";
            SQL += "dbo.HL7_PID.PID_37,";
            SQL += "dbo.HL7_PID.PID_38,";
            SQL += "dbo.HL7_PID.PID_39,";
            SQL += "dbo.HL7_PID.PID_40 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_PID ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_PID.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_PID.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(PID entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(InsertPID()))
            {
                //cmd.Parameters.AddWithValue("@PID_KEY", entity.PID_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@PID_1", entity.PID_1);
                cmd.Parameters.AddWithValue("@PID_2", entity.PID_2);
                cmd.Parameters.AddWithValue("@PID_3", entity.PID_3);
                cmd.Parameters.AddWithValue("@PID_4", entity.PID_4);
                cmd.Parameters.AddWithValue("@PID_5", entity.PID_5);
                cmd.Parameters.AddWithValue("@PID_6", entity.PID_6);
                cmd.Parameters.AddWithValue("@PID_7", entity.PID_7);
                cmd.Parameters.AddWithValue("@PID_8", entity.PID_8);
                cmd.Parameters.AddWithValue("@PID_9", entity.PID_9);
                cmd.Parameters.AddWithValue("@PID_10", entity.PID_10);
                cmd.Parameters.AddWithValue("@PID_11", entity.PID_11);
                cmd.Parameters.AddWithValue("@PID_12", entity.PID_12);
                cmd.Parameters.AddWithValue("@PID_13", entity.PID_13);
                cmd.Parameters.AddWithValue("@PID_14", entity.PID_14);
                cmd.Parameters.AddWithValue("@PID_15", entity.PID_15);
                cmd.Parameters.AddWithValue("@PID_16", entity.PID_16);
                cmd.Parameters.AddWithValue("@PID_17", entity.PID_17);
                cmd.Parameters.AddWithValue("@PID_18", entity.PID_18);
                cmd.Parameters.AddWithValue("@PID_19", entity.PID_19);
                cmd.Parameters.AddWithValue("@PID_20", entity.PID_20);
                cmd.Parameters.AddWithValue("@PID_21", entity.PID_21);
                cmd.Parameters.AddWithValue("@PID_22", entity.PID_22);
                cmd.Parameters.AddWithValue("@PID_23", entity.PID_23);
                cmd.Parameters.AddWithValue("@PID_24", entity.PID_24);
                cmd.Parameters.AddWithValue("@PID_25", entity.PID_25);
                cmd.Parameters.AddWithValue("@PID_26", entity.PID_26);
                cmd.Parameters.AddWithValue("@PID_27", entity.PID_27);
                cmd.Parameters.AddWithValue("@PID_28", entity.PID_28);
                cmd.Parameters.AddWithValue("@PID_29", entity.PID_29);
                cmd.Parameters.AddWithValue("@PID_30", entity.PID_30);
                cmd.Parameters.AddWithValue("@PID_31", entity.PID_31);
                cmd.Parameters.AddWithValue("@PID_32", entity.PID_32);
                cmd.Parameters.AddWithValue("@PID_33", entity.PID_33);
                cmd.Parameters.AddWithValue("@PID_34", entity.PID_34);
                cmd.Parameters.AddWithValue("@PID_35", entity.PID_35);
                cmd.Parameters.AddWithValue("@PID_36", entity.PID_36);
                cmd.Parameters.AddWithValue("@PID_37", entity.PID_37);
                cmd.Parameters.AddWithValue("@PID_38", entity.PID_38);
                cmd.Parameters.AddWithValue("@PID_39", entity.PID_39);
                cmd.Parameters.AddWithValue("@PID_40", entity.PID_40);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_PID SET ";
            SQL += "dbo.HL7_PID.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_PID.SET_CODE =@SET_CODE ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}