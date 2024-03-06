using ConHIS.API.Controllers;
using ConHIS.API.Models;
using ConHIS.Libary_Class.PNNInterface.HL7Structure;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;

namespace ConHIS.Libary_Class.PNNInterface.Features
{
    public class MappingMiddleController
    {
        private readonly Thaneshopmiddle_ATPM th;
        private readonly Thaneshopmiddle_extentions_ATPM ext;

        private hosxp_conhis_machine hos;
        private master_druginfomation druginfomation;
        private master_frequencyInfo frequencyinfo;

        private master_prescription prescription;

        private string OrderControl = string.Empty;
        private string OrderStatus = string.Empty;
        private bool OrderReplace = false;

        private readonly MSH msh;
        private readonly AL1 al1;
        private readonly NTE nte;
        private readonly ORC orc;
        private readonly PID pid;
        private readonly PV1 pv1;
        private readonly RXE rxe;
        private readonly RXR rxr;
        private readonly TQ1 tq1;
        private readonly EVN evn;

        private System_logfile logs;

        public string EventFileType { get; }
        public string ActiveFileType { get; }

        public MappingMiddleController(string EventFileType,string ActiveFileType)
        {
            msh = new MSH();
            al1 = new AL1();
            nte = new NTE();
            orc = new ORC();
            pid = new PID();
            pv1 = new PV1();
            rxe = new RXE();
            rxr = new RXR();
            tq1 = new TQ1();
            evn = new EVN();

            th = new Thaneshopmiddle_ATPM();
            ext = new Thaneshopmiddle_extentions_ATPM();
            druginfomation = new master_druginfomation();
            frequencyinfo = new master_frequencyInfo();
            prescription = new master_prescription();
            logs = new System_logfile();

            hos = new hosxp_conhis_machine();

            this.EventFileType = EventFileType;
            this.ActiveFileType = ActiveFileType;
        }

