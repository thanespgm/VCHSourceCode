using ConHIS.Libary_Class;
using ConHIS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class MedicationPlaningPage : Form
    {
        //variable For GanttChart MedPlan
        private GanttChart ganttChartMedicationPlan;

        private DateTime TimeStart;
        private DateTime TimeStop;

        private string strWard = null;
        private string strPriority = string.Empty;

        private readonly Thaneshopmiddle_ATPM th;
        private readonly master_prescription pres;

        private PnDrugDispense pnDrugDispense;

        private string HnCompare;
        private string TimeCompare;

        public MedicationPlaningPage()
        {
            InitializeComponent();
            th = new Thaneshopmiddle_ATPM();
            pres = new master_prescription();
        }

        private void MedicationPlaningPage_Load(object sender, EventArgs e)
        {
            this.cbWardInfo.Text = "เลือกทั้งหมด";
            //strPriority = "S";
            this.OnloadGanttChartMedPlan();

            splitContainerGantChart.Panel2Collapsed = true;
            pnDrugDispensing.Height = 200;
            pnDrugDispensing.Refresh();
        }

        // fuction get data ward in Hospital
        private void OnloadDataWard()
        {
            try
            {
                DataSet ds = th.GetDataWardInfo();
                this.cbWardInfo.DisplayMember = "f_warddesc";
                this.cbWardInfo.ValueMember = "f_wardcode";
                this.cbWardInfo.DataSource = ds.Tables[0];
                //this.RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Load cbWardInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.CheckState == CheckState.Unchecked)
            {
                this.cbWardInfo.Enabled = true;
                OnloadDataWard();
                if (pnGanttChartMedicationPlan != null)
                    pnGanttChartMedicationPlan.Controls.Clear();
                strWard = cbWardInfo.SelectedValue.ToString();
                OnloadGanttChartMedPlan();
            }
            else
            {
                if (pnGanttChartMedicationPlan != null)
                    pnGanttChartMedicationPlan.Controls.Clear();
                this.cbWardInfo.Enabled = false;
                this.cbWardInfo.Text = "เลือกทั้งหมด";
                strWard = null;
                OnloadGanttChartMedPlan();
            }
        }

        private void OnloadGanttChartMedPlan()
        {
            ganttChartMedicationPlan = new GanttChart();

            TimeStart = pres.GetDateStartMedicationPlanningChart();
            TimeStop = pres.GetDateStartMedicationPlanningChart().AddHours(48);

            ganttChartMedicationPlan.Dock = DockStyle.Fill;
            ganttChartMedicationPlan.AllowChange = false;
            ganttChartMedicationPlan.AllowManualEditBar = false;
            ganttChartMedicationPlan.FromDate = new DateTime(TimeStart.Year, TimeStart.Month, TimeStart.Day, TimeStart.Hour, TimeStart.Minute, TimeStart.Second);
            ganttChartMedicationPlan.ToDate = new DateTime(TimeStop.Year, TimeStop.Month, TimeStop.Day, TimeStop.Hour, TimeStop.Minute, TimeStop.Second);
            pnGanttChartMedicationPlan.Controls.Add(ganttChartMedicationPlan);

            this.LoadGanttChartMedicationPlanning();
        }

        private async void LoadGanttChartMedicationPlanning()
        {
            try
            {
                ganttChartMedicationPlan.MouseMove += new MouseEventHandler(ganttChartMedicationPlan.GanttChart_MouseMove);
                ganttChartMedicationPlan.MouseMove += new MouseEventHandler(ganttChartMedicationPlan_MouseMove);
                ganttChartMedicationPlan.MouseDragged += new MouseEventHandler(ganttChartMedicationPlan.GanttChart_MouseDragged);
                ganttChartMedicationPlan.MouseLeave += new EventHandler(ganttChartMedicationPlan.GanttChart_MouseLeave);
                ganttChartMedicationPlan.BarChanged += new EventHandler(ganttChartMedicationPlan_BarChanged);
                ganttChartMedicationPlan.ContextMenuStrip = ContextMenuGanttChart1;

                //Set Input Data Chart Bar.
                List<BarInformation> lstMedication = new List<BarInformation>();

                // List<Color> ColorList = new List<Color>();

                int itemIndex = 0;

                this.lbItemsAll.Text = "0";
                DataSet ds = new DataSet();
                try
                {
                    ds = pres.GetDisplayGanttChartMedicationPlanData(strWard, strPriority);
                    this.lbItemsAll.Text = ds.Tables[0].Rows.Count.ToString();
                }
                catch (Exception e) { throw new Exception("ปัญหาในการโหลดข้อมูล M_prescription มาสร้างตารางบริหารเวลา " + "\r\n" + e.Message); }

                int seq = 0;

                foreach (DataRow items in ds.Tables[0].Rows)
                {
                    seq++;
                  //  DataSet dsTime = pres.GetDisplayGanttChartMedicationPlanDataDetailBar(items["PatientId"].ToString(), Convert.ToDateTime(items["TakeDate"]).ToString("yyyyMMdd"));
                    DataSet dsTime = pres.GetDisplayGanttChartMedicationPlanDataDetailBar(items["PatientId"].ToString(),null);

                    if (dsTime != null || dsTime.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dttime in dsTime.Tables[0].Rows)
                        {
                            String strTime = string.Empty;
                            if (dttime["Freq_Desc_Detail_Code"].ToString()!= "9999")
                            {
                                strTime = Convert.ToDateTime(dttime["TakeDate"]).ToString("dd-MM-yyyy") + " " + dttime["Freq_Desc_Detail_Code"].ToString().Substring(0, 2) + ":" + dttime["Freq_Desc_Detail_Code"].ToString().Substring(2, 2);
                                lstMedication.Add(new BarInformation(
                                seq.ToString() + " :" + dttime["PatientId"].ToString() + " :" + dttime["PatientName"].ToString() + " ",
                                DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None),
                                DateTime.ParseExact(strTime, "dd-MM-yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None).AddMinutes(30),
                                Color.Teal,
                                Color.Gainsboro,
                                itemIndex
                                ));
                            }
                        }
                    }
                    itemIndex++;
                }

                foreach (BarInformation bar in lstMedication)
                {
                    await Task.Run(()=> ganttChartMedicationPlan.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "เกิดข้อผิดพลาดการโหลดข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ganttChartMedicationPlan_MouseMove(Object sender, MouseEventArgs e)
        {
            List<string> toolTipText = new List<string>();

            if (ganttChartMedicationPlan.MouseOverRowText != null && ganttChartMedicationPlan.MouseOverRowText != "" && ganttChartMedicationPlan.MouseOverRowValue != null)
            {
                object obj = ganttChartMedicationPlan.MouseOverRowValue;
                string typ = obj.GetType().ToString();

                if (typ.IndexOf("barinformation", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    BarInformation val = (BarInformation)ganttChartMedicationPlan.MouseOverRowValue;
                    TimeSpan diff = val.ToTime - val.FromTime;

                    try
                    {
                        string[] PatientName = { };
                        PatientName = val.RowText.Split(':');
                        string takeDate = val.FromTime.ToString("yyyyMMdd");
                        string takeTime = val.FromTime.ToString("HHmm");

                        if(PatientName[1].Trim() != HnCompare || takeTime != TimeCompare)
                        {
                            HnCompare = PatientName[1].Trim();
                            TimeCompare = takeTime;

                            DataSet ds = pres.GetDisplayGanttChartMedicationPlanDataDetailBar(PatientName[1].Trim(), takeDate, takeTime);
                            if (ds != null)
                            {
                                splitContainerGantChart.Panel2Collapsed = false;

                                lbHn.Text = PatientName[1].Trim();
                                lbPatientName.Text = PatientName[2].Trim();
                                lbTakeTime.Text = val.FromTime.ToString("HH:mm tt");

                                lbDispenseItems.Text = ds.Tables[0].Rows.Count.ToString();

                                if (ds.Tables[0].Rows.Count <= 4)
                                    pnDrugDispensing.Height = 200;
                                else
                                    pnDrugDispensing.Height = 300;

                                LoadDrugDispense(ds);
                            }
                        }
                        
                    }
                    catch (Exception ex) { throw new Exception("ปัญหาในการโหลดข้อมูล M_prescription มาสร้างตารางบริหารเวลา " + "\r\n" + ex.Message); }
                }
                else if (string.Equals(typ, "string", StringComparison.OrdinalIgnoreCase))
                {
                    toolTipText.Add(ganttChartMedicationPlan.MouseOverRowValue.ToString());
                }
            }
            else
            {
                //splitContainerGantChart.Panel2Collapsed = true;
                toolTipText.Add("");
            }
            ganttChartMedicationPlan.ToolTipTextTitle = ganttChartMedicationPlan.MouseOverRowText;
            ganttChartMedicationPlan.ToolTipText = toolTipText;
        }

        private void ganttChartMedicationPlan_BarChanged(object sender, EventArgs e)
        {
            //BarInformation b = sender as BarInformation;
            //txtLog.Text += String.Format("\r\n{0} มีการเปลี่ยนแปลง", b.RowText);
        }

        private void cbWardInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnGanttChartMedicationPlan != null)
                pnGanttChartMedicationPlan.Controls.Clear();
            strWard = cbWardInfo.SelectedValue.ToString();
            OnloadGanttChartMedPlan();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            splitContainerGantChart.Panel2Collapsed = true;
        }

        private void LoadDrugDispense(DataSet ds)
        {
            int itemsDrug = 0;
            flowLayoutPanelContent.Controls.Clear();

            foreach (DataRow drug in ds.Tables[0].Rows)
            {
                pnDrugDispense = new PnDrugDispense();
                pnDrugDispense.lSeqNo = (itemsDrug + 1).ToString().PadLeft(2, '0'); ;
                pnDrugDispense.lDrugName = drug["DrugName"].ToString();
                pnDrugDispense.lInstructionDesc = drug["FreePrintItem_Presc1"].ToString() + " " + drug["Freq_Desc_Detail"].ToString();
                pnDrugDispense.lDrugLabel = drug["FreePrintItem_Presc5"].ToString();
                if (drug["NormalStatus"].ToString() == "Normal For(One Day)")
                {
                    pnDrugDispense.PriorityColor = Color.Green;
                }
                else if (drug["NormalStatus"].ToString() == "Normal For(Dose)")
                {
                    pnDrugDispense.PriorityColor = Color.Red;
                }
                else
                {
                    pnDrugDispense.PriorityColor = Color.Blue;
                }
                pnDrugDispense.lPriority = drug["NormalStatus"].ToString();
                
                itemsDrug++;

                pnDrugDispense.Margin = new System.Windows.Forms.Padding(5);
              
                flowLayoutPanelContent.Controls.Add(pnDrugDispense);
            }
        }
    }
}