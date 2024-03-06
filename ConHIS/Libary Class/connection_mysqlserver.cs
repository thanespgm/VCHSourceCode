using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace ConHIS.Libary_Class
{
    internal class Connection_mysqlserver
    {
        //Filed And Properties
        private System_logfile logs = new System_logfile();

        protected string _connectionstring;

        public string ConnectSever
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
        }

        //Constructor And Abstract Class

        public Connection_mysqlserver(string dbconnect)
        {
            this._connectionstring = dbconnect;
        }

        //Function Check Connection Status
        public bool ConnStatus()
        {
            bool result = false;
            MySqlConnection sqlConnection = new MySqlConnection(_connectionstring);
            try
            {
                sqlConnection.Open();
                result = true;
            }
            catch (MySqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " MySQL Error");
                result = false;
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return result;
        }

        //Function Command Fill data
        //retrun type Dataset
        public DataSet FillMYSQL(MySqlCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                command.Connection = new MySqlConnection(_connectionstring);
                command.Connection.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(command))
                {
                    if (ds != null)
                    {
                        ds.Clear();
                    }
                    da.Fill(ds);
                }
            }
            catch (MySqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " MySQL Error");
            }
            finally
            {
                command.Connection.Close();
                command.Connection.Dispose();
            }
            return ds;
        }

        //Function Command ExecuteNonQuery Data [Insert Update Delete]
        //retrun type boolean
        public bool ExecuteNonQueryMySQL(MySqlCommand command)
        {
            bool result = false;
            StringBuilder errorMessages = new StringBuilder();
            using (MySqlConnection conn = new MySqlConnection(_connectionstring))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    command.ExecuteNonQuery();
                    result = true;
                    trans.Commit();
                }
                catch (MySqlException ex)
                {
                    logs.Writelogfile(ex.ToString(), " MySQL Error");
                    trans.Rollback();
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        //Function Command ExecuteScalar Data [Query Select]
        //Return type [Objects]

        public object ExecuteScalarMySQL(MySqlCommand command)
        {
            object result = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionstring))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    result = command.ExecuteScalar();
                    trans.Commit();
                }
                catch (MySqlException ex)
                {
                    trans.Rollback();
                    logs.Writelogfile(ex.ToString(), " MySQL Error");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }
    }
}