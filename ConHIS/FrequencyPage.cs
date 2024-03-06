using System;
using System.Collections.Generic;
using ConHIS.Libary_Class;
using ConHIS.Properties;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace ConHIS
{
    public partial class FrequencyPage : Form
    {
        private readonly master_frequencyInfo fre = new master_frequencyInfo();
        private DataSet dsTogrid = null;
        private string SelectStr = "All";
        private int f_id = 0;

        public FrequencyPage()
        {
            InitializeComponent();
        }

        private void FrequencyPage_Load(object sender, EventArgs e)
        {
            LoadDefaultForm();
        }

        private void LoadDefaultForm()
        {
            gbDgvFrequencyList.Enabled = true;
            gbFrequencyDetail.Enabled = false;
            tbFrequencySearch.Clear();
            rbtnAll.Checked = true;
            LoadDataFrequencyInformation();
        }

        private void LoadDataFrequencyInformation()
        {
            try
            {
                dsTogrid = fre.GetDisplayDataGridView(SelectStr, tbFrequencySearch.Text.Trim());
                dgvFrequencySelected.Rows.Clear();
                foreach (DataRow row in dsTogrid.Tables[0].Rows)
                {
                    bool s = false;
                    string frequencycode = row["f_frequencycode"].ToString();
                    string frequencydesc = row["f_frequencydesc"].ToString();
                    string frequencytime = row["f_frequencytime"].ToString();
                    string updatedAt = Convert.ToDateTime(row["updatedAt"]).ToString("yyyy/MM/dd HH:mm:ss");
                    int accept = Convert.ToInt32(row["accept"]);
                    string acceptStatus = "";
                    if (accept == 0)
                        acceptStatus = "Accept";
                    else
                        acceptStatus = "Success";

                    dgvFrequencySelected.Rows.Add(s,acceptStatus, frequencycode, frequencydesc, frequencytime,updatedAt);
                }
                dgvFrequencySelected.CurrentCell = null;
                dgvFrequencySelected.ClearSelection();
            }
            catch (Exception e)
            {
                throw new Exception("Error LoadDataFequencyInformation : " + e.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectStr = "FromBy";
            LoadDataFrequencyInformation();
        }

        private void tbFrequencySearch_TextChanged(object sender, EventArgs e)
        {
            if (tbFrequencySearch.Text.Length == 0)
            {
                SelectStr = "All";
                LoadDataFrequencyInformation();
            }
            else
                SelectStr = "FromBy";
        }

        private void dgvFrequencySelected_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvFrequencySelected.Rows.Count != 0)
            {
                if (e.ColumnIndex == dgvFrequencySelected.Columns[3].Index)
                {
                    SetFormDrugDetail(dgvFrequencySelected.Rows[dgvFrequencySelected.CurrentRow.Index].Cells[3].Value.ToString());
                }
                else if (e.ColumnIndex == dgvFrequencySelected.Columns[1].Index)
                {
                    fre.FrequencyDesc = dgvFrequencySelected.Rows[dgvFrequencySelected.CurrentRow.Index].Cells[3].Value.ToString();
                    fre.Accept = 1;
                    if (fre.UpdateAcceptData() == true)
                    {
                        dgvFrequencySelected.Rows[dgvFrequencySelected.CurrentRow.Index].Cells[1].Value = "Success";
                        dgvFrequencySelected.Rows[dgvFrequencySelected.CurrentRow.Index].Cells[1].ReadOnly = true;
                    }
                }
                   
            }
        }

        private void SetFormDrugDetail(string frequencyCode)
        {
            gbFrequencyDetail.Enabled = true;
            tbFrequencyCode.Enabled = false;
            tbFrequencyDesc.Enabled = false;
            tbFrequencyTime.Enabled = false;
            tbUpdatedAt.Enabled = false;

            DataSet ds = fre.GetDisplayDataDetail(frequencyCode);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                f_id = Convert.ToInt32(row["id"]);
                tbFrequencyCode.Text = row["f_frequencycode"].ToString();
                tbFrequencyDesc.Text = row["f_frequencydesc"].ToString();
                tbFrequencyTime.Text = row["f_frequencytime"].ToString();
                tbUpdatedAt.Text = Convert.ToDateTime(row["updatedAt"]).ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        private void btnEditFrequencyCd_Click(object sender, EventArgs e)
        {
            if (tbFrequencyCode.Text.Length != 0)
            {
                tbFrequencyCode.Enabled = true;
                tbFrequencyCode.Focus();
            }
        }

        private void btnEditFrequencyDesc_Click(object sender, EventArgs e)
        {
            if (tbFrequencyDesc.Text.Length != 0)
            {
                tbFrequencyDesc.Enabled = true;
                tbFrequencyDesc.Focus();
            }
        }

        private void btnEditFrequencyTime_Click(object sender, EventArgs e)
        {
            if (tbFrequencyTime.Text.Length != 0)
            {
                tbFrequencyTime.Enabled = true;
                tbFrequencyTime.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(tbFrequencyCode.Text.Length != 0 && tbFrequencyDesc.Text.Length != 0 && tbFrequencyTime.Text.Length != 0)
            {
                fre.FrequencyCode = tbFrequencyCode.Text;
                fre.FrequencyDesc = tbFrequencyDesc.Text;
                fre.FrequencyTime = tbFrequencyTime.Text;
                if (fre.UpdateDataFrequency(f_id) == true)
                {
                    gbDgvFrequencyList.Enabled = true;
                    gbFrequencyDetail.Enabled = false;
                    tbFrequencyCode.Enabled = false;
                    tbFrequencyCode.Clear();
                    tbFrequencyDesc.Enabled = false;
                    tbFrequencyDesc.Clear();
                    tbFrequencyTime.Enabled = false;
                    tbFrequencyTime.Clear();
                    tbUpdatedAt.Enabled = false;
                    tbUpdatedAt.Clear();
                }
                else
                {
                    if (MessageBox.Show("Update Data ERror.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        gbDgvFrequencyList.Enabled = true;
                        gbFrequencyDetail.Enabled = false;
                        tbFrequencyCode.Enabled = false;
                        tbFrequencyCode.Clear();
                        tbFrequencyDesc.Enabled = false;
                        tbFrequencyDesc.Clear();
                        tbFrequencyTime.Enabled = false;
                        tbFrequencyTime.Clear();
                        tbUpdatedAt.Enabled = false;
                        tbUpdatedAt.Clear();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbDgvFrequencyList.Enabled = true;
            gbFrequencyDetail.Enabled = false;
            tbFrequencyCode.Enabled = false;
            tbFrequencyCode.Clear();
            tbFrequencyDesc.Enabled = false;
            tbFrequencyDesc.Clear();
            tbFrequencyTime.Enabled = false;
            tbFrequencyTime.Clear();
            tbUpdatedAt.Enabled = false;
            tbUpdatedAt.Clear();
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "All";
            tbFrequencySearch.Enabled = false;
            tbFrequencySearch.Clear();
            LoadDataFrequencyInformation();
        }

        private void rbtnNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "New";
            tbFrequencySearch.Enabled = false;
            tbFrequencySearch.Clear();
            LoadDataFrequencyInformation();
        }
    }
}
