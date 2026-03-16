using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessEntity;
using System.Data;
using Wis.Anes.DataAccess;

namespace Wis.Anes.BusinessComponent
{
    public class StatisticsBC : IStatistics
    {


        public Statistics.DeptStatDataTable GetDeptStat(DateTime startTime, DateTime endTime)
        {
            return (new StatisticsDA()).GetDeptStat(startTime, endTime);
        }
        /// <summary>
        /// 获取手术查询统计信息
        /// </summary>
        /// <param name="anesDoctor">麻醉医生</param>
        /// <param name="operDoctor">手术医生</param>
        /// <param name="nurse">护士</param>
        /// <param name="operatingDept">手术科室</param>
        /// <param name="anesMethod">麻醉方法</param>
        /// <param name="sex">性别</param>
        /// <param name="ageStart">起始年龄</param>
        /// <param name="ageEnd">结束年龄</param>
        /// <param name="operationName">手术名称</param>
        /// <param name="operScale">手术规模</param>
        /// <param name="operDateStart">手术起始日期</param>
        /// <param name="operDateEnd">手术截至日期</param>
        /// <param name="indicator1">急诊</param>
        /// <param name="indicator2">择期</param>
        /// <returns></returns>
        public Statistics.AnesQueryDataTable GetAnesQuery(string anesDoctor, string operDoctor, string nurse, string operatingDept, string anesMethod, string sex, int ageStart,
                                                               int ageEnd, string operationName, string operScale, DateTime operDateStart, DateTime operDateEnd, bool indicator1, bool indicator2)
        {
            return (new StatisticsDA()).GetAnesQuery(anesDoctor, operDoctor, nurse, operatingDept, anesMethod, sex, ageStart,
                                                               ageEnd, operationName, operScale, operDateStart, operDateEnd, indicator1, indicator2);
        }
        /// <summary>
        /// 获取取消手术查询统计信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>取消手术查询统计信息</returns>
        public Statistics.CancelAnesQueryDataTable GetCancelAnesQuery(DateTime startDate, DateTime endDate)
        {
            return (new StatisticsDA()).GetCancelAnesQuery(startDate, endDate);
        }


        /// <summary>
        /// 获取取消手术查询统计信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>取消手术查询统计信息</returns>
        public Statistics.WorkloadTimeQueryDataTable GetWorkloadTimeQuery(DateTime starTime, DateTime endTime, string OpRoom, string Dept, string Doctor)
        {
            return (new StatisticsDA()).GetWorkloadTimeQuery(starTime, endTime, OpRoom, Dept, Doctor);
        }

        /// <summary>
        /// 获取取消手术查询统计信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>取消手术查询统计信息</returns>
        public Statistics.WorkloadTimeQueryDataTable GetWorkloadTimeQuery1(DateTime starTime, DateTime endTime, string OpRoom, string Dept, string Doctor)
        {
            return (new StatisticsDA()).GetWorkloadTimeQuery1(starTime, endTime, OpRoom, Dept, Doctor);
        }

        /// <summary>
        /// 获取取消手术查询统计信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>取消手术查询统计信息</returns>
        public Statistics.IdentityQueryDataTable GetIdentityQuery(DateTime starTime, DateTime endTime, string dept, string patient)
        {
            return (new StatisticsDA()).GetIdentityQuery(starTime, endTime, dept, patient);
        }

        /// <summary>
        /// 获取科室手术例数统计
        /// </summary>
        /// <param name="startDate">查询开始日期</param>
        /// <param name="endDate">查询截止日期</param>
        /// <param name="deptName">科室名称</param>
        /// <returns>科室手术例数统计数据集</returns>
        public Statistics.DeptAnesCountQueryDataTable GetDeptAnesCountQuery(DateTime startDate, DateTime endDate, string deptName)
        {
            return (new StatisticsDA()).GetDeptAnesCountQuery(startDate, endDate, deptName);
        }


        /// <summary>
        /// 全院统计
        /// </summary>
        /// <param name="startDate">查询开始日期</param>
        /// <param name="endDate">查询截止日期</param>
        /// <param name="opRoom">手术室</param>
        /// <param name="deptName">科室名称</param>
        /// <returns></returns>
        public Statistics.HospitalQueryDataTable GetHospitalQuery(DateTime startDate, DateTime endDate, string opRoom, string deptName)
        {
            return (new StatisticsDA()).GetHospitalQuery(startDate, endDate, opRoom, deptName);
        }

        /// <summary>
        /// 获取手术工作量月对比表
        /// </summary>
        /// <param name="date">统计</param>
        /// <returns>手术工作量月对比表</returns>
        public Statistics.DeptAnesWorkByMonthDataTable GetDeptAnesWorkByMonth(DateTime date)
        {
            return (new StatisticsDA()).GetDeptAnesWorkByMonth(date);
        }

        /// <summary>
        /// 获取手术工作量季度对比表
        /// </summary>
        /// <param name="year">统计年</param>
        /// <param name="startMonth">统计起始月</param>
        /// <param name="endMonth">统计结束月</param>
        /// <returns>手术工作量季度对比表</returns>
        public Statistics.DeptAnesWorkByMonthDataTable GetDeptAnesWorkByQuarter(int year, int startMonth, int endMonth)
        {
            return (new StatisticsDA()).GetDeptAnesWorkByQuarter(year, startMonth, endMonth);
        }
        /// <summary>
        /// 根据创建者得到查询条件
        /// </summary>
        /// <param name="creatorID"></param>
        /// <returns></returns>
        public Statistics.QueryCondDataTable GetQueryCondByUser(string creatorID, string condTitle)
        {
            return (new StatisticsDA()).GetQueryCondByUser(creatorID, condTitle);
        }
        /// <summary>
        /// 根据创建者得到查询条件名称
        /// </summary>
        /// <param name="creatorID"></param>
        /// <returns></returns>
        public Statistics.QueryCondSelectionDataTable GetQueryCondSelectionByUser(string creatorID)
        {
            return (new StatisticsDA()).GetQueryCondSelectionByUser(creatorID);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="QueryCondDB"></param>
        /// <param name="QueryCondSelectionDB"></param>
        /// <returns></returns>
        public int AddQueryCond(Statistics.QueryCondDataTable QueryCondDB, Statistics.QueryCondSelectionDataTable QueryCondSelectionDB)
        {
            return (new StatisticsDA()).AddQueryCond(QueryCondDB, QueryCondSelectionDB);

        }
        public Statistics.HospitalQueryDataTable GetHospitalQueryDataTable(string fieldName, DateTime startDate, DateTime endDate, string operateRoom, string departName)
        {
            return (new StatisticsDA()).GetHospitalQueryDataTable(fieldName, startDate, endDate, operateRoom, departName);
        }

        public DataTable GetPunctureQueryTable(DateTime startTime, DateTime endTime)
        {
            return (new StatisticsDA()).GetPunctureQueryTable(startTime, endTime);
        }
    }
}
