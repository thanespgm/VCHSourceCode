namespace ConHIS
{
    partial class GeneralPage
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
            this.Chk_StartOnProgram = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbTmtoRetrieve = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbReadTextFormat = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CbEncode_SeparatorPattren = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TbSeparatorPattren = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TbReadFileWait = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbDatabaseCondition = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbDaysDelete = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Chk_StartOnWindows = new System.Windows.Forms.CheckBox();
            this.Chk_StartRelationMachine = new System.Windows.Forms.CheckBox();
            this.TCInterfaceFormatMode = new System.Windows.Forms.TabControl();
            this.TPTextFileMode = new System.Windows.Forms.TabPage();
            this.TPHosXPMode = new System.Windows.Forms.TabPage();
            this.gbHostIPAddress = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbServerDBType = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.BtnTestConnect = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbDatabaseName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbInterfaceMode = new System.Windows.Forms.GroupBox();
            this.cbSiteName = new System.Windows.Forms.ComboBox();
            this.gbInterfaceTimer = new System.Windows.Forms.GroupBox();
            this.chkSyncSMT = new System.Windows.Forms.CheckBox();
            this.chkDTATray = new System.Windows.Forms.CheckBox();
            this.tbStartOrderContinue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbReadTextFormat.SuspendLayout();
            this.gbDatabaseCondition.SuspendLayout();
            this.TCInterfaceFormatMode.SuspendLayout();
            this.TPTextFileMode.SuspendLayout();
            this.TPHosXPMode.SuspendLayout();
            this.gbHostIPAddress.SuspendLayout();
            this.gbInterfaceMode.SuspendLayout();
            this.gbInterfaceTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chk_StartOnProgram
            // 
            this.Chk_StartOnProgram.AutoSize = true;
            this.Chk_StartOnProgram.Location = new System.Drawing.Point(27, 21);
            this.Chk_StartOnProgram.Name = "Chk_StartOnProgram";
            this.Chk_StartOnProgram.Size = new System.Drawing.Size(192, 23);
            this.Chk_StartOnProgram.TabIndex = 0;
            this.Chk_StartOnProgram.Text = "เริ่มต้นดึงข้อมูลเมื่อเปิดโปรแกรม";
            this.Chk_StartOnProgram.UseVisualStyleBackColor = true;
            this.Chk_StartOnProgram.CheckedChanged += new System.EventHandler(this.Chk_StartOnProgram_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "(MiliSeconds)";
            // 
            // TbTmtoRetrieve
            // 
            this.TbTmtoRetrieve.Location = new System.Drawing.Point(102, 17);
            this.TbTmtoRetrieve.Name = "TbTmtoRetrieve";
            this.TbTmtoRetrieve.Size = new System.Drawing.Size(63, 26);
            this.TbTmtoRetrieve.TabIndex = 11;
            this.TbTmtoRetrieve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbTmtoRetrieve.TextChanged += new System.EventHandler(this.TbTmtoRetrieve_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "เวลาการดึงข้อมูล:";
            // 
            // gbReadTextFormat
            // 
            this.gbReadTextFormat.Controls.Add(this.label6);
            this.gbReadTextFormat.Controls.Add(this.label5);
            this.gbReadTextFormat.Controls.Add(this.CbEncode_SeparatorPattren);
            this.gbReadTextFormat.Controls.Add(this.label4);
            this.gbReadTextFormat.Controls.Add(this.TbSeparatorPattren);
            this.gbReadTextFormat.Controls.Add(this.label1);
            this.gbReadTextFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReadTextFormat.Location = new System.Drawing.Point(3, 3);
            this.gbReadTextFormat.Name = "gbReadTextFormat";
            this.gbReadTextFormat.Size = new System.Drawing.Size(611, 216);
            this.gbReadTextFormat.TabIndex = 13;
            this.gbReadTextFormat.TabStop = false;
            this.gbReadTextFormat.Text = "รูปแบบการอ่านข้อมูลจากไฟล์เข้าฐานข้อมูล";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(330, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "จำนวนฟิลด์ข้อมูล:";
            // 
            // CbEncode_SeparatorPattren
            // 
            this.CbEncode_SeparatorPattren.DisplayMember = "0";
            this.CbEncode_SeparatorPattren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEncode_SeparatorPattren.FormattingEnabled = true;
            this.CbEncode_SeparatorPattren.Items.AddRange(new object[] {
            "ปิดสัญลักษณ์หัวและท้ายข้อมูล",
            "ปิดสัญลักษณ์ส่วนหัวข้อมูล",
            "ปิดสัญลักษณ์ส่วนท้ายข้อมูล",
            "ไม่มีการปิดด้วยสัญลักษณ์หัวและท้ายข้อมูล"});
            this.CbEncode_SeparatorPattren.Location = new System.Drawing.Point(150, 52);
            this.CbEncode_SeparatorPattren.Name = "CbEncode_SeparatorPattren";
            this.CbEncode_SeparatorPattren.Size = new System.Drawing.Size(241, 26);
            this.CbEncode_SeparatorPattren.TabIndex = 14;
            this.CbEncode_SeparatorPattren.SelectedIndexChanged += new System.EventHandler(this.CbEncode_SeparatorPattren_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "รูปแบบการเข้ารหัสข้อมูล:";
            // 
            // TbSeparatorPattren
            // 
            this.TbSeparatorPattren.Location = new System.Drawing.Point(150, 23);
            this.TbSeparatorPattren.Name = "TbSeparatorPattren";
            this.TbSeparatorPattren.Size = new System.Drawing.Size(63, 26);
            this.TbSeparatorPattren.TabIndex = 12;
            this.TbSeparatorPattren.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSeparatorPattren.TextChanged += new System.EventHandler(this.TbSeparatorPattren_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "สัญลักษณ์แบ่งฟิลด์ข้อมูล:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "(MiliSeconds)";
            // 
            // TbReadFileWait
            // 
            this.TbReadFileWait.Location = new System.Drawing.Point(375, 16);
            this.TbReadFileWait.Name = "TbReadFileWait";
            this.TbReadFileWait.Size = new System.Drawing.Size(63, 26);
            this.TbReadFileWait.TabIndex = 17;
            this.TbReadFileWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbReadFileWait.TextChanged += new System.EventHandler(this.TbReadFileWait_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "เวลาการรออ่านไฟล์ข้อมูล:";
            // 
            // gbDatabaseCondition
            // 
            this.gbDatabaseCondition.BackColor = System.Drawing.Color.White;
            this.gbDatabaseCondition.Controls.Add(this.label9);
            this.gbDatabaseCondition.Controls.Add(this.TbDaysDelete);
            this.gbDatabaseCondition.Controls.Add(this.label10);
            this.gbDatabaseCondition.Location = new System.Drawing.Point(17, 514);
            this.gbDatabaseCondition.Name = "gbDatabaseCondition";
            this.gbDatabaseCondition.Size = new System.Drawing.Size(625, 55);
            this.gbDatabaseCondition.TabIndex = 14;
            this.gbDatabaseCondition.TabStop = false;
            this.gbDatabaseCondition.Text = "การจัดเก็บข้อมูลในฐานข้อมูล";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "(วัน)";
            // 
            // TbDaysDelete
            // 
            this.TbDaysDelete.Location = new System.Drawing.Point(217, 16);
            this.TbDaysDelete.Name = "TbDaysDelete";
            this.TbDaysDelete.Size = new System.Drawing.Size(63, 26);
            this.TbDaysDelete.TabIndex = 14;
            this.TbDaysDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbDaysDelete.TextChanged += new System.EventHandler(this.TbDaysDelete_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "เวลาการลบข้อมูลที่ไม่เกี่ยวข้องย้อนหลัง:";
            // 
            // Chk_StartOnWindows
            // 
            this.Chk_StartOnWindows.AutoSize = true;
            this.Chk_StartOnWindows.Location = new System.Drawing.Point(364, 21);
            this.Chk_StartOnWindows.Name = "Chk_StartOnWindows";
            this.Chk_StartOnWindows.Size = new System.Drawing.Size(216, 23);
            this.Chk_StartOnWindows.TabIndex = 15;
            this.Chk_StartOnWindows.Text = "Windows (On Start Program)";
            this.Chk_StartOnWindows.UseVisualStyleBackColor = true;
            this.Chk_StartOnWindows.CheckedChanged += new System.EventHandler(this.Chk_StartOnWindows_CheckedChanged);
            // 
            // Chk_StartRelationMachine
            // 
            this.Chk_StartRelationMachine.AutoSize = true;
            this.Chk_StartRelationMachine.Location = new System.Drawing.Point(17, 489);
            this.Chk_StartRelationMachine.Name = "Chk_StartRelationMachine";
            this.Chk_StartRelationMachine.Size = new System.Drawing.Size(267, 23);
            this.Chk_StartRelationMachine.TabIndex = 0;
            this.Chk_StartRelationMachine.Text = "จัดเก็บข้อมูลที่เกี่ยวข้องกับเครื่องนับยาอัติโนมัติ";
            this.Chk_StartRelationMachine.UseVisualStyleBackColor = true;
            this.Chk_StartRelationMachine.CheckedChanged += new System.EventHandler(this.Chk_StartRelationMachine_CheckedChanged);
            // 
            // TCInterfaceFormatMode
            // 
            this.TCInterfaceFormatMode.Controls.Add(this.TPTextFileMode);
            this.TCInterfaceFormatMode.Controls.Add(this.TPHosXPMode);
            this.TCInterfaceFormatMode.Location = new System.Drawing.Point(17, 174);
            this.TCInterfaceFormatMode.Name = "TCInterfaceFormatMode";
            this.TCInterfaceFormatMode.SelectedIndex = 0;
            this.TCInterfaceFormatMode.Size = new System.Drawing.Size(625, 253);
            this.TCInterfaceFormatMode.TabIndex = 16;
            // 
            // TPTextFileMode
            // 
            this.TPTextFileMode.Controls.Add(this.gbReadTextFormat);
            this.TPTextFileMode.Location = new System.Drawing.Point(4, 27);
            this.TPTextFileMode.Name = "TPTextFileMode";
            this.TPTextFileMode.Padding = new System.Windows.Forms.Padding(3);
            this.TPTextFileMode.Size = new System.Drawing.Size(617, 222);
            this.TPTextFileMode.TabIndex = 0;
            this.TPTextFileMode.Text = "โหมดการอินเตอร์เฟสผ่านไฟล์ข้อมูล";
            this.TPTextFileMode.UseVisualStyleBackColor = true;
            // 
            // TPHosXPMode
            // 
            this.TPHosXPMode.Controls.Add(this.gbHostIPAddress);
            this.TPHosXPMode.Location = new System.Drawing.Point(4, 27);
            this.TPHosXPMode.Name = "TPHosXPMode";
            this.TPHosXPMode.Padding = new System.Windows.Forms.Padding(3);
            this.TPHosXPMode.Size = new System.Drawing.Size(617, 222);
            this.TPHosXPMode.TabIndex = 1;
            this.TPHosXPMode.Text = "โหมดการอินเตอร์เฟสผ่าน HosXP";
            this.TPHosXPMode.UseVisualStyleBackColor = true;
            // 
            // gbHostIPAddress
            // 
            this.gbHostIPAddress.Controls.Add(this.label15);
            this.gbHostIPAddress.Controls.Add(this.cbServerDBType);
            this.gbHostIPAddress.Controls.Add(this.label16);
            this.gbHostIPAddress.Controls.Add(this.tbPort);
            this.gbHostIPAddress.Controls.Add(this.BtnTestConnect);
            this.gbHostIPAddress.Controls.Add(this.tbPassword);
            this.gbHostIPAddress.Controls.Add(this.label11);
            this.gbHostIPAddress.Controls.Add(this.tbUserName);
            this.gbHostIPAddress.Controls.Add(this.tbDatabaseName);
            this.gbHostIPAddress.Controls.Add(this.label12);
            this.gbHostIPAddress.Controls.Add(this.label13);
            this.gbHostIPAddress.Controls.Add(this.tbServerName);
            this.gbHostIPAddress.Controls.Add(this.label14);
            this.gbHostIPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbHostIPAddress.Location = new System.Drawing.Point(3, 3);
            this.gbHostIPAddress.Name = "gbHostIPAddress";
            this.gbHostIPAddress.Size = new System.Drawing.Size(611, 216);
            this.gbHostIPAddress.TabIndex = 14;
            this.gbHostIPAddress.TabStop = false;
            this.gbHostIPAddress.Text = "เชื่อมต่อฐานข้อมูล MySQL";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(63, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 19);
            this.label15.TabIndex = 23;
            this.label15.Text = "Server Type:";
            // 
            // cbServerDBType
            // 
            this.cbServerDBType.FormattingEnabled = true;
            this.cbServerDBType.Items.AddRange(new object[] {
            "SQL Server",
            "MySQL Server",
            "ProstgreSQL Server"});
            this.cbServerDBType.Location = new System.Drawing.Point(141, 28);
            this.cbServerDBType.Name = "cbServerDBType";
            this.cbServerDBType.Size = new System.Drawing.Size(199, 26);
            this.cbServerDBType.TabIndex = 22;
            this.cbServerDBType.Text = "--ไม่ระบุ--";
            this.cbServerDBType.SelectedIndexChanged += new System.EventHandler(this.CbServerDBType_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(365, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 19);
            this.label16.TabIndex = 16;
            this.label16.Text = "Port :";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(407, 77);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(36, 26);
            this.tbPort.TabIndex = 24;
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnTestConnect
            // 
            this.BtnTestConnect.Location = new System.Drawing.Point(407, 178);
            this.BtnTestConnect.Name = "BtnTestConnect";
            this.BtnTestConnect.Size = new System.Drawing.Size(145, 31);
            this.BtnTestConnect.TabIndex = 23;
            this.BtnTestConnect.Text = "Test Connection";
            this.BtnTestConnect.UseVisualStyleBackColor = true;
            this.BtnTestConnect.Click += new System.EventHandler(this.BtnTestConnect_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(141, 178);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(205, 26);
            this.tbPassword.TabIndex = 19;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 19);
            this.label11.TabIndex = 18;
            this.label11.Text = "Password :";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(141, 145);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(205, 26);
            this.tbUserName.TabIndex = 17;
            this.tbUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDatabaseName
            // 
            this.tbDatabaseName.Location = new System.Drawing.Point(141, 111);
            this.tbDatabaseName.Name = "tbDatabaseName";
            this.tbDatabaseName.Size = new System.Drawing.Size(205, 26);
            this.tbDatabaseName.TabIndex = 16;
            this.tbDatabaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 19);
            this.label12.TabIndex = 15;
            this.label12.Text = "DataBase Name :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 19);
            this.label13.TabIndex = 13;
            this.label13.Text = "Username :";
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(141, 77);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(205, 26);
            this.tbServerName.TabIndex = 12;
            this.tbServerName.Text = "localhost";
            this.tbServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(55, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 19);
            this.label14.TabIndex = 11;
            this.label14.Text = "Server Name :";
            // 
            // gbInterfaceMode
            // 
            this.gbInterfaceMode.BackColor = System.Drawing.Color.White;
            this.gbInterfaceMode.Controls.Add(this.cbSiteName);
            this.gbInterfaceMode.Location = new System.Drawing.Point(17, 48);
            this.gbInterfaceMode.Name = "gbInterfaceMode";
            this.gbInterfaceMode.Size = new System.Drawing.Size(625, 54);
            this.gbInterfaceMode.TabIndex = 21;
            this.gbInterfaceMode.TabStop = false;
            this.gbInterfaceMode.Text = "รูปแบบการประสานข้อมูลของ HIS";
            // 
            // cbSiteName
            // 
            this.cbSiteName.BackColor = System.Drawing.Color.Azure;
            this.cbSiteName.DisplayMember = "1";
            this.cbSiteName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbSiteName.FormattingEnabled = true;
            this.cbSiteName.Items.AddRange(new object[] {
            "--ไม่ระบุไซค์งาน--",
            "โรงพยาบาลกรุงเทพ ศูนย์วิจัย OPD  TakeCare รูปแบบ TextFile  เวอรชั่น 1 (ปี 2018)",
            "โรงพยาบาลมหาวิทยาลัยสุรนารี  IPD HosXP รูปแบบ HL7 2.3 เวอร์ชั่น 1( ปี 2020 )",
            "โรงพยาบาลชลประทาน OPD HosXP รูปแบบ HL7 2.3 เวอรชั่น 1 ( ปี 2020 )",
            "โรงพยาบาลหัวเฉียว  IPD TakeCare รูปแบบ TextFile  เวอร์ชั่น 1 (ปี 2020)",
            "โรงพยาบาลวิชัยยุทธ IPD IMed รูปแบบ Direct DB เวอร์ชั่น 1 (ปี 2021)",
            "โรงพยาบาลจุฬาภรณ์ IPD SSB รูปแบบ HL7 2.7 เวอร์ชั่น 1 (ปี 2021)",
            "โรงพยาบาลปากช่องนานา IPD HosXP HL 2.3 เวอร์ชั่น 2 (ปี 2022)",
            "โรงพยาบาลจิตเวชสงขลา IPD HosXP HL 2.3 เวอร์ชั่น 2 (ปี 2022)"});
            this.cbSiteName.Location = new System.Drawing.Point(19, 20);
            this.cbSiteName.Name = "cbSiteName";
            this.cbSiteName.Size = new System.Drawing.Size(593, 26);
            this.cbSiteName.TabIndex = 24;
            this.cbSiteName.ValueMember = "1";
            this.cbSiteName.SelectedIndexChanged += new System.EventHandler(this.cbSiteName_SelectedIndexChanged);
            // 
            // gbInterfaceTimer
            // 
            this.gbInterfaceTimer.BackColor = System.Drawing.Color.White;
            this.gbInterfaceTimer.Controls.Add(this.label2);
            this.gbInterfaceTimer.Controls.Add(this.label8);
            this.gbInterfaceTimer.Controls.Add(this.label7);
            this.gbInterfaceTimer.Controls.Add(this.label3);
            this.gbInterfaceTimer.Controls.Add(this.TbReadFileWait);
            this.gbInterfaceTimer.Controls.Add(this.TbTmtoRetrieve);
            this.gbInterfaceTimer.Location = new System.Drawing.Point(17, 433);
            this.gbInterfaceTimer.Name = "gbInterfaceTimer";
            this.gbInterfaceTimer.Size = new System.Drawing.Size(625, 50);
            this.gbInterfaceTimer.TabIndex = 22;
            this.gbInterfaceTimer.TabStop = false;
            this.gbInterfaceTimer.Text = "ความถี่และเวลาข้อมูลการประสานข้อมูล";
            // 
            // chkSyncSMT
            // 
            this.chkSyncSMT.AutoSize = true;
            this.chkSyncSMT.Location = new System.Drawing.Point(36, 120);
            this.chkSyncSMT.Name = "chkSyncSMT";
            this.chkSyncSMT.Size = new System.Drawing.Size(156, 23);
            this.chkSyncSMT.TabIndex = 23;
            this.chkSyncSMT.Text = "เชื่อมต่อกับรถเข็น SMT";
            this.chkSyncSMT.UseVisualStyleBackColor = true;
            this.chkSyncSMT.CheckedChanged += new System.EventHandler(this.chkSyncSMT_CheckedChanged);
            // 
            // chkDTATray
            // 
            this.chkDTATray.AutoSize = true;
            this.chkDTATray.Location = new System.Drawing.Point(196, 120);
            this.chkDTATray.Name = "chkDTATray";
            this.chkDTATray.Size = new System.Drawing.Size(122, 23);
            this.chkDTATray.TabIndex = 24;
            this.chkDTATray.Text = "ใช้ยา DTA Tray";
            this.chkDTATray.UseVisualStyleBackColor = true;
            this.chkDTATray.CheckedChanged += new System.EventHandler(this.chkDTATray_CheckedChanged);
            // 
            // tbStartOrderContinue
            // 
            this.tbStartOrderContinue.Location = new System.Drawing.Point(496, 117);
            this.tbStartOrderContinue.Name = "tbStartOrderContinue";
            this.tbStartOrderContinue.Size = new System.Drawing.Size(133, 26);
            this.tbStartOrderContinue.TabIndex = 26;
            this.tbStartOrderContinue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbStartOrderContinue.TextChanged += new System.EventHandler(this.tbStartOrderContinue_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(371, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 19);
            this.label18.TabIndex = 25;
            this.label18.Text = "มื้อเริ่มต้นยาทายต่อเนื่อง :";
            // 
            // GeneralPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tbStartOrderContinue);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.chkDTATray);
            this.Controls.Add(this.chkSyncSMT);
            this.Controls.Add(this.gbInterfaceTimer);
            this.Controls.Add(this.gbInterfaceMode);
            this.Controls.Add(this.TCInterfaceFormatMode);
            this.Controls.Add(this.Chk_StartOnWindows);
            this.Controls.Add(this.gbDatabaseCondition);
            this.Controls.Add(this.Chk_StartRelationMachine);
            this.Controls.Add(this.Chk_StartOnProgram);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(656, 579);
            this.MinimumSize = new System.Drawing.Size(656, 579);
            this.Name = "GeneralPage";
            this.Size = new System.Drawing.Size(656, 579);
            this.Load += new System.EventHandler(this.GeneralPage_Load);
            this.gbReadTextFormat.ResumeLayout(false);
            this.gbReadTextFormat.PerformLayout();
            this.gbDatabaseCondition.ResumeLayout(false);
            this.gbDatabaseCondition.PerformLayout();
            this.TCInterfaceFormatMode.ResumeLayout(false);
            this.TPTextFileMode.ResumeLayout(false);
            this.TPHosXPMode.ResumeLayout(false);
            this.gbHostIPAddress.ResumeLayout(false);
            this.gbHostIPAddress.PerformLayout();
            this.gbInterfaceMode.ResumeLayout(false);
            this.gbInterfaceTimer.ResumeLayout(false);
            this.gbInterfaceTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Chk_StartOnProgram;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbTmtoRetrieve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbReadTextFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbSeparatorPattren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbReadFileWait;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbEncode_SeparatorPattren;
        private System.Windows.Forms.GroupBox gbDatabaseCondition;
        private System.Windows.Forms.CheckBox Chk_StartOnWindows;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbDaysDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox Chk_StartRelationMachine;
        private System.Windows.Forms.TabControl TCInterfaceFormatMode;
        private System.Windows.Forms.TabPage TPTextFileMode;
        private System.Windows.Forms.TabPage TPHosXPMode;
        private System.Windows.Forms.GroupBox gbHostIPAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gbInterfaceMode;
        private System.Windows.Forms.GroupBox gbInterfaceTimer;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button BtnTestConnect;
        private System.Windows.Forms.ComboBox cbServerDBType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.ComboBox cbSiteName;
        private System.Windows.Forms.CheckBox chkSyncSMT;
        private System.Windows.Forms.CheckBox chkDTATray;
        private System.Windows.Forms.TextBox tbStartOrderContinue;
        private System.Windows.Forms.Label label18;
    }
}
