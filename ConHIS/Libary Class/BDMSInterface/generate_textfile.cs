using ConHIS.Libary_Class;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace ConHIS
{
    internal class Generate_textfile
    {
        //Variable And Objects
        private DataSet pr = null;

        private DataSet ds = null;

        private System_logfile log = new System_logfile();
        private Thaneshopmiddle th = new Thaneshopmiddle();
        private readonly Thanes_textfileslog l = new Thanes_textfileslog();

        private static string errorMessage;
        private static string datatext;
        private static string presfilename;
        private string datafilename;

        protected char _SeparatorPattren;

        public char Separator
        {
            set { _SeparatorPattren = value; }
        }

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

        private string event_code;
        private string event_message;
        private string error_message;

        //Constructor And Abstract Class
        public Generate_textfile()
        {
        }

        public Generate_textfile(string path, char Seprator)
        {
            this._pathname = path;
            this._SeparatorPattren = Seprator;
        }

        public string Generate_format(bool status, char string_format)
        {
            string result = null;
            string f = Convert.ToString(string_format);
            int itemspres = 0;
            if (status == true)
            {
                pr = th.GetDataThanesMiddleGroupByPres();
                if (pr.Tables[0].Rows.Count != 0)
                {
                    presfilename = pr.Tables[0].Rows[0][0].ToString().Trim();
                    ds = th.GetDataThanesMiddle(presfilename);
                    ////presfilename = presfilename.Replace("/", "_");
                    itemspres = ds.Tables[0].Rows.Count;
                    if (itemspres != 0)
                    {
                        for (int i = 0; i < itemspres; i++)
                        {
                            result += ds.Tables[0].Rows[i]["f_prescriptionno"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_seq"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_seqmax"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_prescriptiondate"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_hn"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_en"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_patientname"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_sex"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_patientepisodedate"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_prioritycode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_prioritydesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_ordertargetdate"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_ordertargettime"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_ordercreatedate"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_ordercreatetime"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderitemcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderitemname"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderqty"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderunitcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderunitdesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_instructioncode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_instructiondesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_dosage"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_dosageunit"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_frequencycode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_frequencydesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_durationcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_durationdesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_noteprocessing"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_fromlocationname"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_userorderby"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_useracceptby"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderacceptdate"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderaccepttime"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_orderacceptfromip"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_patientdob"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_itemlotcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_itemlotexpire"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_doctorcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_doctorname"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_wardcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_warddesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_roomcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_roomdesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_bedcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_beddesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_pharmacylocationcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_pharmacylocationdesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_pharmacyitemcode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_pharmacyitemdesc"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_freetext1"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_freetext2"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_itemidentify"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_tomachineno"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_dispensestatus"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_status"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_lastmodified"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_PRN"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_frequencyTime"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_language"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_dosagedispense"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_comment"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_statusCh"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_freetext3"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_freetext4"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_heighAlertDrug"].ToString().Trim() + f;
                            // result += ds.Tables[0].Rows[i]["f_referenceCode"].ToString().Trim() + f;
                            result += ds.Tables[0].Rows[i]["f_prescriptionno"].ToString().Trim() + ds.Tables[0].Rows[i]["f_seq"].ToString().Trim();
                            if (itemspres > 1)
                            {
                                result += "\r\n";
                            }
                        }
                    }
                }
            }
            return result;
        }

        //Functions for writing data files
        //By creating a filename based on the prescription number of the patient.

        public bool ExportTextFile(bool enable)
        {
            bool result = false;
            try
            {
                if ((enable == true) && ((_pathname != null) || (_pathname != "")))
                {
                    datatext = Generate_format(true, _SeparatorPattren);
                    DateTime date = DateTime.UtcNow.Date;
                    string genfolder = _pathname + @"\" + date.ToString("dd-MM-yyyy") + @"\Wait";
                    string filename = genfolder + @"\" + presfilename + ".txt";
                    if (!Directory.Exists(genfolder))
                    {
                        Directory.CreateDirectory(genfolder);
                    }
                    else if (presfilename != null)
                    {
                        StreamWriter sw;
                        presfilename = presfilename.Replace("_", "/");
                        if ((File.Exists(filename)) && (datatext != null))
                        {
                            sw = File.AppendText(filename);
                            sw.Write(datatext);
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                            th.Status = 1;
                        }
                        else if (datatext != null)
                        {
                            sw = File.CreateText(filename);
                            sw.Write(datatext);
                            sw.Flush();
                            sw.Close();
                            sw.Dispose();
                            th.Status = 1;
                        }
                        if (th.UpdateDataGenerateByPres(presfilename) == true)
                        {
                            presfilename = null;
                            result = true;
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException DirNotFound)
            {
                errorMessage = DirNotFound.ToString();
            }
            catch (UnauthorizedAccessException UnAuthDir)
            {
                errorMessage = UnAuthDir.ToString();
            }
            catch (PathTooLongException LongPath)
            {
                errorMessage = LongPath.ToString();
            }
            catch (IOException ex)
            {
                result = false;
                errorMessage = ex.ToString();
            }
            return result;
        }

        //Functions for reading data files
        //By Read a filename based on the prescription number of the patient.
        public bool ImportTextFile(string filename, bool enable)
        {
            bool result = false;
            try
            {
                if ((enable == true) && ((filename != null) || (filename != "")))
                {
                    Variable.TextFileName = filename;
                    string targetfolder = Search_targetfolder();
                    string waitfolder = Variable.PathHost.ToString();
                    _prescriptionfile = waitfolder + @"\" + filename;

                    log.Writelogfile("[" + filename + "] : " + " รออ่านไฟล์ข้อมูล [1]", " TextFileProcess");
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
                            log.Writelogfile("[" + filename + "] : " + " ไฟล์ข้อมูลซ้ำกันในระบบ [2]", " TextFileProcess");
                            log.Writelogfile("[" + filename + "] : " + " ไฟล์ข้อมูลซ้ำกันในระบบ [2]", " TextFileDupicate");
                        }
                        event_code = "E0006";
                        event_message = "[" + filename + "] : " + "ไฟล์ข้อมูลซ้ำกันในระบบ";

                        this.WritelogSystem(true);
                    }
                    else
                    {
                        // Check the status of the prescription as a cancellation of a prescription.
                        if (filename.Contains("_C_"))
                        {
                            if (this.ReadFileToProcess(_prescriptionfile, "delete") == true)
                            {
                                string cancalfolder = targetfolder + @"\Cancel";
                                string prescriptioncancel = cancalfolder + @"\" + filename;
                                CreateFolderTypeAndMoveFile(cancalfolder);
                                if (File.Exists(_prescriptionfile))
                                {
                                    System.IO.File.Move(_prescriptionfile, prescriptioncancel);
                                }
                                event_code = "D0001";
                                event_message = "[" + filename + "] : " + "ยกเลิกข้อมูลเรียบร้อยแล้ว";
                                this.WritelogSystem(true);
                            }
                        }
                        //Check the status of the prescription as if adding a prescription list information.
                        else if (filename.Contains("_A_"))
                        {
                        }
                        //Check the status of prescriptions according to the status of normal data addition
                        else
                        {
                            datafilename = filename;
                            if (this.ReadFileToProcess(_prescriptionfile, "insert") == true)
                            {
                                string completefolder = targetfolder + @"\Complete";
                                string prescriptioncomplete = completefolder + @"\" + filename;
                                CreateFolderTypeAndMoveFile(completefolder);
                                if (File.Exists(_prescriptionfile))
                                {
                                    System.IO.File.Move(_prescriptionfile, prescriptioncomplete);
                                    log.Writelogfile("[" + filename + "] : " + " ไฟล์ข้อมูลบันทึกข้อมูลเรียบร้อย [3]", " TextFileProcess");
                                    log.Writelogfile("[" + datafilename + "] : " + " ไฟล์ข้อมูลบันทึกข้อมูลเรียบร้อย [3]", " TextFileComplete");
                                }
                                datafilename = "";
                                event_code = "C0001";
                                event_message = "[" + filename + "] : " + "บันทึกข้อมูลเรียบร้อยแล้ว";
                                this.WritelogSystem(true);
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
                    log.Writelogfile("[" + filename + "] : " + " ไม่พบที่อยู่ของ Directory ไฟล์ข้อมูลนี้ [1]", " TextFileProcess");
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + DirNotFound.ToString(), " Read Text File Error");
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
                    log.Writelogfile("[" + filename + "] : " + " ไฟล์ข้อมูลนี้ ไม่ได้รับอนุญาติ ไม่สามารถเข้าถึงได้ [1]", " TextFileProcess");
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + UnAuthDir.ToString(), " Read Text File Error");
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
                    log.Writelogfile("[" + filename + "] : " + " เส้นทางที่อยู่ไฟล์ข้อมูลยาวเกินไป [1]", " TextFileProcess");
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + LongPath.ToString(), " Read Text File Error");
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
                    log.Writelogfile("[" + filename + "] : " + " เกิดข้อผิดพลาดการเข้าถึงแหล่งข้อมูล [1]", " TextFileProcess");
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + ex.ToString() + "\r\n" + ex.GetType(), " Read Text File Error");
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
                string waitfolder = Variable.PathHost.ToString();

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
        public bool ReadFileToProcess(string pathTextfile, string process)
        {
            bool result = false;
            string datafile = null;
            try
            {
                if (File.Exists(pathTextfile))
                {
                    using (FileStream fs = new FileStream(pathTextfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        StreamReader sr = new StreamReader(fs, Encoding.Default);
                        datafile = sr.ReadToEnd().ToString();
                        sr.Close();
                        sr.Dispose();
                        fs.Close();
                        fs.Dispose();
                    }

                    if ((datafile != null) || (datafile != ""))
                    {
                        log.Writelogfile("[" + datafilename + "] : " + " อ่านไฟล์ข้อมูลสำเร็จ [2]", " TextFileProcess");
                        switch (Variable.Encode_Separator)
                        {
                            case 0:

                                datafile = datafile.Replace("\n", _SeparatorPattren.ToString());                   //Changed '\r\n' to "|"
                                break;

                            case 1:

                                break;

                            case 2:
                                datafile = datafile.Replace("\n", _SeparatorPattren.ToString());                   //Changed '\r\n' to "|"
                                break;

                            case 3:
                                break;
                        }

                        int textlength = datafile.Length;
                        string[] valuetext = datafile.Split(_SeparatorPattren);

                        int line = ((valuetext.GetLength(0)) / 65);               //Get SeqMax Data Prescription
                        int compare_filed = ((valuetext.GetLength(0) - 1) % 65);
                        int i = 0;
                        int j = 0;
                        string str = "";

                        if (compare_filed == 0)
                        {
                            while (i < line)
                            {
                                th.PrescriptonNo = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 0)).ToString().Trim();
                                string str_seq = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 1)).ToString().Trim();
                                if (int.TryParse(str_seq, out int t_seq))
                                {
                                    th.Seq = Convert.ToInt32(t_seq);
                                }
                                else
                                {
                                    str += " column : f_seq     data : " + str_seq + "  data type : int " + "\r\n";
                                }
                                string str_seqmax = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 2)).ToString().Trim();
                                if (int.TryParse(str_seqmax, out int t_seqmax))
                                {
                                    th.SeqMax = Convert.ToInt32(t_seqmax);
                                }
                                else
                                {
                                    str += " column : f_seqmax     data : " + str_seqmax + "  data type : int " + "\r\n";
                                }
                                th.PrescriptionDate = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 3)).ToString().Trim();
                                th.Hn = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 4)).ToString().Trim();
                                th.En = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 5)).ToString().Trim();
                                th.PatientName = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 6)).ToString().Trim();
                                string str_sex = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 7)).ToString().Trim();
                                if (Decimal.TryParse(str_sex, out decimal t_sex))
                                {
                                    th.Sex = Convert.ToDecimal(t_sex);
                                }
                                else
                                {
                                    str += " column : f_sex     data : " + str_sex + "  data type : numeric " + "\r\n";
                                }
                                //th.PatientEpisodeDate = Convert.ToDateTime(datafile.Split(_SeparatorPattren).GetValue(Sep(j, 8)).ToString().Trim());
                                th.PriorityCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 9)).ToString().Trim();
                                th.PriorityDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 10)).ToString().Trim();
                                th.OrderTargetDate = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 11)).ToString().Trim();
                                th.OrderTargetTime = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 12)).ToString().Trim();
                                th.OrderCreateDate = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 13)).ToString().Trim();
                                th.OrderCreateTime = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 14)).ToString().Trim();
                                th.OrderItemCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 15)).ToString().Trim();
                                th.OrderItemName = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 16)).ToString().Trim();
                                string str_orderqty = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 17)).ToString();
                                if (Decimal.TryParse(str_orderqty, out decimal t_orderqty))
                                {
                                    th.OrderQty = Convert.ToDecimal(t_orderqty);
                                }
                                else
                                {
                                    str += " column : f_orderqty     data : " + str_orderqty + "  data type : numeric " + "\r\n";
                                }
                                th.OrderUnitCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 18)).ToString().Trim();
                                th.OrderUnitDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 19)).ToString().Trim();
                                th.InstructionCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 20)).ToString().Trim();
                                th.InstructionDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 21)).ToString().Trim();
                                string str_dosage = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 22)).ToString().Trim();
                                if (Decimal.TryParse(str_dosage, out decimal t_dosage))
                                {
                                    th.Dosage = Convert.ToDecimal(t_dosage);
                                }
                                else
                                {
                                    str += " column : f_dosage     data : " + str_dosage + "  data type : numeric " + "\r\n";
                                }
                                th.DosageUnit = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 23)).ToString().Trim();
                                th.FrequencyCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 24)).ToString().Trim();
                                th.FrequencyDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 25)).ToString().Trim();
                                th.DurationCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 26)).ToString().Trim();
                                th.DurationDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 27)).ToString().Trim();
                                th.NoteProcessing = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 28)).ToString().Trim();
                                th.FromLocationName = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 29)).ToString().Trim();
                                th.UserOrderBy = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 30)).ToString().Trim();
                                th.UserAcceptBy = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 31)).ToString().Trim();
                                th.OrderAcceptDate = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 32)).ToString().Trim();
                                th.OrderAcceptTime = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 33)).ToString().Trim();
                                th.OrderAcceptFromIP = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 34)).ToString().Trim();
                                th.PatientDOB = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 35)).ToString().Trim();
                                th.ItemLotCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 36)).ToString().Trim();
                                th.ItemLotExpire = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 37)).ToString().Trim();
                                th.DoctorCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 38)).ToString().Trim();
                                th.DoctorName = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 39)).ToString().Trim();
                                th.WardCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 40)).ToString().Trim();
                                th.WardDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 41)).ToString().Trim();
                                th.RoomCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 42)).ToString().Trim();
                                th.RoomDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 43)).ToString().Trim();
                                th.BedCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 44)).ToString().Trim();
                                th.BedDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 45)).ToString().Trim();
                                th.PharmacyLocationCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 46)).ToString().Trim();
                                th.PharmacyLocationDesc = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 47)).ToString().Trim();
                                th.Freetext1 = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 48)).ToString().Trim();
                                th.Freetext2 = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 49)).ToString().Trim();
                                th.ItemIdentify = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 50)).ToString().Trim();
                                string str_tomachineno = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 51)).ToString().Trim();
                                if (int.TryParse(str_tomachineno, out int t_tomachineno))
                                {
                                    th.ToMachineNo = Convert.ToInt32(t_tomachineno);
                                }
                                else
                                {
                                    str += " column : f_tomachineno     data : " + str_tomachineno + "  data type : int " + "\r\n";
                                }
                                string str_dispensestatus = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 52)).ToString().Trim();
                                if (int.TryParse(str_dispensestatus, out int t_dispensestatus))
                                {
                                    th.DispenseStatus = Convert.ToInt32(t_dispensestatus);
                                }
                                else
                                {
                                    str += " column : f_dispensestatus     data : " + str_dispensestatus + "  data type : int " + "\r\n";
                                }
                                string str_status = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 53)).ToString().Trim();
                                if (int.TryParse(str_status, out int t_status))
                                {
                                    th.Status = Convert.ToInt32(t_status);
                                }
                                else
                                {
                                    str += " column : f_status     data : " + str_status + "  data type : int " + "\r\n";
                                }
                                //th.LastModified = Convert.ToDateTime(datafile.Split(_SeparatorPattren).GetValue(Sep(j, 54)).ToString().Trim());
                                string str_PRN = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 55)).ToString().Trim();
                                if (Decimal.TryParse(str_PRN, out decimal t_PRN))
                                {
                                    th.PRN = Convert.ToDecimal(t_PRN);
                                }
                                else
                                {
                                    str += " column : f_PRN     data : " + str_PRN + "  data type : numeric " + "\r\n";
                                }
                                th.FrequencyTime = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 56)).ToString().Trim();
                                string str_language = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 57)).ToString().Trim();
                                if (int.TryParse(str_language, out int t_language))
                                {
                                    th.Language = Convert.ToInt32(t_language);
                                }
                                else
                                {
                                    str += " column : f_language     data : " + str_language + "  data type : int " + "\r\n";
                                }
                                th.DosageDispense = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 58)).ToString().Trim();
                                th.Comment = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 59)).ToString().Trim();
                                string str_StatusCh = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 60)).ToString().Trim();
                                if (int.TryParse(str_StatusCh, out int t_StatusCh))
                                {
                                    th.StatusCh = Convert.ToInt32(t_StatusCh);
                                }
                                else
                                {
                                    str += " column : f_statusCh     data : " + str_StatusCh + "  data type : int " + "\r\n";
                                }
                                th.Freetext3 = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 61)).ToString().Trim();
                                th.Freetext4 = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 62)).ToString().Trim();
                                string str_HeighAlertDrug = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 63)).ToString().Trim();
                                if (int.TryParse(str_HeighAlertDrug, out int t_HeighAlertDrug))
                                {
                                    th.HeighAlertDrug = Convert.ToInt32(t_HeighAlertDrug);
                                }
                                else
                                {
                                    str += " column : f_heighAlertDrug     data : " + str_HeighAlertDrug + "  data type : int " + "\r\n";
                                }
                                th.ReferenceCode = datafile.Split(_SeparatorPattren).GetValue(Sep(j, 64)).ToString().Trim();

                                if (str != "")
                                {
                                    Variable.errorStrLog = str;
                                }

                                //=======================================Checked Data Fileds for BHQ ==================================================
                                th.OrderQty = (decimal)Math.Ceiling(th.OrderQty);
                                if (th.DurationDesc != "")
                                {
                                    th.DurationDesc = th.DurationDesc.Substring(0, 9);
                                }

                                if (th.Freetext1 != "")
                                {
                                    th.Freetext1 = th.Freetext1.Replace("^", "\r\n");
                                }
                                //=======================================DataBase Processing===================================================
                                //Insert Data new Prescription
                                switch (process)
                                {
                                    case "insert":
                                        if (th.CheckDataBeforeInSert(datafilename) == true)  //Check Data Before Insert to Database
                                        {
                                            if (th.InsertDataThanesMiddle() == true)
                                            {
                                                i++;
                                                j = (65 * i);
                                            }
                                            else
                                            {
                                                string targetfolder = Search_targetfolder();
                                                string errorfolder = targetfolder + @"\Error";
                                                string prescriptionerror = errorfolder + @"\" + datafilename;
                                                CreateFolderTypeAndMoveFile(errorfolder);
                                                if (File.Exists(_prescriptionfile))
                                                {
                                                    System.IO.File.Move(_prescriptionfile, prescriptionerror);
                                                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileProcess");
                                                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileError");
                                                }
                                                event_code = "E0001";
                                                event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";
                                                this.WritelogSystem(true);
                                                log.Writelogfile("[" + datafilename + "] \r\n" + errorMessage, " Read Text File Error");
                                                result = false;
                                            }
                                        }
                                        else
                                        {
                                            i = line;
                                            string targetfolder = Search_targetfolder();
                                            string errorfolder = targetfolder + @"\Error";
                                            string prescriptionerror = errorfolder + @"\" + datafilename;
                                            CreateFolderTypeAndMoveFile(errorfolder);
                                            if (File.Exists(_prescriptionfile))
                                            {
                                                System.IO.File.Move(_prescriptionfile, prescriptionerror);
                                                log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileProcess");
                                                log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileError");
                                            }
                                            event_code = "E0001";
                                            event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";
                                            this.WritelogSystem(true);
                                            log.Writelogfile("[" + datafilename + "] \r\n" + errorMessage, " Read Text File Error");
                                            result = false;
                                        }
                                        break;

                                    case "update":
                                        if (th.UpDateDataThanesMiddle() == true)
                                        {
                                            i++;
                                            j = (65 * i);
                                        }
                                        else
                                        {
                                            result = false;
                                        }
                                        break;

                                    case "delete":
                                        int items = Convert.ToInt32(th.GetItemsDataThanesMiddle(null, "all"));
                                        if (items != 0)
                                        {
                                            if (th.DeleteDataThanesMiddle() == true)
                                            {
                                                i++;
                                                j = (65 * i);
                                            }
                                        }
                                        else
                                        {
                                            result = false;
                                        }
                                        break;

                                    default:
                                        break;
                                }
                                if (i == line)
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                        }
                        else
                        {
                            string targetfolder = Search_targetfolder();
                            string errorfolder = targetfolder + @"\Error";
                            string prescriptionerror = errorfolder + @"\" + datafilename;
                            CreateFolderTypeAndMoveFile(errorfolder);
                            if (File.Exists(_prescriptionfile))
                            {
                                System.IO.File.Move(_prescriptionfile, prescriptionerror);
                                log.Writelogfile("[" + datafilename + "] : " + " ไฟล์ข้อมูล filed ข้อมูลไม่ถูกต้อง [3]", " TextFileProcess");
                                log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileError");
                            }
                            event_code = "E0001";
                            event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";

                            errorMessage = "จำนวน filed ข้อมูลไม่ถูกต้อง";
                            string strtxt = "column total : " + valuetext.GetLength(0) + "   data record : " + line + "   data is broken : " + compare_filed;
                            log.Writelogfile(strtxt, " Check_Data_Before_[ " + datafilename + " ]");
                            result = false;
                        }
                    }
                    else
                    {
                        string targetfolder = Search_targetfolder();
                        string errorfolder = targetfolder + @"\Error";
                        string prescriptionerror = errorfolder + @"\" + datafilename;
                        CreateFolderTypeAndMoveFile(errorfolder);
                        if (File.Exists(_prescriptionfile))
                        {
                            System.IO.File.Move(_prescriptionfile, prescriptionerror);
                            log.Writelogfile("[" + datafilename + "] : " + " อ่านไฟล์ข้อมูลไม่สำเร็จ ไฟล์ว่างเปล่า [3]", " TextFileProcess");
                            log.Writelogfile("[" + datafilename + "] : " + " อ่านไฟล์ข้อมูลไม่สำเร็จ ไฟล์ว่างเปล่า [3]", " TextFileError");
                        }
                        event_code = "E0001";
                        event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";
                        this.WritelogSystem(true);
                        log.Writelogfile("[" + datafilename + "] \r\n" + errorMessage, " Read Text File Error");
                        result = false;
                    }
                }
            }
            catch (IOException ex)
            {
                result = false;
                errorMessage = ex.ToString();
                string targetfolder = Search_targetfolder();
                string errorfolder = targetfolder + @"\Error";
                string prescriptionerror = errorfolder + @"\" + datafilename;
                CreateFolderTypeAndMoveFile(errorfolder);
                if (File.Exists(_prescriptionfile))
                {
                    System.IO.File.Move(_prescriptionfile, prescriptionerror);
                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileProcess");
                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileError");
                }
                event_code = "E0001";
                event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";

                log.Writelogfile("[" + datafilename + "] \r\n" + errorMessage, " Read Text File Error");
            }
            catch (Exception e)
            {
                result = false;
                errorMessage = e.ToString();
                string targetfolder = Search_targetfolder();
                string errorfolder = targetfolder + @"\Error";
                string prescriptionerror = errorfolder + @"\" + datafilename;
                CreateFolderTypeAndMoveFile(errorfolder);
                if (File.Exists(_prescriptionfile))
                {
                    System.IO.File.Move(_prescriptionfile, prescriptionerror);
                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileProcess");
                    log.Writelogfile("[" + datafilename + "] : " + " บันทึกข้อมูลลงฐานข้อมูลไม่สำเร็จ [3]", " TextFileError");
                }
                event_code = "E0001";
                event_message = "[" + datafilename + "] : " + "ข้อผิดพลาดอ่านไฟล์ข้อมูลไม่สำเร็จ โปรดตรวจสอบ !!!";

                log.Writelogfile("[" + datafilename + "] \r\n" + errorMessage, " Read Text File Error");
            }
            return result;
        }

        private static int Sep(int line, int value)
        {
            return (line + value);
        }

        public bool WritelogSystem(bool enable)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:sss.fff");
            if (enable == true)
            {
                Variable.SysQueue.Enqueue(String.Format("[{0}],{1},{2}", timestamp, event_code, event_message));
            }
            return true;
        }
    }
}