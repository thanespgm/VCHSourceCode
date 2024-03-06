using System;
using System.Data;
using System.Globalization;
using ConHIS.RestFull_TMS;

namespace ConHIS.Libary_Class
{
    internal class Classify_medication_ATPM
    {
        //Variable And Objects
        private readonly Thaneshopmiddle_ATPM md;

        private readonly Thaneshopmiddle_extentions_ATPM ext;

        private readonly System_logfile logs;

        private readonly int StartOrderStanding = 07;

        //Constructor
        public Classify_medication_ATPM()
        {
            md = new Thaneshopmiddle_ATPM();
            ext = new Thaneshopmiddle_extentions_ATPM();
            logs = new System_logfile();
        }

        //Method
        //##### แยกมื้อ
        public void ClassifyOnLoad()
        {
            master_prescription prescription = new master_prescription();   //M_Prescription
            DataSet ds = md.GetDispalyDataClassify();           //tb_thaneshop_middle
            string strPrescription = string.Empty;
            string parentDataPres = string.Empty;
            string parentDataDosage = string.Empty;
            decimal countFrequency = 0;
            decimal countQtyDose = 0;
            decimal loopCount = 0;
            //string barcodeDataPres = string.Empty;

            decimal seqofPres = 0;
            try
            {
                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int prnStatus = Convert.ToInt32(row["f_prnstat"]);

                        seqofPres = Convert.ToInt32(row["f_seq"]);

                        strPrescription = row["f_prescriptionno"].ToString() ;
                        parentDataPres = row["f_frequencytime"].ToString().Replace(" ", "");
                        

                        parentDataDosage = row["f_dosagedispense"].ToString().Replace(", ", ",");

                        string priorityDesc = row["f_prioritydesc"].ToString();

                        //barcodeDataPres = row["f_runningno"].ToString();

                        // ------------------- Data Row----------------------------------------------
                        //Dim SearchWithinThis As String = "ABCDEFGHIJKLMNOP"
                        //Dim SearchForThis As String = "DEF"
                        //Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(SearchForThis)


                        string[] childPres = { };
                        string[] dosagedispenseCount = { };

                        int dosagedispenseTime = parentDataDosage.IndexOf(":");
                        dosagedispenseCount = parentDataDosage.Split(',');
                        if (parentDataPres == "")
                        {

                        }
                        else
                        {
                            childPres = parentDataPres.Split(',');
                        }
                        
                        string prn_indication = string.Empty;
                        string drugLabelName = string.Empty;
                        string pregCat = string.Empty;
                        string extStartDate = string.Empty;
                        string extStartTime = string.Empty;
                        DataSet dsExt =  ext.GetAllExtentionsDetail(row["f_runningno"].ToString());
                        if (Convert.ToInt16(dsExt.Tables[0].Rows.Count) != 0)
                        {
                            prn_indication = dsExt.Tables[0].Rows[0]["prn_indication"].ToString();
                            drugLabelName = dsExt.Tables[0].Rows[0]["drug_label_name"].ToString();
                            pregCat = dsExt.Tables[0].Rows[0]["preg_cat"].ToString();
                            extStartDate = dsExt.Tables[0].Rows[0]["startdate"].ToString();
                            if (extStartDate == row["f_ordertargetdate"].ToString())
                            {
                                extStartTime = dsExt.Tables[0].Rows[0]["starttime"].ToString().Replace(":", "");
                            }
                            else
                            {
                                extStartTime = row["f_ordertargettime"].ToString().Replace(":", "");
                            }
                            //extStartTime = dsExt.Tables[0].Rows[0]["starttime"].ToString().Replace(":","");
                            
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
                        childFreqDescription = row["f_frequencydesc"].ToString().Split('_');
                        prescription.FreePrintItemPres2 = childFreqDescription[1];
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

                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        /// โปรแกรมคำนวณการแยกมื้อยา
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                                        for (int g = 0; g < Convert.ToInt32(freqCounter); g++)
                                        {
                                            if ((Convert.ToInt32(freqCounter) - g) == 1)
                                                str += freqDescData_full;
                                            else
                                                str += freqDescData_full + "|";
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

                            decimal loopCountNegative = 0;
                            decimal loopQtydose = 0;
                            //##Compare frequencyTime vs qty/dose
                            //dosagedispenseTime = parentDataDosage.IndexOf(",");
                            //dosagedispenseCount = parentDataDosage.Split(',');

                            if (parentDataPres != "") 
                            {
                                countQtyDose = Convert.ToDecimal(row["f_orderqty"]) / Convert.ToDecimal(row["f_dosage"]);
                                loopQtydose = countQtyDose;
                            }
                            else
                            {
                                countQtyDose = dosagedispenseCount.Length;
                                loopQtydose = countQtyDose;
                            }


                            if (dosagedispenseTime > 0 )
                            {
                                // Dosagedispense 

                                countFrequency = Convert.ToDecimal(dosagedispenseCount.Length);
                            }
                            else
                            {
                                //frequencyTime
                                countFrequency = Convert.ToDecimal(childPres.Length);
                            }

                            //countFrequency = Convert.ToDecimal(childPres.Length);
                            loopCount = Convert.ToInt16(countQtyDose - countFrequency);
                            loopCountNegative = loopCount;
                            if ((countQtyDose - countFrequency) != 0)
                            {
                                loopCount = countQtyDose - countFrequency;
                            }
                            ////else
                            ////    loopCount = 0;
                            if (priorityDesc == "Standing")
                            {
                                prescription.NormalStatus = "Standing";
                            }
                            else
                            {
                                prescription.NormalStatus = "Normal";
                            }

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
                                        prescription.FreqCounter = childPres.Length.ToString(); 
                                        prescription.FreqDescDetailCode = childPres[j].Replace(":", "");
                                        ////if (row["f_frequencydesc"].ToString().Contains("ทุก"))
                                        ////{
                                        ////    if (prn_indication != "")
                                        ////    {
                                        ////        prescription.FreqDescDetail = FreqDetailClass[j] + " เมื่อมีอาการ "+ prn_indication;
                                        ////    }
                                        ////    else
                                        ////    { 
                                        ////        prescription.FreqDescDetail = FreqDetailClass[j]; 
                                        ////    }


                                        ////}
                                        ////else
                                        ////{
                                        ////    if (prn_indication != "")
                                        ////    {
                                        ////        prescription.FreqDescDetail = FreqDetailClass[j] + " เมื่อมีอาการ " + prn_indication;
                                        ////    }
                                        ////    else
                                        ////    {
                                        ////        prescription.FreqDescDetail = FreqDetailClass[j] ;
                                        ////    }

                                        ////}
                                        prescription.FreqDescDetail = FreqDetailClass[j];
                                        if (prn_indication != "")
                                        {
                                            prescription.FreqDescDetail = prescription.FreqDescDetail + " เมื่อมีอาการ " + prn_indication;
                                        }
                                        prescription.MakeRecTime = DateTime.Now;
                                        prescription.UpDateRecTime = DateTime.Now;
                                        prescription.FreePrintItemPres1 = row["f_instructiondesc"].ToString() + " " + CharacterOfDosage(Convert.ToDecimal(row["f_dosage"])) + " " + row["f_dosageunit"].ToString();
                                        prescription.CreateDateTime = DateTime.Now;

                                        //##Insert Data To M_prescription
                                        ////string testDate = row["f_ordertargetdate"].ToString();
                                        ////DateTime todayNow2 = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy").Substring(0, 10));

                                        DateTime targetDate = Convert.ToDateTime(row["f_ordertargetdate"].ToString());
                                        DateTime todayNow = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy").Substring(0, 10));
                                        if (targetDate != todayNow)
                                        {
                                            targetDate = todayNow;
                                        }

                                        //## taketime มากกว่าหรือเท่ากับ startTime 
                                        if (targetDate >= todayNow && (Convert.ToInt16(prescription.TakeTime) >= Convert.ToInt16(extStartTime)))
                                        {

                                            if (loopCount > 0) // Qty/dose มากกว่า FrequencyTime ที่ส่งมา จัดเพิ่มโดยมื้อที่เพิ่มจะเป็นวันถัดไป
                                            {
                                                if (loopCountNegative > 0)
                                                {
                                                    //### จัดมื้อปกติ
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    //### จัดเพิ่มอีกมื้อของวันถัดไป
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCount -= 1;
                                                }
                                            }
                                            else if (loopCount < 0) // Qty/dose น้อยกว่า FrequencyTime ที่ส่งมา จัดมื้อแรกๆตัดมื้อหลัง
                                            {
                                                 if (loopQtydose == 0) //## เช็คว่าต้องจัดกี่มื้อโดยอิงจาก Qty/dose 
                                                {

                                                }
                                                else
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCountNegative += 1;
                                                    loopQtydose -= 1;
                                                }
                                            }
                                            else // Qty/dose เท่ากับ FrequencyTime ที่ส่งมา จัดตามปกติ
                                            {
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            }
                                        }
                                        //## taketime น้อยกว่า startTime ต้องจัดเป็นวันพรุ่งนี้ (addday+1)
                                        else
                                        {
                                            if (loopCountNegative < 0)
                                            {
                                                if (loopQtydose == 0) //## เช็คว่าต้องจัดกี่มื้อโดยอิงจาก Qty/dose 
                                                {

                                                }
                                                else
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopQtydose -= 1;
                                                }
                                            }
                                            else if (loopCountNegative > 0)
                                            {
                                                //
                                                if (loopCount > 0)
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCountNegative += 1;
                                                    loopQtydose -= 1;
                                                }
                                            }
                                            else if (loopCountNegative == 0)
                                            {
                                                // รายการยาที่เวลาเริ่มต้นก่อน 14.01 มื้อกับ dose คำนวนแล้วปกติ
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            }
                                            else
                                            {
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            }

                                        }

                                    }



                                }
                                catch (Exception e) { throw new Exception(" เกิดข้อผิดพลาด: " + parentDataPres + e.Message + " "); }
                            }

                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            /// กรณีแยกมื้อยา เคสการรับประทานยา จำนวนยาในแต่ละมื้อไม่เท่ากัน จะระบุมาในข้อมูลข้อ DosageDispense หรือวิธีการรับประทาน
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

                                    //###ใส่คำอธิบายมื้อเช่น หลังอาหารเช้า, หลังอาหารกลางวัน
                                    // childDosage.Length : Dosagedispense count
                                    if (FreqDetailClass.Length == 1)
                                        prescription.FreqDescDetail = freqDescData_full; //row["f_frequencydesc"].ToString(); 
                                    else if (row["f_dosagedispense"].ToString() != "")
                                    {

                                        if (row["f_frequencydesc"].ToString().Substring(0, 1) == "w" || row["f_frequencydesc"].ToString().Substring(0, 1) == "q")

                                        {
                                            prescription.FreqDescDetail = FreqDetailClass[0];
                                            //## ถ้าเป็นมื้อที่เป็นต่อสัปดาห์ ให้บวก taketime +10 เช่น 0900 จะเท่ากับ 0910 เพื่อใช้แยกซอง
                                            prescription.TakeTime = prescription.TakeTime.ToString().Substring(0, 2) + d + "0";
                                            prescription.FreqDescDetailCode = prescription.TakeTime;
                                        }
                                        else
                                        {
                                            prescription.FreqDescDetail = FreqDetailClass[d];
                                        }

                                    }
                                    else

                                        prescription.FreqDescDetail = FreqDetailClass[d];

                                    if (prn_indication != "")
                                    {
                                        prescription.FreqDescDetail = prescription.FreqDescDetail + " เมื่อมีอาการ " + prn_indication;
                                    }
                                    prescription.MakeRecTime = DateTime.Now;
                                    prescription.UpDateRecTime = DateTime.Now;
                                    prescription.FreePrintItemPres1 = row["f_instructiondesc"].ToString() + " " + CharacterOfDosage(Convert.ToDecimal(childDosageDispense[0])) + " " + row["f_dosageunit"].ToString();
                                    prescription.CreateDateTime = DateTime.Now;

                                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    /// ตรวจสอบเงื่อนไขกรณีรายการประเภท Narmol [PRN] ยาใช้วันนี้แบบจำแนกการจัดยาให้ตามเวลา ณ ปัจจุบัน กับมื้อยาที่เหลือ
                                    /// Example. จำนวน Dosage กับ Qty ไม่สอดคล้องกับมื้อยา คือ ขาดมื้อ ไม่ครบ จะถูกตีเป็น Stat PRN แล้วคำนวณมื้อใหม่
                                    /// ข้อมูล Qty ที่เข้ามาจะต้องไม่เกิน Dosage และมื้อที่มีอยู่
                                    if (priorityDesc != "")
                                    {
                                        //##Insert Data To M_prescription
                                        DateTime targetDate = Convert.ToDateTime(row["f_ordertargetdate"].ToString());
                                        DateTime todayNow = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy").Substring(0, 10));

                                        //## เช็คว่าวันที่ใช้ยามากกว่า targetdate หรือไม่ และ เช็คเวลาที่ส่งมามากกว่า targettime หรือไม่
                                        if (targetDate >= todayNow && (Convert.ToInt16(prescription.TakeTime) >= Convert.ToInt16(extStartTime)))
                                        {

                                            if (loopCount > 0) // Qty/dose มากกว่า FrequencyTime ที่ส่งมา จัดเพิ่มโดยมื้อที่เพิ่มจะเป็นวันถัดไป
                                            {
                                                if (loopCountNegative > 0)
                                                {
                                                    //### จัดมื้อปกติ
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    //### จัดเพิ่มอีกมื้อของวันถัดไป
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCount -= 1;
                                                }
                                            }
                                            else if (loopCount < 0) // Qty/dose น้อยกว่า FrequencyTime ที่ส่งมา จัดมื้อแรกๆตัดมื้อหลัง
                                            {
                                                if (loopCountNegative != 0)
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCountNegative += 1;
                                                }
                                            }
                                            else // Qty/dose เท่ากับ FrequencyTime ที่ส่งมา จัดตามปกติ
                                            {
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            }
                                        }
                                        //## taketime น้อยกว่า targettime
                                        else 
                                        {
                                            //## ถ้าเป็นยา Standing ให้บวกวันเพิ่มไป 1 แล้วแยกมื้อปกติ
                                            ////prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                            ////SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                            ////loopCountNegative += 1;
                                            ///
                                            if (loopCountNegative < 0)
                                            {
                                                if (loopQtydose == 0) //## เช็คว่าต้องจัดกี่มื้อโดยอิงจาก Qty/dose 
                                                {

                                                }
                                                else
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCountNegative += 1;
                                                    loopQtydose -= 1;
                                                }
                                            }
                                            else if (loopCountNegative > 0)
                                            {
                                                if (loopCount > 0)
                                                {
                                                    prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                    SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                    loopCountNegative += 1;
                                                    loopQtydose -= 1;
                                                }
                                            }
                                            else
                                            {
                                                prescription.TakeDate = DateTime.ParseExact(row["f_ordertargetdate"].ToString(), "dd/MM/yyyy", new CultureInfo("en-US")).AddDays(1);
                                                SavePrescriptionPerTakeTime(prescription, childPres.Length);
                                                //loopCountNegative += 1;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        //
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
                throw new Exception("[01 M_Prescription] -> Classify_medication_ATPM : " + strPrescription + "[" + parentDataPres + "][" + parentDataDosage + "] " + e.Message);
            }
        }

        public void SavePrescriptionPerTakeTime(master_prescription prescription, int seqmax)
        {
            var valid = new DataValidation(prescription, "M_Prescription").Validate();
            if (valid)
            {
              //  AddDispenseApi(prescription);
              // ### Insert Data to m_prescription
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

        ////private void AddDispenseApi(master_prescription pres)
        ////{
        ////    try
        ////    {
        ////        JsonDispense jDispense = new JsonDispense
        ////        {
        ////            seq = pres.SeqNo,
        ////            drugCode = pres.DrugCd,
        ////            prescriptionNo = pres.PrescriptionNoHIS,
        ////            userAcceptBy = "รอดำเนินการ",
        ////            qty = pres.DispensedTotalDose,
        ////            dosage = pres.DispensedDose,
        ////            instructionCode = "take",
        ////            dosageForm = "ไม่ระบุ",
        ////            unitCode = pres.DispensedUnit.ToUpper(),
        ////            frequencyCode = pres.FreqDesc,
        ////            timeCode = "1",
        ////            strengthUnit = "-",
        ////            wardCode = pres.WardCd,
        ////            doctorCode = "-",
        ////            subStand = pres.FreePrintItemPres5,
        ////            priorityCode = pres.PriorityCd,
        ////            continueStartDate = pres.TakeDate.ToString("yyyyMMdd"),
        ////            continueEndDate = pres.TakeDate.ToString("yyyyMMdd"),
        ////            orderTargetDate = pres.TakeDate,
        ////            orderFrequency = 1,
        ////            dispenseStatus = 0,
        ////            lotNumber = "",
        ////            status = 0
        ////        };
        ////        jDispense.AddDispense(jDispense);
        ////    }
        ////    catch (Exception e)
        ////    {
        ////        throw new Exception("Error Add Dispense of Clasify: " + e.Message);
        ////    }
        ////}

    }
}