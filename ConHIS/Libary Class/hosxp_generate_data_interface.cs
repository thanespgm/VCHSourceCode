using System;
using System.Data;

namespace ConHIS.Libary_Class
{
    internal class Hosxp_generate_data_interface
    {
        //Variable And Objects
        private readonly Thaneshopmiddle th = new Thaneshopmiddle();

        private readonly Hosxp_opd_pres_machine hos;

        //int itemsComprae = 0;

        private DataSet opd = null;

        private string event_code;
        private string event_message;

        //Constructor And Abstract Class
        public Hosxp_generate_data_interface()
        {
            hos = new Hosxp_opd_pres_machine(Variable.ServerDBType);
        }

        //Fuction for Interface Data opd_pres_machine To Thanes Middle Table
        public bool InterfaceHosXP(bool enable, string hn)
        {
            bool result = false;
            try
            {
                if (enable == true)
                {
                    //int itemsGetHosXP = Convert.ToInt16(hos.GetItemsDataOPDPresMachine ("wait",hn, "1"));
                    //if (itemsComprae != itemsGetHosXP)
                    //{
                    //   itemsComprae = itemsGetHosXP;

                    event_code = "F00IN";
                    event_message = "[" + th.PrescriptonNo + "] : " + "GetDataOPD Hn :" + hn.ToString();
                    this.WritelogSystem(true);

                    opd = hos.GetDataOPDPresMachine("wait", hn, "1");

                    if (opd.Tables[0].Rows.Count != 0)
                    {
                        int itemsAll = opd.Tables[0].Rows.Count;

                        for (int i = 0; i < itemsAll; i++)
                        {
                            //-------------------------------------------Referrence format Middle Table for BDMS------------------------------------------

                            th.PrescriptonNo = DateTime.Now.ToString("yyMMdd") + opd.Tables[0].Rows[i]["hn"].ToString().Trim(); ;
                            th.Seq = (i + 1);
                            th.SeqMax = itemsAll;
                            th.PrescriptionDate = DateTime.Now.ToString("yyyyMMdd");
                            th.Hn = opd.Tables[0].Rows[i]["hn"].ToString().Trim();
                            th.En = opd.Tables[0].Rows[i]["vn"].ToString().Trim();
                            th.PatientName = opd.Tables[0].Rows[i]["pname"].ToString().Trim() + opd.Tables[0].Rows[i]["fname"].ToString().Trim() + "  " + opd.Tables[0].Rows[i]["lname"].ToString().Trim();
                            th.Sex = 3;
                            //th.PatientEpisodeDate = "";
                            th.PriorityCode = "H";
                            th.PriorityDesc = "Home-Med";
                            th.OrderTargetDate = DateTime.Now.ToString("yyyyMMdd");
                            th.OrderTargetTime = DateTime.Now.ToString("HH:mm:sstt");
                            th.OrderCreateDate = DateTime.Now.ToString("yyyyMMdd");
                            th.OrderCreateTime = DateTime.Now.ToString("HH:mm:sstt");
                            th.OrderItemCode = opd.Tables[0].Rows[i]["icode"].ToString().Trim();
                            th.OrderItemName = opd.Tables[0].Rows[i]["dname"].ToString().Trim();
                            th.OrderQty = Convert.ToDecimal(opd.Tables[0].Rows[i]["qty"]);
                            th.OrderUnitCode = opd.Tables[0].Rows[i]["usage_unit_code"].ToString().Trim();
                            th.OrderUnitDesc = opd.Tables[0].Rows[i]["usage_unit_name"].ToString().Trim();
                            th.InstructionCode = "Take";
                            th.InstructionDesc = "";
                            th.Dosage = 0;
                            th.DosageUnit = "999";
                            th.FrequencyCode = "ConHIS";
                            th.FrequencyDesc = "";
                            th.DurationCode = "0";
                            th.DurationDesc = "";
                            th.NoteProcessing = "";
                            th.FromLocationName = "Pharmacy OPD Department";
                            th.UserOrderBy = "";
                            th.UserAcceptBy = opd.Tables[0].Rows[i]["modify_staff"].ToString().Trim();
                            th.OrderAcceptDate = DateTime.Now.ToString("yyyyMMdd");
                            th.OrderAcceptTime = DateTime.Now.ToString("HH:mm:sstt");
                            th.OrderAcceptFromIP = opd.Tables[0].Rows[i]["modify_computer"].ToString().Trim();
                            th.PatientDOB = Convert.ToDateTime(opd.Tables[0].Rows[i]["patientdob"]).ToString("yyyy-MM-dd");
                            th.ItemLotCode = "";
                            th.ItemLotExpire = "";
                            th.DoctorCode = opd.Tables[0].Rows[i]["doctor_code"].ToString().Trim();
                            th.DoctorName = opd.Tables[0].Rows[i]["doctor_name"].ToString().Trim();
                            th.WardCode = "OPD";
                            th.WardDesc = "OPD";
                            th.RoomCode = "OPD";
                            th.RoomDesc = "OPD";
                            th.BedCode = "OPD";
                            th.BedDesc = "OPD";
                            th.PharmacyLocationCode = opd.Tables[0].Rows[i]["depcode"].ToString().Trim();
                            th.PharmacyLocationDesc = "Pharmacy OPD Department [" + opd.Tables[0].Rows[i]["depcode"].ToString().Trim() + "]";
                            th.Freetext1 = "";
                            th.Freetext2 = opd.Tables[0].Rows[i]["opd_presc_machine_id"].ToString().Trim();
                            th.ItemIdentify = "";
                            //------------------------------Processing To Machine Locations-----------------------------------------
                            int to_machineno = Convert.ToInt16(opd.Tables[0].Rows[i]["tomachineno"].ToString().Trim());
                            if (to_machineno != 0)
                            {
                                if ((th.PharmacyLocationCode == "084") || (th.PharmacyLocationCode == "187"))
                                {
                                    th.ToMachineNo = 1;
                                }
                                else
                                {
                                    th.ToMachineNo = 2;
                                }
                            }
                            else
                            {
                                th.ToMachineNo = 0;
                            }
                            // th.ToMachineNo = Convert.ToInt16(opd.Tables[0].Rows[i]["tomachineno"].ToString().Trim());
                            //-------------------------------------------------------------------------------------------------------
                            th.DispenseStatus = Convert.ToDecimal(opd.Tables[0].Rows[i]["dispensstatus"].ToString().Trim());
                            th.Status = 0;
                            th.LastModified = Convert.ToDateTime(opd.Tables[0].Rows[i]["modify_datetime"]);
                            th.PRN = 0;
                            th.FrequencyTime = "0";
                            th.Language = 0;
                            th.DosageDispense = "0";
                            th.Comment = "";
                            th.StatusCh = 0;
                            th.Freetext3 = "";
                            th.Freetext4 = "";
                            th.HeighAlertDrug = 0;
                            th.ReferenceCode = opd.Tables[0].Rows[i]["opd_presc_machine_id"].ToString().Trim();

                            if (Variable.referrenceCode != th.ReferenceCode)
                            {
                                if (Convert.ToInt16(th.CheckItemsDataThanesMiddle(th.ReferenceCode)) == 0)
                                {
                                    //hos.UpdateDispenseStatusOPDPresMachine(th.ReferenceCode, "1");

                                    Variable.referrenceCode = th.ReferenceCode;

                                    if (th.InsertDataThanesMiddle() == true)
                                    {
                                        event_code = "C0001";
                                        event_message = "[" + th.PrescriptonNo + "] : " + "บันทึกข้อมูลเรียบร้อยแล้ว";
                                        this.WritelogSystem(true);

                                        result = true;
                                    }
                                    else
                                    {
                                        event_code = "E0001";
                                        event_message = "[" + th.PrescriptonNo + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                                        this.WritelogSystem(true);

                                        result = false;
                                    }
                                }
                                else
                                {
                                    //if (hos.UpdateDispenseStatusOPDPresMachine(th.ReferenceCode, "1") == true)
                                    //{
                                    event_code = "C0002";
                                    event_message = "[" + th.PrescriptonNo + "] : " + "มีข้อมูลซ้ำในระบบ อัพเดท";
                                    this.WritelogSystem(true);

                                    result = true;
                                    //}
                                }
                            }
                        }
                    }
                }
                // }
            }
            catch
            {
                //MessageBox.Show(ex.Message.ToString() + "{" + th.PrescriptonNo + "}", "InsertTo");
                //event_code = "E0002";
                //event_message = "[" + th.PrescriptonNo + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                //this.WritelogSystem(true);
            }
            finally
            {
                //Variable.referrenceCode = th.GetMaxReferrenceCode().ToString();
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
    }
}