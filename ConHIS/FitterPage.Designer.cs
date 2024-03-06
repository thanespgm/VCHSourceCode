namespace ConHIS
{
    partial class FitterPage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.tabFitter = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDisplay);
            this.tabControl1.Controls.Add(this.tabFitter);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(776, 535);
            this.tabDisplay.TabIndex = 0;
            this.tabDisplay.Text = "การแสดงผลข้อมูล";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // tabFitter
            // 
            this.tabFitter.Location = new System.Drawing.Point(4, 22);
            this.tabFitter.Name = "tabFitter";
            this.tabFitter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFitter.Size = new System.Drawing.Size(776, 535);
            this.tabFitter.TabIndex = 1;
            this.tabFitter.Text = "การกรองข้อมูล";
            this.tabFitter.UseVisualStyleBackColor = true;
            // 
            // FitterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FitterPage";
            this.Text = "การนำเสนอและการกรองข้อมูล";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.TabPage tabFitter;
    }
}