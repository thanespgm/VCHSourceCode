using ConHIS.RestFull_TMS.ConHISManager;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace ConHIS.Libary_Class
{
    class Vichaiyut_generate_data_interface
    {
        //Variable And Objects
        private readonly Thaneshopmiddle_VICHAIYUT md = new Thaneshopmiddle_VICHAIYUT();
        private readonly Thaneshopmiddle_extentions_Vichaiyut ext = new Thaneshopmiddle_extentions_Vichaiyut();

        //host His Vichaiyut Hospital
        private readonly Thaneshopmiddle_VICHAIYUT hos = new Thaneshopmiddle_VICHAIYUT();


        private readonly System_logfile log = new System_logfile();

        //int itemsComprae = 0;

        private DataSet ipd = null;

        private string datafilename;
        private string event_code;
        private string event_message;

        //Constructor And Abstract Class
        public Vichaiyut_generate_data_interface()
        {
           
        }

        //Fuction for Interface Data opd_pres_machine To Thanes Middle Table
        public bool InterfaceHosVichaiyut(bool enable, string prescriptionNo)
        {
            bool result = false;
            try
            {
                if (enable == true)
                {
                    datafilename = prescriptionNo;

                    event_code = "F00IN";
                    event_message = "[" + md.PrescriptionNo + "] : " + "GetDataIPD Prescription :" + prescriptionNo.ToString();
                    this.WritelogSystem(true);

                    ipd = hos.GetDataMiddleFormHISVichaiyut(prescriptionNo, 2);

                    if (ipd.Tables[0].Rows.Count != 0)
                    {
                        int itemsAll = ipd.Tables[0].Rows.Count;

                        foreach (DataRow row in ipd.Tables[0].Rows)
                        {
                            md.PrescriptionNo = row["f_prescriptionno"].ToString();     //Field 01
                            try
                            {
                                md.Seq = Convert.ToDecimal(row["f_seq"]);               //Field 02
                            }
                            catch (Exception e) { throw new Exception("Seq => Values :" + row["f_seq"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.SeqMax = Convert.ToDecimal(row["f_seqmax"]);          //Field 03
                            }
                            catch (Exception e) { throw new Exception("Seq Max => Values :" + row["f_seqmax"] + " Error :" + e.Message); }
                            md.RunningNo = row["f_referenceCode"].ToString();      //Field 04

                            DateTime PresDate = DateTime.ParseExact(row["f_prescriptiondate"].ToString(), "yyyyMMdd", new CultureInfo("en-US"), DateTimeStyles.None);
                            md.PrescriptionDate = PresDate.ToString("yyyyMMdd");                    //Field 05

                            try
                            {
                                string OrderCreateDateTime = row["f_ordercreatedate"].ToString() + row["f_ordercreatetime"].ToString();
                                md.OrderCreateDate = DateTime.ParseExact(OrderCreateDateTime, "yyyyMMddHH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);   //Field 06
                            }
                            catch (Exception e) { throw new Exception("OrderCreateDate => Values :" + row["f_ordercreatedate"].ToString() + " Error :" + e.Message); }
                            //md.OrderTargetDate = row["f_ordertargetdate"].ToString().Substring(6,2)+ "/"+ row["f_ordertargetdate"].ToString().Substring(4, 2) + "/" + row["f_ordertargetdate"].ToString().Substring(0, 4);                    //Field 07
                            //DateTime.ParseExact(DateTime.Now.ToString(), "dd/MM/yyyy", new CultureInfo("en-US"));
                            md.OrderTargetDate = DateTime.Now.ToString("dd/MM/yyyy");                    //Field 07
                            md.OrderTargetTime = row["f_ordertargettime"].ToString();                    //Field 08
                            md.PharmacyLocationCode = row["f_pharmacylocationcode"].ToString();          //Field 09
                            md.PharmacyLocationDesc = row["f_pharmacylocationdesc"].ToString();          //Field 10
                            md.UserOrderBy = row["f_ordercreatedate"].ToString();                        //Field 11
                            md.UserAcceptBy = row["f_ordercreatedate"].ToString();                       //Field 12
                            try
                            {
                                string OrderAcceptDateTime = row["f_orderacceptdate"].ToString() + row["f_orderaccepttime"].ToString();
                                md.OrderAcceptDate = DateTime.ParseExact(OrderAcceptDateTime, "yyyyMMddHH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None);  //Field 13
                            }
                            catch (Exception e) { throw new Exception("OrderAcceptDate => Values :" + row["f_orderacceptdate"].ToString() + " Error :" + e.Message); }
                            md.OrderAcceptFromIP = row["f_orderacceptfromip"].ToString();                //Field 14
                            try
                            {
                                md.DispenseStatus = Convert.ToDecimal(row["f_dispensestatus"]);     //Field 15
                            }
                            catch (Exception e) { throw new Exception("DispenseStatus => Values :" + row["f_dispensestatus"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.Status = Convert.ToDecimal(row["f_status"]);             //Field 16
                            }
                            catch (Exception e) { throw new Exception("Status => Values :" + row["f_status"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.PrintStatus = 0;
                                // md.PrintStatus = Convert.ToDecimal(childParts[16]);        //Field 17
                            }
                            catch (Exception e) { throw new Exception("PrintStatus => Values :" + md.PrintStatus + " Error :" + e.Message); }
                            md.Hn = row["f_hn"].ToString();                                 //Field 18
                            md.An = row["f_en"].ToString();                                 //Field 19
                            md.Vn = row["f_en"].ToString();                                 //Field 20
                            md.PatientName = row["f_patientname"].ToString();               //Field 21
                            if (row["f_sex"].ToString() == "1")
                                md.Sex = "F";                               //Field 22
                            else if (row["f_sex"].ToString() == "0")
                                md.Sex = "M";                               //Field 22
                            else
                                md.Sex = "";                                //Field 22

                            try
                            {
                                md.PatientDOB = DateTime.ParseExact(row["f_patientdob"].ToString(), "yyyyMMdd", new CultureInfo("en-US"), DateTimeStyles.None);       //Field 23
                            }
                            catch (Exception e) { throw new Exception("PatientDOB => Values :" + row["f_patientdob"].ToString() + " Error :" + e.Message); }
                            md.WardCode = row["f_wardcode"].ToString();                            //Field 24
                            md.WardDesc = row["f_warddesc"].ToString();                            //Field 25
                            md.RoomCode = row["f_roomcode"].ToString();                            //Field 26
                            md.RoomDesc = row["f_roomdesc"].ToString();                            //Field 27
                            md.BedCode = row["f_bedcode"].ToString();                              //Field 28
                            md.DrugAllergy = "";                                                   //Field 29
                            md.DoctorCode = row["f_doctorcode"].ToString();                        //Field 30
                            md.DoctorName = row["f_doctorname"].ToString();                        //Field 31
                            try
                            {
                                md.ToMachineNo = Convert.ToDecimal(row["f_tomachineno"]);        //Field 32
                            }
                            catch (Exception e) { throw new Exception("ToMachineNo => Values :" + row["f_tomachineno"].ToString() + " Error :" + e.Message); }
                            md.OrderItemCode = row["f_orderitemcode"].ToString();                      //Field 33
                            md.OrderItemName = row["f_orderitemname"].ToString();                      //Field 34
                            try
                            {
                                md.OrderQty = Convert.ToDecimal(row["f_orderqty"]);           //Field 35
                            }
                            catch (Exception e) { throw new Exception("OrderQty => Values :" + row["f_orderqty"].ToString() + " Error :" + e.Message); }
                            md.OrderUnitCode = row["f_orderunitcode"].ToString();                      //Field 36
                            md.OrderUnitDesc = row["f_orderunitdesc"].ToString();                      //Field 37
                            try
                            {
                                md.Dosage = Convert.ToDecimal(row["f_dosage"]);             //Field 38
                            }
                            catch (Exception e) { throw new Exception("Dosage => Values :" + row["f_dosage"].ToString() + " Error :" + e.Message); }
                            md.DosageUnit = row["f_dosageunit"].ToString();                         //Field 39
                            md.BinLocation = "";                                                    //Field 40
                            md.ItemIdentify = row["f_itemidentify"].ToString();                     //Field 41
                            md.ItemLotNo = row["f_itemlotcode"].ToString();                         //Field 42
                            try
                            {
                                if (row["f_itemlotexpire"].ToString() != "")
                                    md.ItemLotExpire = DateTime.ParseExact(row["f_itemlotexpire"].ToString(), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);     //Field 43
                                else
                                    md.ItemLotExpire = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                            }
                            catch (Exception e) { throw new Exception("ItemLotExpire => Values :" + row["f_itemlotexpire"].ToString() + " Error :" + e.Message); }
                            md.InstructionCode = row["f_instructioncode"].ToString();                    //Field 44
                            md.InstructionDesc = row["f_instructiondesc"].ToString();                    //Field 45
                            md.DrugFormCode = "";                                                        //Field 46
                            md.DrugFormDesc = "";                                                        //Field 47
                            try
                            {
                                //md.HeighAlretDrug = 0;
                                md.HeighAlretDrug = Convert.ToDecimal(row["f_heighAlertDrug"]);     //Field 48
                            }
                            catch (Exception e) { throw new Exception("HeighAlretDrug => Values :" + row["f_heighAlertDrug"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                //md.PRNSTAT = 0;
                                md.PRNSTAT = Convert.ToDecimal(row["f_heighAlertDrug"]);            //Field 49
                            }
                            catch (Exception e) { throw new Exception("PRNSTAT => Values :" + row["f_heighAlertDrug"] + " Error :" + e.Message); }
                            if (row["f_prioritycode"].ToString().Length == 1)
                            {
                                md.PriorityCode = row["f_prioritycode"].ToString();                  //Field 50
                            }
                            else
                            {
                                md.PriorityCode = row["f_prioritycode"].ToString().Substring(0, 2);          //Field 50
                            }
                            md.PriorityDesc = row["f_prioritydesc"].ToString();                      //Field 51
                            md.FrequencyCode = row["f_frequencycode"].ToString();                    //Field 52
                                                                                                     // md.FrequencyDesc = row["f_frequencydesc"].ToString();                    //Field 53
                                                                                                     // md.FrequencyTime = row["f_frequencyTime"].ToString();                    //Field 54
                                                                                                     //f_PRN
                            GenFrequencyDescMessage(md, md.FrequencyCode, row["f_frequencydesc"].ToString(), row["f_frequencyTime"].ToString(), row["f_dosagedispense"].ToString(), Convert.ToInt16(row["f_PRN"]));

                           md.DosageDispense = row["f_dosagedispense"].ToString();                  //Field 55


                            try
                            {
                                md.Language = Convert.ToDecimal(row["f_language"]);           //Field 56
                            }
                            catch (Exception e) { throw new Exception("Language => Values :" + row["f_language"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.DurationCode = Convert.ToDecimal(row["f_durationcode"]);       //Field 57
                            }
                            catch (Exception e) { throw new Exception("DurationCode => Values :" + row["f_durationcode"].ToString() + " Error :" + e.Message); }
                            md.NoteProcessing = row["f_noteprocessing"].ToString();                     //Field 58
                            md.BarcodeByHIS = row["f_freetext3"].ToString();                           //Field 59
                            md.ExcludeIPFill = "";                      //Field 60
                            try
                            {
                                ////if (row["f_lastmodified"].ToString() != "")
                                ////    md.LastModified = DateTime.ParseExact(Convert.ToDateTime(row["f_lastmodified"]).ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);     //Field 61
                                ////else
                                    md.LastModified = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                            }
                            catch (Exception e) { throw new Exception("LastModified => Values :" + row["f_lastmodified"].ToString() + " Error :" + e.Message); }
                            md.Comment = row["f_comment"].ToString();                            //Field 62
                            try
                            {
                                md.DrugBagSplit = Convert.ToDecimal(row["f_bagspecialdrug"]);       //Field 63
                            }
                            catch (Exception e) { throw new Exception("DrugBagSplit => Values :" + row["f_bagspecialdrug"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.OPDAdminStatus = 0;
                            }
                            catch (Exception e) { throw new Exception("OPDAdminStatus => Values :" + row["f_lastmodified"].ToString() + " Error :" + e.Message); }
                            try
                            {
                                md.OPDAdminDateTime = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                            }
                            catch (Exception e) { throw new Exception("OPDAdminDateTime => Values :" + row["f_lastmodified"].ToString() + " Error :" + e.Message); }
                            md.OPDAdminBy = row["f_opdadmitbycode"].ToString();                         //Field 66
                            md.OPDAdminRemark = "";                     //Field 67
                            md.OPDAdminLocation = "";                    //Field 68
                            try
                            {
                                md.OPDAdminContinue = 0;
                            }
                            catch (Exception e) { throw new Exception("OPDAdminContinue => Values :" + row["f_lastmodified"].ToString() + " Error :" + e.Message); }

                            //////////////////////////////////////////////////////////
                            /// Table Extentions Data ThaneshopMiddle.-----------------
                            /// 
                            //Check Data Thanes hosp Middle Extenstion Validation.
                            ext.RunningNo = md.RunningNo;
                            ext.PRN_Indication = "";                                      //Field 70
                            ext.DrugLabelName = row["f_freetext1"].ToString();            //Field 71
                            ext.PregCat = "";                                             //Field 72
                            ext.FreeText1 = row["f_freetext2"].ToString();                //Field 73
                            ext.FreeText3 = "";                                           //Field 74
                            var val = new DataValidation(ext, datafilename).Validate();
                            if (val)
                            {
                                bool Ans = ext.InsertDataExtentionsDetail();
                                if (!Ans)
                                    throw new Exception("ไม่สามารถบันทึกข้อมูลของ Extentions : " + datafilename + " ได้");
                            }

                            //Check Data Thanes hosp Middle Validation.
                            var valid = new DataValidation(md, datafilename).Validate();
                            if (valid)
                            {
                                if (Convert.ToInt32(md.SearchAllDataFullbyPrescription(md.PrescriptionNo, md.Seq,md.RunningNo)) == 0)
                                {
                                    //Middle Tables
                                    bool Answer = md.InsertDataThanesMiddle();
                                    if (Answer == true)
                                    {
                                     
                                        //Update Dispense Status Host.
                                        if (hos.UpdateDispenseStatus(md.PrescriptionNo,md.Seq,md.RunningNo,md.ToMachineNo,1) == true){
                                            result = true;
                                        }
                                        else {
                                            result = false;
                                            throw new Exception("ไม่สามารถอัพเดท Dispense จากฝั่ง host ได้ : " + datafilename + " ได้");
                                        }
                                    }
                                    else {
                                        result = false;
                                        throw new Exception("ไม่สามารถบันทึกข้อมูลของ : " + datafilename + " ได้");
                                    }
                                }
                                else
                                {
                                    result = false;
                                    throw new Exception("ไม่สามารถบันทึกข้อมูลของ : " + datafilename + " ได้ ข้อมูล Dupicate ซ้ำ");
                                }
                            }
                            else
                            {
                                result = false;
                                const string V = "เกิดข้อผิดพลาดการตรวจสอบข้อมูล : ";
                                throw new Exception(V + datafilename);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                hos.UpdateDispenseStatus(md.PrescriptionNo, md.Seq, md.RunningNo, md.ToMachineNo, 3);
                event_code = "E0001";
                event_message = "[" + datafilename + "][Prescription NO] : ข้อผิดพลาด บันทึกข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";
                this.WritelogSystem(true);

                log.Writelogfile("[" + datafilename + "] : บันทึกข้อมูลไม่สำเร็จ " + ex.Message, " ConHIS_Logs");
            }
            return result;
        }

        public bool WritelogSystem(bool enable)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:sss.fff");
            if (enable == true)
            {
                Variable.SysQueue.Enqueue(String.Format("[{0}],{1},{2}", timestamp, event_code, event_message));
            }
            return true;
        }

        public bool AddMasterDrugInfo(Thaneshopmiddle_ATPM md)
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
                        ToMachineNo = md.ToMachineNo,
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
                    var valid = new DataValidation(dr, datafilename).Validate();
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
                                throw new Exception("ไม่สามารถบันทึกข้อมูลของ Master Drug Information : " + datafilename + " ได้");
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        const string V = "เกิดข้อผิดพลาดการตรวจสอบข้อมูล Master Drug Information : ";
                        throw new Exception(V + datafilename);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(" Insert Data Master Drug Information : " + e.Message);
            }
            return result;
        }

        public bool AddMasterInstruction(Thaneshopmiddle_ATPM md)
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
                    throw new Exception("การเพิม่ข้อมูล Master Instruction" + e.Message);
                }
            }
            return result;
        }

        public bool AddMasterFrequency(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            master_frequencyInfo ins = new master_frequencyInfo
            {
                FrequencyCode = md.FrequencyCode,
                FrequencyDesc = md.FrequencyDesc,
                FrequencyTime = md.FrequencyTime
            };

            if (ins.GetFrequencyCheck(md.FrequencyCode) == 0)
            {
                try
                {
                    if (ins.InsertDataFrequency() == true)
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

        private void GenFrequencyDescMessage(Thaneshopmiddle_VICHAIYUT md, string frequencycode ,string frequencydesc ,string frequencytime, string dosagedispense, Int16 prn)
        {
            string strFrequencyTime = "";
            string strFrequencyDesc = "";
            string strFrequencyKey = "";
            string strDosageDispense = "";
            if (prn == 1)
            {
                // PRN 
                md.PRNSTAT = 1;
                frequencytime = "3000";

            }
            else if (prn == 2)
            {
                //STAT
                md.PRNSTAT = 2;
                frequencytime = "4000";
            }
            else if (prn == 3)
            {
                md.PRNSTAT = 3;
                frequencytime = "5000";
            }
            try
            {
                string[] childFrequencyTime = { };
                string[] childDosageDispense = { };


                if (frequencytime != "")
                {
                    childFrequencyTime = frequencytime.Trim().Split(',');
                    int iFrequency = childFrequencyTime.Length;
                    int i = 1;

                    string genKey = "";
                    if (frequencycode.Contains("no") && frequencydesc.Contains("ระบุเวลา"))
                        genKey = "เวลา ";
                    else if (frequencycode.Contains("feed"))
                        genKey = "เวลา ";
                    else
                        genKey += "";

                     foreach (string itemFrequency in childFrequencyTime)
                        {
                            string itemFrequencyTimeHours = itemFrequency.Substring(0, 2);
                            string itemFrequencyTimeMinute = itemFrequency.Substring(2, 2);

                            if (i < iFrequency)
                                strFrequencyTime += itemFrequencyTimeHours + ":" + itemFrequencyTimeMinute + ",";
                            else if (i == iFrequency)
                                strFrequencyTime += itemFrequencyTimeHours + ":" + itemFrequencyTimeMinute;

                            if (!frequencycode.Contains("feed") && !frequencydesc.Contains("ระบุเวลา"))
                            {
                                switch (itemFrequencyTimeHours)
                                {
                                    case "00":
                                        genKey += "";
                                        break;
                                    case "01":
                                        genKey += "";
                                        break;
                                    case "02":
                                        genKey += "";
                                        break;
                                    case "03":
                                        genKey += "";
                                        break;
                                    case "04":
                                        genKey += "";
                                        break;
                                    case "05":
                                        genKey += "เช้า ";
                                        break;
                                    case "06":
                                        genKey += "เช้า ";
                                        break;
                                    case "07":
                                        genKey += "เช้า ";
                                        break;
                                    case "08":
                                        genKey += "เช้า ";
                                        break;
                                    case "09":
                                        genKey += "เช้า ";
                                        break;
                                    case "10":
                                        genKey += "กลางวัน ";
                                        break;
                                    case "11":
                                        genKey += "กลางวัน ";
                                        break;
                                    case "12":
                                        genKey += "กลางวัน ";
                                        break;
                                    case "13":
                                        genKey += "กลางวัน ";
                                        break;
                                    case "14":
                                        genKey += "กลางวัน ";
                                        break;
                                    case "15":
                                        genKey += "เย็น";
                                        break;
                                    case "16":
                                        genKey += "เย็น ";
                                        break;
                                    case "17":
                                        genKey += "เย็น ";
                                        break;
                                    case "18":
                                        genKey += "เย็น ";
                                        break;
                                    case "19":
                                        genKey += "เย็น ";
                                        break;
                                    case "20":
                                        genKey += "ก่อนนอน";
                                        break;
                                    case "21":
                                        genKey += "ก่อนนอน ";
                                        break;
                                    case "22":
                                        genKey += "ก่อนนอน ";
                                        break;
                                    case "23":
                                        genKey += "ก่อนนอน";
                                        break;
                                }
                            }
                            else
                            {
                                switch (itemFrequencyTimeHours)
                                {
                                    case "00":
                                        genKey += "00:00 น. ";
                                        break;              
                                    case "01":              
                                        genKey += "01:00 น. ";
                                        break;              
                                    case "02":              
                                        genKey += "02:00 น. ";
                                        break;              
                                    case "03":              
                                        genKey += "03:00 น. ";
                                        break;              
                                    case "04":              
                                        genKey += "04:00 น. ";
                                        break;              
                                    case "05":              
                                        genKey += "05:00 น. ";
                                        break;              
                                    case "06":              
                                        genKey += "06:00 น. ";
                                        break;              
                                    case "07":              
                                        genKey += "07:00 น. ";
                                        break;              
                                    case "08":              
                                        genKey += "08:00 น. ";
                                        break;              
                                    case "09":              
                                        genKey += "09:00 น. ";
                                        break;              
                                    case "10":              
                                        genKey += "10:00 น. ";
                                        break;              
                                    case "11":              
                                        genKey += "11:00 น. ";
                                        break;              
                                    case "12":              
                                        genKey += "12:00 น. ";
                                        break;              
                                    case "13":              
                                        genKey += "13:00 น. ";
                                        break;              
                                    case "14":              
                                        genKey += "14:00 น. ";
                                        break;              
                                    case "15":              
                                        genKey += "15:00 น. ";
                                        break;              
                                    case "16":              
                                        genKey += "16:00 น. ";
                                        break;              
                                    case "17":              
                                        genKey += "17:00 น. ";
                                        break;              
                                    case "18":              
                                        genKey += "18:00 น. ";
                                        break;              
                                    case "19":              
                                        genKey += "19:00 น. ";
                                        break;              
                                    case "20":              
                                        genKey += "20:00 น. ";
                                        break;              
                                    case "21":              
                                        genKey += "21:00 น. ";
                                        break;              
                                    case "22":              
                                        genKey += "22:00 น. ";
                                        break;              
                                    case "23":              
                                        genKey += "23:00 น. ";
                                        break;
                                }
                            }

                            if ((iFrequency - i) == 1)
                            {
                                 if (!frequencycode.Contains("feed") && !frequencydesc.Contains("ระบุเวลา"))    
                                    genKey += "และ ";
                            }

                            i++;
                        }

                    // กรณีพวกมื้อไม่เท่ากัน
                    if (dosagedispense != "")
                    {
                        string dosagevalue = "";
                        string dosagecheck = "";
                        childDosageDispense = dosagedispense.Trim().Split(',');
                        int j = 1;
                        foreach (string dosage in childDosageDispense)
                        {
                            if (dosage != dosagevalue)
                            {
                                dosagevalue = dosage;
                                if (j == 1)
                                    dosagecheck += "1";
                                else
                                    dosagecheck += "0";
                            }
                            else { dosagecheck += "1"; }
                            j++;
                        }

                        //ตรวจสอบแล้วพบว่ามื้อการรับประทานไม่เท่ากัน
                        if (dosagecheck.Contains("0"))
                        {
                            int k = 0;
                            string[] DosageTime = { };
                            DosageTime = strFrequencyTime.Trim().Split(',');

                            if (iFrequency == childDosageDispense.Length)
                            {
                                foreach (string dosage in childDosageDispense)
                                {
                                    if ((k+1) < iFrequency)
                                        strDosageDispense += dosage + " " + md.OrderUnitDesc + "(" + DosageTime[k] + "), ";
                                    else if ((k + 1) == iFrequency)
                                        strDosageDispense += dosage + " " + md.OrderUnitDesc + "(" + DosageTime[k] + ")";
                                }

                                k++;
                            }
                            else { throw new Exception("DosageDispense กับ FrequencyTime ไม่เท่ากัน"); }

                            md.FrequencyTime = "";
                            md.DosageDispense = strDosageDispense;
                        }
                        else
                        {
                            strFrequencyKey = genKey;
                            if (frequencydesc != "")
                            {
                                if (frequencydesc == "ก่อนนอน")
                                    strFrequencyDesc = "th" + iFrequency + "_วันละ " + iFrequency + " ครั้ง " + frequencydesc;
                                else if (prn > 0)
                                {
                                    strFrequencyDesc = "th" + iFrequency + "_วันละ " + iFrequency + " ครั้ง " + GenFrequencyCase(frequencycode, strFrequencyKey) + frequencydesc;
                                }
                                else
                                    strFrequencyDesc = "th" + iFrequency + "_วันละ " + iFrequency + " ครั้ง " + GenFrequencyCase(frequencycode, strFrequencyKey);


                            }
                            else
                            {
                                if (md.PriorityDesc == "Stat")
                                    strFrequencyDesc = "th" + iFrequency + "_เร่งด่วน " + iFrequency + " ครั้ง ";
                                else if (md.PriorityDesc == "PRN")
                                    strFrequencyDesc = "th" + iFrequency + "_จำนวน " + iFrequency + " ครั้ง เมื่อมีอาการ";
                                else
                                    strFrequencyDesc = "th" + iFrequency + "_วันละ " + iFrequency + " ครั้ง ให้รับประทานเวลา "+ strFrequencyTime + " น.";
                            } 
                            //strFrequencyDesc = "q" + iFrequency + "_ทุก " + (24 / iFrequency) + " ชั่วโมง ";
                            md.FrequencyTime = strFrequencyTime;
                            md.DosageDispense = "";
                        }
                    }
                    md.FrequencyDesc = strFrequencyDesc;
                    ////if (md.PRNSTAT == 1)// PRN
                    ////{
                    ////    md.FrequencyDesc = frequencydesc;
                    ////    md.PRNSTAT = 1;

                    ////}
                    ////else if (md.PRNSTAT == 2) // STAT
                    ////{
                    ////    md.FrequencyDesc = frequencydesc;
                    ////    md.PRNSTAT = 2;
                    ////}
                    ////else // Normal
                    ////{
                    ////    md.FrequencyDesc = frequencydesc; 
                    ////    md.PRNSTAT = 0;
                    ////}


                }
                
            }
            catch(Exception e)
            {
                throw new Exception("Gen ข้อความเพื่อสร้าง Frequency Desc ไม่สำเร็จ" + e.Message);
            }
        }

        private string GenFrequencyCase(string frequencycode, string keydesc)
        {
            string strF = "";

           // if (frequencycode != "")
            //{

            if(keydesc != "ก่อนนอน ")
            {
                switch (frequencycode)
                {
                    case "":
                        strF = "" + keydesc;
                        break;
                    case "ac1":
                        strF = "ก่อนอาหาร" + keydesc + " (ก่อนอาหาร 1 ชั่วโมง)";
                        break;
                    case "achalf":
                        strF = "ก่อนอาหาร" + keydesc + " (ก่อนอาหารครึ่งชั่วโมง)";
                        break;
                    case "ac":
                        strF = "ก่อนอาหาร" + keydesc;
                        break;
                    case "pc1":
                        strF = "หลังอาหาร" + keydesc + " (หลังอาหาร 1 ชั่วโมง)";
                        break;
                    case "pc2":
                        strF = "หลังอาหาร" + keydesc + " (หลังอาหาร 2 ชั่วโมง)";
                        break;
                    case "pci":
                        strF = "หลังอาหาร" + keydesc + " (ทันที)";
                        break;
                    case "wm":
                        strF = "พร้อมอาหาร" + keydesc;
                        break;
                    case "pc":
                        strF = "หลังอาหาร" + keydesc;
                        break;
                    case "pc3":
                        strF = "หลังอาหาร" + keydesc + " (หลังอาหารครึ่งชั่วโมง)";
                        break;
                    case "no":
                        strF = "" + keydesc;
                        break;
                    default:
                         strF = "" + keydesc;
                        break;
                }
            }
            else
            {
                switch (frequencycode)
                {
                    case "":
                        strF = "" + keydesc;
                        break;
                    case "ac1":
                        strF =  keydesc + " (ก่อนอาหาร 1 ชั่วโมง)";
                        break;
                    case "achalf":
                        strF =  keydesc + " (ก่อนอาหารครึ่งชั่วโมง)";
                        break;
                    case "ac":
                        strF = keydesc;
                        break;
                    case "pc1":
                        strF = keydesc + " (หลังอาหาร 1 ชั่วโมง)";
                        break;
                    case "pc2":
                        strF = keydesc + " (หลังอาหาร 2 ชั่วโมง)";
                        break;
                    case "pci":
                        strF = keydesc + " (ทันที)";
                        break;
                    case "wm":
                        strF = keydesc;
                        break;
                    case "pc":
                        strF = keydesc;
                        break;
                    case "pc3":
                        strF = "หลังอาหาร" + keydesc + " (หลังอาหารครึ่งชั่วโมง)";
                        break;
                    case "no":
                        strF = "" + keydesc;
                        break;
                    default:
                        strF = "" + keydesc;
                        break;
                }
            }
               
           // }

            return strF;
        }

        public bool AddJsonThaneshopMiddles(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {
                    JsonThaneshopMiddles jMiddle = new JsonThaneshopMiddles
                    {
                        Prescriptionno = md.PrescriptionNo,                           //Field 01
                        Seq = md.Seq,                                                 //Field 02
                        Seqmax = md.SeqMax,                                           //Field 03
                        Runningno = md.RunningNo,                                     //Field 04
                        Prescriptiondate = md.PrescriptionDate,                       //Field 05
                        Ordercreatedate = md.OrderCreateDate,                         //Field 06
                        Ordertargetdate = md.OrderTargetDate,                         //Field 07
                        Ordertargettime = md.OrderTargetTime,                         //Field 08
                        Pharmacylocationcode = md.PharmacyLocationCode,               //Field 09
                        Pharmacylocationdesc = md.PharmacyLocationDesc,               //Field 10
                        Userorderby = md.UserOrderBy,                                 //Field 11
                        Useracceptby = md.UserAcceptBy,                               //Field 12
                        Orderacceptdate = md.OrderAcceptDate,                         //Field 13
                        Orderacceptfromip = md.OrderAcceptFromIP,                     //Field 14
                        Dispensestatus = md.DispenseStatus,                           //Field 15
                        Status = md.Status,                                           //Field 16
                        Printstatus = md.PrintStatus,                                 //Field 17
                        Hn = md.Hn,                                                   //Field 18
                        An = md.An,                                                   //Field 19
                        Vn = md.Vn,                                                   //Field 20
                        Patientname = md.PatientName,                                 //Field 21
                        Sex = md.Sex,                                                 //Field 22
                        Patientdob = md.PatientDOB,                                   //Field 23
                        Wardcode = md.WardCode,                                       //Field 24
                        Warddesc = md.WardDesc,                                       //Field 25
                        Roomcode = md.RoomCode,                                       //Field 26
                        Roomdesc = md.RoomDesc,                                       //Field 27
                        Bedcode = md.BedCode,                                         //Field 28
                        Drugallergy = md.DrugAllergy,                                 //Field 29
                        Doctorcode = md.DoctorCode,                                   //Field 30
                        Doctorname = md.DoctorName,                                   //Field 31
                        Tomachineno = md.ToMachineNo,                                 //Field 32
                        Orderitemcode = md.OrderItemCode,                             //Field 33
                        Orderitemname = md.OrderItemName,                             //Field 34
                        Orderqty = md.OrderQty,                                       //Field 35
                        Orderunitcode = md.OrderUnitCode,                             //Field 36
                        Orderunitdesc = md.OrderUnitDesc,                             //Field 37
                        Dosage = md.Dosage,                                           //Field 38
                        Dosageunit = md.DosageUnit,                                   //Field 39
                        Binlocation = md.BinLocation,                                 //Field 40
                        Itemidentify = md.ItemIdentify,                               //Field 41
                        Itemlotno = md.ItemLotNo,                                     //Field 42
                        Itemlotexpire = md.ItemLotExpire,                             //Field 43
                        Instructioncode = md.InstructionCode,                         //Field 44
                        Instructiondesc = md.InstructionDesc,                         //Field 45
                        Drugformcode = md.DrugFormCode,                               //Field 46
                        Drugformdesc = md.DrugFormDesc,                               //Field 47
                        Highalertdrug = md.HeighAlretDrug,                            //Field 48
                        Prnstat = md.PRNSTAT,                                         //Field 49
                        Prioritycode = md.PriorityCode,                               //Field 50
                        Prioritydesc = md.PriorityDesc,                               //Field 51
                        Frequencycode = md.FrequencyCode,                             //Field 52
                        Frequencydesc = md.FrequencyDesc,                             //Field 53
                        Frequencytime = md.FrequencyTime,                             //Field 54
                        Dosagedispense = md.DosageDispense,                           //Field 55
                        Language = md.Language,                                       //Field 56
                        Durationcode = md.DurationCode,                               //Field 57
                        Noteprocessing = md.NoteProcessing,                           //Field 58
                        Barcodebyhis = md.BarcodeByHIS,                               //Field 59
                        Excludeipfill = md.ExcludeIPFill,                             //Field 60
                        Lastmodified = md.LastModified,                               //Field 61
                        Comment = md.Comment,                                         //Field 62
                        Drugbagsplit = md.DrugBagSplit,                               //Field 63
                        OpdAdminstatus = md.OPDAdminStatus,                          //Field 64
                        OpdAdmindatetime = md.OPDAdminDateTime,                      //Field 65
                        OpdAdminby = md.OPDAdminBy,                                  //Field 66
                        OpdAdminremark = md.OPDAdminRemark,                          //Field 67
                        OpdAdminlocation = md.OPDAdminLocation,                      //Field 68
                        OpdAdmincontinue = md.OPDAdminContinue,                       //Field 69
                        RowId = ""
                    };

                    jMiddle.AddThaneshopMiddles(jMiddle);
                    result = true;
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                throw new Exception("RestFull API Error : " + ErrorMessage.errorMessage);
            }
            return result;
        }

        public bool AddJsonGenders(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {   
                    JsonGenders jGender = new JsonGenders
                    {
                        Name = md.Sex,                                                  
                    };
                    jGender.AddGenders(jGender);
                    result = true;
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                throw new Exception("RestFull API Error : " + ErrorMessage.errorMessage);
            }
            return result;
        }

        public bool AddJsonLanguages(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {
                    JsonLanguages j = new JsonLanguages
                    {
                        Name = md.Sex,                                                 
                    };
                    j.AddLanguages(j);
                    result = true;
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                throw new Exception("RestFull API Error : " + ErrorMessage.errorMessage);
            }
            return result;
        }

        public bool AddJsonPatients(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if (md != null)
                {
                    JsonPatients j = new JsonPatients
                    {
                        Hn = md.Hn,
                        Name = md.PatientName,
                        DOB = md.PatientDOB,
                        GenderId = 1,
                        LanguageId =1
                    };
                    j.AddPatients(j);
                    result = true;
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                throw new Exception("RestFull API Error : " + ErrorMessage.errorMessage);
            }
            return result;
        }
    }
}