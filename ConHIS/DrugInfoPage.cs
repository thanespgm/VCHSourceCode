using System;
using System.Collections.Generic;
using ConHIS.Libary_Class;
using ConHIS.Properties;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ConHIS.Libary_Class.CRAInterface.Features;

namespace ConHIS
{
    public partial class DrugInfoPage : Form
    {

        private readonly master_druginfomation dr = new master_druginfomation();

        private readonly master_prescription pres;

        private readonly Thaneshopmiddle_ATPM th;

        private readonly ArrayList r_drug = new ArrayList();

        private DataSet dsTogrid = null;
        private string SelectStr = "All";

        public DrugInfoPage()
        {
            InitializeComponent();
            pres = new master_prescription();
            th = new Thaneshopmiddle_ATPM();
        }

        private void DrugInfoPage_Load(object sender, EventArgs e)
        {
            LoadDefaultForm();
           
        }

        private void LoadDefaultForm()
        {
            gbDgvDrugList.Enabled = true;
            gbDrugDetail.Enabled = false;
            rbtnAll.Checked = true;
            LoadDataDrugInformation();
            GetCountDataCheck();
        }

        private void GetCountDataCheck()
        {
            int all = dr.GetDisplayDataGridView("All", "").Tables[0].Rows.Count;
            int machine = dr.GetDisplayDataGridView("Machine", "").Tables[0].Rows.Count;
            int newdrug = dr.GetDisplayDataGridView("New","").Tables[0].Rows.Count;
            rbtnAll.Text = String.Format("ยืนยันแล้ว ({0} รายการ)",all);
            rbtnMachine.Text = String.Format("Machine ({0} รายการ)", machine);
            rbtnNewOrder.Text = String.Format("รายการใหม่ ({0} รายการ)", newdrug);
        }

        private void LoadDataDrugInformation()
        {
            try
            {
                dsTogrid = dr.GetDisplayDataGridView(SelectStr, tbDrugSearch.Text.Trim());
                dgvDrugSelected.Rows.Clear();
                foreach (DataRow row in dsTogrid.Tables[0].Rows)
                {
                    bool s = false;
                    string orderitemcode = row["f_orderitemcode"].ToString();
                    string orderitemsname = row["f_orderitemname"].ToString();
                    string orderunitdesc = row["f_orderunitdesc"].ToString();
                    int tomachineno = Convert.ToInt32(row["f_tomachineno"]);
                    int accept = Convert.ToInt32(row["accept"]);

                    string machine_location = "";
                    string pathDispense = "";
                    string acceptStatus = "";

                    if (tomachineno == 0)
                    {
                        machine_location = "จัดยาจากห้องยา";
                        pathDispense = "จัดยาจากห้องยา";
                    }
                    else if(tomachineno == 2)
                    {
                        machine_location = "โรบอทจัดยา PROUD";
                        pathDispense = "จัดยาจากโรบอท";
                    }
                    else if (tomachineno == 4)
                    {
                        machine_location = "หยด DTA PROUD";
                        pathDispense = "จัดยาด้วย DTA";
                    }

                    if (accept == 0)
                        acceptStatus = "Accept";
                    else
                        acceptStatus = "Success";
                    dgvDrugSelected.Rows.Add(s, pathDispense, acceptStatus, orderitemcode, orderitemsname, orderunitdesc, machine_location);
                }
                dgvDrugSelected.CurrentCell = null;
                dgvDrugSelected.ClearSelection();
            }catch(Exception e)
            {
                throw new Exception("Error LoadDataDrugInformation : " + e.Message);
            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "All"; 
            tbDrugSearch.Enabled = false;
            tbDrugSearch.Clear();
            LoadDataDrugInformation();
            GetCountDataCheck();

        }

        private void rbtnMachine_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "Machine";
            tbDrugSearch.Enabled = false;
            tbDrugSearch.Clear();
            LoadDataDrugInformation();
            GetCountDataCheck();
        }

        private void rbtnNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "New";
            tbDrugSearch.Enabled = false;
            tbDrugSearch.Clear();
            LoadDataDrugInformation();
            GetCountDataCheck();
        }

        private void rbtnSerachBy_CheckedChanged(object sender, EventArgs e)
        {
            SelectStr = "FromBy";
            tbDrugSearch.Enabled = true;
            tbDrugSearch.Clear();
            tbDrugSearch.Focus();
            LoadDataDrugInformation();
            GetCountDataCheck();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataDrugInformation();
            GetCountDataCheck();
        }

