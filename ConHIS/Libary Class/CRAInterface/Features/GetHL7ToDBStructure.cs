﻿using ConHIS.Libary_Class.CRAInterface.HL7Structure;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ConHIS.Libary_Class.CRAInterface.Features
{
    public class GetHL7ToDBStructure
    {
        //Variable And Objects
        private static StreamReader sr;

        private ArrayList mSegments;

        private readonly System_logfile log;
        private readonly Thaneshopmiddle_ATPM md;
        private readonly Thaneshopmiddle_extentions_ATPM ext;

        private string datafilename;

        protected string _prescriptionfile;

        private string SetData = "";
        private string EventCd = "";
        private string OldName = "";

        private HL7Segments mHL7Message = new HL7Segments();
        private string ActiveFileType = "";
        private string EventFileType = "";

        public HL7Segments CurrentHL7
        {
            get { return mHL7Message; }
            set { }
        }
        public string PrescriptionFileName
        {
            get { return _prescriptionfile; }
            set { _prescriptionfile = value; }
        }

        public string PrescriptionNo
        {
            get { return SetData; }
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
        public GetHL7ToDBStructure()
        {
            log = new System_logfile();
            md = new Thaneshopmiddle_ATPM();
            ext = new Thaneshopmiddle_extentions_ATPM();

            
        }

        public GetHL7ToDBStructure(string path)
        {
            this._pathname = path;

            log = new System_logfile();
            md = new Thaneshopmiddle_ATPM();
            ext = new Thaneshopmiddle_extentions_ATPM();
        }

        //Functions for reading data files
        //By Read a filename based on the prescription number of the patient.
        public bool ReadHL7FileAsync(string filename)
        {
            const bool result = false;
            try
            {
                if ((filename != null) || (filename != ""))
                {
                    Variable.TextFileName = filename;

                    string waitfolder = Variable.PathHost;
                    _prescriptionfile = waitfolder + @"\" + filename;

                    //Check whether the data file is duplicate or not.
                    string[] pathfile = GetFileNamesDesctination(filename);

                    if ((pathfile != null) && (pathfile.GetLength(0) != 0))
                    {
                        datafilename = filename;
                        string dupicatefolder = SearchTargetFolder() + @"\Dupicate";
                        string prescriptiondupicate = dupicatefolder + @"\" + filename;
                        CreateFolderTypeAndMoveFile(dupicatefolder);
                        if (File.Exists(_prescriptionfile))
                        {
                            System.IO.File.Move(_prescriptionfile, prescriptiondupicate);
                            log.Writelogfile("[" + filename + "] :  ไฟล์ข้อมูลซ้ำกันในระบบ", " GetHL7ToDBStructure");
                        }
                        //Message Show Logs System
                        event_code = "Error";
                        event_message = "[" + filename + "] : ไฟล์ข้อมูลซ้ำกันในระบบ";
                        this.WritelogSystem(true);
                    }
                    else
                    {
                        datafilename = filename;
                        if (ReadFileToInsertArray(_prescriptionfile))
                        {
                            string completefolder = SearchTargetFolder() + @"\Complete";
                            string prescriptioncomplete = completefolder + @"\" + filename;
                            CreateFolderTypeAndMoveFile(completefolder);
                            if (File.Exists(_prescriptionfile))
                            {
                                System.IO.File.Move(_prescriptionfile, prescriptioncomplete);
                                log.Writelogfile("[" + datafilename + "] :  ไฟล์ข้อมูลบันทึกข้อมูลเรียบร้อย", " GetHL7ToDBStructure");
                            }
                            //Message Show Logs System
                            datafilename = "";
                            event_code = "Success";
                            event_message = "[" + filename + "] : บันทึกไฟล์ข้อมูลเรียบร้อยแล้ว";
                            this.WritelogSystem(true);
                        }
                        else
                        {
                            datafilename = filename;
                            string errorfolder = SearchTargetFolder() + @"\Error";
                            string prescriptionerror = errorfolder + @"\" + filename;
                            CreateFolderTypeAndMoveFile(errorfolder);
                            if (File.Exists(_prescriptionfile))
                            {
                                System.IO.File.Move(_prescriptionfile, prescriptionerror);
                                log.Writelogfile("[" + filename + "] :  ไฟล์ข้อมูลที่เกิดข้อผิดพลาด", " GetHL7ToDBStructure");
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                if (Variable.pathfileErrorAccess != filename)
                {
                    Variable.pathfileErrorAccess = filename;
                    error_message = "เกิดข้อผิดพลาดการเข้าถึงแหล่งข้อมูล";
                    event_code = "Error";
                    event_message = error_message;
                    this.WritelogSystem(true);
                    log.Writelogfile("[" + filename + "] : " + error_message + "\r\n" + ex.ToString() + "\r\n" + ex.GetType(), " GetHL7ToDBStructure");
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
                string targetfolder = SearchTargetFolder();
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
                string targetfolder = SearchTargetFolder();
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
                string targetfolder = SearchTargetFolder() + @"\Complete\";
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
        private string SearchTargetFolder()
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
                        log.Writelogfile("[" + datafilename + "] :  อ่านไฟล์ข้อมูลสำเร็จ", " GetHL7ToDBStructure");

                        fs.Close();
                        fs.Dispose();
                    }
                }
                else
                    result = "";
            }
            catch
            {
                log.Writelogfile("[" + datafilename + "] :  อ่านไฟล์ข้อมูลไม่สำเร็จ", " GetHL7ToDBStructure");
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

        public bool ReadFileToInsertArray(string pathFile)
        //public bool ReadFileToInsertArray(string dataHL7,string presc)
        {
            bool result = false;
            try
            {
                string dataHL7 = ReadFile(pathFile);

                dataHL7 = dataHL7.Replace("PID", "\nPID");
                dataHL7 = dataHL7.Replace("PV1", "\nPV1");
                dataHL7 = dataHL7.Replace("ORC", "\nORC");
                dataHL7 = dataHL7.Replace("AL1", "\nAL1");
                dataHL7 = dataHL7.Replace("RXD", "\nRXD");
                dataHL7 = dataHL7.Replace("RXR", "\nRXR");
                dataHL7 = dataHL7.Replace("NTE", "\nNTE");
                dataHL7 = dataHL7.Replace("TQ1", "\nTQ1");

                 DataText = dataHL7;

                int rows = LoadMessage(DataText);

                SetData = datafilename.Replace(".hl7","");

               // datafilename = presc;
               // SetData = presc;

                if (rows != 0)
                {
                    mHL7Message.LoadHL7Message(DataText);

                    if (mHL7Message.SegmentArray.Count > 0)
                    {
                        HL7NodeInfo HL7Node;
                        string segType;

                        for (int nodIdx = 0; nodIdx < mHL7Message.SegmentArray.Count; nodIdx++)
                        {
                            segType = mHL7Message.GetSegmentType(nodIdx);
                            HL7Node = new HL7NodeInfo(HL7NodeType.HL7Segment, segType.Trim().ToUpper(), nodIdx, -1, -1, -1);
                            HL7Node.ElementCount = mHL7Message.FieldCount(nodIdx);

                            if(OldName != datafilename)
                            {
                                OldName = datafilename;

                                if (mHL7Message.GetSegmentType(0) == "MSH")
                                {
                                    string[] segDetail = ((string)mHL7Message.SegmentArray[0]).Split('|');
                                    if (segDetail.Length > 7)
                                    {


                                        string msgType = segDetail[8];
                                        segDetail = msgType.Split('^');
                                        if (segDetail.Length > 1)
                                        {
                                            EventFileType = segDetail[0];
                                            ActiveFileType = segDetail[1];
                                            EventCd = EventFileType + " " + ActiveFileType;
                                            ActiveFileType = ActiveFileType.Trim().ToUpper();
                                            log.Writelogfile(" Drug Dispense IPD ID : " + datafilename.ToString() + " Message name-type = " + EventFileType, " HL7Messges");
                                            log.Writelogfile(" Drug Dispense IPD ID : " + datafilename.ToString() + " Message event-type = " + ActiveFileType, " HL7Messges");
                                        }
                                    }
                                }
                            }
                            
                            string[] childParts = { };
                            string parentData;

                            switch (EventFileType)
                            {
                                case "RDS":
                                    switch (ActiveFileType)
                                    {
                                        // O13 - Pharmacy/treatment dispense
                                        case "O13":
                                            if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                            {
                                                parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                childParts = parentData.Split('|');
                                                switch (HL7Node.SegmentType)
                                                {
                                                    case "MSH":
                                                        AddMessageHeader(childParts);
                                                        break;
                                                    case "PID":
                                                        AddPatientIdentification(childParts);
                                                        break;
                                                    case "PV1":
                                                        AddPatientVisit(childParts);
                                                        break;
                                                    case "ORC":
                                                        AddCommondOrder(childParts);
                                                        break;
                                                    case "AL1":
                                                        AddPatientAllergyInformation(childParts);
                                                        break;
                                                    case "RXD":
                                                        AddPharmacyTreamentDispense(childParts);
                                                        break;
                                                    case "RXR":
                                                        AddPharmacyTreatmentRoute(childParts);
                                                        break;
                                                    case "NTE":
                                                        AddNotesAndComments(childParts);
                                                        break;
                                                    case "TQ1":
                                                        AddTimingAndQuantity(childParts);
                                                        break;
                                                }
                                            }
                                            break;      
                                    }
                                    break;
                                case "ADT":
                                    switch (ActiveFileType)
                                    {
                                        // A01 - Admit/visit notification
                                        case "A01":
                                            if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                            {
                                                parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                childParts = parentData.Split('|');
                                                switch (HL7Node.SegmentType)
                                                {
                                                    case "MSH":
                                                        AddMessageHeader(childParts);
                                                        break;
                                                    case "EVN":
                                                        AddEventType(childParts);
                                                        break;
                                                    case "PID":
                                                        AddPatientIdentification(childParts);
                                                        break;
                                                    case "PV1":
                                                        AddPatientVisit(childParts);
                                                        break;
                                                    case "AL1":
                                                        AddPatientAllergyInformation(childParts);
                                                        break;
                                                }
                                            }
                                            break;
                                        // A02 - Transfer a patient
                                        case "A02":
                                            if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                            {
                                                parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                childParts = parentData.Split('|');
                                                switch (HL7Node.SegmentType)
                                                {
                                                    case "MSH":
                                                        AddMessageHeader(childParts);
                                                        break;
                                                    case "EVN":
                                                        AddEventType(childParts);
                                                        break;
                                                    case "PID":
                                                        AddPatientIdentification(childParts);
                                                        break;
                                                    case "PV1":
                                                        AddPatientVisit(childParts);
                                                        break;
                                                }
                                            }
                                            break;
                                        // A03 - Discharge/end visit
                                        case "A03":
                                            if (HL7Node.NodeType == HL7NodeType.HL7Segment)
                                            {
                                                parentData = mHL7Message.GetElement(HL7Node.MsgIndex);
                                                childParts = parentData.Split('|');
                                                switch (HL7Node.SegmentType)
                                                {
                                                    case "MSH":
                                                        AddMessageHeader(childParts);
                                                        break;
                                                    case "EVN":
                                                        AddEventType(childParts);
                                                        break;
                                                    case "PID":
                                                        AddPatientIdentification(childParts);
                                                        break;
                                                    case "PV1":
                                                        AddPatientVisit(childParts);
                                                        break;
                                                }
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }  
                    }
                 
                    MappingMiddleController map = new MappingMiddleController(EventFileType, ActiveFileType);

                    if (map.MiddleActiveEventHandler(SetData) == true)
                    {
                        ///////////////////  hos.UpdateStatusConHISMachine(1, fileID);///////////////////////////////////
                        event_code = "Success";
                        event_message = "[" + SetData + "] : " + "บันทึกข้อมูลเรียบร้อยแล้ว";
                        this.WritelogSystem(true);
                        result = true;
                    }
                    else
                    {
                        event_code = "Error";
                        event_message = "[" + SetData + "] : " + "บันทึกข้อมูลไม่สำเร็จ";
                        this.WritelogSystem(true);

                        result = false;
                    }
                }
                else
                {
                    result = false;
                    throw new Exception("ไม่มีข้อมูลในไฟล์ข้อมูล : " + datafilename + " ");
                }
            }
            catch (Exception ex)
            {
                result = false;
                event_code = "Error";
                event_message = "[" + datafilename + "] : " + ex.Message;
                this.WritelogSystem(true);

                log.Writelogfile("[" + datafilename + "] : บันทึกข้อมูลไม่สำเร็จ " + ex.Message, " GetHL7ToDBStructure");
            }
            return result;
        }

        public bool WritelogSystem(bool enable)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:sss.fff");
            if (enable)
                Variable.SysQueue.Enqueue(String.Format("[{0}],{1},{2}", timestamp, event_code, event_message));
            return true;
        }

        #endregion "Read TextFile To Array List."

        #region "HL7 Message Structure"
        private void AddMessageHeader(string[] data)
        {
            try
            {
                if (data.Length == 25)
                {
                    MSH msh = new MSH()
                    {
                        MSH_1 = "|",
                        MSH_2 = data[1],
                        MSH_3 = data[2],
                        MSH_4 = data[3],
                        MSH_5 = data[4],
                        MSH_6 = data[5],
                        MSH_7 = data[6],
                        MSH_8 = data[7],
                        MSH_9 = data[8],
                        MSH_10 = data[9],
                        MSH_11 = data[10],
                        MSH_12 = data[11],
                        MSH_13 = data[12],
                        MSH_14 = data[13],
                        MSH_15 = data[14],
                        MSH_16 = data[15],
                        MSH_17 = data[16],
                        MSH_18 = data[17],
                        MSH_19 = data[18],
                        MSH_20 = data[19],
                        MSH_21 = data[20],
                        MSH_22 = data[21],
                        MSH_23 = data[22],
                        MSH_24 = data[23],
                        // MSH_25 = childParts[25],
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(msh, datafilename).Validate();
                    if (ValidateResult)
                    {
                        msh.Add(msh);
                    }
                }
                else
                    throw new Exception("MSH -> [Total Required Column: 25][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientIdentification(string[] data)
        {
            try
            {
                if(data.Length == 41)
                {
                    PID pid = new PID()
                    {
                        PID_1 = data[1].Trim(),
                        PID_2 = data[2].Trim(),
                        PID_3 = data[3].Trim(),
                        PID_4 = data[4].Trim(),
                        PID_5 = data[5].Trim(),
                        PID_6 = data[6].Trim(),
                        PID_7 = data[7].Trim(),
                        PID_8 = data[8].Trim(),
                        PID_9 = data[9].Trim(),
                        PID_10 = data[10].Trim(),
                        PID_11 = data[11].Trim(),
                        PID_12 = data[12].Trim(),
                        PID_13 = data[13].Trim(),
                        PID_14 = data[14].Trim(),
                        PID_15 = data[15].Trim(),
                        PID_16 = data[16].Trim(),
                        PID_17 = data[17].Trim(),
                        PID_18 = data[18].Trim(),
                        PID_19 = data[19].Trim(),
                        PID_20 = data[20].Trim(),
                        PID_21 = data[21].Trim(),
                        PID_22 = data[22].Trim(),
                        PID_23 = data[23].Trim(),
                        PID_24 = data[24].Trim(),
                        PID_25 = data[25].Trim(),
                        PID_26 = data[26].Trim(),
                        PID_27 = data[27].Trim(),
                        PID_28 = data[28].Trim(),
                        PID_29 = data[29].Trim(),
                        PID_30 = data[30].Trim(),
                        PID_31 = data[31].Trim(),
                        PID_32 = data[32].Trim(),
                        PID_33 = data[33].Trim(),
                        PID_34 = data[34].Trim(),
                        PID_35 = data[35].Trim(),
                        PID_36 = data[36].Trim(),
                        PID_37 = data[37].Trim(),
                        PID_38 = data[38].Trim(),
                        PID_39 = data[39].Trim(),
                        PID_40 = data[40].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(pid, datafilename).Validate();
                    if (ValidateResult)
                    {
                        pid.Add(pid);
                    }
                }
                else
                    throw new Exception("PID ->[Total Required Column: 41][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientVisit(string[] data)
        {
            try
            {
               if(data.Length == 55)
                {
                    PV1 pV1 = new PV1()
                    {
                        PV1_1 = data[1].Trim(),
                        PV1_2 = data[2].Trim(),
                        PV1_3 = data[3].Trim(),
                        PV1_4 = data[4].Trim(),
                        PV1_5 = data[5].Trim(),
                        PV1_6 = data[6].Trim(),
                        PV1_7 = data[7].Trim(),
                        PV1_8 = data[8].Trim(),
                        PV1_9 = data[9].Trim(),
                        PV1_10 = data[10].Trim(),
                        PV1_11 = data[11].Trim(),
                        PV1_12 = data[12].Trim(),
                        PV1_13 = data[13].Trim(),
                        PV1_14 = data[14].Trim(),
                        PV1_15 = data[15].Trim(),
                        PV1_16 = data[16].Trim(),
                        PV1_17 = data[17].Trim(),
                        PV1_18 = data[18].Trim(),
                        PV1_19 = data[19].Trim(),
                        PV1_20 = data[20].Trim(),
                        PV1_21 = data[21].Trim(),
                        PV1_22 = data[22].Trim(),
                        PV1_23 = data[23].Trim(),
                        PV1_24 = data[24].Trim(),
                        PV1_25 = data[25].Trim(),
                        PV1_26 = data[26].Trim(),
                        PV1_27 = data[27].Trim(),
                        PV1_28 = data[28].Trim(),
                        PV1_29 = data[29].Trim(),
                        PV1_30 = data[30].Trim(),
                        PV1_31 = data[31].Trim(),
                        PV1_32 = data[32].Trim(),
                        PV1_33 = data[33].Trim(),
                        PV1_34 = data[34].Trim(),
                        PV1_35 = data[35].Trim(),
                        PV1_36 = data[36].Trim(),
                        PV1_37 = data[37].Trim(),
                        PV1_38 = data[38].Trim(),
                        PV1_39 = data[39].Trim(),
                        PV1_40 = data[40].Trim(),
                        PV1_41 = data[41].Trim(),
                        PV1_42 = data[42].Trim(),
                        PV1_43 = data[43].Trim(),
                        PV1_44 = data[44].Trim(),
                        PV1_45 = data[45].Trim(),
                        PV1_46 = data[46].Trim(),
                        PV1_47 = data[47].Trim(),
                        PV1_48 = data[48].Trim(),
                        PV1_49 = data[49].Trim(),
                        PV1_50 = data[50].Trim(),
                        PV1_51 = data[51].Trim(),
                        PV1_52 = data[52].Trim(),
                        PV1_53 = data[53].Trim(),
                        PV1_54 = data[54].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(pV1, datafilename).Validate();
                    if (ValidateResult)
                    {
                        pV1.Add(pV1);
                    }
                }
                else
                    throw new Exception("PV1 ->[Total Required Column: 55][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddCommondOrder(string[] data)
        {
            try
            {
                if(data.Length == 34)
                {
                    ORC oRC = new ORC()
                    {
                        ORC_1 = data[1].Trim(),
                        ORC_2 = data[2].Trim(),
                        ORC_3 = data[3].Trim(),
                        ORC_4 = data[4].Trim(),
                        ORC_5 = data[5].Trim(),
                        ORC_6 = data[6].Trim(),
                        ORC_7 = data[7].Trim(),
                        ORC_8 = data[8].Trim(),
                        ORC_9 = data[9].Trim(),
                        ORC_10 = data[10].Trim(),
                        ORC_11 = data[11].Trim(),
                        ORC_12 = data[12].Trim(),
                        ORC_13 = data[13].Trim(),
                        ORC_14 = data[14].Trim(),
                        ORC_15 = data[15].Trim(),
                        ORC_16 = data[16].Trim(),
                        ORC_17 = data[17].Trim(),
                        ORC_18 = data[18].Trim(),
                        ORC_19 = data[19].Trim(),
                        ORC_20 = data[20].Trim(),
                        ORC_21 = data[21].Trim(),
                        ORC_22 = data[22].Trim(),
                        ORC_23 = data[23].Trim(),
                        ORC_24 = data[24].Trim(),
                        ORC_25 = data[25].Trim(),
                        ORC_26 = data[26].Trim(),
                        ORC_27 = data[27].Trim(),
                        ORC_28 = data[28].Trim(),
                        ORC_29 = data[29].Trim(),
                        ORC_30 = data[30].Trim(),
                        ORC_31 = data[31].Trim(),
                        ORC_32 = data[32].Trim(),
                        ORC_33 = data[33].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData,
                    };
                    var ValidateResult = new HL7DataValidation(oRC, datafilename).Validate();
                    if (ValidateResult)
                    {
                        oRC.Add(oRC);
                    }
                }
                else
                    throw new Exception("ORC ->[Total Required Column: 34][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPatientAllergyInformation(string[] data)
        {
            try
            {
                if(data.Length == 7)
                {
                    AL1 aL1 = new AL1()
                    {
                        AL1_1 = data[1].Trim(),
                        AL1_2 = data[2].Trim(),
                        AL1_3 = data[3].Trim(),
                        AL1_4 = data[4].Trim(),
                        AL1_5 = data[5].Trim(),
                        AL1_6 = data[6].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(aL1, datafilename).Validate();
                    if (ValidateResult)
                    {
                        aL1.Add(aL1);
                    }
                }
                else
                    throw new Exception("AL1 ->[Total Required Column: 7][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPharmacyTreamentDispense(string[] data)
        {
            try
            {
                if(data.Length == 35)
                {
                    RXD rXD = new RXD()
                    {
                        RXD_1 = data[1].Trim(),
                        RXD_2 = data[2].Trim(),
                        RXD_3 = data[3].Trim(),
                        RXD_4 = data[4].Trim(),
                        RXD_5 = data[5].Trim(),
                        RXD_6 = data[6].Trim(),
                        RXD_7 = data[7].Trim(),
                        RXD_8 = data[8].Trim(),
                        RXD_9 = data[9].Trim(),
                        RXD_10 = data[10].Trim(),
                        RXD_11 = data[11].Trim(),
                        RXD_12 = data[12].Trim(),
                        RXD_13 = data[13].Trim(),
                        RXD_14 = data[14].Trim(),
                        RXD_15 = data[15].Trim(),
                        RXD_16 = data[16].Trim(),
                        RXD_17 = data[17].Trim(),
                        RXD_18 = data[18].Trim(),
                        RXD_19 = data[19].Trim(),
                        RXD_20 = data[20].Trim(),
                        RXD_21 = data[21].Trim(),
                        RXD_22 = data[22].Trim(),
                        RXD_23 = data[23].Trim(),
                        RXD_24 = data[24].Trim(),
                        RXD_25 = data[25].Trim(),
                        RXD_26 = data[26].Trim(),
                        RXD_27 = data[27].Trim(),
                        RXD_28 = data[28].Trim(),
                        RXD_29 = data[29].Trim(),
                        RXD_30 = data[30].Trim(),
                        RXD_31 = data[31].Trim(),
                        RXD_32 = data[32].Trim(),
                        RXD_33 = data[33].Trim(),
                        RXD_34 = data[34].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(rXD, datafilename).Validate();
                    if (ValidateResult)
                    {
                        rXD.Add(rXD);
                    }
                }
                else
                    throw new Exception("RXD ->[Total Required Column: 35][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddPharmacyTreatmentRoute(string[] data)
        {
            try
            {
                if(data.Length == 7)
                {
                    RXR rXR = new RXR()
                    {
                        RXR_1 = data[1].Trim(),
                        RXR_2 = data[2].Trim(),
                        RXR_3 = data[3].Trim(),
                        RXR_4 = data[4].Trim(),
                        RXR_5 = data[5].Trim(),
                        RXR_6 = data[6].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData,
                    };
                    var ValidateResult = new HL7DataValidation(rXR, datafilename).Validate();
                    if (ValidateResult)
                    {
                        rXR.Add(rXR);
                    }
                }
                else
                    throw new Exception("RXR ->[Total Required Column: 7][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddNotesAndComments(string[] data)
        {
            try
            {
                if(data.Length == 9)
                {
                    NTE nTE = new NTE()
                    {
                        NTE_1 = data[1].Trim(),
                        NTE_2 = data[2].Trim(),
                        NTE_3 = data[3].Trim(),
                        NTE_4 = data[4].Trim(),
                        NTE_5 = data[5].Trim(),
                        NTE_6 = data[6].Trim(),
                        NTE_7 = data[7].Trim(),
                        NTE_8 = data[8].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(nTE, datafilename).Validate();
                    if (ValidateResult)
                    {
                        nTE.Add(nTE);
                    }
                }
                else
                    throw new Exception("NTE ->[Total Required Column: 9][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddTimingAndQuantity(string[] data)
        {
            try
            {
                if(data.Length == 15)
                {
                    TQ1 tQ1 = new TQ1()
                    {
                        TQ1_1 = data[1].Trim(),
                        TQ1_2 = data[2].Trim(),
                        TQ1_3 = data[3].Trim(),
                        TQ1_4 = data[4].Trim(),
                        TQ1_5 = data[5].Trim(),
                        TQ1_6 = data[6].Trim(),
                        TQ1_7 = data[7].Trim(),
                        TQ1_8 = data[8].Trim(),
                        TQ1_9 = data[9].Trim(),
                        TQ1_10 = data[10].Trim(),
                        TQ1_11 = data[11].Trim(),
                        TQ1_12 = data[12].Trim(),
                        TQ1_13 = data[13].Trim(),
                        TQ1_14 = data[14].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(tQ1, datafilename).Validate();
                    if (ValidateResult)
                    {
                        tQ1.Add(tQ1);
                    }
                }
                else
                    throw new Exception("TQ1 ->[Total Required Column: 15][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddEventType(string[] data)
        {
            try
            {
                if (data.Length == 8)
                {
                    EVN eVN = new EVN()
                    {
                        EVN_1 = data[1].Trim(),
                        EVN_2 = data[2].Trim(),
                        EVN_3 = data[3].Trim(),
                        EVN_4 = data[4].Trim(),
                        EVN_5 = data[5].Trim(),
                        EVN_6 = data[6].Trim(),
                        EVN_7 = data[7].Trim(),
                        EVEN = EventCd,
                        SET_CODE = SetData
                    };
                    var ValidateResult = new HL7DataValidation(eVN, datafilename).Validate();
                    if (ValidateResult)
                    {
                        eVN.Add(eVN);
                    }
                }
                else
                    throw new Exception("EVN ->[Total Required Column: 8][Total Column: " + data.Length + "] -- ข้อมูลไม่ครบถ้วน --");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}