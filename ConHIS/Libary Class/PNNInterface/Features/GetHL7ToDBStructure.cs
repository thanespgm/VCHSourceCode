using ConHIS.Libary_Class.CRAInterface.Features;
using ConHIS.Libary_Class.PNNInterface.HL7Structure;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;

namespace ConHIS.Libary_Class.PNNInterface.Features
{
    public class PNNHGetHL7ToDBStructure
    {
        //Variable And Objects
        private readonly hosxp_conhis_machine hos;

        private ArrayList mSegments;

        private readonly System_logfile log;
        private readonly Thaneshopmiddle_ATPM md;
        private readonly Thaneshopmiddle_extentions_ATPM ext;

        private string dataStrings;
        private byte[] dataText;
        private string SetData = "";
        private string EventCd = "";
        private string OldName = "";
        

        private HL7Segments mHL7Message;
        private string ActiveFileType = "";
        private string EventFileType = "";

        public HL7Segments CurrentHL7
        {
            get { return mHL7Message; }
            set { }
        }

        public PNNHGetHL7ToDBStructure()
        {
            mHL7Message = new HL7Segments();
            log = new System_logfile();
            md = new Thaneshopmiddle_ATPM();
            ext = new Thaneshopmiddle_extentions_ATPM();
            hos = new hosxp_conhis_machine();
        }

        private string event_code;
        private string event_message;

        public string BinaryToText(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            string text = reader.ReadToEnd();
            return text;
        }

