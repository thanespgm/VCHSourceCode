using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ConHIS.Libary_Class
{
    internal class hosxp_conhis_machine_opd
    {
        private int presc_id;
        private string drug_request_msg_type;
        private byte[] hl7_data;
        private string recieve_status;
        private DateTime drug_dispense_datetime;
        private string recieve_order_type;

        private Connection_mysqlserver Myconn;

        private readonly System_logfile logs = new System_logfile();

        public int Drug_dispense_opd_id { get; set; }
        public int Presc_id { get => presc_id; set => presc_id = value; }
        public string Drug_request_msg_type { get => drug_request_msg_type; set => drug_request_msg_type = value; }
        public byte[] Hl7_data { get => hl7_data; set => hl7_data = value; }
        public string Recieve_status { get => recieve_status; set => recieve_status = value; }
        public DateTime Drug_dispense_datetime { get => drug_dispense_datetime; set => drug_dispense_datetime = value; }
        public string Recieve_order_type { get => recieve_order_type; set => recieve_order_type = value; }

        public hosxp_conhis_machine_opd()
        {
            Myconn = new Connection_mysqlserver(Variable.ServerHosXP);
        }

        public DataSet GetDataConHISMachine(string fileID)
        {
            DataSet result = null;
            string SQL = null;
            SQL += "SELECT ";
            SQL += "drug_dispense_opd.drug_dispense_opd_id,";
            SQL += "drug_dispense_opd.presc_id,";
            SQL += "drug_dispense_opd.drug_request_msg_type,";
            SQL += "drug_dispense_opd.hl7_data,";
            SQL += "drug_dispense_opd.drug_dispense_datetime,";
            SQL += "drug_dispense_opd.recieve_status,";
            SQL += "drug_dispense_opd.recieve_status_datetime,";
            SQL += "drug_dispense_opd.recieve_order_type ";
            SQL += "FROM ";
            SQL += "drug_dispense_opd ";
            SQL += "WHERE ";
            SQL += "drug_dispense_opd.drug_dispense_opd_id =@drug_dispense_opd_id ";
            SQL += "AND ";
            SQL += "CONVERT(drug_dispense_opd.drug_dispense_datetime, DATE) = CONVERT(NOW(),DATE) ";
            SQL += "AND ";
            SQL += "drug_dispense_opd.recieve_status = 'N' ";
            SQL += "AND ";
            SQL += "drug_dispense_opd.recieve_order_type = 'NW' ";
            SQL += "ORDER BY drug_dispense_opd.drug_dispense_opd_id ASC";

            using (MySqlCommand Mycmd = new MySqlCommand(SQL))
            {
                Mycmd.Parameters.Add(new MySqlParameter("@drug_dispense_opd_id", fileID));
                result = Myconn.FillMYSQL(Mycmd);
            }
            return result;
        }

        public DataSet GetDataFileID()
        {
            DataSet result = null;
            string SQL = null;
            SQL += "SELECT ";
            SQL += "drug_dispense_opd.drug_dispense_opd_id ";
            SQL += "FROM ";
            SQL += "drug_dispense_opd ";
            SQL += "WHERE ";
            SQL += "drug_dispense_opd.recieve_status = 'N' ";
            SQL += "AND ";
            SQL += "CONVERT(drug_dispense_opd.drug_dispense_datetime, DATE) = CONVERT(NOW(),DATE) ";
            SQL += "AND ";
            SQL += "drug_dispense_opd.recieve_order_type = 'NW' ";
            SQL += "ORDER BY drug_dispense_opd.drug_dispense_opd_id ASC";

            using (MySqlCommand Mycmd = new MySqlCommand(SQL))
            {
                result = Myconn.FillMYSQL(Mycmd);
            }
            return result;
        }

        public bool InsertToDrugDispenseHosXP(string PesecID, string RequestMsgType, byte[] HL7_Data, string RecieveStatus, string RecieveOrderType)
        {
            bool result = false;
            string SQL = null;
            SQL += "INSERT INTO drug_machine_confirm (";
            SQL += "drug_machine_confirm.vn, ";
            SQL += "drug_machine_confirm.drug_request_msg_type, ";
            SQL += "drug_machine_confirm.hl7_data, ";
            SQL += "drug_machine_confirm.`drug_machine _datetime`, ";
            SQL += "drug_machine_confirm.recieve_status, ";
            SQL += "drug_machine_confirm.recieve_status_datetime, ";
            SQL += "drug_machine_confirm.recieve_order_type) ";
            SQL += "VALUES(";
            SQL += "@vn, ";
            SQL += "@drug_request_msg_type, ";
            SQL += "@hl7_data, ";
            SQL += "NOW(), ";
            SQL += "@recieve_status, ";
            SQL += "NOW(), ";
            SQL += "@recieve_order_type)";

            using (MySqlCommand Mycmd = new MySqlCommand(SQL))
            {
                Mycmd.Parameters.Add(new MySqlParameter("@vn", PesecID));
                Mycmd.Parameters.Add(new MySqlParameter("@drug_request_msg_type", RequestMsgType));
                Mycmd.Parameters.Add("@hl7_data", MySqlDbType.Blob).Value = HL7_Data;
                Mycmd.Parameters.Add(new MySqlParameter("@recieve_status", RecieveStatus));
                Mycmd.Parameters.Add(new MySqlParameter("@recieve_order_type", RecieveOrderType));
                result = Myconn.ExecuteNonQueryMySQL(Mycmd);
            }
            return result;
        }

        public bool UpdateStatusConHISMachine(string status, string fileID)
        {
            bool result = false;
            string SQL = null;
            SQL += "UPDATE drug_dispense_opd SET ";
            SQL += "drug_dispense_opd.recieve_status = @recieve_status ";
            SQL += "WHERE ";
            SQL += "drug_dispense_opd.drug_dispense_opd_id =@drug_dispense_opd_id ";
            SQL += "AND ";
            SQL += "CONVERT(drug_dispense_opd.drug_dispense_datetime, DATE) = CONVERT(NOW(),DATE) ";
            using (MySqlCommand Mycmd = new MySqlCommand(SQL))
            {
                Mycmd.Parameters.Add(new MySqlParameter("@recieve_status", status));
                Mycmd.Parameters.Add(new MySqlParameter("@drug_dispense_opd_id", fileID));
                result = Myconn.ExecuteNonQueryMySQL(Mycmd);
            }
            return result;
        }
    }
}