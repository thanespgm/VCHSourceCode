using Microsoft.SqlServer.Management.Smo;
using System;
using System.Data.Sql;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class DatabaSepage : UserControl
    {
        protected string _servername;
        protected string _databasename;
        protected string _username;
        protected string _password;
        protected string _asynchronous_processing;
        protected string _connecttion_timeout;
        protected string _datasource;

        public DatabaSepage()
        {
            InitializeComponent();
        }

        private void DatabaSepage_Load(object sender, EventArgs e)
        {
            Server_config s = new Server_config();
            if (s.CheckDictoryFileConfig() == true)
            {
                this.LoadServerConfig();
            }
            else
            {
                this.LoadFormDefault();
            }
        }

        private void LoadFormDefault()
        {
            if (this.CbServerName.Text == "")
            {
                this.CbAuthentication.SelectedIndex = 1;
                this.CbAuthentication.Enabled = false;
                this.tbUserName.Text = "";
                this.tbUserName.Enabled = false;
                this.tbPassword.Text = "";
                this.tbPassword.Enabled = false;
                this.chkSavePassword.Checked = false;
                this.chkSavePassword.Enabled = false;
                this.CbDatabaseName.Text = "";
                this.gb_ConnectDatabase.Enabled = false;
                this.BtnTestConnection.Enabled = false;
                this.BtnApply.Enabled = false;
            }
            else
            {
                this.CbAuthentication.Enabled = true;
                this.gb_ConnectDatabase.Enabled = true;
                this.BtnTestConnection.Enabled = true;
                this.BtnApply.Enabled = true;
            }
        }

        private void CbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CbAuthentication.SelectedIndex == 0)
            {
                this.tbUserName.Text = "";
                this.tbUserName.Enabled = true;
                this.tbPassword.Text = "";
                this.tbPassword.Enabled = true;
                this.chkSavePassword.Checked = false;
                this.chkSavePassword.Enabled = true;
            }
            else
            {
                this.tbUserName.Text = "";
                this.tbUserName.Enabled = false;
                this.tbPassword.Text = "";
                this.tbPassword.Enabled = false;
                this.chkSavePassword.Checked = false;
                this.chkSavePassword.Enabled = false;
            }
        }

        private void LoadServerConfig()
        {
            Server_config s = new Server_config();
            if (s.Readdatabase_config() == true)
            {
                this.CbServerName.Text = s.ServerNameLocal;
                if ((s.UserNameLocal != "") && (s.PassWordLocal != ""))
                {
                    this.CbAuthentication.SelectedIndex = 0;
                    this.tbUserName.Text = s.UserNameLocal;
                    this.tbUserName.Enabled = true;
                    this.tbPassword.Text = s.PassWordLocal;
                    this.tbPassword.Enabled = true;
                    this.chkSavePassword.Checked = true;
                }
                else
                {
                    this.CbAuthentication.SelectedIndex = 1;
                    this.tbUserName.Text = "";
                    this.tbUserName.Enabled = true;
                    this.tbPassword.Text = "";
                    this.tbPassword.Enabled = true;
                }
                this.CbDatabaseName.Text = s.DatabaseLocal;
                if ((s.StatusLocal == "True") || (s.StatusLocal == "true"))
                {
                    this.chk_OnConnectHost.Checked = true;
                }
                else
                {
                    this.chk_OnConnectHost.Checked = false;
                }
                this.tbConnecttimeout.Text = s.ConnectTimeOutLocal;
                if ((s.AsynchronousLocal == "True") || (s.AsynchronousLocal == "true"))
                {
                    this.EnableAsync.Checked = true;
                    this.DisableAsync.Checked = false;
                }
                else
                {
                    this.DisableAsync.Checked = true;
                    this.EnableAsync.Checked = false;
                }
                this.BtnTestConnection.Enabled = true;
                this.BtnApply.Enabled = true;
            }
        }

        private void CbServerName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                System.Data.DataTable table = instance.GetDataSources();
                this.CbServerName.Items.Clear();
                foreach (System.Data.DataRow row in table.Rows)
                {
                    string serverInstance = "";
                    string servername = String.Format("{0}", row["ServerName"].ToString());
                    if (row["InstanceName"].ToString() != "")
                    {
                        serverInstance = String.Format("{0}\\{1}", row["ServerName"].ToString(), row["InstanceName"].ToString());
                    }
                    else
                    {
                        serverInstance = servername;
                    }

                    this.CbServerName.Items.Add(serverInstance);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CbServerName.Text != "")
            {
                this.LoadFormDefault();
            }
        }

        private void CbDatabaseName_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.CbDatabaseName.Items.Clear();
                string servername = this.CbServerName.Text.ToString();
                Microsoft.SqlServer.Management.Common.ServerConnection serverconnection = new Microsoft.SqlServer.Management.Common.ServerConnection
                {
                    ServerInstance = servername,
                    LoginSecure = true
                };
                if (this.CbAuthentication.SelectedIndex == 0)
                {
                    serverconnection.LoginSecure = false;
                    serverconnection.Login = this.tbUserName.Text;
                    serverconnection.Password = this.tbPassword.Text;
                }
                Server server = new Server(serverconnection);
                try
                {
                    foreach (Database database in server.Databases)
                    {
                        this.CbDatabaseName.Items.Add(database.Name);
                    }
                    this.Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    string exception = ex.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                _servername = this.CbServerName.Text.ToString().Trim();
                _databasename = this.CbDatabaseName.Text.ToString().Trim();
                if (this.EnableAsync.Checked == true)
                {
                    _asynchronous_processing = "true";
                }
                else if (this.DisableAsync.Checked == true)
                {
                    _asynchronous_processing = "false";
                }
                if (this.tbConnecttimeout.Text != "")
                {
                    try
                    {
                        int temp = Convert.ToInt32(this.tbConnecttimeout.Text);
                        _connecttion_timeout = this.tbConnecttimeout.Text.Trim();
                    }
                    catch
                    {
                        this.tbConnecttimeout.Text = "0";
                        _connecttion_timeout = this.tbConnecttimeout.Text.Trim();
                    }
                }
                else
                {
                    this.tbConnecttimeout.Text = "0";
                    _connecttion_timeout = this.tbConnecttimeout.Text.Trim();
                }
                if (this.CbAuthentication.SelectedIndex == 0)
                {
                    _username = this.tbUserName.Text.ToString().Trim();
                    _password = this.tbPassword.Text.ToString().Trim();
                    _datasource = "Data Source=" + _servername + ";Initial Catalog=" + _databasename + ";;Persist Security Info=True;User ID=" + _username + ";Password=" + _password + ";Asynchronous Processing=" + _asynchronous_processing + ";Connect Timeout=" + _connecttion_timeout;
                }
                else
                {
                    _datasource = "Data Source=" + _servername + ";Initial Catalog=" + _databasename + ";Integrated Security=True;Asynchronous Processing=" + _asynchronous_processing + ";Connect Timeout=" + _connecttion_timeout;
                }

                this.SaveConfig();

                Connection_sqlserver conn = new Connection_sqlserver(_datasource);
                if (conn.ConnStatus() == true)
                {
                    MessageBox.Show("Connection successful.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Connection failed.", "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            this.SaveConfig();
        }

        private void SaveConfig()
        {
            Server_config sc = new Server_config();
            try
            {
                if (this.chk_OnConnectHost.Checked == true)
                {
                    sc.StatusLocal = "True";
                }
                else
                {
                    sc.StatusLocal = "False";
                }
                sc.ServerNameLocal = this.CbServerName.Text.ToString().Trim();
                sc.DatabaseLocal = this.CbDatabaseName.Text.ToString().Trim();
                if (this.EnableAsync.Checked == true)
                {
                    sc.AsynchronousLocal = "true";
                }
                else if (this.DisableAsync.Checked == true)
                {
                    sc.AsynchronousLocal = "false";
                }
                if (this.tbConnecttimeout.Text != "")
                {
                    try
                    {
                        int temp = Convert.ToInt32(this.tbConnecttimeout.Text);
                        sc.ConnectTimeOutLocal = this.tbConnecttimeout.Text.Trim();
                    }
                    catch
                    {
                        this.tbConnecttimeout.Text = "0";
                        sc.ConnectTimeOutLocal = this.tbConnecttimeout.Text.Trim();
                    }
                }
                else
                {
                    this.tbConnecttimeout.Text = "0";
                    sc.ConnectTimeOutLocal = this.tbConnecttimeout.Text.Trim();
                }
                if (this.CbAuthentication.SelectedIndex == 0)
                {
                    sc.UserNameLocal = this.tbUserName.Text.ToString().Trim();
                    sc.PassWordLocal = this.tbPassword.Text.ToString().Trim();
                }
                else
                {
                    sc.UserNameLocal = "";
                    sc.PassWordLocal = "";
                }

                if (sc.Writedatabase_Local_config() == true)
                {
                    this.BtnApply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}