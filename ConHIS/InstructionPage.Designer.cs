
namespace ConHIS
{
    partial class InstructionPage
    {
        /// <summary>
        /// Required designer variable.
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionPage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDgvInstructionList = new System.Windows.Forms.GroupBox();
            this.pnDrugSelected = new System.Windows.Forms.Panel();
            this.tbInstructionSearch = new System.Windows.Forms.TextBox();
            this.dgvInstructionSelected = new System.Windows.Forms.DataGridView();
            this.gbInstructionDetail = new System.Windows.Forms.GroupBox();
            this.tbInstructionCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInstructionDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUpdatedAt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEditInstructionDesc = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnEditInstructionCd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.fd_selectdrug = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fd_otderitemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fd_orderitemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fd_orderunitdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtnNewOrder = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.gbDgvInstructionList.SuspendLayout();
            this.pnDrugSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructionSelected)).BeginInit();
            this.gbInstructionDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDgvInstructionList
            // 
            this.gbDgvInstructionList.BackColor = System.Drawing.SystemColors.Menu;
            this.gbDgvInstructionList.Controls.Add(this.pnDrugSelected);
            this.gbDgvInstructionList.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbDgvInstructionList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbDgvInstructionList.Font = new System.Drawing.Font("Athiti Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDgvInstructionList.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gbDgvInstructionList.Location = new System.Drawing.Point(0, 0);
            this.gbDgvInstructionList.Name = "gbDgvInstructionList";
            this.gbDgvInstructionList.Size = new System.Drawing.Size(394, 211);
            this.gbDgvInstructionList.TabIndex = 22;
            this.gbDgvInstructionList.TabStop = false;
            this.gbDgvInstructionList.Text = "รายการข้อมูลวิธีการใช้ยา";
            // 
            // pnDrugSelected
            // 
            this.pnDrugSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnDrugSelected.BackColor = System.Drawing.SystemColors.Control;
            this.pnDrugSelected.Controls.Add(this.rbtnNewOrder);
            this.pnDrugSelected.Controls.Add(this.rbtnAll);
            this.pnDrugSelected.Controls.Add(this.btnSearch);
            this.pnDrugSelected.Controls.Add(this.tbInstructionSearch);
            this.pnDrugSelected.Controls.Add(this.dgvInstructionSelected);
            this.pnDrugSelected.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDrugSelected.Location = new System.Drawing.Point(6, 26);
            this.pnDrugSelected.Name = "pnDrugSelected";
            this.pnDrugSelected.Size = new System.Drawing.Size(385, 179);
            this.pnDrugSelected.TabIndex = 20;
            // 
            // tbInstructionSearch
            // 
            this.tbInstructionSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbInstructionSearch.BackColor = System.Drawing.Color.Pink;
            this.tbInstructionSearch.Location = new System.Drawing.Point(174, 8);
            this.tbInstructionSearch.Name = "tbInstructionSearch";
            this.tbInstructionSearch.Size = new System.Drawing.Size(113, 27);
            this.tbInstructionSearch.TabIndex = 20;
            this.tbInstructionSearch.TextChanged += new System.EventHandler(this.tbInstructionSearch_TextChanged);
            // 
            // dgvInstructionSelected
            // 
            this.dgvInstructionSelected.AllowUserToAddRows = false;
            this.dgvInstructionSelected.AllowUserToDeleteRows = false;
            this.dgvInstructionSelected.AllowUserToResizeColumns = false;
            this.dgvInstructionSelected.AllowUserToResizeRows = false;
            this.dgvInstructionSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInstructionSelected.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInstructionSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvInstructionSelected.ColumnHeadersHeight = 25;
            this.dgvInstructionSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInstructionSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fd_selectdrug,
            this.fd_otderitemcode,
            this.fd_orderitemname,
            this.fd_orderunitdesc});
            this.dgvInstructionSelected.GridColor = System.Drawing.Color.White;
            this.dgvInstructionSelected.Location = new System.Drawing.Point(5, 40);
            this.dgvInstructionSelected.Name = "dgvInstructionSelected";
            this.dgvInstructionSelected.RowHeadersVisible = false;
            this.dgvInstructionSelected.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            this.dgvInstructionSelected.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvInstructionSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstructionSelected.Size = new System.Drawing.Size(376, 136);
            this.dgvInstructionSelected.TabIndex = 1;
            this.dgvInstructionSelected.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInstructionSelected_CellMouseClick);
            // 
            // gbInstructionDetail
            // 
            this.gbInstructionDetail.BackColor = System.Drawing.Color.White;
            this.gbInstructionDetail.Controls.Add(this.tbUpdatedAt);
            this.gbInstructionDetail.Controls.Add(this.label14);
            this.gbInstructionDetail.Controls.Add(this.btnEditInstructionDesc);
            this.gbInstructionDetail.Controls.Add(this.tbInstructionDesc);
            this.gbInstructionDetail.Controls.Add(this.label2);
            this.gbInstructionDetail.Controls.Add(this.btnCancel);
            this.gbInstructionDetail.Controls.Add(this.btnOK);
            this.gbInstructionDetail.Controls.Add(this.btnEditInstructionCd);
            this.gbInstructionDetail.Controls.Add(this.tbInstructionCode);
            this.gbInstructionDetail.Controls.Add(this.label1);
            this.gbInstructionDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInstructionDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbInstructionDetail.Font = new System.Drawing.Font("Athiti Medium", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInstructionDetail.ForeColor = System.Drawing.Color.RoyalBlue;
            this.gbInstructionDetail.Location = new System.Drawing.Point(400, 0);
            this.gbInstructionDetail.Name = "gbInstructionDetail";
            this.gbInstructionDetail.Size = new System.Drawing.Size(384, 211);
            this.gbInstructionDetail.TabIndex = 23;
            this.gbInstructionDetail.TabStop = false;
            this.gbInstructionDetail.Text = "รายละเอียดวิธีใช้ยา";
            // 
            // tbInstructionCode
            // 
            this.tbInstructionCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInstructionCode.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstructionCode.Location = new System.Drawing.Point(107, 38);
            this.tbInstructionCode.Name = "tbInstructionCode";
            this.tbInstructionCode.Size = new System.Drawing.Size(228, 27);
            this.tbInstructionCode.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "รหัสวิธีใช้ยา :";
            // 
            // tbInstructionDesc
            // 
            this.tbInstructionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInstructionDesc.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstructionDesc.Location = new System.Drawing.Point(107, 70);
            this.tbInstructionDesc.Multiline = true;
            this.tbInstructionDesc.Name = "tbInstructionDesc";
            this.tbInstructionDesc.Size = new System.Drawing.Size(228, 59);
            this.tbInstructionDesc.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "คำอธิบายวิธีใช้ยา :";
            // 
            // tbUpdatedAt
            // 
            this.tbUpdatedAt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUpdatedAt.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUpdatedAt.Location = new System.Drawing.Point(107, 134);
            this.tbUpdatedAt.Name = "tbUpdatedAt";
            this.tbUpdatedAt.Size = new System.Drawing.Size(227, 27);
            this.tbUpdatedAt.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(25, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 19);
            this.label14.TabIndex = 52;
            this.label14.Text = "อัพเดทข้อมูล :";
            // 
            // btnEditInstructionDesc
            // 
            this.btnEditInstructionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInstructionDesc.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInstructionDesc.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnEditInstructionDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnEditInstructionDesc.Image")));
            this.btnEditInstructionDesc.Location = new System.Drawing.Point(340, 69);
            this.btnEditInstructionDesc.Name = "btnEditInstructionDesc";
            this.btnEditInstructionDesc.Size = new System.Drawing.Size(30, 30);
            this.btnEditInstructionDesc.TabIndex = 51;
            this.btnEditInstructionDesc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditInstructionDesc.UseVisualStyleBackColor = true;
            this.btnEditInstructionDesc.Click += new System.EventHandler(this.btnEditInstructionDesc_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(259, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(172, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 47;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnEditInstructionCd
            // 
            this.btnEditInstructionCd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInstructionCd.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInstructionCd.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnEditInstructionCd.Image = ((System.Drawing.Image)(resources.GetObject("btnEditInstructionCd.Image")));
            this.btnEditInstructionCd.Location = new System.Drawing.Point(341, 36);
            this.btnEditInstructionCd.Name = "btnEditInstructionCd";
            this.btnEditInstructionCd.Size = new System.Drawing.Size(30, 30);
            this.btnEditInstructionCd.TabIndex = 46;
            this.btnEditInstructionCd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditInstructionCd.UseVisualStyleBackColor = true;
            this.btnEditInstructionCd.Click += new System.EventHandler(this.btnEditInstructionCd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(292, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fd_selectdrug
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle14.NullValue = false;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Maroon;
            this.fd_selectdrug.DefaultCellStyle = dataGridViewCellStyle14;
            this.fd_selectdrug.HeaderText = "เลือก";
            this.fd_selectdrug.Name = "fd_selectdrug";
            this.fd_selectdrug.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fd_selectdrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fd_selectdrug.Width = 45;
            // 
            // fd_otderitemcode
            // 
            this.fd_otderitemcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Athiti", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Maroon;
            this.fd_otderitemcode.DefaultCellStyle = dataGridViewCellStyle15;
            this.fd_otderitemcode.HeaderText = "รหัสวิธีใช้ยา";
            this.fd_otderitemcode.Name = "fd_otderitemcode";
            this.fd_otderitemcode.Width = 86;
            // 
            // fd_orderitemname
            // 
            this.fd_orderitemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Athiti", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Maroon;
            this.fd_orderitemname.DefaultCellStyle = dataGridViewCellStyle16;
            this.fd_orderitemname.HeaderText = "คำอธิบายวิธีใช้ยา";
            this.fd_orderitemname.Name = "fd_orderitemname";
            this.fd_orderitemname.Width = 109;
            // 
            // fd_orderunitdesc
            // 
            this.fd_orderunitdesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Athiti", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Maroon;
            this.fd_orderunitdesc.DefaultCellStyle = dataGridViewCellStyle17;
            this.fd_orderunitdesc.HeaderText = "วันเวลาที่ทำการอัพเดท";
            this.fd_orderunitdesc.Name = "fd_orderunitdesc";
            this.fd_orderunitdesc.Visible = false;
            this.fd_orderunitdesc.Width = 137;
            // 
            // rbtnNewOrder
            // 
            this.rbtnNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnNewOrder.AutoSize = true;
            this.rbtnNewOrder.Location = new System.Drawing.Point(89, 8);
            this.rbtnNewOrder.Name = "rbtnNewOrder";
            this.rbtnNewOrder.Size = new System.Drawing.Size(79, 23);
            this.rbtnNewOrder.TabIndex = 28;
            this.rbtnNewOrder.TabStop = true;
            this.rbtnNewOrder.Text = "รายการใหม่";
            this.rbtnNewOrder.UseVisualStyleBackColor = true;
            this.rbtnNewOrder.CheckedChanged += new System.EventHandler(this.rbtnNewOrder_CheckedChanged);
            // 
            // rbtnAll
            // 
            this.rbtnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Location = new System.Drawing.Point(6, 8);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(60, 23);
            this.rbtnAll.TabIndex = 27;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "ทั้งหมด";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // InstructionPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 211);
            this.Controls.Add(this.gbInstructionDetail);
            this.Controls.Add(this.gbDgvInstructionList);
            this.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 250);
            this.Name = "InstructionPage";
            this.Text = "ข้อมูลวิธีการใช้ยา ( Instruction )";
            this.Load += new System.EventHandler(this.InstructionPage_Load);
            this.gbDgvInstructionList.ResumeLayout(false);
            this.pnDrugSelected.ResumeLayout(false);
            this.pnDrugSelected.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructionSelected)).EndInit();
            this.gbInstructionDetail.ResumeLayout(false);
            this.gbInstructionDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDgvInstructionList;
        private System.Windows.Forms.Panel pnDrugSelected;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbInstructionSearch;
        private System.Windows.Forms.DataGridView dgvInstructionSelected;
        private System.Windows.Forms.GroupBox gbInstructionDetail;
        private System.Windows.Forms.Button btnEditInstructionCd;
        private System.Windows.Forms.TextBox tbInstructionCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditInstructionDesc;
        private System.Windows.Forms.TextBox tbInstructionDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbUpdatedAt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fd_selectdrug;
        private System.Windows.Forms.DataGridViewTextBoxColumn fd_otderitemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn fd_orderitemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fd_orderunitdesc;
        private System.Windows.Forms.RadioButton rbtnNewOrder;
        private System.Windows.Forms.RadioButton rbtnAll;
    }
}