        public bool InterfaceHL7MessageHosXP(bool enable, string fileID)
        {
            bool result = false;
            try
            {
                if (enable == true)
                {
                    event_code = "F00IN";
                    event_message = "GetData Dispense ID : " + fileID.ToString();
                   
                    this.WritelogSystem(true);

                    DataSet ipd = hos.GetDataConHISMachine(fileID);
                    SetData = fileID.ToString();

                    if (ipd.Tables[0].Rows.Count != 0)
                    {
                        int itemsAll = ipd.Tables[0].Rows.Count;

                        for (int i = 0; i < itemsAll; i++)
                        {
                            dataText = (byte[])ipd.Tables[0].Rows[i]["hl7_data"];
                            dataStrings = BinaryToText(dataText);

                            mHL7Message.LoadHL7Message(dataStrings);

                            if (mHL7Message.SegmentArray.Count > 0)
                            {
                                HL7NodeInfo HL7Node;
                                string segType;

                                for (int nodIdx = 0; nodIdx < mHL7Message.SegmentArray.Count; nodIdx++)
                                {
                                    segType = mHL7Message.GetSegmentType(nodIdx);
                                    HL7Node = new HL7NodeInfo(HL7NodeType.HL7Segment, segType.Trim().ToUpper(), nodIdx, -1, -1, -1);
                                    HL7Node.ElementCount = mHL7Message.FieldCount(nodIdx);

                                    if (OldName != SetData)
                                    {
                                        OldName = SetData;

                                        if (mHL7Message.GetSegmentType(0) == "MSH")
                                        {
                                            string[] segDetail = ((string)mHL7Message.SegmentArray[0]).Split('|');
                                            if (segDetail.Length > 7)
                                            {


                                                string msgType = segDetail[8];
                                                segDetail = msgType.Split('^');
                                                if (segDetail.Length > 1)
                                                {
                                                    EventFileType = segDetail[0];
                                                    ActiveFileType = segDetail[1];
                                                    EventCd = EventFileType + " " + ActiveFileType;
                                                    ActiveFileType = ActiveFileType.Trim().ToUpper();
                                                    log.Writelogfile(" Drug Dispense IPD ID : " + SetData.ToString() + " Message name-type = " + EventFileType, " HL7Messges");
                                                    log.Writelogfile(" Drug Dispense IPD ID : " + SetData.ToString() + " Message event-type = " + ActiveFileType, " HL7Messges");
                                                }
                                            }
                                        }
                                    }

                                    string[] childParts = { };
                                    string parentData;
                                    switch (EventFileType)
                                    {
                                        case "RDE":
                                            switch (ActiveFileType)
                                            {
                                                // O01 - Pharmacy/treatment dispense
                                                case "O01":
                                                    if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                                    {
                                                        parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                        childParts = parentData.Split('|');
                                                        switch (HL7Node.SegmentType)
                                                        {
                                                            case "MSH":
                                                                AddMessageHeader(childParts);
                                                                break;
                                                            case "PID":
                                                                AddPatientIdentification(childParts);
                                                                break;
                                                            case "PV1":
                                                                AddPatientVisit(childParts);
                                                                break;
                                                            case "ORC":
                                                                AddCommondOrder(childParts);
                                                                break;
                                                            case "AL1":
                                                                AddPatientAllergyInformation(childParts);
                                                                break;
                                                            case "RXE":
                                                                AddPharmacyEncodedOrderSegment(childParts);
                                                                break;
                                                            case "RXD":
                                                                AddPharmacyTreamentDispense(childParts);
                                                                break;
                                                            case "RXR":
                                                                AddPharmacyTreatmentRoute(childParts);
                                                                break;
                                                            case "NTE":
                                                                AddNotesAndComments(childParts);
                                                                break;
                                                            case "TQ1":
                                                                AddTimingAndQuantity(childParts);
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }
                                            break;
                                        case "ADT":
                                            switch (ActiveFileType)
                                            {
                                                // A01 - Admit/visit notification
                                                case "A01":
                                                    if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                                    {
                                                        parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                        childParts = parentData.Split('|');
                                                        switch (HL7Node.SegmentType)
                                                        {
                                                            case "MSH":
                                                                AddMessageHeader(childParts);
                                                                break;
                                                            case "EVN":
                                                                AddEventType(childParts);
                                                                break;
                                                            case "PID":
                                                                AddPatientIdentification(childParts);
                                                                break;
                                                            case "PV1":
                                                                AddPatientVisit(childParts);
                                                                break;
                                                            case "AL1":
                                                                AddPatientAllergyInformation(childParts);
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                // A02 - Transfer a patient
                                                case "A02":
                                                    if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                                    {
                                                        parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                        childParts = parentData.Split('|');
                                                        switch (HL7Node.SegmentType)
                                                        {
                                                            case "MSH":
                                                                AddMessageHeader(childParts);
                                                                break;
                                                            case "EVN":
                                                                AddEventType(childParts);
                                                                break;
                                                            case "PID":
                                                                AddPatientIdentification(childParts);
                                                                break;
                                                            case "PV1":
                                                                AddPatientVisit(childParts);
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                // A03 - Discharge/end visit
                                                case "A03":
                                                    if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                                    {
                                                        parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                        childParts = parentData.Split('|');
                                                        switch (HL7Node.SegmentType)
                                                        {
                                                            case "MSH":
                                                                AddMessageHeader(childParts);
                                                                break;
                                                            case "EVN":
                                                                AddEventType(childParts);
                                                                break;
                                                            case "PID":
                                                                AddPatientIdentification(childParts);
                                                                break;
                                                            case "PV1":
                                                                AddPatientVisit(childParts);
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }
                                            break;
                                    }
                                }
                            }

                            //==================================================================================================
                            //Update Table Drug Dispense IPD for Hosxp Interface
                            hos.UpdateStatusConHISMachine("Y", fileID);
                            //==================================================================================================
                        }

                        #region "Data Insert Values To tb_thanes_middle"

                         MappingMiddleController map = new MappingMiddleController(EventFileType, ActiveFileType);

                        if (map.MiddleActiveEventHandler(SetData) == true)
                        {
                           // hos.UpdateStatusConHISMachine("", fileID);
                            event_code = "Success";
                            event_message = "[" + SetData + "] : " + "บันทึกข้อมูลเรียบร้อยแล้ว";
                            this.WritelogSystem(true);
                            result = true;
                        }
                        else
                        {
                            event_code = "Error";
                            event_message = "[" + SetData + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                            this.WritelogSystem(true);

                            result = false;
                        }

                        #endregion "Data Insert Values To tb_thanes_middle"
                    }
                }
            }
            catch (Exception ex)
            {
                log.Writelogfile(" Drug Dispense OPD ID : " + fileID.ToString() + " Format Error" + ex.ToString(), " HL7Message_Error");

                hos.UpdateStatusConHISMachine("Y", fileID);

                event_code = "E0002";
              //  event_message = "[" + th.Prescriptionno + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                this.WritelogSystem(true);
            }
            finally { }
            return result;
        }

        private string GetPatientName(string data)
        {
            string fristName, LastName, preName;
            LastName = data.Split('^').GetValue(0).ToString().Trim();
            fristName = data.Split('^').GetValue(1).ToString().Trim();
            preName = data.Split('^').GetValue(3).ToString().Trim();
            return preName + fristName + " " + LastName;
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

        #region "HL7 Message Structure"
        private void AddMessageHeader(string[] data)
        {
            try
            {
                if (data.Length == 19)
                {
                    MSH msh = new MSH()
                    {
                        MSH_1 = "|",
                        MSH_2 = data[1],
                        MSH_3 = data[2],
                        MSH_4 = data[3],
                        MSH_5 = data[4],
                        MSH_6 = data[5],
                        MSH_7 = data[6],
                        MSH_8 = data[7],
                        MSH_9 = data[8],
                        MSH_10 = data[9],
                        MSH_11 = data[10],
                        MSH_12 = data[11],
                        MSH_13 = data[12],
                        MSH_14 = data[13],
                        MSH_15 = data[14],
                        MSH_16 = data[15],
                        MSH_17 = data[16],
                        MSH_18 = data[17],
                        MSH_19 = data[18],
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(msh, SetData).Validate();
                    if (ValidateResult)
                    {
                        msh.Add(msh);
                    }
                }
                else
                    throw new Exception("MSH -> [Total Required Column: 19][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientIdentification(string[] data)
        {
            try
            {
                if (data.Length == 31)
                {
                    PID pid = new PID()
                    {
                        PID_1 = data[1].Trim(),
                        PID_2 = data[2].Trim(),
                        PID_3 = data[3].Trim(),
                        PID_4 = data[4].Trim(),
                        PID_5 = data[5].Trim(),
                        PID_6 = data[6].Trim(),
                        PID_7 = data[7].Trim(),
                        PID_8 = data[8].Trim(),
                        PID_9 = data[9].Trim(),
                        PID_10 = data[10].Trim(),
                        PID_11 = data[11].Trim(),
                        PID_12 = data[12].Trim(),
                        PID_13 = data[13].Trim(),
                        PID_14 = data[14].Trim(),
                        PID_15 = data[15].Trim(),
                        PID_16 = data[16].Trim(),
                        PID_17 = data[17].Trim(),
                        PID_18 = data[18].Trim(),
                        PID_19 = data[19].Trim(),
                        PID_20 = data[20].Trim(),
                        PID_21 = data[21].Trim(),
                        PID_22 = data[22].Trim(),
                        PID_23 = data[23].Trim(),
                        PID_24 = data[24].Trim(),
                        PID_25 = data[25].Trim(),
                        PID_26 = data[26].Trim(),
                        PID_27 = data[27].Trim(),
                        PID_28 = data[28].Trim(),
                        PID_29 = data[29].Trim(),
                        PID_30 = data[30].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(pid, SetData).Validate();
                    if (ValidateResult)
                    {
                        pid.Add(pid);
                    }
                }
                else
                    throw new Exception("PID ->[Total Required Column: 30][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientVisit(string[] data)
        {
            try
            {
                if (data.Length == 52)
                {
                    PV1 pV1 = new PV1()
                    {
                        PV1_1 = data[1].Trim(),
                        PV1_2 = data[2].Trim(),
                        PV1_3 = data[3].Trim(),
                        PV1_4 = data[4].Trim(),
                        PV1_5 = data[5].Trim(),
                        PV1_6 = data[6].Trim(),
                        PV1_7 = data[7].Trim(),
                        PV1_8 = data[8].Trim(),
                        PV1_9 = data[9].Trim(),
                        PV1_10 = data[10].Trim(),
                        PV1_11 = data[11].Trim(),
                        PV1_12 = data[12].Trim(),
                        PV1_13 = data[13].Trim(),
                        PV1_14 = data[14].Trim(),
                        PV1_15 = data[15].Trim(),
                        PV1_16 = data[16].Trim(),
                        PV1_17 = data[17].Trim(),
                        PV1_18 = data[18].Trim(),
                        PV1_19 = data[19].Trim(),
                        PV1_20 = data[20].Trim(),
                        PV1_21 = data[21].Trim(),
                        PV1_22 = data[22].Trim(),
                        PV1_23 = data[23].Trim(),
                        PV1_24 = data[24].Trim(),
                        PV1_25 = data[25].Trim(),
                        PV1_26 = data[26].Trim(),
                        PV1_27 = data[27].Trim(),
                        PV1_28 = data[28].Trim(),
                        PV1_29 = data[29].Trim(),
                        PV1_30 = data[30].Trim(),
                        PV1_31 = data[31].Trim(),
                        PV1_32 = data[32].Trim(),
                        PV1_33 = data[33].Trim(),
                        PV1_34 = data[34].Trim(),
                        PV1_35 = data[35].Trim(),
                        PV1_36 = data[36].Trim(),
                        PV1_37 = data[37].Trim(),
                        PV1_38 = data[38].Trim(),
                        PV1_39 = data[39].Trim(),
                        PV1_40 = data[40].Trim(),
                        PV1_41 = data[41].Trim(),
                        PV1_42 = data[42].Trim(),
                        PV1_43 = data[43].Trim(),
                        PV1_44 = data[44].Trim(),
                        PV1_45 = data[45].Trim(),
                        PV1_46 = data[46].Trim(),
                        PV1_47 = data[47].Trim(),
                        PV1_48 = data[48].Trim(),
                        PV1_49 = data[49].Trim(),
                        PV1_50 = data[50].Trim(),
                        PV1_51 = data[51].Trim(),
                        //PV1_52 = data[52].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(pV1, SetData).Validate();
                    if (ValidateResult)
                    {
                        pV1.Add(pV1);
                    }
                }
                else
                    throw new Exception("PV1 ->[Total Required Column: 52][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddCommondOrder(string[] data)
        {
            try
            {
                if (data.Length == 20)
                {
                    ORC oRC = new ORC()
                    {
                        ORC_1 = data[1].Trim(),
                        ORC_2 = data[2].Trim(),
                        ORC_3 = data[3].Trim(),
                        ORC_4 = data[4].Trim(),
                        ORC_5 = data[5].Trim(),
                        ORC_6 = data[6].Trim(),
                        ORC_7 = data[7].Trim(),
                        ORC_8 = data[8].Trim(),
                        ORC_9 = data[9].Trim(),
                        ORC_10 = data[10].Trim(),
                        ORC_11 = data[11].Trim(),
                        ORC_12 = data[12].Trim(),
                        ORC_13 = data[13].Trim(),
                        ORC_14 = data[14].Trim(),
                        ORC_15 = data[15].Trim(),
                        ORC_16 = data[16].Trim(),
                        ORC_17 = data[17].Trim(),
                        ORC_18 = data[18].Trim(),
                        ORC_19 = data[19].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData,
                    };
                    var ValidateResult = new HL7DataValidation(oRC, SetData).Validate();
                    if (ValidateResult)
                    {
                        oRC.Add(oRC);
                    }
                }
                else
                    throw new Exception("ORC ->[Total Required Column: 34][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientAllergyInformation(string[] data)
        {
            try
            {
                if (data.Length == 7)
                {
                    AL1 aL1 = new AL1()
                    {
                        AL1_1 = data[1].Trim(),
                        AL1_2 = data[2].Trim(),
                        AL1_3 = data[3].Trim(),
                        AL1_4 = data[4].Trim(),
                        AL1_5 = data[5].Trim(),
                        AL1_6 = data[6].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(aL1, SetData).Validate();
                    if (ValidateResult)
                    {
                        aL1.Add(aL1);
                    }
                }
                else
                    throw new Exception("AL1 ->[Total Required Column: 7][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPharmacyTreamentDispense(string[] data)
        {
            try
            {
                if (data.Length > 25 || data.Length == 25)
                {
                    RXD rXD = new RXD()
                    {
                        RXD_1 = data[1].Trim(),
                        RXD_2 = data[2].Trim(),
                        RXD_3 = data[3].Trim(),
                        RXD_4 = data[4].Trim(),
                        RXD_5 = data[5].Trim(),
                        RXD_6 = data[6].Trim(),
                        RXD_7 = data[7].Trim(),
                        RXD_8 = data[8].Trim(),
                        RXD_9 = data[9].Trim(),
                        RXD_10 = data[10].Trim(),
                        RXD_11 = data[11].Trim(),
                        RXD_12 = data[12].Trim(),
                        RXD_13 = data[13].Trim(),
                        RXD_14 = data[14].Trim(),
                        RXD_15 = data[15].Trim(),
                        RXD_16 = data[16].Trim(),
                        RXD_17 = data[17].Trim(),
                        RXD_18 = data[18].Trim(),
                        RXD_19 = data[19].Trim(),
                        RXD_20 = data[20].Trim(),
                        RXD_21 = data[21].Trim(),
                        RXD_22 = data[22].Trim(),
                        RXD_23 = data[23].Trim(),
                        RXD_24 = data[24].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(rXD, SetData).Validate();
                    if (ValidateResult)
                    {
                        rXD.Add(rXD);
                    }
                }
                else
                    throw new Exception("RXD ->[Total Required Column: 25][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPharmacyEncodedOrderSegment(string[] data)
        {
            try
            {
                if (data.Length == 31)
                {
                    RXE rXE = new RXE()
                    {
                        RXE_1 = data[1].Trim(),
                        RXE_2 = data[2].Trim(),
                        RXE_3 = data[3].Trim(),
                        RXE_4 = data[4].Trim(),
                        RXE_5 = data[5].Trim(),
                        RXE_6 = data[6].Trim(),
                        RXE_7 = data[7].Trim(),
                        RXE_8 = data[8].Trim(),
                        RXE_9 = data[9].Trim(),
                        RXE_10 = data[10].Trim(),
                        RXE_11 = data[11].Trim(),
                        RXE_12 = data[12].Trim(),
                        RXE_13 = data[13].Trim(),
                        RXE_14 = data[14].Trim(),
                        RXE_15 = data[15].Trim(),
                        RXE_16 = data[16].Trim(),
                        RXE_17 = data[17].Trim(),
                        RXE_18 = data[18].Trim(),
                        RXE_19 = data[19].Trim(),
                        RXE_20 = data[20].Trim(),
                        RXE_21 = data[21].Trim(),
                        RXE_22 = data[22].Trim(),
                        RXE_23 = data[23].Trim(),
                        RXE_24 = data[24].Trim(),
                        RXE_25 = data[25].Trim(),
                        RXE_26 = data[26].Trim(),
                        RXE_27 = data[27].Trim(),
                        RXE_28 = data[28].Trim(),
                        RXE_29 = data[29].Trim(),
                        RXE_30 = data[30].Trim(),
                        //RXE_31 = data[31].Trim(),
                        //RXE_32 = data[32].Trim(),
                        //RXE_33 = data[33].Trim(),
                        //RXE_34 = data[34].Trim(),
                        //RXE_35 = data[35].Trim(),
                        //RXE_36 = data[36].Trim(),
                        //RXE_37 = data[37].Trim(),
                        //RXE_38 = data[38].Trim(),
                        //RXE_39 = data[39].Trim(),
                        //RXE_40 = data[40].Trim(),
                        //RXE_41 = data[41].Trim(),
                        //RXE_42 = data[42].Trim(),
                        //RXE_43 = data[43].Trim(),
                        //RXE_44 = data[44].Trim(),
                        //RXE_45 = data[45].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(rXE, SetData).Validate();
                    if (ValidateResult)
                    {
                        rXE.Add(rXE);
                    }
                }
                else
                    throw new Exception("RXE ->[Total Required Column: 30][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPharmacyTreatmentRoute(string[] data)
        {
            try
            {
                if (data.Length >= 4)
                {
                    RXR rXR = new RXR()
                    {
                        RXR_1 = data[1].Trim(),
                        RXR_2 = data[2].Trim(),
                        RXR_3 = data[3].Trim(),
                       // RXR_4 = data[4].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData,
                    };
                    var ValidateResult = new HL7DataValidation(rXR, SetData).Validate();
                    if (ValidateResult)
                    {
                        rXR.Add(rXR);
                    }
                }
                else
                    throw new Exception("RXR ->[Total Required Column: 5][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddNotesAndComments(string[] data)
        {
            try
            {
                if (data.Length == 4)
                {
                    NTE nTE = new NTE()
                    {
                        NTE_1 = data[1].Trim(),
                        NTE_2 = data[2].Trim(),
                        NTE_3 = data[3].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(nTE, SetData).Validate();
                    if (ValidateResult)
                    {
                        nTE.Add(nTE);
                    }
                }
                else
                    throw new Exception("NTE ->[Total Required Column: 4][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddTimingAndQuantity(string[] data)
        {
            try
            {
                if (data.Length == 15)
                {
                    TQ1 tQ1 = new TQ1()
                    {
                        TQ1_1 = data[1].Trim(),
                        TQ1_2 = data[2].Trim(),
                        TQ1_3 = data[3].Trim(),
                        TQ1_4 = data[4].Trim(),
                        TQ1_5 = data[5].Trim(),
                        TQ1_6 = data[6].Trim(),
                        TQ1_7 = data[7].Trim(),
                        TQ1_8 = data[8].Trim(),
                        TQ1_9 = data[9].Trim(),
                        TQ1_10 = data[10].Trim(),
                        TQ1_11 = data[11].Trim(),
                        TQ1_12 = data[12].Trim(),
                        TQ1_13 = data[13].Trim(),
                        TQ1_14 = data[14].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(tQ1, SetData).Validate();
                    if (ValidateResult)
                    {
                        tQ1.Add(tQ1);
                    }
                }
                else
                    throw new Exception("TQ1 ->[Total Required Column: 15][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddEventType(string[] data)
        {
            try
            {
                if (data.Length == 8)
                {
                    EVN eVN = new EVN()
                    {
                        EVN_1 = data[1].Trim(),
                        EVN_2 = data[2].Trim(),
                        EVN_3 = data[3].Trim(),
                        EVN_4 = data[4].Trim(),
                        EVN_5 = data[5].Trim(),
                        EVN_6 = data[6].Trim(),
                        EVN_7 = data[7].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(eVN, SetData).Validate();
                    if (ValidateResult)
                    {
                        eVN.Add(eVN);
                    }
                }
                else
                    throw new Exception("EVN ->[Total Required Column: 8][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}