using System;
using System.Data;
using System.IO;
using System.Text;

namespace ConHIS.Libary_Class
{
    internal class hosxp_hl7_message_interface
    {
        //Variable And Objects
        // private readonly Thaneshopmiddle_SUTH th;
        private readonly Thaneshopmiddle_PCMC th;

        //private readonly hosxp_conhis_machine hos;
        private readonly hosxp_conhis_machine hos;

        private readonly System_logfile logs = new System_logfile();

        private string dataStrings;
        private byte[] dataText;
        private string SetData = "";
        private string EventCd = "";

        private DataSet ipd = null;

        private HL7Segments mHL7Message;
        private string ActiveFileType = "";

        public HL7Segments CurrentHL7
        {
            get { return mHL7Message; }
            set { }
        }

        public hosxp_hl7_message_interface()
        {
            mHL7Message = new HL7Segments();
            hos = new hosxp_conhis_machine();
            th = new Thaneshopmiddle_PCMC();
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
                    event_message = "[" + th.Prescriptionno + "] : " + "GetData Dispense ID : " + fileID.ToString();
                    this.WritelogSystem(true);

                    ipd = hos.GetDataConHISMachine(fileID);
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

                                    /// When a tree node is expanded for the first time its child node collection
                                    /// has not been populated.  This will populate the child nodes when required.
                                    ///
                                    string[] childParts = { };
                                    //string childPart;
                                    string parentData;

                                    //HL7NodeInfo childInfo;
                                    //HL7NodeInfo groupInfo;

                                    if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                    {
                                        parentData = mHL7Message.GetElement(HL7Node.MsgIndex);

                                        if (HL7Node.SegmentType == "MSH")
                                        {
                                            childParts = parentData.Split('|');
                                            //------------------------------------------------------------------------------------------------------------
                                            //--------------------------------------------------insert  MSH table-----------------------------------------
                                            hl7_msh_V2_3 hl7 = new hl7_msh_V2_3();

                                            hl7.SET_CODE = SetData;

                                            hl7.MSH_1 = childParts[1];
                                            hl7.MSH_2 = childParts[2];
                                            hl7.MSH_3 = childParts[3];
                                            hl7.MSH_4 = childParts[4];
                                            hl7.MSH_5 = childParts[5];
                                            hl7.MSH_6 = childParts[6];
                                            hl7.MSH_7 = childParts[7];
                                            hl7.MSH_8 = childParts[8];
                                            hl7.MSH_9 = childParts[9];
                                            hl7.MSH_10 = childParts[10];
                                            hl7.MSH_11 = childParts[11];

                                            hl7.Add(hl7);

                                            EventCd = childParts[8].Split('^').GetValue(0).ToString().Trim();
                                            //------------------------------------------------------------------------------------------------------------
                                            //------------------------------------------------------------------------------------------------------------
                                        }
                                        else
                                        {
                                            childParts = parentData.Split('|');

                                            switch (HL7Node.SegmentType)
                                            {
                                                case "PID":

                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert  PID table-----------------------------------------
                                                    hl7_pid_V2_3 pid = new hl7_pid_V2_3();

                                                    pid.SET_CODE = SetData;

                                                    pid.PID_1 = childParts[1].Trim();
                                                    pid.PID_2 = childParts[2].Trim();
                                                    pid.PID_3 = childParts[3].Trim();
                                                    pid.PID_4 = childParts[4].Trim();
                                                    pid.PID_5 = childParts[5].Trim();
                                                    pid.PID_6 = childParts[6].Trim();
                                                    pid.PID_7 = childParts[7].Trim();
                                                    pid.PID_8 = childParts[8].Trim();
                                                    pid.PID_9 = childParts[9].Trim();
                                                    pid.PID_10 = childParts[10].Trim();
                                                    pid.PID_11 = childParts[11].Trim();
                                                    pid.PID_12 = childParts[12].Trim();
                                                    pid.PID_13 = childParts[13].Trim();
                                                    pid.PID_14 = childParts[14].Trim();
                                                    pid.PID_15 = childParts[15].Trim();
                                                    pid.PID_16 = childParts[16].Trim();
                                                    pid.PID_17 = childParts[17].Trim();
                                                    pid.PID_18 = childParts[18].Trim();
                                                    pid.PID_19 = childParts[19].Trim();
                                                    pid.PID_20 = childParts[20].Trim();
                                                    pid.PID_21 = childParts[21].Trim();
                                                    pid.PID_22 = childParts[22].Trim();
                                                    pid.PID_23 = childParts[23].Trim();
                                                    pid.PID_24 = childParts[24].Trim();
                                                    pid.PID_25 = childParts[25].Trim();
                                                    pid.PID_26 = childParts[26].Trim();
                                                    pid.PID_27 = childParts[27].Trim();
                                                    pid.PID_28 = childParts[28].Trim();
                                                    pid.PID_29 = childParts[29].Trim();
                                                    pid.PID_30 = childParts[30].Trim();
                                                    pid.EVEN = EventCd;

                                                    pid.Add(pid);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "PV1":

                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert  PV1 table-----------------------------------------
                                                    hl7_pv1_V2_3 pv1 = new hl7_pv1_V2_3();
                                                    pv1.SET_CODE = SetData;

                                                    pv1.PV1_1 = childParts[1].Trim();
                                                    pv1.PV1_2 = childParts[2].Trim();
                                                    pv1.PV1_3 = childParts[3].Trim();
                                                    pv1.PV1_4 = childParts[4].Trim();
                                                    pv1.PV1_5 = childParts[5].Trim();
                                                    pv1.PV1_6 = childParts[6].Trim();
                                                    pv1.PV1_7 = childParts[7].Trim();
                                                    pv1.PV1_8 = childParts[8].Trim();
                                                    pv1.PV1_9 = childParts[9].Trim();
                                                    pv1.PV1_10 = childParts[10].Trim();
                                                    pv1.PV1_11 = childParts[11].Trim();
                                                    pv1.PV1_12 = childParts[12].Trim();
                                                    pv1.PV1_13 = childParts[13].Trim();
                                                    pv1.PV1_14 = childParts[14].Trim();
                                                    pv1.PV1_15 = childParts[15].Trim();
                                                    pv1.PV1_16 = childParts[16].Trim();
                                                    pv1.PV1_17 = childParts[17].Trim();
                                                    pv1.PV1_18 = childParts[18].Trim();
                                                    pv1.PV1_19 = childParts[19].Trim();
                                                    pv1.PV1_20 = childParts[20].Trim();
                                                    pv1.PV1_21 = childParts[21].Trim();
                                                    pv1.PV1_22 = childParts[22].Trim();
                                                    pv1.PV1_23 = childParts[23].Trim();
                                                    pv1.PV1_24 = childParts[24].Trim();
                                                    pv1.PV1_25 = childParts[25].Trim();
                                                    pv1.PV1_26 = childParts[26].Trim();
                                                    pv1.PV1_27 = childParts[27].Trim();
                                                    pv1.PV1_28 = childParts[28].Trim();
                                                    pv1.PV1_29 = childParts[29].Trim();
                                                    pv1.PV1_30 = childParts[30].Trim();
                                                    pv1.PV1_31 = childParts[31].Trim();
                                                    pv1.PV1_32 = childParts[32].Trim();
                                                    pv1.PV1_33 = childParts[33].Trim();
                                                    pv1.PV1_34 = childParts[34].Trim();
                                                    pv1.PV1_35 = childParts[35].Trim();
                                                    pv1.PV1_36 = childParts[36].Trim();
                                                    pv1.PV1_37 = childParts[37].Trim();
                                                    pv1.PV1_38 = childParts[38].Trim();
                                                    pv1.PV1_39 = childParts[39].Trim();
                                                    pv1.PV1_40 = childParts[40].Trim();
                                                    pv1.PV1_41 = childParts[41].Trim();
                                                    pv1.PV1_42 = childParts[42].Trim();
                                                    pv1.PV1_43 = childParts[43].Trim();
                                                    pv1.PV1_44 = childParts[44].Trim();
                                                    pv1.PV1_45 = childParts[45].Trim();
                                                    pv1.PV1_46 = childParts[46].Trim();
                                                    pv1.PV1_47 = childParts[47].Trim();
                                                    pv1.PV1_48 = childParts[48].Trim();
                                                    pv1.PV1_49 = childParts[49].Trim();
                                                    pv1.PV1_50 = childParts[50].Trim();
                                                    pv1.PV1_51 = childParts[51].Trim();
                                                    pv1.EVEN = EventCd;

                                                    pv1.Add(pv1);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "ORC":  // Command Order Segment

                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert  ORC table-----------------------------------------
                                                    hl7_orc_V2_3 orc = new hl7_orc_V2_3();

                                                    orc.SET_CODE = SetData;

                                                    orc.ORC_1 = childParts[1].Trim();
                                                    orc.ORC_2 = childParts[2].Trim();
                                                    orc.ORC_3 = childParts[3].Trim();
                                                    orc.ORC_4 = childParts[4].Trim();
                                                    orc.ORC_5 = childParts[5].Trim();
                                                    orc.ORC_6 = childParts[6].Trim();
                                                    orc.ORC_7 = childParts[7].Trim();
                                                    orc.ORC_8 = childParts[8].Trim();
                                                    orc.ORC_9 = childParts[9].Trim();
                                                    orc.ORC_10 = childParts[10].Trim();
                                                    orc.ORC_11 = childParts[11].Trim();
                                                    orc.ORC_12 = childParts[12].Trim();
                                                    orc.ORC_13 = childParts[13].Trim();
                                                    orc.ORC_14 = childParts[14].Trim();
                                                    orc.ORC_15 = childParts[15].Trim();
                                                    orc.ORC_16 = childParts[16].Trim();
                                                    orc.ORC_17 = childParts[17].Trim();
                                                    orc.ORC_18 = childParts[18].Trim();
                                                    orc.ORC_19 = childParts[19].Trim();
                                                    orc.EVEN = EventCd;

                                                    orc.Add(orc);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "AL1":  // Patient Allergy Information

                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert AL1 table-----------------------------------------
                                                    hl7_al1_V2_3 al1 = new hl7_al1_V2_3();

                                                    al1.SET_CODE = SetData;

                                                    al1.AL1_1 = childParts[1].Trim();
                                                    al1.AL1_2 = childParts[2].Trim();
                                                    al1.AL1_3 = childParts[3].Trim();
                                                    al1.AL1_4 = childParts[4].Trim();
                                                    al1.AL1_5 = childParts[5].Trim();
                                                    al1.AL1_6 = childParts[6].Trim();
                                                    al1.EVEN = EventCd;

                                                    al1.Add(al1);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "RXD":  // Pharmacy/Treatment Dispense

                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert RXD table-----------------------------------------
                                                    hl7_rxd_V2_3 rxd = new hl7_rxd_V2_3();

                                                    rxd.SET_CODE = SetData;

                                                    rxd.RXD_1 = childParts[1].Trim();
                                                    rxd.RXD_2 = childParts[2].Trim();
                                                    rxd.RXD_3 = childParts[3].Trim();
                                                    rxd.RXD_4 = childParts[4].Trim();
                                                    rxd.RXD_5 = childParts[5].Trim();
                                                    rxd.RXD_6 = childParts[6].Trim();
                                                    rxd.RXD_7 = childParts[7].Trim();
                                                    rxd.RXD_8 = childParts[8].Trim();
                                                    rxd.RXD_9 = childParts[9].Trim();
                                                    rxd.RXD_10 = childParts[10].Trim();
                                                    rxd.RXD_11 = childParts[11].Trim();
                                                    rxd.RXD_12 = childParts[12].Trim();
                                                    rxd.RXD_13 = childParts[13].Trim();
                                                    rxd.RXD_14 = childParts[14].Trim();
                                                    rxd.RXD_15 = childParts[15].Trim();
                                                    rxd.RXD_16 = childParts[16].Trim();
                                                    rxd.RXD_17 = childParts[17].Trim();
                                                    rxd.RXD_18 = childParts[18].Trim();
                                                    rxd.RXD_19 = childParts[19].Trim();
                                                    rxd.RXD_20 = childParts[20].Trim();
                                                    rxd.RXD_21 = childParts[21].Trim();
                                                    rxd.RXD_22 = childParts[22].Trim();
                                                    rxd.RXD_23 = childParts[23].Trim();
                                                    rxd.RXD_24 = childParts[24].Trim();
                                                    rxd.RXD_25 = childParts[25].Trim();
                                                    rxd.RXD_26 = childParts[26].Trim();
                                                    rxd.RXD_27 = childParts[27].Trim();
                                                    rxd.RXD_28 = childParts[28].Trim();
                                                    rxd.RXD_29 = childParts[29].Trim();
                                                    rxd.EVEN = EventCd;

                                                    rxd.Add(rxd);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "RXR":
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert RXR table-----------------------------------------
                                                    hl7_rxr_V2_3 rxr = new hl7_rxr_V2_3();

                                                    rxr.SET_CODE = SetData;

                                                    rxr.RXR_1 = childParts[1].Trim();
                                                    rxr.RXR_2 = childParts[2].Trim();
                                                    rxr.RXR_3 = childParts[3].Trim();
                                                    rxr.RXR_4 = childParts[4].Trim();
                                                    //r.RXR_5 = childParts[5].Trim();
                                                    rxr.RXR_5 = "";
                                                    rxr.EVEN = EventCd;

                                                    rxr.Add(rxr);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "NTE": //Notes and comments segment
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert NTE table-----------------------------------------
                                                    hl7_nte_V2_3 nte = new hl7_nte_V2_3();

                                                    nte.SET_CODE = SetData;

                                                    nte.NTE_1 = childParts[1].Trim();
                                                    nte.NTE_2 = childParts[2].Trim();
                                                    nte.NTE_3 = childParts[3].Trim();
                                                    nte.EVEN = EventCd;

                                                    nte.Add(nte);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------

                                                    break;

                                                case "EVN": // Event type
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //--------------------------------------------------insert EVN table-----------------------------------------
                                                    hl7_evn_V2_3 evn = new hl7_evn_V2_3();

                                                    evn.SET_CODE = SetData;

                                                    evn.EVN_1 = childParts[1].Trim();
                                                    evn.EVN_2 = childParts[2].Trim();
                                                    evn.EVN_3 = childParts[3].Trim();
                                                    evn.EVN_4 = childParts[4].Trim();
                                                    evn.EVN_5 = childParts[5].Trim();
                                                    evn.Add(evn);
                                                    //------------------------------------------------------------------------------------------------------------
                                                    //------------------------------------------------------------------------------------------------------------
                                                    break;
                                            }
                                        }
                                    }// Expanding a segment node
                                }

