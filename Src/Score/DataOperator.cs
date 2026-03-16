using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Data;
using System.Data.Common;
using System.Data;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;

namespace Score
{
    public class DataOperator
    {
        public static string OperatorNurse
        {
            get
            {
                return ExtendApplicationContext.Current.LoginUserContext.UserName;

            }
        }

        private static void DoError(Exception ex)
        {
            //Log.Error(ex);
            ////现在三种异常都一样处理，以后再处理
            //if (ex is BLLException)
            //{
            //    Wis.Anes.Framework.Utilities.Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            //}
            //else
            //{
            //    if (ex is DALException)
            //    {
            //        Wis.Anes.Framework.Utilities.Dialog.MessageBox(ex.Message, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        if (ex.Message.Contains("ORA-00001: 违反唯一约束条件 (PK_MED_VITAL_SIGNS_REC_TEMP)"))
            //        {
            //            Wis.Anes.Framework.Utilities.Dialog.MessageBox("输入的时间点数据已经存在,请找到相应的时间点进行录入,谢谢!", MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }


        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public static DateTime GetSysDate()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return DateTime.Now;
            }
        }

        public static int UpdateDataTable(DataTable dataTable, string tableName)
        {
            try
            {
                IDatabase database = DatabaseFactory.Create();
                return database.Update(dataTable, tableName);
            }
            catch (Exception ex)
            {
                DoError(ex);
                return 0;
            }
        }

        /// <summary>
        /// 更新患者评分结果
        /// </summary>
        /// <param name="PatientScoringResultDt">患者评分结果强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        public static int UpdatePatientScoringResult(Wis.Anes.BusinessEntity.Score.PatientScoringResultDataTable PatientScoringResultDt)
        {
            return UpdateDataTable(PatientScoringResultDt, "WIS_PAT_SCORING_RESULT");
            //try
            //{
            //    IDatabase database = DatabaseFactory.Create();
            //    return database.Update(PatientScoringResultDt, "WIS_PAT_SCORING_RESULT");
            //}
            //catch (Exception ex)
            //{
            //    DoError(ex);
            //    return 0;
            //}
        }

        public static int UpdateApache2ScoringResult(Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable dataTable)
        {
            return UpdateDataTable(dataTable, "WIS_SCORE_APACHE2_RESULT");
        }


        /// <summary>
        /// 获取患者Apache2评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分时间</param>
        /// <returns>Apache2评分明细记录数据集</returns>
        public static Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable GetApache2ScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable table = new Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetApache2ScoringResultDetailByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取患者评分结果强类型数据集
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分标准</param>
        /// <returns>评分结果强类型数据集</returns>
        public static Wis.Anes.BusinessEntity.Score.PatientScoringResultDataTable GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.PatientScoringResultDataTable table = new Wis.Anes.BusinessEntity.Score.PatientScoringResultDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraMethod = database.BuildDbParameter("method", DbType.DateTime, scoringMethod);
                string sql = StoredScript.Get("Score_GetPatientScoringResultDataByPatientInfoAndMethod");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraMethod });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }

        public static Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable GetDataApache2(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable table = new Wis.Anes.BusinessEntity.Score.Apache2ScoringResultDetailDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetApache2ScoringResultDetailByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取患者Tiss评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分时间</param>
        /// <returns>Tiss评分明细记录数据集</returns>
        public static Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable GetTissScoringResultDt(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable table = new Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetTissScoringResultDetalByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        public static Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable GetDataTiss(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable table = new Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetTissScoringResultDetalByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 更新Tiss评分明细记录
        /// </summary>
        /// <param name="TissResultDt">Tiss评分强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        public static int UpdateTissScoringResult(Wis.Anes.BusinessEntity.Score.TissScoringResultDetalDataTable TissResultDt)
        {
            return UpdateDataTable(TissResultDt, "WIS_SCORE_TISS_RESULT");
        }


        /// <summary>
        /// 获取患者Balthazar评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Balthazar评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable GetBalthazar(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetMedBalthazarScoringResultByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }

        /// <summary>
        /// 更新Balthazar评分
        /// </summary>
        /// <param name="NortTable">Balthazar评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateBalthazar(Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable BalthazarDataTable)
        {
            return UpdateDataTable(BalthazarDataTable, "MED_BALTHAZAR_SCORING_RESULT");
        }

        /// <summary>
        /// 更新Child-pugh评分
        /// </summary>
        /// <param name="NortTable">Child-pugh评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateChildPugh(Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable childpughDataTable)
        {
            return UpdateDataTable(childpughDataTable, "MED_CHILDPUGH_SCORING_RESULT");
        }


        /// <summary>
        /// 更新Goldman评分
        /// </summary>
        /// <param name="NortTable">Goldman评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateGoldman(Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable goldmanDataTable)
        {
            return UpdateDataTable(goldmanDataTable, "MED_GOLDMAN_SCORING_RESULT");
        }
        /// <summary>
        /// 获取患者Lutz评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Lutz评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable GetLutz(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetMedLutzScoringResultByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 获取患者Lutz评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        public static Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable GetDataLutz(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetMedLutzScoringResultByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 更新Lutz评分
        /// </summary>
        /// <param name="NortTable">Lutz评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateLutzScore(Wis.Anes.BusinessEntity.Score.MED_LUTZ_SCORING_RESULTDataTable lutzDataTable)
        {
            return UpdateDataTable(lutzDataTable, "MED_LUTZ_SCORING_RESULT");
        }
        /// <summary>
        /// 获取患者Pars评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Pars评分明细表</returns>

        public static Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable GetPars(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetMedParsScoringResultByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }

        /// <summary>
        /// 获取患者Pars评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Pars评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable GetDataPars(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetMedParsScoringResultByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        /// <summary>
        /// 更新Pars评分
        /// </summary>
        /// <param name="NortTable">Pars评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public static int UpdateParsScore(Wis.Anes.BusinessEntity.Score.WIS_SCORE_PARS_RESULTDataTable parsDataTable)
        {
            return UpdateDataTable(parsDataTable, "WIS_SCORE_PARS_RESULT");
        }
        /// <summary>
        /// 获取患者Goldman评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Goldman评分明细表</returns>

        /// <summary>
        /// 获取患者Goldman评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Goldman评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable GetGoldman(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetMedGoldmanScoringResultByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }

        }

        public static Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable GetDataGoldman(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_GOLDMAN_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetMedGoldmanScoringResultByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }

        }
        /// <summary>
        /// 获取患者Child-pugh评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>Child-pugh评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable GetChildPugh(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                DbParameter paraDateTime = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
                string sql = StoredScript.Get("Score_GetMedChildpughScoringResultByPatientInfoAndDateTime");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraDateTime });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
        public static Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable GetDataBalthazar(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_BALTHAZAR_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetMedBalthazarScoringResultByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }

        /// <summary>
        /// 获取患者Child-pugh评分明细记录
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>Child-pugh评分明细表</returns>
        public static Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable GetDataChildPugh(string patientID, decimal visitID, decimal depID)
        {
            try
            {
                Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable table = new Wis.Anes.BusinessEntity.Score.MED_CHILDPUGH_SCORING_RESULTDataTable();
                IDatabase database = DatabaseFactory.Create();
                DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
                DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
                DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
                string sql = StoredScript.Get("Score_GetMedChildpughScoringResultByPatientInfo");
                database.Fill(sql, table, new DbParameter[] { paraPatientID, paraVisitID, paraDepID });
                return table;
            }
            catch (Exception ex)
            {
                DoError(ex);
                return null;
            }
        }
    }
}
