using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ConHIS.Libary_Class
{
    internal class JSDDNET_Drug
    {
        //Fields And Properties
        private string runningno;                         
        private string drugCd1;                            //Field 22
        private string drugCd2;                            //Field 22
        private string drugName;                          //Field 23
        private string drugBarcode1;                      //Field 73
        private string drugBarcode2;                      //Field 74
        private string unitCd;

        private string strConnectionString;
     

        private System_logfile logs;

        [StringLength(12, ErrorMessage = "Runningno : ขนาดข้อมูลเกิน 12 ตัวอักษร ")]
        public string Runningno { get => runningno; set => runningno = value; }

        [StringLength(50, ErrorMessage = "DrugCd1 : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string DrugCd1 { get => drugCd1; set => drugCd1 = value; }

        [StringLength(50, ErrorMessage = "DrugCd2 : ขนาดข้อมูลเกิน 50 ตัวอักษร ")]
        public string DrugCd2 { get => drugCd2; set => drugCd2 = value; }

        [StringLength(230, ErrorMessage = "DrugName : ขนาดข้อมูลเกิน 230 ตัวอักษร ")]
        public string DrugName { get => drugName; set => drugName = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode1 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode1 { get => drugBarcode1; set => drugBarcode1 = value; }

        [StringLength(14, ErrorMessage = "DrugBarcode2 : ขนาดข้อมูลเกิน 14 ตัวอักษร ")]
        public string DrugBarcode2 { get => drugBarcode2; set => drugBarcode2 = value; }

        [StringLength(8, ErrorMessage = "UnitCd : ขนาดข้อมูลเกิน 8 ตัวอักษร ")]
        public string UnitCd { get => unitCd; set => unitCd = value; }
      

        public JSDDNET_Drug(string DBName)
        {
            strConnectionString = Variable.DBlocal.Replace("Catalog=CONHIS_MIDDLE_V4", "Catalog="+ DBName);

            logs = new System_logfile();
        }

        public DataSet GetDisplayDataGridViewFullDetail(string condition)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(strConnectionString);
            SQL += "SELECT ";
            SQL += "M_Drug.vc_DrugCd,";
            SQL += "M_Drug.vc_DrugNm,";
            SQL += "M_Drug.vc_DrugRuby, ";
            SQL += "M_Drug.ln_PacImageFile_Print_pri, ";
            SQL += "M_Drug.vc_DrugKind, ";
            SQL += "M_Drug.vc_PreShapeCd,";
            SQL += "M_Drug.vc_JanCd1,";
            SQL += "M_Drug.vc_JanCd2,";
            SQL += "M_Drug.vc_PrepareUnitCd,";
            SQL += "M_Drug.vc_HostCd1, ";
            SQL += "M_Drug.vc_HostCd2, ";
            SQL += "M_Drug.vc_StabilityCoefficient,";
            SQL += "M_Drug.vc_ExposeFlg,";
            SQL += "M_Drug.vc_HeatFlg,";
            SQL += "M_Drug.vc_SecantFlg, ";
            SQL += "M_Drug.vc_SmashFlg,";
            SQL += "M_Drug.vc_AcidAlkaliFlg,";
            SQL += "M_Drug.vc_SingleFlg, ";
            SQL += "M_Drug.vc_PrescriptionAuditFlg,";
            SQL += "M_Drug.vc_HalfOriginal, ";
            SQL += "M_Drug.vc_ScrapOriginal,";
            SQL += "M_Drug.vc_ReservationOriginal,";
            SQL += "M_Drug.vc_LabelFlg,";
            SQL += "M_Drug.vc_JRepeatFlg,";
            SQL += "M_Drug.ln_EfficacyFigure,";
            SQL += "M_Drug.vc_DrugInfoOutFlg, ";
            SQL += "M_Drug.vc_DrugHistoryOutFlg,";
            SQL += "M_Drug.vc_DissolvePowder, ";
            SQL += "M_Drug.vc_GranuleFlg, ";
            SQL += "M_Drug.vc_NarcoticFlg, ";
            SQL += "M_Drug.vc_ReagentFlg, ";
            SQL += "M_Drug.vc_InvestigationFlg,";
            SQL += "M_Drug.vc_AnticancerFlg, ";
            SQL += "M_Drug.vc_BloodProductsFlg,";
            SQL += "M_Drug.vc_StrongPoisonFlg, ";
            SQL += "M_Drug.vc_AntibioticsFlg, ";
            SQL += "M_Drug.vc_DiabetesFlg, ";
            SQL += "M_Drug.vc_PreservationFlg,";
            SQL += "M_Drug.vc_ThyroidGlandFlg, ";
            SQL += "M_Drug.vc_ErasureFlg, ";
            SQL += "M_Drug.vc_PsychotropicFlg,";
            SQL += "M_Drug.vc_SexCkeckFlg, ";
            SQL += "M_Drug.vc_ExsCouplingFlg,";
            SQL += "M_Drug.vc_WashFlg, ";
            SQL += "M_Drug.vc_HerbalMedicineFlg,";
            SQL += "M_Drug.vc_WaterMedicineStandardFlg,";
            SQL += "M_Drug.ln_PrintColor, ";
            SQL += "M_Drug.ln_DspColorCd, ";
            SQL += "M_Drug.vc_ConnExs, ";
            SQL += "M_Drug.dt_LastUpdateDate, ";
            SQL += "M_Drug.vc_ComputerNm, ";
            SQL += "M_Drug.vc_UserNm, ";
            SQL += "M_Drug.vc_ProgramNm,";
            SQL += "M_Drug.vc_HisDrugNm,";
            SQL += "M_Drug.vc_UnUsedDivision, ";
            SQL += "M_Drug.vc_CalibrationFlg";
            SQL += "FROM ";
            SQL += "dbo.M_Drug ";
            SQL += "ORDER BY ";
            SQL += "dbo.M_Drug.vc_DrugCd ASC";

            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return conn.FillSQL(cmd);
            }
        }

        public bool InsertDataDrug()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(strConnectionString);
            SQL += "INSERT INTO dbo.M_Drug (";
            SQL += "M_Drug.vc_DrugCd,";
            SQL += "M_Drug.vc_DrugNm,";
            SQL += "M_Drug.vc_DrugRuby, ";
            SQL += "M_Drug.ln_PacImageFile_Print_pri, ";
            SQL += "M_Drug.vc_DrugKind, ";
            SQL += "M_Drug.vc_PreShapeCd,";
            SQL += "M_Drug.vc_JanCd1,";
            SQL += "M_Drug.vc_JanCd2,";
            SQL += "M_Drug.vc_PrepareUnitCd,";
            SQL += "M_Drug.vc_HostCd1, ";
            SQL += "M_Drug.vc_HostCd2, ";
            SQL += "M_Drug.vc_StabilityCoefficient,";
            SQL += "M_Drug.vc_ExposeFlg,";
            SQL += "M_Drug.vc_HeatFlg,";
            SQL += "M_Drug.vc_SecantFlg, ";
            SQL += "M_Drug.vc_SmashFlg,";
            SQL += "M_Drug.vc_AcidAlkaliFlg,";
            SQL += "M_Drug.vc_SingleFlg, ";
            SQL += "M_Drug.vc_PrescriptionAuditFlg,";
            SQL += "M_Drug.vc_HalfOriginal, ";
            SQL += "M_Drug.vc_ScrapOriginal,";
            SQL += "M_Drug.vc_ReservationOriginal,";
            SQL += "M_Drug.vc_LabelFlg,";
            SQL += "M_Drug.vc_JRepeatFlg,";
            SQL += "M_Drug.ln_EfficacyFigure,";
            SQL += "M_Drug.vc_DrugInfoOutFlg, ";
            SQL += "M_Drug.vc_DrugHistoryOutFlg,";
            SQL += "M_Drug.vc_DissolvePowder, ";
            SQL += "M_Drug.vc_GranuleFlg, ";
            SQL += "M_Drug.vc_NarcoticFlg, ";
            SQL += "M_Drug.vc_ReagentFlg, ";
            SQL += "M_Drug.vc_InvestigationFlg,";
            SQL += "M_Drug.vc_AnticancerFlg, ";
            SQL += "M_Drug.vc_BloodProductsFlg,";
            SQL += "M_Drug.vc_StrongPoisonFlg, ";
            SQL += "M_Drug.vc_AntibioticsFlg, ";
            SQL += "M_Drug.vc_DiabetesFlg, ";
            SQL += "M_Drug.vc_PreservationFlg,";
            SQL += "M_Drug.vc_ThyroidGlandFlg, ";
            SQL += "M_Drug.vc_ErasureFlg, ";
            SQL += "M_Drug.vc_PsychotropicFlg,";
            SQL += "M_Drug.vc_SexCkeckFlg, ";
            SQL += "M_Drug.vc_ExsCouplingFlg,";
            SQL += "M_Drug.vc_WashFlg, ";
            SQL += "M_Drug.vc_HerbalMedicineFlg,";
            SQL += "M_Drug.vc_WaterMedicineStandardFlg,";
            SQL += "M_Drug.ln_PrintColor, ";
            SQL += "M_Drug.ln_DspColorCd, ";
            SQL += "M_Drug.vc_ConnExs, ";
            SQL += "M_Drug.dt_LastUpdateDate, ";
            SQL += "M_Drug.vc_ComputerNm, ";
            SQL += "M_Drug.vc_UserNm, ";
            SQL += "M_Drug.vc_ProgramNm,";
            SQL += "M_Drug.vc_HisDrugNm,";
            SQL += "M_Drug.vc_UnUsedDivision, ";
            SQL += "M_Drug.vc_CalibrationFlg) ";
            SQL += "VALUES (";
            SQL += "@vc_DrugCd,";
            SQL += "@vc_DrugNm,";
            SQL += "@vc_DrugRuby, ";
            SQL += "0, ";
            SQL += "01, ";
            SQL += "11,";
            SQL += "@vc_JanCd1,";
            SQL += "@vc_JanCd2,";
            SQL += "@vc_PrepareUnitCd,";
            SQL += "@vc_HostCd1, ";
            SQL += "@vc_HostCd2, ";
            SQL += "1,";
            SQL += "0,";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "2,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0,";
            SQL += "0,";
            SQL += "0,";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0, ";
            SQL += "1,";
            SQL += "0, ";
            SQL += "0,";
            SQL += "0,";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "0, ";
            SQL += "GETDATE(), ";
            SQL += "@vc_ComputerNm, ";
            SQL += "@vc_UserNm, ";
            SQL += "@vc_ProgramNm,";
            SQL += "@vc_HisDrugNm,";
            SQL += "0, ";
            SQL += "0) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(SQL))
                {
                    if (GetCountData() != 0)
                        Runningno = (GetCountData() + 1).ToString().PadLeft(3, '0');
                    else
                        Runningno = "001";

                    cmd.Parameters.Add(new SqlParameter("@vc_DrugCd",Runningno));
                    cmd.Parameters.Add(new SqlParameter("@vc_DrugNm",DrugName));
                    cmd.Parameters.Add(new SqlParameter("@vc_DrugRuby",DrugName.Substring(0,1).ToUpper()));
                    cmd.Parameters.Add(new SqlParameter("@vc_JanCd1", Runningno.PadLeft(10,'0')));
                    cmd.Parameters.Add(new SqlParameter("@vc_JanCd2",DrugBarcode2));
                    cmd.Parameters.Add(new SqlParameter("@vc_PrepareUnitCd",UnitCd));
                    cmd.Parameters.Add(new SqlParameter("@vc_HostCd1", DrugCd1));
                    cmd.Parameters.Add(new SqlParameter("@vc_HostCd2",DrugCd2));
                    cmd.Parameters.Add(new SqlParameter("@vc_ComputerNm", "HC_PROUD"));
                    cmd.Parameters.Add(new SqlParameter("@vc_UserNm", "Yuyama"));
                    cmd.Parameters.Add(new SqlParameter("@vc_ProgramNm", "M_Drug"));
                    cmd.Parameters.Add(new SqlParameter("@vc_HisDrugNm", DrugName.ToUpper()));

                    return conn.ExecuteNonQuerySQL(cmd);
                }
            }
            catch (Exception e) { throw new Exception("Class JSDDNET_Drug Error => InsertDataDrug :" + e.Message); }
        }

        public int GetDrugCodeCheck(string DrugCd)
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(strConnectionString);
            SQL += "SELECT ";
            SQL += "COUNT(dbo.M_Drug.vc_HostCd1)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_Drug ";
            SQL += "WHERE ";
            SQL += "dbo.M_Drug.vc_HostCd1 = @DrugCd ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                cmd.Parameters.Add(new SqlParameter("@DrugCd", DrugCd));
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }

        public int GetCountData()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(strConnectionString);
            SQL += "SELECT ";
            SQL += "COUNT(*)As CountItems ";
            SQL += "FROM ";
            SQL += "dbo.M_Drug ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }

        public int GetMaxDataRow()
        {
            string SQL = null;
            Connection_sqlserver conn = new Connection_sqlserver(strConnectionString);
            SQL += "SELECT ";
            SQL += "MAX(dbo.M_Drug.vc_DrugCd)As MaxItems ";
            SQL += "FROM ";
            SQL += "dbo.M_Drug ";
            using (SqlCommand cmd = new SqlCommand(SQL))
            {
                return (int)conn.ExecuteScalarSQL(cmd);
            }
        }
    }
}