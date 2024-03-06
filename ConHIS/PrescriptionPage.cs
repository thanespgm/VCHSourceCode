using ConHIS.Libary_Class;
using ConHIS.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class PrescriptionPage : Form
    {
        private readonly ArrayList r_prescriptionno = new ArrayList();
        private readonly ArrayList r_frequenTimeOrder = new ArrayList();

        private readonly Thaneshopmiddle_ATPM th = new Thaneshopmiddle_ATPM();
        private readonly master_prescription pres = new master_prescription();   //M_Prescription

        private DataSet dsTogrid = null;

        private bool enableload = false;

        private int istep = 0;

        private int itemsall = 0;

        private int itemscancel = 0;

        private int itemsCompare = 0;

        private int itemscomplete = 0;

        //Variable are used to compare the differences in the number of prescriptions at each time.
        private int itemsSearchCompare = 0;

        //Variable are used to compare the differences in the number of prescriptions at each time.
        private int itemswait = 0;

        private string statusTabPage = "all";

        //Variable and objects
        private string strSearch = null;    //Variable Search Prescription Data

        private string strSerachSelected = null;

        private string strWard = null;
        private string strPriorty = null;
        private string strMachineNo = null;
        private string strStatusType = "all";

        private string strGroupBy = null;
        private int seqno = 0;
        //Variable Enable Auto load
        //Create Ojects Class Thanes Middle Table

        public PrescriptionPage()
        {
            InitializeComponent();
            this.BgwOnload.WorkerReportsProgress = true;
            this.BgwOnload.WorkerSupportsCancellation = true;
        }

        private void BgwOnload_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            if (dsTogrid != null)
            {
                int icount = 0;
                int c = dsTogrid.Tables[0].Rows.Count;
                if (this.enableload == true)
                {
                    icount = istep;
                }
                else if (this.enableload == false)
                {
                    istep = 1;
                    switch (statusTabPage)
                    {
                        case "all":
                            this.DgvPrescriptionAll.Rows.Clear();
                            break;

                        case "wait":
                            this.DgvPrescriptionWait.Rows.Clear();
                            break;

                        case "complete":
                            this.DgvPrescriptionComplete.Rows.Clear();
                            break;

                        case "cancel":
                            this.DgvPrescriptionCancel.Rows.Clear();
                            break;
                    }
                }
                for (int i = icount; i < c; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        //Progress Bar Control
                        int a = (int)(((double)i / (double)c) * 100);
                        worker.ReportProgress(a);

                        istep++;
                    }
                }
            }
        }

        //function background worker onload Prescription Data to datagrid view
        private void BgwOnload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.UpdateprocessImport(e.ProgressPercentage);
        }

        private void BgwOnload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
                this.txt_overall.Text = "ยกเลิกการอ่านข้อมูล";
            else if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else
            {
                this.txt_overall.Text = "เสร็จสมบูรณ์";
                switch (statusTabPage)
                {
                    case "all":
                        this.DgvPrescriptionAll.CurrentCell = null;
                        this.DgvPrescriptionAll.ClearSelection();
                        break;

                    case "wait":
                        this.DgvPrescriptionWait.CurrentCell = null;
                        this.DgvPrescriptionWait.ClearSelection();
                        break;

                    case "complete":
                        this.DgvPrescriptionComplete.CurrentCell = null;
                        this.DgvPrescriptionComplete.ClearSelection();
                        break;

                    case "cancel":
                        this.DgvPrescriptionCancel.CurrentCell = null;
                        this.DgvPrescriptionCancel.ClearSelection();
                        break;
                }
            }
        }

        //function cancel prescription data for management
        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[1].Value.ToString();
                    th.RowID = row.Cells[18].Value.ToString();
                    th.Status = 2;
                    string drugcode = row.Cells[8].Value.ToString();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, null,2,1);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
           // this.RefreshGrid();
        }

        //function recount prescription data for management
        private void BtnRecountOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[1].Value.ToString();
                    th.RowID = row.Cells[16].Value.ToString();
                    th.Status = 0;
                    th.UpdateStatusDataThanesMiddle();
                    string drugcode = row.Cells[6].Value.ToString();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, null, 0,0);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
           // this.RefreshGrid();
        }

        //function restore prescription data for management
        private void BtnRestoreOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
            {
                _ = new DataGridViewCheckBoxCell();
                DataGridViewCheckBoxCell chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[1].Value.ToString();
                    th.RowID = row.Cells[16].Value.ToString();
                    th.Status = 1;
                    string drugcode = row.Cells[6].Value.ToString();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, null, 0,0);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
            //this.RefreshGrid();
        }

        private void BtnSearchData_Click(object sender, EventArgs e)
        {
            if ((this.tbSearchData.Text != null) || (this.tbSearchData.Text != ""))
            {
                this.enableload = false;
                this.strSearch = this.tbSearchData.Text.Trim();
                this.OnloadDataThanesMiddle(false, statusTabPage);
            }
            else
            {
                this.enableload = true;
            }
        }

        //function all selected data for managenement
        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            seqno = 0;
            r_frequenTimeOrder.Clear();

            switch (this.BtnSelectAll.Text)
            {
                case "เลือกทั้งหมด":
                    foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
                    {
                        DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                        chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                        if (chk_select.Selected == false)
                        {
                            row.Cells[0].Value = true;
                            r_frequenTimeOrder.Add(row.Cells[18].Value.ToString());
                        }
                    }
                    this.BtnSelectAll.Text = "ไม่เลือกทั้งหมด";
                    this.BtnSelectAll.ForeColor = Color.Red;
                    break;

                case "ไม่เลือกทั้งหมด":
                    foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
                    {
                        DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                        chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                        if (chk_select.Selected == false)
                        {
                            row.Cells[0].Value = false;
                        }
                    }
                    this.BtnSelectAll.Text = "เลือกทั้งหมด";
                    this.BtnSelectAll.ForeColor = Color.Blue;
                    break;
            }

            if (r_frequenTimeOrder.Count != 0)
                this.OnloadDataFrequencyTimeSelected();
            else
                this.dgvFrequencyTime.Rows.Clear();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.CheckState == CheckState.Unchecked)
            {
                this.cbWardInfo.Enabled = true;
                OnloadDataWard();
                strWard = cbWardInfo.SelectedValue.ToString();
            }
            else
            {
                this.cbWardInfo.Enabled = false;
                this.cbWardInfo.Text = "เลือกทั้งหมด";
                strWard = null;
                this.RefreshGrid();
            }
        }

        //gatagridview cell mouse click event
        private void DgvPrescriptionAll_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.DgvPrescriptionAll.Rows.Count != 0)
            {
                if (e.ColumnIndex == this.DgvPrescriptionAll.Columns[0].Index)
                {
                    r_prescriptionno.Clear();

                    foreach (DataGridViewRow row in this.DgvPrescriptionAll.Rows)
                    {
                        if (row.Cells[0].Selected)
                        {
                            if (!Convert.ToBoolean(row.Cells[0].Value) || row.Cells[0].Value == null)
                                row.Cells[0].Value = true;
                            else
                                row.Cells[0].Value = false;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            row.Cells[0].Value = true;
                            row.Cells[1].Style.BackColor = Color.LightBlue;
                            row.Cells[2].Style.BackColor = Color.LightBlue;
                            row.Cells[3].Style.BackColor = Color.LightBlue;
                            row.Cells[4].Style.BackColor = Color.LightBlue;
                            row.Cells[5].Style.BackColor = Color.LightBlue;
                            row.Cells[6].Style.BackColor = Color.LightBlue;
                            row.Cells[7].Style.BackColor = Color.LightBlue;
                            row.Cells[8].Style.BackColor = Color.LightBlue;
                            r_prescriptionno.Add(row.Cells[4].Value.ToString().Trim());
                        }
                        else
                        {
                            switch (row.Cells[9].Value.ToString())
                            {
                                case "0":
                                    row.Cells[1].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[2].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[3].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[4].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[5].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[6].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[7].Style.BackColor = Color.WhiteSmoke;
                                    row.Cells[8].Style.BackColor = Color.WhiteSmoke;
                                    break;

                                case "1":
                                     row.Cells[1].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[2].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[3].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[4].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[5].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[6].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[7].Style.BackColor = Color.DarkSeaGreen;
                                     row.Cells[8].Style.BackColor = Color.DarkSeaGreen;
                                    break;
                                case "2":
                                     row.Cells[1].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[2].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[3].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[4].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[5].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[6].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[7].Style.BackColor = Color.DarkSalmon;
                                     row.Cells[8].Style.BackColor = Color.DarkSalmon;
                                    break;
                            }

                            r_prescriptionno.Remove(row.Cells[4].Value.ToString().Trim());
                        }
                    }

                    if (r_prescriptionno.Count != 0)
                    {
                        strStatusType = "all";
                        this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
                    }
                    else
                    {
                        this.dgvPrescriptionSelected.Rows.Clear();
                    }
                }
                else if (e.ColumnIndex == this.DgvPrescriptionAll.Columns[1].Index)   // Prescription Cancel
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionAll.Rows[DgvPrescriptionAll.CurrentRow.Index].Cells[1];

                    th.PrescriptionNo = this.DgvPrescriptionAll.Rows[this.DgvPrescriptionAll.CurrentRow.Index].Cells[4].Value.ToString().Trim();
                    th.Status = 2;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 2, 1);
                    this.RefreshGrid();
                }
                else if (e.ColumnIndex == this.DgvPrescriptionAll.Columns[2].Index)   // Prescription Reset
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionAll.Rows[DgvPrescriptionAll.CurrentRow.Index].Cells[2];


                    th.PrescriptionNo = this.DgvPrescriptionAll.Rows[this.DgvPrescriptionAll.CurrentRow.Index].Cells[4].Value.ToString().Trim();
                    th.Status = 0;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 0, 0);
                    this.RefreshGrid();
                }
                else if (e.ColumnIndex == this.DgvPrescriptionAll.Columns[3].Index)  // Prescription Detail
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionAll.Rows[DgvPrescriptionAll.CurrentRow.Index].Cells[3];
                    this.ShowPrescriptionDetail(this.DgvPrescriptionAll.Rows[this.DgvPrescriptionAll.CurrentRow.Index].Cells[4].Value.ToString().Trim());
                }
            }
        }

        private void DgvPrescriptionCancel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.DgvPrescriptionCancel.Rows.Count != 0)
            {
                if (e.ColumnIndex == this.DgvPrescriptionCancel.Columns[0].Index)
                {
                    r_prescriptionno.Clear();

                    foreach (DataGridViewRow row in this.DgvPrescriptionCancel.Rows)
                    {
                        if (row.Cells[0].Selected)
                        {
                            if (!Convert.ToBoolean(row.Cells[0].Value) || row.Cells[0].Value == null)
                                row.Cells[0].Value = true;
                            else
                                row.Cells[0].Value = false;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            row.Cells[0].Value = true;
                            row.Cells[2].Style.BackColor = Color.LightBlue;
                            row.Cells[3].Style.BackColor = Color.LightBlue;
                            row.Cells[4].Style.BackColor = Color.LightBlue;
                            row.Cells[5].Style.BackColor = Color.LightBlue;
                            row.Cells[6].Style.BackColor = Color.LightBlue;
                            r_prescriptionno.Add(row.Cells[2].Value.ToString().Trim());
                        }
                        else
                        {
                            row.Cells[0].Value = false;
                            row.Cells[2].Style.BackColor = Color.DarkSalmon;
                            row.Cells[3].Style.BackColor = Color.DarkSalmon;
                            row.Cells[4].Style.BackColor = Color.DarkSalmon;
                            row.Cells[5].Style.BackColor = Color.White;
                            row.Cells[6].Style.BackColor = Color.DarkSalmon;
                            r_prescriptionno.Remove(row.Cells[2].Value.ToString().Trim());
                        }
                    }

                    if (r_prescriptionno.Count != 0)
                    {
                        strStatusType = "cancel";
                        this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
                    }
                    else
                    {
                        this.dgvPrescriptionSelected.Rows.Clear();
                    }
                }
                else if (e.ColumnIndex == this.DgvPrescriptionCancel.Columns[1].Index)
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionCancel.Rows[DgvPrescriptionCancel.CurrentRow.Index].Cells[1];
                    this.ShowPrescriptionDetail(this.DgvPrescriptionCancel.Rows[this.DgvPrescriptionCancel.CurrentRow.Index].Cells[2].Value.ToString().Trim());
                }
            }
        }

        private void DgvPrescriptionComplete_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.DgvPrescriptionComplete.Rows.Count != 0)
            {
                if (e.ColumnIndex == this.DgvPrescriptionComplete.Columns[0].Index)
                {
                    r_prescriptionno.Clear();

                    foreach (DataGridViewRow row in this.DgvPrescriptionComplete.Rows)
                    {
                        if (row.Cells[0].Selected)
                        {
                            if (!Convert.ToBoolean(row.Cells[0].Value) || row.Cells[0].Value == null)
                                row.Cells[0].Value = true;
                            else
                                row.Cells[0].Value = false;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            row.Cells[0].Value = true;
                            row.Cells[2].Style.BackColor = Color.LightBlue;
                            row.Cells[3].Style.BackColor = Color.LightBlue;
                            row.Cells[4].Style.BackColor = Color.LightBlue;
                            row.Cells[5].Style.BackColor = Color.LightBlue;
                            row.Cells[6].Style.BackColor = Color.LightBlue;
                            r_prescriptionno.Add(row.Cells[2].Value.ToString().Trim());
                        }
                        else
                        {
                            row.Cells[0].Value = false;
                            row.Cells[2].Style.BackColor = Color.DarkSalmon;
                            row.Cells[3].Style.BackColor = Color.DarkSalmon;
                            row.Cells[4].Style.BackColor = Color.DarkSalmon;
                            row.Cells[5].Style.BackColor = Color.White;
                            row.Cells[6].Style.BackColor = Color.DarkSalmon;
                            r_prescriptionno.Remove(row.Cells[2].Value.ToString().Trim());
                        }
                    }

                    if (r_prescriptionno.Count != 0)
                    {
                        strStatusType = "complete";
                        this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
                    }
                    else
                    {
                        this.dgvPrescriptionSelected.Rows.Clear();
                    }
                }
                else if (e.ColumnIndex == this.DgvPrescriptionComplete.Columns[1].Index)
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionComplete.Rows[DgvPrescriptionComplete.CurrentRow.Index].Cells[1];
                    this.ShowPrescriptionDetail(this.DgvPrescriptionComplete.Rows[this.DgvPrescriptionComplete.CurrentRow.Index].Cells[2].Value.ToString().Trim());
                }
            }
        }

        private void DgvPrescriptionWait_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.DgvPrescriptionWait.Rows.Count != 0)
            {
                if (e.ColumnIndex == this.DgvPrescriptionWait.Columns[0].Index)
                {
                    r_prescriptionno.Clear();

                    foreach (DataGridViewRow row in this.DgvPrescriptionWait.Rows)
                    {
                        if (row.Cells[0].Selected)
                        {
                            if (!Convert.ToBoolean(row.Cells[0].Value) || row.Cells[0].Value == null)
                                row.Cells[0].Value = true;
                            else
                                row.Cells[0].Value = false;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            row.Cells[0].Value = true;
                            row.Cells[3].Style.BackColor = Color.LightBlue;
                            row.Cells[4].Style.BackColor = Color.LightBlue;
                            row.Cells[5].Style.BackColor = Color.LightBlue;
                            row.Cells[6].Style.BackColor = Color.LightBlue;
                            row.Cells[7].Style.BackColor = Color.LightBlue;
                            r_prescriptionno.Add(row.Cells[3].Value.ToString().Trim());
                        }
                        else
                        {
                            row.Cells[3].Style.BackColor = Color.WhiteSmoke;
                            row.Cells[4].Style.BackColor = Color.WhiteSmoke;
                            row.Cells[5].Style.BackColor = Color.WhiteSmoke;
                            row.Cells[6].Style.BackColor = Color.WhiteSmoke;
                            row.Cells[7].Style.BackColor = Color.WhiteSmoke;
                            r_prescriptionno.Remove(row.Cells[3].Value.ToString().Trim());
                        }
                    }

                    if (r_prescriptionno.Count != 0)
                    {
                        strStatusType = "wait";
                        this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
                    }
                    else
                    {
                        this.dgvPrescriptionSelected.Rows.Clear();
                    }
                }
                else if (e.ColumnIndex == this.DgvPrescriptionWait.Columns[1].Index)   // Prescription Cancel
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionWait.Rows[DgvPrescriptionWait.CurrentRow.Index].Cells[1];

                    th.PrescriptionNo = this.DgvPrescriptionWait.Rows[this.DgvPrescriptionWait.CurrentRow.Index].Cells[3].Value.ToString().Trim();
                    th.Status = 2;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 2, 1);
                    this.RefreshGrid();
                }

                else if (e.ColumnIndex == this.DgvPrescriptionWait.Columns[2].Index)
                {
                    _ = new DataGridViewButtonCell();
                    _ = (DataGridViewButtonCell)DgvPrescriptionWait.Rows[DgvPrescriptionWait.CurrentRow.Index].Cells[2];
                    this.ShowPrescriptionDetail(this.DgvPrescriptionWait.Rows[this.DgvPrescriptionWait.CurrentRow.Index].Cells[3].Value.ToString().Trim());
                }
            }
        }

        private bool DisplayDataGrid(DataSet ds, string statustype)
        {
            if (ds != null)
            {
                int j = 0;
                int icount = 0;
                int c = ds.Tables[0].Rows.Count;
                if (this.enableload == true)
                {
                    icount = istep;
                }
                else if (this.enableload == false)
                {
                    istep = 1;
                    switch (statustype)
                    {
                        case "all":
                            this.DgvPrescriptionAll.Rows.Clear();
                            break;

                        case "wait":
                            this.DgvPrescriptionWait.Rows.Clear();
                            break;

                        case "complete":
                            this.DgvPrescriptionComplete.Rows.Clear();
                            break;

                        case "cancel":
                            this.DgvPrescriptionCancel.Rows.Clear();
                            break;
                    }
                }
                for (int i = icount; i < c; i++)
                {
                    bool s = false;
                    string btn = "";
                    string presno = "", hn = "";
                    switch (strGroupBy)
                    {
                        case "prescription":
                            presno = ds.Tables[0].Rows[i]["f_prescriptionno"].ToString().Trim();

                            hn = ds.Tables[0].Rows[i]["f_hn"].ToString().Trim();
                            break;

                        case "hn":
                            hn = ds.Tables[0].Rows[i]["f_hn"].ToString().Trim();
                            break;
                    }
                    string bed = ds.Tables[0].Rows[i]["f_bedcode"].ToString().Trim();
                    string an = ds.Tables[0].Rows[i]["f_an"].ToString().Trim();
                    string patientname = ds.Tables[0].Rows[i]["f_patientname"].ToString().Trim();
                    string status = ds.Tables[0].Rows[i]["f_status"].ToString().Trim();

                    switch (statustype)
                    {
                        case "all":
                            this.DgvPrescriptionAll.Rows.Add(s, "","", btn, presno,bed, an, hn, patientname, status);
                            if (Settings.Default.DisplayAll == true)
                            {
                                strStatusType = "all";
                                r_prescriptionno.Add(presno);
                            }

                            switch (status)
                            {
                                case "0":
                                    this.DgvPrescriptionAll.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[5].Style.BackColor = Color.AliceBlue;
                                    this.DgvPrescriptionAll.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                    this.DgvPrescriptionAll.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                                    break;

                                case "1":
                                    this.DgvPrescriptionAll.Rows[i].Cells[1].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[2].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[4].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[5].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[6].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[7].Style.BackColor = Color.DarkSeaGreen;
                                    this.DgvPrescriptionAll.Rows[i].Cells[8].Style.BackColor = Color.DarkSeaGreen;

                                    break;
                                case "2":
                                    this.DgvPrescriptionAll.Rows[i].Cells[1].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[2].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[4].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[5].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[6].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[7].Style.BackColor = Color.DarkSalmon;
                                    this.DgvPrescriptionAll.Rows[i].Cells[8].Style.BackColor = Color.DarkSalmon;
                                    break;
                            }
                            break;

                        case "wait":
                            this.DgvPrescriptionWait.Rows.Add(s,"", btn,presno, bed, an, hn, patientname, status);
                            if (Settings.Default.DisplayAll == true)
                            {
                                r_prescriptionno.Add(presno);
                                strStatusType = "wait"; 
                            }

                            this.DgvPrescriptionAll.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionAll.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                            break;

                        case "complete":
                            this.DgvPrescriptionComplete.Rows.Add(s, btn, presno, bed, an, hn, patientname, status);
                            if (Settings.Default.DisplayAll == true)
                            {
                                r_prescriptionno.Add(presno);
                                strStatusType = "complete";
                            }
                            this.DgvPrescriptionComplete.Rows[i].Cells[1].Style.BackColor = Color.DarkSeaGreen;
                            this.DgvPrescriptionComplete.Rows[i].Cells[2].Style.BackColor = Color.DarkSeaGreen;
                            this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionComplete.Rows[i].Cells[4].Style.BackColor = Color.DarkSeaGreen;
                            this.DgvPrescriptionComplete.Rows[i].Cells[5].Style.BackColor = Color.DarkSeaGreen;
                            this.DgvPrescriptionComplete.Rows[i].Cells[6].Style.BackColor = Color.DarkSeaGreen;
                            break;

                        case "cancel":
                            this.DgvPrescriptionCancel.Rows.Add(s, btn, presno, bed,an, hn, patientname, status);
                            if (Settings.Default.DisplayAll == true)
                            {
                                r_prescriptionno.Add(presno);
                                strStatusType = "cancel";                              
                            }
                            this.DgvPrescriptionCancel.Rows[i].Cells[1].Style.BackColor = Color.DarkSalmon;
                            this.DgvPrescriptionCancel.Rows[i].Cells[2].Style.BackColor = Color.DarkSalmon;
                            this.DgvPrescriptionAll.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            this.DgvPrescriptionCancel.Rows[i].Cells[4].Style.BackColor = Color.DarkSalmon;
                            this.DgvPrescriptionCancel.Rows[i].Cells[5].Style.BackColor = Color.DarkSalmon;
                            this.DgvPrescriptionCancel.Rows[i].Cells[6].Style.BackColor = Color.DarkSalmon;
                            break;
                    }

                    j++;
                    int a = (int)(((double)j / (double)c) * 100);
                    this.UpdateprocessImport(a);

                    istep++;
                }

                if (r_prescriptionno.Count != 0)
                {
                    this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
                    if (r_frequenTimeOrder.Count != 0)
                        this.OnloadDataFrequencyTimeSelected();
                    else
                        this.dgvFrequencyTime.Rows.Clear();
                }
                else
                    this.dgvPrescriptionSelected.Rows.Clear();


                switch (statustype)
                {
                    case "all":
                        this.DgvPrescriptionAll.CurrentCell = null;
                        this.DgvPrescriptionAll.ClearSelection();
                        break;

                    case "wait":
                        this.DgvPrescriptionWait.CurrentCell = null;
                        this.DgvPrescriptionWait.ClearSelection();
                        break;

                    case "complete":
                        this.DgvPrescriptionComplete.CurrentCell = null;
                        this.DgvPrescriptionComplete.ClearSelection();
                        break;

                    case "cancel":
                        this.DgvPrescriptionCancel.CurrentCell = null;
                        this.DgvPrescriptionCancel.ClearSelection();
                        break;
                }
            }

            if (r_prescriptionno.Count != 0)
            {
                foreach (Object items in r_prescriptionno)
                {
                    foreach (DataGridViewRow row in this.DgvPrescriptionAll.Rows)
                    {
                        if (items.ToString() == row.Cells[2].Value.ToString())
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value) == false)
                            {
                                row.Cells[0].Value = true;
                                row.Cells[2].Style.BackColor = Color.LightBlue;
                                row.Cells[4].Style.BackColor = Color.LightBlue;
                                row.Cells[5].Style.BackColor = Color.LightBlue;
                            }
                        }
                    }
                }
            }

            return true;
        }

        //function get data thanes middle detail display
        private void OnloadDataPrescriptionSelected(ArrayList prescriptionno, string statustype)
        {
            try
            {
                r_frequenTimeOrder.Clear();

                DataSet ds = null;
                ds = th.GetDispalyPrescriptionDataGridViewSelected(prescriptionno, statustype, strPriorty, strMachineNo, strSerachSelected);
                int items = ds.Tables[0].Rows.Count;
                if (items != 0)
                {
                    this.dgvPrescriptionSelected.Rows.Clear();
                    for (int i = 0; i < items; i++)
                    {
                        bool s = false;
                        string presno = ds.Tables[0].Rows[i]["f_prescriptionno"].ToString().Trim();
                        string bed = ds.Tables[0].Rows[i]["f_bedcode"].ToString().Trim();
                        string hn = ds.Tables[0].Rows[i]["f_hn"].ToString().Trim();
                        string patientname = ds.Tables[0].Rows[i]["f_patientname"].ToString().Trim();
                        string prioritydesc = ds.Tables[0].Rows[i]["f_prioritydesc"].ToString().Trim();
                        string drugcode = ds.Tables[0].Rows[i]["f_orderitemcode"].ToString().Trim();
                        string drugname = ds.Tables[0].Rows[i]["f_orderitemname"].ToString().Trim();
                        string quanitity = ds.Tables[0].Rows[i]["f_orderqty"].ToString().Trim();
                        string unitdesc = ds.Tables[0].Rows[i]["f_orderunitdesc"].ToString().Trim();
                        string status = ds.Tables[0].Rows[i]["f_status"].ToString().Trim();
                        string lastmodified = Convert.ToDateTime(ds.Tables[0].Rows[i]["f_lastmodified"]).ToString("HH:mm:ss tt");
                        string seq = ds.Tables[0].Rows[i]["f_seq"].ToString().Trim();
                        string tomachine = ds.Tables[0].Rows[i]["f_tomachineno"].ToString().Trim();
                        string dosage = ds.Tables[0].Rows[i]["f_dosage"].ToString().Trim();
                        string rowID = ds.Tables[0].Rows[i]["RowID"].ToString().Trim();
                        string strStatus = string.Empty;
                        switch (status)
                        {
                            case "0":
                                strStatus = "รอจัดยา";
                                break;

                            case "1":
                                strStatus = "สั่งจัดเรียบร้อย";
                                break;

                            case "2":
                                strStatus = "ยกเลิกการจัดยา";
                                break;
                        }
                        string strMachineNo = string.Empty;
                        switch (tomachine)
                        {
                            case "2":
                                strMachineNo = "จัดยาจากโรบอท";
                                break;

                            case "4":
                                strMachineNo = "จัดยาด้วย DTA";
                                break;
                            case "24":
                                strMachineNo = "จัดยาจากโรบอทและ DTA";
                                break;
                            case "0":
                                strMachineNo = "จัดจากห้องยา";
                                break;
                        }

                        string unuseDivision = "";
                        if (chkCassetteStatus.Checked == true)
                        {
                            unuseDivision = RunStoredUseDivision(drugcode);
                        }

                        string dosageDTA = "";
                        if (Convert.ToDecimal(dosage)!= 0)
                        {
                            if(tomachine == "24" || tomachine == "2" )
                            {
                                decimal dta = (Convert.ToDecimal(quanitity) % Convert.ToDecimal(dosage));
                                if(dta == 0)
                                {
                                    dosageDTA = "";
                                }
                                else
                                {
                                    dosageDTA = (Convert.ToDecimal(quanitity) % Convert.ToDecimal(dosage)).ToString() + " " + unitdesc;
                                }
                            }else if (tomachine == "4")
                            {
                                dosageDTA =  Convert.ToDecimal(quanitity).ToString() + " " + unitdesc;
                            }
                            else
                            {
                                dosageDTA = "-ไม่ใช่ยาที่กำหนด-";
                            }
                        }
                        else
                        {
                            dosageDTA = "";
                        }
                           
                        
                        if(tomachine == "0")
                            dosageDTA = "-";


                        this.dgvPrescriptionSelected.Rows.Add(s, presno, bed, hn, patientname, prioritydesc,"","",seq, drugcode, drugname, quanitity, unitdesc, strStatus, lastmodified,strMachineNo,unuseDivision, dosageDTA, rowID);
                       
                        if(Settings.Default.DisplayAll == true)
                        {
                            r_frequenTimeOrder.Add(rowID);
                        }
                        
                        if (prioritydesc == "Normal")
                        {
                            this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.ForeColor = Color.Navy;
                            this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.BackColor = Color.LightSteelBlue;
                        }
                        else
                        {
                            this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.ForeColor = Color.DarkGreen;
                            this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                        }
                        switch (status)
                        {
                            case "0":
                                this.dgvPrescriptionSelected.Rows[i].Cells[1].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[2].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[3].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[4].Style.BackColor = Color.White;
                                //this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                this.dgvPrescriptionSelected.Rows[i].Cells[7].Style.BackColor = SystemColors.ActiveCaption;
                                this.dgvPrescriptionSelected.Rows[i].Cells[8].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[9].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[10].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[11].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[12].Style.BackColor = Color.White;
                                this.dgvPrescriptionSelected.Rows[i].Cells[13].Style.BackColor = Color.White;

                                break;

                            case "1":
                                this.dgvPrescriptionSelected.Rows[i].Cells[1].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[2].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[3].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[4].Style.BackColor = Color.DarkSeaGreen;
                                //this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[7].Style.BackColor = SystemColors.ActiveCaption;
                                this.dgvPrescriptionSelected.Rows[i].Cells[8].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[9].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[10].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[11].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[12].Style.BackColor = Color.DarkSeaGreen;
                                this.dgvPrescriptionSelected.Rows[i].Cells[13].Style.BackColor = Color.DarkSeaGreen;
                                break;

                            case "2":
                                this.dgvPrescriptionSelected.Rows[i].Cells[1].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[2].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[3].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[4].Style.BackColor = Color.DarkSalmon;
                                //this.dgvPrescriptionSelected.Rows[i].Cells[5].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[7].Style.BackColor = SystemColors.ActiveCaption;
                                this.dgvPrescriptionSelected.Rows[i].Cells[8].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[9].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[10].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[11].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[12].Style.BackColor = Color.DarkSalmon;
                                this.dgvPrescriptionSelected.Rows[i].Cells[13].Style.BackColor = Color.DarkSalmon;
                                break;
                        }

                        switch (strMachineNo)
                        {
                            case "2":
                                this.dgvPrescriptionSelected.Rows[i].Cells[15].Style.ForeColor = Color.YellowGreen;
                                break;
                            case "4":
                                this.dgvPrescriptionSelected.Rows[i].Cells[15].Style.ForeColor = Color.Peru;
                                break;
                            case "24":
                                this.dgvPrescriptionSelected.Rows[i].Cells[15].Style.ForeColor = Color.Blue;
                                break;
                            case "0":
                                this.dgvPrescriptionSelected.Rows[i].Cells[15].Style.ForeColor = Color.WhiteSmoke;
                                break;
                        }
                        if (chkCassetteStatus.Checked == true)
                        {
                            if (unuseDivision.Contains("Enable"))
                            {
                                this.dgvPrescriptionSelected.Columns["f_UnuseDivision"].DefaultCellStyle.ForeColor = Color.Blue;
                                this.dgvPrescriptionSelected.Rows[i].Cells[16].Style.BackColor = Color.White;
                            }
                            else if (unuseDivision.Contains("Disable"))
                            {
                                this.dgvPrescriptionSelected.Columns["f_UnuseDivision"].DefaultCellStyle.ForeColor = Color.Red;
                                this.dgvPrescriptionSelected.Rows[i].Cells[16].Style.BackColor = Color.White;
                            }
                        }
                            
                    }
                    ds.Clear();
                    ds.Dispose();
                    this.dgvPrescriptionSelected.CurrentCell = null;
                    this.dgvPrescriptionSelected.ClearSelection();
                    if (strPriorty == null)
                        this.gbDgvOrderList.Text = "รายการข้อมูลที่ถูกเลือกเพื่อดำเนินการ " + items.ToString() + " รายการ";
                    else
                        this.gbDgvOrderList.Text = "รายการข้อมูลที่ถูกเลือกเพื่อดำเนินการ ประเภทรายการ [ " + cbPriorityDesc.Text + " ] จำนวน " + items.ToString() + " รายการ";
                    // btn tools management
                    this.BtnSelectAll.Text = "เลือกทั้งหมด";
                    this.BtnSelectAll.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ข้อผิดพลาดการโหลดข้อมูลรายการสั่งยา Error DataGridView Prescription Order Selected  : " + ex.Message);
            }
        }

        //function get data thanes middle detail display
        private void OnloadDataFrequencyTimeSelected()
        {
            try
            {
                DataSet ds = null;
                ds = pres.GetDispalyFrequencyTakeTimeDataGridViewSelected(r_frequenTimeOrder);
                string taketimeCompare = "";
                string statusPack = "จัดยา";
                int items = ds.Tables[0].Rows.Count;
                if (items != 0)
                {
                    this.dgvFrequencyTime.Rows.Clear();
                    for (int i = 0; i < items; i++)
                    {
                        bool s = false;
                        string bedno = ds.Tables[0].Rows[i]["BedNo"].ToString().Trim();
                        string hn = ds.Tables[0].Rows[i]["PatientId"].ToString().Trim();
                        string patientname = ds.Tables[0].Rows[i]["PatientName"].ToString().Trim();
                        string takedate = ds.Tables[0].Rows[i]["TakeDate"].ToString().Trim();

                        string taketime = string.Empty;
                        if (ds.Tables[0].Rows[i]["TakeTime"].ToString() != "1111")
                            taketime = ds.Tables[0].Rows[i]["TakeTime"].ToString().Substring(0, 2) + ":" + ds.Tables[0].Rows[i]["TakeTime"].ToString().Substring(2, 2) + " น.";
                        else
                            taketime = "None";

                        string freqDesc = ds.Tables[0].Rows[i]["Freq_Desc_Detail"].ToString().Trim();
                        string drugname = ds.Tables[0].Rows[i]["DrugName"].ToString().Trim();
                        string freePrint1 = ds.Tables[0].Rows[i]["FreePrintItem_Presc1"].ToString().Trim();
                        string presc = ds.Tables[0].Rows[i]["PrescriptionNoHIS"].ToString().Trim();
                        string status = ds.Tables[0].Rows[i]["NormalStatus"].ToString().Trim();
                        if (Settings.Default.DispenseDoseMode == false)
                        {
                            if (taketimeCompare != taketime)
                            {
                                taketimeCompare = taketime;
                                seqno++;
                            }
                        }
                        else
                        {
                            seqno++;
                        }
                        this.dgvFrequencyTime.Rows.Add(s, seqno, bedno, hn, patientname, takedate, taketime, freqDesc, statusPack, drugname, freePrint1, presc, status);

                        if (status.Contains("One Day"))
                        {
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.ForeColor = Color.Navy;
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.BackColor = Color.LightSteelBlue;
                        }
                        else if (status.Contains("Dose"))
                        {
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.ForeColor = Color.Red;
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.BackColor = Color.LightSteelBlue;
                        }
                        else
                        {
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.ForeColor = Color.DarkGreen;
                            this.dgvFrequencyTime.Rows[i].Cells[12].Style.BackColor = Color.LightGreen;
                        }
                    }
                    ds.Clear();
                    ds.Dispose();
                    this.dgvFrequencyTime.CurrentCell = null;
                    this.dgvFrequencyTime.ClearSelection();
                    if (strPriorty == null)
                        this.gbFrequecyTime.Text = "รายการข้อมูลมื้อยาที่เลือก จำนวน " + seqno.ToString() + " รายการ";
                    else
                        this.gbFrequecyTime.Text = "รายการข้อมูลมื้อยาที่เลือก ประเภทรายการ [ " + cbPriorityDesc.Text + " ] จำนวน " + seqno.ToString() + " รายการ";
                    // btn tools management
                    //this.BtnSelectAll.Text = "เลือกทั้งหมด";
                    //this.BtnSelectAll.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ข้อผิดพลาดการโหลดข้อมูลแยกมื้อยา Error DataGridView Frequency Time : " + ex.Message);
            }
        }

        //function get data thanes middle display
        private void OnloadDataThanesMiddle(bool status, string statustype)
        {
            try
            {
                int itemspres = 0;
                if ((status == true) && ((this.strSearch == "") || (this.strSearch == null)))
                {
                    itemspres = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, null, statustype));
                    if ((itemspres != 0) && (itemsCompare != itemspres))
                    {
                        itemsCompare = itemspres;
                        dsTogrid = th.GetDispalyPrescriptionDataGridView(strGroupBy, strWard, null, statustype);
                        this.DisplayDataGrid(dsTogrid, statustype);
                    }
                    itemsSearchCompare = 0;
                }
                else if ((status == false) && ((this.strSearch != "") && (this.strSearch != null)))
                {
                    itemspres = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, strSearch, statustype));
                    if ((itemspres != 0) && (itemsSearchCompare != itemspres))
                    {
                        itemsSearchCompare = itemspres;
                        dsTogrid = th.GetDispalyPrescriptionDataGridView(strGroupBy, strWard, strSearch, statustype);
                        this.DisplayDataGrid(dsTogrid, statustype);
                    }
                    itemsCompare = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ข้อผิดพลาดการโหลดข้อมูล Error OnloadDataThanesMiddle : " + ex.Message);
            }
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
                this.RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Load cbWardInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // fuction get data priorty in Hospital
        private void OnloadDataPriority()
        {
            try
            {
                DataSet ds = th.GetDataPriortyInfo();
                this.cbPriorityDesc.DisplayMember = "f_prioritydesc";
                this.cbPriorityDesc.ValueMember = "f_prioritycode";
                this.cbPriorityDesc.DataSource = ds.Tables[0];
                //this.RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Load cbPriorityDesc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //function get items prescription by status type
        private void OnloadItemsPrescription()
        {
            try
            {
                int all = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, null, "all"));
                int wait = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, null, "wait"));
                int complete = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, null, "complete"));
                int cancel = Convert.ToInt32(th.GetItemsDataThanesMiddle(strGroupBy, strWard, null, "cancel"));
                if (all != itemsall)
                {
                    itemsall = all;
                    this.tabPrescriptionAll.Text = "ใบสั่งยาทั้งหมด [" + itemsall + "]";
                    if (chkRefresh.CheckState == CheckState.Checked)
                        this.RefreshGrid();
                }
                if (wait != itemswait)
                {
                    itemswait = wait;
                    this.tabPrescriptionWait.Text = "ใบสั่งยารอจัดยา [" + itemswait + "]";
                    if (chkRefresh.CheckState == CheckState.Checked)
                        this.RefreshGrid();
                }
                if (complete != itemscomplete)
                {
                    itemscomplete = complete;
                    this.tabPrescriptionComplete.Text = "ใบสั่งยาจัดยาแล้ว [" + itemscomplete + "]";
                    if (chkRefresh.CheckState == CheckState.Checked)
                        this.RefreshGrid();
                }
                if (cancel != itemscancel)
                {
                    itemscancel = cancel;
                    this.tabPrescriptionCancel.Text = "ใบสั่งยายกเลิกการจัดยา [" + itemscancel + "]";
                    if (chkRefresh.CheckState == CheckState.Checked)
                        this.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrescriptionPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Default.ClientMode == true)
            {
                try
                {
                    Application.Exit();
                    this.Dispose();
                }
                finally
                {
                    Application.Exit();
                    this.Dispose();
                }
            }
            r_prescriptionno.Clear();
            this.TmOnload.Enabled = false;
            this.TmOnload.Stop();
        }

        private void PrescriptionPage_Load(object sender, EventArgs e)
        {
            this.enableload = true;                      //Onload Status
            this.cbWardInfo.Text = "เลือกทั้งหมด";
            this.cbPriorityDesc.Text = "เลือกทั้งหมด";
            this.cbToMachineno.Text = "เลือกทั้งหมด";
            strGroupBy = "prescription";
            this.OnloadItemsPrescription();              //Onload Prescription Data To DataGrid View.
            this.OnloadDataThanesMiddle(true, statusTabPage);

            dgvFrequencyTime.AutoGenerateColumns = false;
            //Default Form Value
            if (!Settings.Default.DispenseDoseMode)
                rbtnMutiDose.Checked = true;
            else
                rbtnUnitDose.Checked = true;

            //Timer Onload Start
            this.TmOnload.Enabled = true;
            this.TmOnload.Start();
        }

        //function refresh data grid view
        private void RefreshGrid()
        {
            this.enableload = false;
            istep = 1;
            itemsCompare = 0;
            switch (this.TcPrescriptionType.SelectedIndex)
            {
                case 0:         //for all status
                    statusTabPage = "all";
                    this.chkAllData.CheckState = CheckState.Unchecked;
                    break;

                case 1:         //for wait status
                    statusTabPage = "wait";
                    this.chkWaitData.CheckState = CheckState.Unchecked;
                    break;

                case 2:          //for complete status
                    statusTabPage = "complete";
                    this.chkCompleteData.CheckState = CheckState.Unchecked;
                    break;

                case 3:          //for cancel status
                    statusTabPage = "cancel";
                    this.chkCancelData.CheckState = CheckState.Unchecked;
                    break;

                default:        //for all status
                    statusTabPage = "all";
                    this.chkAllData.CheckState = CheckState.Unchecked;
                    break;
            }
            this.OnloadDataThanesMiddle(true, statusTabPage);
            r_prescriptionno.Clear();

            this.tbSearchData.Text = "";
            this.strSearch = null;
            //this.dgvPrescriptionSelected.Rows.Clear();
        }

        //function selected data for show prescription detail
        private void ShowPrescriptionDetail(string f_prescriptionno)
        {
            this.Opacity = 50;
            PrescriptionDetail pres = new PrescriptionDetail(f_prescriptionno);
            pres.ShowDialog();
        }

        //selected index changed
        private void TcPrescriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            r_prescriptionno.Clear();
            this.RefreshGrid();
        }

        //timer for onload items prescription

        private void TmOnload_Tick(object sender, EventArgs e)
        {
            this.OnloadItemsPrescription();
        }

        private void UpdateprocessImport(int percent)
        {
            this.progressbar_overall.Value = percent;
            this.txt_overall.Text = String.Format(" {0}% ", percent);
            if (percent == 100)
            {
                this.progressbar_overall.Value = 0;
            }
        }

        private void cbWardInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            strWard = cbWardInfo.SelectedValue.ToString();
            r_prescriptionno.Clear();
            this.RefreshGrid();
        }

        private void chkAllData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllData.CheckState == CheckState.Checked)
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionAll.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        row.Cells[0].Value = true;
                        row.Cells[4].Style.BackColor = Color.LightBlue;
                        row.Cells[5].Style.BackColor = Color.LightBlue;
                        row.Cells[6].Style.BackColor = Color.LightBlue;
                        row.Cells[7].Style.BackColor = Color.LightBlue;
                        r_prescriptionno.Add(row.Cells[4].Value.ToString().Trim());
                    }
                }
            }
            else
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionAll.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[0].Value = false;
                        row.Cells[4].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[5].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[6].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[7].Style.BackColor = Color.WhiteSmoke;
                    }
                }
            }

            if (r_prescriptionno.Count != 0)
            {
                strStatusType = "all";
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
            else
                this.dgvPrescriptionSelected.Rows.Clear();
        }

        private void chkWaitData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWaitData.CheckState == CheckState.Checked)
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionWait.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        row.Cells[0].Value = true;
                        row.Cells[3].Style.BackColor = Color.LightBlue;
                        row.Cells[4].Style.BackColor = Color.LightBlue;
                        row.Cells[5].Style.BackColor = Color.LightBlue;
                        row.Cells[6].Style.BackColor = Color.LightBlue;
                        row.Cells[7].Style.BackColor = Color.LightBlue;
                        r_prescriptionno.Add(row.Cells[3].Value.ToString().Trim());
                    }
                }
            }
            else
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionWait.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[0].Value = false;
                        row.Cells[3].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[4].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[5].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[6].Style.BackColor = Color.WhiteSmoke;
                        row.Cells[7].Style.BackColor = Color.WhiteSmoke;
                    }
                }
            }

            if (r_prescriptionno.Count != 0)
            {
                strStatusType = "wait";
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
            else
                this.dgvPrescriptionSelected.Rows.Clear();
        }

        private void chkCompleteData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompleteData.CheckState == CheckState.Checked)
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionComplete.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        row.Cells[0].Value = true;
                        row.Cells[2].Style.BackColor = Color.LightBlue;
                        row.Cells[4].Style.BackColor = Color.LightBlue;
                        row.Cells[5].Style.BackColor = Color.LightBlue;
                        r_prescriptionno.Add(row.Cells[2].Value.ToString().Trim());
                    }
                }
            }
            else
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionComplete.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[0].Value = false;
                        row.Cells[2].Style.BackColor = Color.DarkSeaGreen;
                        row.Cells[4].Style.BackColor = Color.DarkSeaGreen;
                        row.Cells[5].Style.BackColor = Color.White;
                    }
                }
            }

            if (r_prescriptionno.Count != 0)
            {
                strStatusType = "complete";
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
            else
                this.dgvPrescriptionSelected.Rows.Clear();
        }

        private void chkCancelData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCancelData.CheckState == CheckState.Checked)
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionCancel.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        row.Cells[0].Value = true;
                        row.Cells[2].Style.BackColor = Color.LightBlue;
                        row.Cells[4].Style.BackColor = Color.LightBlue;
                        row.Cells[5].Style.BackColor = Color.LightBlue;
                        r_prescriptionno.Add(row.Cells[2].Value.ToString().Trim());
                    }
                }
            }
            else
            {
                r_prescriptionno.Clear();

                foreach (DataGridViewRow row in this.DgvPrescriptionCancel.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[0].Value = false;
                        row.Cells[2].Style.BackColor = Color.DarkSalmon;
                        row.Cells[4].Style.BackColor = Color.DarkSalmon;
                        row.Cells[5].Style.BackColor = Color.White;
                    }
                }
            }

            if (r_prescriptionno.Count != 0)
            {
                strStatusType = "cancel";
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
            else
                this.dgvPrescriptionSelected.Rows.Clear();
        }

        private void btnMedPlanData_Click(object sender, EventArgs e)
        {
            MedicationPlaningPage medicationPlaning = new MedicationPlaningPage();
            medicationPlaning.ShowDialog();
        }

        private void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefresh.CheckState == CheckState.Unchecked)
                TmOnload.Enabled = false;
            else
                TmOnload.Enabled = true;
        }

        private void btnListView_Click(object sender, EventArgs e)
        {
            if (btnListView.BackColor == Color.Gainsboro)
            {
                btnListView.BackColor = Color.White;
                btnGanttChartView.BackColor = Color.Gainsboro;
            }
        }

        private void btnGanttChartView_Click(object sender, EventArgs e)
        {
            if (btnGanttChartView.BackColor == Color.Gainsboro)
            {
                btnListView.BackColor = Color.Gainsboro;
                btnGanttChartView.BackColor = Color.White;
            }
        }

        private void chkAllPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPriority.CheckState == CheckState.Unchecked)
            {
                this.cbPriorityDesc.Enabled = true;
                OnloadDataPriority();
                strPriorty = cbPriorityDesc.SelectedValue.ToString();
            }
            else
            {
                this.cbPriorityDesc.Enabled = false;
                this.cbPriorityDesc.Text = "เลือกทั้งหมด";
                strPriorty = null;
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
        }

        private void cbPriorityDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            strPriorty = cbPriorityDesc.SelectedValue.ToString();
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
        }

        private void chkAllToMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllToMachine.CheckState == CheckState.Unchecked)
            {
                this.cbToMachineno.Enabled = true;
                switch (cbToMachineno.Text)
                {
                    case "โรบอทและหยด DTA":
                        strMachineNo = "IN ('2','4') ";
                        break;
                    case "โรบอท":
                        strMachineNo = "IN ('2') ";
                        break;
                    case "หยด DTA":
                        strMachineNo = "IN ('4') ";
                        break;
                    case "จัดจากห้องยา":
                        strMachineNo = "";
                        break;
                }
            }
            else
            {
                this.cbToMachineno.Enabled = false;
                this.cbToMachineno.Text = "เลือกทั้งหมด";
                strMachineNo = null;
                this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            }
        }

        private void cbToMachineno_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbToMachineno.Text)
            {
                case "โรบอทและหยด DTA":
                    strMachineNo = "IN ('24','2','4') ";
                    break;
                case "โรบอท":
                    strMachineNo = "IN ('2') ";
                    break;
                case "หยด DTA":
                    strMachineNo = "IN ('4') ";
                    break;
                case "จัดจากห้องยา":
                    strMachineNo = "0";
                    break;
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
        }

        private void rbtnMutiDose_CheckedChanged(object sender, EventArgs e)
        {
            seqno = 0;
            Settings.Default.DispenseDoseMode = false;
            Settings.Default.Save();
            if (r_frequenTimeOrder.Count != 0)
                this.OnloadDataFrequencyTimeSelected();
        }

        private void rbtnUnitDose_CheckedChanged(object sender, EventArgs e)
        {
            seqno = 0;
            Settings.Default.DispenseDoseMode = true;
            Settings.Default.Save();
            if (r_frequenTimeOrder.Count != 0)
                this.OnloadDataFrequencyTimeSelected();
        }

        private void dgvPrescriptionSelected_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvPrescriptionSelected.Rows.Count != 0)
            {
                if (e.ColumnIndex == this.dgvPrescriptionSelected.Columns[0].Index)
                {
                    r_frequenTimeOrder.Clear();

                    foreach (DataGridViewRow row in this.dgvPrescriptionSelected.Rows)
                    {
                        if (row.Cells[0].Selected)
                        {
                            if (!Convert.ToBoolean(row.Cells[0].Value) || row.Cells[0].Value == null)
                                row.Cells[0].Value = true;
                            else
                                row.Cells[0].Value = false;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            row.Cells[0].Value = true;
                            row.Cells[2].Style.BackColor = Color.LightBlue;
                            row.Cells[3].Style.BackColor = Color.LightBlue;
                            row.Cells[4].Style.BackColor = Color.LightBlue;
                            row.Cells[5].Style.BackColor = Color.LightBlue;
                            row.Cells[6].Style.BackColor = Color.LightBlue;
                            r_frequenTimeOrder.Add(row.Cells[17].Value.ToString().Trim());
                        }
                        else
                        {
                            row.Cells[0].Value = false;
                            row.Cells[2].Style.BackColor = Color.White;
                            row.Cells[3].Style.BackColor = Color.White;
                            row.Cells[4].Style.BackColor = Color.White;
                            row.Cells[5].Style.BackColor = Color.White;
                            row.Cells[6].Style.BackColor = Color.White;
                            r_frequenTimeOrder.Remove(row.Cells[17].Value.ToString().Trim());
                        }
                    }

                    if (r_frequenTimeOrder.Count != 0)
                        this.OnloadDataFrequencyTimeSelected();
                    else
                        this.dgvFrequencyTime.Rows.Clear();
                }
                else if (e.ColumnIndex == this.dgvPrescriptionSelected.Columns[6].Index)   // Cancel drug
                {
                    th.PrescriptionNo = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                    th.RowID = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[18].Value.ToString().Trim();
                    th.Status = 2;
                    string drugcode = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[9].Value.ToString().Trim();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, th.RowID, 2, 1);

                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[8].Style.BackColor = SystemColors.ActiveCaption;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[9].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[10].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[11].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[12].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[13].Value = "ยกเลิกการจัดยา";
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[13].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[14].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[15].Style.BackColor = Color.DarkSalmon;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[16].Style.BackColor = Color.DarkSalmon;
                }
                else if (e.ColumnIndex == this.dgvPrescriptionSelected.Columns[7].Index)   // Cancel drug
                {
                    th.PrescriptionNo = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                    th.RowID = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[18].Value.ToString().Trim();
                    th.Status = 0;
                    string drugcode = this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[9].Value.ToString().Trim();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, th.RowID, 0, 0);

                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[8].Style.BackColor = SystemColors.ActiveCaption;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[9].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[10].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[11].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[12].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[13].Value = "รอจัดยา";
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[13].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[14].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[15].Style.BackColor = Color.White;
                    this.dgvPrescriptionSelected.Rows[this.dgvPrescriptionSelected.CurrentRow.Index].Cells[16].Style.BackColor = Color.White;
                }
            }
        }

        private void tbPresSearch_TextChanged(object sender, EventArgs e)
        {
            strSerachSelected = tbPresSearch.Text.Trim();
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
        }

        private void tbSearchData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((this.tbSearchData.Text != null) || (this.tbSearchData.Text != ""))
            {
                this.enableload = false;
                this.strSearch = this.tbSearchData.Text.Trim();
                this.OnloadDataThanesMiddle(false, statusTabPage);
            }
            else
                this.enableload = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbPresSearch.Text = "";
            strSerachSelected = null;
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
        }

        private void dgvFrequencyTime_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (this.dgvFrequencyTime.Columns["TakeTime"].Index == e.ColumnIndex && e.RowIndex >= 0)
            //{
            //    Rectangle newRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4);

            //    using (Brush gridBrush = new SolidBrush(this.dgvFrequencyTime.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            //    {
            //        using (Pen gridLinePen = new Pen(gridBrush))
            //        {
            //            // Erase the cell.
            //            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

            //            // Draw the grid lines (only the right and bottom lines;
            //            // DataGridView takes care of the others).
            //            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
            //            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

            //            // Draw the inset highlight box.
            //            e.Graphics.DrawRectangle(Pens.Blue, newRect);

            //            // Draw the text content of the cell, ignoring alignment.
            //            if (e.Value != null)
            //            {
            //                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2, StringFormat.GenericDefault);
            //            }
            //            e.Handled = true;
            //        }
            //    }
            //}

            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvFrequencyTime.AdvancedCellBorderStyle.Top;
            }
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            // To compare only values on 1st and 2nd column (TGL, TRANSAKSI)
            DataGridViewCell cell1 = null;
            DataGridViewCell cell2 = null;
            if (Settings.Default.DispenseDoseMode == false)
            {
                if (column > 6 || column == 0) return false;
                cell1 = dgvFrequencyTime[6, row];
                cell2 = dgvFrequencyTime[6, row - 1];
            }
            else
                return false;

            if (cell1.Value == null || cell2.Value == null)
                return false;

            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvFrequencyTime_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void BtnSelectTakeTimtAll_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelTakeTimeOrder_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvFrequencyTime.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[11].Value.ToString();
                    th.RowID = row.Cells[15].Value.ToString();
                    th.Status = 2;
                    string drugcode = row.Cells[5].Value.ToString();
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, drugcode, th.RowID, 2, 1);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
            this.RefreshGrid();
        }

        private void BtnRecountTakeTimeOrder_Click(object sender, EventArgs e)
        {

        }

        private void BtnRestoreTakeTimeOrder_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelPrescription_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DgvPrescriptionWait.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[3].Value.ToString();
                    th.RowID = null;
                    th.Status = 2;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 2, 1);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
            this.RefreshGrid();
        }

        private void BtnRecountPrescription_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DgvPrescriptionComplete.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[2].Value.ToString();
                    th.RowID = null;
                    th.Status = 1;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 0, 0);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
            this.RefreshGrid();
        }

        private void BtnRestorePerscription_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DgvPrescriptionCancel.Rows)
            {
                DataGridViewCheckBoxCell chk_select = new DataGridViewCheckBoxCell();
                chk_select = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((bool)row.Cells[0].Value == true)
                {
                    th.PrescriptionNo = row.Cells[2].Value.ToString();
                    th.RowID = null;
                    th.Status = 0;
                    th.UpdateStatusDataThanesMiddle();
                    pres.UpdateStatusByPrescriptionno(th.PrescriptionNo, null, null, 0, 0);
                }
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, statusTabPage);
            this.RefreshGrid();
        }

        public string RunStoredUseDivision(string drugcode)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.JSDSource))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.sp_JSDUseDivisionByDrugCd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@drugcode", drugcode));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                           int unuse = Convert.ToInt32(rdr["vc_UnUsedDivision"].ToString());
                            if(unuse == 0)
                            {
                                result = "Cassette "+ rdr["ln_CassetteNo"].ToString().PadLeft(3,'0')  + " Enable";
                            }
                            else
                            {
                                result = "Cassette " + rdr["ln_CassetteNo"].ToString().PadLeft(3, '0') + " Disable";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = "ยาอื่นๆ นอกโรบอท";
                //throw new Exception("RunStoredProcGetIndex :" + ex.Message);
            }
            return result;
        }

        private void tabPrescriptionAll_Click(object sender, EventArgs e)
        {

        }

        private void chkCassetteStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCassetteStatus.CheckState == CheckState.Checked)
            {
                this.dgvPrescriptionSelected.Columns["f_UnuseDivision"].Visible = true;
            }
            else
            {
                this.dgvPrescriptionSelected.Columns["f_UnuseDivision"].Visible = false;
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
        }

        private void BtnReportInfo_Click(object sender, EventArgs e)
        {
            MonitorPage full = new MonitorPage
            {
                WindowState = FormWindowState.Maximized
            };
            full.Show();
        }

        private void btnDrugInfo_Click(object sender, EventArgs e)
        {
            DrugInfoPage dr = new DrugInfoPage
            {
                WindowState = FormWindowState.Maximized
            };
            dr.Show();
        }

        private void chkDoseDTA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoseDTA.CheckState == CheckState.Checked)
            {
                this.dgvPrescriptionSelected.Columns["f_dosageDTA"].Visible = true;
            }
            else
            {
                this.dgvPrescriptionSelected.Columns["f_dosageDTA"].Visible = false;
            }
        }

        private void DgvPrescriptionAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 1)
            {
                Image someImage;
                someImage = Properties.Resources.remove_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.remove_16.Width;
                var h = Properties.Resources.remove_16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 2)
            {
                Image someImage;
                someImage = Properties.Resources.reset_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w1 = Properties.Resources.remove_16.Width;
                var h1 = Properties.Resources.remove_16.Height;
                var x1 = e.CellBounds.Left + (e.CellBounds.Width - w1) / 2;
                var y1 = e.CellBounds.Top + (e.CellBounds.Height - h1) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x1, y1, w1, h1));
                e.Handled = true;
            }
            if (e.ColumnIndex == 3)
            {
                Image someImage;
                someImage = Properties.Resources.prescription_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w1 = Properties.Resources.remove_16.Width;
                var h1 = Properties.Resources.remove_16.Height;
                var x1 = e.CellBounds.Left + (e.CellBounds.Width - w1) / 2;
                var y1 = e.CellBounds.Top + (e.CellBounds.Height - h1) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x1, y1, w1, h1));
                e.Handled = true;
            }
        }

        private void DgvPrescriptionWait_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 1)
            {
                Image someImage;
                someImage = Properties.Resources.remove_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.remove_16.Width;
                var h = Properties.Resources.remove_16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 2)
            {
                Image someImage;
                someImage = Properties.Resources.prescription_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w1 = Properties.Resources.remove_16.Width;
                var h1 = Properties.Resources.remove_16.Height;
                var x1 = e.CellBounds.Left + (e.CellBounds.Width - w1) / 2;
                var y1 = e.CellBounds.Top + (e.CellBounds.Height - h1) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x1, y1, w1, h1));
                e.Handled = true;
            }
        }

        private void chkPrescripGroup_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPrescripGroup.CheckState == CheckState.Checked)
            {
                Settings.Default.GroupByPresc = false;
            }
            else
            {
                Settings.Default.GroupByPresc = true;
            }
            this.OnloadDataPrescriptionSelected(r_prescriptionno, strStatusType);
            Settings.Default.Save();
        }

        private void dgvPrescriptionSelected_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellPrescValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void dgvPrescriptionSelected_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 6)
            {
                Image someImage;
                someImage = Properties.Resources.remove_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.remove_16.Width;
                var h = Properties.Resources.remove_16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 7)
            {
                Image someImage;
                someImage = Properties.Resources.reset_16;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.remove_16.Width;
                var h = Properties.Resources.remove_16.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellPrescValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvPrescriptionSelected.AdvancedCellBorderStyle.Top;
            }
        }

        private bool IsTheSameCellPrescValue(int column, int row)
        {
            // To compare only values on 1st and 2nd column (TGL, TRANSAKSI)
            DataGridViewCell cell1 = null;
            DataGridViewCell cell2 = null;
            if (Settings.Default.GroupByPresc == false)
            {
                if (column > 4 || column == 0) return false;
                cell1 = dgvPrescriptionSelected[4, row];
                cell2 = dgvPrescriptionSelected[4, row - 1];
            }
            else
                return false;

            if (cell1.Value == null || cell2.Value == null)
                return false;

            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void chkReview_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReview.CheckState == CheckState.Checked)
                Settings.Default.DisplayAll = true;
            else
                Settings.Default.DisplayAll = false;
            Settings.Default.Save();
        }
    }
}