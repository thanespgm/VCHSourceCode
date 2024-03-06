using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class FullDetailPage : Form
    {
        private int itemstotallist = 0;
        private int itemsAll = 0;
        private string strsearch = "";
        private DataSet ds = null;
        private readonly Connection_sqlserver c = new Connection_sqlserver(Variable.DBlocal);

        //readonly Thaneshopmiddle th = new Thaneshopmiddle();     //Create Ojects Class Thanes Middle Table
        private readonly Thaneshopmiddle_ATPM th = new Thaneshopmiddle_ATPM();     //Create Ojects Class Thanes Middle Table

        public FullDetailPage()
        {
            InitializeComponent();
            this.tmAutoCheck.Enabled = true;
            this.BgwAutoCheck.WorkerReportsProgress = true;
            this.BgwAutoCheck.WorkerSupportsCancellation = true;
        }

        private void FullDetailPage_Load(object sender, EventArgs e)
        {
            this.tmAutoCheck.Start();
            //this.OnloadDataDisplayFullDetail();
        }

        private void FullDetailPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.tmAutoCheck.Stop();
            this.tmAutoCheck.Enabled = false;
            this.Dispose();
        }

        //On load Data DisplayFull Detail
        private void OnloadDataDisplayFullDetail()
        {
            ds = th.GetDispalyDataGridViewFullDetail(strsearch);
            this.itemstotallist = ds.Tables[0].Rows.Count;        //total list prescription
            if (this.itemstotallist != 0)
            {
                this.ds.Tables[0].BeginLoadData();
                this.DgvPrescriptionAll.DataSource = ds.Tables[0];    //DataGridView Binding
                this.ds.Tables[0].EndLoadData();
            }
            this.DgvPrescriptionAll.CurrentCell = null;
            this.DgvPrescriptionAll.ClearSelection();
        }

        //Button Click Auto Search Data On Textbooks
        private void BtnSearchData_Click(object sender, EventArgs e)
        {
            if (this.tbSearchData.Text != "")
            {
                strsearch = this.tbSearchData.Text.Trim();
                this.OnloadDataDisplayFullDetail();
                this.lbAlretsDataShow.Visible = true;
                this.lbAlretsDataShow.Text = "(ผลการค้นหาข้อมูล  " + (this.DgvPrescriptionAll.Rows.Count).ToString() + " รายการ)";
            }
            else
            {
                this.lbAlretsDataShow.Visible = false;
            }
        }

        //KeyPress Auto Search Data On Textbooks
        private void TbSearchData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                strsearch = this.tbSearchData.Text.Trim();
                this.OnloadDataDisplayFullDetail();
                this.lbAlretsDataShow.Visible = true;
                this.lbAlretsDataShow.Text = "(ผลการค้นหาข้อมูล  " + (this.DgvPrescriptionAll.Rows.Count).ToString() + " รายการ)";
            }
            else
            {
                this.lbAlretsDataShow.Visible = false;
            }
        }

        //Button Data Refresh
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.tbSearchData.Text = "";
            strsearch = this.tbSearchData.Text.Trim();
            this.OnloadDataDisplayFullDetail();
            this.lbAlretsDataShow.Visible = false;
        }

        //Timer Automatic Checker Data
        private void TmAutoCheck_Tick(object sender, EventArgs e)
        {
            if (c.ConnStatus())
            {
                this.txtdatabase_status.Text = "สถานะการเชื่อมต่อฐานข้อมูล : เชื่อมต่ออยู่";
                this.txtdatabase_status.ForeColor = Color.Navy;
            }
            else
            {
                this.txtdatabase_status.Text = "สถานะการเชื่อมต่อฐานข้อมูล : หยุดเชื่อมต่อ";
                this.txtdatabase_status.ForeColor = Color.Red;
            }
            if ((itemsAll != Convert.ToInt32(th.ItemsAllDataFull())) && tbSearchData.Text.Length == 0)
            {
                this.itemsAll = Convert.ToInt32(th.ItemsAllDataFull());
                this.txtitemslist.Text = "รายการทั้งหมด " + this.itemsAll.ToString() + " รายการ";
                if (!BgwAutoCheck.IsBusy)
                {
                    this.Updateprocess(0);
                    this.BgwAutoCheck.RunWorkerAsync();
                }
            }
            else
            {
                if (this.BgwAutoCheck.WorkerSupportsCancellation)
                {
                    this.BgwAutoCheck.CancelAsync();
                }
            }
        }

        //Background Worker On load Data
        private void BgwAutoCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break; // TODO: might not be correct. Was : Exit For
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    worker.ReportProgress(i);
                }
            }
        }

        private void BgwAutoCheck_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Updateprocess(e.ProgressPercentage);
        }

        private void BgwAutoCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.tbSearchData.Text = "";
                strsearch = this.tbSearchData.Text.Trim();
                this.OnloadDataDisplayFullDetail();
                this.lbAlretsDataShow.Visible = false;
            }
            else if (e.Error != null)
            {
                this.tbSearchData.Text = "";
                strsearch = this.tbSearchData.Text.Trim();
                this.OnloadDataDisplayFullDetail();
                this.lbAlretsDataShow.Visible = false;
            }
            else
            {
                this.tbSearchData.Text = "";
                strsearch = this.tbSearchData.Text.Trim();
                this.OnloadDataDisplayFullDetail();
                this.lbAlretsDataShow.Visible = false;
            }
            this.Updateprocess(0);
        }

        private void Updateprocess(int percent)
        {
            this.pgb_loaddata.Value = percent;
            this.txtprecents.Text = String.Format(" {0} % ", percent);
            if (percent == 100)
            {
                this.pgb_loaddata.Value = 0;
            }
        }
    }
}