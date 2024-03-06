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
    public partial class InstructionPage : Form
    {
        private readonly master_instruction ins = new master_instruction();
        private DataSet dsTogrid = null;
        private string SelectStr = "All";
        private int f_id = 0;

        public InstructionPage()
        {
            InitializeComponent();
        }

        private void InstructionPage_Load(object sender, EventArgs e)
        {
            LoadDefaultForm();
        }

        private void LoadDefaultForm()
        {
            gbDgvInstructionList.Enabled = true;
            gbInstructionDetail.Enabled = false;
            tbInstructionSearch.Clear();
            LoadDataInstructionInformation();
        }

        private void LoadDataInstructionInformation()
        {
            try
            {
                dsTogrid = ins.GetDisplayDataGridView(SelectStr, tbInstructionSearch.Text.Trim());
                dgvInstructionSelected.Rows.Clear();
                foreach (DataRow row in dsTogrid.Tables[0].Rows)
                {
                    bool s = false;
                    string instructioncode = row["f_instructioncode"].ToString();
                    string instructiondesc = row["f_instructiondesc"].ToString();
                    string updatedAt = Convert.ToDateTime(row["updatedAt"]).ToString("yyyy/MM/dd HH:mm:ss");
                    dgvInstructionSelected.Rows.Add(s, instructioncode, instructiondesc, updatedAt);
                }
                dgvInstructionSelected.CurrentCell = null;
                dgvInstructionSelected.ClearSelection();
            }
            catch (Exception e)
            {
                throw new Exception("Error LoadDataInstructionInformation : " + e.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SelectStr = "FromBy";
            LoadDataInstructionInformation();
        }

        private void tbInstructionSearch_TextChanged(object sender, EventArgs e)
        {
            if(tbInstructionSearch.Text.Length == 0)
            {
                SelectStr = "All";
                LoadDataInstructionInformation();
            }  
            else
                SelectStr = "FromBy";
        }

        private void dgvInstructionSelected_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgvInstructionSelected.Rows.Count != 0)
            {
                SetFormDrugDetail(dgvInstructionSelected.Rows[dgvInstructionSelected.CurrentRow.Index].Cells[1].Value.ToString());
            }
        }

        private void SetFormDrugDetail(string instructionCode)
        {
            gbInstructionDetail.Enabled = true;
            tbInstructionCode.Enabled = false;
            tbInstructionDesc.Enabled = false;
            tbUpdatedAt.Enabled = false;

            DataSet ds = ins.GetDisplayDataDetail(instructionCode);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                f_id = Convert.ToInt32(row["id"]);
                tbInstructionCode.Text = row["f_instructioncode"].ToString();
                tbInstructionDesc.Text = row["f_instructiondesc"].ToString();
                tbUpdatedAt.Text = Convert.ToDateTime(row["updatedAt"]).ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        private void btnEditInstructionCd_Click(object sender, EventArgs e)
        {
            if(tbInstructionCode.Text.Length != 0)
            {
                tbInstructionCode.Enabled = true;
                tbInstructionCode.Focus();
            }
        }

        private void btnEditInstructionDesc_Click(object sender, EventArgs e)
        {
            if(tbInstructionDesc.Text.Length != 0)
            {
                tbInstructionDesc.Enabled = true;
                tbInstructionDesc.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(tbInstructionCode.Text.Length != 0 && tbInstructionDesc.Text.Length != 0)
            {
                ins.InstructionCode = tbInstructionCode.Text;
                ins.InstructionDesc = tbInstructionDesc.Text;
                if (ins.UpdateDataInstruction(f_id) == true)
                {
                    gbDgvInstructionList.Enabled = true;
                    gbInstructionDetail.Enabled = false;
                    tbInstructionCode.Enabled = false;
                    tbInstructionCode.Clear();
                    tbInstructionDesc.Enabled = false;
                    tbInstructionDesc.Clear();
                    tbUpdatedAt.Enabled = false;
                    tbUpdatedAt.Clear();
                }
                else
                {
                    if (MessageBox.Show("Update Data ERror.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        gbDgvInstructionList.Enabled = true;
                        gbInstructionDetail.Enabled = false;
                        tbInstructionCode.Enabled = false;
                        tbInstructionCode.Clear();
                        tbInstructionDesc.Enabled = false;
                        tbInstructionDesc.Clear();
                        tbUpdatedAt.Enabled = false;
                        tbUpdatedAt.Clear();
                    }
                }
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbDgvInstructionList.Enabled = true;
            gbInstructionDetail.Enabled = false;
            tbInstructionCode.Enabled = false;
            tbInstructionCode.Clear();
            tbInstructionDesc.Enabled = false;
            tbInstructionDesc.Clear();
            tbUpdatedAt.Enabled = false;
            tbUpdatedAt.Clear();
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "All";
            tbInstructionSearch.Enabled = false;
            tbInstructionSearch.Clear();
            LoadDataInstructionInformation();
        }

        private void rbtnNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "New";
            tbInstructionSearch.Enabled = false;
            tbInstructionSearch.Clear();
            LoadDataInstructionInformation();
        }
    }
}
