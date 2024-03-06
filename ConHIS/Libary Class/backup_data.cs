using ConHIS.Properties;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConHIS
{
    internal class Backup_data
    {
        //objects and properties
        private readonly System_logfile logs;

        //constuctor class
        public Backup_data()
        {
            logs = new System_logfile();
        }

        //function backup data per day
        public bool TransectionBackupAsync()
        {
            string datePerDay = DateTime.Now.Day.ToString();
            string dateBackup = Settings.Default.dateBackup;
            bool result;
            try
            {
                if (dateBackup != datePerDay)
                {
                    result = true;
                    Settings.Default.dateBackup = datePerDay;
                    Settings.Default.Save();
                    if ( InsertDataThanesMiddleBackup())
                    {
                         DeleteDataThanesMiddleAsync();
                    }

                    // -------------------------------------------------------------------
                    // -------- For Conhis Middle V4 -------------------------------------
                    if (InsertDataExtentionsBackupAsync())
                    {
                        DeleteDataExtentionsAsync();
                    }

                    if (InsertDataPrescriptionBackupAsync())
                    {
                        DeleteDataPrescriptionAsync();
                    }
                    //---------- End Conhis Middle V4 -------------------------------------
                    // --------------------------------------------------------------------
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                logs.Writelogfile(ex.ToString(), " transection backup error");
            }
            return result;
        }

        //Query command for Transection Data.
        //Return Type boolean
        public bool InsertDataThanesMiddleBackup()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle_bak ";
            SQL += "SELECT * FROM dbo.tb_thaneshosp_middle ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool InsertDataExtentionsBackupAsync()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle_extention_bak ";
            SQL += "SELECT * FROM dbo.tb_thaneshosp_middle_extention ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool InsertDataPrescriptionBackupAsync()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_Prescription_bak ";
            SQL += "SELECT * FROM dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Clear Current Data Table.
        //Return Type boolean
        public bool DeleteDataThanesMiddleAsync()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.tb_thaneshosp_middle ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool DeleteDataExtentionsAsync()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.tb_thaneshosp_middle_extention ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool DeleteDataPrescriptionAsync()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Clear Current Data Table.
        //Return Type boolean
        public bool DeleteDataNonOrderMachineAsync(string presdate)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.tb_thaneshosp_middle_bak ";
            SQL += "WHERE dbo.tb_thaneshosp_middle_bak.f_prescriptiondate = @prescriptiondate ";
            SQL += "AND dbo.tb_thaneshosp_middle_bak.f_tomachineno = 0 ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@prescriptiondate", presdate);
                return  conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //function fitter order by machine tr-ev-1
        public bool OrderbymachineEVAsync()
        {
            bool result = false;
            if (Settings.Default.onRelationMachine)
            {
                string dateFitter = DateTime.Now.AddDays(-(Settings.Default.onDelete)).ToString("yyyyMMdd");
                string dateDelete = Settings.Default.dateDelete;
                try
                {
                    if (dateFitter != dateDelete)
                    {
                        Settings.Default.dateDelete = dateFitter;
                        Settings.Default.Save();
                        if (DeleteDataNonOrderMachineAsync(dateFitter))
                        {
                            result = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logs.Writelogfile(ex.ToString(), "order by machine error");
                    result = false;
                }
            }
            return result;
        }
    }
}