        private void dgvDrugSelected_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(dgvDrugSelected.Rows.Count != 0)
            {
                if (e.ColumnIndex == dgvDrugSelected.Columns[0].Index)
                {
                    if(Convert.ToBoolean(dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[0].Value) == true)
                    {
                        r_drug.Remove(dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[3].Value.ToString());
                    }
                    else
                    {
                        r_drug.Add(dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[3].Value.ToString());
                    }
                }

                if (e.ColumnIndex == dgvDrugSelected.Columns[3].Index)
                {
                    SetFormDrugDetail(dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[3].Value.ToString());
                }
                else if(e.ColumnIndex == dgvDrugSelected.Columns[2].Index)
                {
                    string SelectedText = dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[1].Value.ToString();
                    //int SelectedVal = Convert.ToInt32(dgvDrugSelected.Rows[0].Cells["tomachineno"].Value);
                    int machineDispense = 0;
                    if (SelectedText == "จัดยาจากโรบอท")
                        machineDispense = 2; 
                    else if (SelectedText == "จัดยาจากห้องยา")
                        machineDispense = 0;
                    else if (SelectedText == "จัดยาด้วย DTA")
                        machineDispense = 4;
                    dr.OrderItemCode = dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[3].Value.ToString();
                    dr.Accept = 1;
                    if (dr.UpdateAcceptData() == true)
                    {
                        dr.UpdateDataToMachineNo(machineDispense);
                        dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[2].Value = "Success";
                        dgvDrugSelected.Rows[dgvDrugSelected.CurrentRow.Index].Cells[2].ReadOnly = true;
                    }
                }
            }
        }
        private void SetFormDrugDetail(string ordertiemsCode)
        {
            gbDrugDetail.Enabled = true;

            tbDrugCode.Enabled = false;
            tbDrugComerceName.Enabled = false;
            tbDrugGenericName.Enabled = false;
            tbDrugPrintName.Enabled = false;
            tbDrugBarcode.Enabled = false;
           // cbToMacnineName.SelectedIndex = 0;
            rbtnInstructionFromHIS.Checked = true;
            //cbInstructionCode.SelectedIndex = 0;
            tbInstructionName.Enabled = false;
            rbtnFrequencyFromHIS.Checked = true;
            //cbFrequencyName.SelectedIndex = 0;
            tbFrequencyTime.Enabled = false;
            tbDrugLabel.Enabled = false;
            tbUpdatedAt.Enabled = false;

            DataSet ds = dr.GetDisplayDataDetail(ordertiemsCode);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                tbDrugCode.Text = row["f_orderitemcode"].ToString();
                tbDrugComerceName.Text = row["f_orderitemname"].ToString();
                tbDrugGenericName.Text = row["f_orderitmename_generic"].ToString();
                tbDrugPrintName.Text = row["f_orderitmename_print"].ToString();
                tbDrugBarcode.Text = row["f_orderitem_barcode"].ToString();
                if (Convert.ToInt32(row["f_instruction_activefrom"]) == 0)
                    rbtnInstructionFromHIS.Checked = true;
                else
                    rbtnInstructionFromMasterInterface.Checked = true;
                tbInstructionName.Text = row["f_instructiondesc"].ToString();
                if (Convert.ToInt32(row["f_frequency_activefrom"]) == 0)
                    rbtnFrequencyFromHIS.Checked = true;
                else
                    rbtnFrequencyFromMasterInterface.Checked = true;
                tbFrequencyTime.Text = row["f_frequencytime"].ToString();
                tbDrugLabel.Text = row["f_druglabel"].ToString();
                tbUpdatedAt.Text = Convert.ToDateTime(row["updatedAt"]).ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        private void btnDrugInstruction_Click(object sender, EventArgs e)
        {
            InstructionPage ins = new InstructionPage
            {
                WindowState = FormWindowState.Maximized
            };
            ins.Show();
        }

        private void btnDrugFrequency_Click(object sender, EventArgs e)
        {
            FrequencyPage fre = new FrequencyPage
            {
                WindowState = FormWindowState.Maximized
            };
            fre.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState == CheckState.Checked)
            {
                foreach (DataGridViewRow row in this.dgvDrugSelected.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        row.Cells[0].Value = true;
                        r_drug.Add(row.Cells[3].Value.ToString().Trim());
                    }
                }
            }
            else
            {
                r_drug.Clear();
                foreach (DataGridViewRow row in this.dgvDrugSelected.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[0].Value = false;
                    }
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(r_drug.Count != 0)
            {
                int tomachine = 0;
                dr.Accept = 1;
                if (cbSelectPath.Text == "จัดยาจากโรบอท")
                    tomachine = 2;
                else if (cbSelectPath.Text == "จัดยาจากห้องยา")
                    tomachine = 0;
                else if (cbSelectPath.Text == "จัดยาด้วย DTA")
                    tomachine = 4;
               

                foreach(string orderitemCode in r_drug)
                {
                    dr.OrderItemCode = orderitemCode;
                    if (dr.UpdateAcceptData() == true)
                    {
                        dr.UpdateDataToMachineNo(tomachine);
                    }
                }
                tbDrugSearch.Enabled = true;
                tbDrugSearch.Clear();
                tbDrugSearch.Focus();
                LoadDataDrugInformation();
                GetCountDataCheck();
            }
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
           if(pres.DeleteByHnReady() == true)
            {
                th.UpdateDispenseStatusDataThanesMiddle(0);

                DataSet ds = pres.GetDisplayDataGridViewFullDetail(null);
                foreach(DataRow presno in ds.Tables[0].Rows)
                {
                    th.UpdateDispenseStatusDataThanesMiddle(presno["f_prescriptionno"].ToString(),1);
                }

                ClassifyMedication_Cra classifyMedication = new ClassifyMedication_Cra();
                classifyMedication.ClassifyOnLoadAsync();
                classifyMedication.GenSeqOfMaxAsync();

                MessageBox.Show("Success");
            }          
        }
    }
}
