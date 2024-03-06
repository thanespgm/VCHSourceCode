using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class master_prescription
    {
        //Fields And Properties

        private string prescriptionNo;                    //Field 01
        private decimal seqNo;                            //Field 02
        private string prescriptionNoHIS;                 //Field 03
        private string priorityCd;                        //Field 04
        private string patientId;                         //Field 05
        private string patientName;                       //Field 06
        private string patientAn;                         //Field 07
        private DateTime brithDay;                        //Field 08
        private string wardCd;                            //Field 09
        private string wardName;                          //Field 10
        private string roomNo;                            //Field 11
        private string bedNo;                             //Field 12
        private string prescriptionDate;                  //Field 13
        private DateTime takeDate;                        //Field 14
        private string takeTime;                          //Field 15
        private string barcodeId;                         //Field 16
        private string drugCd;                            //Field 17
        private string drugName;                          //Field 18
        private decimal dispensedDose;                    //Field 19
        private decimal dispensedTotalDose;               //Field 20
        private string dispensedUnit;                     //Field 21
        private string freqCounter;                       //Field 22
        private string freqDesc;                          //Field 23
        private string freqDescDetailCode;                //Field 24
        private string freqDescDetail;                    //Field 25
        private DateTime makeRecTime;                     //Field 26
        private DateTime upDateRecTime;                   //Field 27
        private string freePrintItemPres1;                //Field 28
        private string freePrintItemPres2;                //Field 29
        private string freePrintItemPres3;                //Field 30
        private string freePrintItemPres4;                //Field 31
        private string freePrintItemPres5;                //Field 32
        private decimal procFlg;                          //Field 33
        private decimal dTAFlg;                           //Field 34
        private decimal machineFlg;                       //Field 35
        private decimal printFlg;                         //Field 36
        private decimal sMTFlg;                           //Field 37
        private decimal processFlg;                       //Field 38
        private string pharmacyIPD;                       //Field 39
        private string rowID;                             //Field 40
        private DateTime createDateTime;                  //Field 41
        private string fieldUpdate;                       //Field 42
        private string normalStatus;                      //Field 43
        private string barcodeByHIS;                      //Field 44
        private decimal status;                           //Field 45

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [Required(ErrorMessage = "PrescriptionNo : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string PrescriptionNo { get => prescriptionNo; set => prescriptionNo = value; }

        [Required(ErrorMessage = "Seq : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "Seq : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 999999, ErrorMessage = "Seq : ขนาดข้อมูลเกิน Max")]
        public decimal SeqNo { get => seqNo; set => seqNo = value; }

        [Required(ErrorMessage = "PrescriptionNoHIS : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "PrescriptionNoHIS : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string PrescriptionNoHIS { get => prescriptionNoHIS; set => prescriptionNoHIS = value; }

        [Required(ErrorMessage = "PriorityCd : ไม่พบข้อมูล")]
        [StringLength(10, ErrorMessage = "PriorityCd : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string PriorityCd { get => priorityCd; set => priorityCd = value; }

        [Required(ErrorMessage = "PatientId : ไม่พบข้อมูล")]
        [StringLength(15, ErrorMessage = "PatientId : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string PatientId { get => patientId; set => patientId = value; }

        [Required(ErrorMessage = "PatientName : ไม่พบข้อมูล")]
        [StringLength(300, ErrorMessage = "PatientName : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string PatientName { get => patientName; set => patientName = value; }

        [StringLength(15, ErrorMessage = "PatientAn : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string PatientAn { get => patientAn; set => patientAn = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BrithDay { get => brithDay; set => brithDay = value; }

        [Required(ErrorMessage = "WardCd : ไม่พบข้อมูล")]
        [StringLength(30, ErrorMessage = "WardCd : ขนาดข้อมูลเกิน 30 ตัวอักษร ")]
        public string WardCd { get => wardCd; set => wardCd = value; }

        [StringLength(50, ErrorMessage = "WardName : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string WardName { get => wardName; set => wardName = value; }

        [StringLength(20, ErrorMessage = "RoomNo : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string RoomNo { get => roomNo; set => roomNo = value; }

        [StringLength(20, ErrorMessage = "BedNo : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string BedNo { get => bedNo; set => bedNo = value; }

        [Required(ErrorMessage = "PrescriptionDate : ไม่พบข้อมูล")]
        [RegularExpression("([0-9]+)", ErrorMessage = "PrescriptionDate : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [StringLength(20, ErrorMessage = "PrescriptionDate : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }

        [Required(ErrorMessage = "TakeDate : ไม่พบข้อมูล")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime TakeDate { get => takeDate; set => takeDate = value; }

        [StringLength(10, ErrorMessage = "TakeTime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string TakeTime { get => takeTime; set => takeTime = value; }

        [StringLength(150, ErrorMessage = "BarcodeId : ขนาดข้อมูลเกิน 150 ตัวอักษร ")]
        public string BarcodeId { get => barcodeId; set => barcodeId = value; }

        [Required(ErrorMessage = "DrugCd : ไม่พบข้อมูล")]
        [StringLength(50, ErrorMessage = "DrugCd : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string DrugCd { get => drugCd; set => drugCd = value; }

        [Required(ErrorMessage = "DrugName : ไม่พบข้อมูล")]
        [StringLength(150, ErrorMessage = "DrugName : ขนาดข้อมูลเกิน 150 ตัวอักษร ")]
        public string DrugName { get => drugName; set => drugName = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispensedDose : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99999999.99, ErrorMessage = "DispensedDose : ขนาดข้อมูลเกิน Max")]
        public decimal DispensedDose { get => dispensedDose; set => dispensedDose = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispensedTotalDose : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99999999.99, ErrorMessage = "DispensedTotalDose : ขนาดข้อมูลเกิน Max")]
        public decimal DispensedTotalDose { get => dispensedTotalDose; set => dispensedTotalDose = value; }

        [StringLength(20, ErrorMessage = "DispensedUnit : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string DispensedUnit { get => dispensedUnit; set => dispensedUnit = value; }

        [StringLength(5, ErrorMessage = "FreqCounter : ขนาดข้อมูลเกิน 5 ตัวอักษร ")]
        public string FreqCounter { get => freqCounter; set => freqCounter = value; }

        [StringLength(300, ErrorMessage = "FreqDesc : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string FreqDesc { get => freqDesc; set => freqDesc = value; }

        [StringLength(300, ErrorMessage = "FreqDescDetailCode : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string FreqDescDetailCode { get => freqDescDetailCode; set => freqDescDetailCode = value; }

        [StringLength(500, ErrorMessage = "FreqDescDetail : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string FreqDescDetail { get => freqDescDetail; set => freqDescDetail = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime MakeRecTime { get => makeRecTime; set => makeRecTime = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime UpDateRecTime { get => upDateRecTime; set => upDateRecTime = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres1 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres1 { get => freePrintItemPres1; set => freePrintItemPres1 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres2 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres2 { get => freePrintItemPres2; set => freePrintItemPres2 = value; }

        [StringLength(500, ErrorMessage = "FreePrintItemPres3 : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string FreePrintItemPres3 { get => freePrintItemPres3; set => freePrintItemPres3 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres4 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres4 { get => freePrintItemPres4; set => freePrintItemPres4 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres5 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres5 { get => freePrintItemPres5; set => freePrintItemPres5 = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "ProcFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "ProcFlg : ขนาดข้อมูลเกิน Max")]
        public decimal ProcFlg { get => procFlg; set => procFlg = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DTAFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "DTAFlg : ขนาดข้อมูลเกิน Max")]
        public decimal DTAFlg { get => dTAFlg; set => dTAFlg = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "MachineFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "MachineFlg : ขนาดข้อมูลเกิน Max")]
        public decimal MachineFlg { get => machineFlg; set => machineFlg = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "PrintFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "PrintFlg : ขนาดข้อมูลเกิน Max")]
        public decimal PrintFlg { get => printFlg; set => printFlg = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "SMTFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "SMTFlg : ขนาดข้อมูลเกิน Max")]
        public decimal SMTFlg { get => sMTFlg; set => sMTFlg = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "ProcessFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "ProcessFlg : ขนาดข้อมูลเกิน Max")]
        public decimal ProcessFlg { get => processFlg; set => processFlg = value; }

        [StringLength(50, ErrorMessage = "PharmacyIPD : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string PharmacyIPD { get => pharmacyIPD; set => pharmacyIPD = value; }

        [StringLength(200, ErrorMessage = "RowID : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string RowID { get => rowID; set => rowID = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDateTime { get => createDateTime; set => createDateTime = value; }

        [StringLength(100, ErrorMessage = "FieldUpdate : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string FieldUpdate { get => fieldUpdate; set => fieldUpdate = value; }

        [StringLength(300, ErrorMessage = "BarcodeByHIS : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string BarcodeByHIS { get => barcodeByHIS; set => barcodeByHIS = value; }

        [StringLength(15, ErrorMessage = "NormalStatus : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string NormalStatus { get => normalStatus; set => normalStatus = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "Status : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "Status : ขนาดข้อมูลเกิน Max")]
        public decimal Status { get => status; set => status = value; }

        ////[StringLength(300, ErrorMessage = "BarcodeByHIS : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        ////public string BarcodeId { get => barcodeId; set => barcodeId = value; }

        #endregion "Properties/ViewModel/Data Validation"

        private System_logfile logs;

        public master_prescription()
        {
            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridViewFullDetail(string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PrescriptionNo,";
            SQL += "dbo.M_Prescription.SeqNo,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.Birthday,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.PrescriptionDate,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime,";
            SQL += "dbo.M_Prescription.BarcodeId,";
            SQL += "dbo.M_Prescription.DrugCd,";
            SQL += "dbo.M_Prescription.DrugName,";
            SQL += "dbo.M_Prescription.DispensedDose,";
            SQL += "dbo.M_Prescription.DispensedTotalDose,";
            SQL += "dbo.M_Prescription.DispensedUnit,";
            SQL += "dbo.M_Prescription.Freq_Counter,";
            SQL += "dbo.M_Prescription.Freq_Desc,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail,";
            SQL += "dbo.M_Prescription.MakeRecTime,";
            SQL += "dbo.M_Prescription.UpDateRecTime,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc1,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc2,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc3,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc4,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc5,";
            SQL += "dbo.M_Prescription.ProcFlg,";
            SQL += "dbo.M_Prescription.DTAFlg,";
            SQL += "dbo.M_Prescription.MachineFlg,";
            SQL += "dbo.M_Prescription.PrintFlg,";
            SQL += "dbo.M_Prescription.SMTFlg,";
            SQL += "dbo.M_Prescription.ProcessFlg,";
            SQL += "dbo.M_Prescription.PharmacyIPD,";
            SQL += "dbo.M_Prescription.RowID,";
            SQL += "dbo.M_Prescription.CreateDateTime,";
            SQL += "dbo.M_Prescription.FieldUpdate, ";
            SQL += "dbo.M_Prescription.NormalStatus, ";
            SQL += "dbo.M_Prescription.f_status ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";

            if ((condition != "") && (condition != null))
            {
                SQL += "WHERE ";
                SQL += "(dbo.M_Prescription.PrescriptionNo LIKE '%" + condition + "%' OR ";
                SQL += "dbo.M_Prescription.PatientId LIKE '%" + condition + "%' OR ";
                SQL += "dbo.M_Prescription.PatientName LIKE '%" + condition + "%') ";
            }
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.PrescriptionNo, ";
            SQL += "dbo.M_Prescription.SeqNo, ";
            SQL += "dbo.M_Prescription.PrescriptionDate ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thanes-hop middle table for Display DataGrid View Detail
        public DataSet GetDispalyFrequencyTakeTimeDataGridViewSelected(ArrayList prescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.BedNo, ";
            SQL += "dbo.M_Prescription.PatientId, ";
            SQL += "dbo.M_Prescription.PatientName, ";
            SQL += "CONVERT(VARCHAR,dbo.M_Prescription.TakeDate,111) AS TakeDate, ";
            SQL += "dbo.M_Prescription.TakeTime, ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail, ";
            SQL += "dbo.M_Prescription.DrugName, ";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc1, ";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS, ";
            SQL += "dbo.M_Prescription.NormalStatus ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            if (prescriptionno.Count == 1)
            {
                foreach (Object prescriptionnoIn in prescriptionno)
                    SQL += "dbo.M_Prescription.RowID ='" + prescriptionnoIn + "' ";
            }
            else if ((prescriptionno.Count != 0) && (prescriptionno != null))
            {
                string presno = "";
                int i = 0;
                foreach (Object prescriptionnoIn in prescriptionno)
                {
                    i++;
                    if (prescriptionno.Count != i)
                    {
                        presno += "'" + prescriptionnoIn + "',";
                    }
                    else
                    {
                        presno += "'" + prescriptionnoIn + "'";
                    }
                }
                SQL += "dbo.M_Prescription.RowID IN (" + presno + ") ";
            }

            SQL += "ORDER BY dbo.M_Prescription.BedNo,dbo.M_Prescription.TakeDate, dbo.M_Prescription.TakeTime,dbo.M_Prescription.DrugName ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetPriorityForGraph(string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PriorityCd ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";

            if ((condition != "") && (condition != null))
            {
                SQL += "WHERE ";
                SQL += "(dbo.M_Prescription.PrescriptionNo LIKE '%" + condition + "%' OR ";
                SQL += "dbo.M_Prescription.PatientId LIKE '%" + condition + "%' OR ";
                SQL += "dbo.M_Prescription.PatientName LIKE '%" + condition + "%') ";
            }
            SQL += "GROUP BY ";
            SQL += "dbo.M_Prescription.PriorityCd ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayGanttChartMedicationPlanData(string wardcode, string priority)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo ";
            //SQL += "dbo.M_Prescription.TakeDate ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";

            if (wardcode != null)
            {
                SQL += "WHERE ";
                SQL += "dbo.M_Prescription.WardCd ='" + wardcode + "' ";
                //SQL += "AND ";
               // SQL += "dbo.M_Prescription.PriorityCd ='" + priority + "' ";
            }
            else
            {
                //SQL += "WHERE ";
                //SQL += "dbo.M_Prescription.PriorityCd ='" + priority + "' ";
            }

            SQL += "GROUP BY ";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo ";
           // SQL += "dbo.M_Prescription.TakeDate ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.BedNo ASC";
          //  SQL += "dbo.M_Prescription.TakeDate ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayGanttChartMedicationPlanDataDetailBar(string PatientId, string TakeDate)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "* ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PatientId =@PatientId ";
           // SQL += "AND ";
           // SQL += "CONVERT(VARCHAR,TakeDate,112) =@TakeDate ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
               // cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayGanttChartMedicationPlanDataDetailBar(string PatientId, string TakeDate, string TakeTime)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "* ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PatientId =@PatientId ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,TakeDate,112) =@TakeDate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code =@TakeTime ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.TakeTime ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", TakeTime));
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayDataToolTipDetail(string prescription, decimal seqno, string drugname, string takedate, string taketime)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PrescriptionNo,";
            SQL += "dbo.M_Prescription.SeqNo,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.Birthday,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.PrescriptionDate,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime,";
            SQL += "dbo.M_Prescription.BarcodeId,";
            SQL += "dbo.M_Prescription.DrugCd,";
            SQL += "dbo.M_Prescription.DrugName,";
            SQL += "dbo.M_Prescription.DispensedDose,";
            SQL += "dbo.M_Prescription.DispensedTotalDose,";
            SQL += "dbo.M_Prescription.DispensedUnit,";
            SQL += "dbo.M_Prescription.Freq_Counter,";
            SQL += "dbo.M_Prescription.Freq_Desc,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail,";
            SQL += "dbo.M_Prescription.MakeRecTime,";
            SQL += "dbo.M_Prescription.UpDateRecTime,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc1,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc2,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc3,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc4,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc5,";
            SQL += "dbo.M_Prescription.ProcFlg,";
            SQL += "dbo.M_Prescription.DTAFlg,";
            SQL += "dbo.M_Prescription.MachineFlg,";
            SQL += "dbo.M_Prescription.PrintFlg,";
            SQL += "dbo.M_Prescription.SMTFlg,";
            SQL += "dbo.M_Prescription.ProcessFlg,";
            SQL += "dbo.M_Prescription.PharmacyIPD,";
            SQL += "dbo.M_Prescription.RowID,";
            SQL += "dbo.M_Prescription.CreateDateTime,";
            SQL += "dbo.M_Prescription.FieldUpdate ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.FieldUpdate =@FieldUpdate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.DrugName =@DrugName ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,dbo.M_Prescription.TakeDate,112) =@TakeDate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code =@TakeTime ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.SeqNo =@SeqNo ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", prescription));
                cmd.Parameters.Add(new SqlParameter("@DrugName", drugname));
                cmd.Parameters.Add(new SqlParameter("@SeqNo", seqno));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", takedate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", taketime));
                return conn.FillSQL(cmd);
            }
        }

        public int GetCountItemProFlg()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(M_Prescription.ProcFlg) AS Items ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.ProcFlg IN('1','2') ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }

        public DataSet GetGroupByTakeTime(bool status,string patentId, string prescription)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            if(status == true)
            {
                SQL += "WHERE ";
                SQL += "dbo.M_Prescription.PatientId =@PatientId ";
                SQL += "AND ";
                SQL += "dbo.M_Prescription.PrescriptionNoHIS =@PrescriptionNoHIS ";
                SQL += "AND ";
                SQL += "dbo.M_Prescription.MachineFlg ='2' ";
            }
            SQL += "GROUP BY ";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientId", patentId));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", prescription));
                return conn.FillSQL(cmd);
            }
        }

        public bool UpdateSeqOfMaxPerHn(string hn, string prescription, string takedate ,string taketime ,string SeqOfMax)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_Prescription SET ";
            SQL += "dbo.M_Prescription.SeqNo =@SeqNo ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PatientId =@PatientId ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS =@PrescriptionNoHIS ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,dbo.M_Prescription.TakeDate,112) =@TakeDate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.TakeTime =@TakeTime ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientId", hn));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", prescription));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", takedate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", taketime));
                cmd.Parameters.Add(new SqlParameter("@SeqNo", SeqOfMax));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool InsertDataPrescription()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_Prescription(";
            SQL += "dbo.M_Prescription.PrescriptionNo,";
            SQL += "dbo.M_Prescription.SeqNo,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.Birthday,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.PrescriptionDate,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime,";
            SQL += "dbo.M_Prescription.BarcodeId,";
            SQL += "dbo.M_Prescription.DrugCd,";
            SQL += "dbo.M_Prescription.DrugName,";
            SQL += "dbo.M_Prescription.DispensedDose,";
            SQL += "dbo.M_Prescription.DispensedTotalDose,";
            SQL += "dbo.M_Prescription.DispensedUnit,";
            SQL += "dbo.M_Prescription.Freq_Counter,";
            SQL += "dbo.M_Prescription.Freq_Desc,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail,";
            SQL += "dbo.M_Prescription.MakeRecTime,";
            SQL += "dbo.M_Prescription.UpDateRecTime,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc1,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc2,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc3,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc4,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc5,";
            SQL += "dbo.M_Prescription.ProcFlg,";
            SQL += "dbo.M_Prescription.DTAFlg,";
            SQL += "dbo.M_Prescription.MachineFlg,";
            SQL += "dbo.M_Prescription.PrintFlg,";
            SQL += "dbo.M_Prescription.SMTFlg,";
            SQL += "dbo.M_Prescription.ProcessFlg,";
            SQL += "dbo.M_Prescription.PharmacyIPD,";
            SQL += "dbo.M_Prescription.RowID,";
            SQL += "dbo.M_Prescription.CreateDateTime,";
            SQL += "dbo.M_Prescription.FieldUpdate, ";
            SQL += "dbo.M_Prescription.BarcodeByHIS, "; 
            SQL += "dbo.M_Prescription.NormalStatus, ";
            SQL += "dbo.M_Prescription.f_status) ";
            SQL += "VALUES(";
            SQL += "@PrescriptionNo,";
            SQL += "@SeqNo,";
            SQL += "@PrescriptionNoHIS,";
            SQL += "@PriorityCd,";
            SQL += "@PatientId,";
            SQL += "@PatientName,";
            SQL += "@PatientAn,";
            SQL += "@Birthday,";
            SQL += "@WardCd,";
            SQL += "@WardName,";
            SQL += "@RoomNo,";
            SQL += "@BedNo,";
            SQL += "@PrescriptionDate,";
            SQL += "@TakeDate,";
            SQL += "@TakeTime,";
            SQL += "@BarcodeId,";
            SQL += "@DrugCd,";
            SQL += "@DrugName,";
            SQL += "@DispensedDose,";
            SQL += "@DispensedTotalDose,";
            SQL += "@DispensedUnit,";
            SQL += "@Freq_Counter,";
            SQL += "@Freq_Desc,";
            SQL += "@Freq_Desc_Detail_Code,";
            SQL += "@Freq_Desc_Detail,";
            SQL += "@MakeRecTime,";
            SQL += "@UpDateRecTime,";
            SQL += "@FreePrintItem_Presc1,";
            SQL += "@FreePrintItem_Presc2,";
            SQL += "@FreePrintItem_Presc3,";
            SQL += "@FreePrintItem_Presc4,";
            SQL += "@FreePrintItem_Presc5,";
            SQL += "@ProcFlg,";
            SQL += "@DTAFlg,";
            SQL += "@MachineFlg,";
            SQL += "@PrintFlg,";
            SQL += "@SMTFlg,";
            SQL += "@ProcessFlg,";
            SQL += "@PharmacyIPD,";
            SQL += "@RowID,";
            SQL += "@CreateDateTime,";
            SQL += "@FieldUpdate,";
           SQL += "@BarcodeByHIS,"; 
            SQL += "@NormalStatus,";
            SQL += "@f_status)";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNo", PrescriptionNo));
                cmd.Parameters.Add(new SqlParameter("@SeqNo", SeqNo));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", PrescriptionNoHIS));
                cmd.Parameters.Add(new SqlParameter("@PriorityCd", PriorityCd));
                cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
                cmd.Parameters.Add(new SqlParameter("@PatientName", PatientName));
                cmd.Parameters.Add(new SqlParameter("@PatientAn", PatientAn));
                cmd.Parameters.Add(new SqlParameter("@Birthday", BrithDay));
                cmd.Parameters.Add(new SqlParameter("@WardCd", WardCd));
                cmd.Parameters.Add(new SqlParameter("@WardName", WardName));
                cmd.Parameters.Add(new SqlParameter("@RoomNo", RoomNo));
                cmd.Parameters.Add(new SqlParameter("@BedNo", BedNo));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionDate", PrescriptionDate));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", TakeTime));
                cmd.Parameters.Add(new SqlParameter("@BarcodeId", BarcodeId));
                cmd.Parameters.Add(new SqlParameter("@DrugCd", DrugCd));
                cmd.Parameters.Add(new SqlParameter("@DrugName", DrugName));
                cmd.Parameters.Add(new SqlParameter("@DispensedDose", DispensedDose));
                cmd.Parameters.Add(new SqlParameter("@DispensedTotalDose", DispensedTotalDose));
                cmd.Parameters.Add(new SqlParameter("@DispensedUnit", DispensedUnit));
                cmd.Parameters.Add(new SqlParameter("@Freq_Counter", FreqCounter));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc", FreqDesc));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail_Code", FreqDescDetailCode));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail", FreqDescDetail));
                cmd.Parameters.Add(new SqlParameter("@MakeRecTime", MakeRecTime));
                cmd.Parameters.Add(new SqlParameter("@UpDateRecTime", UpDateRecTime));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc1", FreePrintItemPres1));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc2", FreePrintItemPres2));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc3", FreePrintItemPres3));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc4", FreePrintItemPres4));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc5", FreePrintItemPres5));
                cmd.Parameters.Add(new SqlParameter("@ProcFlg", ProcFlg));
                cmd.Parameters.Add(new SqlParameter("@DTAFlg", DTAFlg));
                cmd.Parameters.Add(new SqlParameter("@MachineFlg", MachineFlg));
                cmd.Parameters.Add(new SqlParameter("@PrintFlg", PrintFlg));
                cmd.Parameters.Add(new SqlParameter("@SMTFlg", SMTFlg));
                cmd.Parameters.Add(new SqlParameter("@ProcessFlg", ProcessFlg));
                cmd.Parameters.Add(new SqlParameter("@PharmacyIPD", PharmacyIPD));
                cmd.Parameters.Add(new SqlParameter("@RowID", RowID));
                cmd.Parameters.Add(new SqlParameter("@CreateDateTime", CreateDateTime));
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", FieldUpdate));
               cmd.Parameters.Add(new SqlParameter("@BarcodeByHIS", BarcodeByHIS));
                cmd.Parameters.Add(new SqlParameter("@NormalStatus", NormalStatus));
                cmd.Parameters.Add(new SqlParameter("@f_status", Status));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
        public bool InsertDataPrescriptionVCH()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.M_Prescription(";
            SQL += "dbo.M_Prescription.PrescriptionNo,";
            SQL += "dbo.M_Prescription.SeqNo,";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS,";
            SQL += "dbo.M_Prescription.PriorityCd,";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.Birthday,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.PrescriptionDate,";
            SQL += "dbo.M_Prescription.TakeDate,";
            SQL += "dbo.M_Prescription.TakeTime,";
            SQL += "dbo.M_Prescription.BarcodeId,";
            SQL += "dbo.M_Prescription.DrugCd,";
            SQL += "dbo.M_Prescription.DrugName,";
            SQL += "dbo.M_Prescription.DispensedDose,";
            SQL += "dbo.M_Prescription.DispensedTotalDose,";
            SQL += "dbo.M_Prescription.DispensedUnit,";
            SQL += "dbo.M_Prescription.Freq_Counter,";
            SQL += "dbo.M_Prescription.Freq_Desc,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code,";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail,";
            SQL += "dbo.M_Prescription.MakeRecTime,";
            SQL += "dbo.M_Prescription.UpDateRecTime,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc1,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc2,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc3,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc4,";
            SQL += "dbo.M_Prescription.FreePrintItem_Presc5,";
            SQL += "dbo.M_Prescription.ProcFlg,";
            SQL += "dbo.M_Prescription.DTAFlg,";
            SQL += "dbo.M_Prescription.MachineFlg,";
            SQL += "dbo.M_Prescription.PrintFlg,";
            SQL += "dbo.M_Prescription.SMTFlg,";
            SQL += "dbo.M_Prescription.ProcessFlg,";
            SQL += "dbo.M_Prescription.PharmacyIPD,";
            SQL += "dbo.M_Prescription.RowID,";
            SQL += "dbo.M_Prescription.CreateDateTime,";
            SQL += "dbo.M_Prescription.FieldUpdate, ";
            SQL += "dbo.M_Prescription.BarcodeByHIS, "; // sakda use VCH only
            SQL += "dbo.M_Prescription.NormalStatus, ";
            SQL += "dbo.M_Prescription.f_status) ";
            SQL += "VALUES(";
            SQL += "@PrescriptionNo,";
            SQL += "@SeqNo,";
            SQL += "@PrescriptionNoHIS,";
            SQL += "@PriorityCd,";
            SQL += "@PatientId,";
            SQL += "@PatientName,";
            SQL += "@PatientAn,";
            SQL += "@Birthday,";
            SQL += "@WardCd,";
            SQL += "@WardName,";
            SQL += "@RoomNo,";
            SQL += "@BedNo,";
            SQL += "@PrescriptionDate,";
            SQL += "@TakeDate,";
            SQL += "@TakeTime,";
            SQL += "@BarcodeId,";
            SQL += "@DrugCd,";
            SQL += "@DrugName,";
            SQL += "@DispensedDose,";
            SQL += "@DispensedTotalDose,";
            SQL += "@DispensedUnit,";
            SQL += "@Freq_Counter,";
            SQL += "@Freq_Desc,";
            SQL += "@Freq_Desc_Detail_Code,";
            SQL += "@Freq_Desc_Detail,";
            SQL += "@MakeRecTime,";
            SQL += "@UpDateRecTime,";
            SQL += "@FreePrintItem_Presc1,";
            SQL += "@FreePrintItem_Presc2,";
            SQL += "@FreePrintItem_Presc3,";
            SQL += "@FreePrintItem_Presc4,";
            SQL += "@FreePrintItem_Presc5,";
            SQL += "@ProcFlg,";
            SQL += "@DTAFlg,";
            SQL += "@MachineFlg,";
            SQL += "@PrintFlg,";
            SQL += "@SMTFlg,";
            SQL += "@ProcessFlg,";
            SQL += "@PharmacyIPD,";
            SQL += "@RowID,";
            SQL += "@CreateDateTime,";
            SQL += "@FieldUpdate,";
            SQL += "@BarcodeByHIS,"; // sakda use VCH only
            SQL += "@NormalStatus,";
            SQL += "@f_status)";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNo", PrescriptionNo));
                cmd.Parameters.Add(new SqlParameter("@SeqNo", SeqNo));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", PrescriptionNoHIS));
                cmd.Parameters.Add(new SqlParameter("@PriorityCd", PriorityCd));
                cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
                cmd.Parameters.Add(new SqlParameter("@PatientName", PatientName));
                cmd.Parameters.Add(new SqlParameter("@PatientAn", PatientAn));
                cmd.Parameters.Add(new SqlParameter("@Birthday", BrithDay));
                cmd.Parameters.Add(new SqlParameter("@WardCd", WardCd));
                cmd.Parameters.Add(new SqlParameter("@WardName", WardName));
                cmd.Parameters.Add(new SqlParameter("@RoomNo", RoomNo));
                cmd.Parameters.Add(new SqlParameter("@BedNo", BedNo));
                cmd.Parameters.Add(new SqlParameter("@PrescriptionDate", PrescriptionDate));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", TakeTime));
                cmd.Parameters.Add(new SqlParameter("@BarcodeId", BarcodeId));
                cmd.Parameters.Add(new SqlParameter("@DrugCd", DrugCd));
                cmd.Parameters.Add(new SqlParameter("@DrugName", DrugName));
                cmd.Parameters.Add(new SqlParameter("@DispensedDose", DispensedDose));
                cmd.Parameters.Add(new SqlParameter("@DispensedTotalDose", DispensedTotalDose));
                cmd.Parameters.Add(new SqlParameter("@DispensedUnit", DispensedUnit));
                cmd.Parameters.Add(new SqlParameter("@Freq_Counter", FreqCounter));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc", FreqDesc));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail_Code", FreqDescDetailCode));
                cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail", FreqDescDetail));
                cmd.Parameters.Add(new SqlParameter("@MakeRecTime", MakeRecTime));
                cmd.Parameters.Add(new SqlParameter("@UpDateRecTime", UpDateRecTime));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc1", FreePrintItemPres1));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc2", FreePrintItemPres2));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc3", FreePrintItemPres3));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc4", FreePrintItemPres4));
                cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc5", FreePrintItemPres5));
                cmd.Parameters.Add(new SqlParameter("@ProcFlg", ProcFlg));
                cmd.Parameters.Add(new SqlParameter("@DTAFlg", DTAFlg));
                cmd.Parameters.Add(new SqlParameter("@MachineFlg", MachineFlg));
                cmd.Parameters.Add(new SqlParameter("@PrintFlg", PrintFlg));
                cmd.Parameters.Add(new SqlParameter("@SMTFlg", SMTFlg));
                cmd.Parameters.Add(new SqlParameter("@ProcessFlg", ProcessFlg));
                cmd.Parameters.Add(new SqlParameter("@PharmacyIPD", PharmacyIPD));
                cmd.Parameters.Add(new SqlParameter("@RowID", RowID));
                cmd.Parameters.Add(new SqlParameter("@CreateDateTime", CreateDateTime));
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", FieldUpdate));
                cmd.Parameters.Add(new SqlParameter("@BarcodeByHIS", BarcodeByHIS));// sakda use VCH only
                cmd.Parameters.Add(new SqlParameter("@NormalStatus", NormalStatus));
                cmd.Parameters.Add(new SqlParameter("@f_status", Status));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
        public DateTime GetDateStartMedicationPlanningChart()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CONVERT(DATETIME,CONCAT(CONVERT(VARCHAR,MIN(M_Prescription.TakeDate), 110 ) ,' ', CONCAT(SUBSTRING(MIN ( M_Prescription.Freq_Desc_Detail_Code ), 0, 3),':', SUBSTRING(MIN ( M_Prescription.Freq_Desc_Detail_Code ), 3, 2))),120) AS StartTime ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (DateTime)conn.ExecuteScalarSQL(cmd);
            }
        }

        public DateTime GetDateStopMedicationPlanningChart()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CONVERT(DATETIME,CONCAT(CONVERT(VARCHAR, MAX(M_Prescription.TakeDate), 110 ) ,' ', CONCAT(SUBSTRING(MAX (M_Prescription.Freq_Desc_Detail_Code ), 0, 3),':', SUBSTRING(MAX ( M_Prescription.Freq_Desc_Detail_Code ), 3, 2))),120) AS StopTime ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (DateTime)conn.ExecuteScalarSQL(cmd);
            }
        }

        public DateTime GetDateStartMedPlanChart(string Prescription)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CONVERT(DATETIME,CONCAT(CONVERT(VARCHAR, M_Prescription.TakeDate, 110 ) ,' ', CONCAT(SUBSTRING(MIN ( M_Prescription.Freq_Desc_Detail_Code ), 0, 3),':', SUBSTRING(MIN ( M_Prescription.Freq_Desc_Detail_Code ), 3, 2))),120) AS StartTime ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "M_Prescription.FieldUpdate =@FieldUpdate ";
            SQL += "GROUP BY ";
            SQL += "M_Prescription.TakeDate ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", Prescription));
                return (DateTime)conn.ExecuteScalarSQL(cmd);
            }
        }

        public DateTime GetDateStopMedPlanChart(string Prescription)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CONVERT(DATETIME,CONCAT(CONVERT(VARCHAR, M_Prescription.TakeDate, 110 ) ,' ', CONCAT(SUBSTRING(MAX ( M_Prescription.Freq_Desc_Detail_Code ), 0, 3),':', SUBSTRING(MAX ( M_Prescription.Freq_Desc_Detail_Code ), 3, 2))),120) AS StopTime ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "M_Prescription.FieldUpdate =@FieldUpdate ";
            SQL += "GROUP BY ";
            SQL += "M_Prescription.TakeDate ";
            SQL += "ORDER BY ";
            SQL += "M_Prescription.TakeDate DESC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", Prescription));
                return (DateTime)conn.ExecuteScalarSQL(cmd);
            }
        }

        public bool DeleteByHnReady()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.ProcFlg = '0' ";
          
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool DeleteByPrescripton(string presc,string hn)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "M_Prescription.FieldUpdate =@FieldUpdate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.PatientId =@PatientId ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", presc));
                cmd.Parameters.Add(new SqlParameter("@PatientId", hn));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatusByPrescriptionno(string presctiptionno, string drugcode, string rowId, decimal procflg,decimal processflg)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_Prescription SET ";
            SQL += "dbo.M_Prescription.ProcFlg =@ProcFlg, ";
            SQL += "dbo.M_Prescription.ProcessFlg =@ProcessFlg ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS =@PrescriptionNoHIS ";

            if(drugcode != null)
            {
                SQL += "AND ";
                SQL += "dbo.M_Prescription.DrugCd ='"+ drugcode + "'" ;
            }
           

            if(rowId != null)
            {
                SQL += "AND ";
                SQL += "dbo.M_Prescription.RowID ='"+ rowId +"'";
            }

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", presctiptionno));
                cmd.Parameters.Add(new SqlParameter("@ProcFlg", procflg));
                cmd.Parameters.Add(new SqlParameter("@ProcessFlg", processflg));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateStatusByPrescriptionno(string presctiptionno, string hn, string drugcode, decimal procFlg)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_Prescription SET ";
            SQL += "dbo.M_Prescription.ProcFlg =@ProcFlg ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS =@PrescriptionNoHIS ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.PatientId =@PatientId ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.DrugCd =@DrugCd ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.ProcFlg <>1 ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", presctiptionno));
                cmd.Parameters.Add(new SqlParameter("@PatientId", hn));
                cmd.Parameters.Add(new SqlParameter("@DrugCd", drugcode));
                cmd.Parameters.Add(new SqlParameter("@ProcFlg", procFlg));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }


        public bool UpdateStatusByPrescriptionNoAndDrugCode(string presctiptionno, string drugcode, decimal procflg, decimal processflg)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.M_Prescription SET ";
            SQL += "dbo.M_Prescription.ProcFlg =@ProcFlg, ";
            SQL += "dbo.M_Prescription.ProcessFlg =@ProcessFlg ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PrescriptionNoHIS =@PrescriptionNoHIS ";

            if (drugcode != null)
            {
                SQL += "AND ";
                SQL += "dbo.M_Prescription.DrugCd ='" + drugcode + "'";
            }

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PrescriptionNoHIS", presctiptionno));
                cmd.Parameters.Add(new SqlParameter("@ProcFlg", procflg));
                cmd.Parameters.Add(new SqlParameter("@ProcessFlg", processflg));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public int GetCountData()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.M_Prescription.PrescriptionNo)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }

        public int GetMaxDataRow()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "MAX(dbo.M_Prescription.PrescriptionNo)As MaxItems ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}