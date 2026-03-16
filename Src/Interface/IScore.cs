/*----------------------------------------------------------------
 // Copyright (C) 2007 北京拓扑工厂科技发展有限公司
 // 文件名：IScore.cs
 // 文件功能描述：
 //      评分接口类
 // 
 // 创建标识：
 //     XXX 2011-8-30
 // 修改标识：
 // 修改描述：
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Interface
{
    /// <summary>
    /// 评分接口类
    /// </summary>
    public interface IScore
    {
        ///<summary>
        ///更新APA评分信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>

        int UpdateAPA(Score.WIS_SCORE_APA_RESULTDataTable medsDataTable);
        ///<summary>
        /// APA评分明细信息
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringDateTime">评分时间</param>
        Score.WIS_SCORE_APA_RESULTDataTable GetAPAInfo(string patientID, decimal visitID, decimal depID, DateTime scoringDateTime);
        Score.WIS_SCORE_APA_RESULTDataTable GetAPAInfo(string patientID, decimal visitID, decimal depID);
        /// <summary>
        /// 获取患者评分结果强类型数据集
        /// </summary>
        /// <param name="patientID">病人ID</param>
        /// <param name="visitID">住院标识</param>
        /// <param name="scoringMethod">评分标准</param>
        /// <returns>评分结果强类型数据集</returns>
        Score.PatientScoringResultDataTable GetPatientScoringResultDt(string patientID, decimal visitID, decimal depID, string scoringMethod);
        /// <summary>
        /// 更新患者评分结果
        /// </summary>
        /// <param name="PatientScoringResultDt">患者评分结果强类型数据集</param>
        /// <returns>更新影响的行数</returns>
        int UpdatePatientScoringResult(Score.PatientScoringResultDataTable PatientScoringResultDt);
    }
}
