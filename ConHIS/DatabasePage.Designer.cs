namespace ConHIS
{
    partial class DatabaSepage
    {
        /// <summary> 
        /// Required designer Variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chk_OnConnectHost = new System.Windows.Forms.CheckBox();
            this.gb_LogOnServer = new System.Windows.Forms.GroupBox();
            this.CbServerName = new System.Windows.Forms.ComboBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.CbAuthentication = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CbDatabaseName = new System.Windows.Forms.ComboBox();
            this.gb_ConnectDatabase = new System.Windows.Forms.GroupBox();
            this.tbConnecttimeout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DisableAsync = new System.Windows.Forms.RadioButton();
            this.EnableAsync = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnTestConnection = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.gb_LogOnServer.SuspendLayout();
            this.gb_ConnectDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk_OnConnectHost
            // 
            this.chk_OnConnectHost.AutoSize = true;
            this.chk_OnConnectHost.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_OnConnectHost.Location = new System.Drawing.Point(17, 17);
            this.chk_OnConnectHost.Name = "chk_OnConnectHost";
            this.chk_OnConnectHost.Size = new System.Drawing.Size(290, 23);
            this.chk_OnConnectHost.TabIndex = 0;
            this.chk_OnConnectHost.Text = "เปิดการเชื่อมต่อฐานข้อมูล TPN_CONNECT_STD_MIDDLE";
            this.chk_OnConnectHost.UseVisualStyleBackColor = true;
            // 
            // gb_LogOnServer
            // 
            this.gb_LogOnServer.Controls.Add(this.CbServerName);
            this.gb_LogOnServer.Controls.Add(this.chkSavePassword);
            this.gb_LogOnServer.Controls.Add(this.tbPassword);
            this.gb_LogOnServer.Controls.Add(this.tbUserName);
            this.gb_LogOnServer.Controls.Add(this.CbAuthentication);
            this.gb_LogOnServer.Controls.Add(this.label4);
            this.gb_LogOnServer.Controls.Add(this.label3);
            this.gb_LogOnServer.Controls.Add(this.label2);
            this.gb_LogOnServer.Controls.Add(this.label1);
            this.gb_LogOnServer.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_LogOnServer.Location = new System.Drawing.Point(17, 41);
            this.gb_LogOnServer.Name = "gb_LogOnServer";
            this.gb_LogOnServer.Size = new System.Drawing.Size(521, 170);
            this.gb_LogOnServer.TabIndex = 2;
            this.gb_LogOnServer.TabStop = false;
            this.gb_LogOnServer.Text = "Log on to the server";
            // 
            // CbServerName
            // 
            this.CbServerName.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbServerName.FormattingEnabled = true;
            this.CbServerName.Location = new System.Drawing.Point(194, 17);
            this.CbServerName.Name = "CbServerName";
            this.CbServerName.Size = new System.Drawing.Size(241, 27);
            this.CbServerName.TabIndex = 8;
            this.CbServerName.SelectedIndexChanged += new System.EventHandler(this.CbServerName_SelectedIndexChanged);
            this.CbServerName.Click += new System.EventHandler(this.CbServerName_Click);
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSavePassword.Location = new System.Drawing.Point(196, 140);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(102, 23);
            this.chkSavePassword.TabIndex = 4;
            this.chkSavePassword.Text = "Save Password";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(194, 110);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(241, 27);
            this.tbPassword.TabIndex = 7;
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(194, 79);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(241, 27);
            this.tbUserName.TabIndex = 6;
            // 
            // CbAuthentication
            // 
            this.CbAuthentication.DisplayMember = "0";
            this.CbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAuthentication.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAuthentication.FormattingEnabled = true;
            this.CbAuthentication.Items.AddRange(new object[] {
            "SQL Server Authentication",
            "Windows Authentication"});
            this.CbAuthentication.Location = new System.Drawing.Point(194, 48);
            this.CbAuthentication.Name = "CbAuthentication";
            this.CbAuthentication.Size = new System.Drawing.Size(241, 27);
            this.CbAuthentication.TabIndex = 5;
            this.CbAuthentication.SelectedIndexChanged += new System.EventHandler(this.CbAuthentication_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Authentication :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host Name/IP Address :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Database Name :";
            // 
            // CbDatabaseName
            // 
            this.CbDatabaseName.DisplayMember = "0";
            this.CbDatabaseName.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbDatabaseName.FormattingEnabled = true;
            this.CbDatabaseName.Location = new System.Drawing.Point(194, 22);
            this.CbDatabaseName.Name = "CbDatabaseName";
            this.CbDatabaseName.Size = new System.Drawing.Size(241, 27);
            this.CbDatabaseName.TabIndex = 5;
            this.CbDatabaseName.Click += new System.EventHandler(this.CbDatabaseName_Click);
            // 
            // gb_ConnectDatabase
            // 
            this.gb_ConnectDatabase.Controls.Add(this.tbConnecttimeout);
            this.gb_ConnectDatabase.Controls.Add(this.label6);
            this.gb_ConnectDatabase.Controls.Add(this.DisableAsync);
            this.gb_ConnectDatabase.Controls.Add(this.EnableAsync);
            this.gb_ConnectDatabase.Controls.Add(this.label5);
            this.gb_ConnectDatabase.Controls.Add(this.CbDatabaseName);
            this.gb_ConnectDatabase.Controls.Add(this.label8);
            this.gb_ConnectDatabase.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ConnectDatabase.Location = new System.Drawing.Point(17, 217);
            this.gb_ConnectDatabase.Name = "gb_ConnectDatabase";
            this.gb_ConnectDatabase.Size = new System.Drawing.Size(521, 118);
            this.gb_ConnectDatabase.TabIndex = 3;
            this.gb_ConnectDatabase.TabStop = false;
            this.gb_ConnectDatabase.Text = "Connect to a database";
            // 
            // tbConnecttimeout
            // 
            this.tbConnecttimeout.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConnecttimeout.Location = new System.Drawing.Point(194, 79);
            this.tbConnecttimeout.Name = "tbConnecttimeout";
            this.tbConnecttimeout.Size = new System.Drawing.Size(65, 27);
            this.tbConnecttimeout.TabIndex = 10;
            this.tbConnecttimeout.Text = "30";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Connect Timeout :";
            // 
            // DisableAsync
            // 
            this.DisableAsync.AutoSize = true;
            this.DisableAsync.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisableAsync.Location = new System.Drawing.Point(278, 54);
            this.DisableAsync.Name = "DisableAsync";
            this.DisableAsync.Size = new System.Drawing.Size(53, 23);
            this.DisableAsync.TabIndex = 8;
            this.DisableAsync.Text = "Flase";
            this.DisableAsync.UseVisualStyleBackColor = true;
            // 
            // EnableAsync
            // 
            this.EnableAsync.AutoSize = true;
            this.EnableAsync.Checked = true;
            this.EnableAsync.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableAsync.Location = new System.Drawing.Point(194, 54);
            this.EnableAsync.Name = "EnableAsync";
            this.EnableAsync.Size = new System.Drawing.Size(48, 23);
            this.EnableAsync.TabIndex = 7;
            this.EnableAsync.TabStop = true;
            this.EnableAsync.Text = "True";
            this.EnableAsync.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Asynchronous Processing :";
            // 
            // BtnTestConnection
            // 
            this.BtnTestConnection.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTestConnection.Location = new System.Drawing.Point(17, 343);
            this.BtnTestConnection.Name = "BtnTestConnection";
            this.BtnTestConnection.Size = new System.Drawing.Size(119, 33);
            this.BtnTestConnection.TabIndex = 9;
            this.BtnTestConnection.Text = "Test Connection";
            this.BtnTestConnection.UseVisualStyleBackColor = true;
            this.BtnTestConnection.Click += new System.EventHandler(this.BtnTestConnection_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApply.Location = new System.Drawing.Point(419, 343);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(119, 33);
            this.BtnApply.TabIndex = 10;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // DatabaSepage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.BtnTestConnection);
            this.Controls.Add(this.gb_ConnectDatabase);
            this.Controls.Add(this.gb_LogOnServer);
            this.Controls.Add(this.chk_OnConnectHost);
            this.MaximumSize = new System.Drawing.Size(556, 388);
            this.MinimumSize = new System.Drawing.Size(556, 388);
            this.Name = "DatabaSepage";
            this.Size = new System.Drawing.Size(556, 388);
            this.Load += new System.EventHandler(this.DatabaSepage_Load);
            this.gb_LogOnServer.ResumeLayout(false);
            this.gb_LogOnServer.PerformLayout();
            this.gb_ConnectDatabase.ResumeLayout(false);
            this.gb_ConnectDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_OnConnectHost;
        private System.Windows.Forms.GroupBox gb_LogOnServer;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.ComboBox CbAuthentication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CbDatabaseName;
        private System.Windows.Forms.GroupBox gb_ConnectDatabase;
        private System.Windows.Forms.TextBox tbConnecttimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton DisableAsync;
        private System.Windows.Forms.RadioButton EnableAsync;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnTestConnection;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.ComboBox CbServerName;
    }
}
