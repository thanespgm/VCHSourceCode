using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class hl7_pv1_V2_3
    {
        private string pV1_KEY;
        private string pV1_1;
        private string pV1_2;
        private string pV1_3;
        private string pV1_4;
        private string pV1_5;
        private string pV1_6;
        private string pV1_7;
        private string pV1_8;
        private string pV1_9;
        private string pV1_10;
        private string pV1_11;
        private string pV1_12;
        private string pV1_13;
        private string pV1_14;
        private string pV1_15;
        private string pV1_16;
        private string pV1_17;
        private string pV1_18;
        private string pV1_19;
        private string pV1_20;
        private string pV1_21;
        private string pV1_22;
        private string pV1_23;
        private string pV1_24;
        private string pV1_25;
        private string pV1_26;
        private string pV1_27;
        private string pV1_28;
        private string pV1_29;
        private string pV1_30;
        private string pV1_31;
        private string pV1_32;
        private string pV1_33;
        private string pV1_34;
        private string pV1_35;
        private string pV1_36;
        private string pV1_37;
        private string pV1_38;
        private string pV1_39;
        private string pV1_40;
        private string pV1_41;
        private string pV1_42;
        private string pV1_43;
        private string pV1_44;
        private string pV1_45;
        private string pV1_46;
        private string pV1_47;
        private string pV1_48;
        private string pV1_49;
        private string pV1_50;
        private string pV1_51;
        private string pV1_52;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;

        private string Insert;

        //Properties

        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }
        public string PV1_KEY { get => pV1_KEY; set => pV1_KEY = value; }
        public string PV1_1 { get => pV1_1; set => pV1_1 = value; }
        public string PV1_2 { get => pV1_2; set => pV1_2 = value; }
        public string PV1_3 { get => pV1_3; set => pV1_3 = value; }
        public string PV1_4 { get => pV1_4; set => pV1_4 = value; }
        public string PV1_5 { get => pV1_5; set => pV1_5 = value; }
        public string PV1_6 { get => pV1_6; set => pV1_6 = value; }
        public string PV1_7 { get => pV1_7; set => pV1_7 = value; }
        public string PV1_8 { get => pV1_8; set => pV1_8 = value; }
        public string PV1_9 { get => pV1_9; set => pV1_9 = value; }
        public string PV1_10 { get => pV1_10; set => pV1_10 = value; }
        public string PV1_11 { get => pV1_11; set => pV1_11 = value; }
        public string PV1_12 { get => pV1_12; set => pV1_12 = value; }
        public string PV1_13 { get => pV1_13; set => pV1_13 = value; }
        public string PV1_14 { get => pV1_14; set => pV1_14 = value; }
        public string PV1_15 { get => pV1_15; set => pV1_15 = value; }
        public string PV1_16 { get => pV1_16; set => pV1_16 = value; }
        public string PV1_17 { get => pV1_17; set => pV1_17 = value; }
        public string PV1_18 { get => pV1_18; set => pV1_18 = value; }
        public string PV1_19 { get => pV1_19; set => pV1_19 = value; }
        public string PV1_20 { get => pV1_20; set => pV1_20 = value; }
        public string PV1_21 { get => pV1_21; set => pV1_21 = value; }
        public string PV1_22 { get => pV1_22; set => pV1_22 = value; }
        public string PV1_23 { get => pV1_23; set => pV1_23 = value; }
        public string PV1_24 { get => pV1_24; set => pV1_24 = value; }
        public string PV1_25 { get => pV1_25; set => pV1_25 = value; }
        public string PV1_26 { get => pV1_26; set => pV1_26 = value; }
        public string PV1_27 { get => pV1_27; set => pV1_27 = value; }
        public string PV1_28 { get => pV1_28; set => pV1_28 = value; }
        public string PV1_29 { get => pV1_29; set => pV1_29 = value; }
        public string PV1_30 { get => pV1_30; set => pV1_30 = value; }
        public string PV1_31 { get => pV1_31; set => pV1_31 = value; }
        public string PV1_32 { get => pV1_32; set => pV1_32 = value; }
        public string PV1_33 { get => pV1_33; set => pV1_33 = value; }
        public string PV1_34 { get => pV1_34; set => pV1_34 = value; }
        public string PV1_35 { get => pV1_35; set => pV1_35 = value; }
        public string PV1_36 { get => pV1_36; set => pV1_36 = value; }
        public string PV1_37 { get => pV1_37; set => pV1_37 = value; }
        public string PV1_38 { get => pV1_38; set => pV1_38 = value; }
        public string PV1_39 { get => pV1_39; set => pV1_39 = value; }
        public string PV1_40 { get => pV1_40; set => pV1_40 = value; }
        public string PV1_41 { get => pV1_41; set => pV1_41 = value; }
        public string PV1_42 { get => pV1_42; set => pV1_42 = value; }
        public string PV1_43 { get => pV1_43; set => pV1_43 = value; }
        public string PV1_44 { get => pV1_44; set => pV1_44 = value; }
        public string PV1_45 { get => pV1_45; set => pV1_45 = value; }
        public string PV1_46 { get => pV1_46; set => pV1_46 = value; }
        public string PV1_47 { get => pV1_47; set => pV1_47 = value; }
        public string PV1_48 { get => pV1_48; set => pV1_48 = value; }
        public string PV1_49 { get => pV1_49; set => pV1_49 = value; }
        public string PV1_50 { get => pV1_50; set => pV1_50 = value; }
        public string PV1_51 { get => pV1_51; set => pV1_51 = value; }
        public string PV1_52 { get => pV1_52; set => pV1_52 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }

        public hl7_pv1_V2_3()
        {
            Insert = InsertPV1();
        }

        private string InsertPV1()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_PV1( ";
            //SQL += "dbo.HL7_PV1.PV1_KEY,";
            SQL += "dbo.HL7_PV1.SET_CODE,";
            SQL += "dbo.HL7_PV1.PV1_1,";
            SQL += "dbo.HL7_PV1.PV1_2,";
            SQL += "dbo.HL7_PV1.PV1_3,";
            SQL += "dbo.HL7_PV1.PV1_4,";
            SQL += "dbo.HL7_PV1.PV1_5,";
            SQL += "dbo.HL7_PV1.PV1_6,";
            SQL += "dbo.HL7_PV1.PV1_7,";
            SQL += "dbo.HL7_PV1.PV1_8,";
            SQL += "dbo.HL7_PV1.PV1_9,";
            SQL += "dbo.HL7_PV1.PV1_10,";
            SQL += "dbo.HL7_PV1.PV1_11,";
            SQL += "dbo.HL7_PV1.PV1_12,";
            SQL += "dbo.HL7_PV1.PV1_13,";
            SQL += "dbo.HL7_PV1.PV1_14,";
            SQL += "dbo.HL7_PV1.PV1_15,";
            SQL += "dbo.HL7_PV1.PV1_16,";
            SQL += "dbo.HL7_PV1.PV1_17,";
            SQL += "dbo.HL7_PV1.PV1_18,";
            SQL += "dbo.HL7_PV1.PV1_19,";
            SQL += "dbo.HL7_PV1.PV1_20,";
            SQL += "dbo.HL7_PV1.PV1_21,";
            SQL += "dbo.HL7_PV1.PV1_22,";
            SQL += "dbo.HL7_PV1.PV1_23,";
            SQL += "dbo.HL7_PV1.PV1_24,";
            SQL += "dbo.HL7_PV1.PV1_25,";
            SQL += "dbo.HL7_PV1.PV1_26,";
            SQL += "dbo.HL7_PV1.PV1_27,";
            SQL += "dbo.HL7_PV1.PV1_28,";
            SQL += "dbo.HL7_PV1.PV1_29,";
            SQL += "dbo.HL7_PV1.PV1_30,";
            SQL += "dbo.HL7_PV1.PV1_31,";
            SQL += "dbo.HL7_PV1.PV1_32,";
            SQL += "dbo.HL7_PV1.PV1_33,";
            SQL += "dbo.HL7_PV1.PV1_34,";
            SQL += "dbo.HL7_PV1.PV1_35,";
            SQL += "dbo.HL7_PV1.PV1_36,";
            SQL += "dbo.HL7_PV1.PV1_37,";
            SQL += "dbo.HL7_PV1.PV1_38,";
            SQL += "dbo.HL7_PV1.PV1_39,";
            SQL += "dbo.HL7_PV1.PV1_40,";
            SQL += "dbo.HL7_PV1.PV1_41,";
            SQL += "dbo.HL7_PV1.PV1_42,";
            SQL += "dbo.HL7_PV1.PV1_43,";
            SQL += "dbo.HL7_PV1.PV1_44,";
            SQL += "dbo.HL7_PV1.PV1_45,";
            SQL += "dbo.HL7_PV1.PV1_46,";
            SQL += "dbo.HL7_PV1.PV1_47,";
            SQL += "dbo.HL7_PV1.PV1_48,";
            SQL += "dbo.HL7_PV1.PV1_49,";
            SQL += "dbo.HL7_PV1.PV1_50,";
            SQL += "dbo.HL7_PV1.PV1_51,";
            SQL += "dbo.HL7_PV1.EVEN) ";
            //SQL += "dbo.HL7_PV1.PV1_52) ";
            SQL += "VALUES(";
            //SQL += "@PV1_KEY,";
            SQL += "@SET_CODE,";
            SQL += "@PV1_1,";
            SQL += "@PV1_2,";
            SQL += "@PV1_3,";
            SQL += "@PV1_4,";
            SQL += "@PV1_5,";
            SQL += "@PV1_6,";
            SQL += "@PV1_7,";
            SQL += "@PV1_8,";
            SQL += "@PV1_9,";
            SQL += "@PV1_10,";
            SQL += "@PV1_11,";
            SQL += "@PV1_12,";
            SQL += "@PV1_13,";
            SQL += "@PV1_14,";
            SQL += "@PV1_15,";
            SQL += "@PV1_16,";
            SQL += "@PV1_17,";
            SQL += "@PV1_18,";
            SQL += "@PV1_19,";
            SQL += "@PV1_20,";
            SQL += "@PV1_21,";
            SQL += "@PV1_22,";
            SQL += "@PV1_23,";
            SQL += "@PV1_24,";
            SQL += "@PV1_25,";
            SQL += "@PV1_26,";
            SQL += "@PV1_27,";
            SQL += "@PV1_28,";
            SQL += "@PV1_29,";
            SQL += "@PV1_30,";
            SQL += "@PV1_31,";
            SQL += "@PV1_32,";
            SQL += "@PV1_33,";
            SQL += "@PV1_34,";
            SQL += "@PV1_35,";
            SQL += "@PV1_36,";
            SQL += "@PV1_37,";
            SQL += "@PV1_38,";
            SQL += "@PV1_39,";
            SQL += "@PV1_40,";
            SQL += "@PV1_41,";
            SQL += "@PV1_42,";
            SQL += "@PV1_43,";
            SQL += "@PV1_44,";
            SQL += "@PV1_45,";
            SQL += "@PV1_46,";
            SQL += "@PV1_47,";
            SQL += "@PV1_48,";
            SQL += "@PV1_49,";
            SQL += "@PV1_20,";
            SQL += "@PV1_51,";
            SQL += "@EVEN)";
            //SQL += "@PV1_52)";
            return SQL;
        }

        public DataSet SelectPV1(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_PV1.PV1_KEY,";
            SQL += "dbo.HL7_PV1.SET_CODE,";
            SQL += "dbo.HL7_PV1.PV1_1,";
            SQL += "dbo.HL7_PV1.PV1_2,";
            SQL += "dbo.HL7_PV1.PV1_3,";
            SQL += "dbo.HL7_PV1.PV1_4,";
            SQL += "dbo.HL7_PV1.PV1_5,";
            SQL += "dbo.HL7_PV1.PV1_6,";
            SQL += "dbo.HL7_PV1.PV1_7,";
            SQL += "dbo.HL7_PV1.PV1_8,";
            SQL += "dbo.HL7_PV1.PV1_9,";
            SQL += "dbo.HL7_PV1.PV1_10,";
            SQL += "dbo.HL7_PV1.PV1_11,";
            SQL += "dbo.HL7_PV1.PV1_12,";
            SQL += "dbo.HL7_PV1.PV1_13,";
            SQL += "dbo.HL7_PV1.PV1_14,";
            SQL += "dbo.HL7_PV1.PV1_15,";
            SQL += "dbo.HL7_PV1.PV1_16,";
            SQL += "dbo.HL7_PV1.PV1_17,";
            SQL += "dbo.HL7_PV1.PV1_18,";
            SQL += "dbo.HL7_PV1.PV1_19,";
            SQL += "dbo.HL7_PV1.PV1_20,";
            SQL += "dbo.HL7_PV1.PV1_21,";
            SQL += "dbo.HL7_PV1.PV1_22,";
            SQL += "dbo.HL7_PV1.PV1_23,";
            SQL += "dbo.HL7_PV1.PV1_24,";
            SQL += "dbo.HL7_PV1.PV1_25,";
            SQL += "dbo.HL7_PV1.PV1_26,";
            SQL += "dbo.HL7_PV1.PV1_27,";
            SQL += "dbo.HL7_PV1.PV1_28,";
            SQL += "dbo.HL7_PV1.PV1_29,";
            SQL += "dbo.HL7_PV1.PV1_30,";
            SQL += "dbo.HL7_PV1.PV1_31,";
            SQL += "dbo.HL7_PV1.PV1_32,";
            SQL += "dbo.HL7_PV1.PV1_33,";
            SQL += "dbo.HL7_PV1.PV1_34,";
            SQL += "dbo.HL7_PV1.PV1_35,";
            SQL += "dbo.HL7_PV1.PV1_36,";
            SQL += "dbo.HL7_PV1.PV1_37,";
            SQL += "dbo.HL7_PV1.PV1_38,";
            SQL += "dbo.HL7_PV1.PV1_39,";
            SQL += "dbo.HL7_PV1.PV1_40,";
            SQL += "dbo.HL7_PV1.PV1_41,";
            SQL += "dbo.HL7_PV1.PV1_42,";
            SQL += "dbo.HL7_PV1.PV1_43,";
            SQL += "dbo.HL7_PV1.PV1_44,";
            SQL += "dbo.HL7_PV1.PV1_45,";
            SQL += "dbo.HL7_PV1.PV1_46,";
            SQL += "dbo.HL7_PV1.PV1_47,";
            SQL += "dbo.HL7_PV1.PV1_48,";
            SQL += "dbo.HL7_PV1.PV1_49,";
            SQL += "dbo.HL7_PV1.PV1_50,";
            SQL += "dbo.HL7_PV1.PV1_51 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_PV1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_PV1.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_PV1.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(hl7_pv1_V2_3 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(Insert))
            {
                //cmd.Parameters.AddWithValue("PV1_KEY", entity.PV1_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@PV1_1", entity.PV1_1);
                cmd.Parameters.AddWithValue("@PV1_2", entity.PV1_2);
                cmd.Parameters.AddWithValue("@PV1_3", entity.PV1_3);
                cmd.Parameters.AddWithValue("@PV1_4", entity.PV1_4);
                cmd.Parameters.AddWithValue("@PV1_5", entity.PV1_5);
                cmd.Parameters.AddWithValue("@PV1_6", entity.PV1_6);
                cmd.Parameters.AddWithValue("@PV1_7", entity.PV1_7);
                cmd.Parameters.AddWithValue("@PV1_8", entity.PV1_8);
                cmd.Parameters.AddWithValue("@PV1_9", entity.PV1_9);
                cmd.Parameters.AddWithValue("@PV1_10", entity.PV1_10);
                cmd.Parameters.AddWithValue("@PV1_11", entity.PV1_11);
                cmd.Parameters.AddWithValue("@PV1_12", entity.PV1_12);
                cmd.Parameters.AddWithValue("@PV1_13", entity.PV1_13);
                cmd.Parameters.AddWithValue("@PV1_14", entity.PV1_14);
                cmd.Parameters.AddWithValue("@PV1_15", entity.PV1_15);
                cmd.Parameters.AddWithValue("@PV1_16", entity.PV1_16);
                cmd.Parameters.AddWithValue("@PV1_17", entity.PV1_17);
                cmd.Parameters.AddWithValue("@PV1_18", entity.PV1_18);
                cmd.Parameters.AddWithValue("@PV1_19", entity.PV1_19);
                cmd.Parameters.AddWithValue("@PV1_20", entity.PV1_20);
                cmd.Parameters.AddWithValue("@PV1_21", entity.PV1_21);
                cmd.Parameters.AddWithValue("@PV1_22", entity.PV1_22);
                cmd.Parameters.AddWithValue("@PV1_23", entity.PV1_23);
                cmd.Parameters.AddWithValue("@PV1_24", entity.PV1_24);
                cmd.Parameters.AddWithValue("@PV1_25", entity.PV1_25);
                cmd.Parameters.AddWithValue("@PV1_26", entity.PV1_26);
                cmd.Parameters.AddWithValue("@PV1_27", entity.PV1_27);
                cmd.Parameters.AddWithValue("@PV1_28", entity.PV1_28);
                cmd.Parameters.AddWithValue("@PV1_29", entity.PV1_29);
                cmd.Parameters.AddWithValue("@PV1_30", entity.PV1_30);
                cmd.Parameters.AddWithValue("@PV1_31", entity.PV1_31);
                cmd.Parameters.AddWithValue("@PV1_32", entity.PV1_32);
                cmd.Parameters.AddWithValue("@PV1_33", entity.PV1_33);
                cmd.Parameters.AddWithValue("@PV1_34", entity.PV1_34);
                cmd.Parameters.AddWithValue("@PV1_35", entity.PV1_35);
                cmd.Parameters.AddWithValue("@PV1_36", entity.PV1_36);
                cmd.Parameters.AddWithValue("@PV1_37", entity.PV1_37);
                cmd.Parameters.AddWithValue("@PV1_38", entity.PV1_38);
                cmd.Parameters.AddWithValue("@PV1_39", entity.PV1_39);
                cmd.Parameters.AddWithValue("@PV1_40", entity.PV1_40);
                cmd.Parameters.AddWithValue("@PV1_41", entity.PV1_41);
                cmd.Parameters.AddWithValue("@PV1_42", entity.PV1_42);
                cmd.Parameters.AddWithValue("@PV1_43", entity.PV1_43);
                cmd.Parameters.AddWithValue("@PV1_44", entity.PV1_44);
                cmd.Parameters.AddWithValue("@PV1_45", entity.PV1_45);
                cmd.Parameters.AddWithValue("@PV1_46", entity.PV1_46);
                cmd.Parameters.AddWithValue("@PV1_47", entity.PV1_47);
                cmd.Parameters.AddWithValue("@PV1_48", entity.PV1_48);
                cmd.Parameters.AddWithValue("@PV1_49", entity.PV1_49);
                cmd.Parameters.AddWithValue("@PV1_50", entity.PV1_50);
                cmd.Parameters.AddWithValue("@PV1_51", entity.PV1_51);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                //cmd.Parameters.AddWithValue("@PV1_52", entity.PV1_52);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_PV1 SET ";
            SQL += "dbo.HL7_PV1.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_PV1.SET_CODE =@SET_CODE ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}