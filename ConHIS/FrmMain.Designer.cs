namespace ConHIS
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnMainForm = new System.Windows.Forms.Panel();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.pnRestFullAPI = new System.Windows.Forms.Panel();
            this.gbRestFull = new System.Windows.Forms.GroupBox();
            this.btnClassify = new System.Windows.Forms.Button();
            this.btnTimeTable = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.tbPrescriptionCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtResponse = new System.Windows.Forms.TextBox();
            this.tbRestUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.pnRestFullAPI.SuspendLayout();
            this.gbRestFull.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMainForm
            // 
            this.pnMainForm.AutoScroll = true;
            this.pnMainForm.AutoSize = true;
            this.pnMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMainForm.Location = new System.Drawing.Point(0, 0);
            this.pnMainForm.Name = "pnMainForm";
            this.pnMainForm.Size = new System.Drawing.Size(1348, 571);
            this.pnMainForm.TabIndex = 0;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.pnMainForm);
            this.mainSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainSplitContainer.Panel1MinSize = 400;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.pnRestFullAPI);
            this.mainSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainSplitContainer.Size = new System.Drawing.Size(1350, 687);
            this.mainSplitContainer.SplitterDistance = 573;
            this.mainSplitContainer.TabIndex = 1;
            // 
            // pnRestFullAPI
            // 
            this.pnRestFullAPI.Controls.Add(this.gbRestFull);
            this.pnRestFullAPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRestFullAPI.Location = new System.Drawing.Point(0, 0);
            this.pnRestFullAPI.Name = "pnRestFullAPI";
            this.pnRestFullAPI.Size = new System.Drawing.Size(1348, 108);
            this.pnRestFullAPI.TabIndex = 0;
            // 
            // gbRestFull
            // 
            this.gbRestFull.Controls.Add(this.btnClassify);
            this.gbRestFull.Controls.Add(this.btnTimeTable);
            this.gbRestFull.Controls.Add(this.btnShow);
            this.gbRestFull.Controls.Add(this.btnGetAll);
            this.gbRestFull.Controls.Add(this.tbPrescriptionCount);
            this.gbRestFull.Controls.Add(this.label3);
            this.gbRestFull.Controls.Add(this.TxtResponse);
            this.gbRestFull.Controls.Add(this.tbRestUrl);
            this.gbRestFull.Controls.Add(this.label2);
            this.gbRestFull.Controls.Add(this.label1);
            this.gbRestFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRestFull.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRestFull.Location = new System.Drawing.Point(0, 0);
            this.gbRestFull.Name = "gbRestFull";
            this.gbRestFull.Size = new System.Drawing.Size(1348, 108);
            this.gbRestFull.TabIndex = 0;
            this.gbRestFull.TabStop = false;
            this.gbRestFull.Text = "TMS Rest Full API Connect";
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(1025, 22);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(153, 23);
            this.btnClassify.TabIndex = 9;
            this.btnClassify.Text = "Classify Medical";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // btnTimeTable
            // 
            this.btnTimeTable.Location = new System.Drawing.Point(1183, 22);
            this.btnTimeTable.Name = "btnTimeTable";
            this.btnTimeTable.Size = new System.Drawing.Size(153, 23);
            this.btnTimeTable.TabIndex = 8;
            this.btnTimeTable.Text = "Show Time Table";
            this.btnTimeTable.UseVisualStyleBackColor = true;
            this.btnTimeTable.Click += new System.EventHandler(this.btnTimeTable_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(825, 22);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(194, 23);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show Prescription By Date";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(625, 22);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(194, 23);
            this.btnGetAll.TabIndex = 6;
            this.btnGetAll.Text = "Request Prescription By Date";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // tbPrescriptionCount
            // 
            this.tbPrescriptionCount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbPrescriptionCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPrescriptionCount.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrescriptionCount.Location = new System.Drawing.Point(467, 23);
            this.tbPrescriptionCount.Name = "tbPrescriptionCount";
            this.tbPrescriptionCount.Size = new System.Drawing.Size(127, 26);
            this.tbPrescriptionCount.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prescription Items :";
            // 
            // TxtResponse
            // 
            this.TxtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtResponse.BackColor = System.Drawing.Color.White;
            this.TxtResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtResponse.Location = new System.Drawing.Point(99, 62);
            this.TxtResponse.Multiline = true;
            this.TxtResponse.Name = "TxtResponse";
            this.TxtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtResponse.Size = new System.Drawing.Size(1237, 24);
            this.TxtResponse.TabIndex = 3;
            // 
            // tbRestUrl
            // 
            this.tbRestUrl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tbRestUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRestUrl.Location = new System.Drawing.Point(99, 24);
            this.tbRestUrl.Name = "tbRestUrl";
            this.tbRestUrl.Size = new System.Drawing.Size(237, 24);
            this.tbRestUrl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Debug Output :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "RestFull Url :";
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 687);
            this.Controls.Add(this.mainSplitContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ConHIS Interface format OPD & IPD V2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.pnRestFullAPI.ResumeLayout(false);
            this.gbRestFull.ResumeLayout(false);
            this.gbRestFull.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMainForm;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel pnRestFullAPI;
        private System.Windows.Forms.GroupBox gbRestFull;
        private System.Windows.Forms.TextBox TxtResponse;
        private System.Windows.Forms.TextBox tbRestUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.TextBox tbPrescriptionCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnTimeTable;
        private System.Windows.Forms.Button btnClassify;
    }
}

