using ConHIS.Libary_Class.CRAInterface;
using ConHIS.Libary_Class.CRAInterface.Features;
using ConHIS.Properties;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.AddUserControlMode();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text += "    " + Settings.Default.VersionConhis.ToString() ;
           tbRestUrl.Text = Settings.Default.RestURL;
            //Settings.Default.VersionConhis.ToString();
            if(Settings.Default.ClientMode == true)
            {
                this.Hide();
                PrescriptionPage pres = new PrescriptionPage
                {
                    WindowState = FormWindowState.Maximized,
                    TopLevel = true
                };
                pres.Show();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }

        public void AddUserControlMode()
        {
            HomePage H_uc = new HomePage();
            this.CheckedUsercontrol(H_uc);
            
        }

        public void CheckedUsercontrol(UserControl ucl)
        {
            if (this.pnMainForm != null)
            {
                ucl.Anchor = AnchorStyles.Top;
                //ucl.Dock = DockStyle.Fill;
                this.pnMainForm.Controls.Clear();
                this.pnMainForm.Controls.Add(ucl);
            }
            else
            {
                ucl.Anchor = AnchorStyles.Top;
                //ucl.Dock = DockStyle.Fill;
                this.pnMainForm.Controls.Add(ucl);
            }

           
           
        }

        #region"JSON Functions"

        public void DeserialiseJSON(string strJSON)
        {
            try
            {
                var jOperator = JsonConvert.DeserializeObject<dynamic>(strJSON).data;
                Settings.Default.AccessToken = jOperator.token;
                Settings.Default.Save();
                Settings.Default.Reload();

                DebugOutput("Here's our JSON object: " + jOperator.ToString());
                DebugOutput("Access Token: " + jOperator.token);
            }
            catch (Exception ex)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(ex.Message);
                DebugOutput("Problem: " + ErrorMessage.errorMessage);
            }
        }

        #endregion

        #region "Debug Output"

        public async Task DebugOutput(string strDebugText)
        {
            TxtResponse.ResetText();
            try
            {
                await Task.Run(()=> TxtResponse.ForeColor = Color.Green);
                System.Diagnostics.Debug.Write(strDebugText);
                await Task.Run(() => TxtResponse.Text = strDebugText);
            }
            catch (Exception ex)
            {
                await Task.Run(() => TxtResponse.ForeColor = Color.Red);
                System.Diagnostics.Debug.Write(ex.Message);
            }
        }

        #endregion "Debug Output"

        private async  void btnGetAll_Click(object sender, EventArgs e)
        {
          
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTimeTable_Click(object sender, EventArgs e)
        {
            //TimeTableForm timeTable = new TimeTableForm();
            //timeTable.ShowDialog();
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            //ClassifyMedication classifyMedication = new ClassifyMedication();
            //classifyMedication.GenSeqOfMax();
        }

        private void tbRestUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}