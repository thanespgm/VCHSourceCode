using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class JSDDNET_Prescription
    {
        //Fields And Properties
        private string prescriptionNo;                    //Field 01

        private decimal seqNo;                            //Field 02
        private decimal groupNo;                          //Field 03
        private decimal machineNo;                        //Field 04
        private decimal proFlg;                           //Field 05
        private string patientId;                         //Field 05
        private string patientName;                       //Field 06
        private string englishName;                       //Field 07
        private DateTime brithDay;                        //Field 08
        private string sex;                               //Field 09
        private string ioFlg;                             //Field 10
        private string wardCd;                            //Field 11
        private string wardName;                          //Field 12
        private string roomNo;                            //Field 13
        private string bedNo;                             //Field 14
        private string doctorCd;                          //Field 15
        private string doctorName;                        //Field 16
        private DateTime prescriptionDate;                //Field 17
        private DateTime takeDate;                        //Field 18
        private string takeTime;                          //Field 19
        private string lastTime;                          //Field 20
        private decimal prescClass;                       //Field 21
        private string drugCd;                            //Field 22
        private string drugName;                          //Field 23
        private string drugShape;                         //Field 24
        private decimal prescriptionDose;                 //Field 25
        private string prescriptionUnit;                  //Field 26
        private decimal dispenseDose;                     //Field 27
        private decimal dispenseTotalDose;                //Field 28
        private string dispenseUnit;                      //Field 29
        private decimal amountPerPackage;                 //Field 30
        private string firmID;                            //Field 31
        private decimal dispenseDays;                     //Field 32
        private string freqDescCode;                      //Field 33
        private string freqDesc;                          //Field 34
        private string freqCounter;                       //Field 35
        private string freqDescDetailCode;                //Field 36
        private string freqDescDetail;                    //Field 37
        private string explanationCode;                   //Field 38
        private string explanation;                       //Field 39
        private string administrationName;                //Field 40
        private string doctorComment;                     //Field 41
        private decimal bagOrderby;                      //Field 42
        private DateTime makeRecTime;                     //Field 43
        private DateTime upDateRecTime;                   //Field 44
        private string filler;                            //Field 45
        private decimal orderNo;                          //Field 46
        private decimal orderSubNo;                       //Field 47
        private string bagPrintFmt;                       //Field 48
        private string bagLen;                            //Field 49
        private string bagPrintPatientNm;                 //Field 50
        private string ticketNo;                          //Field 51
        private string freePrintItemPres1;                //Field 52
        private string freePrintItemPres2;                //Field 53
        private string freePrintItemPres3;                //Field 54
        private string freePrintItemPres4;                //Field 55
        private string freePrintItemPres5;                //Field 56
        private string freePrintItemDrug1;                //Field 57
        private string freePrintItemDrug2;                //Field 58
        private string freePrintItemDrug3;                //Field 59
        private string freePrintItemDrug4;                //Field 60
        private string freePrintItemDrug5;                //Field 61
        private string syntheticFlg;                      //Field 62
        private string cutFlg;                            //Field 63
        private string pharmacyTime;                      //Field 64
        private string carvedSeal;                        //Field 65
        private string carvedSealAbb;                     //Field 66
        private string preBarcode1;                       //Field 67
        private string preBarcode2;                       //Field 68
        private string preDrugBarcode;                    //Field 69
        private string preBarcodeFmt;                     //Field 70
        private string hisID;                             //Field 71
        private string boxCntStandard;                    //Field 72
        private string drugBarcode1;                      //Field 73
        private string drugBarcode2;                      //Field 74
        private string drugBarcode3;                      //Field 75
        private string drugBarcode4;                      //Field 76
        private string drugBarcode5;                      //Field 77
        private string drugBarcode6;                      //Field 78
        private string drugBarcode7;                      //Field 79
        private string drugBarcode8;                      //Field 80
        private string drugBarcode9;                      //Field 81
        private string drugBarcode10;                     //Field 82
        private string massPrint1;                        //Field 83
        private string massPrint2;                        //Field 84
        private string massPrint3;                        //Field 85
        private string massPrint4;                        //Field 86
        private string massPrint5;                        //Field 87
        private string massPrint6;                        //Field 88
        private string freePrintItemDrug6;                //Field 89
        private string freePrintItemDrug7;                //Field 70
        private string freePrintItemDrug8;                //Field 71
        private string freePrintItemDrug9;                //Field 72
        private string freePrintItemDrug10;               //Field 73
        private string insertMessageFlg;                  //Field 74
        private string insertMessageBagPrintFmt;          //Field 75
        private string insertMessageBagLen;               //Field 76
        private string insertMessageTakeDate;             //Field 77
        private string InsertMessage1;                    //Field 78
        private string InsertMessage2;                    //Field 79
        private string InsertMessage3;                    //Field 80
        private string drugPac;                           //Field 81
        private string drugTouchPanel;                    //Field 82
        private string freePrintItemDrug11;               //Field 83
        private string freePrintItemDrug12;               //Field 84
        private string freePrintItemDrug13;               //Field 85
        private string freePrintItemDrug14;               //Field 86
        private string freePrintItemDrug15;               //Field 87
        private string freePrintItemDrug16;               //Field 88
        private string freePrintItemDrug17;               //Field 89
        private string freePrintItemDrug18;               //Field 90
        private string freePrintItemDrug19;               //Field 91
        private string freePrintItemDrug20;               //Field 92

        private System_logfile logs;

        [Required(ErrorMessage = "PrescriptionNo : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string PrescriptionNo { get => prescriptionNo; set => prescriptionNo = value; }

        [Required(ErrorMessage = "SeqNo : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "SeqNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999999999, ErrorMessage = "SeqNo : ขนาดข้อมูลเกิน Max")]
        public decimal SeqNo { get => seqNo; set => seqNo = value; }

        [Required(ErrorMessage = "GroupNo : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "GroupNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "GroupNo : ขนาดข้อมูลเกิน Max")]
        public decimal GroupNo { get => groupNo; set => groupNo = value; }

        [Required(ErrorMessage = "MachineNo : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "MachineNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "MachineNo : ขนาดข้อมูลเกิน Max")]
        public decimal MachineNo { get => machineNo; set => machineNo = value; }

        [Required(ErrorMessage = "ProFlg : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "ProFlg : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 99, ErrorMessage = "ProFlg : ขนาดข้อมูลเกิน Max")]
        public decimal ProFlg { get => proFlg; set => proFlg = value; }

        [StringLength(40, ErrorMessage = "PatientId : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string PatientId { get => patientId; set => patientId = value; }

        [StringLength(100, ErrorMessage = "PatientName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string PatientName { get => patientName; set => patientName = value; }

        [StringLength(40, ErrorMessage = "EnglishName : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string EnglishName { get => englishName; set => englishName = value; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime BrithDay { get => brithDay; set => brithDay = value; }

        [StringLength(1, ErrorMessage = "Sex : ขนาดข้อมูลเกิน 1 ตัวอักษร ")]
        public string Sex { get => sex; set => sex = value; }

        [Required(ErrorMessage = "IOFlg : ไม่พบข้อมูล")]
        [StringLength(1, ErrorMessage = "IOFlg : ขนาดข้อมูลเกิน 1 ตัวอักษร ")]
        public string IoFlg { get => ioFlg; set => ioFlg = value; }

        [Required(ErrorMessage = "WardCd : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "WardCd : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string WardCd { get => wardCd; set => wardCd = value; }

        [Required(ErrorMessage = "WardName : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "WardName : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string WardName { get => wardName; set => wardName = value; }

        [StringLength(20, ErrorMessage = "RoomNo : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string RoomNo { get => roomNo; set => roomNo = value; }

        [StringLength(20, ErrorMessage = "BedNo : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string BedNo { get => bedNo; set => bedNo = value; }

        [StringLength(20, ErrorMessage = "DoctorCd : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string DoctorCd { get => doctorCd; set => doctorCd = value; }

        [StringLength(100, ErrorMessage = "DoctorName : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string DoctorName { get => doctorName; set => doctorName = value; }

        [Required(ErrorMessage = "PrescriptionDate : ไม่พบข้อมูล")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime PrescriptionDate { get => prescriptionDate; set => prescriptionDate = value; }

        public DateTime TakeDate { get => takeDate; set => takeDate = value; }

        [StringLength(10, ErrorMessage = "TakeTime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string TakeTime { get => takeTime; set => takeTime = value; }

        [StringLength(10, ErrorMessage = "LastTime : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string LastTime { get => lastTime; set => lastTime = value; }

        [Required(ErrorMessage = "PrescClass : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "PrescClass : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "PrescClass : ขนาดข้อมูลเกิน Max")]
        public decimal PrescClass { get => prescClass; set => prescClass = value; }

        [StringLength(50, ErrorMessage = "DrugCd : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string DrugCd { get => drugCd; set => drugCd = value; }

        [StringLength(300, ErrorMessage = "DrugName : ขนาดข้อมูลเกิน 300 ตัวอักษร ")]
        public string DrugName { get => drugName; set => drugName = value; }

        [StringLength(1, ErrorMessage = "DrugShape : ขนาดข้อมูลเกิน 1 ตัวอักษร ")]
        public string DrugShape { get => drugShape; set => drugShape = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "PrescriptionDose : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999.9999, ErrorMessage = "PrescriptionDose : ขนาดข้อมูลเกิน Max")]
        public decimal PrescriptionDose { get => prescriptionDose; set => prescriptionDose = value; }

        [StringLength(8, ErrorMessage = "PrescriptionUnit : ขนาดข้อมูลเกิน 8 ตัวอักษร ")]
        public string PrescriptionUnit { get => prescriptionUnit; set => prescriptionUnit = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispenseDose : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999.9999, ErrorMessage = "DispenseDose : ขนาดข้อมูลเกิน Max")]
        public decimal DispenseDose { get => dispenseDose; set => dispenseDose = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispenseTotalDose : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999.9999, ErrorMessage = "DispenseTotalDose : ขนาดข้อมูลเกิน Max")]
        public decimal DispenseTotalDose { get => dispenseTotalDose; set => dispenseTotalDose = value; }

        [Required(ErrorMessage = "DispenseUnit : ไม่พบข้อมูล")]
        [StringLength(8, ErrorMessage = "DispenseUnit : ขนาดข้อมูลเกิน 8 ตัวอักษร ")]
        public string DispenseUnit { get => dispenseUnit; set => dispenseUnit = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "AmountPerPackage : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999.9999, ErrorMessage = "AmountPerPackage : ขนาดข้อมูลเกิน Max")]
        public decimal AmountPerPackage { get => amountPerPackage; set => amountPerPackage = value; }

        [StringLength(100, ErrorMessage = "FirmID : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string FirmID { get => firmID; set => firmID = value; }

        [Required(ErrorMessage = "DispenseDays : ไม่พบข้อมูล")]
        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "DispenseDays : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 999, ErrorMessage = "DispenseDays : ขนาดข้อมูลเกิน Max")]
        public decimal DispenseDays { get => dispenseDays; set => dispenseDays = value; }

        [StringLength(10, ErrorMessage = "FreqDescCode : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string FreqDescCode { get => freqDescCode; set => freqDescCode = value; }

        [Required(ErrorMessage = "FreqDesc : ไม่พบข้อมูล")]
        [StringLength(40, ErrorMessage = "FreqDesc : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreqDesc { get => freqDesc; set => freqDesc = value; }

        [StringLength(5, ErrorMessage = "FreqCounter : ขนาดข้อมูลเกิน 5 ตัวอักษร ")]
        public string FreqCounter { get => freqCounter; set => freqCounter = value; }

        [StringLength(120, ErrorMessage = "FreqDescDetailCode : ขนาดข้อมูลเกิน 120 ตัวอักษร ")]
        public string FreqDescDetailCode { get => freqDescDetailCode; set => freqDescDetailCode = value; }

        [Required(ErrorMessage = "FreqDescDetail : ไม่พบข้อมูล")]
        [StringLength(240, ErrorMessage = "FreqDescDetail : ขนาดข้อมูลเกิน 240 ตัวอักษร ")]
        public string FreqDescDetail { get => freqDescDetail; set => freqDescDetail = value; }

        [StringLength(5, ErrorMessage = "ExplanationCode : ขนาดข้อมูลเกิน 5 ตัวอักษร ")]
        public string ExplanationCode { get => explanationCode; set => explanationCode = value; }

        [StringLength(32, ErrorMessage = "Explanation : ขนาดข้อมูลเกิน 32 ตัวอักษร ")]
        public string Explanation { get => explanation; set => explanation = value; }

        [StringLength(20, ErrorMessage = "AdministrationName : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string AdministrationName { get => administrationName; set => administrationName = value; }

        [StringLength(60, ErrorMessage = "DoctorComment : ขนาดข้อมูลเกิน 60 ตัวอักษร ")]
        public string DoctorComment { get => doctorComment; set => doctorComment = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "BagOrderby : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9, ErrorMessage = "BagOrderby : ขนาดข้อมูลเกิน Max")]
        public decimal BagOrderby { get => bagOrderby; set => bagOrderby = value; }

        [Required(ErrorMessage = "MakeRecTime : ไม่พบข้อมูล")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime MakeRecTime { get => makeRecTime; set => makeRecTime = value; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss:fff}")]
        public DateTime UpDateRecTime { get => upDateRecTime; set => upDateRecTime = value; }

        [StringLength(64, ErrorMessage = "Filler : ขนาดข้อมูลเกิน 64 ตัวอักษร ")]
        public string Filler { get => filler; set => filler = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "OrderNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999999999, ErrorMessage = "OrderNo : ขนาดข้อมูลเกิน Max")]
        public decimal OrderNo { get => orderNo; set => orderNo = value; }

        [RegularExpression((@"^-?[0-9]*\.?[0-9]+$"), ErrorMessage = "OrderSubNo : ไม่ใช่ข้อมูลตัวเลข 0-9")]
        [Range(0, 9999999999999999999, ErrorMessage = "OrderSubNo : ขนาดข้อมูลเกิน Max")]
        public decimal OrderSubNo { get => orderSubNo; set => orderSubNo = value; }

        [StringLength(10, ErrorMessage = "BagPrintFmt : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string BagPrintFmt { get => bagPrintFmt; set => bagPrintFmt = value; }

        [StringLength(3, ErrorMessage = "BagLen : ขนาดข้อมูลเกิน 3 ตัวอักษร ")]
        public string BagLen { get => bagLen; set => bagLen = value; }

        [StringLength(40, ErrorMessage = "BagPrintPatientNm : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string BagPrintPatientNm { get => bagPrintPatientNm; set => bagPrintPatientNm = value; }

        [StringLength(15, ErrorMessage = "TicketNo : ขนาดข้อมูลเกิน 15 ตัวอักษร ")]
        public string TicketNo { get => ticketNo; set => ticketNo = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres1 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres1 { get => freePrintItemPres1; set => freePrintItemPres1 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres2 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres2 { get => freePrintItemPres2; set => freePrintItemPres2 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres3 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres3 { get => freePrintItemPres3; set => freePrintItemPres3 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres4 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres4 { get => freePrintItemPres4; set => freePrintItemPres4 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemPres5 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemPres5 { get => freePrintItemPres5; set => freePrintItemPres5 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug1 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug1 { get => freePrintItemDrug1; set => freePrintItemDrug1 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug2 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug2 { get => freePrintItemDrug2; set => freePrintItemDrug2 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug3 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug3 { get => freePrintItemDrug3; set => freePrintItemDrug3 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug4 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug4 { get => freePrintItemDrug4; set => freePrintItemDrug4 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug5 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug5 { get => freePrintItemDrug5; set => freePrintItemDrug5 = value; }

        [StringLength(1, ErrorMessage = "SyntheticFlg : ขนาดข้อมูลเกิน 1 ตัวอักษร ")]
        public string SyntheticFlg { get => syntheticFlg; set => syntheticFlg = value; }

        [StringLength(1, ErrorMessage = "CutFlg : ขนาดข้อมูลเกิน 1 ตัวอักษร ")]
        public string CutFlg { get => cutFlg; set => cutFlg = value; }

        [StringLength(20, ErrorMessage = "PharmacyTime : ขนาดข้อมูลเกิน 20 ตัวอักษร ")]
        public string PharmacyTime { get => pharmacyTime; set => pharmacyTime = value; }

        [StringLength(10, ErrorMessage = "CarvedSeal : ขนาดข้อมูลเกิน 10 ตัวอักษร ")]
        public string CarvedSeal { get => carvedSeal; set => carvedSeal = value; }

        [StringLength(4, ErrorMessage = "CarvedSealAbb : ขนาดข้อมูลเกิน 4 ตัวอักษร ")]
        public string CarvedSealAbb { get => carvedSealAbb; set => carvedSealAbb = value; }

        [StringLength(500, ErrorMessage = "PreBarcode1 : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string PreBarcode1 { get => preBarcode1; set => preBarcode1 = value; }

        [StringLength(500, ErrorMessage = "PreBarcode2 : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string PreBarcode2 { get => preBarcode2; set => preBarcode2 = value; }

        [StringLength(500, ErrorMessage = "PreDrugBarcode : ขนาดข้อมูลเกิน 500 ตัวอักษร ")]
        public string PreDrugBarcode { get => preDrugBarcode; set => preDrugBarcode = value; }

        [StringLength(100, ErrorMessage = "PreBarcodeFmt : ขนาดข้อมูลเกิน 100 ตัวอักษร ")]
        public string PreBarcodeFmt { get => preBarcodeFmt; set => preBarcodeFmt = value; }

        [StringLength(30, ErrorMessage = "HisID : ขนาดข้อมูลเกิน 30 ตัวอักษร ")]
        public string HisID { get => hisID; set => hisID = value; }

        [StringLength(30, ErrorMessage = "BoxCntStandard : ขนาดข้อมูลเกิน 30 ตัวอักษร ")]
        public string BoxCntStandard { get => boxCntStandard; set => boxCntStandard = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode1 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode1 { get => drugBarcode1; set => drugBarcode1 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode2 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode2 { get => drugBarcode2; set => drugBarcode2 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode3 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode3 { get => drugBarcode3; set => drugBarcode3 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode4 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode4 { get => drugBarcode4; set => drugBarcode4 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode5 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode5 { get => drugBarcode5; set => drugBarcode5 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode6 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode6 { get => drugBarcode6; set => drugBarcode6 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode7 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode7 { get => drugBarcode7; set => drugBarcode7 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode8 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode8 { get => drugBarcode8; set => drugBarcode8 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode9 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode9 { get => drugBarcode9; set => drugBarcode9 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode10 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode10 { get => drugBarcode10; set => drugBarcode10 = value; }

        [StringLength(1000, ErrorMessage = "MassPrint1 : ขนาดข้อมูลเกิน 1000 ตัวอักษร ")]
        public string MassPrint1 { get => massPrint1; set => massPrint1 = value; }

        [StringLength(4000, ErrorMessage = "MassPrint2 : ขนาดข้อมูลเกิน 4000 ตัวอักษร ")]
        public string MassPrint2 { get => massPrint2; set => massPrint2 = value; }

        [StringLength(1000, ErrorMessage = "MassPrint3 : ขนาดข้อมูลเกิน 1000 ตัวอักษร ")]
        public string MassPrint3 { get => massPrint3; set => massPrint3 = value; }

        [StringLength(1000, ErrorMessage = "MassPrint4 : ขนาดข้อมูลเกิน 1000 ตัวอักษร ")]
        public string MassPrint4 { get => massPrint4; set => massPrint4 = value; }

        [StringLength(4000, ErrorMessage = "MassPrint5 : ขนาดข้อมูลเกิน 4000 ตัวอักษร ")]
        public string MassPrint5 { get => massPrint5; set => massPrint5 = value; }

        [StringLength(1000, ErrorMessage = "MassPrint6 : ขนาดข้อมูลเกิน 1000 ตัวอักษร ")]
        public string MassPrint6 { get => massPrint6; set => massPrint6 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug6 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug6 { get => freePrintItemDrug6; set => freePrintItemDrug6 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug7 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug7 { get => freePrintItemDrug7; set => freePrintItemDrug7 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug8 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug8 { get => freePrintItemDrug8; set => freePrintItemDrug8 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug9 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug9 { get => freePrintItemDrug9; set => freePrintItemDrug9 = value; }

        [StringLength(200, ErrorMessage = "FreePrintItemDrug10 : ขนาดข้อมูลเกิน 200 ตัวอักษร ")]
        public string FreePrintItemDrug10 { get => freePrintItemDrug10; set => freePrintItemDrug10 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessageFlg { get => insertMessageFlg; set => insertMessageFlg = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessageBagPrintFmt { get => insertMessageBagPrintFmt; set => insertMessageBagPrintFmt = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessageBagLen { get => insertMessageBagLen; set => insertMessageBagLen = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessageTakeDate { get => insertMessageTakeDate; set => insertMessageTakeDate = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessage11 { get => InsertMessage1; set => InsertMessage1 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessage21 { get => InsertMessage2; set => InsertMessage2 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string InsertMessage31 { get => InsertMessage3; set => InsertMessage3 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string DrugPac { get => drugPac; set => drugPac = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string DrugTouchPanel { get => drugTouchPanel; set => drugTouchPanel = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug11 { get => freePrintItemDrug11; set => freePrintItemDrug11 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug12 { get => freePrintItemDrug12; set => freePrintItemDrug12 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug13 { get => freePrintItemDrug13; set => freePrintItemDrug13 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug14 { get => freePrintItemDrug14; set => freePrintItemDrug14 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug15 { get => freePrintItemDrug15; set => freePrintItemDrug15 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug16 { get => freePrintItemDrug16; set => freePrintItemDrug16 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug17 { get => freePrintItemDrug17; set => freePrintItemDrug17 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug18 { get => freePrintItemDrug18; set => freePrintItemDrug18 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug19 { get => freePrintItemDrug19; set => freePrintItemDrug19 = value; }

        [StringLength(40, ErrorMessage = "PrescriptionNo : ขนาดข้อมูลเกิน 40 ตัวอักษร ")]
        public string FreePrintItemDrug20 { get => freePrintItemDrug20; set => freePrintItemDrug20 = value; }

        public JSDDNET_Prescription()
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
            SQL += "dbo.M_Prescription.FieldUpdate ";
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

        public DataSet GetDisplayGanttChartMedicationPlanData(string wardcode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.TakeDate ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";

            if (wardcode != null)
            {
                SQL += "WHERE ";
                SQL += "dbo.M_Prescription.WardCd ='" + wardcode + "' ";
            }

            SQL += "GROUP BY ";
            SQL += "dbo.M_Prescription.PatientId,";
            SQL += "dbo.M_Prescription.PatientName,";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.WardName,";
            SQL += "dbo.M_Prescription.RoomNo,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.TakeDate ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.PatientAn,";
            SQL += "dbo.M_Prescription.WardCd,";
            SQL += "dbo.M_Prescription.BedNo,";
            SQL += "dbo.M_Prescription.TakeDate ASC";
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
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,TakeDate,112) =@TakeDate ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayGanttChartMedicationPlanDataDetailBar(string PatientName, string TakeDate, string TakeTime)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "* ";
            SQL += "FROM ";
            SQL += "dbo.M_Prescription ";
            SQL += "WHERE ";
            SQL += "dbo.M_Prescription.PatientName =@PatientName ";
            SQL += "AND ";
            SQL += "CONVERT(VARCHAR,TakeDate,112) =@TakeDate ";
            SQL += "AND ";
            SQL += "dbo.M_Prescription.Freq_Desc_Detail_Code =@TakeTime ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Prescription.TakeTime ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@PatientName", PatientName));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", TakeTime));
                return conn.FillSQL(cmd);
            }
        }

        public DataSet GetDisplayDataToolTipDetail(string prescription, string drugname, string takedate, string taketime)
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

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", prescription));
                cmd.Parameters.Add(new SqlParameter("@DrugName", drugname));
                cmd.Parameters.Add(new SqlParameter("@TakeDate", takedate));
                cmd.Parameters.Add(new SqlParameter("@TakeTime", taketime));
                return conn.FillSQL(cmd);
            }
        }

        public bool InsertDataPrescription()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.Prescription (";
            SQL += "dbo.Prescription.PrescriptionNo,";
            SQL += "dbo.Prescription.SeqNo,";
            SQL += "dbo.Prescription.Group_No,";
            SQL += "dbo.Prescription.MachineNo,";
            SQL += "dbo.Prescription.ProcFlg,";
            SQL += "dbo.Prescription.PatientId,";
            SQL += "dbo.Prescription.PatientName,";
            SQL += "dbo.Prescription.EnglishName,";
            SQL += "dbo.Prescription.Birthday,";
            SQL += "dbo.Prescription.Sex,";
            SQL += "dbo.Prescription.IOFlg,";
            SQL += "dbo.Prescription.WardCd,";
            SQL += "dbo.Prescription.WardName,";
            SQL += "dbo.Prescription.RoomNo,";
            SQL += "dbo.Prescription.BedNo,";
            SQL += "dbo.Prescription.DoctorCd,";
            SQL += "dbo.Prescription.DoctorName,";
            SQL += "dbo.Prescription.PrescriptionDate,";
            SQL += "dbo.Prescription.TakeDate,";
            SQL += "dbo.Prescription.TakeTime,";
            SQL += "dbo.Prescription.LastTime,";
            SQL += "dbo.Prescription.Presc_Class,";
            SQL += "dbo.Prescription.DrugCd,";
            SQL += "dbo.Prescription.DrugName,";
            SQL += "dbo.Prescription.DrugShape,";
            SQL += "dbo.Prescription.PrescriptionDose,";
            SQL += "dbo.Prescription.PrescriptionUnit,";
            SQL += "dbo.Prescription.DispensedDose,";
            SQL += "dbo.Prescription.DispensedTotalDose,";
            SQL += "dbo.Prescription.DispensedUnit,";
            SQL += "dbo.Prescription.Amount_Per_Package,";
            SQL += "dbo.Prescription.Firm_Id,";
            SQL += "dbo.Prescription.Dispense_Days,";
            SQL += "dbo.Prescription.Freq_Desc_Code,";
            SQL += "dbo.Prescription.Freq_Desc,";
            SQL += "dbo.Prescription.Freq_Counter,";
            SQL += "dbo.Prescription.Freq_Desc_Detail_Code,";
            SQL += "dbo.Prescription.Freq_Desc_Detail,";
            SQL += "dbo.Prescription.Explanation_Code,";
            SQL += "dbo.Prescription.Explanation,";
            SQL += "dbo.Prescription.Administration_Name,";
            SQL += "dbo.Prescription.DoctorComment,";
            SQL += "dbo.Prescription.BagOrderby,";
            SQL += "dbo.Prescription.MakeRecTime,";
            SQL += "dbo.Prescription.UpDateRecTime,";
            SQL += "dbo.Prescription.Filler,";
            SQL += "dbo.Prescription.Order_No,";
            SQL += "dbo.Prescription.Order_Sub_No,";
            SQL += "dbo.Prescription.BagPrintFmt,";
            SQL += "dbo.Prescription.BagLen,";
            SQL += "dbo.Prescription.BagPrintPatientNm,";
            SQL += "dbo.Prescription.TicketNo,";
            SQL += "dbo.Prescription.FreePrintItem_Presc1,";
            SQL += "dbo.Prescription.FreePrintItem_Presc2,";
            SQL += "dbo.Prescription.FreePrintItem_Presc3,";
            SQL += "dbo.Prescription.FreePrintItem_Presc4,";
            SQL += "dbo.Prescription.FreePrintItem_Presc5,";
            SQL += "dbo.Prescription.FreePrintItem_Drug1,";
            SQL += "dbo.Prescription.FreePrintItem_Drug2,";
            SQL += "dbo.Prescription.FreePrintItem_Drug3,";
            SQL += "dbo.Prescription.FreePrintItem_Drug4,";
            SQL += "dbo.Prescription.FreePrintItem_Drug5,";
            SQL += "dbo.Prescription.SyntheticFlg,";
            SQL += "dbo.Prescription.CutFlg,";
            SQL += "dbo.Prescription.PharmacyTime,";
            SQL += "dbo.Prescription.CarvedSeal,";
            SQL += "dbo.Prescription.CarvedSealAbb,";
            SQL += "dbo.Prescription.PreBarcode1,";
            SQL += "dbo.Prescription.PreBarcode2,";
            SQL += "dbo.Prescription.PreDrugBarcode,";
            SQL += "dbo.Prescription.PreBarcodeFmt,";
            SQL += "dbo.Prescription.HisId,";
            SQL += "dbo.Prescription.BoxCntStandard,";
            SQL += "dbo.Prescription.DrugBarcode1,";
            SQL += "dbo.Prescription.DrugBarcode2,";
            SQL += "dbo.Prescription.DrugBarcode3,";
            SQL += "dbo.Prescription.DrugBarcode4,";
            SQL += "dbo.Prescription.DrugBarcode5,";
            SQL += "dbo.Prescription.DrugBarcode6,";
            SQL += "dbo.Prescription.DrugBarcode7,";
            SQL += "dbo.Prescription.DrugBarcode8,";
            SQL += "dbo.Prescription.DrugBarcode9,";
            SQL += "dbo.Prescription.DrugBarcode10,";
            SQL += "dbo.Prescription.MassPrint1,";
            SQL += "dbo.Prescription.MassPrint2,";
            SQL += "dbo.Prescription.MassPrint3,";
            SQL += "dbo.Prescription.MassPrint4,";
            SQL += "dbo.Prescription.MassPrint5,";
            SQL += "dbo.Prescription.MassPrint6,";
            SQL += "dbo.Prescription.FreePrintItem_Drug6,";
            SQL += "dbo.Prescription.FreePrintItem_Drug7,";
            SQL += "dbo.Prescription.FreePrintItem_Drug8,";
            SQL += "dbo.Prescription.FreePrintItem_Drug9,";
            SQL += "dbo.Prescription.FreePrintItem_Drug10,";
            SQL += "dbo.Prescription.InsertMessageFlg,";
            SQL += "dbo.Prescription.InsertMessageBagPrintFmt,";
            SQL += "dbo.Prescription.InsertMessageBagLen,";
            SQL += "dbo.Prescription.InsertMessageTakeDate,";
            SQL += "dbo.Prescription.InsertMessage1,";
            SQL += "dbo.Prescription.InsertMessage2,";
            SQL += "dbo.Prescription.InsertMessage3,";
            SQL += "dbo.Prescription.DrugPac,";
            SQL += "dbo.Prescription.DrugTouchPanel,";
            SQL += "dbo.Prescription.FreePrintItem_Drug11,";
            SQL += "dbo.Prescription.FreePrintItem_Drug12,";
            SQL += "dbo.Prescription.FreePrintItem_Drug13,";
            SQL += "dbo.Prescription.FreePrintItem_Drug14,";
            SQL += "dbo.Prescription.FreePrintItem_Drug15,";
            SQL += "dbo.Prescription.FreePrintItem_Drug16,";
            SQL += "dbo.Prescription.FreePrintItem_Drug17,";
            SQL += "dbo.Prescription.FreePrintItem_Drug18,";
            SQL += "dbo.Prescription.FreePrintItem_Drug19,";
            SQL += "dbo.Prescription.FreePrintItem_Drug20) ";
            SQL += "VALUES (";
            SQL += "@PrescriptionNo,";
            SQL += "@SeqNo,";
            SQL += "@Group_No,";
            SQL += "@MachineNo,";
            SQL += "@ProcFlg,";
            SQL += "@PatientId,";
            SQL += "@PatientName,";
            SQL += "@EnglishName,";
            SQL += "@Birthday,";
            SQL += "@Sex,";
            SQL += "@IOFlg,";
            SQL += "@WardCd,";
            SQL += "@WardName,";
            SQL += "@RoomNo,";
            SQL += "@BedNo,";
            SQL += "@DoctorCd,";
            SQL += "@DoctorName,";
            SQL += "@PrescriptionDate,";
            SQL += "@TakeDate,";
            SQL += "@TakeTime,";
            SQL += "@LastTime,";
            SQL += "@Presc_Class,";
            SQL += "@DrugCd,";
            SQL += "@DrugName,";
            SQL += "@DrugShape,";
            SQL += "@PrescriptionDose,";
            SQL += "@PrescriptionUnit,";
            SQL += "@DispensedDose,";
            SQL += "@DispensedTotalDose,";
            SQL += "@DispensedUnit,";
            SQL += "@Amount_Per_Package,";
            SQL += "@Firm_Id,";
            SQL += "@Dispense_Days,";
            SQL += "@Freq_Desc_Code,";
            SQL += "@Freq_Desc,";
            SQL += "@Freq_Counter,";
            SQL += "@Freq_Desc_Detail_Code,";
            SQL += "@Freq_Desc_Detail,";
            SQL += "@Explanation_Code,";
            SQL += "@Explanation,";
            SQL += "@Administration_Name,";
            SQL += "@DoctorComment,";
            SQL += "@BagOrderby,";
            SQL += "@MakeRecTime,";
            SQL += "@UpDateRecTime,";
            SQL += "@Filler,";
            SQL += "@Order_No,";
            SQL += "@Order_Sub_No,";
            SQL += "@BagPrintFmt,";
            SQL += "@BagLen,";
            SQL += "@BagPrintPatientNm,";
            SQL += "@TicketNo,";
            SQL += "@FreePrintItem_Presc1,";
            SQL += "@FreePrintItem_Presc2,";
            SQL += "@FreePrintItem_Presc3,";
            SQL += "@FreePrintItem_Presc4,";
            SQL += "@FreePrintItem_Presc5,";
            SQL += "@FreePrintItem_Drug1,";
            SQL += "@FreePrintItem_Drug2,";
            SQL += "@FreePrintItem_Drug3,";
            SQL += "@FreePrintItem_Drug4,";
            SQL += "@FreePrintItem_Drug5,";
            SQL += "@SyntheticFlg,";
            SQL += "@CutFlg,";
            SQL += "@PharmacyTime,";
            SQL += "@CarvedSeal,";
            SQL += "@CarvedSealAbb,";
            SQL += "@PreBarcode1,";
            SQL += "@PreBarcode2,";
            SQL += "@PreDrugBarcode,";
            SQL += "@PreBarcodeFmt,";
            SQL += "@HisId,";
            SQL += "@BoxCntStandard,";
            SQL += "@DrugBarcode1,";
            SQL += "@DrugBarcode2,";
            SQL += "@DrugBarcode3,";
            SQL += "@DrugBarcode4,";
            SQL += "@DrugBarcode5,";
            SQL += "@DrugBarcode6,";
            SQL += "@DrugBarcode7,";
            SQL += "@DrugBarcode8,";
            SQL += "@DrugBarcode9,";
            SQL += "@DrugBarcode10,";
            SQL += "@MassPrint1,";
            SQL += "@MassPrint2,";
            SQL += "@MassPrint3,";
            SQL += "@MassPrint4,";
            SQL += "@MassPrint5,";
            SQL += "@MassPrint6,";
            SQL += "@FreePrintItem_Drug6,";
            SQL += "@FreePrintItem_Drug7,";
            SQL += "@FreePrintItem_Drug8,";
            SQL += "@FreePrintItem_Drug9,";
            SQL += "@FreePrintItem_Drug10,";
            SQL += "@InsertMessageFlg,";
            SQL += "@InsertMessageBagPrintFmt,";
            SQL += "@InsertMessageBagLen,";
            SQL += "@InsertMessageTakeDate,";
            SQL += "@InsertMessage1,";
            SQL += "@InsertMessage2,";
            SQL += "@InsertMessage3,";
            SQL += "@DrugPac,";
            SQL += "@DrugTouchPanel,";
            SQL += "@FreePrintItem_Drug11,";
            SQL += "@FreePrintItem_Drug12,";
            SQL += "@FreePrintItem_Drug13,";
            SQL += "@FreePrintItem_Drug14,";
            SQL += "@FreePrintItem_Drug15,";
            SQL += "@FreePrintItem_Drug16,";
            SQL += "@FreePrintItem_Drug17,";
            SQL += "@FreePrintItem_Drug18,";
            SQL += "@FreePrintItem_Drug19,";
            SQL += "@FreePrintItem_Drug20) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(SQL))
                {
                    cmd.Parameters.Add(new SqlParameter("@PrescriptionNo", PrescriptionNo));
                    cmd.Parameters.Add(new SqlParameter("@SeqNo", SeqNo));
                    cmd.Parameters.Add(new SqlParameter("@Group_No", GroupNo));
                    cmd.Parameters.Add(new SqlParameter("@MachineNo", MachineNo));
                    cmd.Parameters.Add(new SqlParameter("@ProcFlg", ProFlg));
                    cmd.Parameters.Add(new SqlParameter("@PatientId", PatientId));
                    cmd.Parameters.Add(new SqlParameter("@PatientName", PatientName));
                    cmd.Parameters.Add(new SqlParameter("@EnglishName", EnglishName));
                    cmd.Parameters.Add(new SqlParameter("@Birthday", BrithDay));
                    cmd.Parameters.Add(new SqlParameter("@Sex", Sex));
                    cmd.Parameters.Add(new SqlParameter("@IOFlg", IoFlg));
                    cmd.Parameters.Add(new SqlParameter("@WardCd", WardCd));
                    cmd.Parameters.Add(new SqlParameter("@WardName", WardName));
                    cmd.Parameters.Add(new SqlParameter("@RoomNo", RoomNo));
                    cmd.Parameters.Add(new SqlParameter("@BedNo", BedNo));
                    cmd.Parameters.Add(new SqlParameter("@DoctorCd", DoctorCd));
                    cmd.Parameters.Add(new SqlParameter("@DoctorName", DoctorName));
                    cmd.Parameters.Add(new SqlParameter("@PrescriptionDate", PrescriptionDate));
                    cmd.Parameters.Add(new SqlParameter("@TakeDate", TakeDate));
                    cmd.Parameters.Add(new SqlParameter("@TakeTime", TakeTime));
                    cmd.Parameters.Add(new SqlParameter("@LastTime", LastTime));
                    cmd.Parameters.Add(new SqlParameter("@Presc_Class", PrescClass));
                    cmd.Parameters.Add(new SqlParameter("@DrugCd", DrugCd));
                    cmd.Parameters.Add(new SqlParameter("@DrugName", DrugName));
                    cmd.Parameters.Add(new SqlParameter("@DrugShape", DrugShape));
                    cmd.Parameters.Add(new SqlParameter("@PrescriptionDose", PrescriptionDose));
                    cmd.Parameters.Add(new SqlParameter("@PrescriptionUnit", PrescriptionUnit));
                    cmd.Parameters.Add(new SqlParameter("@DispensedDose", DispenseDose));
                    cmd.Parameters.Add(new SqlParameter("@DispensedTotalDose", DispenseTotalDose));
                    cmd.Parameters.Add(new SqlParameter("@DispensedUnit", DispenseUnit));
                    cmd.Parameters.Add(new SqlParameter("@Amount_Per_Package", AmountPerPackage));
                    cmd.Parameters.Add(new SqlParameter("@Firm_Id", FirmID));
                    cmd.Parameters.Add(new SqlParameter("@Dispense_Days", DispenseDays));
                    cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Code", FreqDescCode));
                    cmd.Parameters.Add(new SqlParameter("@Freq_Desc", FreqDesc));
                    cmd.Parameters.Add(new SqlParameter("@Freq_Counter", FreqCounter));
                    cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail_Code", FreqDescDetailCode));
                    cmd.Parameters.Add(new SqlParameter("@Freq_Desc_Detail", FreqDescDetail));
                    cmd.Parameters.Add(new SqlParameter("@Explanation_Code", ExplanationCode));
                    cmd.Parameters.Add(new SqlParameter("@Explanation", Explanation));
                    cmd.Parameters.Add(new SqlParameter("@Administration_Name", AdministrationName));
                    cmd.Parameters.Add(new SqlParameter("@DoctorComment", DoctorComment));
                    cmd.Parameters.Add(new SqlParameter("@BagOrderby", BagOrderby));
                    cmd.Parameters.Add(new SqlParameter("@MakeRecTime", MakeRecTime));
                    cmd.Parameters.Add(new SqlParameter("@UpDateRecTime", UpDateRecTime));
                    cmd.Parameters.Add(new SqlParameter("@Filler", Filler));
                    cmd.Parameters.Add(new SqlParameter("@Order_No", OrderNo));
                    cmd.Parameters.Add(new SqlParameter("@Order_Sub_No", OrderSubNo));
                    cmd.Parameters.Add(new SqlParameter("@BagPrintFmt", BagPrintFmt));
                    cmd.Parameters.Add(new SqlParameter("@BagLen", BagLen));
                    cmd.Parameters.Add(new SqlParameter("@BagPrintPatientNm", BagPrintPatientNm));
                    cmd.Parameters.Add(new SqlParameter("@TicketNo", TicketNo));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc1", FreePrintItemDrug1));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc2", FreePrintItemDrug2));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc3", FreePrintItemDrug3));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc4", FreePrintItemDrug4));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Presc5", FreePrintItemDrug5));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug1", FreePrintItemDrug6));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug2", FreePrintItemDrug7));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug3", FreePrintItemDrug8));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug4", FreePrintItemDrug9));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug5", FreePrintItemDrug10));
                    cmd.Parameters.Add(new SqlParameter("@SyntheticFlg", SyntheticFlg));
                    cmd.Parameters.Add(new SqlParameter("@CutFlg", CutFlg));
                    cmd.Parameters.Add(new SqlParameter("@PharmacyTime", PharmacyTime));
                    cmd.Parameters.Add(new SqlParameter("@CarvedSeal", CarvedSeal));
                    cmd.Parameters.Add(new SqlParameter("@CarvedSealAbb", CarvedSealAbb));
                    cmd.Parameters.Add(new SqlParameter("@PreBarcode1", PreBarcode1));
                    cmd.Parameters.Add(new SqlParameter("@PreBarcode2", PreBarcode2));
                    cmd.Parameters.Add(new SqlParameter("@PreDrugBarcode", PreDrugBarcode));
                    cmd.Parameters.Add(new SqlParameter("@PreBarcodeFmt", PreBarcodeFmt));
                    cmd.Parameters.Add(new SqlParameter("@HisId", HisID));
                    cmd.Parameters.Add(new SqlParameter("@BoxCntStandard", BoxCntStandard));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode1", DrugBarcode1));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode2", DrugBarcode2));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode3", DrugBarcode3));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode4", DrugBarcode4));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode5", DrugBarcode5));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode6", DrugBarcode6));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode7", DrugBarcode7));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode8", DrugBarcode8));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode9", DrugBarcode9));
                    cmd.Parameters.Add(new SqlParameter("@DrugBarcode10", DrugBarcode10));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint1", MassPrint1));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint2", MassPrint2));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint3", MassPrint3));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint4", MassPrint4));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint5", MassPrint5));
                    cmd.Parameters.Add(new SqlParameter("@MassPrint6", MassPrint6));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug6", FreePrintItemDrug6));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug7", FreePrintItemDrug7));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug8", FreePrintItemDrug8));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug9", FreePrintItemDrug9));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug10", FreePrintItemDrug10));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessageFlg", InsertMessageFlg));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessageBagPrintFmt", InsertMessageBagPrintFmt));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessageBagLen", InsertMessageBagLen));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessageTakeDate", InsertMessageTakeDate));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessage1", InsertMessage1));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessage2", InsertMessage2));
                    cmd.Parameters.Add(new SqlParameter("@InsertMessage3", InsertMessage3));
                    cmd.Parameters.Add(new SqlParameter("@DrugPac", DrugPac));
                    cmd.Parameters.Add(new SqlParameter("@DrugTouchPanel", DrugTouchPanel));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug11", FreePrintItemDrug11));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug12", FreePrintItemDrug12));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug13", FreePrintItemDrug13));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug14", FreePrintItemDrug14));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug15", FreePrintItemDrug15));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug16", FreePrintItemDrug16));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug17", FreePrintItemDrug17));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug18", FreePrintItemDrug18));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug19", FreePrintItemDrug19));
                    cmd.Parameters.Add(new SqlParameter("@FreePrintItem_Drug20", FreePrintItemDrug20));

                    return conn.ExecuteNonQuerySQL(cmd);
                }
            }
            catch (Exception e) { throw new Exception("Class JSDDNET_Prescription Error => InsertDataPrescription :" + e.Message); }
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
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@FieldUpdate", Prescription));
                return (DateTime)conn.ExecuteScalarSQL(cmd);
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