using ConHIS.Libary_Class;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class PrescriptionDetail : Form
    {
        //variable and objects
        private static string prescriptionno = null;

        //variable For GanttChart MedPlan
        private GanttChart ganttChartMedPlan;

        private DateTime TimeStart;
        private DateTime TimeStop;

        private static StreamWriter sw;

        private readonly Thaneshopmiddle_ATPM th;    //Create Objects Class Thanes Middle Table
        private readonly master_prescription pres;
        private readonly System_logfile logs;

        //constructor class
        public PrescriptionDetail()
        {
            InitializeComponent();
            th = new Thaneshopmiddle_ATPM();
            pres = new master_prescription();
            logs = new System_logfile();
        }

        public PrescriptionDetail(string f_prescriptionno)
        {
            InitializeComponent();
            th = new Thaneshopmiddle_ATPM();
            pres = new master_prescription();
            logs = new System_logfile();
            prescriptionno = f_prescriptionno;
        }

        //form event
        private void PrescriptionDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "ข้อมูลรายละเอียดใบสั่งยา เลขที่ : " + prescriptionno;
                this.OnloadDataPatient(prescriptionno);
                this.OnloadGanttChartMedPlan(prescriptionno);
            }
            catch (Exception ex)
            {
                logs.Writelogfile(ex.Message, " ConHIS_PrescriptionDetail");
            }
        }

        private void PrescriptionDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ = new PrescriptionPage
            {
                Opacity = 100
            };
        }

        private void OnloadGanttChartMedPlan(string prescriptionno)
        {
            try
            {
                TimeStart = pres.GetDateStartMedPlanChart(prescriptionno);
                TimeStop = pres.GetDateStartMedPlanChart(prescriptionno).AddHours(28);

                ganttChartMedPlan = new GanttChart();
                ganttChartMedPlan.Dock = DockStyle.Fill;
                ganttChartMedPlan.AllowChange = false;
                ganttChartMedPlan.AllowManualEditBar = false;
                ganttChartMedPlan.FromDate = new DateTime(TimeStart.Year, TimeStart.Month, TimeStart.Day, TimeStart.Hour, TimeStart.Minute, TimeStart.Second);
                ganttChartMedPlan.ToDate = new DateTime(TimeStop.Year, TimeStop.Month, TimeStop.Day, TimeStop.Hour, TimeStop.Minute, TimeStop.Second);
                pnMedPlanGanttChart.Controls.Add(ganttChartMedPlan);

                this.LoadGanttChartMedPlan();
            }
            catch (Exception e) { throw new Exception("ปัญหาการโหลดข้อมูลเริ่มต้นมาแสดงกราฟ :" + e.Message); }
        }

        private void LoadGanttChartMedPlan()
        {
            try
            {
                ganttChartMedPlan.MouseMove += new MouseEventHandler(ganttChartMedPlan.GanttChart_MouseMove);
                ganttChartMedPlan.MouseMove += new MouseEventHandler(ganttChartMedPlan_MouseMove);
                ganttChartMedPlan.MouseDragged += new MouseEventHandler(ganttChartMedPlan.GanttChart_MouseDragged);
                ganttChartMedPlan.MouseLeave += new EventHandler(ganttChartMedPlan.GanttChart_MouseLeave);
                ganttChartMedPlan.BarChanged += new EventHandler(ganttChartMedPlan_BarChanged);
                ganttChartMedPlan.ContextMenuStrip = ContextMenuGanttChart1;

                //Set Input Data Chart Bar.
                List<BarInformation> lstMedication = new List<BarInformation>();

                // List<Color> ColorList = new List<Color>();

                int itemIndex = 0;

                DataSet ds = pres.GetDisplayDataGridViewFullDetail(prescriptionno);

                int seq = 0;

                foreach (DataRow items in ds.Tables[0].Rows)
                {
                    String strTime = Convert.ToDateTime(items["TakeDate"]).ToString("dd-MM-yyyy") + " " + items["Freq_Desc_Detail_Code"].ToString().Substring(0, 2) + ":" + items["Freq_Desc_Detail_Code"].ToString().Substring(2, 2);
                    seq++;

                    if (items["NormalStatus"].ToString() == "Continue")

                        lstMedication.Add(new BarInformation(
                            seq.ToString() + " : " + items["SeqNo"] + " :" + items["DrugName"].ToString() + " ",
                            DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None),
                            DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None).AddMinutes(30),
                            Color.SeaGreen,
                            Color.Gainsboro,
                            itemIndex
                            ));
                    else
                    {
                        if (items["NormalStatus"].ToString() == "For(One Day)")
                        {
                            lstMedication.Add(new BarInformation(
                                seq.ToString() + " : " + items["SeqNo"] + " :" + items["DrugName"].ToString() + " ",
                                DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None),
                                DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None).AddMinutes(30),
                                Color.Orange,
                                Color.Gainsboro,
                                itemIndex
                                ));
                        }
                        else
                        {
                            lstMedication.Add(new BarInformation(
                               seq.ToString() + " : " + items["SeqNo"] + " :" + items["DrugName"].ToString() + " ",
                               DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None),
                               DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None).AddMinutes(30),
                               Color.Red,
                               Color.Gainsboro,
                               itemIndex
                               ));
                        }
                    }
                    itemIndex++;
                }
                foreach (BarInformation bar in lstMedication)
                {
                    ganttChartMedPlan.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "เกิดข้อผิดพลาดการโหลดข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ganttChartMedPlan_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();

            if (ganttChartMedPlan.MouseOverRowText != null && ganttChartMedPlan.MouseOverRowText != "" && ganttChartMedPlan.MouseOverRowValue != null)
            {
                object obj = ganttChartMedPlan.MouseOverRowValue;
                string typ = obj.GetType().ToString();

                if (typ.IndexOf("barinformation", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    BarInformation val = (BarInformation)ganttChartMedPlan.MouseOverRowValue;
                    TimeSpan diff = val.ToTime - val.FromTime;

                    try
                    {
                        string[] drugname = { };
                        drugname = val.RowText.Split(':');
                        string takeDate = val.FromTime.ToString("yyyyMMdd");
                        string takeTime = val.FromTime.ToString("HHmm");
                        DataSet ds = pres.GetDisplayDataToolTipDetail(prescriptionno, Convert.ToDecimal(drugname[1].Trim()), drugname[2].Trim(), takeDate, takeTime);
                        if (ds != null)
                        {
                            toolTipText.Add("\r\n");
                            toolTipText.Add("เวลาให้ยา : " + val.FromTime.ToString("HH:mm tt"));
                            toolTipText.Add(ds.Tables[0].Rows[0]["FreePrintItem_Presc1"].ToString());
                            toolTipText.Add(ds.Tables[0].Rows[0]["Freq_Desc_Detail"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                else if (string.Equals(typ, "string", StringComparison.OrdinalIgnoreCase))
                {
                    toolTipText.Add(ganttChartMedPlan.MouseOverRowValue.ToString());
                }
            }
            else
            {
                toolTipText.Add("");
            }
            ganttChartMedPlan.ToolTipTextTitle = ganttChartMedPlan.MouseOverRowText;
            ganttChartMedPlan.ToolTipText = toolTipText;
        }

        private void ganttChartMedPlan_BarChanged(object sender, EventArgs e)
        {
            //BarInformation b = sender as BarInformation;
            //txtLog.Text += String.Format("\r\n{0} มีการเปลี่ยนแปลง", b.RowText);
        }

        //function get data prescription by prescription_no
        private void OnloadDataPatient(string prescriptionno)
        {
            if ((prescriptionno != null) || (prescriptionno != ""))
            {
                //to Patient Data
                DataSet ds = th.GetDispalyDataPatient(prescriptionno);
                this.DisplayDataTextBoxs(ds);

                //to DataGridView
                DataSet dsGrid = th.GetDataDisplayDetailPrescription(prescriptionno);
                this.DisplayDataGridView(dsGrid);
            }
        }

        private bool DisplayDataTextBoxs(DataSet ds)
        {
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lb_Prescriptionno.Text = row["f_prescriptionno"].ToString().Trim();
                    lb_PriorityDesc.Text = row["f_prioritydesc"].ToString().Trim();
                    lb_Lastmodified.Text = row["f_lastmodified"].ToString().Trim();
                    lb_Hn.Text = row["f_hn"].ToString().Trim();
                    lb_Vn.Text = row["f_vn"].ToString().Trim();
                    lb_En.Text = row["f_an"].ToString().Trim();
                    lb_Patientname.Text = row["f_patientname"].ToString().Trim();

                    switch (row["f_sex"].ToString().Trim())
                    {
                        case "M":
                            lb_Sex.Text = "ชาย";
                            break;

                        case "F":
                            lb_Sex.Text = "หญิง";
                            break;

                        default:
                            lb_Sex.Text = "ไม่ระบุเพศ";
                            break;
                    }

                    lb_DOB.Text = Convert.ToDateTime(row["f_patientdob"]).ToString("dd/MM/yyyy") + " (" + Convert.ToDateTime(row["f_patientdob"]).AddYears(543).ToString("yyyy") + ")";
                    int this_age = DateTime.Now.Year - Convert.ToDateTime(row["f_patientdob"]).Year;
                    lb_Age.Text = this_age.ToString();
                    lb_PhramacyLocationDesc.Text = row["f_pharmacylocationdesc"].ToString().Trim();
                    lb_Ward.Text = row["f_warddesc"].ToString().Trim();
                    lb_Room.Text = row["f_roomdesc"].ToString().Trim();
                    lb_Bed.Text = row["f_bedcode"].ToString().Trim();
                    lb_PatientEpisodedate.Text = "-ไม่มีการระบุ-";
                    lb_Prescriptiondate.Text = row["f_prescriptiondate"].ToString().Substring(0, 4) + "/" + row["f_prescriptiondate"].ToString().Substring(4, 2) + "/" + row["f_prescriptiondate"].ToString().Substring(6, 2);
                    lb_DoctorName.Text = row["f_userorderby"].ToString().Trim();
                    lb_OrderCreateDateTime.Text = Convert.ToDateTime(row["f_ordercreatedate"]).ToString("dd-MM-yyyy HH:mm:ss");
                    lb_OrderAcceptDateTime.Text = Convert.ToDateTime(row["f_orderacceptdate"]).ToString("dd-MM-yyyy HH:mm:ss");
                    lb_OrderAcceptFromIp.Text = row["f_orderacceptfromip"].ToString().Trim();
                    lb_UserAceeptBy.Text = row["f_useracceptby"].ToString().Trim();
                }
            }
            return true;
        }

        private bool DisplayDataGridView(DataSet ds)
        {
            if (ds != null)
            {
                this.dgvDrugOrder.Rows.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    bool selected = false;
                    string t_seqno = row["f_seq"].ToString().Trim();
                    string t_prioritydesc = row["f_prioritydesc"].ToString().Trim();
                    string t_orderitemscode = row["f_orderitemcode"].ToString().Trim();
                    string t_orderitemsname = row["f_orderitemname"].ToString().Trim();
                    string t_orderqty = row["f_orderqty"].ToString().Trim();
                    string t_orderunitdesc = row["f_orderunitdesc"].ToString().Trim();
                    string t_ordertargetdate = row["f_ordertargetdate"].ToString();
                    //for ATPM
                    string[] childFreqDescription = { };
                    childFreqDescription = row["f_frequencydesc"].ToString().Split('_');
                    string t_instructiondesc = row["f_instructiondesc"].ToString() + " " + row["f_dosage"].ToString() + " " + row["f_dosageunit"].ToString() + "\r\n" + childFreqDescription[1];
                    string t_druglabelname = row["drug_label_name"].ToString().Trim();
                    string t_noteprocessing = row["f_comment"].ToString().Trim();
                    string t_pregcat = row["preg_cat"].ToString().Trim();
                    string t_prnindication = row["prn_indication"].ToString().Trim();
                    int t_tomachineno = Convert.ToInt16(row["f_tomachineno"]);
                    string t_present;
                    switch (t_tomachineno)
                    {
                        case 0:
                            t_present = "ชั้นยา";
                            break;

                        case 1:
                            t_present = "หุ่นยนต์จัดยาอัตโนมัติ";
                            break;

                        case 2:
                            t_present = "หุ่นยนต์จัดยาอัตโนมัติ";
                            break;

                        default:
                            t_present = "ชั้นยา";
                            break;
                    }
                    string t_orderadress = row["f_binlocation"].ToString().Trim();
                    int t_dispensestatus = Convert.ToInt16(row["f_dispensestatus"]);
                    int t_status = Convert.ToInt16(row["f_status"]);
                    string t_statusorder;
                    switch (t_dispensestatus)
                    {
                        case 0:
                            t_statusorder = "รอส่งข้อมูล";
                            break;

                        case 1:
                            t_statusorder = "ส่งข้อมูลแล้ว";
                            break;

                        default:
                            t_statusorder = "รอส่งข้อมูล";
                            break;
                    }

                    string t_statuspres;
                    switch (t_status)
                    {
                        case 0:
                            t_statuspres = "รอจัดยา";
                            break;

                        case 1:
                            t_statuspres = "จัดยาเรียบร้อย";
                            break;

                        case 2:
                            t_statuspres = "ยกเลิกการจัดยา";
                            break;

                        default:
                            t_statuspres = "รอจัดยา";
                            break;
                    }
                    string t_lastmodified = (Convert.ToDateTime(row["f_lastmodified"])).ToString("yyyy-MM-dd HH:mm:ss");

                    dgvDrugOrder.Rows.Add(selected, t_seqno, t_prioritydesc, t_orderitemscode, t_orderitemsname, t_orderqty, t_orderunitdesc, t_ordertargetdate, t_instructiondesc, t_druglabelname, t_noteprocessing, t_pregcat, t_prnindication, t_present, t_orderadress, t_statusorder, t_statuspres, t_lastmodified);
                }

                dgvDrugOrder.CurrentCell = null;
                dgvDrugOrder.ClearSelection();
            }
            return true;
        }

        private void SaveImageToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            Control chart = null;
            if (menuItem != null)
            {
                ContextMenuStrip calendarMenu = menuItem.Owner as ContextMenuStrip;

                if (calendarMenu != null)
                {
                    chart = calendarMenu.SourceControl;
                }
            }
            SaveImage(chart);
        }

        private void SaveImage(Control control)
        {
            GanttChart gantt = control as GanttChart;
            string filePath = Interaction.InputBox("Where to save the file?", "Save image", "C:\\Users\\sakda\\Documents\\ConHIS_IPD\\GanttCharttMedPlan.jpg");
            if (File.Exists(filePath))
                sw = File.AppendText(filePath);
            else
                sw = File.CreateText(filePath);
            if (filePath.Length == 0)
                return;
            gantt.SaveImage(filePath);
            Interaction.MsgBox("Picture saved", MsgBoxStyle.Information);
        }

     
    }
}