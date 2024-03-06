namespace ConHIS
{
    partial class FullDetailPage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvPrescriptionAll = new System.Windows.Forms.DataGridView();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lbAlretsDataShow = new System.Windows.Forms.Label();
            this.lbHeader = new System.Windows.Forms.Label();
            this.gbSearchDataDetail = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnSearchData = new System.Windows.Forms.Button();
            this.tbSearchData = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PbHospitalLogo = new System.Windows.Forms.PictureBox();
            this.tls_datafilldetails = new System.Windows.Forms.ToolStrip();
            this.txtdatabase_status = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtitemslist = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtload_data = new System.Windows.Forms.ToolStripLabel();
            this.pgb_loaddata = new System.Windows.Forms.ToolStripProgressBar();
            this.txtprecents = new System.Windows.Forms.ToolStripLabel();
            this.BgwAutoCheck = new System.ComponentModel.BackgroundWorker();
            this.tmAutoCheck = new System.Windows.Forms.Timer(this.components);
            this.PnSpaceDataGridview = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrescriptionAll)).BeginInit();
            this.pnHeader.SuspendLayout();
            this.gbSearchDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHospitalLogo)).BeginInit();
            this.tls_datafilldetails.SuspendLayout();
            this.PnSpaceDataGridview.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvPrescriptionAll
            // 
            this.DgvPrescriptionAll.AllowUserToAddRows = false;
            this.DgvPrescriptionAll.AllowUserToDeleteRows = false;
            this.DgvPrescriptionAll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DgvPrescriptionAll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPrescriptionAll.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPrescriptionAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPrescriptionAll.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvPrescriptionAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPrescriptionAll.GridColor = System.Drawing.Color.White;
            this.DgvPrescriptionAll.Location = new System.Drawing.Point(0, 0);
            this.DgvPrescriptionAll.Name = "DgvPrescriptionAll";
            this.DgvPrescriptionAll.ReadOnly = true;
            this.DgvPrescriptionAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPrescriptionAll.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPrescriptionAll.RowHeadersVisible = false;
            this.DgvPrescriptionAll.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvPrescriptionAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPrescriptionAll.Size = new System.Drawing.Size(1350, 565);
            this.DgvPrescriptionAll.TabIndex = 1;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.White;
            this.pnHeader.Controls.Add(this.lbAlretsDataShow);
            this.pnHeader.Controls.Add(this.lbHeader);
            this.pnHeader.Controls.Add(this.gbSearchDataDetail);
            this.pnHeader.Controls.Add(this.pictureBox7);
            this.pnHeader.Controls.Add(this.pictureBox6);
            this.pnHeader.Controls.Add(this.pictureBox5);
            this.pnHeader.Controls.Add(this.pictureBox4);
            this.pnHeader.Controls.Add(this.pictureBox3);
            this.pnHeader.Controls.Add(this.pictureBox2);
            this.pnHeader.Controls.Add(this.PbHospitalLogo);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1350, 99);
            this.pnHeader.TabIndex = 18;
            // 
            // lbAlretsDataShow
            // 
            this.lbAlretsDataShow.AutoSize = true;
            this.lbAlretsDataShow.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAlretsDataShow.ForeColor = System.Drawing.Color.Maroon;
            this.lbAlretsDataShow.Location = new System.Drawing.Point(1020, 16);
            this.lbAlretsDataShow.Name = "lbAlretsDataShow";
            this.lbAlretsDataShow.Size = new System.Drawing.Size(172, 16);
            this.lbAlretsDataShow.TabIndex = 10;
            this.lbAlretsDataShow.Text = "(ผลการค้นหาข้อมูล  10 รายการ)";
            this.lbAlretsDataShow.Visible = false;
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbHeader.Location = new System.Drawing.Point(742, 16);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(271, 16);
            this.lbHeader.TabIndex = 9;
            this.lbHeader.Text = "รายการแสดงรายละเอียดข้อมูลจากการ Interface  ";
            // 
            // gbSearchDataDetail
            // 
            this.gbSearchDataDetail.Controls.Add(this.btnRefresh);
            this.gbSearchDataDetail.Controls.Add(this.label12);
            this.gbSearchDataDetail.Controls.Add(this.BtnSearchData);
            this.gbSearchDataDetail.Controls.Add(this.tbSearchData);
            this.gbSearchDataDetail.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.gbSearchDataDetail.Location = new System.Drawing.Point(732, 37);
            this.gbSearchDataDetail.Name = "gbSearchDataDetail";
            this.gbSearchDataDetail.Size = new System.Drawing.Size(615, 51);
            this.gbSearchDataDetail.TabIndex = 7;
            this.gbSearchDataDetail.TabStop = false;
            this.gbSearchDataDetail.Text = "ค้นหาข้อมูล";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(525, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "คืนค่า";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.MediumBlue;
            this.label12.Location = new System.Drawing.Point(10, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "ค้นหาข้อมูลใบสั่งยา (ระบุเลขที่ใบสั่งยา / HN / ชื่อ)";
            // 
            // BtnSearchData
            // 
            this.BtnSearchData.Location = new System.Drawing.Point(449, 18);
            this.BtnSearchData.Name = "BtnSearchData";
            this.BtnSearchData.Size = new System.Drawing.Size(75, 26);
            this.BtnSearchData.TabIndex = 15;
            this.BtnSearchData.Text = "ค้นหา";
            this.BtnSearchData.UseVisualStyleBackColor = true;
            this.BtnSearchData.Click += new System.EventHandler(this.BtnSearchData_Click);
            // 
            // tbSearchData
            // 
            this.tbSearchData.BackColor = System.Drawing.Color.Pink;
            this.tbSearchData.Location = new System.Drawing.Point(249, 17);
            this.tbSearchData.Name = "tbSearchData";
            this.tbSearchData.Size = new System.Drawing.Size(195, 24);
            this.tbSearchData.TabIndex = 17;
            this.tbSearchData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSearchData_KeyDown);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::ConHIS.Properties.Resources.arrow;
            this.pictureBox7.Location = new System.Drawing.Point(483, 63);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(141, 25);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ConHIS.Properties.Resources.arrow;
            this.pictureBox6.Location = new System.Drawing.Point(217, 63);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(141, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::ConHIS.Properties.Resources.thanes;
            this.pictureBox5.Location = new System.Drawing.Point(523, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(105, 52);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ConHIS.Properties.Resources.drive;
            this.pictureBox4.Location = new System.Drawing.Point(364, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(96, 73);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ConHIS.Properties.Resources.host;
            this.pictureBox3.Location = new System.Drawing.Point(630, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(96, 73);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ConHIS.Properties.Resources.host;
            this.pictureBox2.Location = new System.Drawing.Point(115, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(96, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // PbHospitalLogo
            // 
            this.PbHospitalLogo.Image = global::ConHIS.Properties.Resources.thanes;
            this.PbHospitalLogo.Location = new System.Drawing.Point(8, 5);
            this.PbHospitalLogo.Name = "PbHospitalLogo";
            this.PbHospitalLogo.Size = new System.Drawing.Size(105, 94);
            this.PbHospitalLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbHospitalLogo.TabIndex = 0;
            this.PbHospitalLogo.TabStop = false;
            // 
            // tls_datafilldetails
            // 
            this.tls_datafilldetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tls_datafilldetails.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.tls_datafilldetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtdatabase_status,
            this.toolStripSeparator1,
            this.txtitemslist,
            this.toolStripSeparator2,
            this.txtload_data,
            this.pgb_loaddata,
            this.txtprecents});
            this.tls_datafilldetails.Location = new System.Drawing.Point(0, 664);
            this.tls_datafilldetails.Name = "tls_datafilldetails";
            this.tls_datafilldetails.Size = new System.Drawing.Size(1350, 25);
            this.tls_datafilldetails.TabIndex = 20;
            this.tls_datafilldetails.Text = "toolStrip1";
            // 
            // txtdatabase_status
            // 
            this.txtdatabase_status.ForeColor = System.Drawing.Color.Navy;
            this.txtdatabase_status.Name = "txtdatabase_status";
            this.txtdatabase_status.Size = new System.Drawing.Size(191, 22);
            this.txtdatabase_status.Text = "สถานะการเชื่อมต่อฐานข้อมูล : เชื่อมต่ออยู่";
            this.txtdatabase_status.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // txtitemslist
            // 
            this.txtitemslist.Name = "txtitemslist";
            this.txtitemslist.Size = new System.Drawing.Size(119, 22);
            this.txtitemslist.Text = "รายการทั้งหมด 0 รายการ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtload_data
            // 
            this.txtload_data.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtload_data.Name = "txtload_data";
            this.txtload_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtload_data.Size = new System.Drawing.Size(62, 22);
            this.txtload_data.Text = "โหลดข้อมูล ";
            // 
            // pgb_loaddata
            // 
            this.pgb_loaddata.Name = "pgb_loaddata";
            this.pgb_loaddata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pgb_loaddata.Size = new System.Drawing.Size(400, 22);
            // 
            // txtprecents
            // 
            this.txtprecents.Name = "txtprecents";
            this.txtprecents.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtprecents.Size = new System.Drawing.Size(33, 22);
            this.txtprecents.Text = " 0 %";
            // 
            // BgwAutoCheck
            // 
            this.BgwAutoCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwAutoCheck_DoWork);
            this.BgwAutoCheck.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwAutoCheck_ProgressChanged);
            this.BgwAutoCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwAutoCheck_RunWorkerCompleted);
            // 
            // tmAutoCheck
            // 
            this.tmAutoCheck.Tick += new System.EventHandler(this.TmAutoCheck_Tick);
            // 
            // PnSpaceDataGridview
            // 
            this.PnSpaceDataGridview.Controls.Add(this.DgvPrescriptionAll);
            this.PnSpaceDataGridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnSpaceDataGridview.Location = new System.Drawing.Point(0, 99);
            this.PnSpaceDataGridview.Name = "PnSpaceDataGridview";
            this.PnSpaceDataGridview.Size = new System.Drawing.Size(1350, 565);
            this.PnSpaceDataGridview.TabIndex = 21;
            // 
            // FullDetailPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1350, 689);
            this.Controls.Add(this.PnSpaceDataGridview);
            this.Controls.Add(this.tls_datafilldetails);
            this.Controls.Add(this.pnHeader);
            this.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FullDetailPage";
            this.Text = "ข้อมูลแบบละเอียด";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FullDetailPage_FormClosed);
            this.Load += new System.EventHandler(this.FullDetailPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPrescriptionAll)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.gbSearchDataDetail.ResumeLayout(false);
            this.gbSearchDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHospitalLogo)).EndInit();
            this.tls_datafilldetails.ResumeLayout(false);
            this.tls_datafilldetails.PerformLayout();
            this.PnSpaceDataGridview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPrescriptionAll;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox PbHospitalLogo;
        private System.Windows.Forms.GroupBox gbSearchDataDetail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnSearchData;
        private System.Windows.Forms.TextBox tbSearchData;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Label lbAlretsDataShow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStrip tls_datafilldetails;
        private System.Windows.Forms.ToolStripLabel txtdatabase_status;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel txtitemslist;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel txtload_data;
        private System.Windows.Forms.ToolStripProgressBar pgb_loaddata;
        private System.Windows.Forms.ToolStripLabel txtprecents;
        private System.ComponentModel.BackgroundWorker BgwAutoCheck;
        private System.Windows.Forms.Timer tmAutoCheck;
        private System.Windows.Forms.Panel PnSpaceDataGridview;
    }
}