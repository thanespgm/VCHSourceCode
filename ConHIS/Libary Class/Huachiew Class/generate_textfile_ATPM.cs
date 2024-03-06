using ConHIS.RestFull_TMS;
using ConHIS.Libary_Class;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConHIS
{
    internal class Generate_textfile_ATPM
    {
        //Variable And Objects
        private static StreamReader sr;

        private ArrayList mSegments;

        private readonly System_logfile log = new System_logfile();
        private readonly Thaneshopmiddle_ATPM md = new Thaneshopmiddle_ATPM();
        private readonly Thaneshopmiddle_extentions_ATPM ext = new Thaneshopmiddle_extentions_ATPM();

        private string datafilename;
        private string hn_Compare = string.Empty;
        private string pres_Compare = string.Empty;
        private string ward_Compare = string.Empty;
        private string bed_Compare = string.Empty;
        private string drug_Compare = string.Empty;
        private string drugunits_Compare = string.Empty;
        private string instruction_Compare = string.Empty;
        private string priority_Compare = string.Empty;
        private string frequency_Compare = string.Empty;

        protected string _prescriptionfile;

        public string PrescriptionFileName
        {
            get { return _prescriptionfile; }
            set { _prescriptionfile = value; }
        }

        protected string _pathname;

        public string PathName
        {
            get { return _pathname; }
            set { _pathname = value; }
        }

        public string DataText { get; set; }

        private string event_code;
        private string event_message;
        private string error_message;

        //Constructor And Abstract Class
        public Generate_textfile_ATPM()
        {
        }

        public Generate_textfile_ATPM(string path)
        {
            this._pathname = path;
        }

        //Functions for reading data files
        //By Read a filename based on the prescription number of the patient.
        public bool ImportTextFile(string filename, bool enable)
        {
            const bool result = false;
            try
            {
                if (enable
                    && ((filename != null) || (filename != "")))
                {
                    Variable.TextFileName = filename;
                    string targetfolder = Search_targetfolder();
                    string waitfolder = Variable.PathHost;
                    _prescriptionfile = waitfolder + @"\" + filename;

                    //Check whether the data file is duplicate or not.
                    string[] pathfile = GetFileNamesDesctination(filename);

                    if ((pathfile != null) && (pathfile.GetLength(0) != 0))
                    {
                        datafilename = filename;
                        string dupicatefolder = targetfolder + @"\Dupicate";
                        string prescriptiondupicate = dupicatefolder + @"\" + filename;
                        CreateFolderTypeAndMoveFile(dupicatefolder);
                        if (File.Exists(_prescriptionfile))
                        {
                            System.IO.File.Move(_prescriptionfile, prescriptiondupicate);
                            log.Writelogfile("[" + filename + "] :  ไฟล์ข้อมูลซ้ำกันในระบบ", " ConHIS_Logs");
                        }
                        //Message Show Logs System
                        event_code = "E0006";
                        event_message = "[" + filename + "] : ไฟล์ข้อมูลซ้ำกันในระบบ";
                        this.WritelogSystem(true);
                    }
                    else
                    {
                        datafilename = filename;
                        if (ReadFileToInsertArrayAsync(_prescriptionfile))
                        {
                            string completefolder = targetfolder + @"\Complete";
                            string prescriptioncomplete = completefolder + @"\" + filename;
                            CreateFolderTypeAndMoveFile(completefolder);
                            if (File.Exists(_prescriptionfile))
                            {
                                System.IO.File.Move(_prescriptionfile, prescriptioncomplete);
                                log.Writelogfile("[" + datafilename + "] :  ไฟล์ข้อมูลบันทึกข้อมูลเรียบร้อย", " ConHIS_Logs");
                            }
                            //Message Show Logs System
                            datafilename = "";
                            event_code = "C0001";
                            event_message = "[" + filename + "] : บันทึกข้อมูลเรียบร้อยแล้ว";
                            this.WritelogSystem(true);
                        }
                        else
                        {
                            datafilename = filename;
                            string errorfolder = targetfolder + @"\Error";
                            string prescriptionerror = errorfolder + @"\" + filename;
                            CreateFolderTypeAndMoveFile(errorfolder);
                            if (File.Exists(_prescriptionfile))
                            {
                                System.IO.File.Move(_prescriptionfile, prescriptionerror);
                                log.Writelogfile("[" + filename + "] :  ไฟล์ข้อมูลที่เกิดข้อผิดพลาด", " ConHIS_Logs");
                            }
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException DirNotFound)
            {
                if (Variable.pathfileErrorAccess != filename)
                {
                    Variable.pathfileErrorAccess = filename;
                    error_message = "ไม่พบที่อยู่ของ Directory ไฟล์ข้อมูลนี้";
                    event_code = "E0002";
                    event_message = error_message;
                    this.WritelogSystem(true);
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + DirNotFound.ToString(), " ConHIS_Logs");
                }
            }
            catch (UnauthorizedAccessException UnAuthDir)
            {
                if (Variable.pathfileErrorAccess != filename)
                {
                    Variable.pathfileErrorAccess = filename;
                    error_message = "ไฟล์ข้อมูลนี้ ไม่ได้รับอนุญาติ ไม่สามารถเข้าถึงได้";
                    event_code = "E0003";
                    event_message = error_message;
                    this.WritelogSystem(true);
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + UnAuthDir.ToString(), " ConHIS_Logs");
                }
            }
            catch (PathTooLongException LongPath)
            {
                if (Variable.pathfileErrorAccess != filename)
                {
                    Variable.pathfileErrorAccess = filename;
                    error_message = "เส้นทางที่อยู่ไฟล์ข้อมูลยาวเกินไป";
                    event_code = "E0004";
                    event_message = error_message;
                    this.WritelogSystem(true);
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + LongPath.ToString(), " ConHIS_Logs");
                }
            }
            catch (IOException ex)
            {
                if (Variable.pathfileErrorAccess != filename)
                {
                    Variable.pathfileErrorAccess = filename;
                    error_message = "เกิดข้อผิดพลาดการเข้าถึงแหล่งข้อมูล";
                    event_code = "E0005";
                    event_message = error_message;
                    this.WritelogSystem(true);
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + ex.ToString() + "\r\n" + ex.GetType(), " ConHIS_Logs");
                }
            }
            return result;
        }

        //Function for create Folder Type
        private static void CreateFolderTypeAndMoveFile(string FolderName)
        {
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
            }
        }

        //Function for get file list
        public string[] GetFileNames(string filter)
        {
            string[] files = null;
            if ((_pathname != null) || (_pathname != ""))
            {
                string targetfolder = Search_targetfolder();
                string waitfolder = targetfolder + @"\Wait";
                if (Directory.Exists(waitfolder))
                {
                    files = Directory.GetFiles(waitfolder, filter);
                    for (int i = 0; i < files.Length; i++)
                    {
                        files[i] = Path.GetFileName(files[i]);
                    }
                }
            }
            return files;
        }

        //Function for get file list from Host
        public string[] GetFileNamesHost(string filter)
        {
            string[] files = null;
            if ((_pathname != null) || (_pathname != ""))
            {
                string targetfolder = Search_targetfolder();
                string waitfolder = Variable.PathHost;

                if (Directory.Exists(waitfolder))
                {
                    files = Directory.GetFiles(waitfolder, filter);

                    for (int i = 0; i < files.Length; i++)
                    {
                        string strfile = files[i];

                        DateTime dt = File.GetLastWriteTime(strfile);   //Get Last Write Time.
                        dt = dt.AddMilliseconds(3000);

                        if (DateTime.Now > dt)
                        {
                            files[i] = Path.GetFileName(strfile);
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
            }
            return files;
        }

        //Function for get file list from Destination
        public string[] GetFileNamesDesctination(string filter)
        {
            string[] files = null;
            if ((_pathname != null) || (_pathname != ""))
            {
                string targetfolder = Search_targetfolder() + @"\Complete\";
                string completefolder = targetfolder + filter;
                if (Directory.Exists(targetfolder))
                {
                    files = Directory.GetFiles(targetfolder, filter);
                    for (int i = 0; i < files.Length; i++)
                    {
                        files[i] = Path.GetFileName(files[i]);
                    }
                }
            }
            return files;
        }

        //Function Search Target Folder
        private string Search_targetfolder()
        {
            DateTime date = DateTime.UtcNow.Date;
            string targetfolder = Variable.PathLocal + @"\" + date.ToString("dd-MM-yyyy");
            return targetfolder;
        }

        //Read the data file and save the database.
        //Retrun Type Boolen.

        #region "Read TextFile To Array List."

        private string ReadFile(string fileName)
        {
            string result = "";
            string Path = fileName;
            try
            {
                if (File.Exists(Path))
                {
                    using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        sr = new StreamReader(fs, UnicodeEncoding.UTF8);
                        result = sr.ReadToEnd();
                        log.Writelogfile("[" + datafilename + "] :  อ่านไฟล์ข้อมูลสำเร็จ", " ConHIS_Logs");

                        fs.Close();
                        fs.Dispose();
                    }
                }
                else
                    result = "";
            }
            catch
            {
                log.Writelogfile("[" + datafilename + "] :  อ่านไฟล์ข้อมูลไม่สำเร็จ", " ConHIS_Logs");
            }
            return result;
        }

        public int LoadMessage(string rawMessage)
        {
            mSegments = new ArrayList();
            if (string.IsNullOrEmpty(rawMessage))
                return 0;
            rawMessage = rawMessage.Replace("\r\n", "\r").Replace("\n", "\r");      // TODO move this into the Split call?
            string[] rows = rawMessage.Split(new string[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows)
            {
                string seg = row.Trim();
                // Assumption: a valid HL7 segment has a segment type code followed by at least one field-delimiter, e.g. "NTE|"
                if ((seg.Length > 3) && (seg.IndexOf('|') > 2))
                    mSegments.Add(seg);
            }
            return mSegments.Count;
        }

        private bool ReadFileToInsertArrayAsync(string pathFile)
        {
            bool result = false;
            try
            {
                DataText = ReadFile(pathFile);
                int rows = LoadMessage(DataText);

                if (rows != 0)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        string parentData = mSegments[i].ToString();
                        // ------------------- Data Row----------------------------------------------
                        string[] childParts = { };
                        childParts = parentData.Split('|');

                        // --------------------Start Extract Array Data------------------------------
                        md.PrescriptionNo = childParts[0].Trim();                      //Field 01
                        try
                        {
                            md.Seq = Convert.ToDecimal(childParts[1]);                 //Field 02
                        }
                        catch (Exception e) { throw new Exception("Seq => Values :" + childParts[1] + " Error :" + e.Message); }

                        try
                        {
                            md.SeqMax = Convert.ToDecimal(childParts[2]);              //Field 03
                        }
                        catch (Exception e) { throw new Exception("Seq Max => Values :" + childParts[2] + " Error :" + e.Message); }
                        md.RunningNo = childParts[3].Trim();                           //Field 04

                        DateTime PresDate = DateTime.ParseExact(childParts[4], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                        md.PrescriptionDate = PresDate.ToString("yyyyMMdd");                    //Field 05
                        try
                        {
                            //md.OrderCreateDate = DateTime.Now;
                            md.OrderCreateDate = DateTime.ParseExact(childParts[5], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);   //Field 06
                        }
                        catch (Exception e) { throw new Exception("OrderCreateDate => Values :" + childParts[5] + " Error :" + e.Message); }
                        md.OrderTargetDate = childParts[6].Trim();                     //Field 07
                        md.OrderTargetTime = childParts[7].Trim();                     //Field 08
                        md.PharmacyLocationCode = childParts[8].Trim();                //Field 09
                        md.PharmacyLocationDesc = childParts[9].Trim();                //Field 10
                        md.UserOrderBy = childParts[10].Trim();                        //Field 11
                        md.UserAcceptBy = childParts[11].Trim();                       //Field 12
                        try
                        {
                            //md.OrderAcceptDate = DateTime.Now;
                            md.OrderAcceptDate = DateTime.ParseExact(childParts[12], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);  //Field 13
                        }
                        catch (Exception e) { throw new Exception("OrderAcceptDate => Values :" + childParts[12] + " Error :" + e.Message); }
                        md.OrderAcceptFromIP = childParts[13].Trim();                  //Field 14
                        try
                        {
                            md.DispenseStatus = Convert.ToDecimal(childParts[14]);     //Field 15
                        }
                        catch (Exception e) { throw new Exception("DispenseStatus => Values :" + childParts[14] + " Error :" + e.Message); }
                        try
                        {
                            md.Status = Convert.ToDecimal(childParts[15]);             //Field 16
                        }
                        catch (Exception e) { throw new Exception("Status => Values :" + childParts[15] + " Error :" + e.Message); }
                        try
                        {
                            md.PrintStatus = Convert.ToDecimal(childParts[16]);        //Field 17
                        }
                        catch (Exception e) { throw new Exception("PrintStatus => Values :" + childParts[16] + " Error :" + e.Message); }
                        md.Hn = childParts[17].Trim();                                 //Field 18
                        md.An = childParts[18].Trim();                                 //Field 19
                        md.Vn = childParts[19].Trim();                                 //Field 20
                        md.PatientName = childParts[20].Trim();                        //Field 21
                       // md.PatientName = "Thanes Demo "+ md.Hn;
                        md.Sex = childParts[21].Trim();                                //Field 22
                        try
                        {
                            //md.PatientDOB = DateTime.Now;
                            md.PatientDOB = DateTime.ParseExact(childParts[22], "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);       //Field 23
                        }
                        catch (Exception e) { throw new Exception("PatientDOB => Values :" + childParts[22] + " Error :" + e.Message); }
                        md.WardCode = childParts[23].Trim();                           //Field 24
                        md.WardDesc = childParts[24].Trim();                           //Field 25
                        md.RoomCode = childParts[25].Trim();                           //Field 26
                        md.RoomDesc = childParts[26].Trim();                           //Field 27
                        md.BedCode = childParts[27].Trim();                            //Field 28
                        md.DrugAllergy = childParts[28].Trim();                        //Field 29
                      //md.DoctorCode = childParts[29].Trim();                         //Field 30
                       //md.DoctorName = childParts[30].Trim();                         //Field 31
                        md.DoctorCode = "01122";
                        md.DoctorName = "Mr. ConHIS Demo";
                        try
                        {
                            md.ToMachineNo = Convert.ToDecimal(childParts[31]);        //Field 32
                        }
                        catch (Exception e) { throw new Exception("ToMachineNo => Values :" + childParts[31] + " Error :" + e.Message); }
                        md.OrderItemCode = childParts[32].Trim();                      //Field 33
                        md.OrderItemName = childParts[33].Trim();                      //Field 34
                        try
                        {
                            md.OrderQty = Convert.ToDecimal(childParts[34]);           //Field 35
                        }
                        catch (Exception e) { throw new Exception("OrderQty => Values :" + childParts[34] + " Error :" + e.Message); }
                        md.OrderUnitCode = childParts[35].Trim();                      //Field 36
                        md.OrderUnitDesc = childParts[36].Trim();                      //Field 37
                        try
                        {
                            md.Dosage = Convert.ToDecimal(childParts[37]);             //Field 38
                        }
                        catch (Exception e) { throw new Exception("Dosage => Values :" + childParts[37] + " Error :" + e.Message); }
                        md.DosageUnit = childParts[38].Trim();                         //Field 39
                        md.BinLocation = childParts[39].Trim();                        //Field 40
                        md.ItemIdentify = childParts[40].Trim();                       //Field 41
                        md.ItemLotNo = childParts[41].Trim();                          //Field 42
                        try
                        {
                            if (childParts[42] != "")
                                md.ItemLotExpire = DateTime.ParseExact(childParts[42], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);     //Field 43
                            else
                                md.ItemLotExpire = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                        }
                        catch (Exception e) { throw new Exception("ItemLotExpire => Values :" + childParts[42] + " Error :" + e.Message); }
                        md.InstructionCode = childParts[43].Trim();                    //Field 44
                        md.InstructionDesc = childParts[44].Trim();                    //Field 45
                        md.DrugFormCode = childParts[45].Trim();                       //Field 46
                        md.DrugFormDesc = childParts[46].Trim();                       //Field 47
                        try
                        {
                            //md.HeighAlretDrug = 0;
                            md.HeighAlretDrug = Convert.ToDecimal(childParts[47]);     //Field 48
                        }
                        catch (Exception e) { throw new Exception("HeighAlretDrug => Values :" + childParts[47] + " Error :" + e.Message); }
                        try
                        {
                            //md.PRNSTAT = 0;
                            md.PRNSTAT = Convert.ToDecimal(childParts[48]);            //Field 49
                        }
                        catch (Exception e) { throw new Exception("PRNSTAT => Values :" + childParts[48] + " Error :" + e.Message); }
                        if (childParts[49].Length == 1)
                            md.PriorityCode = childParts[49].Trim();                   //Field 50
                        else
                            md.PriorityCode = childParts[49].Substring(0, 2);          //Field 50
                        md.PriorityDesc = childParts[50].Trim();                       //Field 51
                        md.FrequencyCode = childParts[51].Trim();                      //Field 52
                        md.FrequencyDesc = childParts[52].Trim();                      //Field 53
                        md.FrequencyTime = childParts[53].Trim();                      //Field 54
                        md.DosageDispense = childParts[54].Trim();                     //Field 55
                        try
                        {
                            //md.Language = 0;
                            md.Language = Convert.ToDecimal(childParts[55]);           //Field 56
                        }
                        catch (Exception e) { throw new Exception("Language => Values :" + childParts[55] + " Error :" + e.Message); }
                        try
                        {
                            //md.DurationCode = 0;
                            md.DurationCode = Convert.ToDecimal(childParts[56]);       //Field 57
                        }
                        catch (Exception e) { throw new Exception("DurationCode => Values :" + childParts[56] + " Error :" + e.Message); }
                        md.NoteProcessing = childParts[57].Trim();                     //Field 58
                        md.BarcodeByHIS = childParts[58].Trim();                       //Field 59
                        md.ExcludeIPFill = childParts[59].Trim();                      //Field 60
                        try
                        {
                            ////if (childParts[59] != "")
                            ////    md.LastModified = DateTime.ParseExact(childParts[59], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);     //Field 61
                            ////else
                                md.LastModified = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                        }
                        catch (Exception e) { throw new Exception("LastModified => Values :" + childParts[60] + " Error :" + e.Message); }
                        md.Comment = childParts[61].Trim();                            //Field 62
                        try
                        {
                            //md.DrugBagSplit = 0;
                            md.DrugBagSplit = Convert.ToDecimal(childParts[62]);       //Field 63
                        }
                        catch (Exception e) { throw new Exception("DrugBagSplit => Values :" + childParts[62] + " Error :" + e.Message); }
                        try
                        {
                            if (childParts[63] != "")
                                md.OPDAdminStatus = Convert.ToDecimal(childParts[63]);         //Field 64
                            else
                                md.OPDAdminStatus = 0;
                        }
                        catch (Exception e) { throw new Exception("OPDAdminStatus => Values :" + childParts[63] + " Error :" + e.Message); }
                        try
                        {
                            if (childParts[64] != "")
                                md.OPDAdminDateTime = DateTime.ParseExact(childParts[64], "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);     //Field 65
                            else
                                md.OPDAdminDateTime = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), "dd/MM/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None);
                        }
                        catch (Exception e) { throw new Exception("OPDAdminDateTime => Values :" + childParts[64] + " Error :" + e.Message); }
                        md.OPDAdminBy = childParts[65].Trim();                         //Field 66
                        md.OPDAdminRemark = childParts[66].Trim();                     //Field 67
                        md.OPDAdminLocation = childParts[67].Trim();                   //Field 68
                        try
                        {
                            if (childParts[68] != "")
                                md.OPDAdminContinue = Convert.ToDecimal(childParts[68]);       //Field 69
                            else
                                md.OPDAdminContinue = 0;
                        }
                        catch (Exception e) { throw new Exception("OPDAdminContinue => Values :" + childParts[68] + " Error :" + e.Message); }

                        /// >>>>
                        /// Table Extentions Data ThaneshopMiddle.-------------------------------------------------------------
                        /// >>>
                        if (childParts.Length == 76)
                        {
                            ext.RunningNo = md.RunningNo;
                            ext.PRN_Indication = childParts[69].Trim();                   //Field 70
                            ext.DrugLabelName = childParts[70].Trim();                    //Field 71
                            ext.PregCat = childParts[71].Trim();                          //Field 72
                            
                            //Add On New 2022
                            ext.EndDate = childParts[72].Trim();                          //Field 73
                            ext.EndTime = childParts[73].Trim();                          //Field 74
                            ext.Startdate = childParts[74].Trim();                          //Field 75
                            ext.Starttime = childParts[75].Trim();                          //Field 76
                            var val = new DataValidation(ext, datafilename).Validate();
                            if (val)
                            {
                                bool Ans =  ext.InsertDataExtentionsDetail();
                                if (!Ans)
                                    throw new Exception("ไม่สามารถบันทึกข้อมูลของ Extentions : " + datafilename + " ได้");
                            }
                        }

                        var valid = new DataValidation(md, datafilename).Validate();
                        if (valid)
                        {
                            if ( Convert.ToInt32(md.SearchAllDataFullbyPrescription(md.PrescriptionNo, md.Seq,md.RunningNo)) == 0)
                            {
                                //  bool API_Answer = InsertRestFullAPI(md);

                                //GenerateHL7(md,ext, rows);

                                bool Answer =  md.InsertDataThanesMiddle();
                              //  if (Answer == true && API_Answer == true)
                                if (Answer == true)
                                {
                                    //InsertMasterDrugInfo(md);
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                    throw new Exception("ไม่สามารถบันทึกข้อมูลของ : " + datafilename + " ได้");
                                }
                            }
                            else
                            {
                                result = false;
                                throw new Exception("ไม่สามารถบันทึกข้อมูลของ : " + datafilename + " ได้ ข้อมูล Dupicate ซ้ำ");
                            }
                        }
                        else
                        {
                            result = false;
                            const string V = "เกิดข้อผิดพลาดการตรวจสอบข้อมูล : ";
                            throw new Exception(V + datafilename);
                        }
                    }
                }
                else
                {
                    result = false;
                    throw new Exception("ไม่มีข้อมูลในไฟล์ข้อมูล : " + datafilename + " ได้");
                }
            }
            catch (Exception ex)
            {
                result = false;
                event_code = "E0001";
                event_message = "[" + datafilename + "] : ข้อผิดพลาด บันทึกข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";
                this.WritelogSystem(true);

                log.Writelogfile("[" + datafilename + "] : บันทึกข้อมูลไม่สำเร็จ " + ex.ToString(), " ConHIS_Logs");
            }
            return result;
        }

        #endregion "Read TextFile To Array List."

        public bool WritelogSystem(bool enable)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:sss.fff");
            if (enable)
                Variable.SysQueue.Enqueue(String.Format("[{0}],{1},{2}", timestamp, event_code, event_message));
            return true;
        }

        public bool InsertMasterDrugInfo(Thaneshopmiddle_ATPM md)
        {
            bool result = false;
            try
            {
                if(md != null)
                {
                    master_druginfomation dr = new master_druginfomation
                    {
                        OrderItemCode = md.OrderItemCode,
                        OrderItemName = md.OrderItemName,
                        OrderItemNameGeneric = md.OrderItemName,
                        OrderItemNamePrint = md.OrderItemName,
                        OrderUnitCode = md.OrderUnitCode,
                        OrderUnitDesc = md.OrderUnitDesc,
                        OrderItemBarcode = "",
                        ToMachineNo = md.ToMachineNo,
                        BinLocation = md.BinLocation,
                        InstructionActiveFrom = 1,
                        InstructionCode = md.InstructionCode,
                        InstructionDesc = md.InstructionDesc,
                        FrequencyActiveFrom = 1,
                        FrequencyCode = md.FrequencyCode,
                        FrequencyDesc = md.FrequencyDesc,
                        FrequencyTime = md.FrequencyTime,
                        DrugLabel = ext.DrugLabelName,
                        OrderItemImage = null
                    };
                    var valid = new DataValidation(dr, datafilename).Validate();
                    if (valid)
                    {
                        if(dr.GetDrugCodeCheck(dr.OrderItemCode) == 0)
                        {
                            bool Answer = dr.InsertDataDrugInformation();
                            if (Answer == true)
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                                throw new Exception("ไม่สามารถบันทึกข้อมูลของ Master Drug Information : " + datafilename + " ได้");
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        const string V = "เกิดข้อผิดพลาดการตรวจสอบข้อมูล Master Drug Information : ";
                        throw new Exception(V + datafilename);
                    }
                }
            }catch(Exception e)
            {
                throw new Exception(" Insert Data Master Drug Information : " + e.Message);
            }
            return result;
        }

        //public bool InsertRestFullAPI(Thaneshopmiddle_ATPM md)
        //{
        //    //bool result = false;

        //    //try
        //    //{
        //    //    if (md != null)
        //    //    {
        //            //JsonThaneshopMiddles jMiddle = new JsonThaneshopMiddles
        //            //{
        //                //f_prescriptionno = md.PrescriptionNo,                           //Field 01
        //                //f_seq = md.Seq,                                                 //Field 02
        //                //f_seqmax = md.SeqMax,                                           //Field 03
        //                //f_runningno = md.RunningNo,                                     //Field 04
        //                //f_prescriptiondate = md.PrescriptionDate,                       //Field 05
        //                //f_ordercreatedate = md.OrderCreateDate,                         //Field 06
        //                //f_ordertargetdate = md.OrderTargetDate,                         //Field 07
        //                //f_ordertargettime = md.OrderTargetTime,                         //Field 08
        //                //f_pharmacylocationcode = md.PharmacyLocationCode,               //Field 09
        //                //f_pharmacylocationdesc = md.PharmacyLocationDesc,               //Field 10
        //                //f_userorderby = md.UserOrderBy,                                 //Field 11
        //                //f_useracceptby = md.UserAcceptBy,                               //Field 12
        //                //f_orderacceptdate = md.OrderAcceptDate,                         //Field 13
        //                //f_orderacceptfromip = md.OrderAcceptFromIP,                     //Field 14
        //                //f_dispensestatus = md.DispenseStatus,                           //Field 15
        //                //f_status = md.Status,                                           //Field 16
        //                //f_printstatus = md.PrintStatus,                                 //Field 17
        //                //f_hn = md.Hn,                                                   //Field 18
        //                //f_an = md.An,                                                   //Field 19
        //                //f_vn = md.Vn,                                                   //Field 20
        //                //f_patientname = md.PatientName,                                 //Field 21
        //                //f_sex = md.Sex,                                                 //Field 22
        //                //f_patientdob = md.PatientDOB,                                   //Field 23
        //                //f_wardcode = md.WardCode,                                       //Field 24
        //                //f_warddesc = md.WardDesc,                                       //Field 25
        //                //f_roomcode = md.RoomCode,                                       //Field 26
        //                //f_roomdesc = md.RoomDesc,                                       //Field 27
        //                //f_bedcode = md.BedCode,                                         //Field 28
        //                //f_drugallergy = md.DrugAllergy,                                 //Field 29
        //                //f_doctorcode = md.DoctorCode,                                   //Field 30
        //                //f_doctorname = md.DoctorName,                                   //Field 31
        //                //f_tomachineno = md.ToMachineNo,                                 //Field 32
        //                //f_orderitemcode = md.OrderItemCode,                             //Field 33
        //                //f_orderitemname = md.OrderItemName,                             //Field 34
        //                //f_orderqty = md.OrderQty,                                       //Field 35
        //                //f_orderunitcode = md.OrderUnitCode,                             //Field 36
        //                //f_orderunitdesc = md.OrderUnitDesc,                             //Field 37
        //                //f_dosage = md.Dosage,                                           //Field 38
        //                //f_dosageunit = md.DosageUnit,                                   //Field 39
        //                //f_binlocation = md.BinLocation,                                 //Field 40
        //                //f_itemidentify = md.ItemIdentify,                               //Field 41
        //                //f_itemlotno = md.ItemLotNo,                                     //Field 42
        //                //f_itemlotexpire = md.ItemLotExpire,                             //Field 43
        //                //f_instructioncode = md.InstructionCode,                         //Field 44
        //                //f_instructiondesc = md.InstructionDesc,                         //Field 45
        //                //f_drugformcode = md.DrugFormCode,                               //Field 46
        //                //f_drugformdesc = md.DrugFormDesc,                               //Field 47
        //                //f_highalretdrug = md.HeighAlretDrug,                            //Field 48
        //                //f_prnstat = md.PRNSTAT,                                         //Field 49
        //                //f_prioritycode = md.PriorityCode,                               //Field 50
        //                //f_prioritydesc = md.PriorityDesc,                               //Field 51
        //                //f_frequencycode = md.FrequencyCode,                             //Field 52
        //                //f_frequencydesc = md.FrequencyDesc,                             //Field 53
        //                //f_frequencytime = md.FrequencyTime,                             //Field 54
        //                //f_dosagedispense = md.DosageDispense,                           //Field 55
        //                //f_language = md.Language,                                       //Field 56
        //                //f_durationcode = md.DurationCode,                               //Field 57
        //                //f_noteprocessing = md.NoteProcessing,                           //Field 58
        //                //f_barcodebyhis = md.BarcodeByHIS,                               //Field 59
        //                //f_excludeipfill = md.ExcludeIPFill,                             //Field 60
        //                //f_lastmodified = md.LastModified,                               //Field 61
        //                //f_comment = md.Comment,                                         //Field 62
        //                //f_drugbagsplit = md.DrugBagSplit,                               //Field 63
        //                //f_opd_adminstatus = md.OPDAdminStatus,                          //Field 64
        //                //f_opd_admindatetime = md.OPDAdminDateTime,                      //Field 65
        //                //f_opd_adminby = md.OPDAdminBy,                                  //Field 66
        //                //f_opd_adminremark = md.OPDAdminRemark,                          //Field 67
        //                //f_opd_adminlocation = md.OPDAdminLocation,                      //Field 68
        //                //f_opd_admincontinue = md.OPDAdminContinue                       //Field 69
        //            };

                    //jMiddle.AddThaneshopMiddles(jMiddle);

                    ////Master Ward 
                    //if (md.WardCode != ward_Compare)
                    //{
                    //    ward_Compare = md.WardCode;
                    //    JsonWard jWard = new JsonWard
                    //    {
                    //        wardCode = md.WardCode,
                    //        wardName = md.WardDesc,
                    //        status = 1
                    //    };
                    //    jWard.AddWard(jWard);
                    //}

                    ////Master Beds 
                    //if (md.BedCode != ward_Compare)
                    //{
                    //    bed_Compare = md.BedCode;
                    //    JsonBed jBed = new JsonBed
                    //    {
                    //        roomCode = md.RoomCode,
                    //        roomName = md.RoomDesc,
                    //        bedCode = md.BedCode,
                    //        status = 1
                    //    };
                    //    jBed.AddBeds(jBed);
                    //}

                    ////Master Patient And Patient Visits
                    //if (md.Hn != hn_Compare)
                    //{
                    //    hn_Compare = md.Hn;
                    //    JsonPatient jPatient = new JsonPatient
                    //    {
                    //        hn = md.Hn,
                    //        patientName = md.PatientName,
                    //        patientDOB = md.PatientDOB,
                    //        sex = md.Sex
                    //    };
                    //    jPatient.AddPatient(jPatient);

                    //    JsonPatientVisits jPatientVisits = new JsonPatientVisits
                    //    {
                    //        assigned_Location = md.WardCode,
                    //        wardCode = md.WardCode,
                    //        roomCode = md.RoomCode,
                    //        bedCode = md.BedCode,
                    //        an = md.An,
                    //        vn = md.Vn,
                    //        doctorCode = md.DoctorCode,
                    //        doctorName = md.DoctorName,
                    //        patTypeCode = "01",
                    //        admitDate = md.OrderCreateDate,
                    //        dischargeDate = DateTime.Now,
                    //        hn = md.Hn
                    //    };
                    //    jPatientVisits.AddPatientVisits(jPatientVisits);
                    //}

                    ////Maste3r Prescription Order
                    //if (md.PrescriptionNo != pres_Compare)
                    //{
                    //    pres_Compare = md.PrescriptionNo;
                    //    JsonPrescriptionOrders jPrescriptionOrder = new JsonPrescriptionOrders
                    //    {
                    //        orderControl = md.PriorityCode,
                    //        prescriptionNo = md.PrescriptionNo,
                    //        presType = "all",
                    //        orderStatus = 0,
                    //        prescriptionDate = DateTime.ParseExact(md.PrescriptionDate, "yyyyMMdd", new CultureInfo("en-US"), DateTimeStyles.None),
                    //        userAcceptBy = md.UserAcceptBy,
                    //        enterLocation = "ห้องยาชั้น 12 โรงพยาบาลหัวเฉียว",
                    //        enterDevice = "InterfaceApp",
                    //        userCreatedBy = md.UserOrderBy,
                    //        userActionBy = md.UserAcceptBy,
                    //        hn = md.Hn
                    //    };
                    //    jPrescriptionOrder.AddPrescriptionOrders(jPrescriptionOrder);
                    //}
                    ////Master Drug Info
                    //if(md.OrderItemCode != drug_Compare)
                    //{
                    //    drug_Compare = md.OrderItemCode;
                    //    JsonDruginfo jDrugInfo = new JsonDruginfo
                    //    {
                    //        drugCode = md.OrderItemCode,
                    //        drugName = md.OrderItemName,
                    //        drugNamePrint = md.OrderItemName,
                    //        drugNameThai = md.OrderItemName,
                    //        drugStatus = 1,
                    //        toMachineNo = (int)md.ToMachineNo,
                    //        NDC = md.BarcodeByHIS,
                    //        locationBin = md.BinLocation
                    //    };
                    //    jDrugInfo.AddDrugInfo(jDrugInfo);
                    //}

                    ////Master DrugUnite
                    //if (md.OrderUnitCode != drugunits_Compare)
                    //{
                    //    drugunits_Compare = md.OrderUnitCode;
                    //    JsonDrugUnits jDrugUnits = new JsonDrugUnits
                    //    {
                    //        unitCode = md.OrderUnitCode,
                    //        unitName = md.OrderUnitDesc
                    //    };
                    //    jDrugUnits.AddDrugUnits(jDrugUnits);
                    //}

                    ////Master Instruction
                    //if(md.InstructionCode != instruction_Compare)
                    //{
                    //    instruction_Compare = md.InstructionCode;
                    //    JsonInstruction jInstruction = new JsonInstruction
                    //    {
                    //        instructionCode = md.InstructionCode,
                    //        instructionName = md.InstructionDesc
                    //    };
                    //    jInstruction.AddInstruction(jInstruction);
                    //}

                    ////Master Frquency
                    //if(md.FrequencyCode != frequency_Compare)
                    //{
                    //    frequency_Compare = md.FrequencyCode;
                    //    string[] cFrequency = { };
                    //    cFrequency = md.FrequencyDesc.Split('_');
                    //    JsonFrequency jFrequency = new JsonFrequency
                    //    {
                    //        frequencyCode = md.FrequencyCode,
                    //        frequencyName = cFrequency[1]
                    //    };
                    //    jFrequency.AddFrequecy(jFrequency);
                    //}

                    ////Master Priority
                    //if(md.PriorityCode != priority_Compare)
                    //{
                    //    priority_Compare = md.PriorityCode;
                    //    JsonPriority jPriority = new JsonPriority
                    //    {
                    //        priorityCode = md.PriorityCode,
                    //        priorityName = md.PriorityDesc
                    //    };
                    //    jPriority.AddPriority(jPriority);
                    //}

                    //result = true;
            //    }
           
            //}
            //catch (Exception e)
            //{
            //    var ErrorMessage = JsonConvert.DeserializeObject<dynamic>(e.Message);
            //    throw new Exception("RestFull API Error Insert Data Thanesmiddle : " + ErrorMessage.errorMessage);
            //}
            //return result;
       // }

        int irowHL7 = 0;
        string strHL7 = "";

        private void GenerateHL7(Thaneshopmiddle_ATPM md, Thaneshopmiddle_extentions_ATPM ext, int rowData)
        {
            try
            {
                string[]childPatient = { };
                string[]childUserOrder = { };
                string[]childUserAccept = { };
                string[] childDoctor = { };

                md.PatientName = md.PatientName.Replace("  "," ");
                childPatient = md.PatientName.Split(' ');
                childUserOrder = md.UserOrderBy.Split(' ');
                childUserAccept = md.UserAcceptBy.Split(' ');
                childDoctor = md.DoctorName.Split(' ');

                string orderdate = md.OrderTargetDate.Replace("/", "");
                string orderTargetDatetime = orderdate.Substring(4,4) + orderdate.Substring(2, 2) + orderdate.Substring(0, 2) + md.OrderTargetTime.Replace(":","")+ "00";

                datafilename = datafilename.Replace(".txt", "");
                datafilename = datafilename.Replace("PACK", "");
                datafilename = datafilename.Replace("_", "");

                if (rowData > 0  && irowHL7 != rowData)
                {
                    if(irowHL7 == 0)
                    {
                        //Created MSH 
                        strHL7 += "MSH|^~"+@"\&|SSB Healthcare|SSB (Bangkok) Co., Ltd.|ConHIS Interface|Thanes Delopment Co.,tld|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "||RDS^O13|" + datafilename + "|P|2.7|||||||||||||| " + "\r\n";

                        strHL7 += "PID|1|" + md.Hn + "|||" + childPatient[2] + "^" + childPatient[1] + "^^" + childPatient[0] + "||" + md.PatientDOB.ToString("yyyyMMdd") + "|" + md.Sex + "|||||||" + md.Language + "|||||||||||||||||||||||||" + "\r\n";
                        if (md.DrugAllergy != "")
                        {
                            strHL7 += "AL1|" + md.Hn + "|DA|" + md.DrugAllergy + "||ระบุอาการแพ้เฉพาะที่บันทึกไว้|" + DateTime.Now.ToString("yyyyMMdd") + "\r\n";
                        }

                        strHL7 += "PV1|1|I|" + md.WardCode + "^" + md.WardDesc + "^" + md.RoomCode + "^" + md.BedCode + "||" + md.An + "||||||||||||123456^ดูแลผู้ป่วย^ทดสอบแพทย์^^^ นายแพทย์|F7^ผู้ประกันตนประกันสังคม|" + md.Vn + "|||||||||||||||||||||||||||||||||||" + "\r\n";
                    }
                   
                    if(irowHL7 != rowData)
                    {
                        irowHL7++;

                        strHL7 += "ORC|NW|" + md.RunningNo + "|" + md.PrescriptionNo + "||" + md.DispenseStatus + "|" + md.Status + "|||" + md.PrescriptionDate + "|99999^" + childUserOrder[2] + "^" + childUserOrder[1] + "^" + childUserOrder[0] + "|99999^" + childUserAccept[2] + " ^ " + childUserAccept[1] + " ^ " + childUserAccept[0] + "|" + md.DoctorCode + "^" + childDoctor[2] + "^" + childDoctor[1] + "^" + childDoctor[0] + "|" + md.PharmacyLocationCode + "^" + md.PharmacyLocationDesc + "||" + orderTargetDatetime + "||||" + md.OrderAcceptFromIP + "||||||||||||||" + "\r\n";

                        strHL7 += "TQ1|1|" + md.OrderQty + "|" + md.FrequencyCode + "||||" + orderTargetDatetime + "||" + md.PriorityCode + "^" + md.PriorityDesc + "||" + md.Comment + "||" + md.DurationCode + "|" + "\r\n";

                        strHL7 += "RXD|" + md.Seq + "|" + md.OrderItemCode + "^" + md.OrderItemName + "^^^|" + md.LastModified.ToString("yyyyMMddHHmmss") + "||" + md.OrderUnitCode + "^" + md.OrderUnitDesc + "^" + md.OrderUnitCode.ToUpper() + "|" + md.OrderUnitCode.ToUpper() + "|" + md.PrescriptionNo + "|" + md.InstructionCode + "|" + md.InstructionDesc + "||||||01^" + ext.DrugLabelName + "|||" + md.ItemLotNo + "|" + md.ItemLotExpire.ToString("yyyyMMdd") + "|||||" + md.ToMachineNo + "|NDC Barcode|" + md.PharmacyLocationCode + "^" + md.PharmacyLocationDesc + "||||||||" + "\r\n";

                        strHL7 += "NTE|1||" + md.FrequencyDesc + "|" + md.FrequencyTime + "^" + md.DosageDispense + "||"+DateTime.Now.ToString("yyyyMMddHHmmss")+"||" + "\r\n";

                        strHL7 += "RXR|" + md.OrderItemCode + "|" + md.PharmacyLocationCode + "^" + md.PharmacyLocationDesc + "|" + md.ToMachineNo + "|||" + "\r\n";
                    }  
                }
                if (irowHL7 == rowData)
                {
                    DateTime date = DateTime.UtcNow.Date;
                    string genfolder = Variable.PathLogs + @"\HL7";
                    string filename = genfolder + @"\" + datafilename + ".hl7";
                    if (!Directory.Exists(genfolder))
                    {
                        Directory.CreateDirectory(genfolder);
                    }
                    else if (datafilename != null)
                    {
                        StreamWriter sw;
                        if ((File.Exists(filename)) && (strHL7 != null))
                        {
                            sw = File.AppendText(filename);
                            sw.Write(strHL7);
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                        }
                        else if (strHL7 != null)
                        {
                            sw = File.CreateText(filename);
                            sw.Write(strHL7);
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                        }

                        irowHL7 = 0;
                        strHL7 = "";
                        rowData = 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Generate HL7 Version 2.7 file : " + e.Message);
            }
        }
    }
}