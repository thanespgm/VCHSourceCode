using System;
using System.IO;
using System.Text;

namespace ConHIS
{
    internal class Server_config
    {
        //filed and properties
        private static string _connectionLocal;

        public string ConnectionLocal
        {
            get { return _connectionLocal; }
            set { _connectionLocal = value; }
        }

        private static string _connectionHis;

        public string ConnectionHIS
        {
            get { return _connectionHis; }
            set { _connectionHis = value; }
        }

        //------------------------------------DataBase Local For ConHIS Program--------------------------------------------------
        protected static string _stlocal;

        public string StatusLocal
        {
            get { return _stlocal; }
            set { _stlocal = value; }
        }

        protected static string _servername_local;

        public string ServerNameLocal
        {
            get { return _servername_local; }
            set { _servername_local = value; }
        }

        protected static string _databasename_local;

        public string DatabaseLocal
        {
            get { return _databasename_local; }
            set { _databasename_local = value; }
        }

        protected static string _dbusername_local;

        public string UserNameLocal
        {
            get { return _dbusername_local; }
            set { _dbusername_local = value; }
        }

        protected static string _dbpassword_local;

        public string PassWordLocal
        {
            get { return _dbpassword_local; }
            set { _dbpassword_local = value; }
        }

        protected static string _dbAsynchronous_local;

        public string AsynchronousLocal
        {
            get { return _dbAsynchronous_local; }
            set { _dbAsynchronous_local = value; }
        }

        protected static string _dbconnecttimeout_local;

        public string ConnectTimeOutLocal
        {
            get { return _dbconnecttimeout_local; }
            set { _dbconnecttimeout_local = value; }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        private static string _sthost;

        private static string _servername_host;
        private static string _databasename_host;
        private static string _dbusername_host;
        private static string _dbpassword_host;
        private static string _dbAsynchronous_host;
        private static string _dbconnecttimeout_host;

        //Read the database configuration file.
        //The address of the file is in the [config] folder and the file name [database_config.ini.]
        public bool Readdatabase_config()
        {
            bool result = false;
            string urlconfig = "config/database_config.ini";
            string strdata = null;
            try
            {
                if (File.Exists(urlconfig))
                {
                    using (FileStream fs = new FileStream(urlconfig, FileMode.Open))
                    {
                        StreamReader sr = new StreamReader(fs, UnicodeEncoding.Default);
                        strdata = sr.ReadToEnd().ToString();

                        //Read the configuration file to connect to Local.
                        strdata = strdata.Replace("=================================================\r\n[============Database For ConHIS Program========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Connection status]=", "");
                        _stlocal = strdata.Split(';').GetValue(0).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Server Name]=", "");
                        _servername_local = strdata.Split(';').GetValue(1).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Database Name]=", "");
                        _databasename_local = strdata.Split(';').GetValue(2).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Username]=", "");
                        _dbusername_local = strdata.Split(';').GetValue(3).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Password]=", "");
                        _dbpassword_local = strdata.Split(';').GetValue(4).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Asynchronous Processing]=", "");
                        _dbAsynchronous_local = strdata.Split(';').GetValue(5).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Connect Timeout]=", "");
                        _dbconnecttimeout_local = strdata.Split(';').GetValue(6).ToString().Trim();

