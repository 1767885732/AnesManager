/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：Analgesic.cs
      // 文件功能描述：镇痛接口本地实现类
      //
      // 
      // 创建标识：XXX-2011-02-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Wis.Anes.Data;
using System.Data.Common;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.DataAccess
{
    public class ScoreDA
    {

        /// <summary>
        /// APA表明细信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        /// <returns>meds评分明细表</returns>
        public Score.WIS_SCORE_APA_RESULTDataTable GetAPAInfo(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime)
        {
            Score.WIS_SCORE_APA_RESULTDataTable data = new Score.WIS_SCORE_APA_RESULTDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Score_GetAPAInfo");
            DbParameter patientIdParameter = database.BuildDbParameter("patientID", DbType.String, patientID);
            DbParameter visitIdParameter = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
            DbParameter OperIdParameter = database.BuildDbParameter("depID", DbType.Decimal, depID);
            DbParameter datetimePara = database.BuildDbParameter("dateTime", DbType.DateTime, scoringDateTime);
            database.Fill(sql, data, new DbParameter[] { patientIdParameter, visitIdParameter, OperIdParameter, datetimePara });
            return data;
        }
        /// <summary>
        /// APA表明细信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <returns>meds评分明细表</returns>
        public Score.WIS_SCORE_APA_RESULTDataTable GetAPAInfo(string patientID, decimal visitID, decimal depID)
        {
            return DatabaseFactory.Create().GetTable<Score.WIS_SCORE_APA_RESULTDataTable>("WIS_SCORE_APA_RESULT");
        }
        /// <summary>
        /// 更新 APA表
        /// </summary>
        /// <param name="CramsTable"> meds评分强类型数据集</param>
        /// <returns>更新影响行数</returns>
        public int UpdateAPA(Score.WIS_SCORE_APA_RESULTDataTable dataTable)
        {
            return DatabaseFactory.Create().Update(dataTable, "WIS_SCORE_APA_RESULT");
        }

        /// <summary>
        /// 获取患者评分结果强类型数据集
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分标准</param>
        /// <returns>评分结果强类型数据集</returns>
        public Score.PatientScoringResultDataTable GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod)
        {
            Score.PatientScoringResultDataTable data = new Score.PatientScoringResultDataTable();
            IDatabase database = DatabaseFactory.Create();
            DbParameter paraPatientID = database.BuildDbParameter("patientID", DbType.AnsiString, patientID);
            DbParameter paraVisitID = database.BuildDbParameter("visitID", DbType.Decimal, visitID);
            DbParameter paraDepID = database.BuildDbParameter("depID", DbType.Decimal, depID);
            DbParameter paraMethod = database.BuildDbParameter("method", DbType.DateTime, scoringMethod);
            string sql = StoredScript.Get("Score_GetPatientScoringResultDt");
            database.Fill(sql, data, new DbParameter[] { paraPatientID, paraVisitID, paraDepID, paraMethod });
            return data;
        }

        /// <summary>
        /// 更新患者评分结果
        /// </summary>
        /// <param name="PatientScoringResultDt">患者评分结果强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        public int UpdatePatientScoringResult(Score.PatientScoringResultDataTable PatientScoringResultDt)
        {
            return DatabaseFactory.Create().Update(PatientScoringResultDt, "WIS_PAT_SCORING_RESULT");
        }
    }
}
