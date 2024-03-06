namespace ConHIS
{
    partial class SettingsPage
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ทั่วไป");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ฐานข้อมูล");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ที่อยู่ไฟล์");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.tv_MenuSettings = new System.Windows.Forms.TreeView();
            this.imageListfortv = new System.Windows.Forms.ImageList(this.components);
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.pnSpace = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_MenuSettings
            // 
            this.tv_MenuSettings.ImageIndex = 0;
            this.tv_MenuSettings.ImageList = this.imageListfortv;
            this.tv_MenuSettings.Location = new System.Drawing.Point(12, 12);
            this.tv_MenuSettings.Name = "tv_MenuSettings";
            treeNode1.Name = "n_general";
            treeNode1.Text = "ทั่วไป";
            treeNode2.Name = "n_database";
            treeNode2.Text = "ฐานข้อมูล";
            treeNode3.Name = "n_pathfile";
            treeNode3.Text = "ที่อยู่ไฟล์";
            this.tv_MenuSettings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tv_MenuSettings.SelectedImageIndex = 0;
            this.tv_MenuSettings.Size = new System.Drawing.Size(192, 644);
            this.tv_MenuSettings.TabIndex = 0;
            this.tv_MenuSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tv_MenuSettings_AfterSelect);
            // 
            // imageListfortv
            // 
            this.imageListfortv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListfortv.ImageStream")));
            this.imageListfortv.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListfortv.Images.SetKeyName(0, "unchecked.png");
            this.imageListfortv.Images.SetKeyName(1, "checked.png");
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.pnSpace);
            this.gbPanel.Location = new System.Drawing.Point(210, 7);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(662, 605);
            this.gbPanel.TabIndex = 1;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "ทั่วไป";
            // 
            // pnSpace
            // 
            this.pnSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSpace.Location = new System.Drawing.Point(3, 23);
            this.pnSpace.Name = "pnSpace";
            this.pnSpace.Size = new System.Drawing.Size(656, 579);
            this.pnSpace.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(709, 618);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(796, 618);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SettingsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbPanel);
            this.Controls.Add(this.tv_MenuSettings);
            this.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ตั้งค่าระบบ";
            this.Load += new System.EventHandler(this.SettingsPage_Load);
            this.gbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_MenuSettings;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnSpace;
        private System.Windows.Forms.ImageList imageListfortv;
    }
}