using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;


namespace ConHIS
{
    internal class Thaneshopmiddle_VICHAIYUT
    {
        //filed and properties
        private string prescriptionNo;               //Field 01
        private decimal seq;                         //Field 02
        private decimal seqMax;                      //Field 03
        private string runningNo;                    //Field 04
        private string prescriptionDate;             //Field 05
        private DateTime orderCreateDate;            //Field 06
        private string orderTargetDate;              //Field 07
        private string orderTargetTime;              //Field 08
        private string pharmacyLocationCode;         //Field 09
        private string pharmacyLocationDesc;         //Field 10
        private string userOrderBy;                  //Field 11
        private string userAcceptBy;                 //Field 12
        private DateTime orderAcceptDate;            //Field 13
        private string orderAcceptFromIP;            //Field 14
        private decimal dispenseStatus;              //Field 15
        private decimal status;                      //Field 16
        private decimal printStatus;                 //Field 17
        private string hn;                           //Field 18
        private string an;                           //Field 19
        private string vn;                           //Field 20
        private string patientName;                  //Field 21
        private string sex;                          //Field 22
        private DateTime patientDOB;                 //Field 23
        private string wardCode;                     //Field 24
        private string wardDesc;                     //Field 25
        private string roomCode;                     //Field 26
        private string roomDesc;                     //Field 27
        private string bedCode;                      //Field 28
        private string drugAllergy;                  //Field 29
        private string doctorCode;                   //Field 30
        private string doctorName;                   //Field 31
        private decimal toMachineNo;                 //Field 32
        private string orderItemCode;                //Field 33
        private string orderItemName;                //Field 34
        private decimal orderQty;                    //Field 35
        private string orderUnitCode;                //Field 36
        private string orderUnitDesc;                //Field 37
        private decimal dosage;                      //Field 38
        private string dosageUnit;                   //Field 39
        private string binLocation;                  //Field 40
        private string itemIdentify;                 //Field 41
        private string itemLotNo;                    //Field 42
        private DateTime itemLotExpire;              //Field 43
        private string instructionCode;              //Field 44
        private string instructionDesc;              //Field 45
        private string drugFormCode;                 //Field 46
        private string drugFormDesc;                 //Field 47
        private decimal heighAlretDrug;              //Field 48
        private decimal pRNSTAT;                     //Field 49
        private string priorityCode;                 //Field 50
        private string priorityDesc;                 //Field 51
        private string frequencyCode;                //Field 52
        private string frequencyDesc;                //Field 53
        private string frequencyTime;                //Field 54
        private string dosageDispense;               //Field 55
        private decimal language;                    //Field 56
        private decimal durationCode;                //Field 57
        private string noteProcessing;               //Field 58
        private string barcodeByHIS;                 //Field 59
        private string excludeIPFill;                //Field 60
        private DateTime lastModified;               //Field 61
        private string comment;                      //Field 62
        private decimal drugBagSplit;                //Field 63
        private decimal oPDAdminStatus;              //Field 64
        private DateTime oPDAdminDateTime;           //Field 65
        private string oPDAdminBy;                   //Field 66
        private string oPDAdminRemark;               //Field 67
        private string oPDAdminLocation;             //Field 68
        private decimal oPDAdminContinue;            //Field 69
        private string rowID;                        //Field 70

        //Properties

        #region "Properties/ViewModel/Data Validation"

