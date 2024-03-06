using System;
using System.IO;

namespace ConHIS
{
    internal class System_logfile
    {
        //filed and properties
        private static StreamWriter sw;

        private static string _pathfile;

        public string PathFile
        {
            get { return _pathfile; }
            set { _pathfile = value; }
        }

        //Constructor And Adstract Calss
        public System_logfile()
        {
        }

        //Write log file To Path.
        //The address of the file is in the [logfile] folder and the file name [Pathfile_config.ini.]
        public bool Writelogfile(string messegetext, string chaptertext)
        {
            bool result = false;
            string datetimestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
            string genfolder = DateTime.Now.ToString("dd-MM-yyyy");
            string filename = Variable.PathLogs + genfolder + chaptertext + ".log";
            try
            {
                if (File.Exists(filename))
                    sw = File.AppendText(filename);
                else
                    sw = File.CreateText(filename);
                sw.WriteLine("[" + datetimestamp + "] : " + messegetext);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
            return result;
        }

        public bool LogPerFile(string messegetext, string chaptertext)
        {
            bool result = false;
            string genfolder = DateTime.Now.ToString("dd-MM-yyyy");
            string filename = Variable.PathLogs + genfolder + chaptertext + ".log";
            try
            {
                if (File.Exists(filename))
                    sw = File.AppendText(filename);
                else
                    sw = File.CreateText(filename);
                sw.WriteLine( messegetext);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
            return result;
        }

        //Write log file To Path.
        //The address of the file is in the [logfile] folder and the file name [Pathfile_config.ini.]
        public bool Writelogcheck(string messegetext, string chaptertext)
        {
            bool result = false;
            string datetimestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
            string genfolder = DateTime.Now.ToString("dd-MM-yyyy");
            string filename = Variable.PathLogs + genfolder + chaptertext + ".log";
            try
            {
                if (File.Exists(filename))
                    sw = File.AppendText(filename);
                else
                    sw = File.CreateText(filename);
                sw.WriteLine("[" + datetimestamp + "] : " + "\n" + messegetext);
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
            return result;
        }
    }
}