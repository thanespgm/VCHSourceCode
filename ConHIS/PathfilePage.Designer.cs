namespace ConHIS
{
    partial class PathFilePage
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
            this.gbFileSource = new System.Windows.Forms.GroupBox();
            this.BtnBrowSepathSource = new System.Windows.Forms.Button();
            this.tbPathSourceLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFileDestination = new System.Windows.Forms.GroupBox();
            this.BtnBrowSepathDestination = new System.Windows.Forms.Button();
            this.tbPathDestinationLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAboutTheProgram = new System.Windows.Forms.GroupBox();
            this.BtnBrowseDatabaSepathBackup = new System.Windows.Forms.Button();
            this.tbPathDatabaseBackup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBrowSeprogramPathBackup = new System.Windows.Forms.Button();
            this.tbPathProgramBackup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnBrowSepathLogs = new System.Windows.Forms.Button();
            this.tbPathLogs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnDefault = new System.Windows.Forms.Button();
            this.gbFileSource.SuspendLayout();
            this.gbFileDestination.SuspendLayout();
            this.gbAboutTheProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFileSource
            // 
            this.gbFileSource.Controls.Add(this.BtnBrowSepathSource);
            this.gbFileSource.Controls.Add(this.tbPathSourceLocation);
            this.gbFileSource.Controls.Add(this.label1);
            this.gbFileSource.Location = new System.Drawing.Point(17, 17);
            this.gbFileSource.Name = "gbFileSource";
            this.gbFileSource.Size = new System.Drawing.Size(520, 60);
            this.gbFileSource.TabIndex = 0;
            this.gbFileSource.TabStop = false;
            this.gbFileSource.Text = "ต้นทางข้อมูล [File Source]";
            // 
            // BtnBrowSepathSource
            // 
            this.BtnBrowSepathSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BtnBrowSepathSource.Location = new System.Drawing.Point(422, 23);
            this.BtnBrowSepathSource.Name = "BtnBrowSepathSource";
            this.BtnBrowSepathSource.Size = new System.Drawing.Size(73, 28);
            this.BtnBrowSepathSource.TabIndex = 10;
            this.BtnBrowSepathSource.Text = "Browse";
            this.BtnBrowSepathSource.UseVisualStyleBackColor = true;
            this.BtnBrowSepathSource.Click += new System.EventHandler(this.BtnBrowSepathSource_Click);
            // 
            // tbPathSourceLocation
            // 
            this.tbPathSourceLocation.Location = new System.Drawing.Point(169, 24);
            this.tbPathSourceLocation.Name = "tbPathSourceLocation";
            this.tbPathSourceLocation.Size = new System.Drawing.Size(238, 27);
            this.tbPathSourceLocation.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path Location:";
            // 
            // gbFileDestination
            // 
            this.gbFileDestination.Controls.Add(this.BtnBrowSepathDestination);
            this.gbFileDestination.Controls.Add(this.tbPathDestinationLocation);
            this.gbFileDestination.Controls.Add(this.label2);
            this.gbFileDestination.Location = new System.Drawing.Point(18, 85);
            this.gbFileDestination.Name = "gbFileDestination";
            this.gbFileDestination.Size = new System.Drawing.Size(520, 63);
            this.gbFileDestination.TabIndex = 1;
            this.gbFileDestination.TabStop = false;
            this.gbFileDestination.Text = "ปลายทางจัดเก็บข้อมูล [File Destination]";
            // 
            // BtnBrowSepathDestination
            // 
            this.BtnBrowSepathDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BtnBrowSepathDestination.Location = new System.Drawing.Point(421, 24);
            this.BtnBrowSepathDestination.Name = "BtnBrowSepathDestination";
            this.BtnBrowSepathDestination.Size = new System.Drawing.Size(73, 29);
            this.BtnBrowSepathDestination.TabIndex = 13;
            this.BtnBrowSepathDestination.Text = "Browse";
            this.BtnBrowSepathDestination.UseVisualStyleBackColor = true;
            this.BtnBrowSepathDestination.Click += new System.EventHandler(this.BtnBrowSepathDestination_Click);
            // 
            // tbPathDestinationLocation
            // 
            this.tbPathDestinationLocation.Location = new System.Drawing.Point(168, 26);
            this.tbPathDestinationLocation.Name = "tbPathDestinationLocation";
            this.tbPathDestinationLocation.Size = new System.Drawing.Size(238, 27);
            this.tbPathDestinationLocation.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Path Location:";
            // 
            // gbAboutTheProgram
            // 
            this.gbAboutTheProgram.Controls.Add(this.BtnBrowseDatabaSepathBackup);
            this.gbAboutTheProgram.Controls.Add(this.tbPathDatabaseBackup);
            this.gbAboutTheProgram.Controls.Add(this.label5);
            this.gbAboutTheProgram.Controls.Add(this.BtnBrowSeprogramPathBackup);
            this.gbAboutTheProgram.Controls.Add(this.tbPathProgramBackup);
            this.gbAboutTheProgram.Controls.Add(this.label4);
            this.gbAboutTheProgram.Controls.Add(this.BtnBrowSepathLogs);
            this.gbAboutTheProgram.Controls.Add(this.tbPathLogs);
            this.gbAboutTheProgram.Controls.Add(this.label3);
            this.gbAboutTheProgram.Location = new System.Drawing.Point(18, 154);
            this.gbAboutTheProgram.Name = "gbAboutTheProgram";
            this.gbAboutTheProgram.Size = new System.Drawing.Size(520, 177);
            this.gbAboutTheProgram.TabIndex = 2;
            this.gbAboutTheProgram.TabStop = false;
            this.gbAboutTheProgram.Text = "ที่อยู่จัดเก็บ [About the program]";
            // 
            // BtnBrowseDatabaSepathBackup
            // 
            this.BtnBrowseDatabaSepathBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BtnBrowseDatabaSepathBackup.Location = new System.Drawing.Point(421, 90);
            this.BtnBrowseDatabaSepathBackup.Name = "BtnBrowseDatabaSepathBackup";
            this.BtnBrowseDatabaSepathBackup.Size = new System.Drawing.Size(73, 27);
            this.BtnBrowseDatabaSepathBackup.TabIndex = 22;
            this.BtnBrowseDatabaSepathBackup.Text = "Browse";
            this.BtnBrowseDatabaSepathBackup.UseVisualStyleBackColor = true;
            this.BtnBrowseDatabaSepathBackup.Click += new System.EventHandler(this.BtnBrowseDatabaSepathBackup_Click);
            // 
            // tbPathDatabaseBackup
            // 
            this.tbPathDatabaseBackup.Location = new System.Drawing.Point(168, 90);
            this.tbPathDatabaseBackup.Name = "tbPathDatabaseBackup";
            this.tbPathDatabaseBackup.Size = new System.Drawing.Size(238, 27);
            this.tbPathDatabaseBackup.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Database Backup Location:";
            // 
            // BtnBrowSeprogramPathBackup
            // 
            this.BtnBrowSeprogramPathBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BtnBrowSeprogramPathBackup.Location = new System.Drawing.Point(421, 58);
            this.BtnBrowSeprogramPathBackup.Name = "BtnBrowSeprogramPathBackup";
            this.BtnBrowSeprogramPathBackup.Size = new System.Drawing.Size(73, 28);
            this.BtnBrowSeprogramPathBackup.TabIndex = 19;
            this.BtnBrowSeprogramPathBackup.Text = "Browse";
            this.BtnBrowSeprogramPathBackup.UseVisualStyleBackColor = true;
            this.BtnBrowSeprogramPathBackup.Click += new System.EventHandler(this.BtnBrowSeprogramPathBackup_Click);
            // 
            // tbPathProgramBackup
            // 
            this.tbPathProgramBackup.Location = new System.Drawing.Point(168, 59);
            this.tbPathProgramBackup.Name = "tbPathProgramBackup";
            this.tbPathProgramBackup.Size = new System.Drawing.Size(238, 27);
            this.tbPathProgramBackup.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Program Backup Location:";
            // 
            // BtnBrowSepathLogs
            // 
            this.BtnBrowSepathLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BtnBrowSepathLogs.Location = new System.Drawing.Point(421, 27);
            this.BtnBrowSepathLogs.Name = "BtnBrowSepathLogs";
            this.BtnBrowSepathLogs.Size = new System.Drawing.Size(73, 28);
            this.BtnBrowSepathLogs.TabIndex = 16;
            this.BtnBrowSepathLogs.Text = "Browse";
            this.BtnBrowSepathLogs.UseVisualStyleBackColor = true;
            this.BtnBrowSepathLogs.Click += new System.EventHandler(this.BtnBrowSepathLogs_Click);
            // 
            // tbPathLogs
            // 
            this.tbPathLogs.Location = new System.Drawing.Point(168, 28);
            this.tbPathLogs.Name = "tbPathLogs";
            this.tbPathLogs.Size = new System.Drawing.Size(238, 27);
            this.tbPathLogs.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Logs Location:";
            // 
            // BtnDefault
            // 
            this.BtnDefault.Location = new System.Drawing.Point(418, 343);
            this.BtnDefault.Name = "BtnDefault";
            this.BtnDefault.Size = new System.Drawing.Size(119, 36);
            this.BtnDefault.TabIndex = 11;
            this.BtnDefault.Text = "Default";
            this.BtnDefault.UseVisualStyleBackColor = true;
            this.BtnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // PathFilePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.BtnDefault);
            this.Controls.Add(this.gbAboutTheProgram);
            this.Controls.Add(this.gbFileDestination);
            this.Controls.Add(this.gbFileSource);
            this.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PathFilePage";
            this.Size = new System.Drawing.Size(556, 388);
            this.Load += new System.EventHandler(this.PathFilePage_Load);
            this.gbFileSource.ResumeLayout(false);
            this.gbFileSource.PerformLayout();
            this.gbFileDestination.ResumeLayout(false);
            this.gbFileDestination.PerformLayout();
            this.gbAboutTheProgram.ResumeLayout(false);
            this.gbAboutTheProgram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFileSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbFileDestination;
        private System.Windows.Forms.GroupBox gbAboutTheProgram;
        private System.Windows.Forms.TextBox tbPathSourceLocation;
        private System.Windows.Forms.Button BtnBrowSepathSource;
        private System.Windows.Forms.Button BtnBrowSepathDestination;
        private System.Windows.Forms.TextBox tbPathDestinationLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnBrowSeprogramPathBackup;
        private System.Windows.Forms.TextBox tbPathProgramBackup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBrowSepathLogs;
        private System.Windows.Forms.TextBox tbPathLogs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBrowseDatabaSepathBackup;
        private System.Windows.Forms.TextBox tbPathDatabaseBackup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnDefault;
    }
}