                                // Retrieve some message-type details
                                if (mHL7Message.GetSegmentType(0) == "MSH")
                                {
                                    string[] segDetail = ((string)mHL7Message.SegmentArray[0]).Split('|');
                                    if (segDetail.Length > 7)
                                    {
                                        logs.Writelogfile(" Drug Dispense OPD ID : " + fileID.ToString() + " Message type = " + segDetail[8], " HL7Messges");

                                        string msgType = segDetail[8];
                                        segDetail = msgType.Split('^');
                                        if (segDetail.Length > 1)
                                        {
                                            ActiveFileType = segDetail[1];
                                            ActiveFileType = ActiveFileType.Trim().ToUpper();
                                            logs.Writelogfile(" Drug Dispense OPD ID : " + fileID.ToString() + " Message event-type = " + ActiveFileType, " HL7Messges");
                                        }
                                    }
                                } // TODO display or log unexpected message format, provide a follow-up action
                            }

                            //==================================================================================================
                            //Update Table Drug Dispense IPD for Hosxp Interface
                            hos.UpdateStatusConHISMachine("Y", fileID);
                            //==================================================================================================
                        }

                        #region "Data Insert Values To tb_thanes_middle"

                        hl7_mapping_field_opd map = new hl7_mapping_field_opd();

                        if (map.AddToMiddle(EventCd, fileID.ToString()) == true)
                        {
                            ///////////////////  hos.UpdateStatusConHISMachine(1, fileID);///////////////////////////////////
                            event_code = "C0001";
                            event_message = "[" + th.Prescriptionno + "] : " + "บันทึกข้อมูลเรียบร้อยแล้ว";
                            this.WritelogSystem(true);
                            result = true;
                        }
                        else
                        {
                            event_code = "E0001";
                            event_message = "[" + th.Prescriptionno + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                            this.WritelogSystem(true);

                            result = false;
                        }

                        #endregion "Data Insert Values To tb_thanes_middle"
                    }
                }
            }
            catch (Exception ex)
            {
                logs.Writelogfile(" Drug Dispense OPD ID : " + fileID.ToString() + " Format Error" + ex.ToString(), " HL7Message_Error");

                hos.UpdateStatusConHISMachine("Y", fileID);

                event_code = "E0002";
                event_message = "[" + th.Prescriptionno + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
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
    }
}