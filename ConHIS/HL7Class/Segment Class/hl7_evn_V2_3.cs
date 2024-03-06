using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class hl7_evn_V2_3
    {
        private string eVN_KEY;
        private string eVN_1;
        private string eVN_2;
        private string eVN_3;
        private string eVN_4;
        private string eVN_5;
        private string sET_CODE;

        private string Insert;

        //Properties
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public string EVN_KEY { get => eVN_KEY; set => eVN_KEY = value; }
        public string EVN_1 { get => eVN_1; set => eVN_1 = value; }
        public string EVN_2 { get => eVN_2; set => eVN_2 = value; }
        public string EVN_3 { get => eVN_3; set => eVN_3 = value; }
        public string EVN_4 { get => eVN_4; set => eVN_4 = value; }
        public string EVN_5 { get => eVN_5; set => eVN_5 = value; }

        public hl7_evn_V2_3()
        {
            Insert = InsertEVN();
        }

        private string InsertEVN()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_EVN( ";
            //SQL += "dbo.HL7_EVN.EVN_KEY,";
            SQL += "dbo.HL7_EVN.SET_CODE,";
            SQL += "dbo.HL7_EVN.EVN_1,";
            SQL += "dbo.HL7_EVN.EVN_2,";
            SQL += "dbo.HL7_EVN.EVN_3,";
            SQL += "dbo.HL7_EVN.EVN_4,";
            SQL += "dbo.HL7_EVN.EVN_5)";
            SQL += "VALUES(";
            //SQL += "@EVN_KEY,";
            SQL += "@SET_CODE,";
            SQL += "@EVN_1,";
            SQL += "@EVN_2,";
            SQL += "@EVN_3,";
            SQL += "@EVN_4,";
            SQL += "@EVN_5)";
            return SQL;
        }

        public DataSet SelectEVN(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.HL7_EVN.EVN_KEY,";
            SQL += "dbo.HL7_EVN.SET_CODE,";
            SQL += "dbo.HL7_EVN.EVN_1,";
            SQL += "dbo.HL7_EVN.EVN_2,";
            SQL += "dbo.HL7_EVN.EVN_3,";
            SQL += "dbo.HL7_EVN.EVN_4,";
            SQL += "dbo.HL7_EVN.EVN_5 ";
            SQL += "FROM ";
            SQL += "dbo.HL7_EVN ";
            SQL += "WHERE ";
            SQL += "dbo.HL7_EVN.SET_CODE =@SET_CODE ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@SET_CODE", SetCode);
                return conn.FillSQL(cmd);
            }
        }

        public bool Add(hl7_evn_V2_3 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(Insert))
            {
                //cmd.Parameters.AddWithValue("@EVN_KEY", entity.EVN_KEY);
                cmd.Parameters.AddWithValue("@SET_CODE", entity.SET_CODE);
                cmd.Parameters.AddWithValue("@EVN_1", entity.EVN_1);
                cmd.Parameters.AddWithValue("@EVN_2", entity.EVN_2);
                cmd.Parameters.AddWithValue("@EVN_3", entity.EVN_3);
                cmd.Parameters.AddWithValue("@EVN_4", entity.EVN_4);
                cmd.Parameters.AddWithValue("@EVN_5", entity.EVN_5);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}