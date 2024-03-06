using ConHIS.Libary_Class;
using ConHIS.Properties;
using System;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class GeneralPage : UserControl
    {
        public GeneralPage()
        {
            InitializeComponent();
        }

        private void GeneralPage_Load(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        private void LoadSettings()
        {
            this.Chk_StartOnProgram.Checked = Settings.Default.onStartLoadtext;

            switch (Settings.Default.onInterfaceMode)
            {
                case "BDMS":
                    cbSiteName.SelectedIndex = 1;
                    break;
                case "CHULABHORN":
                    cbSiteName.SelectedIndex = 6;
                    break;
                case "HOSXP":
                    cbSiteName.SelectedIndex = 1;
                    break;
                case "HUACHIEW":
                    cbSiteName.SelectedIndex = 4;
                    break;
                case "VICHAIYUT":
                    cbSiteName.SelectedIndex = 5;
                    break;
                case "PCMC_OPD_HL7":
                    cbSiteName.SelectedIndex = 3;
                    break;
                case "SUTH_IPD_HL7":
                    cbSiteName.SelectedIndex = 2;
                    break;
                case "PNNH_IPD_HL7":
                    cbSiteName.SelectedIndex = 7;
                    break;
                case "SKPH_IPD_HL7":
                    cbSiteName.SelectedIndex = 8;
                    break;
            }
            //if (Settings.Default.onInterfaceMode == "TEXTFILE")
            //{
            //    RbtnTextFile.Checked = true;
            //    RbtnHosXP.Checked = false;
            //    RbtnHosXP_HL7.Checked = false;
            //    RbtnVICHAIYUT.Checked = false;
            //}
            //else if (Settings.Default.onInterfaceMode == "HOSXP")
            //{
            //    RbtnTextFile.Checked = false;
            //    RbtnHosXP.Checked = true;
            //    RbtnHosXP_HL7.Checked = false;
            //    RbtnVICHAIYUT.Checked = false;
            //}
            //else if (Settings.Default.onInterfaceMode == "VICHAIYUT")
            //{
            //    RbtnTextFile.Checked = false;
            //    RbtnHosXP.Checked = false;
            //    RbtnHosXP_HL7.Checked = false;
            //    RbtnVICHAIYUT.Checked = true;
            //}
            //else if (Settings.Default.onInterfaceMode == "HOSXP_HL7")
            //{
            //    RbtnTextFile.Checked = false;
            //    RbtnHosXP.Checked = false;
            //    RbtnHosXP_HL7.Checked = true;
            //    RbtnVICHAIYUT.Checked = false;
            //}
            this.TbSeparatorPattren.Text = Settings.Default.SeparatorPattren.ToString();
            this.TbTmtoRetrieve.Text = Settings.Default.TmtoRetrieve.ToString();
            this.TbReadFileWait.Text = Settings.Default.ReadFileWait.ToString();
            this.CbEncode_SeparatorPattren.SelectedIndex = Settings.Default.Encode_Separator;

            //tab connect MySQL for HosXP
            switch (Settings.Default.serverDBType)
            {
                case "SQL":
                    this.cbServerDBType.SelectedIndex = 0;
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล SQL Server";
                    break;

                case "MySQL":
                    this.cbServerDBType.SelectedIndex = 1;
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล MySQL Server";
                    break;

                case "PGSQL":
                    this.cbServerDBType.SelectedIndex = 2;
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล ProstgreSQL";
                    break;
            }
          
            this.tbServerName.Text = Settings.Default.serverNameMySQL;
            this.tbPort.Text = Settings.Default.portConn;
            this.tbDatabaseName.Text = Settings.Default.dbNameMySQL;
            this.tbUserName.Text = Settings.Default.userNameMySQL;
            this.tbPassword.Text = Settings.Default.passWordMySQL;

            if (Settings.Default.onRelationMachine)
            {
                this.Chk_StartRelationMachine.Checked = true;
                this.gbDatabaseCondition.Enabled = true;
                this.TbDaysDelete.Text = Settings.Default.onDelete.ToString();
            }
            else
            {
                this.Chk_StartRelationMachine.Checked = false;
                this.gbDatabaseCondition.Enabled = false;
                this.TbDaysDelete.Text = "0";
            }
            this.tbStartOrderContinue.Text = Settings.Default.StartOrderStanding.ToString();

            if(Settings.Default.SyncSMT == true)
                chkSyncSMT.Checked = true;
            else
                chkSyncSMT.Checked = false;

            if (Settings.Default.DTATray == true)
                chkDTATray.Checked = true;
            else
                chkDTATray.Checked = false;
        }

        private void Chk_StartOnProgram_CheckedChanged(object sender, EventArgs e)
        {
            switch (Chk_StartOnProgram.Checked)
            {
                case true:
                    Settings.Default.onStartLoadtext = true;
                    break;

                default:
                    Settings.Default.onStartLoadtext = false;
                    break;
            }
            Settings.Default.Save();
        }

        private void Chk_StartOnWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Chk_StartOnWindows.Checked)
            {
            }
            else
            {
            }
        }

        private void TbSeparatorPattren_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.SeparatorPattren = Convert.ToChar(TbSeparatorPattren.Text);
            Settings.Default.Save();
        }

        private void TbTmtoRetrieve_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.TbTmtoRetrieve.Text.Trim(), out int tm))
            {
                Settings.Default.TmtoRetrieve = tm;
                Settings.Default.Save();
            }
        }

        private void TbReadFileWait_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.TbReadFileWait.Text.Trim(), out int tm))
            {
                Settings.Default.ReadFileWait = tm;
                Settings.Default.Save();
            }
        }

        private void CbEncode_SeparatorPattren_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.CbEncode_SeparatorPattren.SelectedIndex)
            {
                case 0:
                    Settings.Default.Encode_Separator = 0;
                    break;

                case 1:
                    Settings.Default.Encode_Separator = 1;
                    break;

                case 2:
                    Settings.Default.Encode_Separator = 2;
                    break;
            }
            Settings.Default.Save();
        }

        private void Chk_StartRelationMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Chk_StartRelationMachine.Checked)
            {
                Settings.Default.onRelationMachine = true;
                this.gbDatabaseCondition.Enabled = true;
            }
            else
            {
                Settings.Default.onRelationMachine = false;
                this.gbDatabaseCondition.Enabled = false;
            }
            Settings.Default.Save();
        }

        private void TbDaysDelete_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.TbDaysDelete.Text.Trim(), out int tm))
            {
                Settings.Default.onDelete = tm;
                Settings.Default.Save();
            }
        }

        private void BtnTestConnect_Click(object sender, EventArgs e)
        {
            if ((tbServerName.Text != "") && (tbDatabaseName.Text != "") && (tbUserName.Text != ""))
            {
                switch (Settings.Default.serverDBType)
                {
                    case "SQL":
                        string SQLconnstring = string.Format("Data Source={0};Initial Catalog={1};;Persist Security Info=True;User ID={2};Password={3};Asynchronous Processing=True;Connect Timeout=100", tbServerName.Text, tbDatabaseName.Text, tbUserName.Text, tbPassword.Text);
                        Connection_sqlserver connSQL = new Connection_sqlserver(SQLconnstring);

                        if (connSQL.ConnStatus())
                        {
                            MessageBox.Show("Connection successful.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings.Default.serverNameMySQL = tbServerName.Text.Trim();
                            Settings.Default.dbNameMySQL = tbDatabaseName.Text.Trim();
                            Settings.Default.userNameMySQL = tbUserName.Text.Trim();
                            Settings.Default.passWordMySQL = tbPassword.Text.Trim();
                            Settings.Default.connMySQL = SQLconnstring;
                            Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "MySQL":
                        string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3} ;", tbServerName.Text, tbDatabaseName.Text, tbUserName.Text, tbPassword.Text);
                        Connection_mysqlserver conn = new Connection_mysqlserver(connstring);

                        if (conn.ConnStatus())
                        {
                            MessageBox.Show("Connection successful.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings.Default.serverNameMySQL = tbServerName.Text.Trim();
                            Settings.Default.dbNameMySQL = tbDatabaseName.Text.Trim();
                            Settings.Default.userNameMySQL = tbUserName.Text.Trim();
                            Settings.Default.passWordMySQL = tbPassword.Text.Trim();
                            Settings.Default.connMySQL = connstring;
                            Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    case "PGSQL":
                        string PGconnstring = string.Format("Server={0}; Port={1}; User ID={2}; password={3}; database={4}; Encoding=UTF8;", tbServerName.Text, tbPort.Text, tbUserName.Text, tbPassword.Text, tbDatabaseName.Text);
                        Connection_pgsqlserver PGconn = new Connection_pgsqlserver(PGconnstring);

                        if (PGconn.ConnStatus())
                        {
                            MessageBox.Show("Connection successful.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings.Default.serverNameMySQL = tbServerName.Text.Trim();
                            Settings.Default.portConn = tbPort.Text.Trim();
                            Settings.Default.dbNameMySQL = tbDatabaseName.Text.Trim();
                            Settings.Default.userNameMySQL = tbUserName.Text.Trim();
                            Settings.Default.passWordMySQL = tbPassword.Text.Trim();
                            Settings.Default.connMySQL = PGconnstring;
                            Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("Connection failed.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }

        private void CbServerDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbServerDBType.SelectedIndex)
            {
                case 0:
                    Settings.Default.serverDBType = "SQL";
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล SQL Server";
                    break;

                case 1:
                    Settings.Default.serverDBType = "MySQL";
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล MySQL Server";
                    break;

                case 2:
                    Settings.Default.serverDBType = "PGSQL";
                    gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล ProstgreSQL";
                    break;
            }
            Settings.Default.Save();
        }

        private void cbSiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSiteName.SelectedIndex)
            {
                case 0:
                    Settings.Default.onInterfaceMode = "";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 1:
                    Settings.Default.onInterfaceMode = "BDMS";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 2:
                    Settings.Default.onInterfaceMode = "SUTH_IPD_HL7";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 3:
                    Settings.Default.onInterfaceMode = "PCMC_OPD_HL7";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 4:
                    Settings.Default.onInterfaceMode = "HUACHIEW";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 5:
                    Settings.Default.onInterfaceMode = "VICHAIYUT";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 6:
                    Settings.Default.onInterfaceMode = "CHULABHORN";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 7:
                    Settings.Default.onInterfaceMode = "PNNH_IPD_HL7";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
                case 8:
                    Settings.Default.onInterfaceMode = "SKPH_IPD_HL7";
                    TCInterfaceFormatMode.SelectedIndex = 1;
                    break;
            }
            Settings.Default.Save();
        }

        private void chkSyncSMT_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSyncSMT.Checked)
                Settings.Default.SyncSMT = true;
            else
                Settings.Default.SyncSMT = false;
            Settings.Default.Save();
        }

        private void chkDTATray_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDTATray.Checked)
                Settings.Default.DTATray = true;
            else
                Settings.Default.DTATray = false;
            Settings.Default.Save();
        }

        private void tbStartOrderContinue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(this.tbStartOrderContinue.Text.Trim(), out int tm))
            {
                Settings.Default.StartOrderStanding = tm;
                Settings.Default.Save();
            }
        }
    }
}