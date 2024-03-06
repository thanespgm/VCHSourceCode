using System;
using System.IO;
using System.Text;

namespace ConHIS
{
    internal class Pathfile_config
    {
        //filed and properties
        protected string _pathFileLocal;

        public string PathFileLocal
        {
            get { return _pathFileLocal; }
            set { _pathFileLocal = value; }
        }

        protected string _pathFileHost;

        public string PathFileHost
        {
            get { return _pathFileHost; }
            set { _pathFileHost = value; }
        }

        protected string _pathLogFile;

        public string PathLogFile
        {
            get { return _pathLogFile; }
            set { _pathLogFile = value; }
        }

        protected string _pathProgramBackup;

        public string PathProgramBackUp
        {
            get { return _pathProgramBackup; }
            set { _pathProgramBackup = value; }
        }

        protected string _pathDatabaseBackup;

        public string PathDatabaseBackUp
        {
            get { return _pathDatabaseBackup; }
            set { _pathDatabaseBackup = value; }
        }

        //Read the path file configuration file.
        //The address of the file is in the [config] folder and the file name [Pathfile_config.ini.]
        public bool ReadPathfile_config()
        {
            bool result = false;
            string urlconfig = "config/Pathfile_config.ini";
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
                        strdata = strdata.Replace("=================================================\r\n[============PathFile For ConHIS Program========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Destination Path]=", "");
                        _pathFileLocal = strdata.Split(';').GetValue(0).ToString().Trim();
                        //Read the configuration file to connect to HIS.
                        strdata = strdata.Replace("=================================================\r\n[============PathFile For HIS Interface=========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Source Path]=", "");
                        _pathFileHost = strdata.Split(';').GetValue(1).ToString().Trim();
                        //Read the configuration file to Write logfile to Folder.
                        strdata = strdata.Replace("=================================================\r\n[===========PathFile For Write System Log=======]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Logfile Path]=", "");
                        _pathLogFile = strdata.Split(';').GetValue(2).ToString().Trim();
                        //Read the configuration file to program backup.
                        strdata = strdata.Replace("=================================================\r\n[===========PathFile For Program BackUP=========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Program Backup Path]=", "");
                        _pathProgramBackup = strdata.Split(';').GetValue(3).ToString().Trim();
                        //Read the configuration file to batabase backup.
                        strdata = strdata.Replace("=================================================\r\n[===========PathFile For Database BackUP========]\r\n=================================================\r\n", "");
                        strdata = strdata.Replace("[Database Backup Path]=", "");
                        _pathDatabaseBackup = strdata.Split(';').GetValue(4).ToString().Trim();
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
        //The address of the file is in the [config] folder and the file name [Pathfile_config.ini.]
        public bool WritedPathfile_config()
        {
            bool result = false;
            string urlFolder = "config";
            string urlconfig = "config/Pathfile_config.ini";
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

                    //Read the configuration file
                    strdata += "=================================================\r\n[============PathFile For ConHIS Program========]\r\n=================================================\r\n";
                    strdata += "[Destination Path]=" + _pathFileLocal + ";";
                    strdata += "\r\n=================================================\r\n[============PathFile For HIS Interface=========]\r\n=================================================\r\n";
                    strdata += "[Source Path]=" + _pathFileHost + ";";
                    strdata += "\r\n=================================================\r\n[===========PathFile For Write System Log=======]\r\n=================================================\r\n";
                    strdata += "[Logfile Path]=" + _pathLogFile + ";";
                    strdata += "\r\n=================================================\r\n[===========PathFile For Program BackUP=========]\r\n=================================================\r\n";
                    strdata += "[Program Backup Path]=" + _pathProgramBackup + ";";
                    strdata += "\r\n=================================================\r\n[===========PathFile For Database BackUP========]\r\n=================================================\r\n";
                    strdata += "[Database Backup Path]=" + _pathDatabaseBackup + ";";

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
                string urlconfig = "config/Pathfile_config.ini";
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