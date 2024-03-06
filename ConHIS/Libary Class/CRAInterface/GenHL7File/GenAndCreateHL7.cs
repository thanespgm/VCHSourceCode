using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConHIS.Libary_Class.CRAInterface.GenHL7File
{
    public class GenAndCreateHL7
    {
        private readonly System_logfile log;

        public GenAndCreateHL7()
        {
            log = new System_logfile();
        }

       
        public void GenAndCreate(string prescriptionno,string HL7msg)
        {
            try
            {
                string str = string.Empty;
                HL7msg = HL7msg.Replace("PID", "\r\nPID");
                HL7msg = HL7msg.Replace("PV1", "\r\nPV1");
                HL7msg = HL7msg.Replace("ORC", "\r\nORC");
                HL7msg = HL7msg.Replace("AL1", "\r\nAL1");
                HL7msg = HL7msg.Replace("RXD", "\r\nRXD");
                HL7msg = HL7msg.Replace("RXR", "\r\nRXR");
                HL7msg = HL7msg.Replace("NTE", "\r\nNTE");
                HL7msg = HL7msg.Replace("TQ1", "\r\nTQ1");

                str = HL7msg;

                DateTime date = DateTime.UtcNow.Date;
                string genfolder = Variable.PathHost;
                string filename = genfolder + @"\" + prescriptionno + ".hl7";
                if (!Directory.Exists(genfolder))
                {
                    Directory.CreateDirectory(genfolder);
                }
                else if (prescriptionno != null)
                {
                    StreamWriter sw;
                    if ((File.Exists(filename)) && (str != null))
                    {
                        sw = File.AppendText(filename);
                        sw.Write(str);
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                    else if (str != null)
                    {
                        sw = File.CreateText(filename);
                        sw.Write(str);
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                    str = "";
                }
            }
            catch(Exception ex)
            {
                log.Writelogfile("[" + prescriptionno + "] : "+ ex.Message, " GenAndCreateHL7");
            } 
        }
    }
}
