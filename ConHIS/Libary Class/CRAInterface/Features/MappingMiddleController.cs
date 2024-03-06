using ConHIS.API.Controllers;
using ConHIS.API.Models;
using ConHIS.Libary_Class.CRAInterface.HL7Structure;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;

namespace ConHIS.Libary_Class.CRAInterface.Features
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

        private readonly MSH msh;
        private readonly AL1 al1;
        private readonly NTE nte;
        private readonly ORC orc;
        private readonly PID pid;
        private readonly PV1 pv1;
        private readonly RXD rxd;
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
            rxd = new RXD();
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

            try
            {
                switch (EventFileType) 
                {
                    case "RDS":
                        switch (ActiveFileType)
                        {
                            // O13 - Pharmacy/treatment dispense
                            case "O13":
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

                //----Create Message Acknowledgment.
                //msaAcknowleds += "MSA|AE|" + fileID + "|" + ex.ToString() + "|||" + "\r\n";
                //hl7_string = mshHeader + msaAcknowleds;
                // hl7_data = Encoding.ASCII.GetBytes(hl7_string);
                //hos.InsertToDrugDispenseHosXP(th.Prescriptionno, "ACK", hl7_data, "N", "AE");

                logs.Writelogfile("ID : {" + SetCode + "} " + ex.ToString(), " Error_MappingMiddleController");
            }
            return result;
        }
        
        private bool AddEditNewMiddleAndExtenstion(string SetCode)
        {
            bool result = false;
            try
            {
                DataSet dsRXD = rxd.SelectRXD(SetCode);
                DataSet dsORC = orc.SelectORC(SetCode);
                DataSet dsPID = pid.SelectPID(SetCode);
                DataSet dsPV1 = pv1.SelectPV1(SetCode);
                DataSet dsAL1 = al1.SelectAL1(SetCode);

                if (dsRXD.Tables[0].Rows.Count != 0)
                {
                    th.SeqMax = dsRXD.Tables[0].Rows.Count;
                    foreach (DataRow row in dsRXD.Tables[0].Rows)
                    {
                        th.PrescriptionNo = row["RXD_7"].ToString();
                        th.Seq = Convert.ToDecimal(row["RXD_1"]);
                        th.OrderItemCode = DeGet(row["RXD_2"].ToString())[0].Trim();
                        th.OrderItemName = DeGet(row["RXD_2"].ToString())[1].Trim();
                        th.LastModified = DateGet(row["RXD_3"].ToString());
                        //th.LastModified = DateTime.Now;

                        if (row["RXD_5"].ToString() != "^")
                        {
                            th.OrderUnitCode = DeGet(row["RXD_5"].ToString())[1].Trim();
                            th.OrderUnitDesc = DeGet(row["RXD_5"].ToString())[1].Trim();

                            //th.OrderUnitDesc = DeGet(row["RXD_12"].ToString())[1].Trim();
                        }
                        else
                        {
                            th.OrderUnitCode = "NULL";
                            th.OrderUnitDesc = "NULL";
                        }
                        th.InstructionCode = row["RXD_8"].ToString();
                        th.InstructionDesc = row["RXD_9"].ToString();
                        try
                        {
                            th.Dosage = Convert.ToDecimal(DeGet(row["RXD_12"].ToString())[0]);
                        }
                        catch
                        {
                            th.Dosage = 0;
                        }

                        //ext.DrugLabelName = DeGet(row["RXD_15"].ToString())[1].Trim();
                        th.ItemLotNo = row["RXD_18"].ToString();
                        th.ItemLotExpire = DateGet(row["RXD_19"].ToString());
                        th.PharmacyLocationCode = DeGet(row["RXD_26"].ToString())[0].Trim();
                        th.PharmacyLocationDesc = DeGet(row["RXD_26"].ToString())[1].Trim();


                        DataSet dsTQ1 = tq1.SelectTQ1(SetCode, th.Seq.ToString());

                        if (dsTQ1.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowTQ1 in dsTQ1.Tables[0].Rows)
                            {
                                th.OrderQty = Convert.ToDecimal(DeGet(rowTQ1["TQ1_2"].ToString())[0]);
                                th.DosageUnit = DeGet(rowTQ1["TQ1_2"].ToString())[1].Trim();
                                // th.OrderUnitDesc = DeGet(rowTQ1["TQ1_2"].ToString())[1].Trim();
                                //th.FrequencyCode = DeGet(rowTQ1["TQ1_3"].ToString())[0].Trim();
                                //th.FrequencyDesc = DeGet(rowTQ1["TQ1_3"].ToString())[1].Trim();
                                th.FrequencyCode = "Gen";
                                th.FrequencyDesc = GenFrequencyDesc("th_" + rowTQ1["TQ1_3"].ToString());
                                th.FrequencyTime = GenFrequencyTime(th.FrequencyDesc);
                                th.OrderTargetDate = DateGet(rowTQ1["TQ1_7"].ToString()).ToString("dd/MM/yyyy");
                                th.OrderTargetTime = DateGet(rowTQ1["TQ1_7"].ToString()).ToString("HH:mm:ss");
                                th.PriorityCode = DeGet(rowTQ1["TQ1_9"].ToString())[0].Trim();
                                th.PriorityDesc = DeGet(rowTQ1["TQ1_9"].ToString())[1].Trim();
                                th.Comment = rowTQ1["TQ1_11"].ToString();
                                th.DurationCode = Convert.ToDecimal(rowTQ1["TQ1_13"]);
                            }

                        }

                        if (dsORC.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowOrc in dsORC.Tables[0].Rows)
                            {
                                OrderControl = rowOrc["ORC_1"].ToString();
                                th.RunningNo = rowOrc["ORC_2"].ToString();
                                OrderStatus = rowOrc["ORC_5"].ToString();
                                th.DispenseStatus = 0;
                                th.Status = Convert.ToDecimal(rowOrc["ORC_6"]);
                                th.PrescriptionDate = rowOrc["ORC_9"].ToString().Substring(0, 8);
                                th.UserOrderBy = DeGet(rowOrc["ORC_10"].ToString())[5].Trim() + DeGet(rowOrc["ORC_10"].ToString())[2].Trim() + " " + DeGet(rowOrc["ORC_10"].ToString())[1].Trim();
                                th.UserAcceptBy = DeGet(rowOrc["ORC_11"].ToString())[5].Trim() + DeGet(rowOrc["ORC_11"].ToString())[2].Trim() + " " + DeGet(rowOrc["ORC_11"].ToString())[1].Trim();
                                th.DoctorCode = DeGet(rowOrc["ORC_12"].ToString())[0].Trim();
                                th.DoctorName = DeGet(rowOrc["ORC_12"].ToString())[5].Trim() + DeGet(rowOrc["ORC_12"].ToString())[2].Trim() + " " + DeGet(rowOrc["ORC_12"].ToString())[1].Trim();
                                th.DoctorName = th.DoctorName.Replace("/", "");
                                th.PharmacyLocationCode = DeGet(rowOrc["ORC_13"].ToString())[0].Trim();
                                th.PharmacyLocationDesc = DeGet(rowOrc["ORC_13"].ToString())[3].Trim();
                                th.OrderAcceptFromIP = DeGet(rowOrc["ORC_18"].ToString())[1].Trim();
                            }
                        }

                        if (dsPID.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowPid in dsPID.Tables[0].Rows)
                            {
                                th.Hn = rowPid["PID_2"].ToString();
                                th.PatientName = DeGet(rowPid["PID_5"].ToString())[4].Trim() + DeGet(rowPid["PID_5"].ToString())[1].Trim() + " " + DeGet(rowPid["PID_5"].ToString())[0].Trim();
                                th.PatientDOB = DateGet(rowPid["PID_7"].ToString());
                                th.Sex = rowPid["PID_8"].ToString();
                                th.Language = Convert.ToDecimal(rowPid["PID_15"]);
                            }
                        }

                        if (dsPV1.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowPv1 in dsPV1.Tables[0].Rows)
                            {
                                th.WardCode = UnGet(rowPv1["PV1_3"].ToString())[0].Trim();
                                th.WardDesc = UnGet(DeGet(rowPv1["PV1_3"].ToString())[0])[1].Trim();
                                th.RoomCode = DeGet(rowPv1["PV1_3"].ToString())[1].Trim();
                                th.BedCode = UnGet(DeGet(rowPv1["PV1_3"].ToString())[2])[0].Trim();
                                th.An = DeGet(rowPv1["PV1_19"].ToString())[0].Trim();
                                th.NoteProcessing = DeGet(rowPv1["PV1_18"].ToString())[1].Trim();
                                th.Vn = DeGet(rowPv1["PV1_19"].ToString())[0].Trim();
                            }
                        }

                        if (dsAL1.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowAl1 in dsAL1.Tables[0].Rows)
                            {
                                if (rowAl1["AL1_3"].ToString() != "")
                                {
                                    th.DrugAllergy = DeGet(rowAl1["AL1_3"].ToString())[1].Trim() + "(อาการ : " + rowAl1["AL1_5"].ToString() + ")";
                                }
                                else if (rowAl1["AL1_5"].ToString() != "")
                                {
                                    th.DrugAllergy = "(อาการ : " + rowAl1["AL1_5"].ToString() + ")";
                                }
                                else
                                {
                                    th.DrugAllergy = "";
                                }
                            }
                        }
                        else
                        {
                            th.DrugAllergy = "";
                        }

                        DataSet dsNTE = nte.SelectNTE(SetCode, th.Seq.ToString());

                        if (dsNTE.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowNte in dsNTE.Tables[0].Rows)
                            {
                                //-----------ถ้ามีข้อมูลอื่นๆนอกเหือใช้ส่วนนี้--------------
                                //th.FrequencyCode = "Gen";
                                ext.DrugLabelName = rowNte["NTE_3"].ToString();

                                // th.DosageDispense = GenFrequencyNoStable(ext.DrugLabelName);
                                // th.FrequencyTime = "";
                                th.DosageDispense = "";
                            }
                        }
                        DataSet dsRXR = rxr.SelectRXR(SetCode, th.OrderItemCode);
                        if (dsRXR.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow rowRxr in dsRXR.Tables[0].Rows)
                            {
                                // th.ToMachineNo = Convert.ToDecimal(DeGet(rowRxr["RXR_3"].ToString())[1]);
                                //th.ToMachineNo = 0;
                                if (th.Dosage != 0)
                                    th.ToMachineNo = druginfomation.GetDrugMiddleToMachineNo(th.OrderItemCode, th.OrderQty, th.Dosage);
                                else
                                    th.ToMachineNo = 0;
                            }
                        }

                        th.RoomDesc = "";
                        th.BinLocation = "";
                        th.ItemIdentify = "";
                        th.DrugFormCode = row["RXD_6"].ToString();
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


                        if (OrderStatus != "CA") { 
                            switch (OrderControl)
                            {
                            case "NW": //New Order
                                var ValidateResult = new HL7DataValidation(th, SetCode).Validate();
                                if (ValidateResult)
                                {
                                    if (th.InsertDataThanesMiddle() == true)
                                    {
                                        rxd.UpdateStatus(SetCode, th.Seq.ToString());
                                        tq1.UpdateStatus(SetCode, th.Seq.ToString());
                                        nte.UpdateStatus(SetCode, th.Seq.ToString());
                                        rxr.UpdateStatus(SetCode, th.OrderItemCode);

                                        //Test API to ConHISManager
                                        //AddMiddles(th);
                                        //////////////////////////

                                        if (ext.RunningNo != th.RunningNo)
                                        {
                                            ext.RunningNo = th.RunningNo;
                                            ext.PRN_Indication = "";                   //Field 70
                                            ext.PregCat = "";                          //Field 72
                                            ext.FreeText1 = "";
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

                                break;
                        }
                    }
                        else if(OrderStatus == "CA") //Order was canceled
                        {
                           if(th.UpdateStatusDataThanesMiddle(th.PrescriptionNo,th.Seq,2) == true)
                            {
                                //Update M_prescription
                                prescription.UpdateStatusByPrescriptionNoAndDrugCode(th.PrescriptionNo,th.OrderItemCode,2,0);

                                rxd.UpdateStatus(SetCode, th.Seq.ToString());
                                tq1.UpdateStatus(SetCode, th.Seq.ToString());
                                nte.UpdateStatus(SetCode, th.Seq.ToString());
                                rxr.UpdateStatus(SetCode, th.OrderItemCode);

                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }    
                    }


                    if (th.SeqMax == th.Seq)
                    {
                        orc.UpdateStatus(SetCode);
                        pid.UpdateStatus(SetCode);
                        pv1.UpdateStatus(SetCode);
                        al1.UpdateStatus(SetCode);

                        //----Create Message Acknowledgment.
                        // hl7_string = mshHeader + msaAcknowleds;
                        //hl7_data = Encoding.ASCII.GetBytes(hl7_string);
                        // hos.InsertToDrugDispenseHosXP(th.Prescriptionno, "ACK", hl7_data, "N", "AA");
                    }
                }
            }
            catch (Exception ex) 
            {
                result = false;
                throw new Exception("Error AddNewMiddleAndExtenstion function: "+ ex.Message);
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

        private DateTime DateGet(string data)
        {
            try
            {
                if (data != "")
                    return DateTime.ParseExact(data, "yyyyMMddHHmmss", new CultureInfo("en-US"), DateTimeStyles.None);
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
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2100"; }
                        }
                        else if (frequencydesc.Contains("หลังอาหาร"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0900"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1300"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1800"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2100"; }
                        }
                        else if (frequencydesc.Contains("พร้อมอาหาร"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0800"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1200"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1700"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2100"; }
                        }
                        else if (frequencydesc.Contains("ทุก"))
                        {
                            if (frequencydesc.Contains("ทุก"))
                            {
                                if (frequencydesc.Contains("48")) { defualtformat += ",0000"; }
                                if (frequencydesc.Contains("24")) { defualtformat += ",2200"; }
                                if (frequencydesc.Contains("12")) { defualtformat += ",1000,2200"; }
                                if (frequencydesc.Contains("8")) { defualtformat += ",0600,1400,2200"; }
                                if (frequencydesc.Contains("6")) { defualtformat += ",0600,1200,1800,2359"; }
                                if (frequencydesc.Contains("4")) { defualtformat += ",0200,0600,1000,1400,1800,2200"; }
                            }
                            else
                            {
                                defualtformat = ",0900";
                            }
                        }
                        else if (frequencydesc.Contains("เวลา"))
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
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2100"; }
                        }
                  
                        else if (frequencydesc.Contains("เช้า") || frequencydesc.Contains("กลางวัน") || frequencydesc.Contains("เย็น") || frequencydesc.Contains("ก่อนนอน"))
                        {
                            if (frequencydesc.Contains("เช้า")) { defualtformat += ",0800"; }
                            if (frequencydesc.Contains("กลางวัน")) { defualtformat += ",1200"; }
                            if (frequencydesc.Contains("เย็น")) { defualtformat += ",1700"; }
                            if (frequencydesc.Contains("ก่อนนอน")) { defualtformat += ",2100"; }
                        }
                        else
                        {
                            defualtformat = ",0900";
                        }
                        result = defualtformat.Remove(0, 1);
                    }
                    else
                    {
                        result = "0900";
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
                string checkChar = strGen.Substring((totalChar - 22), 22);
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
                    throw new Exception("การเพิม่ข้อมูล Master Frequency" + e.Message);
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