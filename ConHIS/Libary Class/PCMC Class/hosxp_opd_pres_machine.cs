using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Data;

namespace ConHIS.Libary_Class
{
    internal class Hosxp_opd_pres_machine
    {
        //filed and properties
        private int opd_presc_machine_id;

        private int medication_machine_id;
        private string hn;
        private string vn;
        private string pname;
        private string fname;
        private string lname;
        private string icode;
        private string dname;
        private decimal qty;
        private decimal dose;
        private DateTime modify_datetime;
        private string modify_staff;
        private string modify_computer;
        private char print_sticker;
        private string usage_code;
        private string usage_line1;
        private string usage_line2;
        private string usage_line3;
        private string usage_line4;
        private string usage_unit_code;
        private string usage_unit_name;
        private string frequency_code;
        private string frequency_name;
        private string time_code;
        private string time_name;
        private string dose_usage_unit_name;
        private string hos_guid;
        private int med_plan_number;
        private string depcode;
        private int rx_queue;
        private int seq;
        private string doctor_code;
        private string doctor_name;
        private string patientdob;
        private string tomachineno;
        private string prescriptiondate;
        private string dispensstatus;
        private string serverDBType;

        public int Opd_presc_machine_id { get => opd_presc_machine_id; set => opd_presc_machine_id = value; }
        public int Medication_machine_id { get => medication_machine_id; set => medication_machine_id = value; }
        public string Hn { get => hn; set => hn = value; }
        public string Vn { get => vn; set => vn = value; }
        public string Pname { get => pname; set => pname = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Icode { get => icode; set => icode = value; }
        public string Dname { get => dname; set => dname = value; }
        public decimal Qty { get => qty; set => qty = value; }
        public decimal Dose { get => dose; set => dose = value; }
        public DateTime Modify_datetime { get => modify_datetime; set => modify_datetime = value; }
        public string Modify_staff { get => modify_staff; set => modify_staff = value; }
        public string Modify_computer { get => modify_computer; set => modify_computer = value; }
        public char Print_sticker { get => print_sticker; set => print_sticker = value; }
        public string Usage_code { get => usage_code; set => usage_code = value; }
        public string Usage_line1 { get => usage_line1; set => usage_line1 = value; }
        public string Usage_line2 { get => usage_line2; set => usage_line2 = value; }
        public string Usage_line3 { get => usage_line3; set => usage_line3 = value; }
        public string Usage_line4 { get => usage_line4; set => usage_line4 = value; }
        public string Usage_unit_code { get => usage_unit_code; set => usage_unit_code = value; }
        public string Usage_unit_name { get => usage_unit_name; set => usage_unit_name = value; }
        public string Frequency_code { get => frequency_code; set => frequency_code = value; }
        public string Frequency_name { get => frequency_name; set => frequency_name = value; }
        public string Time_code { get => time_code; set => time_code = value; }
        public string Time_name { get => time_name; set => time_name = value; }
        public string Dose_usage_unit_name { get => dose_usage_unit_name; set => dose_usage_unit_name = value; }
        public string Hos_guid { get => hos_guid; set => hos_guid = value; }
        public int Med_plan_number { get => med_plan_number; set => med_plan_number = value; }
        public string Depcode { get => depcode; set => depcode = value; }
        public int Rx_queue { get => rx_queue; set => rx_queue = value; }
        public int Seq { get => seq; set => seq = value; }
        public string Doctor_code { get => doctor_code; set => doctor_code = value; }
        public string Doctor_name { get => doctor_name; set => doctor_name = value; }
        public string Patientdob { get => patientdob; set => patientdob = value; }
        public string Tomachineno { get => tomachineno; set => tomachineno = value; }
        public string Prescriptiondate { get => prescriptiondate; set => prescriptiondate = value; }
        public string Dispensstatus { get => dispensstatus; set => dispensstatus = value; }
        public string ServerDBType { get => serverDBType; set => serverDBType = value; }

        private readonly System_logfile logs = new System_logfile();

        //Constructor And Abstract Class
        public Hosxp_opd_pres_machine()
        {
        }

        public Hosxp_opd_pres_machine(string ServerDatabaseType)
        {
            ServerDBType = ServerDatabaseType;
        }

        //Query Command opd_pres_machine table form HIS Interface
        //Return DataSet
        public DataSet GetDataOPDPresMachine(string statustype, string hn, string tomachineno)
        {
            DataSet result = null;
            string SQL = null;
            SQL += "SELECT ";
            SQL += "opd_presc_machine.opd_presc_machine_id,";
            SQL += "opd_presc_machine.medication_machine_id,";
            SQL += "opd_presc_machine.hn,";
            SQL += "opd_presc_machine.vn,";
            SQL += "opd_presc_machine.pname,";
            SQL += "opd_presc_machine.fname,";
            SQL += "opd_presc_machine.lname,";
            SQL += "opd_presc_machine.icode,";
            SQL += "opd_presc_machine.dname,";
            SQL += "opd_presc_machine.qty,";
            SQL += "opd_presc_machine.dose,";
            SQL += "opd_presc_machine.modify_datetime,";
            SQL += "opd_presc_machine.modify_staff,";
            SQL += "opd_presc_machine.modify_computer,";
            SQL += "opd_presc_machine.print_sticker,";
            SQL += "opd_presc_machine.usage_code,";
            SQL += "opd_presc_machine.usage_line1,";
            SQL += "opd_presc_machine.usage_line2,";
            SQL += "opd_presc_machine.usage_line3,";
            SQL += "opd_presc_machine.usage_line4,";
            SQL += "opd_presc_machine.usage_unit_code,";
            SQL += "opd_presc_machine.usage_unit_name,";
            SQL += "opd_presc_machine.frequency_code,";
            SQL += "opd_presc_machine.frequency_name,";
            SQL += "opd_presc_machine.time_code,";
            SQL += "opd_presc_machine.time_name,";
            SQL += "opd_presc_machine.dose_usage_unit_name,";
            SQL += "opd_presc_machine.hos_guid,";
            SQL += "opd_presc_machine.med_plan_number,";
            SQL += "opd_presc_machine.depcode,";
            SQL += "opd_presc_machine.rx_queue,";
            SQL += "opd_presc_machine.seq,";
            SQL += "opd_presc_machine.doctor_code,";
            SQL += "opd_presc_machine.doctor_name,";
            SQL += "opd_presc_machine.patientdob,";
            SQL += "opd_presc_machine.tomachineno,";
            SQL += "opd_presc_machine.prescriptiondate,";
            SQL += "opd_presc_machine.dispensstatus ";
            SQL += "FROM ";
            SQL += "opd_presc_machine ";

            if ((hn != "") && (hn != null))
            {
                SQL += "WHERE ";
                switch (statustype)
                {
                    case "all":
                        break;

                    case "wait":
                        SQL += "opd_presc_machine.hn =@hn ";
                        break;
                }

                SQL += "AND ";
                SQL += "opd_presc_machine.tomachineno = @tomachineno ";
                SQL += "AND ";
                SQL += "opd_presc_machine.dispensstatus ='0' ";
                SQL += "AND ";

                if (ServerDBType == "MySQL")
                    SQL += "DATE_FORMAT(opd_presc_machine.modify_datetime, '%Y %m %d') = DATE_FORMAT(NOW(), '%Y %m %d') ";
                else
                {
                    SQL += "TO_CHAR(opd_presc_machine.modify_datetime, 'yyyyMMdd') = TO_CHAR(NOW(), 'yyyyMMdd') ";
                    //SQL += "AND ";
                    //SQL += "modify_datetime >= (now() - '1 min'::interval)";
                }
            }

            SQL += "ORDER BY opd_presc_machine.modify_datetime ASC ";

            switch (ServerDBType)
            {
                case "MySQL":
                    Connection_mysqlserver Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
                    using (MySqlCommand Mycmd = new MySqlCommand(SQL))
                    {
                        Mycmd.Parameters.Add(new MySqlParameter("@tomachineno", tomachineno));
                        Mycmd.Parameters.Add(new MySqlParameter("@hn", hn));
                        result = Myconn.FillMYSQL(Mycmd);
                    }
                    break;

                case "PGSQL":
                    Connection_pgsqlserver PGconn = new Connection_pgsqlserver(Variable.ServerHosXP);
                    using (NpgsqlCommand PGcmd = new NpgsqlCommand(SQL))
                    {
                        PGcmd.Parameters.Add(new NpgsqlParameter("@tomachineno", tomachineno));
                        PGcmd.Parameters.Add(new NpgsqlParameter("@hn", hn));
                        result = PGconn.FillPGSQL(PGcmd);
                    }
                    break;
            }
            return result;
        }

        //Query Command opd_pres_machine table form HIS Interface
        //Return DataSet
        public DataSet GetDataOPDPresMachineByTopOne(string statustype, string tomachineno)
        {
            DataSet result = null;
            string SQL = null;

            SQL += "SELECT ";
            SQL += "opd_presc_machine_id ";
            SQL += "FROM ";
            SQL += "opd_presc_machine ";

            if ((tomachineno != "") && (tomachineno != null))
            {
                SQL += "WHERE ";
                switch (statustype)
                {
                    case "all":
                        break;

                    case "wait":
                        SQL += "tomachineno = @tomachineno ";
                        break;
                }

                SQL += "AND ";
                SQL += "dispensstatus = '0' ";
                SQL += "AND ";

                if (ServerDBType == "MySQL")
                    SQL += "DATE_FORMAT(modify_datetime, '%Y %m %d') = DATE_FORMAT(NOW(), '%Y %m %d') ";
                else
                {
                    SQL += "TO_CHAR(modify_datetime, 'yyyyMMdd') = TO_CHAR(NOW(), 'yyyyMMdd') ";
                    //if (Variable.referrenceCode != "")
                    //{
                    //    SQL += "AND ";
                    //    SQL += "opd_presc_machine.opd_presc_machine_id > @opd_presc_machine_id ";
                    //}
                    //SQL += "AND ";
                    //SQL += "modify_datetime >= (now() - '1 min'::interval)";
                }
            }

            //SQL += "ORDER BY modify_datetime ASC ";

            switch (ServerDBType)
            {
                case "MySQL":
                    Connection_mysqlserver Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
                    using (MySqlCommand Mycmd = new MySqlCommand(SQL))
                    {
                        Mycmd.Parameters.Add(new MySqlParameter("@tomachineno", tomachineno));
                        result = Myconn.FillMYSQL(Mycmd);
                    }
                    break;

                case "PGSQL":
                    Connection_pgsqlserver PGconn = new Connection_pgsqlserver(Variable.ServerHosXP);
                    using (NpgsqlCommand PGcmd = new NpgsqlCommand(SQL))
                    {
                        PGcmd.Parameters.Add(new NpgsqlParameter("@tomachineno", tomachineno));
                        if (Variable.referrenceCode != "")
                            PGcmd.Parameters.Add(new NpgsqlParameter("@opd_presc_machine_id", Convert.ToInt64(Variable.referrenceCode)));
                        result = PGconn.FillPGSQL(PGcmd);
                    }
                    break;
            }
            return result;
        }

        public DataSet GetDataHn(string statustype, string tomachineno)
        {
            DataSet result = null;
            string SQL = null;

            SQL += "SELECT DISTINCT ";
            SQL += "hn ";
            SQL += "FROM ";
            SQL += "opd_presc_machine ";

            if ((tomachineno != "") && (tomachineno != null))
            {
                SQL += "WHERE ";
                switch (statustype)
                {
                    case "all":
                        break;

                    case "wait":
                        SQL += "tomachineno = @tomachineno ";
                        break;
                }

                SQL += "AND ";
                SQL += "dispensstatus = '0' ";
                SQL += "AND ";

                if (ServerDBType == "MySQL")
                    SQL += "DATE_FORMAT(modify_datetime, '%Y %m %d') = DATE_FORMAT(NOW(), '%Y %m %d') ";
                else
                {
                    SQL += "TO_CHAR(modify_datetime, 'yyyyMMdd') = TO_CHAR(NOW(), 'yyyyMMdd') ";
                    //if (Variable.referrenceCode != "")
                    //{
                    //    SQL += "AND ";
                    //    SQL += "opd_presc_machine.opd_presc_machine_id > @opd_presc_machine_id ";
                    //}
                    //SQL += "AND ";
                    //SQL += "modify_datetime >= (now() - '1 min'::interval)";
                }
            }

            //SQL += "ORDER BY modify_datetime ASC ";

            switch (ServerDBType)
            {
                case "MySQL":
                    Connection_mysqlserver Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
                    using (MySqlCommand Mycmd = new MySqlCommand(SQL))
                    {
                        Mycmd.Parameters.Add(new MySqlParameter("@tomachineno", tomachineno));
                        result = Myconn.FillMYSQL(Mycmd);
                    }
                    break;

                case "PGSQL":
                    Connection_pgsqlserver PGconn = new Connection_pgsqlserver(Variable.ServerHosXP);
                    using (NpgsqlCommand PGcmd = new NpgsqlCommand(SQL))
                    {
                        PGcmd.Parameters.Add(new NpgsqlParameter("@tomachineno", tomachineno));
                        if (Variable.referrenceCode != "")
                            PGcmd.Parameters.Add(new NpgsqlParameter("@opd_presc_machine_id", Convert.ToInt64(Variable.referrenceCode)));
                        result = PGconn.FillPGSQL(PGcmd);
                    }
                    break;
            }
            return result;
        }

        //Query command for Update dispensestatus opd_pres_machine table.
        //Return Type boolean
        public bool UpdateDispenseStatusOPDPresMachine(string opd_presc_machine_id, string tomachineno)
        {
            bool result = false;
            string SQL = null;
            SQL += "UPDATE opd_presc_machine SET ";
            SQL += "dispensstatus = '1' ";
            SQL += "WHERE ";
            SQL += "opd_presc_machine_id = @opd_presc_machine_id ";
            SQL += "AND ";
            SQL += "tomachineno =@tomachineno ";
            SQL += "AND ";

            if (ServerDBType == "MySQL")
                SQL += "DATE_FORMAT(modify_datetime, '%Y %m %d') = DATE_FORMAT(NOW(), '%Y %m %d') ";
            else
                SQL += "TO_CHAR(modify_datetime, 'yyyyMMdd') = TO_CHAR(NOW(), 'yyyyMMdd') ";

            switch (ServerDBType)
            {
                case "MySQL":
                    Connection_mysqlserver Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
                    using (MySqlCommand Mycmd = new MySqlCommand(SQL))
                    {
                        Mycmd.Parameters.Add(new MySqlParameter("@tomachineno", tomachineno));
                        Mycmd.Parameters.Add(new MySqlParameter("@opd_presc_machine_id", opd_presc_machine_id));
                        result = Myconn.ExecuteNonQueryMySQL(Mycmd);
                    }
                    break;

                case "PGSQL":
                    Connection_pgsqlserver PGconn = new Connection_pgsqlserver(Variable.ServerHosXP);
                    using (NpgsqlCommand PGcmd = new NpgsqlCommand(SQL))
                    {
                        PGcmd.Parameters.Add(new NpgsqlParameter("@tomachineno", tomachineno));
                        PGcmd.Parameters.Add(new NpgsqlParameter("@opd_presc_machine_id", Convert.ToInt64(opd_presc_machine_id)));
                        result = PGconn.ExecuteNonQueryPGSQL(PGcmd);
                    }
                    break;
            }
            return result;
        }

        //Query command for Get items opd_pres_machine data
        //Return Type Objects
        public object GetItemsDataOPDPresMachine(string statustype, string hn, string tomachineno)
        {
            object result = null;
            string SQL = null;

            SQL += "SELECT COUNT(*)AS ItemsListOrder ";
            SQL += "FROM ";
            SQL += "opd_presc_machine  ";
            SQL += "WHERE ";
            switch (statustype)
            {
                case "all":
                    SQL += "dispensstatus IN('0','1') ";
                    break;

                case "wait":
                    SQL += "dispensstatus = '0' ";
                    break;
            }

            SQL += "AND ";
            SQL += "tomachineno =@tomachineno ";
            SQL += "AND ";

            if (ServerDBType == "MySQL")
                SQL += "DATE_FORMAT(modify_datetime, '%Y %m %d') = DATE_FORMAT(NOW(), '%Y %m %d') ";
            else
                SQL += "TO_CHAR(modify_datetime, 'yyyyMMdd') = TO_CHAR(NOW(), 'yyyyMMdd') ";

            SQL += "AND ";
            SQL += "hn = @hn";

            switch (ServerDBType)
            {
                case "MySQL":
                    Connection_mysqlserver Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
                    using (MySqlCommand Mycmd = new MySqlCommand(SQL))
                    {
                        Mycmd.Parameters.Add(new MySqlParameter("@tomachineno", tomachineno));
                        Mycmd.Parameters.Add(new MySqlParameter("@hn", hn));
                        result = Myconn.ExecuteScalarMySQL(Mycmd);
                    }
                    break;

                case "PGSQL":
                    Connection_pgsqlserver PGconn = new Connection_pgsqlserver(Variable.ServerHosXP);
                    using (NpgsqlCommand PGcmd = new NpgsqlCommand(SQL))
                    {
                        PGcmd.Parameters.Add(new NpgsqlParameter("@tomachineno", tomachineno));
                        PGcmd.Parameters.Add(new NpgsqlParameter("@hn", hn));
                        result = PGconn.ExecuteScalarPGSQL(PGcmd);
                    }
                    break;
            }
            return result;
        }
    }
}