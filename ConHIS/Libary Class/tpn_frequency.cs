using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class tpn_frequency
    {
        private string tcode;
        private string tcounter;

        public string Tcode { get => tcode; set => tcode = value; }
        public string Tcounter { get => tcounter; set => tcounter = value; }

        public tpn_frequency()
        {
        }

        public string Select(string SetCode)
        {
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBhost);
            string SQL = "";
            SQL += "SELECT ";
            SQL += "dbo.tpn_frequency.t_frequencycounter ";
            SQL += "FROM ";
            SQL += "dbo.tpn_frequency ";
            SQL += "WHERE ";
            SQL += "dbo.tpn_frequency.t_frequencycode =@t_frequencycode ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@t_frequencycode", SetCode);
                return (string)conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}