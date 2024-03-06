using ConHIS.API;
using ConHIS.API.Models;
using ConHIS.Libary_Class;
using ConHIS.Libary_Class.CRAInterface.Features;
using ConHIS.Libary_Class.PNNInterface.Features;
using ConHIS.Libary_Class.SKPHInterface.Features;
using ConHIS.Properties;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConHIS
{
    public partial class HomePage : UserControl
    {
        private int itemsCompare = 0;      //Variable are used to compare the differences in the number of prescriptions at each time.
        private int itemsSearchCompare = 0;//Variable are used to compare the differences in the number of prescriptions at each time.
        private int itemsPrescriptionNo = 0;
        private int itemsPatient = 0;
        private int itemsAllData = 0;
        private string strSearch = null;   //Variable Search Prescription Data
        private bool enableload = false;   //Variable Enable Auto load
        private bool enableread = false;   //Variable Enable For Reader Text File
        private DateTime starttime;
        private string pathoverall = null;

        private string event_code;
        private string event_message;
        private readonly Thaneshopmiddle th;     //Create Objects Class Thanes Middle Table
        private readonly System_logfile logs;

        //private readonly Thaneshopmiddle_SUTH thSUTH;     //Create Objects Class Thanes Middle Table
        private readonly Thaneshopmiddle_ATPM thSUTH;    // MIDDLE_V4
        //private readonly Thaneshopmiddle thSUTH;             //TPN For PCMC

        private readonly master_prescription pres;    // MIDDLE_V4
        private int countProcflg = 0;

        private readonly Backup_data bu;             //Create Objects Class Backup Data

        // private string[] hl7file = { };

        public HomePage()
        {
            InitializeComponent();
            LoadSetting();
                th = new Thaneshopmiddle();
                logs = new System_logfile();

                pres = new master_prescription();
                //thSUTH = new Thaneshopmiddle_SUTH();
                thSUTH = new Thaneshopmiddle_ATPM();
                //thSUTH = new Thaneshopmiddle();
                bu = new Backup_data();

                this.BgwGenerate.WorkerReportsProgress = true;
                this.BgwGenerate.WorkerSupportsCancellation = true;
                this.BgwImport.WorkerReportsProgress = true;
                this.BgwImport.WorkerSupportsCancellation = true;            
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            if (Settings.Default.ClientMode == false)
            {
                this.enableload = true;
                this.tmgenerate.Interval = Variable.TmtoRetrieve;
                this.tmgenerate.Enabled = true;
                this.tmgenerate.Start();
                this.tmstatus.Enabled = true;
                this.tmstatus.Start();
                OnloadDataThanesMiddle(true);
                DisplayDatagraphWorkProcess();
                DisplayDataChartPriortyProcess();
                starttime = DateTime.Now;
                this.lbReferenceTime.Text = starttime.ToString("dd-MM-yyyy HH:mm:ss:fff");
                event_code = "P0001";
                event_message = "โปรแกรมถูกเปิด";
                this.WritelogSystem(true);
                this.OnloadAutomaticStart();           //Check Setting Onstart Data Textfile Onload
            }  
        }

        private void HomePage_ControlRemoved(object sender, ControlEventArgs e)
        {
            event_code = "P0002";
            event_message = "โปรแกรมถูกปิด";
            this.WritelogSystem(true);
            this.tmgenerate.Enabled = false;
            this.tmgenerate.Stop();
            this.tmstatus.Enabled = false;
            this.tmstatus.Stop();
            this.Dispose();
        }

        private static void LoadSetting()
        {
           // Variable.InterfaceMode = "CHULABHORN";
            //Variable.InterfaceMode = "VICHAIYUT";
            Variable.InterfaceMode = Settings.Default.onInterfaceMode;
            Variable.SeparatorPattren = Settings.Default.SeparatorPattren;
            Variable.TmtoRetrieve = Settings.Default.TmtoRetrieve;
            Variable.ReadFileWait = Settings.Default.ReadFileWait;
            Variable.Encode_Separator = Settings.Default.Encode_Separator;
            Variable.ServerHosXP = Settings.Default.connMySQL;
            Variable.ServerDBType = Settings.Default.serverDBType;

            Server_config rc = new Server_config();
            Pathfile_config pc = new Pathfile_config();
            if (rc.Readdatabase_config())
            {
                //rc.Readdatabase_HIS_config();

                Variable.DBlocal = rc.ConnectionLocal;
                Variable.DBhost = rc.ConnectionHIS;
            }
            if (pc.ReadPathfile_config())
            {
                Variable.PathLocal = pc.PathFileLocal;
                Variable.PathHost = pc.PathFileHost;
                Variable.PathLogs = pc.PathLogFile;
            }
        }

        private void Tmgenerate_TickAsync(object sender, EventArgs e)
        {
            _ = this.btnstart_import.Enabled;
            this.lbCurrentTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss:fff");
            this.lbDifferenceTime.Text = DifferenceTimeDisplay().ToString();

            //Transection Backup Data.
            //------------------------------------------------------------------------------------
            //Backup Data for PCMC site.
            //------------------------------------------------------------------------------------

            #region "Backup Data for PCMC site"

            //string TimeCompare = DateTime.Now.ToString("HHmm");
            //if (TimeCompare == "0000")
            //{
            //    this.enableread = false;
            //    if (bu.TransectionBackup() == true)
            //        bu.OrderbymachineEV();
            //}
            //else if (TimeCompare == "0005")
            //    this.enableread = true;

            #endregion "Backup Data for PCMC site"

            //-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------
            //Backup for Default Program.
            if (Settings.Default.ClientMode == false)
            {
                if (bu.TransectionBackupAsync())
                {
                    bu.OrderbymachineEVAsync();
                    dgvFileListProgress.Rows.Clear();
                }
            }
               
            this.CheckFileEnters(this.enableread);

            if (!Variable.ClearBackup)
            {
                OnloadDataThanesMiddle(true);
            }
            else
            {
                this.dgvFileListProgress.Rows.Clear();
                OnloadDataThanesMiddle(true);
            }       
        }

        //The function checks the data when a new file enters the Wait folder.
        private async void CheckFileEnters(bool status)
        {
            if (status)  // connected
            {

                switch (Variable.InterfaceMode)
                {
                    case "BDMS":

                        // Generate_textfile gentxt = new Generate_textfile(Variable.PathHost, Variable.SeparatorPattren);  //Create Objects Class Generate Text File
                        Generate_textfile_ATPM gentxt = new Generate_textfile_ATPM(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4
                        string[] pathfile = gentxt.GetFileNamesHost("*.txt");
                        if (pathfile != null)
                        {
                            if (!BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;

                    case "HUACHIEW":

                        // Generate_textfile gentxt = new Generate_textfile(Variable.PathHost, Variable.SeparatorPattren);  //Create Objects Class Generate Text File
                        Generate_textfile_ATPM genHch = new Generate_textfile_ATPM(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4
                        string[] pathfileHch = genHch.GetFileNamesHost("*.txt");
                        if (pathfileHch != null)
                        {
                            if (!BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;

                    case "CHULABHORN":
                        GetHL7ToDBStructure chulabhorn = new GetHL7ToDBStructure(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4
                        string[] hl7file = await Task.Run(() => chulabhorn.GetFileNamesHost("*.hl7"));
                        if (hl7file.Length != 0)
                        {
                            if (!BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;

                    case "HOSXP":

                        Hosxp_opd_pres_machine hos = new Hosxp_opd_pres_machine(Variable.ServerDBType);
                        int count;
                        try
                        {
                            DataSet itemsGetHosXP = hos.GetDataHn("wait", "1");
                            count = itemsGetHosXP.Tables[0].Rows.Count;
                        }
                        catch (Exception e) { throw new Exception(" " + e.Message); }

                        if (count != 0)
                        {
                            int dsItemsAll = Convert.ToInt32(th.ItemsAllDataPatient());
                            if ((count != dsItemsAll) && (count > dsItemsAll))
                            {
                                if (!BgwImport.IsBusy)
                                {
                                    OnloadDataThanesMiddle(true);
                                    this.BgwImport.RunWorkerAsync();
                                    this.progressbar_overall.Visible = true;
                                    this.txt_overall.Text = "0%";
                                    this.UpdateprocessImport(0);
                                    this.btnstart_import.Enabled = false;
                                    this.btnpause_import.Enabled = true;
                                    this.btnstop_import_process.Enabled = true;
                                }
                            }
                        }
                        break;

                    case "VICHAIYUT":

                        Thaneshopmiddle_VICHAIYUT imed = new Thaneshopmiddle_VICHAIYUT();
                        int countIMed = 0;
                        try
                        {
                            DataSet itemsGetHosIMed = imed.GetDataPrescriptionReady(2);
                            countIMed = itemsGetHosIMed.Tables[0].Rows.Count;
                            event_code = "Request";
                            event_message = " ร้องขอข้อมูลตรวจพบข้อมูลใหม่ "+ countIMed + " รายการ";
                        }
                        catch (Exception e)
                        {
                            throw new Exception(" " + e.Message);
                            event_code = "Error";
                            event_message = e.Message;
                        }
                        this.WritelogSystem(true);

                        if (countIMed != 0)
                        {
                            int dsItemsAll = Convert.ToInt32(th.ItemsAllDataPrescription());
                            //if ((countIMed != dsItemsAll) && (countIMed > dsItemsAll))
                            //{
                                if (!BgwImport.IsBusy)
                                {
                                    OnloadDataThanesMiddle(true);
                                    this.BgwImport.RunWorkerAsync();
                                    this.progressbar_overall.Visible = true;
                                    this.txt_overall.Text = "0%";
                                    this.UpdateprocessImport(0);
                                    this.btnstart_import.Enabled = false;
                                    this.btnpause_import.Enabled = true;
                                    this.btnstop_import_process.Enabled = true;
                                }
                           // }
                        }
                        break;

                    case "PCMC_OPD_HL7":
                        //For PCMC
                        hosxp_conhis_machine_opd hosHL7 = new hosxp_conhis_machine_opd();
                        //For SUTH 
                       // hosxp_conhis_machine hosHL7 = new hosxp_conhis_machine();
                        int countHL7;
                        try
                        {
                            DataSet itemsGetHL7 = hosHL7.GetDataFileID();
                            countHL7 = itemsGetHL7.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countHL7 != 0)
                        {
                            if ((countHL7 != 0) && (countHL7 > 0) && !BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;

                    case "SUTH_IPD_HL7":
                        //For PCMC
                        //hosxp_conhis_machine_opd hosHL7 = new hosxp_conhis_machine_opd();
                        //For SUTH 
                         hosxp_conhis_machine hosSUTH = new hosxp_conhis_machine();
                        int countSUTH;
                        try
                        {
                            DataSet itemsGetHL7 = hosSUTH.GetDataFileID();
                            countSUTH = itemsGetHL7.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countSUTH != 0)
                        {
                            if ((countSUTH != 0) && (countSUTH > 0) && !BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;
                    case "PNNH_IPD_HL7":
                        hosxp_conhis_machine hosPNNH = new hosxp_conhis_machine();
                        int countPNNH;
                        try
                        {
                            DataSet itemsGetHL7 = hosPNNH.GetDataFileID();
                            countPNNH = itemsGetHL7.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countPNNH != 0)
                        {
                            if ((countPNNH != 0) && (countPNNH > 0) && !BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;
                    case "SKPH_IPD_HL7":
                        hosxp_conhis_machine hosSKPH = new hosxp_conhis_machine();
                        int countSKPH;
                        try
                        {
                            DataSet itemsGetHL7 = hosSKPH.GetDataFileID();
                            countSKPH = itemsGetHL7.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countSKPH != 0)
                        {
                            if ((countSKPH != 0) && (countSKPH > 0) && !BgwImport.IsBusy)
                            {
                                OnloadDataThanesMiddle(true);
                                this.BgwImport.RunWorkerAsync();
                                this.progressbar_overall.Visible = true;
                                this.txt_overall.Text = "0%";
                                this.UpdateprocessImport(0);
                                this.btnstart_import.Enabled = false;
                                this.btnpause_import.Enabled = true;
                                this.btnstop_import_process.Enabled = true;
                            }
                        }
                        break;
                }
            }
            else                 // disconnected
            {
                if (BgwImport.WorkerSupportsCancellation)
                {
                    OnloadDataThanesMiddle(false);
                    this.BgwImport.CancelAsync();
                }
            }
        }

        //Function to display the Calculate difference between two dates
        private TimeSpan DifferenceTimeDisplay()
        {
            DateTime endtime = DateTime.Now;
            TimeSpan result = (endtime - starttime);
            return result;
        }

        //Function to display the data graph of the work process in the system.
        private void DisplayDatagraphWorkProcess()
        {
            int[] pointG = new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //-------------------------Switch for SUTH-----------------------------------
            //DataSet ds = th.PrescriptionAmountOfTime();
            DataSet ds =  thSUTH.PrescriptionAmountOfTime();
            //---------------------------------------------------------------------------

            this.ChartWorkLoad.Series[0].Points.Clear();

            if (ds?.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    pointG[Convert.ToInt32(row["timesInsert"])] = Convert.ToInt32(row["itemsPres"]);
                }
                for (int i = 0; i < 24; i++)
                {
                    this.ChartWorkLoad.Series[0].Points.AddXY(i.ToString(), pointG[i]);
                }
            }
            else
            {
                this.ChartWorkLoad.Series[0].Points.Clear();
            }
        }

        //Function to display the data donut chart of the priorty in the system.
        private void DisplayDataChartPriortyProcess()
        {
            //-------------------------Switch for SUTH-----------------------------------
            //DataSet ds = th.PriortyAmountOfRealtime();
            DataSet ds = thSUTH.PriortyAmountOfRealtime();
            //---------------------------------------------------------------------------
            if (ds?.Tables[0].Rows.Count > 0)
            {
                this.ChartPriority.DataSource = ds;
                this.ChartPriority.Series["PriortyName"].XValueMember = "Priority";
                this.ChartPriority.Series["PriortyName"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                this.ChartPriority.Series["PriortyName"].YValueMembers = "Total";
                this.ChartPriority.Series["PriortyName"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            }
            else
            {
                this.ChartPriority.DataSource = null;
            }
        }

        // Background Word for Genrate Text File.
        private void BgwGenerate_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            int itemsAll = Convert.ToInt32(th.ItemsAllDataPrescription());
            int all = itemsAll;
            for (int i = 1; i <= all; i++)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break; // TODO: might not be correct. Was : Exit For
                }
                else
                {
                    Generate_textfile gentxt = new Generate_textfile(Variable.PathHost, Variable.SeparatorPattren);  //Create Objects Class Generate Text File
                    gentxt.ExportTextFile(true);
                    System.Threading.Thread.Sleep(1);
                    int a = (int)(((double)i / (double)all) * 100);
                    worker.ReportProgress(a);
                }
            }
        }

        private void BgwGenerate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BgwGenerate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //MessageBox.Show("Canceled!");
            }
            else if (e.Error != null)
            {
                //MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
               // MessageBox.Show("Completed");
            }
        }

        private async void BgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            try
            {
                switch (Variable.InterfaceMode)
                {
                    case "BDMS":

                         Generate_textfile gentxt = new Generate_textfile(Variable.PathHost, Variable.SeparatorPattren);  //Create Objects Class Generate Text File
                        //Generate_textfile_ATPM gentxt = new Generate_textfile_ATPM(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4

                        string[] pathfile =  gentxt.GetFileNamesHost("*.txt");

                        if (pathfile != null)
                        {
                            int counts = pathfile.Length;
                            for (int i = 1; i <= counts; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    gentxt.ImportTextFile(pathfile[i - 1], true);
                                    System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                    pathoverall = gentxt.PrescriptionFileName;
                                    int a = (int)(((double)i / (double)counts) * 100);
                                    worker.ReportProgress(a);
                                }
                            }
                        }
                        break;

                    case "HUACHIEW":

                        // Generate_textfile gentxt = new Generate_textfile(Variable.PathHost, Variable.SeparatorPattren);  //Create Objects Class Generate Text File
                        Generate_textfile_ATPM gentxtHch = new Generate_textfile_ATPM(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4

                        string[] pathfileHch = gentxtHch.GetFileNamesHost("*.txt");

                        if (pathfileHch != null)
                        {
                            int counts = pathfileHch.Length;
                            for (int i = 1; i <= counts; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    gentxtHch.ImportTextFile(pathfileHch[i - 1], true);
                                    System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                    pathoverall = gentxtHch.PrescriptionFileName;
                                    int a = (int)(((double)i / (double)counts) * 100);
                                    worker.ReportProgress(a);
                                }
                            }
                        }
                        break;

                    case "CHULABHORN":

                        GetHL7ToDBStructure chulabhorn = new GetHL7ToDBStructure(Variable.PathHost);  //Create Objects Class Generate Text File for ConHIS Middle Version 4
                        string[] hl7file = chulabhorn.GetFileNamesHost("*.hl7");
                        if (hl7file.Length != 0)
                        {
                            int counts = hl7file.Length;
                            for (int i = 1; i <= counts; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    chulabhorn.ReadHL7FileAsync(hl7file[i - 1]);
                                    pathoverall = chulabhorn.PrescriptionFileName;
                                    System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                    int a = (int)(((double)i / (double)counts) * 100);
                                    worker.ReportProgress(a);
                                }
                            }

                            DataSet ds = thSUTH.GetDispalyDataClassify();        //tb_thaneshop_middle
                            if (ds.Tables[0].Rows.Count != 0)
                            {
                                ClassifyMedication_Cra classifyMedication = new ClassifyMedication_Cra();
                                classifyMedication.ClassifyOnLoadAsync();
                                classifyMedication.GenSeqOfMaxAsync();
                            }
                        }
                        break;

                    case "HOSXP":

                        Hosxp_opd_pres_machine hos = new Hosxp_opd_pres_machine(Variable.ServerDBType);
                        Hosxp_generate_data_interface genHos = new Hosxp_generate_data_interface();

                        DataSet itemsGetHosXP;
                        _ = new DataSet();
                        itemsGetHosXP = hos.GetDataHn("wait", "1");

                        int count = itemsGetHosXP.Tables[0].Rows.Count;

                        if (count != 0)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    string hn = itemsGetHosXP.Tables[0].Rows[i]["hn"].ToString();

                                    int check = Convert.ToInt32(th.ItemsAllDataFullbyReferrenceCode(hn));

                                    pathoverall = "กำลังโหลดข้อมูลของ Hn : " + hn;

                                    if (check == 0)
                                    {
                                        bool result = genHos.InterfaceHosXP(true, hn);
                                        if (result)
                                        {
                                            System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                            int a = (int)(((double)i / (double)count) * 100);
                                            worker.ReportProgress(a);
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case "VICHAIYUT":

                        Thaneshopmiddle_VICHAIYUT imed = new Thaneshopmiddle_VICHAIYUT();
                        Vichaiyut_generate_data_interface genImed = new Vichaiyut_generate_data_interface();

                        DataSet itemsGetHosIMed;
                        _ = new DataSet();
                        itemsGetHosIMed = imed.GetDataPrescriptionReady(2);

                        int countIMed = itemsGetHosIMed.Tables[0].Rows.Count;

                        if (countIMed != 0)
                        {
                            for (int i = 0; i < countIMed; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    string presc = itemsGetHosIMed.Tables[0].Rows[i]["f_prescriptionno"].ToString();

                                    //int check = Convert.ToInt32(imed.ItemsAllDataFullbyPrescription(presc,2));

                                    pathoverall = "กำลังโหลดข้อมูลของ Presctiontion : " + presc;

                                    //if (check == 0)
                                      //  {
                                        bool result = genImed.InterfaceHosVichaiyut(true, presc);
                                        if (result)
                                        {
                                            System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                            int a = (int)(((double)i / (double)countIMed) * 100);
                                            worker.ReportProgress(a);
                                        }
                                    //}
                                }
                            }
                        }
                        break;
                    case "PCMC_OPD_HL7":
                        //For PCMC
                        hosxp_conhis_machine_opd hosHL7 = new hosxp_conhis_machine_opd();
                        //For SUTH
                        //hosxp_conhis_machine hosHL7 = new hosxp_conhis_machine();
                        hosxp_hl7_message_interface getHL7 = new hosxp_hl7_message_interface();
                        int countHL7 = 0;

                        DataSet itemsGetHL7;
                        _ = new DataSet();

                        try
                        {
                            itemsGetHL7 = hosHL7.GetDataFileID();
                            countHL7 = itemsGetHL7.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countHL7 != 0)
                        {
                            for (int i = 0; i < countHL7; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    // For PCMC
                                    string fileID = itemsGetHL7.Tables[0].Rows[i]["drug_dispense_opd_id"].ToString();
                                    //For SUTH
                                    //string fileID = itemsGetHL7.Tables[0].Rows[i]["drug_dispense_ipd_id"].ToString();
                                    pathoverall = "กำลังโหลดข้อมูลของ Dispense ID : " + fileID;

                                    bool result = getHL7.InterfaceHL7MessageHosXP(true, fileID);
                                    if (result)
                                    {
                                        System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                        int a = (int)(((double)i / (double)countHL7) * 100);
                                        worker.ReportProgress(a);
                                    }
                                }
                            }
                        }
                        break;

                    case "SUTH_IPD_HL7":
                        //For PCMC
                        //hosxp_conhis_machine_opd hosHL7 = new hosxp_conhis_machine_opd();
                        //For SUTH
                        hosxp_conhis_machine hosSUTH = new hosxp_conhis_machine();
                        hosxp_hl7_message_interface getSUTH = new hosxp_hl7_message_interface();
                        int countSUTH = 0;

                        DataSet itemsGetSUTH;
                        _ = new DataSet();

                        try
                        {
                            itemsGetSUTH = hosSUTH.GetDataFileID();
                            countSUTH = itemsGetSUTH.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countSUTH != 0)
                        {
                            for (int i = 0; i < countSUTH; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    // For PCMC
                                    string fileID = itemsGetSUTH.Tables[0].Rows[i]["drug_dispense_ipd_id"].ToString();
                                   
                                    pathoverall = "กำลังโหลดข้อมูลของ Dispense ID : " + fileID;

                                    bool result = getSUTH.InterfaceHL7MessageHosXP(true, fileID);
                                    if (result)
                                    {
                                        System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                        int a = (int)(((double)i / (double)countSUTH) * 100);
                                        worker.ReportProgress(a);
                                    }
                                }
                            }
                        }
                        break;

                    case "PNNH_IPD_HL7":

                        hosxp_conhis_machine hosPNNH = new hosxp_conhis_machine();
                        PNNHGetHL7ToDBStructure PnnH = new PNNHGetHL7ToDBStructure();
                        int countPNNH = 0;

                        DataSet itemsGetPNNH;
                        _ = new DataSet();

                        try
                        {
                            itemsGetPNNH = hosPNNH.GetDataFileID();
                            countPNNH = itemsGetPNNH.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countPNNH != 0)
                        {
                            for (int i = 0; i < countPNNH; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    // For PCMC
                                    string fileID = itemsGetPNNH.Tables[0].Rows[i]["drug_dispense_ipd_id"].ToString();

                                    pathoverall = "กำลังโหลดข้อมูลของ Dispense ID : " + fileID;

                                    bool result = PnnH.InterfaceHL7MessageHosXP(true, fileID);
                                    if (result)
                                    {
                                        System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                        int a = (int)(((double)i / (double)countPNNH) * 100);
                                        worker.ReportProgress(a);
                                    }
                                }
                            }
                        }
                        break;

                    case "SKPH_IPD_HL7":

                        hosxp_conhis_machine hosSKPH = new hosxp_conhis_machine();
                        SKPHGetHL7ToDBStructure SkpH = new SKPHGetHL7ToDBStructure();
                        //PNNHGetHL7ToDBStructure SkpH = new PNNHGetHL7ToDBStructure();
                        int countSKPH = 0;

                        DataSet itemsGetSKPH;
                        _ = new DataSet();

                        try
                        {
                            itemsGetSKPH = hosSKPH.GetDataFileID();
                            countSKPH = itemsGetSKPH.Tables[0].Rows.Count;
                        }
                        catch (Exception)
                        {
                            throw new Exception(" ยังไม่มีข้อมูลที่จะอ่าน ");
                        }

                        if (countSKPH != 0)
                        {
                            for (int i = 0; i < countSKPH; i++)
                            {
                                if (worker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break; // TODO: might not be correct. Was : Exit For
                                }
                                else
                                {
                                    // For SKPH
                                    string fileID = itemsGetSKPH.Tables[0].Rows[i]["drug_dispense_ipd_id"].ToString();

                                    pathoverall = "กำลังโหลดข้อมูลของ Dispense ID : " + fileID;

                                    bool result = SkpH.InterfaceHL7MessageHosXP(true, fileID);
                                    if (result)
                                    {
                                        System.Threading.Thread.Sleep(Variable.ReadFileWait);
                                        int a = (int)(((double)i / (double)countSKPH) * 100);
                                        worker.ReportProgress(a);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logs.Writelogfile(ex.Message, " Bgw Imports");
            }
        }

        private void BgwImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.UpdateprocessImport(e.ProgressPercentage);
        }

        private void BgwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.txt_overall.Text = "ยกเลิกการอ่านข้อมูล";
                 OnloadDataThanesMiddle(true);
            }
            else if (e.Error != null)
            {
                throw new Exception("Error: " + e.Error.Message);
            }
            else
            {
                this.txt_overall.Text = "เสร็จสมบูรณ์";
                 OnloadDataThanesMiddle(true);
             }
            try
            {
                switch (Variable.InterfaceMode)
                {
                    case "VICHAIYUT":
                        Classify_medication_VICHAIYUT vichaiyut = new Classify_medication_VICHAIYUT();
                        vichaiyut.ClassifyOnLoad();
                        break;
                    case "CHULABHORN":
                        ClassifyMedication_Cra classifyMedication = new ClassifyMedication_Cra();
                        classifyMedication.ClassifyOnLoadAsync();
                        break;
                    case "PNNH_IPD_HL7":
                        ClassifyMedicationPNNH classifyMedicationPNNH = new ClassifyMedicationPNNH();
                        classifyMedicationPNNH.ClassifyOnLoadAsync();
                        break;
                    case "SKPH_IPD_HL7":
                        Classify_medication_SKPH classify_medication_SKPH = new Classify_medication_SKPH();
                        classify_medication_SKPH.ClassifyOnLoad();
                        break;
                    default:
                        Classify_medication_ATPM classify = new Classify_medication_ATPM();
                        classify.ClassifyOnLoad();
                        break;
                }
            }
            catch (Exception ex) { logs.Writelogfile(ex.Message, " ConHIS_Logs"); }

             DisplayDatagraphWorkProcess();
             DisplayDataChartPriortyProcess();
        }

        private void UpdateprocessImport(int percent)
        {
            this.progressbar_overall.Value = percent;
            this.txt_overall.Text = String.Format(" {0}% ", percent);
            this.lbPathOverall.Text = pathoverall;
            if (percent == 100)
            {
                this.progressbar_overall.Value = 0;
                this.lbPathOverall.Text = "-";
            }
        }

        private void Btnstart_import_Click(object sender, EventArgs e)
        {
            if (!BgwImport.IsBusy)
            {
                this.enableread = true;
                OnloadDataThanesMiddle(true);
                this.BgwImport.RunWorkerAsync();
                this.progressbar_overall.Visible = true;
                this.txt_overall.Text = "0%";
                this.UpdateprocessImport(0);
                this.btnstart_import.Enabled = false;
                this.btnpause_import.Enabled = true;
                this.btnstop_import_process.Enabled = true;
            }
            event_code = "P0003";
            event_message = "กดปุ่มเริ่มดึงข้อมูล...จากไฟล์ข้อมูล";
            this.WritelogSystem(true);
        }

        private void Btnpause_import_Click(object sender, EventArgs e)
        {
            if (BgwImport.WorkerSupportsCancellation)
            {
                this.enableread = false;
                OnloadDataThanesMiddle(false);
                this.BgwImport.CancelAsync();
                this.btnstart_import.Enabled = true;
                this.btnpause_import.Enabled = false;
                this.btnstop_import_process.Enabled = true;
            }
            event_code = "P0004";
            event_message = "กดปุ่มพักการดึงข้อมูลชั่วคราว....";
            this.WritelogSystem(true);
        }

        private void Btnstop_import_process_Click(object sender, EventArgs e)
        {
            this.enableread = false;
            this.btnstart_import.Enabled = true;
            this.btnpause_import.Enabled = true;
            this.btnstop_import_process.Enabled = false;
            event_code = "P0005";
            event_message = "กดปุ่มหยุดดึงข้อมูล";
            this.WritelogSystem(true);
        }

        //function get data thanes middle automatic Onstart Programs
        private void OnloadAutomaticStart()
        {
            if (Settings.Default.onStartLoadtext)
            {
                if (!BgwImport.IsBusy)
                {
                    this.enableread = true;
                    OnloadDataThanesMiddle(true);
                    this.BgwImport.RunWorkerAsync();
                    this.progressbar_overall.Visible = true;
                    this.txt_overall.Text = "0%";
                    this.UpdateprocessImport(0);
                    this.btnstart_import.Enabled = false;
                    this.btnpause_import.Enabled = true;
                    this.btnstop_import_process.Enabled = true;
                }
                event_code = "P0003";
                event_message = "กดปุ่มเริ่มดึงข้อมู...จากไฟล์ข้อมูล";
                this.WritelogSystem(true);
            }
        }

        //function get data thanes middle display
        private void OnloadDataThanesMiddle(bool status)
        {
            try
            {
                DataSet ds = null;
                //-------------------------Switch for SUTH-----------------------------------
                //int dsPres = Convert.ToInt32(th.ItemsAllDataPrescription());
                //int dsPatient = Convert.ToInt32(th.ItemsAllDataPatient());
                //int dsItemsAll = Convert.ToInt32(th.ItemsAllDataFull());

                int dsPres =  Convert.ToInt32(thSUTH.ItemsAllDataPrescription());
                int dsPatient =  Convert.ToInt32(thSUTH.ItemsAllDataPatient());
                int dsItemsAll =  Convert.ToInt32(thSUTH.ItemsAllDataFull());
                //---------------------------------------------------------------------------

                if (status
                    && ((strSearch?.Length == 0) || (strSearch == null)))
                {
                    //-------------------------Switch for SUTH-----------------------------------
                    //int itemspres = Convert.ToInt32(th.GetItemsDataThanesMiddle(null,"all"));
                    int itemspres =  Convert.ToInt32(thSUTH.GetItemsDataThanesMiddle("prescription", "", null, "all"));
                    //----------------------------------------------------------------------------

                    if ((itemspres != 0) && (itemsCompare != itemspres))
                    {
                        itemsCompare = itemspres;
                        //-------------------------Switch for SUTH-----------------------------------
                        //ds = th.GetDispalyDataGridView(null);
                        ds =  thSUTH.GetDispalyDataGridView(null);
                        //---------------------------------------------------------------------------
                        this.DisplayDataGrid(ds);
                    }
                    itemsSearchCompare = 0;
                }
                else if (!status && (strSearch != "") && (strSearch != null))
                {
                    //-------------------------Switch for SUTH-----------------------------------
                     //int itemspres = Convert.ToInt32(th.GetItemsDataThanesMiddle(strSearch,"all"));
                    int itemspres =  Convert.ToInt32(thSUTH.GetItemsDataThanesMiddle("prescription", "", strSearch, "all"));
                    //---------------------------------------------------------------------------

                    if ((itemspres != 0) && (itemsSearchCompare != itemspres))
                    {
                        itemsSearchCompare = itemspres;
                        //-------------------------Switch for SUTH-----------------------------------
                        //ds = th.GetDispalyDataGridView(strSearch);
                        ds =  thSUTH.GetDispalyDataGridView(strSearch);
                        //---------------------------------------------------------------------------
                        this.DisplayDataGrid(ds);
                    }
                    itemsCompare = 0;
                }

                //items Prescription
                if (itemsPrescriptionNo != dsPres)
                {
                    itemsPrescriptionNo = dsPres;
                    this.btnitemsPres.Text = itemsPrescriptionNo.ToString() + " ใบยา";
                }
                if (itemsPatient != dsPatient)
                {
                    itemsPatient = dsPatient;
                    this.btnitemsPatient.Text = itemsPatient.ToString() + " คน";
                }
                if (itemsAllData != dsItemsAll)
                {
                    itemsAllData = dsItemsAll;
                    this.btnitemsList.Text = itemsAllData.ToString() + " รายการ";

                    //-------------------------Switch for SUTH-----------------------------------
                    //Variable.referrenceCode = th.GetMaxReferrenceCode().ToString();

                    //---------------------------------------------------------------------------
                }
                //Load Reset Graph
            }
            catch (Exception ex) { throw new Exception("OnloadDataThanesMiddle : " + ex.Message); }
        }

        private bool DisplayDataGrid(DataSet ds)
        {
            if (ds != null)
            {
                int icount = 0;
                int c = ds.Tables[0].Rows.Count;
                if (enableload)
                {
                    icount = 0;
                    this.lbItemsSearch.Visible = false;
                    this.dgvFileListProgress.Rows.Clear();
                }
                else if (!enableload)
                {
                    this.lbItemsSearch.Visible = true;
                    this.lbItemsSearch.Text = "( พบข้อมูล " + c.ToString() + " รายการ )";
                    this.dgvFileListProgress.Rows.Clear();
                }
                for (int i = icount; i < c; i++)
                {
                    const string s = "s";
                    string presno = ds.Tables[0].Rows[i]["f_prescriptionno"].ToString().Trim();
                    string seq = ds.Tables[0].Rows[i]["f_seq"].ToString().Trim();
                    string seqmax = ds.Tables[0].Rows[i]["f_seqmax"].ToString().Trim();
                    string hn = ds.Tables[0].Rows[i]["f_hn"].ToString().Trim();
                    string en = ds.Tables[0].Rows[i]["f_an"].ToString().Trim();
                    //string en = ds.Tables[0].Rows[i]["f_en"].ToString().Trim();
                    string patientname = ds.Tables[0].Rows[i]["f_patientname"].ToString().Trim();
                    string lastmodify = ds.Tables[0].Rows[i]["f_lastmodified"].ToString().Trim();
                    this.dgvFileListProgress.Rows.Add(s, presno, seq, seqmax, hn, en, patientname, lastmodify);
                    this.dgvFileListProgress.FirstDisplayedScrollingRowIndex = this.dgvFileListProgress.Rows.Count - 1;
                }
                this.dgvFileListProgress.CurrentCell = null;
                this.dgvFileListProgress.ClearSelection();
                ds.Clear();
            }
            return true;
        }

        private void BtnSearchData_Click(object sender, EventArgs e)
        {
            this.SearchDataPrescription();
        }

        private void TbSearchData_Click(object sender, EventArgs e)
        {
            this.tbSearchData.Text = "";
            this.tbSearchData.Focus();
            this.SearchDataPrescription();
        }

        private void TbSearchData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchDataPrescription();
            }
        }

        private void SearchDataPrescription()
        {
            if (this.tbSearchData.Text != "")
            {
                this.enableload = false;
                this.strSearch = this.tbSearchData.Text.Trim();
                OnloadDataThanesMiddle(enableload);
            }
            else
            {
                this.enableload = true;
                this.strSearch = null;
                OnloadDataThanesMiddle(enableload);
            }
        }

        private void TbSearchData_TextChanged(object sender, EventArgs e)
        {
            if ((tbSearchData.Text?.Length == 0) || (tbSearchData.Text == null))
            {
                itemsCompare = 0;
                this.dgvFileListProgress.Rows.Clear();
                this.SearchDataPrescription();
            }
            else
            {
                // itemsCompare = 0;
                this.dgvFileListProgress.Rows.Clear();
                this.SearchDataPrescription();
            }
        }

        private void BgwInterface_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void BgwInterface_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void BgwInterface_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        //Go to system setup page.
        private void BtnSettingProgram_Click(object sender, EventArgs e)
        {
            PrescriptionPage pres = new PrescriptionPage
            {
                WindowState = FormWindowState.Maximized
            };
            pres.Show();
        }

        //Go to Full Detail Page.
        private void BtnMachineInfo_Click(object sender, EventArgs e)
        {
            FullDetailPage full = new FullDetailPage
            {
                WindowState = FormWindowState.Maximized
            };
            full.Show();
        }

        //Show System logs Event To DataGridView
        private void OnloadSystemLogsEventShow()
        {
            if (Variable.SysQueue.Count != 0)
            {
                this.dgvSystemLogs.ClearSelection();
                while (Variable.SysQueue.Count != 0)
                {
                    string text = Variable.SysQueue.Dequeue().ToString();
                    string[] childParts = { };
                    childParts = text.Split(',');
                    string timestamp = childParts[0].Trim();
                    string event_cd = childParts[1].Trim();
                    string event_msg = childParts[2].Trim();

                    this.dgvSystemLogs.Rows.Add(new string[] { timestamp, event_cd, event_msg });
                }
                this.dgvSystemLogs.ClearSelection();
                this.dgvSystemLogs.FirstDisplayedScrollingRowIndex = this.dgvSystemLogs.Rows.Count - 1;
            }
        }

        public bool WritelogSystem(bool enable)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:sss:fff");
            if (enable)
                Variable.SysQueue.Enqueue(String.Format("{0},{1},{2}", timestamp, event_code, event_message));
            return true;
        }

        //Timer Event Show Status Events
        private void Tmstatus_Tick(object sender, EventArgs e)
        {
            this.OnloadSystemLogsEventShow();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.tbSearchData.Text = "";
             OnloadDataThanesMiddle(true);
        }

        private void BtnSettingsInfo_Click(object sender, EventArgs e)
        {
            SettingsPage st = new SettingsPage();
            st.ShowDialog();
        }

        private void BtnReportInfo_Click(object sender, EventArgs e)
        {
            MonitorPage full = new MonitorPage
            {
                WindowState = FormWindowState.Maximized
            };
            full.Show();
        }

        private void btnDrugInfo_Click(object sender, EventArgs e)
        {
            DrugInfoPage dr = new DrugInfoPage
            {
                WindowState = FormWindowState.Maximized
            };
            dr.Show();
        }

        //////////////////////////////////////////Start Connection API /////////////////////////////////////////////
        private void AuthLogin()
        {
            try
            {
                JsonLogin jsonLogin = new JsonLogin();
                Login login = new Login
                {
                    Email = "SJ@Sulution.com",
                    Password  = "123456"
                };

                string strResponse = jsonLogin.AuthToken(login);
                var Token = (JsonConvert.DeserializeObject<Login>(strResponse)).Token;
                Settings.Default.AccessToken = Token;
                Settings.Default.Save();

                if (strResponse.Contains("errorMessage"))
                {
                    var error = (JsonConvert.DeserializeObject<dynamic>(strResponse)).errorMessage;
                    logs.Writelogfile(error, " API");
                }
                else
                {
                    logs.Writelogfile(strResponse, " API");
                }
            }
            catch (Exception e)
            {
                var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
                Console.WriteLine(ErrorMessage);
            }
        }
    }

}