using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS
{
    internal class ThaneshopDispense_VICHAIYUT
    {
        //filed and properties
        private string prescriptionno;
        private string orderitemcode;
        private string barcodecode;
        private string machineno;
        private DateTime createDateTime;
        private string isread;
        private string status;
        private DateTime modifiedDateTime;
        private string comment;

        public string Prescriptionno { get => prescriptionno; set => prescriptionno = value; }
        public string Orderitemcode { get => orderitemcode; set => orderitemcode = value; }
        public string Barcodecode { get => barcodecode; set => barcodecode = value; }
        public string Machineno { get => machineno; set => machineno = value; }
        public DateTime CreateDateTime { get => createDateTime; set => createDateTime = value; }
        public string Isread { get => isread; set => isread = value; }
        public string Status { get => status; set => status = value; }
        public DateTime ModifiedDateTime { get => modifiedDateTime; set => modifiedDateTime = value; }
        public string Comment { get => comment; set => comment = value; }

        private System_logfile logs;

        //Constructor And Adstract Calss
        public ThaneshopDispense_VICHAIYUT()
        {
            logs = new System_logfile();
        }

        //Query command for adding patient prescriptions data.
        //Return Type boolean
         public bool InsertDataThanesDispense()
          {
               string SQL = null;
               Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
               SQL += "INSERT INTO dbo.tb_thaneshop_dispensing (";
               SQL += "dbo.tb_thaneshop_dispensing.pn,";                                 //2
               SQL += "dbo.tb_thaneshop_dispensing.item_code, ";                              //3
               SQL += "dbo.tb_thaneshop_dispensing.barcode, ";
               SQL += "dbo.tb_thaneshop_dispensing.machine_no, ";     //4
               SQL += "dbo.tb_thaneshop_dispensing.create_dttm,";                                  //5
               SQL += "dbo.tb_thaneshop_dispensing.is_read,";                                  //6
               SQL += "dbo.tb_thaneshop_dispensing.status,";                         //7
               SQL += "dbo.tb_thaneshop_dispensing.modify_dttm,";                                 //8
               SQL += "dbo.tb_thaneshop_dispensing.comment) ";                  //9                              
               SQL += "VALUES( ";
               SQL += "@pn,";                                             //1
               SQL += "@item_code,";                                                        //2
               SQL += "@barcode,";
               SQL += "@machine_no,";//3
               SQL += "GETDATE(),";                                           //4
               SQL += "0,";                                                         //5
               SQL += "'New',";                                                         //6
               SQL += "GETDATE(),";                                                //7
               SQL += "'')";                                                        //8                                                        //72
               using (SqlCommand cmd = new SqlCommand(SQL))
               {
                   cmd.Parameters.Add(new SqlParameter("@pn", Prescriptionno));
                   cmd.Parameters.Add(new SqlParameter("@item_code", Orderitemcode));
                   cmd.Parameters.Add(new SqlParameter("@barcode", Barcodecode));
                   cmd.Parameters.Add(new SqlParameter("@machine_no", Machineno));
                return conn.ExecuteNonQuerySQL(cmd);
               }
          }
        //Query command for adding patient prescriptions data.
        //Return Type boolean
        public bool UpdateDataThanesDispense()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "UPDATE dbo.tb_thaneshop_dispensing SET ";   
            SQL += "dbo.tb_thaneshop_dispensing.is_read =@is_read,";                                  //6
            SQL += "dbo.tb_thaneshop_dispensing.status =@status,";                         //7
            SQL += "dbo.tb_thaneshop_dispensing.modify_dttm =GETDATE(), ";                                 //8
            SQL += "dbo.tb_thaneshop_dispensing.comment =@comment ";                  //9                              
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshop_dispensing.barcode =@barcode ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshop_dispensing.machine_no =@machine_no "; //8                                                        //72
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@is_read", Prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@status", Orderitemcode));
                cmd.Parameters.Add(new SqlParameter("@comment", Comment));
                cmd.Parameters.Add(new SqlParameter("@barcode", Barcodecode));
                cmd.Parameters.Add(new SqlParameter("@machine_no", Machineno));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}
