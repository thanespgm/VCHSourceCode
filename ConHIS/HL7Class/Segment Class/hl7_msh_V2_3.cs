using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class hl7_msh_V2_3
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
        private string sET_CODE;

        private string Insert;

        //Properties
        public string MSH_KEY { get => mSH_KEY; set => mSH_KEY = value; }

        public string MSH_1 { get => mSH_1; set => mSH_1 = value; }
        public string MSH_2 { get => mSH_2; set => mSH_2 = value; }
        public string MSH_3 { get => mSH_3; set => mSH_3 = value; }
        public string MSH_4 { get => mSH_4; set => mSH_4 = value; }
        public string MSH_5 { get => mSH_5; set => mSH_5 = value; }
        public string MSH_6 { get => mSH_6; set => mSH_6 = value; }
        public string MSH_7 { get => mSH_7; set => mSH_7 = value; }
        public string MSH_8 { get => mSH_8; set => mSH_8 = value; }
        public string MSH_9 { get => mSH_9; set => mSH_9 = value; }
        public string MSH_10 { get => mSH_10; set => mSH_10 = value; }
        public string MSH_11 { get => mSH_11; set => mSH_11 = value; }
        public string SET_CODE { get => sET_CODE; set => sET_CODE = value; }

        public hl7_msh_V2_3()
        {
            Insert = InsertMSH();
        }

        private string InsertMSH()
        {
            string SQL = "";
            SQL += "INSERT INTO dbo.HL7_MSH( ";
            //SQL += "dbo.HL7_MSH.MSH_KEY,";
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
            SQL += "dbo.HL7_MSH.MSH_11) ";
            SQL += "VALUES(";
            //SQL += "@MSH_KEY,";
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
            SQL += "@MSH_11) ";
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
            SQL += "dbo.HL7_MSH.MSH_11 ";
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

        public bool Add(hl7_msh_V2_3 entity)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);

            using (SqlCommand cmd = new SqlCommand(Insert))
            {
                //cmd.Parameters.AddWithValue("@MSH_KEY", entity.MSH_KEY);
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
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}