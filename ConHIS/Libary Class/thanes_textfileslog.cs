using System;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class Thanes_textfileslog
    {
        //filed and properties
        protected string _textfilename;

        public string Textfilename
        {
            get { return _textfilename; }
            set { _textfilename = value; }
        }

        protected string _prescriptionno;

        public string PrescriptonNo
        {
            get { return _prescriptionno; }
            set { _prescriptionno = value; }
        }

        protected DateTime _lastcreatefile;

        public DateTime LastCreatefile
        {
            get { return _lastcreatefile; }
            set { _lastcreatefile = value; }
        }

        protected DateTime _lastreadfile;

        public DateTime LastReadfile
        {
            get { return _lastreadfile; }
            set { _lastreadfile = value; }
        }

        protected DateTime _lastinsertdata;

        public DateTime LastInsertData
        {
            get { return _lastinsertdata; }
            set { _lastinsertdata = value; }
        }

        protected int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        protected int _readreset;

        public int ReadReset
        {
            get { return _readreset; }
            set { _readreset = value; }
        }

        protected string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        //Constructor And Adstract Calss
        public Thanes_textfileslog()
        {
        }

        public bool InsertDataThanesTextFileLogs()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_textfilelog (";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_textfilename,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastcreatefile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastreadfile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastinsertdata,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_status,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_readreset,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_derscription) ";
            SQL += "VALUES( ";
            SQL += "@f_textfilename,";
            SQL += "@f_prescriptionno,";
            SQL += "@f_lastcreatefile,";
            SQL += "@f_lastreadfile,";
            SQL += "@f_lastinsertdata,";
            SQL += "@f_status,";
            SQL += "@f_readreset,";
            SQL += "@f_derscription) ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_textfilename", _textfilename));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_lastcreatefile", _lastcreatefile));
                cmd.Parameters.Add(new SqlParameter("@f_lastreadfile", _lastreadfile));
                cmd.Parameters.Add(new SqlParameter("@f_lastinsertdata", _lastinsertdata));
                cmd.Parameters.Add(new SqlParameter("@f_status", _status));
                cmd.Parameters.Add(new SqlParameter("@f_readreset", _readreset));
                cmd.Parameters.Add(new SqlParameter("@f_derscription", _description));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDataThanesTextFileLogs()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_textfilelog SET ";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_prescriptionno =@f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastcreatefile =@f_lastcreatefile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastreadfile =@f_lastreadfile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastinsertdata =@f_lastinsertdata,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_status =@f_status,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_readreset =@f_readreset,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_derscription =@f_derscription ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_textfilename =@f_textfilename ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_textfilename", _textfilename));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_lastcreatefile", _lastcreatefile));
                cmd.Parameters.Add(new SqlParameter("@f_lastreadfile", _lastreadfile));
                cmd.Parameters.Add(new SqlParameter("@f_lastinsertdata", _lastinsertdata));
                cmd.Parameters.Add(new SqlParameter("@f_status", _status));
                cmd.Parameters.Add(new SqlParameter("@f_readreset", _readreset));
                cmd.Parameters.Add(new SqlParameter("@f_derscription", _description));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDataThanesTextFileLogsProcess(string textfilename, string prescriptionno, DateTime lastcreatefile, DateTime lastreadfile, DateTime lastinsertdata, int status, int readreset, string description)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_textfilelog SET ";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_prescriptionno =@f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastcreatefile =@f_lastcreatefile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastreadfile =@f_lastreadfile,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_lastinsertdata =@f_lastinsertdata,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_status =@f_status,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_readreset =@f_readreset,";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_derscription =@f_derscription ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_textfilename =@f_textfilename ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_textfilename", textfilename));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_lastcreatefile", lastcreatefile));
                cmd.Parameters.Add(new SqlParameter("@f_lastreadfile", lastreadfile));
                cmd.Parameters.Add(new SqlParameter("@f_lastinsertdata", lastinsertdata));
                cmd.Parameters.Add(new SqlParameter("@f_status", status));
                cmd.Parameters.Add(new SqlParameter("@f_readreset", readreset));
                cmd.Parameters.Add(new SqlParameter("@f_derscription", description));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public object GetDataTextFile(string textfilename)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT COUNT(dbo.tb_thaneshosp_textfilelog.f_textfilename))AS ItemsTextfile ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_textfilelog ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_textfilelog.f_textfilename =@f_textfilename ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_textfilename", textfilename));
                return conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}