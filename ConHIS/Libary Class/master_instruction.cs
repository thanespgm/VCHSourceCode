using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConHIS.Libary_Class
{
    internal class master_instruction
    {
        //Fields And Properties
        private string instructionCode;              //Field 01
        private string instructionDesc;              //Field 02
        private DateTime createdAt;                  //Field 03
        private DateTime updatedAt;                  //Field 04
        private int accept;                          //Field 05

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [Required(ErrorMessage = "InstructionCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "InstructionCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string InstructionCode { get => instructionCode; set => instructionCode = value; }

        [StringLength(200, ErrorMessage = "InstructionDesc : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string InstructionDesc { get => instructionDesc; set => instructionDesc = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }
        public int Accept { get => accept; set => accept = value; }

        #endregion

        private System_logfile logs;

        public master_instruction()
        {
            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridView(string c, string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_InstructionInfo.id, ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode, ";
            SQL += "dbo.M_InstructionInfo.f_instructiondesc, ";
            SQL += "dbo.M_InstructionInfo.accept, ";
            SQL += "dbo.M_InstructionInfo.createdAt, ";
            SQL += "dbo.M_InstructionInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_InstructionInfo ";

            switch (c)
            {
                case "All":
                    SQL += "WHERE ";
                    SQL += "dbo.M_InstructionInfo.accept = 1 ";
                    break;
                case "New":
                    SQL += "WHERE ";
                    SQL += "dbo.M_InstructionInfo.accept = 0 ";
                    break;
                case "FromBy":
                    SQL += "WHERE ";
                    SQL += "(dbo.M_InstructionInfo.f_instructioncode LIKE '%" + condition + "%' OR ";
                    SQL += "dbo.M_InstructionInfo.f_instructiondesc LIKE '%" + condition + "%') ";
                    SQL += "AND ";
                    SQL += "dbo.M_InstructionInfo.accept = 1 ";
                    break;
            }
            SQL += "ORDER BY ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode ASC ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayDataDetail(string instructionCode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_InstructionInfo.id, ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode, ";
            SQL += "dbo.M_InstructionInfo.f_instructiondesc, ";
            SQL += "dbo.M_InstructionInfo.accept, ";
            SQL += "dbo.M_InstructionInfo.accept, ";
            SQL += "dbo.M_InstructionInfo.createdAt, ";
            SQL += "dbo.M_InstructionInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_InstructionInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode =@f_instructioncode ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", instructionCode));
                return conn.FillSQL(cmd);
            }
        }
        public bool InsertDataInstruction()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_InstructionInfo (";
            SQL += "dbo.M_InstructionInfo.f_instructioncode, ";
            SQL += "dbo.M_InstructionInfo.f_instructiondesc, ";
            SQL += "dbo.M_InstructionInfo.accept, ";
            SQL += "dbo.M_InstructionInfo.createdAt, ";
            SQL += "dbo.M_InstructionInfo.updatedAt) ";
            SQL += "VALUES (";
            SQL += "@f_instructioncode, ";
            SQL += "@f_instructiondesc, ";
            SQL += "0,";
            SQL += "GETDATE(), ";
            SQL += "GETDATE())";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", InstructionCode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", InstructionDesc));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDataInstruction(int id)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_InstructionInfo SET ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode =@f_instructioncode, ";
            SQL += "dbo.M_InstructionInfo.f_instructiondesc =@f_instructiondesc, ";
            SQL += "dbo.M_InstructionInfo.accept = 1, ";
            SQL += "dbo.M_InstructionInfo.updatedAt = GETDATE() ";
            SQL += "WHERE ";
            SQL += "dbo.M_InstructionInfo.id = @id ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", InstructionCode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", InstructionDesc));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public int GetInstructionCodeCheck(string instructionCode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.M_InstructionInfo.f_instructioncode)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_InstructionInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_InstructionInfo.f_instructioncode = @f_instructioncode ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", instructionCode));
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}