        [Required(ErrorMessage = "PrescriptionNo : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string PrescriptionNo { get => prescriptionNo; set => prescriptionNo = value; }

        [Required(ErrorMessage = "Seq : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "Seq : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 999999, ErrorMessage = "Seq : ขนาดข้อมูลเกิน Max")]
        public decimal Seq { get => seq; set => seq = value; }

        [Required(ErrorMessage = "SeqMax : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "SeqMax : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 999999, ErrorMessage = "Seq : ขนาดข้อมูลเกิน Max")]
        public decimal SeqMax { get => seqMax; set => seqMax = value; }

        [Required(ErrorMessage = "RunningNo : ไม่พบข้อมูล")]
        [StringLength(600, ErrorMessage = "RunningNo : ขนาดข้อมูลเกิน 600 ตัวอักษร ")]
        public string RunningNo { get => runningNo; set => runningNo = value; }

        [Required(ErrorMessage = "PrescriptionDate : ไม่พบข้อมูล")]
        [RegularExpression("([0-9]+)", ErrorMessage = "PrescriptionDate : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [StringLength(10, ErrorMessage = "PrescriptionDate : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }

        [Required(ErrorMessage = "OrderCreateDate : ไม่พบข้อมูล")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime OrderCreateDate { get => orderCreateDate; set => orderCreateDate = value; }

        [StringLength(10, ErrorMessage = "OrderTargetDate : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string OrderTargetDate { get => orderTargetDate; set => orderTargetDate = value; }

        [StringLength(10, ErrorMessage = "OrderTargetTime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string OrderTargetTime { get => orderTargetTime; set => orderTargetTime = value; }

        [StringLength(20, ErrorMessage = "PharmacyLocationCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string PharmacyLocationCode { get => pharmacyLocationCode; set => pharmacyLocationCode = value; }

        [StringLength(200, ErrorMessage = "PharmacyLocationDesc : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string PharmacyLocationDesc { get => pharmacyLocationDesc; set => pharmacyLocationDesc = value; }

        [StringLength(100, ErrorMessage = "UserOrderBy : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string UserOrderBy { get => userOrderBy; set => userOrderBy = value; }

        [StringLength(100, ErrorMessage = "UserAcceptBy : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string UserAcceptBy { get => userAcceptBy; set => userAcceptBy = value; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime OrderAcceptDate { get => orderAcceptDate; set => orderAcceptDate = value; }

        [StringLength(15, ErrorMessage = "OrderAcceptFromIP : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string OrderAcceptFromIP { get => orderAcceptFromIP; set => orderAcceptFromIP = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispenseStatus : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "DispenseStatus : ขนาดข้อมูลเกิน Max")]
        public decimal DispenseStatus { get => dispenseStatus; set => dispenseStatus = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "Status : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "Status : ขนาดข้อมูลเกิน Max")]
        public decimal Status { get => status; set => status = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "PrintStatus : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "PrintStatus : ขนาดข้อมูลเกิน Max")]
        public decimal PrintStatus { get => printStatus; set => printStatus = value; }

        [Required(ErrorMessage = "Hn : ไม่พบข้อมูล")]
        [StringLength(15, ErrorMessage = "Hn : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string Hn { get => hn; set => hn = value; }

        [StringLength(15, ErrorMessage = "An : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string An { get => an; set => an = value; }

        [StringLength(15, ErrorMessage = "Vn : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string Vn { get => vn; set => vn = value; }

        [Required(ErrorMessage = "PatientName : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "PatientName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string PatientName { get => patientName; set => patientName = value; }

        [StringLength(2, ErrorMessage = "Sex : ขนาดข้อมูลเกิน 2 ตัวอักษร ")]
        public string Sex { get => sex; set => sex = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PatientDOB { get => patientDOB; set => patientDOB = value; }

        [Required(ErrorMessage = "WardCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "WardCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string WardCode { get => wardCode; set => wardCode = value; }

        [StringLength(40, ErrorMessage = "WardDesc : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string WardDesc { get => wardDesc; set => wardDesc = value; }

        [StringLength(20, ErrorMessage = "RoomCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string RoomCode { get => roomCode; set => roomCode = value; }

        [StringLength(100, ErrorMessage = "RoomDesc : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string RoomDesc { get => roomDesc; set => roomDesc = value; }

        [StringLength(20, ErrorMessage = "BedCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string BedCode { get => bedCode; set => bedCode = value; }

        //[StringLength(200, ErrorMessage = "DrugAllergy : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string DrugAllergy { get => drugAllergy; set => drugAllergy = value; }

        [StringLength(10, ErrorMessage = "DoctorCode : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string DoctorCode { get => doctorCode; set => doctorCode = value; }

        [StringLength(100, ErrorMessage = "DoctorName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string DoctorName { get => doctorName; set => doctorName = value; }

        [Required(ErrorMessage = "ToMachineNo : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "ToMachineNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "ToMachineNo : ขนาดข้อมูลเกิน Max")]
        public decimal ToMachineNo { get => toMachineNo; set => toMachineNo = value; }

        [Required(ErrorMessage = "OrderItemCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "OrderItemCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderItemCode { get => orderItemCode; set => orderItemCode = value; }

        [Required(ErrorMessage = "OrderItemName : ไม่พบข้อมูล")]
        [StringLength(100, ErrorMessage = "OrderItemName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OrderItemName { get => orderItemName; set => orderItemName = value; }

        [Required(ErrorMessage = "OrderQty : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "OrderQty : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99999999.99, ErrorMessage = "OrderQty : ขนาดข้อมูลเกิน Max")]
        public decimal OrderQty { get => orderQty; set => orderQty = value; }

        [Required(ErrorMessage = "OrderUnitCode : ไม่พบข้อมูล")]
        [StringLength(20, ErrorMessage = "OrderUnitCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderUnitCode { get => orderUnitCode; set => orderUnitCode = value; }

        [StringLength(20, ErrorMessage = "OrderUnitDesc : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string OrderUnitDesc { get => orderUnitDesc; set => orderUnitDesc = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "Dosage : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99999999.99, ErrorMessage = "Dosage : ขนาดข้อมูลเกิน Max")]
        public decimal Dosage { get => dosage; set => dosage = value; }

        [StringLength(20, ErrorMessage = "DosageUnit : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string DosageUnit { get => dosageUnit; set => dosageUnit = value; }

        [StringLength(20, ErrorMessage = "BinLocation : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string BinLocation { get => binLocation; set => binLocation = value; }

        [StringLength(100, ErrorMessage = "ItemIdentify : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string ItemIdentify { get => itemIdentify; set => itemIdentify = value; }

        [StringLength(10, ErrorMessage = "ItemLotNo : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string ItemLotNo { get => itemLotNo; set => itemLotNo = value; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ItemLotExpire { get => itemLotExpire; set => itemLotExpire = value; }

        [StringLength(20, ErrorMessage = "InstructionCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string InstructionCode { get => instructionCode; set => instructionCode = value; }

        [StringLength(100, ErrorMessage = "InstructionDesc : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string InstructionDesc { get => instructionDesc; set => instructionDesc = value; }

        [StringLength(20, ErrorMessage = "DrugFormCode : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string DrugFormCode { get => drugFormCode; set => drugFormCode = value; }

        [StringLength(100, ErrorMessage = "DrugFormDesc : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string DrugFormDesc { get => drugFormDesc; set => drugFormDesc = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "HeighAlretDrug : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "HeighAlretDrug : ขนาดข้อมูลเกิน Max")]
        public decimal HeighAlretDrug { get => heighAlretDrug; set => heighAlretDrug = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "PRNSTAT : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "PRNSTAT : ขนาดข้อมูลเกิน Max")]
        public decimal PRNSTAT { get => pRNSTAT; set => pRNSTAT = value; }

        [Required(ErrorMessage = "PriorityCode : ไม่พบข้อมูล")]
        [StringLength(2, ErrorMessage = "PriorityCode : ขนาดข้อมูลเกิน 2 ตัวอักษร ")]
        public string PriorityCode { get => priorityCode; set => priorityCode = value; }

        [StringLength(20, ErrorMessage = "PriorityDesc : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string PriorityDesc { get => priorityDesc; set => priorityDesc = value; }

        [StringLength(120, ErrorMessage = "FrequencyCode : ขนาดข้อมูลเกิน 120 ตัวอักษร ")]
        public string FrequencyCode { get => frequencyCode; set => frequencyCode = value; }

        [StringLength(500, ErrorMessage = "FrequencyDesc : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string FrequencyDesc { get => frequencyDesc; set => frequencyDesc = value; }

        [StringLength(100, ErrorMessage = "FrequencyTime : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string FrequencyTime { get => frequencyTime; set => frequencyTime = value; }

        [StringLength(100, ErrorMessage = "DosageDispense : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string DosageDispense { get => dosageDispense; set => dosageDispense = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "Language : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "Language : ขนาดข้อมูลเกิน Max")]
        public decimal Language { get => language; set => language = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "DurationCode : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "DurationCode : ขนาดข้อมูลเกิน Max")]
        public decimal DurationCode { get => durationCode; set => durationCode = value; }

        [StringLength(200, ErrorMessage = "NoteProcessing : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string NoteProcessing { get => noteProcessing; set => noteProcessing = value; }

        [StringLength(200, ErrorMessage = "BarcodeByHIS : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string BarcodeByHIS { get => barcodeByHIS; set => barcodeByHIS = value; }

        [StringLength(10, ErrorMessage = "ExcludIPFill : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string ExcludeIPFill { get => excludeIPFill; set => excludeIPFill = value; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime LastModified { get => lastModified; set => lastModified = value; }

        [StringLength(200, ErrorMessage = "Comment : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string Comment { get => comment; set => comment = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "DrugBagSplit : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "DrugBagSplit : ขนาดข้อมูลเกิน Max")]
        public decimal DrugBagSplit { get => drugBagSplit; set => drugBagSplit = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "OPDAdminStatus : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "OPDAdminStatus : ขนาดข้อมูลเกิน Max")]
        public decimal OPDAdminStatus { get => oPDAdminStatus; set => oPDAdminStatus = value; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime OPDAdminDateTime { get => oPDAdminDateTime; set => oPDAdminDateTime = value; }

        [StringLength(100, ErrorMessage = "OPDAdminBy : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OPDAdminBy { get => oPDAdminBy; set => oPDAdminBy = value; }

        [StringLength(200, ErrorMessage = "OPDAdminRemark : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string OPDAdminRemark { get => oPDAdminRemark; set => oPDAdminRemark = value; }

        [StringLength(100, ErrorMessage = "OPDAdminLocation : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string OPDAdminLocation { get => oPDAdminLocation; set => oPDAdminLocation = value; }

        [RegularExpression("([0-9]+)", ErrorMessage = "OPDAdminContinue : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "OPDAdminContinue : ขนาดข้อมูลเกิน Max")]
        public decimal OPDAdminContinue { get => oPDAdminContinue; set => oPDAdminContinue = value; }

        [StringLength(200, ErrorMessage = "RowID : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string RowID { get => rowID; set => rowID = value; }

        #endregion "Properties/ViewModel/Data Validation"

        private System_logfile logs;

        //Constructor And Adstract Calss
        public Thaneshopmiddle_VICHAIYUT()
        {
            logs = new System_logfile();
        }

        //Query Command thaneshop middle table for Display DataGrid View Full Detial Form
        public DataSet GetDataMiddleFormHISVichaiyut(string prescriptionno, decimal tomachineNo)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";                      //1
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";                                 //2
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";                              //3
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";                    //4
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";                                  //5
            SQL += "dbo.tb_thaneshosp_middle.f_en,";                                  //6
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";                         //7
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";                                 //8
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate,";                  //9
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";                        //10
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";                        //11
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";                     //12
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";                     //13
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";                     //14
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime,";                     //15
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";                       //16
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";                       //17
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";                            //18
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";                       //19
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";                       //20
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";                     //21
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";                     //22
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";                              //23
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";                          //24
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";                       //25
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";                       //26
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";                        //27
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc,";                        //28
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";                      //29
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname,";                    //30
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";                         //31
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";                        //32
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";                     //33
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime,";                     //34
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";                   //35
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";                          //36
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode,";                         //37
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";                       //38
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";                          //39
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";                          //40
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";                            //41
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";                            //42
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";                            //43
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";                            //44
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";                             //45
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc,";                             //46
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";                //47
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";                //48
           // SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
           //SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh,";                            //63
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4, ";                          //65
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug,";                      //66
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode,";                       //67
            SQL += "dbo.tb_thaneshosp_middle.f_opddispensestatus,";                   //68
            SQL += "dbo.tb_thaneshosp_middle.f_opddispensedate,";                     //69
            SQL += "dbo.tb_thaneshosp_middle.f_opddispensetime,";                     //70
            SQL += "dbo.tb_thaneshosp_middle.f_opddispenseby,";                       //71
            SQL += "dbo.tb_thaneshosp_middle.f_opddispenselocation,";                 //72
            SQL += "dbo.tb_thaneshosp_middle.f_opddispenseall,";                      //73
            SQL += "dbo.tb_thaneshosp_middle.f_opdsenddrugtoward,";                   //74
            SQL += "dbo.tb_thaneshosp_middle.f_opdkeepdruglist,";                     //75
            SQL += "dbo.tb_thaneshosp_middle.f_opdadmitbycode,";                      //76
            SQL += "dbo.tb_thaneshosp_middle.f_opdadmitbyname,";                      //77
            SQL += "dbo.tb_thaneshosp_middle.f_opdcase,";                             //78
            SQL += "dbo.tb_thaneshosp_middle.f_bagspecialdrug ";                      //79       
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,dbo.tb_thaneshosp_middle.f_lastmodified,112) = CONVERT(VARCHAR,GETDATE(),112) ";
            SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode <> '' ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_frequencycode <> '' ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime IS NOT NULL ";
            //SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = 0 ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_lastmodified ASC ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", prescriptionno));
                //cmd.Parameters.AddWithValue("@f_tomachineno1", tomachineNo1);
               // cmd.Parameters.AddWithValue("@f_tomachineno2", tomachineNo2);
                return conn.FillSQL(cmd);
            }
        }
        public DataSet GetDataPrescriptionReady(decimal tomachineNo)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "SELECT DISTINCT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "CONVERT(VARCHAR,dbo.tb_thaneshosp_middle.f_lastmodified,112) = CONVERT(VARCHAR,GETDATE(),112) ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = 0 ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
               // cmd.Parameters.AddWithValue("@f_tomachineno1", tomachineNo1);
               // cmd.Parameters.AddWithValue("@f_tomachineno2", tomachineNo2);
                return conn.FillSQL(cmd);
            }
        }

        //Find the number of prescriptions that have not yet created a data file.
        //Retrun Type int
        public Object ItemsDataReadyToMiddleV4(decimal tomachineNo)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "SELECT ";
            SQL += "COUNT(*)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "CONVERT(VARCHAR,dbo.tb_thaneshosp_middle.f_lastmodified,112) = CONVERT(VARCHAR,GETDATE(),112) ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = 0 ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_tomachineno", tomachineNo);
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        public Object ItemsAllDataPrescription(decimal tomachineNo)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "SELECT ";
            SQL += "COUNT(DISTINCT dbo.tb_thaneshosp_middle.f_prescriptionno)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "CONVERT(VARCHAR,dbo.tb_thaneshosp_middle.f_lastmodified,112) = CONVERT(VARCHAR,GETDATE(),112) ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = 0 ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_tomachineno", tomachineNo);
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //public Object ItemsAllDataFullbyPrescription(string ppresno,decimal tomachineNo)
        public Object ItemsAllDataFullbyPrescription(string presno, decimal tomachineNo)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "SELECT ";
            SQL += "COUNT(*)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,dbo.tb_thaneshosp_middle.f_lastmodified,112) = CONVERT(VARCHAR,GETDATE(),112) ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = 1 ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", presno));
                cmd.Parameters.AddWithValue("@f_tomachineno", tomachineNo);
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for Update status patient prescriptions data.
        //Return Type boolean
        public bool UpdateDispenseStatus(string ppresno, decimal seqno, string referenceCode, decimal tomachineNo, decimal dispensStatus)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus =@f_dispensestatus ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno IN ('21','22') ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode =@f_referenceCode ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode IN ('TAB','CAP') ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", dispensStatus));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", ppresno));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", tomachineNo));
                cmd.Parameters.Add(new SqlParameter("@f_seq", seqno));
                cmd.Parameters.Add(new SqlParameter("@f_referenceCode", referenceCode));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Delete patient prescriptions data.
        //Return Type boolean
        public bool DeleteDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.ServerHosXP);
            SQL += "DELETE FROM dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.fseq =@fseq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", PrescriptionNo));
                //cmd.Parameters.Add(new SqlParameter("@fseq", seq));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public Object SearchAllDataFullbyPrescription(string prescNo, decimal seqno, string refer)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(*)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_runningno =@f_runningno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_prescriptionno", prescNo);
                cmd.Parameters.AddWithValue("@f_seq", seqno);
                cmd.Parameters.Add(new SqlParameter("@f_runningno", refer));
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        public bool InsertDataThanesMiddle()
        {
            bool result = false;
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle (";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";            //Field 01
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";                       //Field 02
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";                    //Field 03
            SQL += "dbo.tb_thaneshosp_middle.f_runningno,";                 //Field 04
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";          //Field 05
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";           //Field 06
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";           //Field 07
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";           //Field 08
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";      //Field 09
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";      //Field 10
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";               //Field 11
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";              //Field 12
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";           //Field 13
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";         //Field 14
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";            //Field 15
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                    //Field 16
            SQL += "dbo.tb_thaneshosp_middle.f_printstatus,";               //Field 17
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";                        //Field 18
            SQL += "dbo.tb_thaneshosp_middle.f_an,";                        //Field 19
            SQL += "dbo.tb_thaneshosp_middle.f_vn,";                        //Field 20
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";               //Field 21
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";                       //Field 22
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";                //Field 23
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";                  //Field 24
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";                  //Field 25
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";                  //Field 26
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";                  //Field 27
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";                   //Field 28
            SQL += "dbo.tb_thaneshosp_middle.f_drugallergy,";               //Field 29
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";                //Field 30
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";                //Field 31
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";               //Field 32
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";             //Field 33
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";             //Field 34
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";                  //Field 35
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";             //Field 36
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";             //Field 37
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";                    //Field 38
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";                //Field 39
            SQL += "dbo.tb_thaneshosp_middle.f_binlocation,";               //Field 40
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";              //Field 41
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotno,";                 //Field 42
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";             //Field 43
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";           //Field 44
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";           //Field 45
            SQL += "dbo.tb_thaneshosp_middle.f_drugformcode,";              //Field 46
            SQL += "dbo.tb_thaneshosp_middle.f_drugformdesc,";              //Field 47
            SQL += "dbo.tb_thaneshosp_middle.f_highalertdrug,";             //Field 48
            SQL += "dbo.tb_thaneshosp_middle.f_prnstat,";                   //Field 49
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";              //Field 50
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";              //Field 51
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";             //Field 52
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";             //Field 53
            SQL += "dbo.tb_thaneshosp_middle.f_frequencytime,";             //Field 54
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";            //Field 55
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                  //Field 56
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";              //Field 57
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";            //Field 58
            SQL += "dbo.tb_thaneshosp_middle.f_barcodebyhis,";              //Field 59
            SQL += "dbo.tb_thaneshosp_middle.f_excludeipfill,";             //Field 60
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";              //Field 61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                   //Field 62
            SQL += "dbo.tb_thaneshosp_middle.f_drugbagsplit,";              //Field 63
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminstatus,";           //Field 64
            SQL += "dbo.tb_thaneshosp_middle.f_opd_admindatetime,";         //Field 65
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminby,";               //Field 66
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminremark,";           //Field 67
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminlocation,";         //Field 68
            SQL += "dbo.tb_thaneshosp_middle.f_opd_admincontinue) ";        //Field 69
            SQL += "VALUES( ";
            SQL += "@f_prescriptionno,";                                    //Field 01
            SQL += "@f_seq,";                                               //Field 02
            SQL += "@f_seqmax,";                                            //Field 03
            SQL += "@f_runningno,";                                         //Field 04
            SQL += "@f_prescriptiondate,";                                  //Field 05
            SQL += "@f_ordercreatedate,";                                   //Field 06
            SQL += "@f_ordertargetdate,";                                   //Field 07
            SQL += "@f_ordertargettime,";                                   //Field 08
            SQL += "@f_pharmacylocationcode,";                              //Field 09
            SQL += "@f_pharmacylocationdesc,";                              //Field 10
            SQL += "@f_userorderby,";                                       //Field 11
            SQL += "@f_useracceptby,";                                      //Field 12
            SQL += "@f_orderacceptdate,";                                   //Field 13
            SQL += "@f_orderacceptfromip,";                                 //Field 14
            SQL += "@f_dispensestatus,";                                    //Field 15
            SQL += "@f_status,";                                            //Field 16
            SQL += "@f_printstatus,";                                       //Field 17
            SQL += "@f_hn,";                                                //Field 18
            SQL += "@f_an,";                                                //Field 19
            SQL += "@f_vn,";                                                //Field 20
            SQL += "@f_patientname,";                                       //Field 21
            SQL += "@f_sex,";                                               //Field 22
            SQL += "@f_patientdob,";                                        //Field 23
            SQL += "@f_wardcode,";                                          //Field 24
            SQL += "@f_warddesc,";                                          //Field 25
            SQL += "@f_roomcode,";                                          //Field 26
            SQL += "@f_roomdesc,";                                          //Field 27
            SQL += "@f_bedcode,";                                           //Field 28
            SQL += "@f_drugallergy,";                                       //Field 29
            SQL += "@f_doctorcode,";                                        //Field 30
            SQL += "@f_doctorname,";                                        //Field 31
            SQL += "@f_tomachineno,";                                       //Field 32
            SQL += "@f_orderitemcode,";                                     //Field 33
            SQL += "@f_orderitemname,";                                     //Field 34
            SQL += "@f_orderqty,";                                          //Field 35
            SQL += "@f_orderunitcode,";                                     //Field 36
            SQL += "@f_orderunitdesc,";                                     //Field 37
            SQL += "@f_dosage,";                                            //Field 38
            SQL += "@f_dosageunit,";                                        //Field 39
            SQL += "@f_binlocation,";                                       //Field 40
            SQL += "@f_itemidentify,";                                      //Field 41
            SQL += "@f_itemlotno,";                                         //Field 42
            SQL += "@f_itemlotexpire,";                                     //Field 43
            SQL += "@f_instructioncode,";                                   //Field 44
            SQL += "@f_instructiondesc,";                                   //Field 45
            SQL += "@f_drugformcode,";                                      //Field 46
            SQL += "@f_drugformdesc,";                                      //Field 47
            SQL += "@f_highalertdrug,";                                     //Field 48
            SQL += "@f_prnstat,";                                           //Field 49
            SQL += "@f_prioritycode,";                                      //Field 50
            SQL += "@f_prioritydesc,";                                      //Field 51
            SQL += "@f_frequencycode,";                                     //Field 52
            SQL += "@f_frequencydesc,";                                     //Field 53
            SQL += "@f_frequencytime,";                                     //Field 54
            SQL += "@f_dosagedispense,";                                    //Field 55
            SQL += "@f_language,";                                          //Field 56
            SQL += "@f_durationcode,";                                      //Field 57
            SQL += "@f_noteprocessing,";                                    //Field 58
            SQL += "@f_barcodebyhis,";                                      //Field 59
            SQL += "@f_excludeipfill,";                                     //Field 60
            SQL += "@f_lastmodified,";                                      //Field 61
            SQL += "@f_comment,";                                           //Field 62
            SQL += "@f_drugbagsplit,";                                      //Field 63
            SQL += "@f_opd_adminstatus,";                                   //Field 64
            SQL += "@f_opd_admindatetime,";                                 //Field 65
            SQL += "@f_opd_adminby,";                                       //Field 66
            SQL += "@f_opd_adminremark,";                                   //Field 67
            SQL += "@f_opd_adminlocation,";                                 //Field 68
            SQL += "@f_opd_admincontinue) ";                                //Field 69
                                                                            //
            try
            {
                using (SqlCommand cmd = new SqlCommand(SQL))
                {
                    cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", PrescriptionNo));                  //Field 01
                    cmd.Parameters.Add(new SqlParameter("@f_seq", Seq));                                        //Field 02
                    cmd.Parameters.Add(new SqlParameter("@f_seqmax", SeqMax));                                  //Field 03
                    cmd.Parameters.Add(new SqlParameter("@f_runningno", RunningNo));                            //Field 04
                    cmd.Parameters.Add(new SqlParameter("@f_prescriptiondate", PrescriptionDate));              //Field 05
                    cmd.Parameters.Add(new SqlParameter("@f_ordercreatedate", OrderCreateDate));                //Field 06
                    cmd.Parameters.Add(new SqlParameter("@f_ordertargetdate", OrderTargetDate));                //Field 07
                    cmd.Parameters.Add(new SqlParameter("@f_ordertargettime", OrderTargetTime));                //Field 08
                    cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationcode", PharmacyLocationCode));      //Field 09
                    cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationdesc", PharmacyLocationDesc));      //Field 10
                    cmd.Parameters.Add(new SqlParameter("@f_userorderby", UserAcceptBy));                       //Field 11
                    cmd.Parameters.Add(new SqlParameter("@f_useracceptby", UserAcceptBy));                      //Field 12
                    cmd.Parameters.Add(new SqlParameter("@f_orderacceptdate", OrderAcceptDate));                //Field 13
                    cmd.Parameters.Add(new SqlParameter("@f_orderacceptfromip", OrderAcceptFromIP));            //Field 14
                    cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", DispenseStatus));                  //Field 15
                    cmd.Parameters.Add(new SqlParameter("@f_status", Status));                                  //Field 16
                    cmd.Parameters.Add(new SqlParameter("@f_printstatus", PrintStatus));                        //Field 17
                    cmd.Parameters.Add(new SqlParameter("@f_hn", Hn));                                          //Field 18
                    cmd.Parameters.Add(new SqlParameter("@f_an", An));                                          //Field 19
                    cmd.Parameters.Add(new SqlParameter("@f_vn", Vn));                                          //Field 20
                    cmd.Parameters.Add(new SqlParameter("@f_patientname", PatientName));                        //Field 21
                    cmd.Parameters.Add(new SqlParameter("@f_sex", Sex));                                        //Field 22
                    cmd.Parameters.Add(new SqlParameter("@f_patientdob", PatientDOB));                          //Field 23
                    cmd.Parameters.Add(new SqlParameter("@f_wardcode", WardCode));                              //Field 24
                    cmd.Parameters.Add(new SqlParameter("@f_warddesc", WardDesc));                              //Field 25
                    cmd.Parameters.Add(new SqlParameter("@f_roomcode", RoomCode));                              //Field 26
                    cmd.Parameters.Add(new SqlParameter("@f_roomdesc", RoomDesc));                              //Field 27
                    cmd.Parameters.Add(new SqlParameter("@f_bedcode", BedCode));                                //Field 28
                    cmd.Parameters.Add(new SqlParameter("@f_drugallergy", DrugAllergy));                        //Field 29
                    cmd.Parameters.Add(new SqlParameter("@f_doctorcode", DoctorCode));                          //Field 30
                    cmd.Parameters.Add(new SqlParameter("@f_doctorname", DoctorName));                          //Field 31
                    cmd.Parameters.Add(new SqlParameter("@f_tomachineno", ToMachineNo));                        //Field 32
                    cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", OrderItemCode));                    //Field 33
                    cmd.Parameters.Add(new SqlParameter("@f_orderitemname", OrderItemName));                    //Field 34
                    cmd.Parameters.Add(new SqlParameter("@f_orderqty", OrderQty));                              //Field 35
                    cmd.Parameters.Add(new SqlParameter("@f_orderunitcode", OrderUnitCode));                    //Field 36
                    cmd.Parameters.Add(new SqlParameter("@f_orderunitdesc", OrderUnitDesc));                    //Field 37
                    cmd.Parameters.Add(new SqlParameter("@f_dosage", Dosage));                                  //Field 38
                    cmd.Parameters.Add(new SqlParameter("@f_dosageunit", DosageUnit));                          //Field 39
                    cmd.Parameters.Add(new SqlParameter("@f_binlocation", BinLocation));                        //Field 40
                    cmd.Parameters.Add(new SqlParameter("@f_itemidentify", ItemIdentify));                      //Field 41
                    cmd.Parameters.Add(new SqlParameter("@f_itemlotno", ItemLotNo));                            //Field 42
                    cmd.Parameters.Add(new SqlParameter("@f_itemlotexpire", ItemLotExpire));                    //Field 43
                    cmd.Parameters.Add(new SqlParameter("@f_instructioncode", InstructionCode));                //Field 44
                    cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", InstructionDesc));                //Field 45
                    cmd.Parameters.Add(new SqlParameter("@f_drugformcode", DrugFormCode));                      //Field 46
                    cmd.Parameters.Add(new SqlParameter("@f_drugformdesc", DrugFormDesc));                      //Field 47
                    cmd.Parameters.Add(new SqlParameter("@f_highalertdrug", HeighAlretDrug));                   //Field 48
                    cmd.Parameters.Add(new SqlParameter("@f_prnstat", PRNSTAT));                                //Field 49
                    cmd.Parameters.Add(new SqlParameter("@f_prioritycode", PriorityCode));                      //Field 50
                    cmd.Parameters.Add(new SqlParameter("@f_prioritydesc", PriorityDesc));                      //Field 51
                    cmd.Parameters.Add(new SqlParameter("@f_frequencycode", FrequencyCode));                    //Field 52
                    cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", FrequencyDesc));                    //Field 53
                    cmd.Parameters.Add(new SqlParameter("@f_frequencyTime", FrequencyTime));                    //Field 54
                    cmd.Parameters.Add(new SqlParameter("@f_dosagedispense", DosageDispense));                  //Field 55
                    cmd.Parameters.Add(new SqlParameter("@f_language", Language));                              //Field 56
                    cmd.Parameters.Add(new SqlParameter("@f_durationcode", DurationCode));                      //Field 57
                    cmd.Parameters.Add(new SqlParameter("@f_noteprocessing", NoteProcessing));                  //Field 58
                    cmd.Parameters.Add(new SqlParameter("@f_barcodebyhis", BarcodeByHIS));                      //Field 59
                    cmd.Parameters.Add(new SqlParameter("@f_excludeipfill", ExcludeIPFill));                    //Field 60
                    cmd.Parameters.Add(new SqlParameter("@f_lastmodified", LastModified));                      //Field 61
                    cmd.Parameters.Add(new SqlParameter("@f_comment", Comment));                                //Field 62
                    cmd.Parameters.Add(new SqlParameter("@f_drugbagsplit", DrugBagSplit));                      //Field 63
                    cmd.Parameters.Add(new SqlParameter("@f_opd_adminstatus", OPDAdminStatus));                 //Field 64
                    cmd.Parameters.Add(new SqlParameter("@f_opd_admindatetime", OPDAdminDateTime));             //Field 65
                    cmd.Parameters.Add(new SqlParameter("@f_opd_adminby", OPDAdminBy));                         //Field 66
                    cmd.Parameters.Add(new SqlParameter("@f_opd_adminremark", OPDAdminRemark));                 //Field 67
                    cmd.Parameters.Add(new SqlParameter("@f_opd_adminlocation", OPDAdminLocation));             //Field 68
                    cmd.Parameters.Add(new SqlParameter("@f_opd_admincontinue", OPDAdminContinue));             //Field 69

                    result = conn.ExecuteNonQuerySQL(cmd);
                }
            }
            catch (Exception ex)
            {
                logs.Writelogfile(" Add ThanesMiddles Error :" + ex.Message + "\n Data Values ->(" + DrugAllergy + ")", "InsertDataThanesMiddle()");
            }
            return result;
        }
        public DataSet GetDispalyDataClassify()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";                 //Field 01
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";                            //Field 02
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";                         //Field 03
            SQL += "dbo.tb_thaneshosp_middle.f_runningno,";                      //Field 04
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";               //Field 05
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";                //Field 06
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";                //Field 07
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";                //Field 08
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";           //Field 09
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";           //Field 10
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";                    //Field 11
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";                   //Field 12
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";                //Field 13
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";              //Field 14
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                 //Field 15
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                         //Field 16
            SQL += "dbo.tb_thaneshosp_middle.f_printstatus,";                    //Field 17
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";                             //Field 18
            SQL += "dbo.tb_thaneshosp_middle.f_an,";                             //Field 19
            SQL += "dbo.tb_thaneshosp_middle.f_vn,";                             //Field 20
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";                    //Field 21
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";                            //Field 22
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";                     //Field 23
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";                       //Field 24
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";                       //Field 25
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";                       //Field 26
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";                       //Field 27
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";                        //Field 28
            SQL += "dbo.tb_thaneshosp_middle.f_drugallergy,";                    //Field 29
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";                     //Field 30
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";                     //Field 31
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                    //Field 32
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";                  //Field 33
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";                  //Field 34
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";                       //Field 35
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";                  //Field 36
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";                  //Field 37
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";                         //Field 38
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";                     //Field 39
            SQL += "dbo.tb_thaneshosp_middle.f_binlocation,";                    //Field 40
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                   //Field 41
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotno,";                      //Field 42
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";                  //Field 43
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";                //Field 44
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";                //Field 45
            SQL += "dbo.tb_thaneshosp_middle.f_drugformcode,";                   //Field 46
            SQL += "dbo.tb_thaneshosp_middle.f_drugformdesc,";                   //Field 47
            SQL += "dbo.tb_thaneshosp_middle.f_highalertdrug,";                  //Field 48
            SQL += "dbo.tb_thaneshosp_middle.f_prnstat,";                        //Field 49
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";                   //Field 50
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";                   //Field 51
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";                  //Field 52
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";                  //Field 53
            SQL += "dbo.tb_thaneshosp_middle.f_frequencytime,";                  //Field 54
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                 //Field 55
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                       //Field 56
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";                   //Field 57
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";                 //Field 58
            SQL += "dbo.tb_thaneshosp_middle.f_barcodebyhis,";                   //Field 59
            SQL += "dbo.tb_thaneshosp_middle.f_excludeipfill,";                  //Field 60
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                   //Field 61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                        //Field 62
            SQL += "dbo.tb_thaneshosp_middle.f_drugbagsplit,";                   //Field 63
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminstatus,";                //Field 64
            SQL += "dbo.tb_thaneshosp_middle.f_opd_admindatetime,";              //Field 65
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminby,";                    //Field 66
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminremark,";                //Field 67
            SQL += "dbo.tb_thaneshosp_middle.f_opd_adminlocation,";              //Field 68
            SQL += "dbo.tb_thaneshosp_middle.f_opd_admincontinue,";              //Field 69
            SQL += "dbo.tb_thaneshosp_middle.RowID ";                            //Field 70
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus ='0' ";
            SQL += "ORDER BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }
        public bool UpdateDispenseStatusDataThanesMiddle(string prescNo, decimal dispensestatus)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = @f_dispensestatus ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", prescNo));
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", dispensestatus));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        public bool UpdateDispenseStatusDataThanesMiddle(string prescNo, decimal seqno, decimal dispensestatus)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus = @f_dispensestatus ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", prescNo));
                cmd.Parameters.Add(new SqlParameter("@f_seq", seqno));
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", dispensestatus));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }
    }
}