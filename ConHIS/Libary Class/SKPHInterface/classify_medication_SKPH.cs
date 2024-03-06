using System;
using System.Data;
using System.Globalization;
using ConHIS.RestFull_TMS;
using ConHIS.Properties;
using System.Threading.Tasks;

namespace ConHIS.Libary_Class
{
    internal class Classify_medication_SKPH
    {
        //Variable And Objects
        private readonly thaneshopmiddle_SKPH md;

        private readonly Thaneshopmiddle_extentions_SKPH ext;

        private readonly System_logfile logs;

        //private readonly int StartOrderStanding = 07; //Settings.Default.VersionConhis 
        private readonly int StartOrderStanding = 16;

        //Constructor
        public Classify_medication_SKPH()
        {
            md = new thaneshopmiddle_SKPH();
            ext = new Thaneshopmiddle_extentions_SKPH();
            logs = new System_logfile();
        }

        //Method
        public void ClassifyOnLoad()
        {
            master_prescription prescription = new master_prescription();   //M_Prescription
            DataSet ds = md.GetDispalyDataClassify();           //tb_thaneshop_middle
            string strPrescription = string.Empty;
            string parentDataPres = string.Empty;
            string parentDataDosage = string.Empty;
            //string barcodeDataPres = string.Empty;
           int StartTimetanding = Settings.Default.StartOrderStanding;
            decimal seqofPres = 0;
            try
            {
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int prnStatus = Convert.ToInt32(row["f_prnstat"]);

                        seqofPres = Convert.ToInt32(row["f_seq"]);

                        strPrescription = row["f_prescriptionno"].ToString();

                        parentDataPres = row["f_frequencytime"].ToString().Replace(" ", "");

                        parentDataDosage = row["f_dosagedispense"].ToString().Replace(", ", ",");

                        string priorityDesc = row["f_prioritydesc"].ToString();

                        //barcodeDataPres = row["f_runningno"].ToString();

                        // ------------------- Data Row----------------------------------------------
                        string[] childPres = { };
                        childPres = parentDataPres.Split(',');
                        // --------------------Start Extract Array Data------------------------------

                        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        // start select form Running No
                        string prn_indication = string.Empty;
                        string drugLabelName = string.Empty;
                        string pregCat = string.Empty;
                        DataSet dsExt =  ext.GetAllExtentionsDetail(row["f_runningno"].ToString());
                        if (Convert.ToInt16(dsExt.Tables[0].Rows.Count) != 0)
                        {
                            prn_indication = dsExt.Tables[0].Rows[0]["prn_indication"].ToString();
                            drugLabelName = dsExt.Tables[0].Rows[0]["drug_label_name"].ToString();
                            pregCat = dsExt.Tables[0].Rows[0]["preg_cat"].ToString();
                        }

                        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        // Extract Data From tb_middleshop
                        prescription.PrescriptionNoHIS = row["f_prescriptionno"].ToString();
                        prescription.PriorityCd = row["f_prioritycode"].ToString();
                        prescription.PatientId = row["f_hn"].ToString();
                        prescription.PatientName = row["f_patientname"].ToString();
                        prescription.PatientAn = row["f_an"].ToString();
                        prescription.BrithDay = Convert.ToDateTime(row["f_patientdob"]);
                        prescription.WardCd = row["f_wardcode"].ToString();
                        prescription.WardName = row["f_warddesc"].ToString();
                        prescription.RoomNo = row["f_roomdesc"].ToString();
                        prescription.BedNo = row["f_bedcode"].ToString();
                        prescription.PrescriptionDate = row["f_prescriptiondate"].ToString();
                        prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                        prescription.BarcodeId = row["f_runningno"].ToString();
                        prescription.DrugCd = row["f_orderitemcode"].ToString();
                        if (pregCat != "")
                            prescription.DrugName = row["f_orderitemname"].ToString() + "[" + pregCat + "]";
                        else
                            prescription.DrugName = row["f_orderitemname"].ToString();
                        prescription.DispensedTotalDose = Convert.ToDecimal(row["f_orderqty"]);
                        prescription.DispensedUnit = row["f_dosageunit"].ToString();
                        prescription.FreqDesc = row["f_frequencycode"].ToString();
                        string[] childFreqDescription = { };
                        ////childFreqDescription = row["f_frequencydesc"].ToString().Split('_');
                        ////prescription.FreePrintItemPres2 =  childFreqDescription[1];
                        prescription.FreePrintItemPres2 = row["f_frequencydesc"].ToString();
                        prescription.FreePrintItemPres3 = prn_indication;                   // Extention Table 
                        prescription.FreePrintItemPres3 = row["f_pharmacylocationcode"].ToString()+"|"+row["f_doctorname"].ToString()+ "|"+ drugLabelName;
                        prescription.FreePrintItemPres4 = row["f_comment"].ToString();
                        prescription.FreePrintItemPres5 = row["f_noteprocessing"].ToString();         // Extention Table
                        prescription.ProcFlg = 0;
                        prescription.DTAFlg = 0;
                        prescription.MachineFlg = Convert.ToDecimal(row["f_tomachineno"]);
                        prescription.PrintFlg = 0;
                        prescription.SMTFlg = 0;
                        prescription.ProcessFlg = 0;
                        prescription.PharmacyIPD = "0";
                        prescription.RowID = row["RowID"].ToString();
                        prescription.FieldUpdate = row["f_prescriptionno"].ToString();
                        prescription.BarcodeByHIS = row["f_barcodebyhis"].ToString();

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        /// โปรแกรมคำนวณการแยกมื้อยา
                        ///
                        if (parentDataPres != "" || parentDataDosage != "")
                        {
                            string[] childFrequencyDec = { };
                            string[] childFreqDose = { };
                            string[] FreqDetailClass = { };
                            //string[] BarcodeIDClass = { };
                           
                            // string freqDescData_2 = string.Empty;
                            //BarcodeIDClass = barcodeDataPres.Split(',');

                            string freqDescData_full = row["f_frequencydesc"].ToString();
                            string[] KeyfreqDesc = freqDescData_full.Split('_');
                            string KeyWord = string.Empty;
                            if (KeyfreqDesc[1].Length >= 5)
                                KeyWord = KeyfreqDesc[1].Substring(0, 5);
                            else
                                KeyWord = KeyfreqDesc[1];

                            int pos = KeyfreqDesc[1].IndexOf("ครั้ง") + 5;
                            int last = KeyfreqDesc[1].Length;
                            bool valContiune;
                            if (last > pos)
                                valContiune = true;
                            else
                                valContiune = false;

                            if (KeyWord.Contains("วันละ"))
                            {
                                string freqCounter = string.Empty;
                                freqDescData_full = KeyfreqDesc[1].Replace(" ", "-");
                                freqDescData_full = freqDescData_full.Replace("วันละ-", "");
                                freqCounter = freqDescData_full.Substring(0, 1);
                                if (valContiune)
                                    freqDescData_full = freqDescData_full.Replace(freqCounter + "-ครั้ง-", "");
                                else
                                    freqDescData_full = "วันละ-" + freqDescData_full;

                                if (freqDescData_full.Contains("อาหาร"))
                                {
                                    string strEnd = string.Empty;
                                    if (freqDescData_full.Contains("(") && freqDescData_full.Contains(")"))
                                    {
                                        int strStart = freqDescData_full.IndexOf("(");
                                        int strStop = freqDescData_full.IndexOf(")");
                                        int strLength = strStop - strStart + 1;
                                        strEnd = freqDescData_full.Substring(strStart, strLength);
                                        strEnd = strEnd.Replace("-", " ");
                                    }
                                    
                                    

                                    if (freqDescData_full.Contains("(ทานหลังอาหารทันที)"))
                                        strEnd = "(ทานหลังอาหารทันที)";
                                    

                                    if (freqCounter != "1")
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-และ-", "-");
                                        freqDescData_full = freqDescData_full.Replace("อาหาร", "|");
                                        freqDescData_full = freqDescData_full.Replace("-", "|");
                                        childFreqDose = freqDescData_full.Split('|');
                                        string fullDoseDesc = string.Empty;
                                        for (int f = 1; f < childFreqDose.Length; f++)
                                        {
                                            if (childFreqDose[f] != "ก่อนนอน")
                                            {
                                                if (strEnd != "")
                                                    fullDoseDesc += childFreqDose[0] + "อาหาร" + childFreqDose[f] + " " + strEnd + "|";
                                                else
                                                    fullDoseDesc += childFreqDose[0] + "อาหาร" + childFreqDose[f] + "|";
                                            }
                                            else
                                                fullDoseDesc += childFreqDose[f] + "|";
                                        }
                                        FreqDetailClass = fullDoseDesc.Split('|');
                                    }
                                    else
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-", " ");
                                        FreqDetailClass = freqDescData_full.Split('|');
                                    }
                                }
                                else if (freqDescData_full.Contains("เวลา"))
                                {
                                    if (freqCounter != "1")
                                    {
                                        freqDescData_full = freqDescData_full.Replace(",", "-");
                                        freqDescData_full = freqDescData_full.Replace("-น.", "");
                                        freqDescData_full = freqDescData_full.Replace("-", "|");
                                        childFreqDose = freqDescData_full.Split('|');
                                        string fullDoseDesc = string.Empty;

                                        for (int f = 1; f < childFreqDose.Length; f++)
                                        {
                                            fullDoseDesc += childFreqDose[0] + " " + childFreqDose[f] + " น.|";
                                        }
                                        FreqDetailClass = fullDoseDesc.Split('|');
                                    }
                                    else
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-", " ");
                                        FreqDetailClass = freqDescData_full.Split('|');
                                    }
                                }
                                else if (freqDescData_full.Contains("ไม่ระบุ"))
                                {
                                    if (freqCounter != "1")
                                    {
                                        string str = "";
                                        for (int g = 0;g < Convert.ToInt32(freqCounter); g++)
                                        {
                                            if((Convert.ToInt32(freqCounter) - g) == 1)
                                                str += freqDescData_full;
                                            else
                                                str += freqDescData_full +"|";
                                        }
                                        FreqDetailClass = str.Split('|');
                                    }
                                    else
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-", " ");
                                        FreqDetailClass = freqDescData_full.Split('|');
                                    }
                                }
                                else
                                {
                                    if (freqCounter != "1")
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-และ-", "-");
                                        freqDescData_full = freqDescData_full.Replace("-", "|");
                                        FreqDetailClass = freqDescData_full.Split('|');
                                    }
                                    else
                                    {
                                        freqDescData_full = freqDescData_full.Replace("-", " ");
                                        FreqDetailClass = freqDescData_full.Split('|');
                                    }
                                }
                            }
                            else
                            {
                                string strFull = string.Empty;
                                for (int f = 0; f < childPres.Length; f++)
                                    strFull += KeyfreqDesc[1] + "|";
                                FreqDetailClass = strFull.Split('|');
                            }

                            //Variable For Frequecy
                            //bool takeStatus = false;
                            bool breakTake = false;
                            int PRNFreqCounter = 0;
                            decimal counterDosage = 0;

                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            /// กรณีแยกมื้อยา เคสการรับประทานยา จำนวนยาในแต่ละมื้อเท่าๆกัน โดยมีข้อมูลระบุในฟิลด์ข้อมูล FrequencyTime โดยเวลาจะเท่ากันกับจำนวนของมื้อยา
                            /// Example. วิธีรับประทาน วันละ 3 ครั้ง หลังอาหารเช้า กลางวัน และ เย็น
                            /// รูปแบบเวลาที่ปรากฏ จะได้ 09:00, 13:00, 18:00
                            if (parentDataPres != "")
                            {
                                int pack = 0;  //Gen SeqNo

                                try
                                {
                                    for (int j = 0; j < childPres.Length; j++)
                                    {
                                        pack++;
                                        prescription.PrescriptionNo = row["f_wardcode"].ToString() + row["f_prescriptionno"].ToString() + row["f_seq"].ToString().PadLeft(2, '0') + pack.ToString().PadLeft(3, '0');
                                        prescription.SeqNo = Convert.ToInt32(row["f_seq"].ToString() + row["f_seqmax"].ToString());
                                        prescription.TakeTime = childPres[j].Replace(":", "");
                                        prescription.DispensedDose = Convert.ToDecimal(row["f_dosage"]);
                                        prescription.FreqCounter = childPres.Length.ToString(); // Select from M_Frequency
                                        prescription.FreqDescDetailCode = childPres[j].Replace(":", "");
                                        prescription.FreqDescDetail = FreqDetailClass[j];     // Select from M_FrequencyTime
                                        prescription.MakeRecTime = DateTime.Now;
                                        prescription.UpDateRecTime = DateTime.Now;
                                        prescription.FreePrintItemPres1 = row["f_instructiondesc"].ToString() + " " + CharacterOfDosage(Convert.ToDecimal(row["f_dosage"])) + " " + row["f_dosageunit"].ToString();
                                        prescription.CreateDateTime = DateTime.Now;

                                        // prescription.BarcodeId = BarcodeIDClass[j];
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        /// ตรวจสอบเงื่อนไขกรณีรายการประเภท Normal [PRN] ยาใช้วันนี้แบบจำแนกการจัดยาให้ตามเวลา ณ ปัจจุบัน กับมื้อยาที่เหลือ
                                        /// Example. จำนวน Dosage กับ Qty ไม่สอดคล้องกับมื้อยา คือ ขาดมื้อ ไม่ครบ จะถูกตีเป็น Stat PRN แล้วคำนวณมื้อใหม่
                                        /// ข้อมูล Qty ที่เข้ามาจะต้องไม่เกิน Dosage และมื้อที่มีอยู่
                                        if (priorityDesc == "Normal" || priorityDesc == "OneDay")
                                        {
                                            if (CompareQtyAndDosage(childPres.Length, prescription.DispensedTotalDose, prescription.DispensedDose) == false)
                                            {
                                                int currentTime = Convert.ToInt32(Convert.ToDateTime(row["f_orderacceptdate"]).ToString("HH"));     // ชั่วโมงที่ทำการกด Accept ใบสั่งยา HH
                                                decimal sumDosage = ((decimal)(childPres.Length * Math.Ceiling(prescription.DispensedDose)));       // Dosage คูณด้วย จำนวนมื้อทั้งหมด
                                                int TakeTimeCompare = Convert.ToInt32(prescription.TakeTime.Substring(0, 2));                       // ชั่วโมงมื้อการรับประทานยา

                                                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                                // กรณี frequency Time Example เป็น Narmol [PRN] เลือกบันทึกมื้อยาที่เกินเวลา ณ ปัจจุบัน
                                                // Example. วิธีรับประทาน วันละ 3 ครั้ง หลังอาหารเช้า กลางวัน และ เย็น
                                                // Frequency Time มาเป็น 09:00, 13:00, 18:00
                                                // เวลา ณ ปัจจุบันเข้ามาช่วงเวลาใดจะเอาช่วงโมงมาคำนวณมื้อที่ไม่เกินเวลาที่สั่งเข้ามา
                                                if (currentTime < TakeTimeCompare || currentTime == TakeTimeCompare)
                                                {
                                                    if (prescription.DispensedTotalDose != counterDosage)
                                                    {
                                                        counterDosage += Math.Ceiling(prescription.DispensedDose);
                                                        if (breakTake == false)
                                                        {
                                                            breakTake = true;
                                                            PRNFreqCounter = (childPres.Length - j);
                                                            prescription.FreqCounter = PRNFreqCounter.ToString();
                                                            prescription.NormalStatus = "For(Dose)";
                                                        }
                                                        SavePrescriptionPerTakeTime(prescription, PRNFreqCounter);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                prescription.NormalStatus = "For(One Day)";
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            }
                                        }
                                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        // เข้าเงื่อนไข การจัดยา และแยกมื้อ กรณีการกินเท่ากัน ตามมื้อและเวลาที่ส่งมา ทั้ง Standing และ Normol
                                        else 
                                             //else if (priorityDesc == "Standing")
                                                {
                                            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            //prescription.NormalStatus = "Standing";
                                            //int TakeTimeCompare = Convert.ToInt32(prescription.TakeTime.Substring(0, 2));
                                            //if (TakeTimeCompare > StartOrderStanding)
                                            //    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                            //else
                                            //    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                            //SavePrescriptionPerTakeTime(prescription, childPres.Length);


                                            //prescription.NormalStatus = "Standing";
                                            prescription.NormalStatus = priorityDesc;

                                            //มื้อเท่าๆกัน
                                            int TakeTimeCompare = StartTimetanding; // Time Start 16.00
                                            //#############################################taketime > 16.00
                                            if (Convert.ToInt32(prescription.TakeTime.Substring(0,2)) > TakeTimeCompare)
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                            else
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                            SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                        }
                                    }
                                }
                                catch(Exception e){ throw new Exception(" เกิดข้อผิดพลาด: "+ parentDataPres + e.Message + " "); } 
                            }

                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            /// กรณีแยกมื้อยา เคสการรับประทานยา จำนวนยาในแต่ละมื้อไม่เท่ากัน โดยไม่มีข้อมูลระบุในฟิลด์ข้อมูล FrequencyTime แต่จะระบุมาในข้อมูลข้อ DosageDispense หรือวิธีการรับประทาน
                            /// ในแต่ละ Dosage โดยมีรูปแบบตามตัวอย่าง แต่ยังมีข้อมูลวิธีการรับประทานอยู่ FrequencyDesc
                            /// Example. วิธีการรับประทาน วันละ 3 ครั้ง เช้า กลางวัน และ เย็น
                            /// รูปแบบเวลาที่ปรากฏ จะได้ 2 Tablet(06:00), 1 Tablet(12:00), 0.5 Tablet(18:00)
                            else if (parentDataDosage != "")
                            {
                                int disagePack = 0;  //Gen SeqNo
                                string[] childDosage = { };
                                string[] childDosageDispense = { };
                                string[] childDosageTime = { };
                                childDosage = parentDataDosage.Split(',');

                                for (int d = 0; d < childDosage.Length; d++)
                                {
                                    childDosageDispense = childDosage[d].Split(' ');
                                    string dosageTime = childDosage[d].Replace(")", "");
                                    childDosageTime = dosageTime.Split('(');

                                    disagePack++;
                                    prescription.PrescriptionNo = row["f_wardcode"].ToString() + row["f_prescriptionno"].ToString() + row["f_seq"].ToString().PadLeft(2, '0') + disagePack.ToString().PadLeft(3, '0');
                                    prescription.SeqNo = Convert.ToInt32(row["f_seq"].ToString() + row["f_seqmax"].ToString());
                                    prescription.TakeTime = childDosageTime[1].Replace(":", "");
                                    prescription.DispensedDose = Convert.ToDecimal(childDosageDispense[0]);
                                    prescription.FreqCounter = childDosage.Length.ToString(); // Select from M_Frequency
                                    prescription.FreqDescDetailCode = childDosageTime[1].Replace(":", "");
                                    if (FreqDetailClass.Length == 1)
                                        prescription.FreqDescDetail = FreqDetailClass[0];     // Select from M_FrequencyTime
                                    else
                                        prescription.FreqDescDetail = FreqDetailClass[d];     // Select from M_FrequencyTime
                                    prescription.MakeRecTime = DateTime.Now;
                                    prescription.UpDateRecTime = DateTime.Now;
                                    prescription.FreePrintItemPres1 = row["f_instructiondesc"].ToString() + " " + CharacterOfDosage(Convert.ToDecimal(childDosageDispense[0])) + " " + row["f_dosageunit"].ToString();
                                    prescription.CreateDateTime = DateTime.Now;
                                    //prescription.BarcodeId = BarcodeIDClass[d];

                                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    /// ตรวจสอบเงื่อนไขกรณีรายการประเภท Narmol [PRN] ยาใช้วันนี้แบบจำแนกการจัดยาให้ตามเวลา ณ ปัจจุบัน กับมื้อยาที่เหลือ
                                    /// Example. จำนวน Dosage กับ Qty ไม่สอดคล้องกับมื้อยา คือ ขาดมื้อ ไม่ครบ จะถูกตีเป็น Stat PRN แล้วคำนวณมื้อใหม่
                                    /// ข้อมูล Qty ที่เข้ามาจะต้องไม่เกิน Dosage และมื้อที่มีอยู่

                                    if (priorityDesc == "Normal" || priorityDesc == "OneDay")
                                    {
                                        if (CompareQtyAndDosage(childDosage.Length, prescription.DispensedTotalDose, prescription.DispensedDose) == false)
                                        {
                                            int currentTime = Convert.ToInt32(Convert.ToDateTime(row["f_orderacceptdate"]).ToString("HH"));     // ชั่วโมงที่ทำการกด Accept ใบสั่งยา HH
                                            decimal sumDosage = ((decimal)(childDosage.Length * Math.Ceiling(prescription.DispensedDose)));     // Dosage คูณด้วย จำนวนมื้อทั้งหมด
                                            int TakeTimeCompare = Convert.ToInt32(prescription.TakeTime.Substring(0, 2));                       // ชั่วโมงมื้อการรับประทานยา

                                            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                            // กรณี frequency Time Example เป็น Narmol [PRN] เลือกบันทึกมื้อยาที่เกินเวลา ณ ปัจจุบัน
                                            // Example. วิธีรับประทาน วันละ 3 ครั้ง หลังอาหารเช้า กลางวัน และ เย็น
                                            // Frequency Time มาเป็น 09:00, 13:00, 18:00
                                            // เวลา ณ ปัจจุบันเข้ามาช่วงเวลาใดจะเอาช่วงโมงมาคำนวณมื้อที่ไม่เกินเวลาที่สั่งเข้ามา
                                            if (currentTime < TakeTimeCompare || currentTime == TakeTimeCompare)
                                            {
                                                if (prescription.DispensedTotalDose != counterDosage)
                                                {
                                                    counterDosage += Math.Ceiling(prescription.DispensedDose);
                                                    if (breakTake == false)
                                                    {
                                                        breakTake = true;
                                                        PRNFreqCounter = (childDosage.Length - d);
                                                        prescription.FreqCounter = PRNFreqCounter.ToString();
                                                        prescription.NormalStatus = "For(Dose)";
                                                    }
                                                    SavePrescriptionPerTakeTime(prescription, PRNFreqCounter);
                                                }
                                            }
                                        }
                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        /// เข้าเงื่อนไข การจัดยา และแยกมื้อ กรณีการกินไม่เท่ากัน Normal
                                        else
                                        {
                                            prescription.NormalStatus = "For(One Day)";
                                            SavePrescriptionPerTakeTime(prescription, childDosage.Length);
                                        }
                                    }
                                    else
                                    //else if (priorityDesc == "Standing")
                                    //มื้อไม่เท่ากัน
                                    {
                                        prescription.NormalStatus = priorityDesc;
                                        int TakeTimeCompare = StartTimetanding;
                                        if (TakeTimeCompare > Convert.ToInt32(row["f_ordertargettime"].ToString().Substring(0, 2)))
                                            prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                        else
                                            prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                        SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                    }
                                }
                            }
                        }
                        md.UpdateDispenseStatusDataThanesMiddle(row["f_prescriptionno"].ToString(), Convert.ToDecimal(row["f_seq"]), 1);
                    }
                }
            }
            catch (Exception e)
            {
                md.UpdateDispenseStatusDataThanesMiddle(strPrescription, seqofPres, 2);
                throw new Exception("[01 M_Prescription] -> Classify-Medication Error : " + strPrescription + "[" + parentDataPres + "][" + parentDataDosage + "] " + e.Message);
            }
        }

        public void SavePrescriptionPerTakeTime(master_prescription prescription, int seqmax)
        {
            var valid = new DataValidation(prescription, "M_Prescription").Validate();
            if (valid)
            {
              //  AddDispenseApi(prescription);
                if (prescription.InsertDataPrescription())
                    logs.Writelogfile("[Key Prescription] :" + prescription.PrescriptionNo + " [SeqMax ]: " + seqmax, " M_Prescription");
                else
                    throw new Exception("ไม่สามารถบันทึกข้อมูลไปยัง M_Prescription : " + prescription.PrescriptionNo + " ได้");
            }
        }

        public bool CompareQtyAndDosage(int row, decimal qty, decimal dosage)
        {
            decimal qtydosage = Math.Ceiling(dosage * row);
            if (qty == qtydosage)
                return true;
            else if (qty > qtydosage)
                return false;
            return false;
        }

        public string CharacterOfDosage(decimal dosage)
        {
            string strCharater = string.Empty;
            string[] strDosage = dosage.ToString().Split('.');
            if (strDosage != null)
            {
                string[] IntDigit = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
                string[] UnitDigit = { "", "เอ็ด", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };
                string[] TenDigit = { "สิบ", "ยี่สิบ", "สามสิบ", "สี่สิบ", "ห้าสิบ", "หกสิบ", "เจ็ดสิบ", "แปดสิบ", "เก้าสิบ" };

                int intDosage = strDosage[0].Length;
                if (strDosage.Length > 1)
                {
                    if (strDosage[1] != "00")
                    {
                        switch (intDosage)
                        {
                            case 1:
                                if (strDosage[0] != "" && strDosage[0] == "0")
                                    strCharater = DecodeDecimalDosage(strDosage[1]);
                                else
                                    strCharater = IntDigit[Convert.ToInt32(strDosage[0])] + "และ" + DecodeDecimalDosage(strDosage[1]);
                                break;

                            case 2:
                                strCharater = TenDigit[Convert.ToInt32(strDosage[0].Substring(0, 1))] + UnitDigit[Convert.ToInt32(strDosage[0].Substring(1, 1))] + "และ" + DecodeDecimalDosage(strDosage[1]);
                                break;
                        }
                    }
                    else
                    {
                        strCharater = Convert.ToInt32(dosage).ToString();
                    }
                }
                else
                {
                    strCharater = Convert.ToInt32(dosage).ToString();
                }
            }

            return strCharater;
        }

        public string DecodeDecimalDosage(string deDosage)
        {
            string strDosage = string.Empty;
            switch (deDosage)
            {
                case "125":
                    strDosage = "หนึ่งส่วนแปด";
                    break;

                case "25":
                    strDosage = "หนึ่งส่วนสี่";
                    break;

                case "5":
                    strDosage = "ครึ่ง";
                    break;

                case "50":
                    strDosage = "ครึ่ง";
                    break;

                case "75":
                    strDosage = "สามส่วนสี่";
                    break;

                default:
                    break;
            }
            return strDosage;
        }

        private void AddDispenseApi(master_prescription pres)
        {
            try
            {
                JsonDispense jDispense = new JsonDispense
                {
                    seq = pres.SeqNo,
                    drugCode = pres.DrugCd,
                    prescriptionNo = pres.PrescriptionNoHIS,
                    userAcceptBy = "รอดำเนินการ",
                    qty = pres.DispensedTotalDose,
                    dosage = pres.DispensedDose,
                    instructionCode = "take",
                    dosageForm = "ไม่ระบุ",
                    unitCode = pres.DispensedUnit.ToUpper(),
                    frequencyCode = pres.FreqDesc,
                    timeCode = "1",
                    strengthUnit = "-",
                    wardCode = pres.WardCd,
                    doctorCode = "-",
                    subStand = pres.FreePrintItemPres5,
                    priorityCode = pres.PriorityCd,
                    continueStartDate = pres.TakeDate.ToString("yyyyMMdd"),
                    continueEndDate = pres.TakeDate.ToString("yyyyMMdd"),
                    orderTargetDate = pres.TakeDate,
                    orderFrequency = 1,
                    dispenseStatus = 0,
                    lotNumber = "",
                    status = 0
                };
                jDispense.AddDispense(jDispense);
            }
            catch (Exception e)
            {
                throw new Exception("Error Add Dispense of Clasify: " + e.Message);
            }
        }

    }
}