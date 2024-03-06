using System;
using System.Data;
using System.Text;

namespace ConHIS.Libary_Class
{
    internal class hl7_mapping_field_opd
    {
        //Variable And Objects
        // private readonly Thaneshopmiddle_SUTH th;
        private readonly Thaneshopmiddle_PCMC th;

        private hosxp_conhis_machine_opd hos;

        private string hl7_string;
        private byte[] hl7_data;
        private bool checkError = false;

        private readonly hl7_msh_V2_3 msh;
        private readonly hl7_evn_V2_3 evn;
        private readonly hl7_al1_V2_3 al1;
        private readonly hl7_nte_V2_3 nte;
        private readonly hl7_orc_V2_3 orc;
        private readonly hl7_pid_V2_3 pid;
        private readonly hl7_pv1_V2_3 pv1;
        private readonly hl7_rxd_V2_3 rxd;
        private readonly hl7_rxr_V2_3 rxr;

        private System_logfile logs = new System_logfile();

        public hl7_mapping_field_opd()
        {
            msh = new hl7_msh_V2_3();
            evn = new hl7_evn_V2_3();
            al1 = new hl7_al1_V2_3();
            nte = new hl7_nte_V2_3();
            orc = new hl7_orc_V2_3();
            pid = new hl7_pid_V2_3();
            pv1 = new hl7_pv1_V2_3();
            rxd = new hl7_rxd_V2_3();
            rxr = new hl7_rxr_V2_3();

            //th = new Thaneshopmiddle_SUTH();
            th = new Thaneshopmiddle_PCMC();
            hos = new hosxp_conhis_machine_opd();
        }

