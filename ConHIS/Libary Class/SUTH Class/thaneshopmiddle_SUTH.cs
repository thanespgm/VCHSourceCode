using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS
{
    internal class Thaneshopmiddle_SUTH
    {
        //filed and properties
        private string prescriptionno;

        private decimal seq;
        private decimal seqmax;
        private string prescriptiondate;
        private string hn;
        private string en;
        private string patientname;
        private decimal sex;
        private DateTime patientepisodedate;
        private string prioritycode;
        private string prioritydesc;
        private string ordertargetdate;
        private string ordertargettime;
        private string ordercreatedate;
        private string ordercreatetime;
        private string orderitemcode;
        private string orderitemname;
        private decimal orderqty;
        private string orderunitcode;
        private string orderunitdesc;
        private string instructioncode;
        private string instructiondesc;
        private decimal dosage;
        private string dosageunit;
        private string frequencycode;
        private string frequencydesc;
        private string durationcode;
        private string durationdesc;
        private string noteprocessing;
        private string fromlocationname;
        private string userorderby;
        private string useracceptby;
        private string orderacceptdate;
        private string orderaccepttime;
        private string orderacceptformip;
        private string patientdob;
        private string itemlotcode;
        private string itemlotexpire;
        private string doctorcode;
        private string doctorname;
        private string wardcode;
        private string warddesc;
        private string roomcode;
        private string roomdesc;
        private string bedcode;
        private string beddesc;
        private string pharmacylocationcode;
        private string pharmacylocationdesc;
        private string pharmacyitemcode;
        private string pharmacyitemdesc;
        private string freetext1;
        private string freetext2;
        private string itemidentify;
        private decimal tomachineno;
        private decimal dispensestatus;
        private decimal status;
        private DateTime lastmodified;
        private decimal pRN;
        private string frequencyTime;
        private decimal language;
        private string dosagedispense;
        private string comment;
        private string freetext3;
        private decimal printstatus;
        private decimal count;
        private string freetext4;
        private string freetext5;
        private string imgbinary;
        private string freetext6;
        private string isExcludeFromIPFill;
        private decimal printIpFill;
        private string lab;

        public string Prescriptionno { get => prescriptionno; set => prescriptionno = value; }
        public decimal Seq { get => seq; set => seq = value; }
        public decimal Seqmax { get => seqmax; set => seqmax = value; }
        public string Prescriptiondate { get => prescriptiondate; set => prescriptiondate = value; }
        public string Hn { get => hn; set => hn = value; }
        public string En { get => en; set => en = value; }
        public string Patientname { get => patientname; set => patientname = value; }
        public decimal Sex { get => sex; set => sex = value; }
        public DateTime Patientepisodedate { get => patientepisodedate; set => patientepisodedate = value; }
        public string Prioritycode { get => prioritycode; set => prioritycode = value; }
        public string Prioritydesc { get => prioritydesc; set => prioritydesc = value; }
        public string Ordertargetdate { get => ordertargetdate; set => ordertargetdate = value; }
        public string Ordertargettime { get => ordertargettime; set => ordertargettime = value; }
        public string Ordercreatedate { get => ordercreatedate; set => ordercreatedate = value; }
        public string Ordercreatetime { get => ordercreatetime; set => ordercreatetime = value; }
        public string Orderitemcode { get => orderitemcode; set => orderitemcode = value; }
        public string Orderitemname { get => orderitemname; set => orderitemname = value; }
        public decimal Orderqty { get => orderqty; set => orderqty = value; }
        public string Orderunitcode { get => orderunitcode; set => orderunitcode = value; }
        public string Orderunitdesc { get => orderunitdesc; set => orderunitdesc = value; }
        public string Instructioncode { get => instructioncode; set => instructioncode = value; }
        public string Instructiondesc { get => instructiondesc; set => instructiondesc = value; }
        public decimal Dosage { get => dosage; set => dosage = value; }
        public string Dosageunit { get => dosageunit; set => dosageunit = value; }
        public string Frequencycode { get => frequencycode; set => frequencycode = value; }
        public string Frequencydesc { get => frequencydesc; set => frequencydesc = value; }
        public string Durationcode { get => durationcode; set => durationcode = value; }
        public string Durationdesc { get => durationdesc; set => durationdesc = value; }
        public string Noteprocessing { get => noteprocessing; set => noteprocessing = value; }
        public string Fromlocationname { get => fromlocationname; set => fromlocationname = value; }
        public string Userorderby { get => userorderby; set => userorderby = value; }
        public string Useracceptby { get => useracceptby; set => useracceptby = value; }
        public string Orderacceptdate { get => orderacceptdate; set => orderacceptdate = value; }
        public string Orderaccepttime { get => orderaccepttime; set => orderaccepttime = value; }
        public string Orderacceptformip { get => orderacceptformip; set => orderacceptformip = value; }
        public string Patientdob { get => patientdob; set => patientdob = value; }
        public string Itemlotcode { get => itemlotcode; set => itemlotcode = value; }
        public string Itemlotexpire { get => itemlotexpire; set => itemlotexpire = value; }
        public string Doctorcode { get => doctorcode; set => doctorcode = value; }
        public string Doctorname { get => doctorname; set => doctorname = value; }
        public string Wardcode { get => wardcode; set => wardcode = value; }
        public string Warddesc { get => warddesc; set => warddesc = value; }
        public string Roomcode { get => roomcode; set => roomcode = value; }
        public string Roomdesc { get => roomdesc; set => roomdesc = value; }
        public string Bedcode { get => bedcode; set => bedcode = value; }
        public string Beddesc { get => beddesc; set => beddesc = value; }
        public string Pharmacylocationcode { get => pharmacylocationcode; set => pharmacylocationcode = value; }
        public string Pharmacylocationdesc { get => pharmacylocationdesc; set => pharmacylocationdesc = value; }
        public string Pharmacyitemcode { get => pharmacyitemcode; set => pharmacyitemcode = value; }
        public string Pharmacyitemdesc { get => pharmacyitemdesc; set => pharmacyitemdesc = value; }
        public string Freetext1 { get => freetext1; set => freetext1 = value; }
        public string Freetext2 { get => freetext2; set => freetext2 = value; }
        public string Itemidentify { get => itemidentify; set => itemidentify = value; }
        public decimal Tomachineno { get => tomachineno; set => tomachineno = value; }
        public decimal Dispensestatus { get => dispensestatus; set => dispensestatus = value; }
        public decimal Status { get => status; set => status = value; }
        public DateTime Lastmodified { get => lastmodified; set => lastmodified = value; }
        public decimal PRN { get => pRN; set => pRN = value; }
        public string FrequencyTime { get => frequencyTime; set => frequencyTime = value; }
        public decimal Language { get => language; set => language = value; }
        public string Dosagedispense { get => dosagedispense; set => dosagedispense = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Freetext3 { get => freetext3; set => freetext3 = value; }
        public decimal Printstatus { get => printstatus; set => printstatus = value; }
        public decimal Count { get => count; set => count = value; }
        public string Freetext4 { get => freetext4; set => freetext4 = value; }
        public string Freetext5 { get => freetext5; set => freetext5 = value; }
        public string Imgbinary { get => imgbinary; set => imgbinary = value; }
        public string Freetext6 { get => freetext6; set => freetext6 = value; }
        public string IsExcludeFromIPFill { get => isExcludeFromIPFill; set => isExcludeFromIPFill = value; }
        public decimal PrintIpFill { get => printIpFill; set => printIpFill = value; }
        public string Lab { get => lab; set => lab = value; }

        private System_logfile logs;

        //Constructor And Adstract Calss
        public Thaneshopmiddle_SUTH()
        {
            logs = new System_logfile();
        }

        //Query Command thaneshop middle table for Display DataGrid View Full Detial Form
        public DataSet GetDispalyDataGridViewFullDetail(string condition)
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
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //66
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5,";                            //67
            SQL += "dbo.tb_thaneshosp_middle.imgbinary,";                             //68
            SQL += "dbo.tb_thaneshosp_middle.f_freetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab ";                                   //72
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
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //66
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5";                            //67
            SQL += "dbo.tb_thaneshosp_middle.imgbinary,";                             //68
            SQL += "dbo.tb_thaneshosp_middle.ffreetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab ";                                   //72
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

        //Query Command thaneshop middle table
        public DataSet GetDataByEn(string en)
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
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //66
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5";                            //67
            SQL += "dbo.tb_thaneshosp_middle.imgbinary,";                             //68
            SQL += "dbo.tb_thaneshosp_middle.ffreetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab ";                                   //72
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_en =@f_en ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus =@ ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_seq ASC ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_en", en);
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
                foreach (Object prescriptionnoIn in prescriptionno)
                    SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = '" + prescriptionnoIn + "' ";
            }
            else if ((prescriptionno.Count != 0) && (prescriptionno != null))
            {
                string presno = "";
                int i = 0;
                SQL += "AND ";
                foreach (Object prescriptionnoIn in prescriptionno)
                {
                    i++;
                    if (prescriptionno.Count != i)
                    {
                        presno += "'" + prescriptionnoIn + "',";
                    }
                    else
                    {
                        presno += "'" + prescriptionnoIn + "'";
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
        public bool UpdateDataGenerateByPres(string pprescriptionno)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "UPDATE dbo.tb_thaneshosp_middle SET ";
            SQL += "dbo.tb_thaneshosp_middle.f_status =@f_status ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_status", Status);
                cmd.Parameters.AddWithValue("@f_prescriptionno", pprescriptionno);
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
            //SQL += "dbo.tb_thaneshosp_middle.fprescriptionno ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items patient Group By Hn
        // Retrun Type Dataset
        public Object ItemsAllDataPatient()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "COUNT(DISTINCT(dbo.tb_thaneshosp_middle.f_hn))as Items ";
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            //SQL += "GROUP BY ";
            //SQL += "dbo.tb_thaneshosp_middle.fhn ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.ExecuteScalarSQL(cmd);
            }
        }

        //Query command for get items all table
        // Retrun Type Dataset
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
            SQL += "WHEN dbo.tb_thaneshosp_middle.f_tomachineno = 0 THEN 'จัดยาโดยผู้ใช้งาน'";
            SQL += "WHEN dbo.tb_thaneshosp_middle.f_tomachineno = 2 THEN 'จัดโดย PROUND'";
            SQL += "ELSE 'จัดยาโดยผู้ใช้งาน'";
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
        public int CHMLength(string columnname)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "SELECT ";
            SQL += "CHARACTERMAXIMUMLENGTH ";
            SQL += "FROM ";
            SQL += "INFORMATIONSCHEMA.COLUMNS ";
            SQL += "WHERE ";
            SQL += "TABLENAME ='tb_thaneshosp_middle' ";
            SQL += "AND ";
            SQL += "COLUMNNAME = @COLUMNNAME ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@COLUMNNAME", columnname);
                return Convert.ToInt32(conn.ExecuteScalarSQL(cmd));
            }
        }

        //Check data before importing data into database.
        //Return Type boolean

        //public bool CheckDataBeforeInSert(string filename)
        //{
        //    string str = "";
        //    if (Variable.errorStrLog != "")
        //    {
        //        str = Variable.errorStrLog;
        //    }
        //    if(Prescriptionno.Length > CHMLength("fprescriptionno"))  //
        //    {
        //        str += " column : fprescriptionno     data : " + Prescriptionno + "  charactermaximumlength : " + CHMLength("fprescriptionno") + "  datalength : " + Prescriptionno.Length + "\r\n";
        //    }
        //    if (Prescriptiondate.Length > CHMLength("fprescriptiondate"))  //
        //    {
        //        str += " column : fprescriptiondate     data : " + Prescriptiondate + "  charactermaximumlength : " + CHMLength("fprescriptiondate") + "  datalength : " + Prescriptiondate.Length + "\r\n";
        //    }
        //    if (Hn.Length > CHMLength("fhn"))   //
        //    {
        //        str += " column : fhn     data : " + Hn + "  charactermaximumlength : " + CHMLength("fhn") + "  datalength : " + Hn.Length + "\r\n";
        //    }
        //    if (En.Length > CHMLength("fen")) //
        //    {
        //        str += " column : fen     data : " + En + "  charactermaximumlength : " + CHMLength("fen") + "  datalength : " + En.Length + "\r\n";
        //    }
        //    if (Patientname.Length > CHMLength("fpatientname"))  //
        //    {
        //        str += " column : fpatientname     data : " + Patientname + "  charactermaximumlength : " + CHMLength("fpatientname") + "  datalength : " + Patientname.Length + "\r\n";
        //    }
        //    if (Prioritycode.Length > CHMLength("fprioritycode"))  //
        //    {
        //        str += " column : fprioritycode     data : " + Prioritycode + "  charactermaximumlength : " + CHMLength("fprioritycode") + "  datalength : " + Prioritycode.Length + "\r\n";
        //    }
        //    if (Prioritydesc.Length > CHMLength("fprioritydesc")) //
        //    {
        //        str += " column : fprioritydesc     data : " + Prioritydesc + "  charactermaximumlength : " + CHMLength("fprioritydesc") + "  datalength : " + Prioritydesc.Length + "\r\n";
        //    }
        //    if (Ordertargetdate.Length > CHMLength("fordertargetdate"))  //
        //    {
        //        str += " column : fordertargetdate     data : " + Ordertargetdate + "  charactermaximumlength : " + CHMLength("fordertargetdate") + "  datalength : " + Ordertargetdate.Length + "\r\n";
        //    }
        //    if (Ordertargettime.Length > CHMLength("fordertargettime")) //
        //    {
        //        str += " column : fordertargettime     data : " + Ordertargettime + "  charactermaximumlength : " + CHMLength("fordertargettime") + "  datalength : " + Ordertargettime.Length + "\r\n";
        //    }
        //    if (Ordercreatedate.Length > CHMLength("fordercreatedate"))   //
        //    {
        //        str += " column : fordercreatedate     data : " + Ordercreatedate + "  charactermaximumlength : " + CHMLength("fordercreatedate") + "  datalength : " + Ordercreatedate.Length + "\r\n";
        //    }
        //    if (Ordercreatetime.Length > CHMLength("fordercreatetime")) //
        //    {
        //        str += " column : fordercreatetime     data : " + Ordercreatetime + "  charactermaximumlength : " + CHMLength("fordercreatetime") + "  datalength : " + Ordercreatetime.Length + "\r\n";
        //    }
        //    if (Orderitemcode.Length > CHMLength("forderitemcode"))  //
        //    {
        //        str += " column : forderitemcode     data : " + Orderitemcode + "  charactermaximumlength : " + CHMLength("forderitemcode") + "  datalength : " + Orderitemcode.Length + "\r\n";
        //    }
        //    if (Orderitemname.Length > CHMLength("forderitemname"))  //
        //    {
        //        str += " column : forderitemname     data : " + Orderitemname + "  charactermaximumlength : " + CHMLength("forderitemname") + "  datalength : " + Orderitemname.Length + "\r\n";
        //    }
        //    if (Orderunitcode.Length > CHMLength("forderunitcode"))  //
        //    {
        //        str += " column : forderunitcode     data : " + Orderunitcode + "  charactermaximumlength : " + CHMLength("forderunitcode") + "  datalength : " + Orderunitcode.Length + "\r\n";
        //    }
        //    if (Orderunitdesc.Length > CHMLength("forderunitdesc"))   //
        //    {
        //        str += " column : forderunitdesc     data : " + Orderunitdesc + "  charactermaximumlength : " + CHMLength("forderunitdesc") + "  datalength : " + Orderunitdesc.Length + "\r\n";
        //    }
        //    if (Instructioncode.Length > CHMLength("finstructioncode"))   //
        //    {
        //        str += " column : finstructioncode     data : " + Instructioncode + "  charactermaximumlength : " + CHMLength("finstructioncode") + "  datalength : " + Instructioncode.Length + "\r\n";
        //    }
        //    if (Instructiondesc.Length > CHMLength("finstructiondesc")) //
        //    {
        //        str += " column : finstructiondesc     data : " + Instructiondesc + "  charactermaximumlength : " + CHMLength("finstructiondesc") + "  datalength : " + Instructiondesc.Length + "\r\n";
        //    }
        //    if (Dosageunit.Length > CHMLength("fdosageunit")) //
        //    {
        //        str += " column : fdosageunit     data : " + Dosageunit + "  charactermaximumlength : " + CHMLength("fdosageunit") + "  datalength : " + Dosageunit.Length + "\r\n";
        //    }
        //    if (Frequencycode.Length > CHMLength("ffrequencycode"))   //
        //    {
        //        str += " column : ffrequencycode     data : " + Frequencycode + "  charactermaximumlength : " + CHMLength("ffrequencycode") + "  datalength : " + Frequencycode.Length + "\r\n";
        //    }
        //    if (Frequencydesc.Length > CHMLength("ffrequencydesc"))   //
        //    {
        //        str += " column : ffrequencydesc     data : " + Frequencydesc + "  charactermaximumlength : " + CHMLength("ffrequencydesc") + "  datalength : " + Frequencydesc.Length + "\r\n";
        //    }
        //    if (Durationcode.Length > CHMLength("fdurationcode"))    //
        //    {
        //        str += " column : fdurationcode     data : " + Durationcode + "  charactermaximumlength : " + CHMLength("fdurationcode") + "  datalength : " + Durationcode.Length + "\r\n";
        //    }
        //    if (Durationdesc.Length > CHMLength("fdurationdesc"))  //
        //    {
        //        str += " column : fdurationdesc     data : " + Durationdesc + "  charactermaximumlength : " + CHMLength("fdurationdesc") + "  datalength : " + Durationdesc.Length + "\r\n";
        //    }
        //    if (Noteprocessing.Length > CHMLength("fnoteprocessing")) //
        //    {
        //        str += " column : fnoteprocessing     data : " + Noteprocessing + "  charactermaximumlength : " + CHMLength("fnoteprocessing") + "  datalength : " + Noteprocessing.Length + "\r\n";
        //    }
        //    if (Fromlocationname.Length > CHMLength("ffromlocationname"))   //
        //    {
        //        str += " column : ffromlocationname     data : " + Fromlocationname + "  charactermaximumlength : " + CHMLength("ffromlocationname") + "  datalength : " + Fromlocationname.Length + "\r\n";
        //    }
        //    if (Userorderby.Length > CHMLength("fuserorderby"))   //
        //    {
        //        str += " column : fuserorderby     data : " + Userorderby + "  charactermaximumlength : " + CHMLength("fuserorderby") + "  datalength : " + Userorderby.Length + "\r\n";
        //    }
        //    if (Useracceptby.Length > CHMLength("fuseracceptby"))   //
        //    {
        //        str += " column : fuseracceptby     data : " + Useracceptby + "  charactermaximumlength : " + CHMLength("fuseracceptby") + "  datalength : " + Useracceptby.Length + "\r\n";
        //    }
        //    if (Orderacceptdate.Length > CHMLength("forderacceptdate"))  //
        //    {
        //        str += " column : forderacceptdate     data : " + Orderacceptdate + "  charactermaximumlength : " + CHMLength("forderacceptdate") + "  datalength : " + Orderacceptdate.Length + "\r\n";
        //    }
        //    if (Orderaccepttime.Length > CHMLength("forderaccepttime")) //
        //    {
        //        str += " column : forderaccepttime     data : " + Orderaccepttime + "  charactermaximumlength : " + CHMLength("forderaccepttime") + "  datalength : " + Orderaccepttime.Length + "\r\n";
        //    }
        //    if (Orderacceptformip.Length > CHMLength("forderacceptfromip"))  //
        //    {
        //        str += " column : forderacceptfromip     data : " + Orderacceptformip + "  charactermaximumlength : " + CHMLength("forderacceptfromip") + "  datalength : " + Orderacceptformip.Length + "\r\n";
        //    }
        //    if (Patientdob.Length > CHMLength("fpatientdob"))  //
        //    {
        //        str += " column : fpatientdob     data : " + Patientdob + "  charactermaximumlength : " + CHMLength("fpatientdob") + "  datalength : " + Patientdob.Length + "\r\n";
        //    }
        //    if (Itemlotcode.Length > CHMLength("fitemlotcode")) //
        //    {
        //        str += " column : fitemlotcode     data : " + Itemlotcode + "  charactermaximumlength : " + CHMLength("fitemlotcode") + "  datalength : " + Itemlotcode.Length + "\r\n";
        //    }
        //    if (Itemlotexpire.Length > CHMLength("fitemlotexpire")) //
        //    {
        //        str += " column : fitemlotexpire     data : " + Itemlotexpire + "  charactermaximumlength : " + CHMLength("fitemlotexpire") + "  datalength : " + Itemlotexpire.Length + "\r\n";
        //    }
        //    if (Doctorcode.Length > CHMLength("fdoctorcode"))  //
        //    {
        //        str += " column : fdoctorcode     data : " + Doctorcode + "  charactermaximumlength : " + CHMLength("fdoctorcode") + "  datalength : " + Doctorcode.Length + "\r\n";
        //    }
        //    if (Doctorname.Length > CHMLength("fdoctorname")) //
        //    {
        //        str += " column : fdoctorname     data : " + Doctorname + "  charactermaximumlength : " + CHMLength("fdoctorname") + "  datalength : " + Doctorname.Length + "\r\n";
        //    }
        //    if (Wardcode.Length > CHMLength("fwardcode")) //
        //    {
        //        str += " column : fwardcode     data : " + Wardcode + "  charactermaximumlength : " + CHMLength("fwardcode") + "  datalength : " + Wardcode.Length + "\r\n";
        //    }
        //    if (Warddesc.Length > CHMLength("fwarddesc"))  //
        //    {
        //        str += " column : fwarddesc     data : " + Warddesc + "  charactermaximumlength : " + CHMLength("fwarddesc") + "  datalength : " + Warddesc.Length + "\r\n";
        //    }
        //    if (Roomcode.Length > CHMLength("froomcode")) //
        //    {
        //        str += " column : froomcode     data : " + Roomcode + "  charactermaximumlength : " + CHMLength("froomcode") + "  datalength : " + Roomcode.Length + "\r\n";
        //    }
        //    if (Roomdesc.Length > CHMLength("froomdesc")) //
        //    {
        //        str += " column : froomdesc     data : " + Roomdesc + "  charactermaximumlength : " + CHMLength("froomdesc") + "  datalength : " + Roomdesc.Length + "\r\n";
        //    }
        //    if (Bedcode.Length > CHMLength("fbedcode"))   //
        //    {
        //        str += " column : fbedcode     data : " + Bedcode + "  charactermaximumlength : " + CHMLength("fbedcode") + "  datalength : " + Bedcode.Length + "\r\n";
        //    }
        //    if (Beddesc.Length > CHMLength("fbeddesc"))    //
        //    {
        //        str += " column : fbeddesc     data : " + Beddesc + "  charactermaximumlength : " + CHMLength("fbeddesc") + "  datalength : " + Beddesc.Length + "\r\n";
        //    }
        //    if (Pharmacylocationcode.Length > CHMLength("fpharmacylocationcode"))  //
        //    {
        //        str += " column : fpharmacylocationcode     data : " + Pharmacylocationcode + "  charactermaximumlength : " + CHMLength("fpharmacylocationcode") + "  datalength : " + Pharmacylocationcode.Length + "\r\n";
        //    }
        //    if (Pharmacylocationdesc.Length > CHMLength("fpharmacylocationdesc"))  //
        //    {
        //        str += " column : fpharmacylocationdesc     data : " + Pharmacylocationdesc + "  charactermaximumlength : " + CHMLength("fpharmacylocationdesc") + "  datalength : " + Pharmacylocationdesc.Length + "\r\n";
        //    }
        //    if (Pharmacyitemcode.Length > CHMLength("fpharmacyitemcode"))  //
        //    {
        //        str += " column : fpharmacyitemcode     data : " + Pharmacyitemcode + "  charactermaximumlength : " + CHMLength("fpharmacyitemcode") + "  datalength : " + Pharmacyitemcode.Length + "\r\n";
        //    }
        //    if (Pharmacyitemdesc.Length > CHMLength("fpharmacyitemdesc"))  //
        //    {
        //        str += " column : fpharmacyitemdesc     data : " + Pharmacyitemdesc + "  charactermaximumlength : " + CHMLength("fpharmacyitemdesc") + "  datalength : " + Pharmacyitemdesc.Length + "\r\n";
        //    }
        //    if (Freetext1.Length > CHMLength("ffreetext1"))    //
        //    {
        //        str += " column : ffreetext1     data : " + Freetext1 + "  charactermaximumlength : " + CHMLength("ffreetext1") + "  datalength : " + Freetext1.Length + "\r\n";
        //    }
        //    if (Freetext2.Length > CHMLength("ffreetext2"))    //
        //    {
        //        str += " column : ffreetext2     data : " + Freetext2 + "  charactermaximumlength : " + CHMLength("ffreetext2") + "  datalength : " + Freetext2.Length + "\r\n";
        //    }
        //    if (Itemidentify.Length > CHMLength("fitemidentify"))   //
        //    {
        //        str += " column : fitemidentify     data : " + Itemidentify + "  charactermaximumlength : " + CHMLength("fitemidentify") + "  datalength : " + Itemidentify.Length + "\r\n";
        //    }
        //    if (FrequencyTime.Length > CHMLength("ffrequencyTime")) //
        //    {
        //        str += " column : ffrequencyTime     data : " + FrequencyTime + "  charactermaximumlength : " + CHMLength("ffrequencyTime") + "  datalength : " + FrequencyTime.Length + "\r\n";
        //    }
        //    if (Dosagedispense.Length > CHMLength("fdosagedispense")) //
        //    {
        //        str += " column : fdosagedispense     data : " + Dosagedispense + "  charactermaximumlength : " + CHMLength("fdosagedispense") + "  datalength : " + Dosagedispense.Length + "\r\n";
        //    }
        //    if (Comment.Length > CHMLength("fcomment")) //
        //    {
        //        str += " column : fcomment     data : " + Comment + "  charactermaximumlength : " + CHMLength("fcomment") + "  datalength : " + Comment.Length + "\r\n";
        //    }
        //    if (Freetext3.Length > CHMLength("ffreetext3"))   //
        //    {
        //        str += " column : ffreetext3     data : " + Freetext3 + "  charactermaximumlength : " + CHMLength("ffreetext3") + "  datalength : " + Freetext3.Length + "\r\n";
        //    }
        //    if (Freetext4.Length > CHMLength("ffreetext4"))  //
        //    {
        //        str += " column : ffreetext4     data : " + Freetext4 + "  charactermaximumlength : " + CHMLength("ffreetext4") + "  datalength : " + Freetext4.Length + "\r\n";
        //    }
        //    if (Freetext5.Length > CHMLength("ffreetext5"))  //
        //    {
        //        str += " column : ffreetext5     data : " + Freetext5 + "  charactermaximumlength : " + CHMLength("ffreetext5") + "  datalength : " + Freetext5.Length + "\r\n";
        //    }
        //    if (Imgbinary.Length > CHMLength("imgbinary"))  //
        //    {
        //        str += " column : imgbinary     data : " + Imgbinary + "  charactermaximumlength : " + CHMLength("imgbinary") + "  datalength : " + Imgbinary.Length + "\r\n";
        //    }
        //    if (Freetext6.Length > CHMLength("ffreetext6"))  //
        //    {
        //        str += " column : ffreetext6     data : " + Freetext6 + "  charactermaximumlength : " + CHMLength("ffreetext6") + "  datalength : " + Freetext6.Length + "\r\n";
        //    }
        //    if (IsExcludeFromIPFill.Length > CHMLength("IsExcludeFromIPFill"))  //
        //    {
        //        str += " column : IsExcludeFromIPFill     data : " + IsExcludeFromIPFill + "  charactermaximumlength : " + CHMLength("IsExcludeFromIPFill") + "  datalength : " + IsExcludeFromIPFill.Length + "\r\n";
        //    }

        //    bool result;
        //    if (str != "")
        //    {
        //        logs.Writelogcheck(str, " CheckDataBefore[ " + filename + " ]");
        //        Variable.errorStrLog = "";
        //        result = false;
        //    }
        //    else
        //    {
        //        result = true;
        //    }
        //    return result;
        //}

        //Query command for adding patient prescriptions data.
        //Return Type boolean

        public bool InsertDataThanesMiddle()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(Variable.DBlocal);
            SQL += "INSERT INTO dbo.tb_thaneshosp_middle (";
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
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //66
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5,";                           //67
            //SQL += "dbo.tb_thaneshosp_middle.imgbinary,";                           //68
            SQL += "dbo.tb_thaneshosp_middle.f_freetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab) ";                                  //72
            SQL += "VALUES( ";
            SQL += "@f_prescriptionno,";                                             //1
            SQL += "@f_seq,";                                                        //2
            SQL += "@f_seqmax,";                                                     //3
            SQL += "@f_prescriptiondate,";                                           //4
            SQL += "@f_hn,";                                                         //5
            SQL += "@f_en,";                                                         //6
            SQL += "@f_patientname,";                                                //7
            SQL += "@f_sex,";                                                        //8
            SQL += "GETDATE(),";                                                     //9
            SQL += "@f_prioritycode,";                                               //10
            SQL += "@f_prioritydesc,";                                               //11
            SQL += "@f_ordertargetdate,";                                            //12
            SQL += "@f_ordertargettime,";                                            //13
            SQL += "@f_ordercreatedate,";                                            //14
            SQL += "@f_ordercreatetime,";                                            //15
            SQL += "@f_orderitemcode,";                                              //16
            SQL += "@f_orderitemname,";                                              //17
            SQL += "@f_orderqty,";                                                   //18
            SQL += "@f_orderunitcode,";                                              //19
            SQL += "@f_orderunitdesc,";                                              //20
            SQL += "@f_instructioncode,";                                            //21
            SQL += "@f_instructiondesc,";                                            //22
            SQL += "@f_dosage,";                                                     //23
            SQL += "@f_dosageunit,";                                                 //24
            SQL += "@f_frequencycode,";                                              //25
            SQL += "@f_frequencydesc,";                                              //26
            SQL += "@f_durationcode,";                                               //27
            SQL += "@f_durationdesc,";                                               //28
            SQL += "@f_noteprocessing,";                                             //29
            SQL += "@f_fromlocationname,";                                           //30
            SQL += "@f_userorderby,";                                                //31
            SQL += "@f_useracceptby,";                                               //32
            SQL += "@f_orderacceptdate,";                                            //33
            SQL += "@f_orderaccepttime,";                                            //34
            SQL += "@f_orderacceptfromip,";                                          //35
            SQL += "@f_patientdob,";                                                 //36
            SQL += "@f_itemlotcode,";                                                //37
            SQL += "@f_itemlotexpire,";                                              //38
            SQL += "@f_doctorcode,";                                                 //39
            SQL += "@f_doctorname,";                                                 //40
            SQL += "@f_wardcode,";                                                   //41
            SQL += "@f_warddesc,";                                                   //42
            SQL += "@f_roomcode,";                                                   //43
            SQL += "@f_roomdesc,";                                                   //44
            SQL += "@f_bedcode,";                                                    //45
            SQL += "@f_beddesc,";                                                    //46
            SQL += "@f_pharmacylocationcode,";                                       //47
            SQL += "@f_pharmacylocationdesc,";                                       //48
            SQL += "@f_pharmacyitemcode,";                                           //49
            SQL += "@f_pharmacyitemdesc,";                                           //50
            SQL += "@f_freetext1,";                                                  //51
            SQL += "@f_freetext2,";                                                  //52
            SQL += "@f_itemidentify,";                                               //53
            SQL += "@f_tomachineno,";                                                //54
            SQL += "@f_dispensestatus,";                                             //55
            SQL += "@f_status,";                                                     //56
            SQL += "GETDATE(),";                                                     //57
            SQL += "@f_PRN,";                                                        //58
            SQL += "@f_frequencyTime,";                                              //59
            SQL += "@f_language,";                                                   //60
            SQL += "@f_dosagedispense,";                                             //61
            SQL += "@f_comment,";                                                    //62
            SQL += "@f_freetext3,";                                                  //63
            SQL += "@Printstatus,";                                                  //64
            SQL += "@f_count,";                                                      //65
            SQL += "@f_freetext4,";                                                  //66
            SQL += "@f_freetext5,";                                                  //67
            //SQL += "@imgbinary,";                                                    //68
            SQL += "@f_freetext6,";                                                  //69
            SQL += "@IsExcludeFromIPFill,";                                          //70
            SQL += "@printIpFill,";                                                  //71
            SQL += "@Lab)";                                                          //72
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", Prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_seq", Seq));
                cmd.Parameters.Add(new SqlParameter("@f_seqmax", Seqmax));
                cmd.Parameters.Add(new SqlParameter("@f_prescriptiondate", Prescriptiondate));
                cmd.Parameters.Add(new SqlParameter("@f_hn", Hn));
                cmd.Parameters.Add(new SqlParameter("@f_en", En));
                cmd.Parameters.Add(new SqlParameter("@f_patientname", Patientname));
                cmd.Parameters.Add(new SqlParameter("@f_sex", Sex));
                cmd.Parameters.Add(new SqlParameter("@f_prioritycode", Prioritycode));
                cmd.Parameters.Add(new SqlParameter("@f_prioritydesc", Prioritydesc));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargetdate", Ordertargetdate));
                cmd.Parameters.Add(new SqlParameter("@f_ordertargettime", Ordertargettime));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatedate", Ordercreatedate));
                cmd.Parameters.Add(new SqlParameter("@f_ordercreatetime", Ordercreatetime));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemcode", Orderitemcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderitemname", Orderitemname));
                cmd.Parameters.Add(new SqlParameter("@f_orderqty", Orderqty));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitcode", Orderunitcode));
                cmd.Parameters.Add(new SqlParameter("@f_orderunitdesc", Orderunitdesc));
                cmd.Parameters.Add(new SqlParameter("@f_instructioncode", Instructioncode));
                cmd.Parameters.Add(new SqlParameter("@f_instructiondesc", Instructiondesc));
                cmd.Parameters.Add(new SqlParameter("@f_dosage", Dosage));
                cmd.Parameters.Add(new SqlParameter("@f_dosageunit", Dosageunit));
                cmd.Parameters.Add(new SqlParameter("@f_frequencycode", Frequencycode));
                cmd.Parameters.Add(new SqlParameter("@f_frequencydesc", Frequencydesc));
                cmd.Parameters.Add(new SqlParameter("@f_durationcode", Durationcode));
                cmd.Parameters.Add(new SqlParameter("@f_durationdesc", Durationdesc));                        //เกิน  10
                cmd.Parameters.Add(new SqlParameter("@f_noteprocessing", Noteprocessing));
                cmd.Parameters.Add(new SqlParameter("@f_fromlocationname", Fromlocationname));
                cmd.Parameters.Add(new SqlParameter("@f_userorderby", Userorderby));
                cmd.Parameters.Add(new SqlParameter("@f_useracceptby", Useracceptby));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptdate", Orderacceptdate));
                cmd.Parameters.Add(new SqlParameter("@f_orderaccepttime", Orderaccepttime));
                cmd.Parameters.Add(new SqlParameter("@f_orderacceptfromip", Orderacceptformip));
                cmd.Parameters.Add(new SqlParameter("@f_patientdob", Patientdob));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotcode", Itemlotcode));
                cmd.Parameters.Add(new SqlParameter("@f_itemlotexpire", Itemlotexpire));
                cmd.Parameters.Add(new SqlParameter("@f_doctorcode", Doctorcode));
                cmd.Parameters.Add(new SqlParameter("@f_doctorname", Doctorname));
                cmd.Parameters.Add(new SqlParameter("@f_wardcode", Wardcode));
                cmd.Parameters.Add(new SqlParameter("@f_warddesc", Warddesc));
                cmd.Parameters.Add(new SqlParameter("@f_roomcode", Roomcode));
                cmd.Parameters.Add(new SqlParameter("@f_roomdesc", Roomdesc));
                cmd.Parameters.Add(new SqlParameter("@f_bedcode", Bedcode));
                cmd.Parameters.Add(new SqlParameter("@f_beddesc", Beddesc));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationcode", Pharmacylocationcode));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacylocationdesc", Pharmacylocationdesc));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacyitemcode", Pharmacyitemcode));
                cmd.Parameters.Add(new SqlParameter("@f_pharmacyitemdesc", Pharmacyitemdesc));
                cmd.Parameters.Add(new SqlParameter("@f_freetext1", Freetext1));
                cmd.Parameters.Add(new SqlParameter("@f_freetext2", Freetext2));
                cmd.Parameters.Add(new SqlParameter("@f_itemidentify", Itemidentify));
                cmd.Parameters.Add(new SqlParameter("@f_tomachineno", Tomachineno));
                cmd.Parameters.Add(new SqlParameter("@f_dispensestatus", Dispensestatus));
                cmd.Parameters.Add(new SqlParameter("@f_status", Status));
                cmd.Parameters.Add(new SqlParameter("@f_PRN", PRN));
                cmd.Parameters.Add(new SqlParameter("@f_frequencyTime", FrequencyTime));
                cmd.Parameters.Add(new SqlParameter("@f_language", Language));
                cmd.Parameters.Add(new SqlParameter("@f_dosagedispense", Dosagedispense));
                cmd.Parameters.Add(new SqlParameter("@f_comment", Comment));
                cmd.Parameters.Add(new SqlParameter("@f_freetext3", Freetext3));
                cmd.Parameters.Add(new SqlParameter("@Printstatus", Printstatus));
                cmd.Parameters.Add(new SqlParameter("@f_count", Count));
                cmd.Parameters.Add(new SqlParameter("@f_freetext4", Freetext4));
                cmd.Parameters.Add(new SqlParameter("@f_freetext5", Freetext5));
                //cmd.Parameters.Add(new SqlParameter("@imgbinary", Imgbinary));
                cmd.Parameters.Add(new SqlParameter("@f_freetext6", Freetext6));
                cmd.Parameters.Add(new SqlParameter("@IsExcludeFromIPFill", IsExcludeFromIPFill));
                cmd.Parameters.Add(new SqlParameter("@printIpFill", PrintIpFill));
                cmd.Parameters.Add(new SqlParameter("@Lab", Lab));
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
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@fprescriptionno,";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@fseq,";
            SQL += "dbo.tb_thaneshosp_middle.f_seqmax =@fseqmax,";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptiondate =@fprescriptiondate,";
            SQL += "dbo.tb_thaneshosp_middle.f_hn =@fhn,";
            SQL += "dbo.tb_thaneshosp_middle.f_en =@fen,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientname =@fpatientname,";
            SQL += "dbo.tb_thaneshosp_middle.f_sex =@fsex,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientepisodedate =@fpatientepisodedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritycode =@fprioritycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_prioritydesc =@fprioritydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargetdate =@fordertargetdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordertargettime =@fordertargettime,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatedate =@fordercreatedate,";
            SQL += "dbo.tb_thaneshosp_middle.f_ordercreatetime =@fordercreatetime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemcode =@forderitemcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderitemname =@forderitemname,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderqty =@forderqty,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitcode =@forderunitcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderunitdesc =@forderunitdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructioncode =@finstructioncode,";
            SQL += "dbo.tb_thaneshosp_middle.f_instructiondesc =@finstructiondesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosage =@fdosage,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosageunit =@fdosageunit,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencycode =@ffrequencycode,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencydesc =@ffrequencydesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationcode =@fdurationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_durationdesc =@fdurationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_noteprocessing =@fnoteprocessing,";
            SQL += "dbo.tb_thaneshosp_middle.f_fromlocationname =@ffromlocationname,";
            SQL += "dbo.tb_thaneshosp_middle.f_userorderby =@fuserorderby,";
            SQL += "dbo.tb_thaneshosp_middle.f_useracceptby =@fuseracceptby,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptdate =@forderacceptdate,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderaccepttime =@forderaccepttime,";
            SQL += "dbo.tb_thaneshosp_middle.f_orderacceptfromip =@forderacceptfromip,";
            SQL += "dbo.tb_thaneshosp_middle.f_patientdob =@fpatientdob,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotcode =@fitemlotcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemlotexpire =@fitemlotexpire,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorcode =@fdoctorcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_doctorname =@fdoctorname,";
            SQL += "dbo.tb_thaneshosp_middle.f_wardcode =@fwardcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_warddesc =@fwarddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomcode =@froomcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_roomdesc =@froomdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_bedcode =@fbedcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_beddesc =@fbeddesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationcode =@fpharmacylocationcode,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacylocationdesc =@fpharmacylocationdesc,";
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode =@fpharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc =@fpharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1 =@ffreetext1,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2 =@ffreetext2,";
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify =@fitemidentify,";
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno =@ftomachineno,";
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus =@fdispensestatus,";
            SQL += "dbo.tb_thaneshosp_middle.f_status =@fstatus,";
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified =@flastmodified,";
            SQL += "dbo.tb_thaneshosp_middle.f_PRN =@fPRN,";
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime =@ffrequencyTime,";
            SQL += "dbo.tb_thaneshosp_middle.f_language =@flanguage,";
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense =@fdosagedispense,";
            SQL += "dbo.tb_thaneshosp_middle.f_comment =@fcomment,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3 =@ffreetext3,";
            SQL += "dbo.tb_thaneshosp_middle.Printstatus =@Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count =@fcount,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4 =@ffreetext4,";
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5 =@ffreetext5,";
            SQL += "dbo.tb_thaneshosp_middle.imgbinary =@imgbinary,";                             //68
            SQL += "dbo.tb_thaneshosp_middle.f_freetext6 =@ffreetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill =@IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill =@printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab =@Lab ";                                   //72
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno = @fprescriptionno ";
            SQL += "AND ";
            SQL += "dbo.tb_thaneshosp_middle.f_seq =@fseq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@fprescriptionno", Prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@fseq", Seq));
                cmd.Parameters.Add(new SqlParameter("@fseqmax", Seqmax));
                cmd.Parameters.Add(new SqlParameter("@fprescriptiondate", Prescriptiondate));
                cmd.Parameters.Add(new SqlParameter("@fhn", Hn));
                cmd.Parameters.Add(new SqlParameter("@fen", En));
                cmd.Parameters.Add(new SqlParameter("@fpatientname", Patientname));
                cmd.Parameters.Add(new SqlParameter("@fsex", Sex));
                cmd.Parameters.Add(new SqlParameter("@fpatientepisodedate", Patientepisodedate));
                cmd.Parameters.Add(new SqlParameter("@fprioritycode", Prioritycode));
                cmd.Parameters.Add(new SqlParameter("@fprioritydesc", Prioritydesc));
                cmd.Parameters.Add(new SqlParameter("@fordertargetdate", Ordertargetdate));
                cmd.Parameters.Add(new SqlParameter("@fordertargettime", Ordertargettime));
                cmd.Parameters.Add(new SqlParameter("@fordercreatedate", Ordercreatedate));
                cmd.Parameters.Add(new SqlParameter("@fordercreatetime", Ordercreatetime));
                cmd.Parameters.Add(new SqlParameter("@forderitemcode", Orderitemcode));
                cmd.Parameters.Add(new SqlParameter("@forderitemname", Orderitemname));
                cmd.Parameters.Add(new SqlParameter("@forderqty", Orderqty));
                cmd.Parameters.Add(new SqlParameter("@forderunitcode", Orderunitcode));
                cmd.Parameters.Add(new SqlParameter("@forderunitdesc", Orderunitdesc));
                cmd.Parameters.Add(new SqlParameter("@finstructioncode", Instructioncode));
                cmd.Parameters.Add(new SqlParameter("@finstructiondesc", Instructiondesc));
                cmd.Parameters.Add(new SqlParameter("@fdosage", Dosage));
                cmd.Parameters.Add(new SqlParameter("@fdosageunit", Dosageunit));
                cmd.Parameters.Add(new SqlParameter("@ffrequencycode", Frequencycode));
                cmd.Parameters.Add(new SqlParameter("@ffrequencydesc", Frequencydesc));
                cmd.Parameters.Add(new SqlParameter("@fdurationcode", Durationcode));
                cmd.Parameters.Add(new SqlParameter("@fdurationdesc", Durationdesc));                        //เกิน  10
                cmd.Parameters.Add(new SqlParameter("@fnoteprocessing", Noteprocessing));
                cmd.Parameters.Add(new SqlParameter("@ffromlocationname", Fromlocationname));
                cmd.Parameters.Add(new SqlParameter("@fuserorderby", Userorderby));
                cmd.Parameters.Add(new SqlParameter("@fuseracceptby", Useracceptby));
                cmd.Parameters.Add(new SqlParameter("@forderacceptdate", Orderacceptdate));
                cmd.Parameters.Add(new SqlParameter("@forderaccepttime", Orderaccepttime));
                cmd.Parameters.Add(new SqlParameter("@forderacceptfromip", Orderacceptformip));
                cmd.Parameters.Add(new SqlParameter("@fpatientdob", Patientdob));
                cmd.Parameters.Add(new SqlParameter("@fitemlotcode", Itemlotcode));
                cmd.Parameters.Add(new SqlParameter("@fitemlotexpire", Itemlotexpire));
                cmd.Parameters.Add(new SqlParameter("@fdoctorcode", Doctorcode));
                cmd.Parameters.Add(new SqlParameter("@fdoctorname", Doctorname));
                cmd.Parameters.Add(new SqlParameter("@fwardcode", Wardcode));
                cmd.Parameters.Add(new SqlParameter("@fwarddesc", Warddesc));
                cmd.Parameters.Add(new SqlParameter("@froomcode", Roomcode));
                cmd.Parameters.Add(new SqlParameter("@froomdesc", Roomdesc));
                cmd.Parameters.Add(new SqlParameter("@fbedcode", Bedcode));
                cmd.Parameters.Add(new SqlParameter("@fbeddesc", Beddesc));
                cmd.Parameters.Add(new SqlParameter("@fpharmacylocationcode", Pharmacylocationcode));
                cmd.Parameters.Add(new SqlParameter("@fpharmacylocationdesc", Pharmacylocationdesc));
                cmd.Parameters.Add(new SqlParameter("@fpharmacyitemcode", Pharmacyitemcode));
                cmd.Parameters.Add(new SqlParameter("@fpharmacyitemdesc", Pharmacyitemdesc));
                cmd.Parameters.Add(new SqlParameter("@ffreetext1", Freetext1));
                cmd.Parameters.Add(new SqlParameter("@ffreetext2", Freetext2));
                cmd.Parameters.Add(new SqlParameter("@fitemidentify", Itemidentify));
                cmd.Parameters.Add(new SqlParameter("@ftomachineno", Tomachineno));
                cmd.Parameters.Add(new SqlParameter("@fdispensestatus", Dispensestatus));
                cmd.Parameters.Add(new SqlParameter("@fstatus", Status));
                cmd.Parameters.Add(new SqlParameter("@fPRN", PRN));
                cmd.Parameters.Add(new SqlParameter("@ffrequencyTime", FrequencyTime));
                cmd.Parameters.Add(new SqlParameter("@flanguage", Language));
                cmd.Parameters.Add(new SqlParameter("@fdosagedispense", Dosagedispense));
                cmd.Parameters.Add(new SqlParameter("@fcomment", Comment));
                cmd.Parameters.Add(new SqlParameter("@ffreetext3", Freetext3));
                cmd.Parameters.Add(new SqlParameter("@Printstatus", Printstatus));
                cmd.Parameters.Add(new SqlParameter("@fcount", Count));
                cmd.Parameters.Add(new SqlParameter("@ffreetext4", Freetext4));
                cmd.Parameters.Add(new SqlParameter("@ffreetext5", Freetext5));
                cmd.Parameters.Add(new SqlParameter("@imgbinary", Imgbinary));
                cmd.Parameters.Add(new SqlParameter("@ffreetext6", Freetext6));
                cmd.Parameters.Add(new SqlParameter("@IsExcludeFromIPFill", IsExcludeFromIPFill));
                cmd.Parameters.Add(new SqlParameter("@printIpFill", PrintIpFill));
                cmd.Parameters.Add(new SqlParameter("@Lab", Lab));
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
            //SQL += "dbo.tb_thaneshosp_middle.fseq =@fseq ";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", Prescriptionno));
                //cmd.Parameters.Add(new SqlParameter("@fseq", seq));
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
                cmd.Parameters.Add(new SqlParameter("@f_prescriptionno", Prescriptionno));
                cmd.Parameters.Add(new SqlParameter("@f_seq", Seq));
                cmd.Parameters.Add(new SqlParameter("@f_status", Status));
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

        //insert the data backup from TPNSTDCONNECTMIDDLE to TPNSTDCONNECTMIDDLEBAK.
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
        public DataSet GetDataDisplayDetailPrescription(string pprescriptionno)
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
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemcode,";                    //49
            SQL += "dbo.tb_thaneshosp_middle.f_pharmacyitemdesc,";                    //50
            SQL += "dbo.tb_thaneshosp_middle.f_freetext1,";                           //51
            SQL += "dbo.tb_thaneshosp_middle.f_freetext2,";                           //52
            SQL += "dbo.tb_thaneshosp_middle.f_itemidentify,";                        //53
            SQL += "dbo.tb_thaneshosp_middle.f_tomachineno,";                         //54
            SQL += "dbo.tb_thaneshosp_middle.f_dispensestatus,";                      //55
            SQL += "dbo.tb_thaneshosp_middle.f_status,";                              //56
            SQL += "dbo.tb_thaneshosp_middle.f_lastmodified,";                        //57
            SQL += "dbo.tb_thaneshosp_middle.f_PRN,";                                 //58
            SQL += "dbo.tb_thaneshosp_middle.f_frequencyTime,";                       //59
            SQL += "dbo.tb_thaneshosp_middle.f_language,";                            //60
            SQL += "dbo.tb_thaneshosp_middle.f_dosagedispense,";                      //61
            SQL += "dbo.tb_thaneshosp_middle.f_comment,";                             //62
            SQL += "dbo.tb_thaneshosp_middle.f_freetext3,";                           //63
            SQL += "dbo.tb_thaneshosp_middle.Printstatus,";                           //64
            SQL += "dbo.tb_thaneshosp_middle.f_count,";                               //65
            SQL += "dbo.tb_thaneshosp_middle.f_freetext4,";                           //66
            SQL += "dbo.tb_thaneshosp_middle.f_freetext5,";                           //67
            SQL += "dbo.tb_thaneshosp_middle.imgbinary,";                             //68
            SQL += "dbo.tb_thaneshosp_middle.f_freetext6,";                           //69
            SQL += "dbo.tb_thaneshosp_middle.IsExcludeFromIPFill,";                   //70
            SQL += "dbo.tb_thaneshosp_middle.printIpFill,";                           //71
            SQL += "dbo.tb_thaneshosp_middle.Lab ";                                   //72
            SQL += "FROM ";
            SQL += "dbo.tb_thaneshosp_middle ";
            SQL += "WHERE ";
            SQL += "dbo.tb_thaneshosp_middle.f_prescriptionno =@f_prescriptionno ";
            SQL += "ORDER BY dbo.tb_thaneshosp_middle.f_seq ASC";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.AddWithValue("@f_prescriptionno", pprescriptionno);
                return conn.FillSQL(cmd);
            }
        }
    }
}