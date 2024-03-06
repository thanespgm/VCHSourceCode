using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ConHIS.Libary_Class
{
    internal class Connection_pgsqlserver
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

        public Connection_pgsqlserver(string dbconnect)
        {
            this._connectionstring = dbconnect;
        }

        //Function Check Connection Status
        public bool ConnStatus()
        {
            bool result = false;
            NpgsqlConnection sqlConnection = new NpgsqlConnection(_connectionstring);
            try
            {
                sqlConnection.Open();
                result = true;
            }
            catch (NpgsqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " PGSQL Error");
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
        public DataSet FillPGSQL(NpgsqlCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                command.Connection = new NpgsqlConnection(_connectionstring);
                command.Connection.Open();

                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(command))
                {
                    if (ds != null)
                    {
                        ds.Clear();
                    }

                    //
                    //byte[]data = CompressDataSet(ds);
                    //ds = DecompressDataSet(data);

                    da.Fill(ds);
                }
            }
            catch (NpgsqlException ex)
            {
                logs.Writelogfile(ex.ToString(), " PGSQL Error");
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
        public bool ExecuteNonQueryPGSQL(NpgsqlCommand command)
        {
            bool result = false;
            StringBuilder errorMessages = new StringBuilder();
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionstring))
            {
                conn.Open();
                NpgsqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    command.ExecuteNonQuery();
                    trans.Commit();
                    result = true;
                }
                catch (NpgsqlException ex)
                {
                    logs.Writelogfile(ex.ToString(), " PGSQL Error");
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

        public object ExecuteScalarPGSQL(NpgsqlCommand command)
        {
            object result = null;
            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionstring))
            {
                conn.Open();
                NpgsqlTransaction trans = conn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    command.Connection = conn;
                    command.Transaction = trans;
                    result = command.ExecuteScalar();
                    trans.Commit();
                }
                catch (NpgsqlException ex)
                {
                    trans.Rollback();
                    logs.Writelogfile(ex.ToString(), " PGSQL Error");
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return result;
        }

        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //
        private byte[] CompressDataSet(DataSet ds)
        {
            byte[] buffer = null;
            if (ds != null)
            {
                ds.RemotingFormat = SerializationFormat.Binary;
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream();
                formatter.Serialize(serializationStream, ds);
                buffer = serializationStream.GetBuffer();
                //buffer = serializationStream.ToArray();
            }
            return buffer;
        }

        private DataSet DecompressDataSet(byte[] bytDs)
        {
            DataSet set = new DataSet();
            MemoryStream stream = new MemoryStream(bytDs);
            stream.Seek(0L, SeekOrigin.Begin);
            set.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter formatter = new BinaryFormatter();
            return (DataSet)formatter.Deserialize(stream, null);
        }

        internal static string Base64Decode(string data)
        {
            string str2;
            try
            {
                System.Text.Decoder decoder = new UTF8Encoding().GetDecoder();
                byte[] bytes = Convert.FromBase64String(data);
                char[] chars = new char[decoder.GetCharCount(bytes, 0, bytes.Length)];
                decoder.GetChars(bytes, 0, bytes.Length, chars, 0);
                string str = new string(chars);
                str2 = str;
            }
            catch (Exception exception)
            {
                throw new Exception("Error in base64Decode" + exception.Message);
            }
            return str2;
        }

        internal static string Base64Encode(string data)
        {
            string str2;
            try
            {
                //byte[] buffer = new byte[data.Length];
                str2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
            }
            catch (Exception exception)
            {
                throw new Exception("Error in base64Encode " + exception.Message);
            }
            return str2;
        }
    }
}