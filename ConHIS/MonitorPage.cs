using System;
using System.Data;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class MonitorPage : Form
    {
        //Variable And Objects

        private Thaneshopmiddle_ATPM th = new Thaneshopmiddle_ATPM();     //Create Objects Class Thanes Middle Table

        //Constructor And Abstract Class
        public MonitorPage()
        {
            InitializeComponent();
        }

        //Event From Load
        private void MonitorPage_Load(object sender, EventArgs e)
        {
            this.DisplayDataChartDrugTypeProcess();
            this.DisplayDataChartMachineWorkloadProcess();
            this.DisplayDataChartWardloadProcess();
        }

        //Function to display the data donut chart of the Drug Type in the system.
        private void DisplayDataChartDrugTypeProcess()
        {
            DataSet ds = null;
            ds = th.DrugTypeAmountOfRealtime();

            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.ChartDrugType.DataSource = ds;
                this.ChartDrugType.Series["DrugTypeName"].XValueMember = "UnitCode";
                this.ChartDrugType.Series["DrugTypeName"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartDrugType.Series["DrugTypeName"].YValueMembers = "Total";
                this.ChartDrugType.Series["DrugTypeName"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
            else
            {
                this.ChartDrugType.DataSource = null;
            }
        }

        //Function to display the data Grant chart of the workload Machine Location in the system.
        private void DisplayDataChartMachineWorkloadProcess()
        {
            DataSet ds = null;
            ds = th.MachineWorkLoadAmountOfRealtime();

            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.ChartMachineLocation.DataSource = ds;
                this.ChartMachineLocation.Series["จำนวนรายการยา"].XValueMember = "MachineLoacation";
                this.ChartMachineLocation.Series["จำนวนรายการยา"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartMachineLocation.Series["จำนวนรายการยา"].YValueMembers = "ItemsPharmacy";
                this.ChartMachineLocation.Series["จำนวนรายการยา"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
            else
            {
                this.ChartMachineLocation.DataSource = null;
            }
        }

        private void DisplayDataChartWardloadProcess()
        {
            DataSet ds = null;
            ds = th.WardWorkLoadAmountOfRealtime();

            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.ChartEachWard.DataSource = ds;
                this.ChartEachWard.Series["จำนวนผู้ป่วย / วอร์ด"].XValueMember = "WardName";
                this.ChartEachWard.Series["จำนวนผู้ป่วย / วอร์ด"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartEachWard.Series["จำนวนผู้ป่วย / วอร์ด"].YValueMembers = "PatientByWard";
                this.ChartEachWard.Series["จำนวนผู้ป่วย / วอร์ด"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                this.ChartEachWard.Series["จำนวนใบยา / วอร์ด"].XValueMember = "WardName";
                this.ChartEachWard.Series["จำนวนใบยา / วอร์ด"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartEachWard.Series["จำนวนใบยา / วอร์ด"].YValueMembers = "PrescriptionByWard";
                this.ChartEachWard.Series["จำนวนใบยา / วอร์ด"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                this.ChartEachWard.Series["จำนวนรายการยา / วอร์ด"].XValueMember = "WardName";
                this.ChartEachWard.Series["จำนวนรายการยา / วอร์ด"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartEachWard.Series["จำนวนรายการยา / วอร์ด"].YValueMembers = "itemsByWard";
                this.ChartEachWard.Series["จำนวนรายการยา / วอร์ด"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
            else
            {
                this.ChartEachWard.DataSource = null;
            }
        }
    }
}