using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class hl7_al1_V2_3
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

        private string Insert;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        // public string AL1_KEY { get => aL1_KEY; set => aL1_KEY = value; }
        public string AL1_1 { get => aL1_1; set => aL1_1 = value; }

        public string AL1_2 { get => aL1_2; set => aL1_2 = value; }
        public string AL1_3 { get => aL1_3; set => aL1_3 = value; }
        public string AL1_4 { get => aL1_4; set => aL1_4 = value; }
        public string AL1_5 { get => aL1_5; set => aL1_5 = value; }
        public string AL1_6 { get => aL1_6; set => aL1_6 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }

        public hl7_al1_V2_3()
        {
            Insert = InsertAL1();
        }

        private string InsertAL1()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_AL1( ";
            //SQL += "dbo.HL7_AL1.AL1_KEY,";
            SQL += "dbo.HL7_AL1.SET_CODE,";
            SQL += "dbo.HL7_AL1.AL1_1,";
            SQL += "dbo.HL7_AL1.AL1_2,";
            SQL += "dbo.HL7_AL1.AL1_3,";
            SQL += "dbo.HL7_AL1.AL1_4,";
            SQL += "dbo.HL7_AL1.AL1_5,";
            SQL += "dbo.HL7_AL1.AL1_6,";
            SQL += "dbo.HL7_AL1.EVEN) ";
            SQL += "VALUES(";
            //SQL += "@AL1_KEY,";
            SQL += "@SET_CODE,";
            SQL += "@AL1_1,";
            SQL += "@AL1_2,";
            SQL += "@AL1_3,";
            SQL += "@AL1_4,";
            SQL += "@AL1_5,";
            SQL += "@AL1_6,";
            SQL += "@EVEN)";
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

        public bool Add(hl7_al1_V2_3 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(Insert))
            {
                //cmd.Parameters.AddWithValue("@AL1_KEY", entity.AL1_KEY);
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