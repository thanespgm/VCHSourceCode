using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS
{
    internal class Thaneshopmiddle
    {
        //filed and properties
        protected string _prescriptionno;

        public string PrescriptonNo
        {
            get { return _prescriptionno; }
            set { _prescriptionno = value; }
        }

        protected int _seq;

        public int Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }

        protected int _seqmax;

        public int SeqMax
        {
            get { return _seqmax; }
            set { _seqmax = value; }
        }

        protected string _prescriptiondate;

        public string PrescriptionDate
        {
            get { return _prescriptiondate; }
            set { _prescriptiondate = value; }
        }

        protected string _hn;

        public string Hn
        {
            get { return _hn; }
            set { _hn = value; }
        }

        protected string _en;

        public string En
        {
            get { return _en; }
            set { _en = value; }
        }

        protected string _patientname;

        public string PatientName
        {
            get { return _patientname; }
            set { _patientname = value; }
        }

        protected decimal _sex;

        public decimal Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        protected DateTime _patientepisodedate;

        public DateTime PatientEpisodeDate
        {
            get { return _patientepisodedate; }
            set { _patientepisodedate = value; }
        }

        protected string _prioritycode;

        public string PriorityCode
        {
            get { return _prioritycode; }
            set { _prioritycode = value; }
        }

        protected string _prioritydesc;

        public string PriorityDesc
        {
            get { return _prioritydesc; }
            set { _prioritydesc = value; }
        }

        protected string _ordertargetdate;

        public string OrderTargetDate
        {
            get { return _ordertargetdate; }
            set { _ordertargetdate = value; }
        }

        protected string _ordertargettime;

        public string OrderTargetTime
        {
            get { return _ordertargettime; }
            set { _ordertargettime = value; }
        }

        protected string _ordercreatedate;

        public string OrderCreateDate
        {
            get { return _ordercreatedate; }
            set { _ordercreatedate = value; }
        }

        protected string _ordercreatetime;

        public string OrderCreateTime
        {
            get { return _ordercreatetime; }
            set { _ordercreatetime = value; }
        }

        protected string _orderitemcode;

        public string OrderItemCode
        {
            get { return _orderitemcode; }
            set { _orderitemcode = value; }
        }

        protected string _orderitemname;

        public string OrderItemName
        {
            get { return _orderitemname; }
            set { _orderitemname = value; }
        }

        protected decimal _orderqty;

        public decimal OrderQty
        {
            get { return _orderqty; }
            set { _orderqty = value; }
        }

        protected string _orderunitcode;

        public string OrderUnitCode
        {
            get { return _orderunitcode; }
            set { _orderunitcode = value; }
        }

        protected string _orderunitdesc;

        public string OrderUnitDesc
        {
            get { return _orderunitdesc; }
            set { _orderunitdesc = value; }
        }

        protected string _instructioncode;

        public string InstructionCode
        {
            get { return _instructioncode; }
            set { _instructioncode = value; }
        }

        protected string _instructiondesc;

        public string InstructionDesc
        {
            get { return _instructiondesc; }
            set { _instructiondesc = value; }
        }

        protected decimal _dosage;

        public decimal Dosage
        {
            get { return _dosage; }
            set { _dosage = value; }
        }

        protected string _dosageunit;

        public string DosageUnit
        {
            get { return _dosageunit; }
            set { _dosageunit = value; }
        }

        protected string _frequencycode;

        public string FrequencyCode
        {
            get { return _frequencycode; }
            set { _frequencycode = value; }
        }

        protected string _frequencydesc;

        public string FrequencyDesc
        {
            get { return _frequencydesc; }
            set { _frequencydesc = value; }
        }

        protected string _durationcode;

        public string DurationCode
        {
            get { return _durationcode; }
            set { _durationcode = value; }
        }

        protected string _durationdesc;

        public string DurationDesc
        {
            get { return _durationdesc; }
            set { _durationdesc = value; }
        }

        protected string _noteprocessing;

        public string NoteProcessing
        {
            get { return _noteprocessing; }
            set { _noteprocessing = value; }
        }

        protected string _fromlocationname;

        public string FromLocationName
        {
            get { return _fromlocationname; }
            set { _fromlocationname = value; }
        }

        protected string _userorderby;

        public string UserOrderBy
        {
            get { return _userorderby; }
            set { _userorderby = value; }
        }

        protected string _useracceptby;

        public string UserAcceptBy
        {
            get { return _useracceptby; }
            set { _useracceptby = value; }
        }

        protected string _orderacceptdate;

        public string OrderAcceptDate
        {
            get { return _orderacceptdate; }
            set { _orderacceptdate = value; }
        }

        protected string _orderaccepttime;

        public string OrderAcceptTime
        {
            get { return _orderaccepttime; }
            set { _orderaccepttime = value; }
        }

        protected string _orderacceptformip;

        public string OrderAcceptFromIP
        {
            get { return _orderacceptformip; }
            set { _orderacceptformip = value; }
        }

        protected string _patientdob;

        public string PatientDOB
        {
            get { return _patientdob; }
            set { _patientdob = value; }
        }

        protected string _itemlotcode;

        public string ItemLotCode
        {
            get { return _itemlotcode; }
            set { _itemlotcode = value; }
        }

        protected string _itemlotexpire;

        public string ItemLotExpire
        {
            get { return _itemlotexpire; }
            set { _itemlotexpire = value; }
        }

        protected string _doctorcode;

        public string DoctorCode
        {
            get { return _doctorcode; }
            set { _doctorcode = value; }
        }

        protected string _doctorname;

        public string DoctorName
        {
            get { return _doctorname; }
            set { _doctorname = value; }
        }

        protected string _wardcode;

        public string WardCode
        {
            get { return _wardcode; }
            set { _wardcode = value; }
        }

        protected string _warddesc;

        public string WardDesc
        {
            get { return _warddesc; }
            set { _warddesc = value; }
        }

        protected string _roomcode;

        public string RoomCode
        {
            get { return _roomcode; }
            set { _roomcode = value; }
        }

        protected string _roomdesc;

        public string RoomDesc
        {
            get { return _roomdesc; }
            set { _roomdesc = value; }
        }

        protected string _bedcode;

        public string BedCode
        {
            get { return _bedcode; }
            set { _bedcode = value; }
        }

        protected string _beddesc;

        public string BedDesc
        {
            get { return _beddesc; }
            set { _beddesc = value; }
        }

        protected string _pharmacylocationcode;

        public string PharmacyLocationCode
        {
            get { return _pharmacylocationcode; }
            set { _pharmacylocationcode = value; }
        }

        protected string _pharmacylocationdesc;

        public string PharmacyLocationDesc
        {
            get { return _pharmacylocationdesc; }
            set { _pharmacylocationdesc = value; }
        }

        protected string _pharmacyitemcode;

        public string PharmacyItemCode
        {
            get { return _pharmacyitemcode; }
            set { _pharmacyitemcode = value; }
        }

        protected string _pharmacyitemdesc;

        public string PharmacyItemDesc
        {
            get { return _pharmacyitemdesc; }
            set { _pharmacyitemdesc = value; }
        }

        protected string _freetext1;

        public string Freetext1
        {
            get { return _freetext1; }
            set { _freetext1 = value; }
        }

        protected string _freetext2;

        public string Freetext2
        {
            get { return _freetext2; }
            set { _freetext2 = value; }
        }

        protected string _itemidentify;

        public string ItemIdentify
        {
            get { return _itemidentify; }
            set { _itemidentify = value; }
        }

        protected decimal _tomachineno;

        public decimal ToMachineNo
        {
            get { return _tomachineno; }
            set { _tomachineno = value; }
        }

        protected decimal _dispensestatus;

        public decimal DispenseStatus
        {
            get { return _dispensestatus; }
            set { _dispensestatus = value; }
        }

        protected decimal _status;

        public decimal Status
        {
            get { return _status; }
            set { _status = value; }
        }

        protected DateTime _lastmodified;

        public DateTime LastModified
        {
            get { return _lastmodified; }
            set { _lastmodified = value; }
        }

        protected decimal _PRN;

        public decimal PRN
        {
            get { return _PRN; }
            set { _PRN = value; }
        }

        protected string _frequencyTime;

        public string FrequencyTime
        {
            get { return _frequencyTime; }
            set { _frequencyTime = value; }
        }

        protected decimal _language;

        public decimal Language
        {
            get { return Language; }
            set { _language = value; }
        }

        protected string _dosagedispense;

        public string DosageDispense
        {
            get { return _dosagedispense; }
            set { _dosagedispense = value; }
        }

        protected string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        protected int _statusCh;

        public int StatusCh
        {
            get { return _statusCh; }
            set { _statusCh = value; }
        }

        protected string _freetext3;

        public string Freetext3
        {
            get { return _freetext3; }
            set { _freetext3 = value; }
        }

        protected string _freetext4;

        public string Freetext4
        {
            get { return _freetext4; }
            set { _freetext4 = value; }
        }

        protected int _heighAlertDrug;

        public int HeighAlertDrug
        {
            get { return _heighAlertDrug; }
            set { _heighAlertDrug = value; }
        }

        protected string _referenceCode;

        public string ReferenceCode
        {
            get { return _referenceCode; }
            set { _referenceCode = value; }
        }

        internal System_logfile Logs { get => logs; set => logs = value; }

        private System_logfile logs = new System_logfile();

        //Constructor And Adstract Calss
        public Thaneshopmiddle()
        {
        }

        //Query Command thaneshop middle table for Display DataGrid View Full Detial Form
        public DataSet GetDispalyDataGridViewFullDetail(string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";
            SQL += "dbo.tb_thaneshosp_middle.f_en,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname,";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";
            SQL += "dbo.tb_thaneshosp_middle.f_status,";
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";
            SQL += "dbo.tb_thaneshosp_middle.f_language,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug,";
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            if ((condition != "") && (condition != null))
            {
                SQL += "WHERE ";
                SQL += "(dbo.tb_thaneshosp_middle.f_prescriptionno LIKE '%" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_hn LIKE '%" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_patientname LIKE '%" + condition + "%') ";
            }
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_lastmodified ASC ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table
        public DataSet GetDataThanesMiddle(string p_prescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";                      //1
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";                                 //2
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";                              //3
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";                    //4
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";                                  //5
            SQL += "dbo.tb_thaneshosp_middle.f_en,";                                  //6
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";                         //7
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";                                 //8
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate,";                  //9
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";                        //10
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";                        //11
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";                     //12
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";                     //13
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";                     //14
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime,";                     //15
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";                       //16
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";                       //17
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";                            //18
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";                       //19
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";                       //20
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";                     //21
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";                     //22
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";                              //23
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";                          //24
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";                       //25
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";                       //26
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";                        //27
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc,";                        //28
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";                      //29
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname,";                    //30
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";                         //31
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";                        //32
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";                     //33
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime,";                     //34
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";                   //35
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";                          //36
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode,";                         //37
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";                       //38
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";                          //39
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";                          //40
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";                            //41
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";                            //42
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";                            //43
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";                            //44
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";                             //45
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc,";                             //46
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";                //47
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";                //48
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //49
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //50
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //51
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //52
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //53
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //54
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //55
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //56
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //57
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //58
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //59
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //60
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh,";                            //61
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug,";                      //64
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode ";                       //65
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_seq ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_prescriptionno", p_prescriptionno);
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table for Display DataGrid View
        public DataSet GetDispalyDataGridView(string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq, ";
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax, ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn, ";
            SQL += "dbo.tb_thaneshosp_middle.f_en, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname, ";
            SQL += "FORMAT(dbo.tb_thaneshosp_middle.f_lastmodified,'HH:mm:ss.fff')AS f_lastmodified ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            if ((condition != "") && (condition != null))
            {
                SQL += "WHERE ";
                SQL += "(dbo.tb_thaneshosp_middle.f_prescriptionno LIKE '%" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_hn LIKE '%" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_patientname LIKE '%" + condition + "%') ";
            }
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_lastmodified ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table for Display DataGrid View
        public DataSet GetDispalyPrescriptionDataGridView(string condition, string statustype)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname, ";
            SQL += "MIN(dbo.tb_thaneshosp_middle.f_status)AS f_status ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            switch (statustype)
            {
                case "all":
                    SQL += "dbo.tb_thaneshosp_middle.f_status IN('0','1','2') ";
                    break;

                case "wait":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 0 ";
                    break;

                case "complete":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 1 ";
                    break;

                case "cancel":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 2 ";
                    break;
            }
            if ((condition != "") && (condition != null))
            {
                SQL += "AND ";
                SQL += "(dbo.tb_thaneshosp_middle.f_prescriptionno LIKE '" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_hn LIKE '" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_patientname LIKE '%" + condition + "%') ";
            }
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_prescriptionno ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table for Display DataGrid View Detail
        public DataSet GetDispalyPrescriptionDataGridViewSelected(ArrayList prescriptionno, string statustype)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_status, ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            switch (statustype)
            {
                case "all":
                    SQL += "dbo.tb_thaneshosp_middle.f_status IN('0','1','2') ";
                    break;

                case "wait":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 0 ";
                    break;

                case "complete":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 1 ";
                    break;

                case "cancel":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 2 ";
                    break;
            }
            if (prescriptionno.Count == 1)
            {
                SQL += "AND ";
                foreach (Object prescriptionno_In in prescriptionno)
                    SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = '" + prescriptionno_In + "' ";
            }
            else if ((prescriptionno.Count != 0) && (prescriptionno != null))
            {
                string presno = "";
                int i = 0;
                SQL += "AND ";
                foreach (Object prescriptionno_In in prescriptionno)
                {
                    i++;
                    if (prescriptionno.Count != i)
                    {
                        presno += "'" + prescriptionno_In + "',";
                    }
                    else
                    {
                        presno += "'" + prescriptionno_In + "'";
                    }
                }
                SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno IN (" + presno + ")";
            }
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_prescriptionno, dbo.tb_thaneshosp_middle.f_seq ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table Group By Prescriptionno
        public DataSet GetDataThanesMiddleGroupByPres()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT TOP 1 ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_status =0 ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno ";
            SQL += "ORDER BY MAX(dbo.tb_thaneshosp_middle.f_lastmodified) ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Update the data that has been generated by the data file, followed by the prescription number.
        public bool UpdateDataGenerateByPres(string p_prescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_status =@f_status ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_status", _status);
                cmd.Parameters.AddWithValue("@f_prescriptionno", p_prescriptionno);
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Find the number of prescriptions that have not yet created a data file.
        //Retrun Type int
        public Object ItemsDataPrescNotCreate()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.tb_thaneshosp_middle.f_prescriptionno)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_status =0 ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items prescription Group By prescripton number
        //Retrun Type Dataset
        public Object ItemsAllDataPrescription()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(DISTINCT(dbo.tb_thaneshosp_middle.f_prescriptionno))as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            //SQL += "GROUP BY ";
            //SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items patient Group By Hn
        //Retrun Type Dataset
        public Object ItemsAllDataPatient()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(DISTINCT(dbo.tb_thaneshosp_middle.f_hn))as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            //SQL += "GROUP BY ";
            //SQL += "dbo.tb_thaneshosp_middle.f_hn ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items all table
        //Retrun Type Dataset
        public Object ItemsAllDataFull()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(*)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items all table
        //Retrun Type Dataset
        public Object ItemsAllDataFullbyReferrenceCode(string refer)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(*)as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn =@f_hn ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_hn", refer);
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command Order for a prescription amount of time in a day.
        //Retrun Type Dataset
        public DataSet PrescriptionAmountOfTime()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "SUBSTRING(CONVERT(VARCHAR(8),dbo.tb_thaneshosp_middle.f_lastmodified,108), 1, 2)As timesInsert, ";
            SQL += "COUNT(*)as itemsPres ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "SUBSTRING(CONVERT(VARCHAR(10),dbo.tb_thaneshosp_middle.f_lastmodified,112),1,8) = SUBSTRING(CONVERT(VARCHAR(10),GETDATE(),112),1,8) ";
            SQL += "GROUP BY ";
            SQL += "SUBSTRING(CONVERT(VARCHAR(8),dbo.tb_thaneshosp_middle.f_lastmodified,108), 1, 2) ";
            SQL += "ORDER BY ";
            SQL += "SUBSTRING(CONVERT(VARCHAR(8),dbo.tb_thaneshosp_middle.f_lastmodified,108), 1, 2) ASC ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query command Order for priorty amount of time in a day.
        //Retrun Type Dataset
        public DataSet PriortyAmountOfRealtime()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.tb_thaneshosp_middle.f_prescriptionno) * 100 / (SELECT COUNT(dbo.tb_thaneshosp_middle.f_prescriptionno) FROM dbo.tb_thaneshosp_middle)As Total, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc As Priority ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query command Order for drugtype amount of time in a day.
        //Retrun Type Dataset
        public DataSet DrugTypeAmountOfRealtime()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.tb_thaneshosp_middle.f_prescriptionno) * 100 / (SELECT COUNT(dbo.tb_thaneshosp_middle.f_prescriptionno) FROM dbo.tb_thaneshosp_middle)As Total, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode As UnitCode ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Query command Order for Machine Workload amount of time in a day.
        //Retrun Type Dataset
        public DataSet MachineWorkLoadAmountOfRealtime()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CASE ";
            SQL += "WHEN dbo.tb_thaneshosp_middle.f_tomachineno = 0 THEN 'จัดยาจากห้องยา'";
            SQL += "WHEN dbo.tb_thaneshosp_middle.f_tomachineno = 1 THEN 'จัดโดย EV-54 ตึกใหม่'";
            SQL += "ELSE 'จัดโดย EV-54 ตึกเก่า'";
            SQL += "END AS MachineLoacation,";
            SQL += "COUNT ( dbo.tb_thaneshosp_middle.f_tomachineno )AS ItemsPharmacy ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        //Check Charater Max length database.
        //Return Type boolean
        public int CHMLength(string column_name)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CHARACTER_MAXIMUM_LENGTH ";
            SQL += "FROM ";
            SQL += "INFORMATION_SCHEMA.COLUMNS ";
            SQL += "WHERE ";
            SQL += "TABLE_NAME ='tb_thaneshosp_middle' ";
            SQL += "AND ";
            SQL += "COLUMN_NAME = @COLUMN_NAME ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@COLUMN_NAME", column_name);
                return Convert.ToInt32(conn.ExecuteScalarSQL(cmd));
            }
        }

        //Check data before importing data into database.
        //Return Type boolean

        public bool CheckDataBeforeInSert(string filename)
        {
            string str = "";
            if (Variable.errorStrLog != "")
            {
                str = Variable.errorStrLog;
            }
            if (_prescriptionno.Length > CHMLength("f_prescriptionno"))  //
            {
                str += " column : f_prescriptionno     data : " + _prescriptionno + "  character_maximum_length : " + CHMLength("f_prescriptionno") + "  data_length : " + _prescriptionno.Length + "\r\n";
            }
            if (_prescriptiondate.Length > CHMLength("f_prescriptiondate"))  //
            {
                str += " column : f_prescriptiondate     data : " + _prescriptiondate + "  character_maximum_length : " + CHMLength("f_prescriptiondate") + "  data_length : " + _prescriptiondate.Length + "\r\n";
            }
            if (_hn.Length > CHMLength("f_hn"))   //
            {
                str += " column : f_hn     data : " + _hn + "  character_maximum_length : " + CHMLength("f_hn") + "  data_length : " + _hn.Length + "\r\n";
            }
            if (_en.Length > CHMLength("f_en")) //
            {
                str += " column : f_en     data : " + _en + "  character_maximum_length : " + CHMLength("f_en") + "  data_length : " + _en.Length + "\r\n";
            }
            if (_patientname.Length > CHMLength("f_patientname"))  //
            {
                str += " column : f_patientname     data : " + _patientname + "  character_maximum_length : " + CHMLength("f_patientname") + "  data_length : " + _patientname.Length + "\r\n";
            }
            if (_prioritycode.Length > CHMLength("f_prioritycode"))  //
            {
                str += " column : f_prioritycode     data : " + _prioritycode + "  character_maximum_length : " + CHMLength("f_prioritycode") + "  data_length : " + _prioritycode.Length + "\r\n";
            }
            if (_prioritydesc.Length > CHMLength("f_prioritydesc")) //
            {
                str += " column : f_prioritydesc     data : " + _prioritydesc + "  character_maximum_length : " + CHMLength("f_prioritydesc") + "  data_length : " + _prioritydesc.Length + "\r\n";
            }
            if (_ordertargetdate.Length > CHMLength("f_ordertargetdate"))  //
            {
                str += " column : f_ordertargetdate     data : " + _ordertargetdate + "  character_maximum_length : " + CHMLength("f_ordertargetdate") + "  data_length : " + _ordertargetdate.Length + "\r\n";
            }
            if (_ordertargettime.Length > CHMLength("f_ordertargettime")) //
            {
                str += " column : f_ordertargettime     data : " + _ordertargettime + "  character_maximum_length : " + CHMLength("f_ordertargettime") + "  data_length : " + _ordertargettime.Length + "\r\n";
            }
            if (_ordercreatedate.Length > CHMLength("f_ordercreatedate"))   //
            {
                str += " column : f_ordercreatedate     data : " + _ordercreatedate + "  character_maximum_length : " + CHMLength("f_ordercreatedate") + "  data_length : " + _ordercreatedate.Length + "\r\n";
            }
            if (_ordercreatetime.Length > CHMLength("f_ordercreatetime")) //
            {
                str += " column : f_ordercreatetime     data : " + _ordercreatetime + "  character_maximum_length : " + CHMLength("f_ordercreatetime") + "  data_length : " + _ordercreatetime.Length + "\r\n";
            }
            if (_orderitemcode.Length > CHMLength("f_orderitemcode"))  //
            {
                str += " column : f_orderitemcode     data : " + _orderitemcode + "  character_maximum_length : " + CHMLength("f_orderitemcode") + "  data_length : " + _orderitemcode.Length + "\r\n";
            }
            if (_orderitemname.Length > CHMLength("f_orderitemname"))  //
            {
                str += " column : f_orderitemname     data : " + _orderitemname + "  character_maximum_length : " + CHMLength("f_orderitemname") + "  data_length : " + _orderitemname.Length + "\r\n";
            }
            if (_orderunitcode.Length > CHMLength("f_orderunitcode"))  //
            {
                str += " column : f_orderunitcode     data : " + _orderunitcode + "  character_maximum_length : " + CHMLength("f_orderunitcode") + "  data_length : " + _orderunitcode.Length + "\r\n";
            }
            if (_orderunitdesc.Length > CHMLength("f_orderunitdesc"))   //
            {
                str += " column : f_orderunitdesc     data : " + _orderunitdesc + "  character_maximum_length : " + CHMLength("f_orderunitdesc") + "  data_length : " + _orderunitdesc.Length + "\r\n";
            }
            if (_instructioncode.Length > CHMLength("f_instructioncode"))   //
            {
                str += " column : f_instructioncode     data : " + _instructioncode + "  character_maximum_length : " + CHMLength("f_instructioncode") + "  data_length : " + _instructioncode.Length + "\r\n";
            }
            if (_instructiondesc.Length > CHMLength("f_instructiondesc")) //
            {
                str += " column : f_instructiondesc     data : " + _instructiondesc + "  character_maximum_length : " + CHMLength("f_instructiondesc") + "  data_length : " + _instructiondesc.Length + "\r\n";
            }
            if (_dosageunit.Length > CHMLength("f_dosageunit")) //
            {
                str += " column : f_dosageunit     data : " + _dosageunit + "  character_maximum_length : " + CHMLength("f_dosageunit") + "  data_length : " + _dosageunit.Length + "\r\n";
            }
            if (_frequencycode.Length > CHMLength("f_frequencycode"))   //
            {
                str += " column : f_frequencycode     data : " + _frequencycode + "  character_maximum_length : " + CHMLength("f_frequencycode") + "  data_length : " + _frequencycode.Length + "\r\n";
            }
            if (_frequencydesc.Length > CHMLength("f_frequencydesc"))   //
            {
                str += " column : f_frequencydesc     data : " + _frequencydesc + "  character_maximum_length : " + CHMLength("f_frequencydesc") + "  data_length : " + _frequencydesc.Length + "\r\n";
            }
            if (_durationcode.Length > CHMLength("f_durationcode"))    //
            {
                str += " column : f_durationcode     data : " + _durationcode + "  character_maximum_length : " + CHMLength("f_durationcode") + "  data_length : " + _durationcode.Length + "\r\n";
            }
            if (_durationdesc.Length > CHMLength("f_durationdesc"))  //
            {
                str += " column : f_durationdesc     data : " + _durationdesc + "  character_maximum_length : " + CHMLength("f_durationdesc") + "  data_length : " + _durationdesc.Length + "\r\n";
            }
            if (_noteprocessing.Length > CHMLength("f_noteprocessing")) //
            {
                str += " column : f_noteprocessing     data : " + _noteprocessing + "  character_maximum_length : " + CHMLength("f_noteprocessing") + "  data_length : " + _noteprocessing.Length + "\r\n";
            }
            if (_fromlocationname.Length > CHMLength("f_fromlocationname"))   //
            {
                str += " column : f_fromlocationname     data : " + _fromlocationname + "  character_maximum_length : " + CHMLength("f_fromlocationname") + "  data_length : " + _fromlocationname.Length + "\r\n";
            }
            if (_userorderby.Length > CHMLength("f_userorderby"))   //
            {
                str += " column : f_userorderby     data : " + _userorderby + "  character_maximum_length : " + CHMLength("f_userorderby") + "  data_length : " + _userorderby.Length + "\r\n";
            }
            if (_useracceptby.Length > CHMLength("f_useracceptby"))   //
            {
                str += " column : f_useracceptby     data : " + _useracceptby + "  character_maximum_length : " + CHMLength("f_useracceptby") + "  data_length : " + _useracceptby.Length + "\r\n";
            }
            if (_orderacceptdate.Length > CHMLength("f_orderacceptdate"))  //
            {
                str += " column : f_orderacceptdate     data : " + _orderacceptdate + "  character_maximum_length : " + CHMLength("f_orderacceptdate") + "  data_length : " + _orderacceptdate.Length + "\r\n";
            }
            if (_orderaccepttime.Length > CHMLength("f_orderaccepttime")) //
            {
                str += " column : f_orderaccepttime     data : " + _orderaccepttime + "  character_maximum_length : " + CHMLength("f_orderaccepttime") + "  data_length : " + _orderaccepttime.Length + "\r\n";
            }
            if (_orderacceptformip.Length > CHMLength("f_orderacceptfromip"))  //
            {
                str += " column : f_orderacceptfromip     data : " + _orderacceptformip + "  character_maximum_length : " + CHMLength("f_orderacceptfromip") + "  data_length : " + _orderacceptformip.Length + "\r\n";
            }
            if (_patientdob.Length > CHMLength("f_patientdob"))  //
            {
                str += " column : f_patientdob     data : " + _patientdob + "  character_maximum_length : " + CHMLength("f_patientdob") + "  data_length : " + _patientdob.Length + "\r\n";
            }
            if (_itemlotcode.Length > CHMLength("f_itemlotcode")) //
            {
                str += " column : f_itemlotcode     data : " + _itemlotcode + "  character_maximum_length : " + CHMLength("f_itemlotcode") + "  data_length : " + _itemlotcode.Length + "\r\n";
            }
            if (_itemlotexpire.Length > CHMLength("f_itemlotexpire")) //
            {
                str += " column : f_itemlotexpire     data : " + _itemlotexpire + "  character_maximum_length : " + CHMLength("f_itemlotexpire") + "  data_length : " + _itemlotexpire.Length + "\r\n";
            }
            if (_doctorcode.Length > CHMLength("f_doctorcode"))  //
            {
                str += " column : f_doctorcode     data : " + _doctorcode + "  character_maximum_length : " + CHMLength("f_doctorcode") + "  data_length : " + _doctorcode.Length + "\r\n";
            }
            if (_doctorname.Length > CHMLength("f_doctorname")) //
            {
                str += " column : f_doctorname     data : " + _doctorname + "  character_maximum_length : " + CHMLength("f_doctorname") + "  data_length : " + _doctorname.Length + "\r\n";
            }
            if (_wardcode.Length > CHMLength("f_wardcode")) //
            {
                str += " column : f_wardcode     data : " + _wardcode + "  character_maximum_length : " + CHMLength("f_wardcode") + "  data_length : " + _wardcode.Length + "\r\n";
            }
            if (_warddesc.Length > CHMLength("f_warddesc"))  //
            {
                str += " column : f_warddesc     data : " + _warddesc + "  character_maximum_length : " + CHMLength("f_warddesc") + "  data_length : " + _warddesc.Length + "\r\n";
            }
            if (_roomcode.Length > CHMLength("f_roomcode")) //
            {
                str += " column : f_roomcode     data : " + _roomcode + "  character_maximum_length : " + CHMLength("f_roomcode") + "  data_length : " + _roomcode.Length + "\r\n";
            }
            if (_roomdesc.Length > CHMLength("f_roomdesc")) //
            {
                str += " column : f_roomdesc     data : " + _roomdesc + "  character_maximum_length : " + CHMLength("f_roomdesc") + "  data_length : " + _roomdesc.Length + "\r\n";
            }
            if (_bedcode.Length > CHMLength("f_bedcode"))   //
            {
                str += " column : f_bedcode     data : " + _bedcode + "  character_maximum_length : " + CHMLength("f_bedcode") + "  data_length : " + _bedcode.Length + "\r\n";
            }
            if (_beddesc.Length > CHMLength("f_beddesc"))    //
            {
                str += " column : f_beddesc     data : " + _beddesc + "  character_maximum_length : " + CHMLength("f_beddesc") + "  data_length : " + _beddesc.Length + "\r\n";
            }
            if (_pharmacylocationcode.Length > CHMLength("f_pharmacylocationcode"))  //
            {
                str += " column : f_pharmacylocationcode     data : " + _pharmacylocationcode + "  character_maximum_length : " + CHMLength("f_pharmacylocationcode") + "  data_length : " + _pharmacylocationcode.Length + "\r\n";
            }
            if (_pharmacylocationdesc.Length > CHMLength("f_pharmacylocationdesc"))  //
            {
                str += " column : f_pharmacylocationdesc     data : " + _pharmacylocationdesc + "  character_maximum_length : " + CHMLength("f_pharmacylocationdesc") + "  data_length : " + _pharmacylocationdesc.Length + "\r\n";
            }
            if (_freetext1.Length > CHMLength("f_freetext1"))    //
            {
                str += " column : f_freetext1     data : " + _freetext1 + "  character_maximum_length : " + CHMLength("f_freetext1") + "  data_length : " + _freetext1.Length + "\r\n";
            }
            if (_freetext2.Length > CHMLength("f_freetext2"))    //
            {
                str += " column : f_freetext2     data : " + _freetext2 + "  character_maximum_length : " + CHMLength("f_freetext2") + "  data_length : " + _freetext2.Length + "\r\n";
            }
            if (_itemidentify.Length > CHMLength("f_itemidentify"))   //
            {
                str += " column : f_itemidentify     data : " + _itemidentify + "  character_maximum_length : " + CHMLength("f_itemidentify") + "  data_length : " + _itemidentify.Length + "\r\n";
            }
            if (_frequencyTime.Length > CHMLength("f_frequencyTime")) //
            {
                str += " column : f_frequencyTime     data : " + _frequencyTime + "  character_maximum_length : " + CHMLength("f_frequencyTime") + "  data_length : " + _frequencyTime.Length + "\r\n";
            }
            if (_dosagedispense.Length > CHMLength("f_dosagedispense")) //
            {
                str += " column : f_dosagedispense     data : " + _dosagedispense + "  character_maximum_length : " + CHMLength("f_dosagedispense") + "  data_length : " + _dosagedispense.Length + "\r\n";
            }
            if (_comment.Length > CHMLength("f_comment")) //
            {
                str += " column : f_comment     data : " + _comment + "  character_maximum_length : " + CHMLength("f_comment") + "  data_length : " + _comment.Length + "\r\n";
            }
            if (_freetext3.Length > CHMLength("f_freetext3"))   //
            {
                str += " column : f_freetext3     data : " + _freetext3 + "  character_maximum_length : " + CHMLength("f_freetext3") + "  data_length : " + _freetext3.Length + "\r\n";
            }
            if (_freetext4.Length > CHMLength("f_freetext4"))  //
            {
                str += " column : f_freetext4     data : " + _freetext4 + "  character_maximum_length : " + CHMLength("f_freetext4") + "  data_length : " + _freetext4.Length + "\r\n";
            }
            if (_referenceCode.Length > CHMLength("f_referenceCode")) //
            {
                str += " column : f_referenceCode     data : " + _referenceCode + "  character_maximum_length : " + CHMLength("f_referenceCode") + "  data_length : " + _referenceCode.Length + "\r\n";
            }

            bool result;
            if (str != "")
            {
                Logs.Writelogcheck(str, " Check_Data_Before_[ " + filename + " ]");
                Variable.errorStrLog = "";
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        //Query command for adding patient prescriptions data.
        //Return Type boolean
        public bool InsertDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle (";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";
            SQL += "dbo.tb_thaneshosp_middle.f_en,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname,";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";
            SQL += "dbo.tb_thaneshosp_middle.f_status,";
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";
            SQL += "dbo.tb_thaneshosp_middle.f_language,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";
            SQL += "dbo.tb_thaneshosp_middle.f_comment, ";
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug,";
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode) ";
            SQL += "VALUES( ";
            SQL += "@f_prescriptionno,";
            SQL += "@f_seq,";
            SQL += "@f_seqmax,";
            SQL += "@f_prescriptiondate,";
            SQL += "@f_hn,";
            SQL += "@f_en,";
            SQL += "@f_patientname,";
            SQL += "@f_sex,";
            SQL += "GETDATE(),";
            SQL += "@f_prioritycode,";
            SQL += "@f_prioritydesc,";
            SQL += "@f_ordertargetdate,";
            SQL += "@f_ordertargettime,";
            SQL += "@f_ordercreatedate,";
            SQL += "@f_ordercreatetime,";
            SQL += "@f_orderitemcode,";
            SQL += "@f_orderitemname,";
            SQL += "@f_orderqty,";
            SQL += "@f_orderunitcode,";
            SQL += "@f_orderunitdesc,";
            SQL += "@f_instructioncode,";
            SQL += "@f_instructiondesc,";
            SQL += "@f_dosage,";
            SQL += "@f_dosageunit,";
            SQL += "@f_frequencycode,";
            SQL += "@f_frequencydesc,";
            SQL += "@f_durationcode,";
            SQL += "@f_durationdesc,";
            SQL += "@f_noteprocessing,";
            SQL += "@f_fromlocationname,";
            SQL += "@f_userorderby,";
            SQL += "@f_useracceptby,";
            SQL += "@f_orderacceptdate,";
            SQL += "@f_orderaccepttime,";
            SQL += "@f_orderacceptfromip,";
            SQL += "@f_patientdob,";
            SQL += "@f_itemlotcode,";
            SQL += "@f_itemlotexpire,";
            SQL += "@f_doctorcode,";
            SQL += "@f_doctorname,";
            SQL += "@f_wardcode,";
            SQL += "@f_warddesc,";
            SQL += "@f_roomcode,";
            SQL += "@f_roomdesc,";
            SQL += "@f_bedcode,";
            SQL += "@f_beddesc,";
            SQL += "@f_pharmacylocationcode,";
            SQL += "@f_pharmacylocationdesc,";
            SQL += "@f_freetext1,";
            SQL += "@f_freetext2,";
            SQL += "@f_itemidentify,";
            SQL += "@f_tomachineno,";
            SQL += "@f_dispensestatus,";
            SQL += "@f_status,";
            SQL += "GETDATE(),";
            SQL += "@f_PRN,";
            SQL += "@f_frequencyTime,";
            SQL += "@f_language,";
            SQL += "@f_dosagedispense,";
            SQL += "@f_comment,";
            SQL += "@f_statusCh,";
            SQL += "@f_freetext3,";
            SQL += "@f_freetext4,";
            SQL += "@f_heighAlertDrug,";
            SQL += "@f_referenceCode) ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_seq", _seq));
                cmd.Parameters.Add(new SqlParameter("@f_seqmax", _seqmax));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptiondate", _prescriptiondate));
                cmd.Parameters.Add(new SqlParameter("@f_hn", _hn));
                cmd.Parameters.Add(new SqlParameter("@f_en", _en));
                cmd.Parameters.Add(new SqlParameter("@f_patientname", _patientname));
                cmd.Parameters.Add(new SqlParameter("@f_sex", _sex));
                //cmd.Parameters.Add(new SqlParameter("@f_patientepisodedate", _patientepisodedate));
                cmd.Parameters.Add(new SqlParameter("@f_prioritycode", _prioritycode));
                cmd.Parameters.Add(new SqlParameter("@f_prioritydesc", _prioritydesc));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargetdate", _ordertargetdate));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargettime", _ordertargettime));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatedate", _ordercreatedate));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatetime", _ordercreatetime));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", _orderitemcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemname", _orderitemname));
                cmd.Parameters.Add(new SqlParameter("@f_orderqty", _orderqty));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitcode", _orderunitcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitdesc", _orderunitdesc));
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", _instructioncode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", _instructiondesc));
                cmd.Parameters.Add(new SqlParameter("@f_dosage", _dosage));
                cmd.Parameters.Add(new SqlParameter("@f_dosageunit", _dosageunit));
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", _frequencycode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", _frequencydesc));
                cmd.Parameters.Add(new SqlParameter("@f_durationcode", _durationcode));
                cmd.Parameters.Add(new SqlParameter("@f_durationdesc", _durationdesc));                        //เกิน  10
                cmd.Parameters.Add(new SqlParameter("@f_noteprocessing", _noteprocessing));
                cmd.Parameters.Add(new SqlParameter("@f_fromlocationname", _fromlocationname));
                cmd.Parameters.Add(new SqlParameter("@f_userorderby", _userorderby));
                cmd.Parameters.Add(new SqlParameter("@f_useracceptby", _useracceptby));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptdate", _orderacceptdate));
                cmd.Parameters.Add(new SqlParameter("@f_orderaccepttime", _orderaccepttime));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptfromip", _orderacceptformip));
                cmd.Parameters.Add(new SqlParameter("@f_patientdob", _patientdob));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotcode", _itemlotcode));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotexpire", _itemlotexpire));
                cmd.Parameters.Add(new SqlParameter("@f_doctorcode", _doctorcode));
                cmd.Parameters.Add(new SqlParameter("@f_doctorname", _doctorname));
                cmd.Parameters.Add(new SqlParameter("@f_wardcode", _wardcode));
                cmd.Parameters.Add(new SqlParameter("@f_warddesc", _warddesc));
                cmd.Parameters.Add(new SqlParameter("@f_roomcode", _roomcode));
                cmd.Parameters.Add(new SqlParameter("@f_roomdesc", _roomdesc));
                cmd.Parameters.Add(new SqlParameter("@f_bedcode", _bedcode));
                cmd.Parameters.Add(new SqlParameter("@f_beddesc", _beddesc));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationcode", _pharmacylocationcode));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationdesc", _pharmacylocationdesc));
                cmd.Parameters.Add(new SqlParameter("@f_freetext1", _freetext1));
                cmd.Parameters.Add(new SqlParameter("@f_freetext2", _freetext2));
                cmd.Parameters.Add(new SqlParameter("@f_itemidentify", _itemidentify));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", _tomachineno));
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", _dispensestatus));
                cmd.Parameters.Add(new SqlParameter("@f_status", _status));
                cmd.Parameters.Add(new SqlParameter("@f_PRN", _PRN));
                cmd.Parameters.Add(new SqlParameter("@f_frequencyTime", _frequencyTime));
                cmd.Parameters.Add(new SqlParameter("@f_language", _language));
                cmd.Parameters.Add(new SqlParameter("@f_dosagedispense", _dosagedispense));
                cmd.Parameters.Add(new SqlParameter("@f_comment", _comment));
                cmd.Parameters.Add(new SqlParameter("@f_statusCh", _statusCh));
                cmd.Parameters.Add(new SqlParameter("@f_freetext3", _freetext3));
                cmd.Parameters.Add(new SqlParameter("@f_freetext4", _freetext4));
                cmd.Parameters.Add(new SqlParameter("@f_heighAlertDrug", _heighAlertDrug));
                cmd.Parameters.Add(new SqlParameter("@f_referenceCode", _referenceCode));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Editting patient prescriptions data.
        //Return Type boolean
        public bool UpDateDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno,";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq,";
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax =@f_seqmax,";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate =@f_prescriptiondate,";
            SQL += "dbo.tb_thaneshosp_middle.f_hn =@f_hn,";
            SQL += "dbo.tb_thaneshosp_middle.f_en =@f_en,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname =@f_patientname,";
            SQL += "dbo.tb_thaneshosp_middle.f_sex =@f_sex,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate =@f_patientepisodedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode =@f_prioritycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc =@f_prioritydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate =@f_ordertargetdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime =@f_ordertargettime,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate =@f_ordercreatedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime =@f_ordercreatetime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode =@f_orderitemcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname =@f_orderitemname,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty =@f_orderqty,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode =@f_orderunitcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc =@f_orderunitdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode =@f_instructioncode,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc =@f_instructiondesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosage =@f_dosage,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit =@f_dosageunit,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode =@f_frequencycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc =@f_frequencydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode =@f_durationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc =@f_durationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing =@f_noteprocessing,";
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname =@f_fromlocationname,";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby =@f_userorderby,";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby =@f_useracceptby,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate =@f_orderacceptdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime =@f_orderaccepttime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip =@f_orderacceptfromip,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob =@f_patientdob,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode =@f_itemlotcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire =@f_itemlotexpire,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode =@f_doctorcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname =@f_doctorname,";
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode =@f_wardcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc =@f_warddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode =@f_roomcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc =@f_roomdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode =@f_bedcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc =@f_beddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode =@f_pharmacylocationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc =@f_pharmacylocationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1 =@f_freetext1,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2 =@f_freetext2,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify =@f_itemidentify,";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno =@f_tomachineno,";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus =@f_dispensestatus,";
            SQL += "dbo.tb_thaneshosp_middle.f_status =@f_status,";
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified =@f_lastmodified,";
            SQL += "dbo.tb_thaneshosp_middle.f_PRN =@f_PRN,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime =@f_frequencyTime,";
            SQL += "dbo.tb_thaneshosp_middle.f_language =@f_language,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense =@f_dosagedispense,";
            SQL += "dbo.tb_thaneshosp_middle.f_comment =@f_comment,";
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh =@f_statusCh,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3 =@f_freetext3,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4 =@f_freetext4,";
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug =@f_heighAlertDrug,";
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode =@f_referenceCode ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_seq", _seq));
                cmd.Parameters.Add(new SqlParameter("@f_seqmax", _seqmax));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptiondate", _prescriptiondate));
                cmd.Parameters.Add(new SqlParameter("@f_hn", _hn));
                cmd.Parameters.Add(new SqlParameter("@f_en", _en));
                cmd.Parameters.Add(new SqlParameter("@f_patientname", _patientname));
                cmd.Parameters.Add(new SqlParameter("@f_sex", _sex));
                cmd.Parameters.Add(new SqlParameter("@f_patientepisodedate", _patientepisodedate));
                cmd.Parameters.Add(new SqlParameter("@f_prioritycode", _prioritycode));
                cmd.Parameters.Add(new SqlParameter("@f_prioritydesc", _prioritydesc));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargetdate", _ordertargetdate));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargettime", _ordertargettime));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatedate", _ordercreatedate));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatetime", _ordercreatetime));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", _orderitemcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemname", _orderitemname));
                cmd.Parameters.Add(new SqlParameter("@f_orderqty", _orderqty));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitcode", _orderunitcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitdesc", _orderunitdesc));
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", _instructioncode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", _instructiondesc));
                cmd.Parameters.Add(new SqlParameter("@f_dosage", _dosage));
                cmd.Parameters.Add(new SqlParameter("@f_dosageunit", _dosageunit));
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", _frequencycode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", _frequencydesc));
                cmd.Parameters.Add(new SqlParameter("@f_durationcode", _durationcode));
                cmd.Parameters.Add(new SqlParameter("@f_durationdesc", _durationdesc));
                cmd.Parameters.Add(new SqlParameter("@f_noteprocessing", _noteprocessing));
                cmd.Parameters.Add(new SqlParameter("@f_fromlocationname", _fromlocationname));
                cmd.Parameters.Add(new SqlParameter("@f_userorderby", _userorderby));
                cmd.Parameters.Add(new SqlParameter("@f_useracceptby", _useracceptby));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptdate", _orderacceptdate));
                cmd.Parameters.Add(new SqlParameter("@f_orderaccepttime", _orderaccepttime));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptfromip", _orderacceptformip));
                cmd.Parameters.Add(new SqlParameter("@f_patientdob", _patientdob));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotcode", _itemlotcode));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotexpire", _itemlotexpire));
                cmd.Parameters.Add(new SqlParameter("@f_doctorcode", _doctorcode));
                cmd.Parameters.Add(new SqlParameter("@f_doctorname", _doctorname));
                cmd.Parameters.Add(new SqlParameter("@f_wardcode", _wardcode));
                cmd.Parameters.Add(new SqlParameter("@f_warddesc", _warddesc));
                cmd.Parameters.Add(new SqlParameter("@f_roomcode", _roomcode));
                cmd.Parameters.Add(new SqlParameter("@f_roomdesc", _roomdesc));
                cmd.Parameters.Add(new SqlParameter("@f_bedcode", _bedcode));
                cmd.Parameters.Add(new SqlParameter("@f_beddesc", _beddesc));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationcode", _pharmacylocationcode));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationdesc", _pharmacylocationdesc));
                cmd.Parameters.Add(new SqlParameter("@f_freetext1", _freetext1));
                cmd.Parameters.Add(new SqlParameter("@f_freetext2", _freetext2));
                cmd.Parameters.Add(new SqlParameter("@f_itemidentify", _itemidentify));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", _tomachineno));
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", _dispensestatus));
                cmd.Parameters.Add(new SqlParameter("@f_status", _status));
                cmd.Parameters.Add(new SqlParameter("@f_lastmodified", _lastmodified));
                cmd.Parameters.Add(new SqlParameter("@f_PRN", _PRN));
                cmd.Parameters.Add(new SqlParameter("@f_frequencyTime", _frequencyTime));
                cmd.Parameters.Add(new SqlParameter("@f_language", _language));
                cmd.Parameters.Add(new SqlParameter("@f_dosagedispense", _dosagedispense));
                cmd.Parameters.Add(new SqlParameter("@f_comment", _comment));
                cmd.Parameters.Add(new SqlParameter("@f_statusCh", _statusCh));
                cmd.Parameters.Add(new SqlParameter("@f_freetext3", _freetext3));
                cmd.Parameters.Add(new SqlParameter("@f_freetext4", _freetext4));
                cmd.Parameters.Add(new SqlParameter("@f_heighAlertDrug", _heighAlertDrug));
                cmd.Parameters.Add(new SqlParameter("@f_referenceCode", _referenceCode));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Delete patient prescriptions data.
        //Return Type boolean
        public bool DeleteDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "DELETE FROM dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            //SQL += "AND ";
            //SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                //cmd.Parameters.Add(new SqlParameter("@f_seq", _seq));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Update status patient prescriptions data.
        //Return Type boolean
        public bool UpdateStatusDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_status =@f_status ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @f_prescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@f_seq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", _prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_seq", _seq));
                cmd.Parameters.Add(new SqlParameter("@f_status", _status));
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query command for Get items referrence Code.
        //Return Type Objects
        public object CheckItemsDataThanesMiddle(string referenceCode)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT COUNT(dbo.tb_thaneshosp_middle.f_referenceCode)AS ItemsReferenceCode ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode =@f_referenceCode ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_referenceCode", referenceCode));
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for Get items referrence Code.
        //Return Type Objects
        public object GetMaxReferrenceCode()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT MAX(dbo.tb_thaneshosp_middle.f_referenceCode)AS MaxReferenceCode ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for Get items patient prescriptions data by prescription number.
        //Return Type Objects
        public object GetItemsDataThanesMiddle(string condition, string statustype)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT COUNT(DISTINCT(dbo.tb_thaneshosp_middle.f_prescriptionno))AS ItemsPrescription ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            switch (statustype)
            {
                case "all":
                    SQL += "dbo.tb_thaneshosp_middle.f_status IN('0','1','2') ";
                    break;

                case "wait":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 0 ";
                    break;

                case "complete":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 1 ";
                    break;

                case "cancel":
                    SQL += "dbo.tb_thaneshosp_middle.f_status = 2 ";
                    break;
            }
            if ((condition != "") && (condition != null))
            {
                SQL += "AND ";
                SQL += "(dbo.tb_thaneshosp_middle.f_prescriptionno LIKE '" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_hn LIKE '" + condition + "%' OR ";
                SQL += "dbo.tb_thaneshosp_middle.f_patientname LIKE '%" + condition + "%') ";
            }
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //insert the data backup from TPN_STD_CONNECT_MIDDLE to TPN_STD_CONNECT_MIDDLE_BAK.
        public bool TransectionBackupThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO tb_thaneshosp_middle_bak ";
            SQL += "SELECT * FROM tb_thaneshosp_middle ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteNonQuerySQL(cmd);
            }
        }

        //Query Command thaneshop middle table for Display Prescription Detail Page.
        public DataSet GetDispalyDataPatient(string prescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn, ";
            SQL += "dbo.tb_thaneshosp_middle.f_en, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname, ";
            SQL += "dbo.tb_thaneshosp_middle.f_sex, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby, ";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob, ";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip, ";
            SQL += "MAX(dbo.tb_thaneshosp_middle.f_lastmodified)as f_lastmodified ";

            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "GROUP BY ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_hn, ";
            SQL += "dbo.tb_thaneshosp_middle.f_en, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname, ";
            SQL += "dbo.tb_thaneshosp_middle.f_sex, ";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby, ";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob, ";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc, ";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate, ";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime, ";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip, ";
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", prescriptionno));
                return conn.FillSQL(cmd);
            }
        }

        //Query Command thaneshop middle table
        public DataSet GetDataDisplayDetailPrescription(string p_prescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno,";                      //1
            SQL += "dbo.tb_thaneshosp_middle.f_seq,";                                 //2
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax,";                              //3
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate,";                    //4
            SQL += "dbo.tb_thaneshosp_middle.f_hn,";                                  //5
            SQL += "dbo.tb_thaneshosp_middle.f_en,";                                  //6
            SQL += "dbo.tb_thaneshosp_middle.f_patientname,";                         //7
            SQL += "dbo.tb_thaneshosp_middle.f_sex,";                                 //8
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate,";                  //9
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode,";                        //10
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc,";                        //11
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate,";                     //12
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime,";                     //13
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate,";                     //14
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime,";                     //15
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode,";                       //16
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname,";                       //17
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty,";                            //18
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode,";                       //19
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc,";                       //20
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode,";                     //21
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc,";                     //22
            SQL += "dbo.tb_thaneshosp_middle.f_dosage,";                              //23
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit,";                          //24
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode,";                       //25
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc,";                       //26
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode,";                        //27
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc,";                        //28
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing,";                      //29
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname,";                    //30
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby,";                         //31
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby,";                        //32
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate,";                     //33
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime,";                     //34
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip,";                   //35
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob,";                          //36
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode,";                         //37
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire,";                       //38
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode,";                          //39
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname,";                          //40
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode,";                            //41
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc,";                            //42
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode,";                            //43
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc,";                            //44
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode,";                             //45
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc,";                             //46
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode,";                //47
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc,";                //48
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //49
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //50
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //51
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //52
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //53
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //54
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //55
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //56
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //57
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //58
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //59
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //60
            SQL += "dbo.tb_thaneshosp_middle.f_statusCh,";                            //61
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.f_heighAlertDrug,";                      //64
            SQL += "dbo.tb_thaneshosp_middle.f_referenceCode ";                       //65
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_seq ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_prescriptionno", p_prescriptionno);
                return conn.FillSQL(cmd);
            }
        }
    }
}