                        if ((_stlocal == "True") || (_stlocal == "true"))
                        {
                            // Windows Authentication
                            if (((_dbusername_local == "null") && (_dbpassword_local == "null")) || ((_dbusername_local == "Null") && (_dbpassword_local == "Null")) || ((_dbusername_local == "NULL") && (_dbpassword_local == "NULL")))
                            {
                                _connectionLocal = "Data Source=" + _servername_local + ";Initial Catalog=" + _databasename_local + ";Integrated Security=True;Asynchronous Processing=" + _dbAsynchronous_local + ";Connect Timeout=" + _dbconnecttimeout_local;
                            }
                            // SQL Server Authentication
                            else
                            {
                                _connectionLocal = "Data Source=" + _servername_local + ";Initial Catalog=" + _databasename_local + ";;Persist Security Info=True;User ID=" + _dbusername_local + ";Password=" + _dbpassword_local + ";Asynchronous Processing=" + _dbAsynchronous_local + ";Connect Timeout=" + _dbconnecttimeout_local + ";";
                            }
                        }
                        result = true;
                    }
                }
            }
            catch (IOException ex)
            {
                result = false;
                throw new IOException(ex.Message);
            }
            return result;
        }

        public bool Readdatabase_HIS_config()
        {
            bool result = false;
            string urlconfig = "config/database_config.ini";
            string strdata = null;
            try
            {
                if (File.Exists(urlconfig))
                {
                    using (FileStream fs = new FileStream(urlconfig, FileMode.Open))
                    {
                        StreamReader sr = new StreamReader(fs, UnicodeEncoding.Default);
                        strdata = sr.ReadToEnd().ToString();
                        //Read the configuration file to connect to HIS.
                        strdata = strdata.Replace("=================================================\r\n[============Database For HIS Interface=========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Connection status]=", "");
                        _sthost = strdata.Split(';').GetValue(7).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Server Name]=", "");
                        _servername_host = strdata.Split(';').GetValue(8).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Database Name]=", "");
                        _databasename_host = strdata.Split(';').GetValue(9).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Username]=", "");
                        _dbusername_host = strdata.Split(';').GetValue(10).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Password]=", "");
                        _dbpassword_host = strdata.Split(';').GetValue(11).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Asynchronous Processing]=", "");
                        _dbAsynchronous_host = strdata.Split(';').GetValue(12).ToString().Trim();
                        strdata = strdata.Replace("\r\n[Connect Timeout]=", "");
                        _dbconnecttimeout_host = strdata.Split(';').GetValue(13).ToString().Trim();

                        if ((_sthost == "True") || (_sthost == "true"))
                        {
                            // Windows Authentication
                            if (((_dbusername_host == "null") && (_dbpassword_host == "null")) || ((_dbusername_host == "Null") && (_dbpassword_host == "Null")) || ((_dbusername_host == "NULL") && (_dbpassword_host == "NULL")))
                            {
                                _connectionHis = "Data Source=" + _servername_host + ";Initial Catalog=" + _databasename_host + ";Integrated Security=True;Asynchronous Processing=" + _dbAsynchronous_host + ";Connect Timeout=" + _dbconnecttimeout_host;
                            }
                            // SQL Server Authentication
                            else
                            {
                                _connectionHis = "Data Source=" + _servername_host + ";Initial Catalog=" + _databasename_host + ";;Persist Security Info=True;User ID=" + _dbusername_host + ";Password=" + _dbpassword_host + ";Asynchronous Processing=" + _dbAsynchronous_host + ";Connect Timeout=" + _dbconnecttimeout_host + ";";
                            }
                        }
                        result = true;
                    }
                }
            }
            catch (IOException ex)
            {
                result = false;
                throw new IOException(ex.Message);
            }
            return result;
        }

        //write the database configuration file.
        //The address of the file is in the [config] folder and the file name [database_config.ini.]
        public bool Writedatabase_Local_config()
        {
            bool result = false;
            string urlFolder = "config";
            string urlconfig = "config/database_config.ini";
            StreamWriter sw;
            string strdata = null;
            try
            {
                if (!Directory.Exists(urlFolder))
                {
                    Directory.CreateDirectory(urlFolder);
                }
                if (File.Exists(urlconfig))
                {
                    File.Delete(urlconfig);

                    //Read the configuration file to connect to Local.
                    strdata += "=================================================\r\n[============Database For ConHIS Program========]\r\n=================================================\r\n";
                    strdata += "[Connection status]=" + _stlocal + ";";
                    strdata += "\r\n[Server Name]=" + _servername_local + ";";
                    strdata += "\r\n[Database Name]=" + _databasename_local + ";";
                    strdata += "\r\n[Username]=" + _dbusername_local + ";";
                    strdata += "\r\n[Password]=" + _dbpassword_local + ";";
                    strdata += "\r\n[Asynchronous Processing]=" + _dbAsynchronous_local + ";";
                    strdata += "\r\n[Connect Timeout]=" + _dbconnecttimeout_local + ";";

                    sw = File.CreateText(urlconfig);
                    sw.Write(strdata);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                    result = true;
                }
            }
            catch (IOException ex)
            {
                result = false;
                throw new IOException(ex.Message);
            }
            return result;
        }

        //Check Dictory File Config.
        public bool CheckDictoryFileConfig()
        {
            bool result = false;
            try
            {
                string urlconfig = "config/database_config.ini";
                if (File.Exists(urlconfig))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
            return result;
        }
    }
}