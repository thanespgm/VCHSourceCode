using System;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS
{
    internal class Connection_sqlserver
    {
        //Filed And Properties
        private readonly System_logfile logs = new System_logfile();

        protected string _connectionstring;

        public string ConnectSever
        {
            get { return _connectionstring; }
            set { _connectionstring = value; }
        }

        //Constructor And Abstract Class

        public Connection_sqlserver(string dbconnect)
        {
            this._connectionstring = dbconnect;
        }

        //Function Check Connection Status
        public bool ConnStatus()
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(_connectionstring);
            try
            {
                sqlConnection.Open();
                result = true;
            }
            catch (SqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " SQL Error");
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
        public DataSet FillSQL(SqlCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                command.Connection = new SqlConnection(_connectionstring);
                command.Connection.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    ds?.Clear();
                    da.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " SQL Error");
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
        public bool ExecuteNonQuerySQL(SqlCommand command)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    command.ExecuteNonQuery();
                    result = true;
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    result = false;
                    trans.Rollback();
                    throw new Exception(ex.Message);
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

        public object ExecuteScalarSQL(SqlCommand command)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(_connectionstring))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    result = command.ExecuteScalar();
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    logs.Writelogfile(ex.ToString(), " SQL Error");
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
    }
}