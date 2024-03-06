namespace ConHIS
{
    partial class MonitorPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChartDrugType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChartMachineLocation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TCMonitorWorkload = new System.Windows.Forms.TabControl();
            this.TPPrescriptionWorkLoad = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChartEachWard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TPDrugAndInventoryWorkLoad = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartDrugType)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMachineLocation)).BeginInit();
            this.TCMonitorWorkload.SuspendLayout();
            this.TPPrescriptionWorkLoad.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEachWard)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChartDrugType);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "แผนผังแสดงประเภทยาในระบบ";
            // 
            // ChartDrugType
            // 
            chartArea13.Area3DStyle.Inclination = 1;
            chartArea13.Name = "DataDrugType";
            this.ChartDrugType.ChartAreas.Add(chartArea13);
            this.ChartDrugType.Dock = System.Windows.Forms.DockStyle.Fill;
            legend13.Alignment = System.Drawing.StringAlignment.Center;
            legend13.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            legend13.DockedToChartArea = "DataDrugType";
            legend13.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend13.ForeColor = System.Drawing.Color.Navy;
            legend13.IsDockedInsideChartArea = false;
            legend13.IsTextAutoFit = false;
            legend13.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend13.MaximumAutoSize = 100F;
            legend13.Name = "DataName";
            legend13.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend13.TitleFont = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartDrugType.Legends.Add(legend13);
            this.ChartDrugType.Location = new System.Drawing.Point(3, 20);
            this.ChartDrugType.Name = "ChartDrugType";
            series21.ChartArea = "DataDrugType";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series21.EmptyPointStyle.IsVisibleInLegend = false;
            series21.EmptyPointStyle.LabelBorderWidth = 0;
            series21.Font = new System.Drawing.Font("Comic Sans MS", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series21.IsValueShownAsLabel = true;
            series21.IsXValueIndexed = true;
            series21.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series21.LabelBorderWidth = 0;
            series21.LabelForeColor = System.Drawing.Color.White;
            series21.Legend = "DataName";
            series21.Name = "DrugTypeName";
            series21.SmartLabelStyle.Enabled = false;
            series21.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series21.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.ChartDrugType.Series.Add(series21);
            this.ChartDrugType.Size = new System.Drawing.Size(319, 243);
            this.ChartDrugType.TabIndex = 1;
            this.ChartDrugType.Text = "chart";
            title13.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title13.Name = "Priorty Chart";
            title13.Visible = false;
            this.ChartDrugType.Titles.Add(title13);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ChartMachineLocation);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(337, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(999, 266);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "แผนผังแสดงปริมาณงานของเครื่องหรือหุ่นยนต์จัดยา";
            // 
            // ChartMachineLocation
            // 
            this.ChartMachineLocation.BackColor = System.Drawing.Color.Transparent;
            this.ChartMachineLocation.BorderlineColor = System.Drawing.Color.Black;
            chartArea14.Area3DStyle.Inclination = 1;
            chartArea14.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea14.AxisX.Crossing = 100D;
            chartArea14.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea14.AxisX.Interval = 1D;
            chartArea14.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea14.AxisX.LabelStyle.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea14.AxisX.LineColor = System.Drawing.Color.Gray;
            chartArea14.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea14.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea14.AxisX.MaximumAutoSize = 20F;
            chartArea14.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea14.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.DimGray;
            chartArea14.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea14.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea14.AxisX.Title = "รุ่นหุ่นยนต์อัติโนมัติ";
            chartArea14.AxisX.TitleFont = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisX.TitleForeColor = System.Drawing.Color.DarkSlateGray;
            chartArea14.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea14.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea14.AxisY.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea14.AxisY.Interval = 100D;
            chartArea14.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea14.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea14.AxisY.IsLabelAutoFit = false;
            chartArea14.AxisY.IsMarksNextToAxis = false;
            chartArea14.AxisY.LabelStyle.Font = new System.Drawing.Font("Athiti", 7.249999F);
            chartArea14.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea14.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea14.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea14.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea14.AxisY.Maximum = 1000D;
            chartArea14.AxisY.MaximumAutoSize = 100F;
            chartArea14.AxisY.Minimum = 0D;
            chartArea14.AxisY.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea14.AxisY.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea14.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea14.AxisY.Title = "ปริมาณงานของหุ่นยนต์นับยาอัตโนมัติ";
            chartArea14.AxisY.TitleFont = new System.Drawing.Font("Athiti Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea14.AxisY.TitleForeColor = System.Drawing.Color.DarkSlateGray;
            chartArea14.Name = "DataMachineLocation";
            chartArea14.Position.Auto = false;
            chartArea14.Position.Height = 100F;
            chartArea14.Position.Width = 62.06036F;
            chartArea14.Position.X = 3F;
            chartArea14.ShadowColor = System.Drawing.Color.White;
            this.ChartMachineLocation.ChartAreas.Add(chartArea14);
            this.ChartMachineLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            legend14.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            legend14.DockedToChartArea = "DataMachineLocation";
            legend14.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend14.IsDockedInsideChartArea = false;
            legend14.IsTextAutoFit = false;
            legend14.MaximumAutoSize = 100F;
            legend14.Name = "DataName";
            legend14.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend14.TitleBackColor = System.Drawing.Color.White;
            legend14.TitleFont = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartMachineLocation.Legends.Add(legend14);
            this.ChartMachineLocation.Location = new System.Drawing.Point(3, 20);
            this.ChartMachineLocation.Name = "ChartMachineLocation";
            this.ChartMachineLocation.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series22.ChartArea = "DataMachineLocation";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series22.EmptyPointStyle.IsVisibleInLegend = false;
            series22.EmptyPointStyle.LabelBorderWidth = 0;
            series22.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series22.IsValueShownAsLabel = true;
            series22.IsXValueIndexed = true;
            series22.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series22.LabelBorderWidth = 0;
            series22.LabelForeColor = System.Drawing.Color.DarkSlateGray;
            series22.Legend = "DataName";
            series22.Name = "จำนวนรายการยา";
            series22.SmartLabelStyle.Enabled = false;
            this.ChartMachineLocation.Series.Add(series22);
            this.ChartMachineLocation.Size = new System.Drawing.Size(993, 243);
            this.ChartMachineLocation.TabIndex = 1;
            this.ChartMachineLocation.Text = "chart1";
            title14.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title14.Name = "Machine Chart";
            title14.Visible = false;
            this.ChartMachineLocation.Titles.Add(title14);
            // 
            // TCMonitorWorkload
            // 
            this.TCMonitorWorkload.Controls.Add(this.TPPrescriptionWorkLoad);
            this.TCMonitorWorkload.Controls.Add(this.TPDrugAndInventoryWorkLoad);
            this.TCMonitorWorkload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCMonitorWorkload.Location = new System.Drawing.Point(0, 0);
            this.TCMonitorWorkload.Name = "TCMonitorWorkload";
            this.TCMonitorWorkload.SelectedIndex = 0;
            this.TCMonitorWorkload.Size = new System.Drawing.Size(1350, 687);
            this.TCMonitorWorkload.TabIndex = 2;
            // 
            // TPPrescriptionWorkLoad
            // 
            this.TPPrescriptionWorkLoad.Controls.Add(this.groupBox3);
            this.TPPrescriptionWorkLoad.Controls.Add(this.groupBox1);
            this.TPPrescriptionWorkLoad.Controls.Add(this.groupBox2);
            this.TPPrescriptionWorkLoad.Location = new System.Drawing.Point(4, 28);
            this.TPPrescriptionWorkLoad.Name = "TPPrescriptionWorkLoad";
            this.TPPrescriptionWorkLoad.Padding = new System.Windows.Forms.Padding(3);
            this.TPPrescriptionWorkLoad.Size = new System.Drawing.Size(1342, 655);
            this.TPPrescriptionWorkLoad.TabIndex = 0;
            this.TPPrescriptionWorkLoad.Text = "แสดงข้อมูลเกี่ยวกับใบยา";
            this.TPPrescriptionWorkLoad.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ChartEachWard);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 278);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1336, 374);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "แผนผังแสดงปริมาณงานในแต่ละวอร์ด";
            // 
            // ChartEachWard
            // 
            this.ChartEachWard.BackColor = System.Drawing.Color.Transparent;
            this.ChartEachWard.BorderlineColor = System.Drawing.Color.Black;
            chartArea15.Area3DStyle.Inclination = 1;
            chartArea15.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea15.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea15.AxisX.InterlacedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea15.AxisX.Interval = 1D;
            chartArea15.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea15.AxisX.LabelStyle.Angle = 90;
            chartArea15.AxisX.LabelStyle.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Teal;
            chartArea15.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisX.LineWidth = 0;
            chartArea15.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea15.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisX.MaximumAutoSize = 25F;
            chartArea15.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea15.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisX.Title = "รายการวอร์ดทั้งหมด";
            chartArea15.AxisX.TitleFont = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisX.TitleForeColor = System.Drawing.Color.DarkSlateGray;
            chartArea15.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea15.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea15.AxisY.InterlacedColor = System.Drawing.Color.Transparent;
            chartArea15.AxisY.Interval = 20D;
            chartArea15.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea15.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea15.AxisY.IsLabelAutoFit = false;
            chartArea15.AxisY.IsMarksNextToAxis = false;
            chartArea15.AxisY.LabelStyle.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea15.AxisY.MajorGrid.Interval = 5D;
            chartArea15.AxisY.MajorGrid.IntervalOffset = 5D;
            chartArea15.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea15.AxisY.MajorTickMark.Interval = 10D;
            chartArea15.AxisY.MajorTickMark.IntervalOffset = 10D;
            chartArea15.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisY.Maximum = 200D;
            chartArea15.AxisY.MaximumAutoSize = 100F;
            chartArea15.AxisY.Minimum = 0D;
            chartArea15.AxisY.MinorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisY.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea15.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea15.AxisY.Title = "จำนวนยาและมื้อยาจากหุ่นยนต์อัตโนมัติ ";
            chartArea15.AxisY.TitleFont = new System.Drawing.Font("Athiti Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea15.AxisY.TitleForeColor = System.Drawing.Color.DarkSlateGray;
            chartArea15.Name = "DataPatientByWard";
            chartArea15.Position.Auto = false;
            chartArea15.Position.Height = 100F;
            chartArea15.Position.Width = 62.06036F;
            chartArea15.Position.X = 3F;
            chartArea15.ShadowColor = System.Drawing.Color.White;
            this.ChartEachWard.ChartAreas.Add(chartArea15);
            this.ChartEachWard.Dock = System.Windows.Forms.DockStyle.Fill;
            legend15.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            legend15.DockedToChartArea = "DataPatientByWard";
            legend15.Font = new System.Drawing.Font("Athiti Medium", 8F, System.Drawing.FontStyle.Bold);
            legend15.IsDockedInsideChartArea = false;
            legend15.IsTextAutoFit = false;
            legend15.MaximumAutoSize = 100F;
            legend15.Name = "DataName";
            legend15.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend15.TitleBackColor = System.Drawing.Color.White;
            legend15.TitleFont = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChartEachWard.Legends.Add(legend15);
            this.ChartEachWard.Location = new System.Drawing.Point(3, 20);
            this.ChartEachWard.Name = "ChartEachWard";
            series23.ChartArea = "DataPatientByWard";
            series23.EmptyPointStyle.IsVisibleInLegend = false;
            series23.EmptyPointStyle.LabelBorderWidth = 0;
            series23.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series23.IsValueShownAsLabel = true;
            series23.IsXValueIndexed = true;
            series23.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series23.LabelBorderWidth = 0;
            series23.LabelForeColor = System.Drawing.Color.DarkSlateGray;
            series23.Legend = "DataName";
            series23.Name = "จำนวนผู้ป่วย / วอร์ด";
            dataPoint9.IsValueShownAsLabel = true;
            dataPoint9.LabelBackColor = System.Drawing.Color.Gray;
            dataPoint9.LabelForeColor = System.Drawing.Color.SeaGreen;
            dataPoint10.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataPoint10.LabelForeColor = System.Drawing.Color.SeaGreen;
            series23.Points.Add(dataPoint9);
            series23.Points.Add(dataPoint10);
            series23.SmartLabelStyle.Enabled = false;
            series24.ChartArea = "DataPatientByWard";
            series24.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series24.IsValueShownAsLabel = true;
            series24.IsXValueIndexed = true;
            series24.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series24.LabelBorderWidth = 0;
            series24.LabelForeColor = System.Drawing.Color.Navy;
            series24.Legend = "DataName";
            series24.Name = "จำนวนใบยา / วอร์ด";
            series25.ChartArea = "DataPatientByWard";
            series25.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series25.IsValueShownAsLabel = true;
            series25.IsXValueIndexed = true;
            series25.LabelForeColor = System.Drawing.Color.Red;
            series25.Legend = "DataName";
            series25.Name = "จำนวนรายการยา / วอร์ด";
            this.ChartEachWard.Series.Add(series23);
            this.ChartEachWard.Series.Add(series24);
            this.ChartEachWard.Series.Add(series25);
            this.ChartEachWard.Size = new System.Drawing.Size(1330, 351);
            this.ChartEachWard.TabIndex = 1;
            this.ChartEachWard.Text = "chartEachWard";
            title15.Font = new System.Drawing.Font("Athiti", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title15.Name = "Ward Chart";
            this.ChartEachWard.Titles.Add(title15);
            // 
            // TPDrugAndInventoryWorkLoad
            // 
            this.TPDrugAndInventoryWorkLoad.Location = new System.Drawing.Point(4, 22);
            this.TPDrugAndInventoryWorkLoad.Name = "TPDrugAndInventoryWorkLoad";
            this.TPDrugAndInventoryWorkLoad.Padding = new System.Windows.Forms.Padding(3);
            this.TPDrugAndInventoryWorkLoad.Size = new System.Drawing.Size(1342, 661);
            this.TPDrugAndInventoryWorkLoad.TabIndex = 1;
            this.TPDrugAndInventoryWorkLoad.Text = "แสดงข้อมูลเกี่ยวกับยาและคลังยา";
            this.TPDrugAndInventoryWorkLoad.UseVisualStyleBackColor = true;
            // 
            // MonitorPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 687);
            this.Controls.Add(this.TCMonitorWorkload);
            this.Font = new System.Drawing.Font("Athiti", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MonitorPage";
            this.Text = "รายงานผลการนำเข้าข้อมูลในกระบวนการต่างๆ";
            this.Load += new System.EventHandler(this.MonitorPage_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartDrugType)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartMachineLocation)).EndInit();
            this.TCMonitorWorkload.ResumeLayout(false);
            this.TPPrescriptionWorkLoad.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartEachWard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartDrugType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMachineLocation;
        private System.Windows.Forms.TabControl TCMonitorWorkload;
        private System.Windows.Forms.TabPage TPPrescriptionWorkLoad;
        private System.Windows.Forms.TabPage TPDrugAndInventoryWorkLoad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEachWard;
    }
}