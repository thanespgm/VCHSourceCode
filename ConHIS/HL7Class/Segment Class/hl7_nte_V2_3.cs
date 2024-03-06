using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class hl7_nte_V2_3
    {
        private string nTE_KEY;
        private string nTE_1;
        private string nTE_2;
        private string nTE_3;
        private string sET_CODE;
        private int sTATUS;
        private string eVEN;

        private string Insert;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string NTE_KEY { get => nTE_KEY; set => nTE_KEY = value; }
        public string NTE_1 { get => nTE_1; set => nTE_1 = value; }
        public string NTE_2 { get => nTE_2; set => nTE_2 = value; }
        public string NTE_3 { get => nTE_3; set => nTE_3 = value; }
        public int STATUS { get => sTATUS; set => sTATUS = value; }
        public string EVEN { get => eVEN; set => eVEN = value; }

        public hl7_nte_V2_3()
        {
            Insert = InsertNTE();
        }

        private string InsertNTE()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_NTE( ";
            //SQL += "dbo.HL7_NTE.NTE_KEY,";
            SQL += "dbo.HL7_NTE.SET_CODE,";
            SQL += "dbo.HL7_NTE.NTE_1,";
            SQL += "dbo.HL7_NTE.NTE_2,";
            SQL += "dbo.HL7_NTE.NTE_3,";
            SQL += "dbo.HL7_NTE.EVEN) ";
            SQL += "VALUES(";
            //SQL += "@NTE_KEY,";
            SQL += "@SET_CODE,";
            SQL += "@NTE_1,";
            SQL += "@NTE_2,";
            SQL += "@NTE_3,";
            SQL += "@EVEN)";
            return SQL;
        }

        public DataSet SelectNTE(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_NTE.NTE_KEY,";
            SQL += "dbo.HL7_NTE.SET_CODE,";
            SQL += "dbo.HL7_NTE.NTE_1,";
            SQL += "dbo.HL7_NTE.NTE_2,";
            SQL += "dbo.HL7_NTE.NTE_3 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_NTE ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_NTE.SET_CODE =@SET_CODE ";
            SQL += "AND ";
            SQL += "dbo.HL7_NTE.STATUS = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(hl7_nte_V2_3 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(Insert))
            {
                //cmd.Parameters.AddWithValue("@NTE_KEY", entity.NTE_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@NTE_1", entity.NTE_1);
                cmd.Parameters.AddWithValue("@NTE_2", entity.NTE_2);
                cmd.Parameters.AddWithValue("@NTE_3", entity.NTE_3);
                cmd.Parameters.AddWithValue("@EVEN", entity.EVEN);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatus(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "UPDATE dbo.HL7_NTE SET ";
            SQL += "dbo.HL7_NTE.STATUS = 1 ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_NTE.SET_CODE =@SET_CODE ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}