        public bool AddToMiddle(string strEVEN, string fileID)
        {
            bool result = false;
            string msaAcknowleds = "";
            string encoder = ('^').ToString() + ('~').ToString() + ('\\').ToString() + ('&').ToString();

            //----- Create  Message Header HL7 Send to BMS-HOSXP
            string mshHeader = "MSH|" + encoder + "|CONHIS|THANES-DEV|Drug Dispense|BMS-HOSxP|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "||ACK|" + fileID + "|P|2.3" + "\r\n";

            try
            {
                if (strEVEN == "ORM")
                {
                    DataSet dsRXD = rxd.SelectRXD(fileID);
                    if (dsRXD.Tables[0].Rows.Count != 0)
                    {
                        th.Seqmax = dsRXD.Tables[0].Rows.Count;

                        for (int i = 0; i < dsRXD.Tables[0].Rows.Count; i++)
                        {
                            //////////////////////////////////////////////////////////////////// [Start ORC] ///////////////////////////////////////////////////////////////
                            DataSet dsORC = orc.SelectORC(fileID);
                            if (dsORC.Tables[0].Rows.Count != 0)
                            {
                                for (int o = 0; o < dsORC.Tables[0].Rows.Count; o++)
                                {
                                    th.Prescriptionno = dsORC.Tables[0].Rows[0]["ORC_2"].ToString();
                                    if (th.Prescriptionno == "" || th.Prescriptionno == null)
                                    {
                                        checkError = true;
                                        throw new Exception("ไม่มีข้อมูล f_prescriptionno");
                                    }

                                    th.En = dsORC.Tables[0].Rows[0]["ORC_3"].ToString();
                                    th.Dispensestatus = Convert.ToDecimal(dsORC.Tables[0].Rows[0]["ORC_5"]);
                                    th.Status = Convert.ToDecimal(dsORC.Tables[0].Rows[0]["ORC_6"]);
                                    // th.Prescriptiondate = dsORC.Tables[0].Rows[0]["ORC_9"].ToString().Substring(0, 8);
                                }
                            }
                            ////////////////////////////////////////////////////////////////// [Stop ORC] ///////////////////////////////////////////////////////////////////
                            ///
                            th.Freetext2 = dsRXD.Tables[0].Rows[i]["RXD_4"].ToString();          //Barcode Recivied Drug Scanner.
                            if (th.Freetext2 == "" || th.Freetext2 == null)
                            {
                                checkError = true;
                                throw new Exception("ไม่มีข้อมูล f_freetext2");
                            }

                            th.Seq = Convert.ToDecimal(dsRXD.Tables[0].Rows[i]["RXD_1"]);

                            if (dsRXD.Tables[0].Rows[i]["RXD_2"].ToString() != "")
                            {
                                string[] childParts = { };
                                string OrderItem = dsRXD.Tables[0].Rows[i]["RXD_2"].ToString();
                                childParts = OrderItem.Split('^');

                                if (childParts.Length >= 2)
                                {
                                    th.Orderitemcode = childParts[0].Trim();
                                    th.Orderitemname = childParts[1].Trim();
                                }
                                else
                                {
                                    th.Orderitemcode = "";
                                    th.Orderitemname = "";
                                }
                            }
                            else
                            {
                                th.Orderitemcode = "";
                                th.Orderitemname = "";
                            }

                            th.Prescriptiondate = dsRXD.Tables[0].Rows[0]["RXD_3"].ToString().Substring(0, 8);

                            if (th.Prescriptiondate == "" || th.Prescriptiondate == null)
                            {
                                //checkError = true;
                                //throw new Exception("ไม่มีข้อมูล f_prescriptiondate");
                            }

                            th.Orderqty = Convert.ToDecimal(dsRXD.Tables[0].Rows[i]["RXD_6"]);
                            if (th.Orderqty == 0)
                            {
                                // checkError = true;
                                // throw new Exception("ข้อมูล f_orderqty = 0");
                            }

                            th.Dosage = Convert.ToDecimal(dsRXD.Tables[0].Rows[i]["RXD_7"]);
                            //if (th.Dosage == 0)
                            //{
                            //    checkError = true;
                            //    throw new Exception("ข้อมูล f_dosage = 0");
                            //}

                            th.Ordercreatedate = dsRXD.Tables[0].Rows[i]["RXD_3"].ToString().Substring(0, 8);

                            if (dsRXD.Tables[0].Rows[i]["RXD_5"].ToString() != "")
                            {
                                string[] childParts = { };
                                string str = dsRXD.Tables[0].Rows[i]["RXD_5"].ToString();
                                childParts = str.Split('^');
                                if (childParts.Length >= 2)
                                {
                                    th.Useracceptby = childParts[1].Trim();
                                }
                                else { th.Useracceptby = ""; }
                            }
                            else
                            {
                                th.Useracceptby = "";
                            }

                            th.Instructioncode = dsRXD.Tables[0].Rows[i]["RXD_8"].ToString();

                            th.Instructiondesc = dsRXD.Tables[0].Rows[i]["RXD_9"].ToString() + dsRXD.Tables[0].Rows[i]["RXD_10"].ToString() + " " + dsRXD.Tables[0].Rows[i]["RXD_11"].ToString() + " " + dsRXD.Tables[0].Rows[i]["RXD_12"].ToString();

                            th.Dosageunit = dsRXD.Tables[0].Rows[i]["RXD_13"].ToString();

                            if (dsRXD.Tables[0].Rows[i]["RXD_14"].ToString() != "")
                            {
                                string[] childParts = { };
                                string str = dsRXD.Tables[0].Rows[i]["RXD_14"].ToString();
                                childParts = str.Split('^');

                                if (childParts.Length >= 2)
                                {
                                    th.Orderunitcode = childParts[0].Trim();
                                    th.Orderunitdesc = childParts[1].Trim();
                                }
                                else
                                {
                                    th.Orderunitcode = "";
                                    th.Orderunitdesc = "";
                                }
                            }
                            else
                            {
                                th.Orderunitcode = "";
                                th.Orderunitdesc = "";
                            }

                            if (dsRXD.Tables[0].Rows[i]["RXD_15"].ToString() != "")
                            {
                                string[] childParts = { };
                                string str = dsRXD.Tables[0].Rows[i]["RXD_15"].ToString();
                                childParts = str.Split('^');

                                if (childParts.Length >= 2)
                                {
                                    th.Frequencycode = childParts[0].Trim();
                                    th.Frequencydesc = childParts[1].Trim();

                                    //if (th.Frequencycode != "")
                                    //{
                                    //    try
                                    //    {
                                    //        tpn_frequency tpn = new tpn_frequency();
                                    //        string strCount = tpn.Select(th.Frequencycode);
                                    //        if (strCount != "" || strCount != null)
                                    //        {
                                    //            th.Count = Convert.ToDecimal(strCount);
                                    //        }
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //        throw new Exception(" เชื่อมต่อตาราง frequency ไม่ได้ :" + ex.ToString());
                                    //    }
                                    //}
                                }
                                else
                                {
                                    th.Frequencycode = "";
                                    th.Frequencydesc = "";

                                    // checkError = true;
                                    //throw new Exception("ไม่มีข้อมูล f_frequencycode ,f_frequencyname");
                                }
                            }
                            else
                            {
                                th.Frequencycode = "";
                                th.Frequencydesc = "";
                                // checkError = true;
                                //throw new Exception("ไม่มีข้อมูล f_frequencycode ,f_frequencyname");
                            }

                            if (dsRXD.Tables[0].Rows[i]["RXD_19"].ToString() != "")
                            {
                                string[] childParts = { };
                                string str = dsRXD.Tables[0].Rows[i]["RXD_19"].ToString();
                                childParts = str.Split('^');
                                if (childParts.Length >= 2)
                                {
                                    th.Doctorcode = childParts[0].Trim();
                                    th.Doctorname = childParts[1].Trim();
                                }
                                else
                                {
                                    th.Doctorcode = "";
                                    th.Doctorname = "";
                                }
                            }
                            else
                            {
                                th.Doctorcode = "";
                                th.Doctorname = "";
                            }

                            th.Freetext3 = dsRXD.Tables[0].Rows[i]["RXD_20"].ToString();

                            th.Prioritydesc = dsRXD.Tables[0].Rows[i]["RXD_24"].ToString();
                            ////if (th.Prioritydesc == "" || th.Prioritydesc == null)
                            //{
                            //    checkError = true;
                            //    throw new Exception("ไม่มีข้อมูล f_prioritydesc");
                            //}

                            //if (th.Prioritydesc != "")
                            //    th.Prioritycode = th.Prioritydesc.Substring(0, 1);
                            //else
                            //{
                            th.Prioritycode = "0";
                            //    checkError = true;
                            //    throw new Exception("ไม่มีข้อมูล f_prioritycode");
                            //}

                            th.Ordertargetdate = dsRXD.Tables[0].Rows[i]["RXD_25"].ToString();

                            th.Ordertargettime = "00:00";

                            th.Ordercreatetime = "00:00:00";

                            th.Durationcode = "1";

                            th.Durationdesc = "1 Day";

                            th.PRN = 0;

                            ///
                            ////////////////////////////////////////////////////////////////// [Start PID]///////////////////////////////////////////////////////////////////
                            DataSet dsPID = pid.SelectPID(fileID);
                            if (dsPID.Tables[0].Rows.Count != 0)
                            {
                                for (int pi = 0; pi < dsPID.Tables[0].Rows.Count; pi++)
                                {
                                    th.Hn = dsPID.Tables[0].Rows[0]["PID_2"].ToString();

                                    th.Patientdob = dsPID.Tables[0].Rows[0]["PID_7"].ToString();

                                    if (dsPID.Tables[0].Rows[0]["PID_8"].ToString() == "M")
                                        th.Sex = 0;
                                    else if (dsPID.Tables[0].Rows[0]["PID_8"].ToString() == "F")
                                        th.Sex = 1;

                                    if (dsPID.Tables[0].Rows[0]["PID_9"].ToString() != "")
                                    {
                                        string[] childParts = { };
                                        string str = dsPID.Tables[0].Rows[0]["PID_9"].ToString();
                                        childParts = str.Split('^');

                                        th.Patientname = childParts[3].Trim() + childParts[1].Trim() + " " + childParts[0].Trim();
                                    }
                                    else
                                    {
                                        th.Patientname = "";
                                    }
                                }
                            }
                            ////////////////////////////////////////////////////////////////// [Stop PID] ///////////////////////////////////////////////////////////////////
                            ///
                            ////////////////////////////////////////////////////////////////// [Start PV1]///////////////////////////////////////////////////////////////////
                            DataSet dsPV1 = pv1.SelectPV1(fileID);
                            if (dsPV1.Tables[0].Rows.Count != 0)
                            {
                                for (int pv = 0; pv < dsPV1.Tables[0].Rows.Count; pv++)
                                {
                                    //if (dsPV1.Tables[0].Rows[0]["PV1_3"].ToString() != "")
                                    //{
                                    //    string str = dsPV1.Tables[0].Rows[0]["PV1_3"].ToString();

                                    //    th.Wardcode = str.Split('-').GetValue(0).ToString().Trim();

                                    //    str = str.Replace('-', '^');

                                    //    th.Warddesc = str.Split('^').GetValue(1).ToString().Trim();

                                    //    th.Roomcode = str.Split('^').GetValue(2).ToString().Trim();

                                    //    th.Bedcode = str.Split('^').GetValue(3).ToString().Trim();
                                    //}
                                    //else
                                    //{
                                    th.Wardcode = "";
                                    th.Warddesc = "";
                                    th.Roomcode = "";
                                    th.Bedcode = "";
                                    //}

                                    //th.En = dsPV1.Tables[0].Rows[0]["PV1_5"].ToString();

                                    if (dsPV1.Tables[0].Rows[0]["PV1_18"].ToString() != "")
                                    {
                                        string[] childParts = { };
                                        string str = dsPV1.Tables[0].Rows[0]["PV1_18"].ToString();
                                        childParts = str.Split('^');

                                        //th.Freetext6 = childParts[1].Trim();
                                    }
                                    else
                                    {
                                        //th.Freetext6 = "";
                                    }
                                }
                            }
                            ////////////////////////////////////////////////////////////////// [Stop PV1] ///////////////////////////////////////////////////////////////////
                            ///
                            ////////////////////////////////////////////////////////////////// [Start AL1]///////////////////////////////////////////////////////////////////
                            DataSet dsAL1 = al1.SelectAL1(fileID);
                            if (dsAL1.Tables[0].Rows.Count != 0)
                            {
                                for (int al = 0; al < dsAL1.Tables[0].Rows.Count; al++)
                                {
                                    th.Freetext4 = dsAL1.Tables[0].Rows[0]["AL1_3"].ToString();
                                }
                            }
                            ////////////////////////////////////////////////////////////////// [Stop AL1] ///////////////////////////////////////////////////////////////////
                            ///
                            ////////////////////////////////////////////////////////////////// [Start RXR]///////////////////////////////////////////////////////////////////
                            DataSet dsRXR = rxr.SelectRXR(fileID, th.Orderitemcode);
                            if (dsRXR.Tables[0].Rows.Count != 0)
                            {
                                for (int r = 0; r < dsRXR.Tables[0].Rows.Count; r++)
                                {
                                    string machineStr = dsRXR.Tables[0].Rows[0]["RXR_3"].ToString();
                                    if (machineStr == "EV54_01")
                                        th.Tomachineno = 1;
                                    else if (machineStr == "EV54_02")
                                        th.Tomachineno = 2;
                                    else
                                        th.Tomachineno = 0;
                                }
                            }
                            ////////////////////////////////////////////////////////////////// [Stop RXR]///////////////////////////////////////////////////////////////////
                            ///

                            /// ***** หมายเหตุ ข้อมูลที่ไม่มีในระบบ hl7
                            ///
                            th.Noteprocessing = "";
                            th.Fromlocationname = "";
                            th.Userorderby = "";
                            th.Orderacceptdate = "";
                            th.Orderaccepttime = "";
                            th.Orderacceptformip = "";
                            th.Itemlotcode = "";
                            th.Itemlotexpire = "";
                            th.Roomdesc = "";
                            th.Beddesc = "";
                            th.Pharmacylocationcode = "";
                            th.Pharmacylocationdesc = "";
                            th.Freetext1 = "";
                            //th.Freetext2 = "";
                            th.Itemidentify = "";
                            th.FrequencyTime = "";
                            th.Dosagedispense = "";
                            th.Comment = "";
                            th.StatusCh = 0;
                            th.Freetext4 = "";
                            th.HeighAlertDrug = 0;
                            th.ReferenceCode = "";
                            ///////////////////////////////////////////////////////////////////[ Data Insert Values To Middle] /////////////////////////////////////////////
                            if (checkError == false)
                            {
                                if (th.InsertDataThanesMiddle() == true)
                                {
                                    rxd.UpdateStatus(fileID, th.Seq.ToString());
                                    rxr.UpdateStatus(fileID, th.Orderitemcode);

                                    //----Create Message Acknowledgment.
                                    if (th.Tomachineno != 0)
                                        msaAcknowleds += "MSA|AA|" + fileID + "|" + th.En + "^" + th.Orderitemcode + "|||" + "\r\n";
                                    result = true;
                                }
                                else
                                {
                                    //----Create Message Acknowledgment.
                                    if (th.Tomachineno != 0)
                                        msaAcknowleds += "MSA|AE|" + fileID + "|FORMAT MESSAGE ERROR|||" + "\r\n";
                                    result = false;
                                }
                            }
                            else
                            {
                                rxd.UpdateStatus(fileID, th.Seq.ToString());
                                rxr.UpdateStatus(fileID, th.Orderitemcode);
                                result = true;
                            }
                            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        }
                    }

                    if (th.Seqmax == th.Seq)
                    {
                        orc.UpdateStatus(fileID);
                        pid.UpdateStatus(fileID);
                        pv1.UpdateStatus(fileID);
                        al1.UpdateStatus(fileID);

                        //----Create Message Acknowledgment.
                        hl7_string = mshHeader + msaAcknowleds;
                        hl7_data = Encoding.ASCII.GetBytes(hl7_string);
                        //hos.InsertToDrugDispenseHosXP(th.En, "ACK", hl7_data, "N", "AA");
                    }
                }
                else if (strEVEN == "ADT")
                {
                }
            }
            catch (Exception ex)
            {
                result = false;

                //----Create Message Acknowledgment.
                msaAcknowleds += "MSA|AE|" + fileID + "|" + ex.ToString() + "|||" + "\r\n";
                hl7_string = mshHeader + msaAcknowleds;
                hl7_data = Encoding.ASCII.GetBytes(hl7_string);
                //hos.InsertToDrugDispenseHosXP(th.En, "ACK", hl7_data, "N", "AE");

                logs.Writelogfile("ID : {" + fileID + "} " + ex.ToString(), " Mapping");
            }
            return result;
        }
    }
}