using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class master_druginfomation
    {
        //Fields And Properties
        private string orderItemCode;                //Field 01
        private string orderItemName;                //Field 02
        private string orderItemNameGeneric;         //Field 03
        private string orderItemNamePrint;           //Field 04
        private string orderUnitCode;                //Field 05
        private string orderUnitDesc;                //Field 06
        private string orderItemBarcode;             //Field 07
        private decimal toMachineNo;                 //Field 08
        private string binLocation;                  //Field 09
        private int instructionActiveFrom;           //Field 10
        private string instructionCode;              //Field 11
        private string instructionDesc;              //Field 12
        private int frequencyActiveFrom;             //Field 13
        private string frequencyCode;                //Field 14
        private string frequencyDesc;                //Field 15
        private string frequencyTime;                //Field 16
        private string drugLabel;                    //Field 17
        private string orderItemImage;               //Field 18
        private DateTime createdAt;                  //Field 19
        private DateTime updatedAt;                  //Field 20
        private int accept;                          //Field 21

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [Required(ErrorMessage = "OrderItemCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "OrderItemCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderItemCode { get => orderItemCode; set => orderItemCode = value; }

        [Required(ErrorMessage = "OrderItemName : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "OrderItemName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OrderItemName { get => orderItemName; set => orderItemName = value; }

        //[Required(ErrorMessage = "OrderItemNameGeneric : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "OrderItemNameGeneric : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OrderItemNameGeneric { get => orderItemNameGeneric; set => orderItemNameGeneric = value; }

       // [Required(ErrorMessage = "OrderItemNamePrint : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "OrderItemNamePrint : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OrderItemNamePrint { get => orderItemNamePrint; set => orderItemNamePrint = value; }

        [Required(ErrorMessage = "OrderUnitCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "OrderUnitCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderUnitCode { get => orderUnitCode; set => orderUnitCode = value; }

        [Required(ErrorMessage = "OrderUnitDesc : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "OrderUnitDesc : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderUnitDesc { get => orderUnitDesc; set => orderUnitDesc = value; }

       // [Required(ErrorMessage = "OrderItemBarcode : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "OrderItemBarcode : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OrderItemBarcode { get => orderItemBarcode; set => orderItemBarcode = value; }

        [Required(ErrorMessage = "ToMachineNo : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "ToMachineNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "ToMachineNo : ขนาดข้อมูลเกิน Max")]
        public decimal ToMachineNo { get => toMachineNo; set => toMachineNo = value; }

        //[Required(ErrorMessage = "BinLocation : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "BinLocation : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string BinLocation { get => binLocation; set => binLocation = value; }

        //[Required(ErrorMessage = "InstructionActiveFrom : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "InstructionActiveFrom : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "InstructionActiveFrom : ขนาดข้อมูลเกิน Max")]
        public int InstructionActiveFrom { get => instructionActiveFrom; set => instructionActiveFrom = value; }

       // [Required(ErrorMessage = "InstructionCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "InstructionCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string InstructionCode { get => instructionCode; set => instructionCode = value; }

        //[Required(ErrorMessage = "InstructionDesc : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "InstructionDesc : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string InstructionDesc { get => instructionDesc; set => instructionDesc = value; }

        //[Required(ErrorMessage = "FrequencyActiveFrom : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "FrequencyActiveFrom : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "FrequencyActiveFrom : ขนาดข้อมูลเกิน Max")]
        public int FrequencyActiveFrom { get => frequencyActiveFrom; set => frequencyActiveFrom = value; }

        //[Required(ErrorMessage = "FrequencyCode : ไม่พบข้อมูล")]
        [StringLength(120, ErrorMessage = "FrequencyCode : ขนาดข้อมูลเกิน 120 ตัวอักษร ")]
        public string FrequencyCode { get => frequencyCode; set => frequencyCode = value; }

        //[Required(ErrorMessage = "FrequencyDesc : ไม่พบข้อมูล")]
        [StringLength(240, ErrorMessage = "FrequencyDesc : ขนาดข้อมูลเกิน 240 ตัวอักษร ")]
        public string FrequencyDesc { get => frequencyDesc; set => frequencyDesc = value; }

        //[Required(ErrorMessage = "FrequencyTime : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "FrequencyTime : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string FrequencyTime { get => frequencyTime; set => frequencyTime = value; }

        //[Required(ErrorMessage = "DrugLabel : ไม่พบข้อมูล")]
        [StringLength(255, ErrorMessage = "DrugLabel : ขนาดข้อมูลเกิน 255 ตัวอักษร ")]
        public string DrugLabel { get => drugLabel; set => drugLabel = value; }

       // [Required(ErrorMessage = "OrderItemImage : ไม่พบข้อมูล")]
       // [StringLength(40, ErrorMessage = "OrderItemImage : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string OrderItemImage { get => orderItemImage; set => orderItemImage = value; }

        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }
        public int Accept { get => accept; set => accept = value; }

        #endregion

        private System_logfile logs;

        public master_druginfomation()
        {
            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridView(string c, string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.id, ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode, ";
            SQL += "dbo.M_DrugInfo.f_orderitemname, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_generic, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_print,";
            SQL += "dbo.M_DrugInfo.f_orderunitcode, ";
            SQL += "dbo.M_DrugInfo.f_orderunitdesc, ";
            SQL += "dbo.M_DrugInfo.f_orderitem_barcode, ";
            SQL += "dbo.M_DrugInfo.f_tomachineno, "; 
            SQL += "dbo.M_DrugInfo.f_binlocation, ";
            SQL += "dbo.M_DrugInfo.f_instruction_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_instructioncode, ";
            SQL += "dbo.M_DrugInfo.f_instructiondesc, ";
            SQL += "dbo.M_DrugInfo.f_frequency_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_frequencycode, ";
            SQL += "dbo.M_DrugInfo.f_frequencydesc, ";
            SQL += "dbo.M_DrugInfo.f_frequencytime, ";
            SQL += "dbo.M_DrugInfo.f_druglabel, ";
            SQL += "dbo.M_DrugInfo.f_orderitemImage, ";
            SQL += "dbo.M_DrugInfo.accept, ";
            SQL += "dbo.M_DrugInfo.cassetteForPROUD, ";
            SQL += "dbo.M_DrugInfo.cassetteStatus, ";
            SQL += "dbo.M_DrugInfo.createdAt, ";
            SQL += "dbo.M_DrugInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";

            switch(c)
            {
                case "All":
                    SQL += "WHERE ";
                    SQL += "dbo.M_DrugInfo.accept = 1 ";
                    break;
                case "New":
                    SQL += "WHERE ";
                    SQL += "dbo.M_DrugInfo.accept = 0 ";
                    break;
                case "Machine":
                    SQL += "WHERE ";
                    SQL += "dbo.M_DrugInfo.f_tomachineno NOT IN ('0') ";
                    SQL += "AND ";
                    SQL += "dbo.M_DrugInfo.accept = 1 ";
                    break;
                case "FromBy":
                    SQL += "WHERE ";
                    SQL += "(dbo.M_DrugInfo.f_orderitemcode LIKE '%" + condition + "%' OR ";
                    SQL += "dbo.M_DrugInfo.f_orderitemname LIKE '%" + condition + "%' OR ";
                    SQL += "dbo.M_DrugInfo.f_orderitem_barcode LIKE '%" + condition + "%') ";
                    SQL += "AND ";
                    SQL += "dbo.M_DrugInfo.accept = 1 ";
                    break;
            }
            SQL += "ORDER BY ";
            SQL += "dbo.M_DrugInfo.f_orderitemname ASC ";
        
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayDataDetail(string orderitemCode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.id, ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode, ";
            SQL += "dbo.M_DrugInfo.f_orderitemname, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_generic, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_print,";
            SQL += "dbo.M_DrugInfo.f_orderunitcode, ";
            SQL += "dbo.M_DrugInfo.f_orderunitdesc, ";
            SQL += "dbo.M_DrugInfo.f_orderitem_barcode, ";
            SQL += "dbo.M_DrugInfo.f_tomachineno, ";
            SQL += "dbo.M_DrugInfo.f_binlocation, ";
            SQL += "dbo.M_DrugInfo.f_instruction_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_instructioncode, ";
            SQL += "dbo.M_DrugInfo.f_instructiondesc, ";
            SQL += "dbo.M_DrugInfo.f_frequency_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_frequencycode, ";
            SQL += "dbo.M_DrugInfo.f_frequencydesc, ";
            SQL += "dbo.M_DrugInfo.f_frequencytime, ";
            SQL += "dbo.M_DrugInfo.f_druglabel, ";
            SQL += "dbo.M_DrugInfo.f_orderitemImage, ";
            SQL += "dbo.M_DrugInfo.accept, ";
            SQL += "dbo.M_DrugInfo.cassetteForPROUD, ";
            SQL += "dbo.M_DrugInfo.cassetteStatus, ";
            SQL += "dbo.M_DrugInfo.createdAt, ";
            SQL += "dbo.M_DrugInfo.updatedAt ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemCode));
                return conn.FillSQL(cmd);
            }
        }

        public decimal GetDrugToMachineNo(string orderitemcode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.f_tomachineno ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode ";
            SQL += "AND ";
            SQL += "dbo.M_DrugInfo.accept = '1' ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemcode));
               var num =  Convert.ToDecimal(conn.ExecuteScalarSQL(cmd));
                if (num == 2 || num == 4)
                    return 2;
                else
                    return 0;
            }
        }

        public decimal GetMachineNo(string orderitemcode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.f_tomachineno ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode ";
            SQL += "AND ";
            SQL += "dbo.M_DrugInfo.accept = '1' ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemcode));
                return Convert.ToDecimal(conn.ExecuteScalarSQL(cmd));    
            }
        }

        public decimal GetDrugCassetteStatus(string orderitemcode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.cassetteStatus ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode ";
            SQL += "AND ";
            SQL += "dbo.M_DrugInfo.accept = '1' ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemcode));
                decimal result = Convert.ToDecimal(conn.ExecuteScalarSQL(cmd));
                if (result == 2)
                    return 2;
                else if (result == 1)
                    return 1;
                else 
                    return 0;
            }
        }


        public decimal GetDrugMiddleToMachineNo(string orderitemcode, decimal qty,decimal dosage)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_DrugInfo.f_tomachineno ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode ";
            SQL += "AND ";
            SQL += "dbo.M_DrugInfo.accept = '1' ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemcode));
                var num = Convert.ToDecimal(conn.ExecuteScalarSQL(cmd));
                if (num == 2)
                {
                    decimal doageDTA = (qty % dosage);
                    if (doageDTA == 0)
                        return 2;
                    else
                        return 24;
                }
                else if(num == 4)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }  
            }
        }

        public bool InsertDataDrugInformation()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_DrugInfo (";
            SQL += "dbo.M_DrugInfo.f_orderitemcode, ";
            SQL += "dbo.M_DrugInfo.f_orderitemname, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_generic, ";
            SQL += "dbo.M_DrugInfo.f_orderitmename_print,";
            SQL += "dbo.M_DrugInfo.f_orderunitcode, ";
            SQL += "dbo.M_DrugInfo.f_orderunitdesc, ";
            SQL += "dbo.M_DrugInfo.f_orderitem_barcode, ";
            SQL += "dbo.M_DrugInfo.f_tomachineno, ";
            SQL += "dbo.M_DrugInfo.f_binlocation, ";
            SQL += "dbo.M_DrugInfo.f_instruction_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_instructioncode, ";
            SQL += "dbo.M_DrugInfo.f_instructiondesc, ";
            SQL += "dbo.M_DrugInfo.f_frequency_activefrom, ";
            SQL += "dbo.M_DrugInfo.f_frequencycode, ";
            SQL += "dbo.M_DrugInfo.f_frequencydesc, ";
            SQL += "dbo.M_DrugInfo.f_frequencytime, ";
            SQL += "dbo.M_DrugInfo.f_druglabel, ";
            // SQL += "dbo.M_DrugInfo.f_orderitemImage, ";
            SQL += "dbo.M_DrugInfo.accept, ";
            SQL += "dbo.M_DrugInfo.createdAt, ";
            SQL += "dbo.M_DrugInfo.updatedAt) ";
            SQL += "VALUES (";
            SQL += "@f_orderitemcode, ";
            SQL += "@f_orderitemname, ";
            SQL += "@f_orderitmename_generic, ";
            SQL += "@f_orderitmename_print,";
            SQL += "@f_orderunitcode, ";
            SQL += "@f_orderunitdesc, ";
            SQL += "@f_orderitem_barcode, ";
            SQL += "@f_tomachineno, ";
            SQL += "@f_binlocation, ";
            SQL += "@f_instruction_activefrom, ";
            SQL += "@f_instructioncode, ";
            SQL += "@f_instructiondesc, ";
            SQL += "@f_frequency_activefrom, ";
            SQL += "@f_frequencycode, ";
            SQL += "@f_frequencydesc, ";
            SQL += "@f_frequencytime, ";
            SQL += "@f_druglabel, ";
            // SQL += "@f_orderitemImage, ";
            SQL += "0,";
            SQL += "GETDATE(), ";
            SQL += "GETDATE())";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", OrderItemCode));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemname", OrderItemName));
                cmd.Parameters.Add(new SqlParameter("@f_orderitmename_generic", OrderItemNameGeneric));
                cmd.Parameters.Add(new SqlParameter("@f_orderitmename_print", OrderItemNamePrint));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitcode", OrderUnitCode));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitdesc", OrderUnitDesc));
                cmd.Parameters.Add(new SqlParameter("@f_orderitem_barcode", OrderItemBarcode));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", ToMachineNo));
                cmd.Parameters.Add(new SqlParameter("@f_binlocation", BinLocation));
                cmd.Parameters.Add(new SqlParameter("@f_instruction_activefrom", InstructionActiveFrom));
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", InstructionCode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", InstructionDesc));
                cmd.Parameters.Add(new SqlParameter("@f_frequency_activefrom", FrequencyActiveFrom));
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", FrequencyCode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", FrequencyDesc));
                cmd.Parameters.Add(new SqlParameter("@f_frequencytime", FrequencyTime));
                cmd.Parameters.Add(new SqlParameter("@f_druglabel", DrugLabel));
                // cmd.Parameters.Add(new SqlParameter("@f_orderitemImage", OrderItemImage));

                if(ToMachineNo == 21)  //ตึกเหนือ อาคารวิชัยยุทธ
                {
                    JSDDNET_Drug jDrug = new JSDDNET_Drug("JSDDNET_01"){
                        DrugName = OrderItemName,
                        DrugBarcode2 = "",
                        UnitCd = OrderUnitCode,
                        DrugCd1 = orderItemCode,
                        DrugCd2 = ""

                    };
                    jDrug.InsertDataDrug();
                }
                else if (ToMachineNo == 22)
                {
                    JSDDNET_Drug jDrug = new JSDDNET_Drug("JSDDNET_02")
                    {
                        DrugName = OrderItemName,
                        DrugBarcode2 = "",
                        UnitCd = OrderUnitCode,
                        DrugCd1 = orderItemCode,
                        DrugCd2 = ""

                    };
                    jDrug.InsertDataDrug();
                }
                
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDataToMachineNo(int machine)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_DrugInfo SET ";
            SQL += "dbo.M_DrugInfo.f_tomachineno =@f_tomachineno ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", OrderItemCode));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", machine));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateAcceptData()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_DrugInfo SET ";
            SQL += "dbo.M_DrugInfo.accept =@accept ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode =@f_orderitemcode";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@accept", Accept));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", OrderItemCode));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public int GetDrugCodeCheck(string orderitemcode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.M_DrugInfo.f_orderitemcode)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_DrugInfo ";
            SQL += "WHERE ";
            SQL += "dbo.M_DrugInfo.f_orderitemcode = @f_orderitemcode ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", orderitemcode));
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }
    }

}