        public bool MiddleActiveEventHandler(string SetCode)
        {
            bool result = false;
            string[] strArray = { };
            try
            {
                switch (EventFileType) 
                {
                    case "RDE":
                        switch (ActiveFileType)
                        {
                            // O01 - Pharmacy/treatment encoded order message
                            case "O01":
                               result = AddEditNewMiddleAndExtenstion(SetCode);
                               break;
                        }
                        break;
                    case "ADT":
                        switch (ActiveFileType)
                        {
                            // A01 - Admit/visit notification
                            case "A01":
                               
                                break;
                            // A02 - Transfer a patient
                            case "A02":
                                
                                break;
                            // A03 - Discharge/end visit
                            case "A03":
                                
                                break;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                result = false;
                logs.Writelogfile("ID : {" + SetCode + "} " + ex.Message, " Error_MappingMiddleController");
            }
            return result;
        }
        
        private bool AddEditNewMiddleAndExtenstion(string SetCode)
        {
            bool result = false;
            string[] strArray ;
            try
            {
                //ตรวจเฉพาะยาที่ส่งเข้าเครื่องเท่านั้น ตัวอื่นไม่สนใจ
                DataSet dsRXR = rxr.SelectRXRToMachineNo(SetCode);

                th.SeqMax = dsRXR.Tables[0].Rows.Count;

                if (dsRXR.Tables[0].Rows.Count != 0)
                {
                    int seqCount = 0;
                    foreach (DataRow rowRxr in dsRXR.Tables[0].Rows)
                    {
                        seqCount++;
                        th.Seq = seqCount;

                        string drugcode = (rowRxr["RXR_1"].ToString());

                        DataSet dsRXE = rxe.SelectRXEByDrugCode(SetCode, drugcode);
                        DataSet dsORC = orc.SelectORC(SetCode);
                        DataSet dsPID = pid.SelectPID(SetCode);
                        DataSet dsPV1 = pv1.SelectPV1(SetCode);
                        DataSet dsAL1 = al1.SelectAL1(SetCode);
                        DataSet dsMSH = msh.SelectMSH(SetCode);

                        if (dsRXE.Tables[0].Rows.Count != 0)
                        {
                            th.DispenseStatus = 0;
                            foreach (DataRow row in dsRXE.Tables[0].Rows)
                            {

                                if (DeGet(row["RXE_2"].ToString()).Length >= 5)
                                {
                                    th.OrderItemCode = DeGet(row["RXE_2"].ToString())[3].Trim();
                                    th.OrderItemName = DeGet(SemiGet(row["RXE_2"].ToString())[0])[4].Trim();
                                }
                                else { throw new Exception("RXE 2 :" + row["RXE_2"].ToString() + " ไม่ถูก Format"); }

                                if (DeGet(row["RXE_7"].ToString()).Length > 3)
                                {
                                    th.ItemIdentify = DeGet(row["RXE_7"].ToString())[1].Trim();
                                    ext.DrugLabelName = DeGet(row["RXE_7"].ToString())[2].Trim();
                                    th.FrequencyCode = DeGet(row["RXE_7"].ToString())[3].Trim();
                                }
                                else if (DeGet(row["RXE_7"].ToString()).Length == 3)
                                {
                                    th.ItemIdentify = DeGet(row["RXE_7"].ToString())[1].Trim();
                                    ext.DrugLabelName = DeGet(row["RXE_7"].ToString())[2].Trim();
                                    th.FrequencyCode = "Gen";
                                }
                                else
                                {
                                    th.ItemIdentify = "";
                                    ext.DrugLabelName = "";
                                    th.FrequencyCode = "Gen";
                                }

                                if (DeGet(row["RXE_14"].ToString()).Length >= 2)
                                {
                                    th.DoctorCode = DeGet(row["RXE_14"].ToString())[0].Trim();        // 21/03/65 ไม่มีข้อมูล
                                    th.DoctorName = DeGet(row["RXE_14"].ToString())[1].Trim();        // 21/03/65 ไม่มีข้อมูล
                                }
                                else
                                {
                                    th.DoctorCode = "";
                                    th.DoctorName = "";
                                }

                                if (row["RXE_28"].ToString() == "")
                                {
                                    th.PriorityCode = "Z";
                                    th.PriorityDesc = "-ไม่มี Priorty-";
                                    th.DispenseStatus = 3;
                                }
                                else
                                {
                                    th.PriorityCode = row["RXE_28"].ToString().Substring(0, 1);
                                    th.PriorityDesc = row["RXE_28"].ToString();
                                }

                                if (row["RXE_30"].ToString() != "")
                                {
                                    th.FrequencyCode = "Gen";
                                    th.FrequencyDesc = GenFrequencyDesc(row["RXE_30"].ToString());
                                }
                                else {
                                    th.FrequencyCode = "Gen"; th.FrequencyDesc = "รับประทานครั้งละ 0 หน่วย วันละ 1 ครั้ง ไม่มีข้อมูล(*frequency*)สร้างจำลองไว้โดยระบบ";
                                    th.DispenseStatus = 3;
                                }
                                th.ItemLotNo = "";
                                th.ItemLotExpire = DateTime.Now;

                                th.OrderTargetDate = row["RXE_18"].ToString().Substring(6, 2) + "/" + row["RXE_18"].ToString().Substring(4, 2) + "/" + row["RXE_18"].ToString().Substring(0, 4);   // 21/03/65 ไม่มีข้อมูล
                                th.OrderTargetTime = row["RXE_18"].ToString().Substring(8, 8);     // 21/03/65 ไม่มีข้อมูล

                                if (th.FrequencyDesc.Contains("ครึ่งเม็ด") || th.FrequencyDesc.Contains("หนึ่งส่วนแปดเม็ด") || th.FrequencyDesc.Contains("หนึ่งส่วนสี่เม็ด") || th.FrequencyDesc.Contains("สามส่วนสี่เม็ด"))
                                    th.FrequencyDesc = th.FrequencyDesc.Replace("เม็ด", " เม็ด");

                                th.FrequencyDesc = th.FrequencyDesc.Replace(" ครั้งละ", "ครั้งละ");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("ทุกๆ", "ทุก");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("-", " ");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("เที่ยง", "กลางวัน");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1 ใน 2", "ครึ่ง");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1 ใน 4", "หนึ่งส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1 ใน 8", "หนึ่งส่วนแปด");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("3 ใน 4", "สามส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1/2", "ครึ่ง");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1/4", "หนึ่งส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1/8", "หนึ่งส่วนแปด");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("3/4", "สามส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("หนึ่งในสอง", "ครึ่ง");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("หนึ่งในสี่", "หนึ่งส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("หนึ่งในแปด", "หนึ่งส่วนแปด");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("สามในสี่", "สามส่วนสี่");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("    ", " ");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("   ", " ");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("  ", " ");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("ครึ่งเม็ด", "0.5 เม็ด");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("1 เม็ดครึ่ง", "1.5 เม็ด");
                                th.FrequencyDesc = th.FrequencyDesc.Replace("เม็ดครึ่ง", "1.5 เม็ด");

                                //ตรวจสอบมื้อที่ไม่เท่ากัน 
                                string comparefrequency = th.FrequencyDesc.Replace("เม็ด", "^");
                                int keyStartCount = comparefrequency.Split('^').Length - 1;

                                if (keyStartCount > 1)   //มีโอกาสการกินมื้อที่ไม่เท่ากัน
                                {
                                    //(1,2,2,2)(07,12,18,19) =22 char

                                    comparefrequency = comparefrequency.Replace("ครึ่ง", "0.5");
                                    comparefrequency = comparefrequency.Replace("หนึ่งส่วนสี่", "0.25");
                                    comparefrequency = comparefrequency.Replace("หนึ่งส่วนแปด", "0.125");
                                    comparefrequency = comparefrequency.Replace("สามส่วนสี่", "0.75");
                                    th.DurationCode = GenDuration(comparefrequency);
                                    th.Dosage = 1;

                                    string strtime = "(" + GenFrequencyTime(comparefrequency).Replace("00", "") + ")";  //สร้างเวลา
                                    string[] arrCompare = comparefrequency.Split(' ');
                                    string dosagePerTime = string.Empty;
                                    string str = string.Empty;
                                    int d = 0;
                                    foreach (string dosestr in arrCompare)
                                    {
                                        if (dosestr == "^")
                                            str = arrCompare[(d - 1)].ToString() + ",";
                                        if (dosestr.Contains("เช้า"))
                                            dosagePerTime += str;
                                        if (dosestr.Contains("กลางวัน"))
                                            dosagePerTime += str;
                                        if (dosestr.Contains("เย็น"))
                                            dosagePerTime += str;
                                        if (dosestr.Contains("ก่อนนอน"))
                                            dosagePerTime += str;
                                        d++;
                                    }
                                    dosagePerTime = dosagePerTime.Substring(0, (dosagePerTime.Length - 1));
                                    string strdosage = "(" + dosagePerTime + ")";
                                    string totalNoStable = strdosage + strtime;
                                    th.DosageDispense = GenFrequencyNoStable(totalNoStable);
                                    th.FrequencyCode = "Gen";
                                    th.FrequencyTime = "";

                                    if (comparefrequency.Contains("วันละ") == false)
                                        th.FrequencyDesc = th.DurationCode + "th_วันละ " + GenDuration(th.FrequencyDesc).ToString() + " ครั้ง " + GenFrequencyDescForNoStable(strtime);                                 

                                    th.OrderUnitCode = "เม็ด";
                                    th.OrderUnitDesc = th.OrderUnitCode;
                                    th.DosageUnit = th.OrderUnitCode;
                                    th.InstructionCode = "Gen";
                                    th.InstructionDesc = "รับประทาน";

                                }
                                else
                                {
                                    th.FrequencyDesc = th.FrequencyDesc.Replace("  ", " ");
                                    th.FrequencyDesc = th.FrequencyDesc.Replace("   ", " ");
                                    string[] frequency = SpacGet(th.FrequencyDesc);
                                    int p = 0;
                                    string strFreqDesc = string.Empty;
                                    string strInstruc = string.Empty;
                                    foreach (string freq in frequency)
                                    {
                                        if (p <= 2)
                                            strInstruc += freq + " ";
                                        if (p >= 3)
                                            strFreqDesc += freq + " ";

                                        p++;
                                    }

                                    if (strFreqDesc.Contains("วันละ") == false)
                                        strFreqDesc = "วันละ " + GenDuration(th.FrequencyDesc).ToString() + " ครั้ง " + strFreqDesc.Replace("  ", " ");

                                    strFreqDesc = strFreqDesc.Replace("ครั้งเวลา", "ครั้ง");
                                    strFreqDesc = strFreqDesc.Replace("ครั้ง ครั้ง", "ครั้ง");
                                    strFreqDesc = strFreqDesc.Replace("เวลา ก่อน", "ครั้ง ก่อน");
                                    strFreqDesc = strFreqDesc.Replace("เวลา พร้อม", "ครั้ง พร้อม");
                                    strFreqDesc = strFreqDesc.Replace("เวลา หลัง", "ครั้ง หลัง");
                                    strFreqDesc = strFreqDesc.Replace("รับประทาน 2 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทาน 1 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้ง 2 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้ง 1 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้งละ 2 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้งละ 1 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทาน ครั้ง 2 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทาน ครั้ง 1 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้งละ ครั้ง 2 เม็ด", "");
                                    strFreqDesc = strFreqDesc.Replace("รับประทานครั้งละ ครั้ง 1 เม็ด", "");

                                    th.DurationCode = GenDuration(th.FrequencyDesc);

                                    if (th.FrequencyDesc.Contains("ใช้ตามแพทย์สั่ง"))
                                    {
                                        strFreqDesc = th.FrequencyDesc;
                                        th.FrequencyDesc = "รับประทาน 1 เม็ด คำสั่ง 1 ครั้ง " + strFreqDesc;
                                        th.DurationCode = 1;
                                    }
                                    else
                                    {
                                        strInstruc = strInstruc.Replace("  ", " ");
                                        th.FrequencyDesc = strInstruc.Replace("เวลา", "ครั้ง") + th.DurationCode + "th_" + strFreqDesc;
                                    }

                                    if (SpacGet(th.FrequencyDesc).Length <= 4 && th.FrequencyDesc.Contains("ก่อนนอน") == true)
                                        th.DurationCode = 1;
                                    else
                                        th.DurationCode = Convert.ToDecimal(SpacGet(th.FrequencyDesc)[4]);

                                    if (th.FrequencyDesc.Contains("เม็ดครึ่ง"))
                                        th.Dosage = GenDosageToDecimail(SpacGet(th.FrequencyDesc)[1]) + Convert.ToDecimal(0.5);
                                    else
                                        th.Dosage = GenDosageToDecimail(SpacGet(th.FrequencyDesc)[1]);     //*** ต้องคอยตรวจดู

                                    th.FrequencyTime = GenFrequencyTime(th.FrequencyDesc);

                                   // th.OrderQty = Math.Ceiling(th.DurationCode * th.Dosage);
                                    th.OrderUnitCode = SpacGet(th.FrequencyDesc)[2].Replace("เม็ดครึ่ง", "เม็ด");
                                    th.OrderUnitDesc = th.OrderUnitCode;
                                    th.DosageUnit = th.OrderUnitCode;
                                    th.InstructionCode = "Gen";
                                    th.InstructionDesc = SpacGet(th.FrequencyDesc)[0];
                                    th.FrequencyDesc = th.DurationCode + "th_" + strFreqDesc;
                                    th.DosageDispense = "";
                                }
                                try { th.OrderQty = Convert.ToDecimal(row["RXE_10"].ToString()); }
                                catch { throw new Exception("RXE 10 :" + row["RXE_10"].ToString() + " ไม่ใช่ตัวเลข"); }

                                th.RunningNo = DateTime.Now.ToString("HHmmssfff") + th.OrderItemCode;

                                if (DeGet(row["RXE_27"].ToString()).Length >= 2)
                                {
                                    th.PharmacyLocationCode = DeGet(row["RXE_27"].ToString())[0].Trim();
                                    th.PharmacyLocationDesc = DeGet(row["RXE_27"].ToString())[1].Trim();
                                }
                                else { 
                                    th.PharmacyLocationCode = "None";
                                    th.PharmacyLocationDesc = "-ไม่มีข้อมูล-";
                                    th.DispenseStatus = 3;
                                }

                                th.LastModified = DateTime.Now;
                                if (DeGet(row["RXE_5"].ToString()).Length >= 2)
                                    th.UserAcceptBy = DeGet(row["RXE_5"].ToString())[1].Trim();
                                else
                                    th.UserAcceptBy = "None";
                                th.UserOrderBy = th.UserAcceptBy;

                                if (dsORC.Tables[0].Rows.Count != 0)
                                {
                                    foreach (DataRow rowMsh in dsMSH.Tables[0].Rows)
                                    {
                                        th.PrescriptionDate = rowMsh["MSH_7"].ToString().Substring(0, 8);
                                    }
                                }

                                if (dsORC.Tables[0].Rows.Count != 0)
                                {
                                    foreach (DataRow rowOrc in dsORC.Tables[0].Rows)
                                    {
                                        OrderControl = rowOrc["ORC_1"].ToString();
                                        th.PrescriptionNo = rowOrc["ORC_2"].ToString();
                                        strArray = rowOrc["ORC_4"].ToString().Split('^');
                                        //string[] strDosage = dosage.ToString().Split('.');
                                        th.Comment = strArray[0];
                                        //th.DispenseStatus = 0;  // 21/03/65 ไม่มีข้อมูล
                                        th.Status = 0;          // 21/03/65 ไม่มีข้อมูล
                                        // th.PrescriptionDate = rowOrc["ORC_9"].ToString().Substring(0, 8);
                                        th.OrderAcceptFromIP = rowOrc["ORC_18"].ToString();
                                    }
                                }

                                if (dsPID.Tables[0].Rows.Count != 0)
                                {
                                    foreach (DataRow rowPid in dsPID.Tables[0].Rows)
                                    {
                                        th.Hn = rowPid["PID_2"].ToString();
                                        th.PatientName = DeGet(rowPid["PID_5"].ToString())[3].Trim() + DeGet(rowPid["PID_5"].ToString())[1].Trim() + " " + DeGet(rowPid["PID_5"].ToString())[0].Trim();
                                        th.PatientDOB = DateGet(rowPid["PID_7"].ToString());
                                        th.Sex = rowPid["PID_8"].ToString();
                                        th.Language = 0;
                                    }
                                }

                                if (dsPV1.Tables[0].Rows.Count != 0)
                                {
                                    foreach (DataRow rowPv1 in dsPV1.Tables[0].Rows)
                                    {
                                        try
                                        {
                                            th.WardCode = DeGet(rowPv1["PV1_3"].ToString())[0].Trim();
                                            th.WardDesc = DeGet(rowPv1["PV1_3"].ToString())[1].Trim();
                                            th.RoomCode = DeGet(rowPv1["PV1_3"].ToString())[2].Trim();
                                            th.BedCode = DeGet(rowPv1["PV1_3"].ToString())[2].Trim();
                                        }
                                        catch { throw new Exception("PV1 20 :" + row["PV1_3"].ToString() + " ไม่ถูก Format"); }
                                        th.An = rowPv1["PV1_19"].ToString().Trim();
                                        th.Vn = rowPv1["PV1_5"].ToString().Trim();
                                        if (DeGet(rowPv1["PV1_20"].ToString()).Length >= 2)
                                            //th.NoteProcessing = DeGet(rowPv1["PV1_20"].ToString())[1];
                                            th.Comment = DeGet(rowPv1["PV1_20"].ToString())[1];
                                        else { throw new Exception("PV1 20 :" + row["PV1_20"].ToString() + " ไม่ถูก Format"); }
                                    }
                                }

                                if (dsAL1.Tables[0].Rows.Count != 0)
                                {
                                    foreach (DataRow rowAl1 in dsAL1.Tables[0].Rows)
                                    {
                                        if (rowAl1["AL1_3"].ToString() != "")
                                            th.DrugAllergy = rowAl1["AL1_3"].ToString().Trim() + "(อาการ : " + rowAl1["AL1_5"].ToString() + ")";
                                        else if (rowAl1["AL1_5"].ToString() != "")
                                            th.DrugAllergy = "(อาการ : " + rowAl1["AL1_5"].ToString() + ")";
                                        else
                                            th.DrugAllergy = "";
                                    }
                                }
                                else
                                    th.DrugAllergy = "";

                                th.ToMachineNo = 2;
                                th.NoteProcessing = "";
                                //th.DosageDispense = "";
                                th.RoomDesc = "";
                                th.BinLocation = "";
                                th.ItemIdentify = "";
                                th.DrugFormCode = "";
                                th.DrugFormDesc = "";
                                th.DrugBagSplit = 0;
                                th.BarcodeByHIS = "";
                                th.ExcludeIPFill = "";
                                th.OPDAdminBy = "";
                                th.OPDAdminRemark = "";
                                th.OPDAdminLocation = "";
                                th.OPDAdminContinue = 0;
                                th.OrderCreateDate = DateTime.Now;
                                th.OrderAcceptDate = DateTime.Now;
                                th.OPDAdminDateTime = DateTime.Now;

                                switch (OrderControl)
                                {
                                    case "NW": //New Order
                                        var ValidateResult = new HL7DataValidation(th, SetCode).Validate();
                                        if (ValidateResult)
                                        {
                                            OrderReplace = false;
                                            if (th.InsertDataThanesMiddle() == true)
                                            {

                                                rxe.UpdateStatus(SetCode, th.OrderItemCode);
                                                nte.UpdateStatus(SetCode, th.Seq.ToString());
                                                rxr.UpdateStatus(SetCode, th.OrderItemCode);

                                                if (ext.RunningNo != th.RunningNo)
                                                {
                                                    ext.RunningNo = th.RunningNo;
                                                    ext.PRN_Indication = "";                   //Field 70
                                                    ext.PregCat = "";                          //Field 72
                                                    ext.FreeText1 = "";
                                                    ext.EndDate = "";
                                                    ext.EndTime = "";
                                                    var val = new DataValidation(ext, SetCode).Validate();
                                                    if (val)
                                                    {
                                                        bool Ans = ext.InsertDataExtentionsDetail();
                                                        if (!Ans)
                                                            throw new Exception("ไม่สามารถบันทึกข้อมูลของ Extentions : " + SetCode + " ได้");
                                                    }
                                                }

                                                //--Add Master Instruction Config.
                                                AddMasterInstruction(th);
                                                //--Add Master Frequency Config.
                                                AddMasterFrequency(th);
                                                //--Add Master Drug Information Config.
                                                AddMasterDrugInfo(th);

                                                result = true;
                                            }
                                            else
                                            {
                                                result = false;
                                            }
                                        }
                                        break;
                                    case "CA": //Order cancel request

                                        break;
                                    case "RP": //Order replace request
                                        var ValidateResultReplace = new HL7DataValidation(th, SetCode).Validate();
                                        bool flgCheckRP = false;
                                        if (ValidateResultReplace)
                                        { 
                                            if (OrderReplace == false)
                                            {
                                                if (Convert.ToInt16(th.CheckItemsDataPresc(th.PrescriptionNo, th.Hn)) != 0)
                                                {
                                                    th.DeleteDataThanesMiddle();
                                                    prescription.DeleteByPrescripton(th.PrescriptionNo, th.Hn);
                                                    //th.UpdateStatusDataThanesMiddle(th.PrescriptionNo, th.Hn, drugcode, 2);
                                                    //prescription.UpdateStatusByPrescriptionno(th.PrescriptionNo, th.Hn, drugcode, 2);
                                                    OrderReplace = true;
                                                    flgCheckRP = false;
                                                }
                                                else
                                                    flgCheckRP = true;
                                            }                                                                                   
                                               
                                            //else                                            
                                            //    th.DispenseStatus = 3;    
                                            if(flgCheckRP == false)
                                            {
                                                if (th.InsertDataThanesMiddle() == true)
                                                {
                                                    rxe.UpdateStatus(SetCode, th.OrderItemCode);
                                                    nte.UpdateStatus(SetCode, th.Seq.ToString());
                                                    rxr.UpdateStatus(SetCode, th.OrderItemCode);

                                                    if (ext.RunningNo != th.RunningNo)
                                                    {
                                                        ext.RunningNo = th.RunningNo;
                                                        ext.PRN_Indication = "";                   //Field 70
                                                        ext.PregCat = "";                          //Field 72
                                                        ext.FreeText1 = "";
                                                        ext.EndDate = "";
                                                        ext.EndTime = "";
                                                        var val = new DataValidation(ext, SetCode).Validate();
                                                        if (val)
                                                        {
                                                            bool Ans = ext.InsertDataExtentionsDetail();
                                                            if (!Ans)
                                                                throw new Exception("ไม่สามารถบันทึกข้อมูลของ Extentions : " + SetCode + " ได้");
                                                        }
                                                    }

                                                    //--Add Master Instruction Config.
                                                    AddMasterInstruction(th);
                                                    //--Add Master Frequency Config.
                                                    AddMasterFrequency(th);
                                                    //--Add Master Drug Information Config.
                                                    AddMasterDrugInfo(th);

                                                    result = true;
                                                }
                                                else
                                                    result = false;
                                            }
                                          
                                        }
                                        
                                        break;
                                }
                            }


                            if (th.SeqMax == th.Seq)
                            {
                                orc.UpdateStatus(SetCode);
                                pid.UpdateStatus(SetCode);
                                pv1.UpdateStatus(SetCode);
                                al1.UpdateStatus(SetCode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                result = false;
                throw new Exception("Error AddNewMiddleAndExtenstion Function : "+ ex.Message);
            }
            return result;
        }

        private string[] DeGet(string data)
        {
            string[] childParts = { };
            try
            {  
                if (data != null)
                {
                     childParts = data.Split('^');
                }
                else
                {
                    data = "^^^^";
                     childParts = data.Split('^');
                }
            }
            catch
            {
                throw new Exception("DeGet data :" + data); 
            }
            return childParts; 
        }

        private string[] UnGet(string data)
        {
            string[] childParts = { };
            if (data != null)
            {
                return childParts = data.Split('_');
            }
            else
            {
                data = "____";
                return childParts = data.Split('^');
            }
        }

        private string[] SemiGet(string data)
        {
            string[] childParts = { };
            try
            {
                if (data != null)
                {
                    childParts = data.Split(';');
                }
                else
                {
                    data = ";;";
                    childParts = data.Split(';');
                }
            }
            catch
            {
                throw new Exception("DeGet data :" + data);
            }
            return childParts;
        }

        private string[] SpacGet(string data)
        {
            string[] childParts = { };
            try
            {
                if (data != null)
                {
                    childParts = data.Split(' ');
                }
                else
                {
                    data = "  ";
                    childParts = data.Split(' ');
                }
             
            }
            catch
            {
                throw new Exception("DeGet data :" + data);
            }
            return childParts;
        }

        private DateTime DateGet(string data)
        {
            try
            {
                if (data != "")
                    return DateTime.ParseExact(data, "yyyyMMdd", new CultureInfo("en-US"), DateTimeStyles.None);
                else
                    return DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
            }
            catch (Exception e) { throw new Exception(" Values :" + data + " Error :" + e.Message); }
        }

        private string GenFrequencyDesc(string frequencydesc)
        {
            string result = string.Empty;
            try
            {
                frequencydesc = frequencydesc.Replace("   ", " ");
                frequencydesc = frequencydesc.Replace("  ", " ");
                frequencydesc = frequencydesc.Replace("-", " ");
                if (frequencydesc.Contains("อาหาร "))
                {
                    frequencydesc = frequencydesc.Replace("อาหาร ", "อาหาร");
                }
                
                result = frequencydesc;
            }
            catch (Exception e)
            {
                throw new Exception("Gen Frequency desc ไม่สำเร็จ -> " + e.Message);
            }
            return result;
        }

        private string GenFrequencyDescForNoStable(string frequencytime)
        {
            string result = string.Empty;
            try
            {
                frequencytime = frequencytime.Replace("(", "");
                frequencytime = frequencytime.Replace(")", "");
                string[] str = frequencytime.Split(',');

                string per = string.Empty;
                foreach (string s in str)
                {
                    switch (s)
                    {
                        case "06":
                            per = "";
                            break;
                        case "07":
                            per = "ก่อนอาหาร";
                            break;
                        case "08":
                            per = "พร้อมอาหาร";
                            break;
                        case "09":
                            per = "หลังอาหาร";
                            break;
                        case "10":
                            per = "";
                            break;
                        case "11":
                            per = "ก่อนอาหาร";
                            break;
                        case "12":
                            per = "พร้อมอาหาร";
                            break;
                        case "13":
                            per = "หลังอาหาร";
                            break;
                        case "14":
                            per = "";
                            break;
                        case "15":
                            per = "";
                            break;
                        case "16":
                            per = "ก่อนอาหาร";
                            break;
                        case "17":
                            per = "พร้อมอาหาร";
                            break;
                        case "18":
                            per = "หลังอาหาร";
                            break;
                    }
                    switch (s)
                    {
                        case "06":
                            result += "";
                            break;
                        case "07":
                            result += "เช้า ";
                            break;
                        case "08":
                            result += "เช้า ";
                            break;
                        case "09":
                            result += "เช้า ";
                            break;
                        case "10":
                            result += "";
                            break;
                        case "11":
                            result += "กลางวัน ";
                            break;
                        case "12":
                            result += "กลางวัน ";
                            break;
                        case "13":
                            result += "กลางวัน ";
                            break;
                        case "14":
                            result += "";
                            break;
                        case "15":
                            result += "";
                            break;
                        case "16":
                            result += "เย็น ";
                            break;
                        case "17":
                            result += "เย็น ";
                            break;
                        case "18":
                            result += "เย็น ";
                            break;
                        case "19":
                            result += "";
                            break;
                        case "20":
                            result += "ก่อนนอน ";
                            break;
                        case "21":
                            result += "ก่อนนอน ";
                            break;
                    }
                }
                result = per + result.Trim();
            }
            catch (Exception e)
            {
                throw new Exception("Gen Frequency desc ไม่สำเร็จ -> " + e.Message);
            }
            return result;
        }

        private int GenDuration(string frequencydesc)
        {
            int result = 0;
            try
            {
                if (frequencydesc.Contains("เช้า"))
                    result++;
                if (frequencydesc.Contains("กลางวัน"))
                    result++;
                if (frequencydesc.Contains("เย็น"))
                    result++;
                if (frequencydesc.Contains("ก่อนนอน"))
                    result++;
                if (frequencydesc.Contains("ทุก 2"))
                    result = 12;
                if (frequencydesc.Contains("ทุก 4"))
                    result = 6;
                if (frequencydesc.Contains("ทุก 6"))
                    result = 4;
                if (frequencydesc.Contains("ทุก 8"))
                    result = 3;
                if (frequencydesc.Contains("ทุก 12"))
                    result = 2;
                if (frequencydesc.Contains("ทุก 24"))
                    result = 1;
            }
            catch (Exception e)
            {
                throw new Exception("Gen Duration ไม่สำเร็จ -> " + e.Message);
            }
            return result;
        }

        private decimal GenDosageToDecimail(string strdosage)
        {
            decimal result = 0;
            switch (strdosage)
            {
                case "หนึ่งส่วนแปด":
                    result = Convert.ToDecimal(0.125);
                    break;
                case "หนึ่งส่วนสี่":
                    result = Convert.ToDecimal(0.25);
                    break;
                case "ครึ่ง":
                    result = Convert.ToDecimal(0.50);
                    break;
                case "เม็ดครึ่ง":
                    result = Convert.ToDecimal(1.50);
                    break;
                case "สามส่วนสี่":
                    result = Convert.ToDecimal(0.75);
                    break;
                default:
                    result = Convert.ToDecimal(strdosage);
                    break;
            }
            return result;
        }

        private string GenFrequencyTime(string frequencydesc)
        {
            string result = string.Empty;
            string defualtformat = string.Empty;
           
            try
            {
                if(frequencyinfo.GetFrequencyCheck(frequencydesc)== 0)
                {
                    if (frequencydesc != "")
                    {
                        if (frequencydesc.Contains("ก่อนอาหาร"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0700"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1100"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1600"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2000"; }
                        }
                        else if (frequencydesc.Contains("พร้อมอาหาร"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0800"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1200"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1700"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2000"; }
                        }
                        else if (frequencydesc.Contains("หลังอาหาร"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0900"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1300"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1800"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2000"; }
                        }                       
                        else if (frequencydesc.Contains("ทุก"))
                        {
                            if (frequencydesc.Contains("ทุก"))
                            {
                                if (frequencydesc.Contains("24")) { defualtformat += ",2200"; }
                                if (frequencydesc.Contains("12")) { defualtformat += ",1000,2200"; }
                                if (frequencydesc.Contains("8")) { defualtformat += ",0600,1400,2200"; }
                                if (frequencydesc.Contains("ทุก 6")) { defualtformat += ",0600,1200,1800,2359"; }
                                if (frequencydesc.Contains("ทุก 4")) { defualtformat += ",0200,0600,1000,1400,1800,2200"; }
                            }
                            else
                            {
                                defualtformat = ",0800";
                            }
                        }
                        else if (frequencydesc.Contains("เวลา "))
                        {
                            string strfrequency = frequencydesc.Replace("เวลา ", ",");

                            if (strfrequency.Contains(",00.00") || strfrequency.Contains("00.00") || strfrequency.Contains(",00.00")) { defualtformat += ",0000"; }
                            if (strfrequency.Contains(",01.00") || strfrequency.Contains("01.00") || strfrequency.Contains(",1.00")) { defualtformat += ",0100"; }
                            if (strfrequency.Contains(",02.00") || strfrequency.Contains("02.00") || strfrequency.Contains(",2.00")) { defualtformat += ",0200"; }
                            if (strfrequency.Contains(",03.00") || strfrequency.Contains("03.00") || strfrequency.Contains(",3.00")) { defualtformat += ",0300"; }
                            if (strfrequency.Contains(",04.00") || strfrequency.Contains("04.00") || strfrequency.Contains(",4.00")) { defualtformat += ",0400"; }
                            if (strfrequency.Contains(",05.00") || strfrequency.Contains("05.00") || strfrequency.Contains(",5.00")) { defualtformat += ",0500"; }
                            if (strfrequency.Contains(",06.00") || strfrequency.Contains("06.00") || strfrequency.Contains(",6.00")) { defualtformat += ",0600"; }
                            if (strfrequency.Contains(",07.00") || strfrequency.Contains("07.00") || strfrequency.Contains(",7.00")) { defualtformat += ",0700"; }
                            if (strfrequency.Contains(",08.00") || strfrequency.Contains("08.00") || strfrequency.Contains(",8.00")) { defualtformat += ",0800"; }
                            if (strfrequency.Contains(",09.00") || strfrequency.Contains("09.00") || strfrequency.Contains(",9.00")) { defualtformat += ",0900"; }
                            if (strfrequency.Contains(",10.00") || strfrequency.Contains("10.00")) { defualtformat += ",1000"; }
                            if (strfrequency.Contains(",11.00") || strfrequency.Contains("11.00")) { defualtformat += ",1100"; }
                            if (strfrequency.Contains(",12.00") || strfrequency.Contains("12.00")) { defualtformat += ",1200"; }
                            if (strfrequency.Contains(",13.00") || strfrequency.Contains("13.00")) { defualtformat += ",1300"; }
                            if (strfrequency.Contains(",14.00") || strfrequency.Contains("14.00")) { defualtformat += ",1400"; }
                            if (strfrequency.Contains(",15.00") || strfrequency.Contains("15.00")) { defualtformat += ",1500"; }
                            if (strfrequency.Contains(",16.00") || strfrequency.Contains("16.00")) { defualtformat += ",1600"; }
                            if (strfrequency.Contains(",17.00") || strfrequency.Contains("17.00")) { defualtformat += ",1700"; }
                            if (strfrequency.Contains(",18.00") || strfrequency.Contains("18.00")) { defualtformat += ",1800"; }
                            if (strfrequency.Contains(",19.00") || strfrequency.Contains("19.00")) { defualtformat += ",1900"; }
                            if (strfrequency.Contains(",20.00") || strfrequency.Contains("20.00")) { defualtformat += ",2000"; }
                            if (strfrequency.Contains(",21.00") || strfrequency.Contains("21.00")) { defualtformat += ",2100"; }
                            if (strfrequency.Contains(",22.00") || strfrequency.Contains("22.00")) { defualtformat += ",2200"; }
                            if (strfrequency.Contains(",23.00") || strfrequency.Contains("23.00")) { defualtformat += ",2300"; }

                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0800"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1200"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1700"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2000"; }
                        }
                  
                        else if (frequencydesc.Contains("เช้า") || frequencydesc.Contains("กลางวัน") || frequencydesc.Contains("เย็น") || frequencydesc.Contains("ก่อนนอน"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0800"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1200"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1700"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2000"; }
                        }
                        else
                        {
                            defualtformat = ",0800";
                        }
                        result = defualtformat.Remove(0, 1);
                    }
                    else
                    {
                        result = "0800";
                    }
                }
                else
                {
                    DataSet dsfreq = frequencyinfo.GetDisplayDataDetail(frequencydesc);
                    if (dsfreq.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow time in dsfreq.Tables[0].Rows)
                        {
                            result = time["f_frequencytime"].ToString().Trim();
                        }
                    }
                }  
            }
            catch (Exception e)
            {
                throw new Exception("Gen Frequency Time ไม่สำเร็จ -> data : "+ frequencydesc+ " |=> " + e.Message);
            }
            return result;
        }

        private string GenFrequencyNoStable(string strGen)
        {
            string result = string.Empty;
            try
            {
                //(1,2,2,2)(07,12,18,19) =22 char
                int totalChar = strGen.Length;
                string checkChar = strGen.Substring((totalChar - totalChar), totalChar);
                int keyStartCount = checkChar.Split('(').Length - 1;
                int keyStopCount = checkChar.Split(')').Length - 1;

                if (checkChar.Contains("(") == true && checkChar.Contains(")") == true)
                {
                    if (keyStartCount == 2 || keyStopCount == 2)
                    {
                        string[] childPart = { };
                        childPart = checkChar.Split(')');
                        var posStart = childPart[0].IndexOf('(');
                        string cutChar = childPart[0].Substring(0, (posStart + 1));
                        string strdose = childPart[0].Replace(cutChar, "");
                        string strtime = childPart[1].Replace("(", "");

                        int doseCount = strdose.Split(',').Length - 1;
                        int timeCount = strtime.Split(',').Length - 1;

                        if (doseCount == timeCount)
                        {
                            string strfull = string.Empty;
                            string[] childDose = { };
                            string[] childTime = { };
                            childDose = strdose.Split(',');
                            childTime = strtime.Split(',');
                            for (int i = 0; i < childDose.Length; i++)
                            {
                                if (i != (childDose.Length - 1))
                                    strfull += String.Format("{0} Tablet({1}:00), ", childDose[i].Trim(), childTime[i].Trim());
                                else
                                    strfull += String.Format("{0} Tablet({1}:00)", childDose[i].Trim(), childTime[i].Trim());
                            }
                            result = strfull;
                        }
                        else
                            result = "";
                    }
                    else
                        result = "";
                }
                else
                    result = "";
            }
            catch (Exception e)
            {
                throw new Exception("Gen Frequency No Stable ไม่สำเร็จ ->" + e.Message);
            }
            return result;
        }


        private bool AddMasterDrugInfo(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {
                    master_druginfomation dr = new master_druginfomation
                    {
                        OrderItemCode = md.OrderItemCode,
                        OrderItemName = md.OrderItemName,
                        OrderItemNameGeneric = md.OrderItemName,
                        OrderItemNamePrint = md.OrderItemName,
                        OrderUnitCode = md.OrderUnitCode,
                        OrderUnitDesc = md.OrderUnitDesc,
                        OrderItemBarcode = "",
                        ToMachineNo = 0,
                        BinLocation = md.BinLocation,
                        InstructionActiveFrom = 1,
                        InstructionCode = md.InstructionCode,
                        InstructionDesc = md.InstructionDesc,
                        FrequencyActiveFrom = 1,
                        FrequencyCode = md.FrequencyCode,
                        FrequencyDesc = md.FrequencyDesc,
                        FrequencyTime = md.FrequencyTime,
                        DrugLabel = "",
                        OrderItemImage = null
                    };
                    var valid = new DataValidation(dr, md.PrescriptionNo).Validate();
                    if (valid)
                    {
                        if (dr.GetDrugCodeCheck(dr.OrderItemCode) == 0)
                        {
                            bool Answer = dr.InsertDataDrugInformation();
                            if (Answer == true)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                                throw new Exception("ไม่สามารถบันทึกข้อมูลของ Master Drug Information : " + md.PrescriptionNo + " ได้");
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        const string V = "เกิดข้อผิดพลาดการตรวจสอบข้อมูล Master Drug Information : ";
                        throw new Exception(V + md.PrescriptionNo);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(" Insert Data Master Drug Information : " + e.Message);
            }
            return result;
        }

        private bool AddMasterInstruction(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            master_instruction ins = new master_instruction
            {
                InstructionCode = md.InstructionCode,
                InstructionDesc = md.InstructionDesc
            };

            if (ins.GetInstructionCodeCheck(md.InstructionCode) == 0)
            {
                try
                {
                    if (ins.InsertDataInstruction() == true)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("การเพิ่มข้อมูล Master Instruction" + e.Message);
                }
            }
            return result;
        }

        private bool AddMasterFrequency(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
           frequencyinfo = new master_frequencyInfo
            {
                FrequencyCode = md.FrequencyCode,
                FrequencyDesc = md.FrequencyDesc,
                FrequencyTime = md.FrequencyTime
            };

            if (frequencyinfo.GetFrequencyCheck(md.FrequencyDesc) == 0)
            {
                try
                {
                    if (frequencyinfo.InsertDataFrequency() == true)
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("การเพิ่มข้อมูล Master Frequency" + e.Message);
                }
            }
            return result;
        }

        private bool AddMiddles(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {
                    Middle jMiddle = new Middle
                    {
                        f_prescriptionno = md.PrescriptionNo,                           //Field 01
                        f_seq = md.Seq,                                                 //Field 02
                        f_seqmax = md.SeqMax,                                           //Field 03
                        f_runningno = md.RunningNo,                                     //Field 04
                        f_prescriptiondate = md.PrescriptionDate,                       //Field 05
                        f_ordercreatedate = md.OrderCreateDate,                         //Field 06
                        f_ordertargetdate = md.OrderTargetDate,                         //Field 07
                        f_ordertargettime = md.OrderTargetTime,                         //Field 08
                        f_pharmacylocationcode = md.PharmacyLocationCode,               //Field 09
                        f_pharmacylocationdesc = md.PharmacyLocationDesc,               //Field 10
                        f_userorderby = md.UserOrderBy,                                 //Field 11
                        f_useracceptby = md.UserAcceptBy,                               //Field 12
                        f_orderacceptdate = md.OrderAcceptDate,                         //Field 13
                        f_orderacceptfromip = md.OrderAcceptFromIP,                     //Field 14
                        f_dispensestatus = md.DispenseStatus,                           //Field 15
                        f_status = md.Status,                                           //Field 16
                        f_printstatus = md.PrintStatus,                                 //Field 17
                        f_hn = md.Hn,                                                   //Field 18
                        f_an = md.An,                                                   //Field 19
                        f_vn = md.Vn,                                                   //Field 20
                        f_patientname = md.PatientName,                                 //Field 21
                        f_sex = md.Sex,                                                 //Field 22
                        f_patientdob = md.PatientDOB,                                   //Field 23
                        f_wardcode = md.WardCode,                                       //Field 24
                        f_warddesc = md.WardDesc,                                       //Field 25
                        f_roomcode = md.RoomCode,                                       //Field 26
                        f_roomdesc = md.RoomDesc,                                       //Field 27
                        f_bedcode = md.BedCode,                                         //Field 28
                        f_drugallergy = md.DrugAllergy,                                 //Field 29
                        f_doctorcode = md.DoctorCode,                                   //Field 30
                        f_doctorname = md.DoctorName,                                   //Field 31
                        f_tomachineno = md.ToMachineNo,                                 //Field 32
                        f_orderitemcode = md.OrderItemCode,                             //Field 33
                        f_orderitemname = md.OrderItemName,                             //Field 34
                        f_orderqty = md.OrderQty,                                       //Field 35
                        f_orderunitcode = md.OrderUnitCode,                             //Field 36
                        f_orderunitdesc = md.OrderUnitDesc,                             //Field 37
                        f_dosage = md.Dosage,                                           //Field 38
                        f_dosageunit = md.DosageUnit,                                   //Field 39
                        f_binlocation = md.BinLocation,                                 //Field 40
                        f_itemidentify = md.ItemIdentify,                               //Field 41
                        f_itemlotno = md.ItemLotNo,                                     //Field 42
                        f_itemlotexpire = md.ItemLotExpire,                             //Field 43
                        f_instructioncode = md.InstructionCode,                         //Field 44
                        f_instructiondesc = md.InstructionDesc,                         //Field 45
                        f_drugformcode = md.DrugFormCode,                               //Field 46
                        f_drugformdesc = md.DrugFormDesc,                               //Field 47
                        f_highalertdrug = md.HeighAlretDrug,                            //Field 48
                        f_prnstat = md.PRNSTAT,                                         //Field 49
                        f_prioritycode = md.PriorityCode,                               //Field 50
                        f_prioritydesc = md.PriorityDesc,                               //Field 51
                        f_frequencycode = md.FrequencyCode,                             //Field 52
                        f_frequencydesc = md.FrequencyDesc,                             //Field 53
                        f_frequencytime = md.FrequencyTime,                             //Field 54
                        f_dosagedispense = md.DosageDispense,                           //Field 55
                        f_language = md.Language,                                       //Field 56
                        f_durationcode = md.DurationCode,                               //Field 57
                        f_noteprocessing = md.NoteProcessing,                           //Field 58
                        f_barcodebyhis = md.BarcodeByHIS,                               //Field 59
                        f_excludeipfill = md.ExcludeIPFill,                             //Field 60
                        f_lastmodified = md.LastModified,                               //Field 61
                        f_comment = md.Comment,                                         //Field 62
                        f_drugbagsplit = md.DrugBagSplit,                               //Field 63
                        f_opd_adminstatus = md.OPDAdminStatus,                           //Field 64
                        f_opd_admindatetime = md.OPDAdminDateTime,                       //Field 65
                        f_opd_adminby = md.OPDAdminBy,                                   //Field 66
                        f_opd_adminremark = md.OPDAdminRemark,                           //Field 67
                        f_opd_adminlocation = md.OPDAdminLocation,                       //Field 68
                        f_opd_admincontinue = md.OPDAdminContinue,                       //Field 69
                        RowId = ""
                    };
                    JsonMiddle jsonMiddle = new JsonMiddle();
                    string jsonMessage = jsonMiddle.AddMiddle(jMiddle);
                    var message = JsonConvert.DeserializeObject<dynamic>(jsonMessage);
                    logs.Writelogfile(message, " API");
                    result = true;
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                throw new Exception("API Error : " + ErrorMessage.errorMessage);
            }
            return result;
        }
    }
}