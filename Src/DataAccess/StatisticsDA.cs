using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.BusinessEntity;
using System.Data.Common;
using Wis.Anes.Data;
using System.Data;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 统计类
    /// </summary>
    public partial class StatisticsDA 
    {
        public Statistics.DeptStatDataTable GetDeptStat(DateTime startTime, DateTime endTime)
        {
            Statistics.DeptStatDataTable data = new Statistics.DeptStatDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_DeptStatByTime");
            DbParameter startTimeParameter = database.BuildDbParameter("startTime", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("endTime", DbType.DateTime, endTime);

            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;

           // return GetData<StatQuery.DeptStatDataTable>(GetSQL("DeptStatByTime"), new object[] { startTime, endTime });
            //return new DeptStatAdapter().GetData(startTime, endTime);
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
            decimal Indicator = -1;
            if (indicator1)
            {
                Indicator = 0;
            }
            else if (indicator2)
            {
                Indicator = 1;
            }
            Statistics.AnesQueryDataTable data = new Statistics.AnesQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetAnesQuery");

            DbParameter anesDoctorParameter = database.BuildDbParameter("@ANES_DOCTOR ", DbType.String, anesDoctor);
            DbParameter operDoctorParameter = database.BuildDbParameter("SURGEON", DbType.String, operDoctor);
            DbParameter nurseParameter = database.BuildDbParameter("NURSE", DbType.String, nurse);

            DbParameter operatingDeptParameter = database.BuildDbParameter("DEPT", DbType.String, operatingDept);
            DbParameter anesMethodParameter = database.BuildDbParameter("ANES_METHOD", DbType.String, anesMethod);
            DbParameter sexParameter = database.BuildDbParameter("SEX", DbType.String, sex);

            DbParameter ageStartParameter = database.BuildDbParameter("AGESTART", DbType.Int32, ageStart);
            DbParameter ageEndParameter = database.BuildDbParameter("AGEEND", DbType.Int32, ageEnd);
            DbParameter operationNameParameter = database.BuildDbParameter("OPERNAME", DbType.String, operationName);

            DbParameter operScaleParameter = database.BuildDbParameter("OPERSCALE", DbType.String, operScale);
            DbParameter operDateStartParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, operDateStart);
            DbParameter operDateEndParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, operDateEnd);

            DbParameter indicatorParameter = database.BuildDbParameter("INDICATOR", DbType.Decimal, Indicator);

            database.Fill(sql, data, new DbParameter[] { anesDoctorParameter, operDoctorParameter, nurseParameter, operatingDeptParameter, anesMethodParameter, sexParameter, ageStartParameter ,
            ageEndParameter,operationNameParameter,operScaleParameter,operDateStartParameter,operDateEndParameter,indicatorParameter});

            return data;
            //return GetData<StatQuery.AnesQueryDataTable>(GetSQL("AnesQuery"), new object[] { anesDoctor, operDoctor, nurse
            //    , operatingDept, anesMethod, sex, ageStart, ageEnd, operationName, operScale,operDateStart, operDateEnd, Indicator});
            //return new StatQueryTableAdapters.AnesQueryTableAdapter().GetData(anesDoctor, operDoctor, nurse, operatingDept, anesMethod, sex, ageStart, ageEnd, operationName, operScale,
                                                                                           //operDateStart, operDateEnd, Indicator);
        }

        /// <summary>
        /// 获取取消手术查询统计信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>取消手术查询统计信息</returns>
        public Statistics.CancelAnesQueryDataTable GetCancelAnesQuery(DateTime startDate, DateTime endDate)
        {
            Statistics.CancelAnesQueryDataTable data = new Statistics.CancelAnesQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetCancelAnesQuery");

            DbParameter startDateParameter = database.BuildDbParameter("STATEDATE", DbType.DateTime, startDate);
            DbParameter endDateParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endDate);

            database.Fill(sql, data, new DbParameter[] { startDateParameter, endDateParameter });
            return data;
            //return GetData<StatQuery.CancelAnesQueryDataTable>(GetSQL("CancelAnesQuery"), new object[] { startDate, endDate });
            //return new StatQueryTableAdapters.CancelAnesQueryTableAdapter().GetData(startDate, endDate);
        }

        /// <summary>
        /// 获取工作量统计查询-按手术时间
        /// </summary>
        /// <param name="starTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="OpRoom">手术室</param>
        /// <param name="Dept">手术科室</param>
        /// <param name="Doctor">麻醉医生</param>
        /// <returns>工作量统计查询表</returns>
        public Statistics.WorkloadTimeQueryDataTable GetWorkloadTimeQuery(DateTime starTime, DateTime endTime, string OpRoom, string Dept, string Doctor)
        {
            Statistics.WorkloadTimeQueryDataTable data = new Statistics.WorkloadTimeQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetWorkloadTimeQuery");

            DbParameter starTimeParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, starTime);
            DbParameter endTimeParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endTime);

            DbParameter opRoomParameter = database.BuildDbParameter("OPRROOM", DbType.String, OpRoom);
            DbParameter deptParameter = database.BuildDbParameter("DEPTNAME", DbType.String, Dept);
            DbParameter doctorParameter = database.BuildDbParameter("DOCTOR", DbType.String, Doctor);

            database.Fill(sql, data, new DbParameter[] { starTimeParameter, endTimeParameter, opRoomParameter, deptParameter, doctorParameter });
            return data;
           // return GetData<StatQuery.WorkloadTimeQueryDataTable>(GetSQL("WorkloadTimeQuery"), new object[] { starTime, endTime, OpRoom, Dept, Doctor });
            //return new StatQueryTableAdapters.WorkloadTimeQueryTableAdapter().GetData(starTime, endTime, OpRoom, Dept, Doctor);
        }

        /// <summary>
        /// 获取工作量统计查询-按出入室时间
        /// </summary>
        /// <param name="starTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="OpRoom">手术室</param>
        /// <param name="Dept">手术科室</param>
        /// <param name="Doctor">麻醉医生</param>
        /// <returns>工作量统计查询表</returns>
        public Statistics.WorkloadTimeQueryDataTable GetWorkloadTimeQuery1(DateTime starTime, DateTime endTime, string OpRoom, string Dept, string Doctor)
        {
            Statistics.WorkloadTimeQueryDataTable data = new Statistics.WorkloadTimeQueryDataTable();
            string sql = StoredScript.Get("Stat_GetWorkloadTimeQueryBy");

            IDatabase database = DatabaseFactory.Create();

            DbParameter starTimeParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, starTime);
            DbParameter endTimeParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endTime);

            DbParameter opRoomParameter = database.BuildDbParameter("OPRROOM", DbType.String, OpRoom);
            DbParameter deptParameter = database.BuildDbParameter("DEPTNAME", DbType.String, Dept);
            DbParameter doctorParameter = database.BuildDbParameter("DOCTOR", DbType.String, Doctor);

            database.Fill(sql, data, new DbParameter[] { starTimeParameter, endTimeParameter, opRoomParameter, deptParameter, doctorParameter });
            return data;

           // return GetData<StatQuery.WorkloadTimeQueryDataTable>(GetSQL("WorkloadTimeQueryBy"), new object[] { starTime, endTime, OpRoom, Dept, Doctor });
            //return new StatQueryTableAdapters.WorkloadTimeQueryTableAdapter().GetDataBy(starTime, endTime, OpRoom, Dept, Doctor);
        }


        /// <summary>
        /// 获取工作量统计查询-按身份
        /// </summary>
        /// <param name="starTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="Dept">手术科室</param>
        /// <param name="Doctor">病人身份</param>
        /// <returns>工作量统计查询表</returns>
        public Statistics.IdentityQueryDataTable GetIdentityQuery(DateTime starTime, DateTime endTime, string dept, string patient)
        {
            Statistics.IdentityQueryDataTable data = new Statistics.IdentityQueryDataTable();
            string sql = StoredScript.Get("Stat_IdentityQuery");
            IDatabase database = DatabaseFactory.Create();

            DbParameter starTimeParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, starTime);
            DbParameter endTimeParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endTime);

            DbParameter deptParameter = database.BuildDbParameter("DEPTNAME", DbType.String, dept);
            DbParameter patientParameter = database.BuildDbParameter("IDENTITY", DbType.String, patient);

            database.Fill(sql, data, new DbParameter[] { starTimeParameter, endTimeParameter, deptParameter, patientParameter });
            return data;
           // return GetData<StatQuery.IdentityQueryDataTable>(GetSQL("IdentityQuery"), new object[] { starTime, endTime, dept, patient });
            //return new StatQueryTableAdapters.IdentityQueryTableAdapter().GetData(starTime, endTime, dept, patient);
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
            Statistics.DeptAnesCountQueryDataTable data = new Statistics.DeptAnesCountQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetDeptAnesCountQuery");

            DbParameter startDateParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, startDate);
            DbParameter endDateParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endDate);

            DbParameter deptNameParameter = database.BuildDbParameter("DEPTNAME", DbType.String, deptName);

            database.Fill(sql, data, new DbParameter[] { startDateParameter, endDateParameter, deptNameParameter });
            return data;
           //return GetData<StatQuery.DeptAnesCountQueryDataTable>(GetSQL("DeptAnesCountQuery"), new object[] { startDate, endDate, deptName });
            //return new StatQueryTableAdapters.DeptAnesCountQueryTableAdapter().GetData(startDate, endDate, deptName);
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
            Statistics.HospitalQueryDataTable data = new Statistics.HospitalQueryDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Stat_GetHospitalQuery");
            DbParameter startDateParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, startDate);
            DbParameter endDateParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endDate);

            DbParameter opRoomParameter = database.BuildDbParameter("OPERATROOM", DbType.String, opRoom);
            DbParameter deptNameParameter = database.BuildDbParameter("DEPTNAME", DbType.String, deptName);

            database.Fill(sql, data, new DbParameter[] { startDateParameter, endDateParameter, opRoomParameter, deptNameParameter });
            return data;
           // return GetData<StatQuery.HospitalQueryDataTable>(GetSQL("HospitalQuery"), new object[] { startDate, endDate, opRoom, deptName });
            //return new StatQueryTableAdapters.HospitalQueryTableAdapter().GetData(startDate, endDate, opRoom, deptName);
        }

        /// <summary>
        /// 获取手术工作量月对比表
        /// </summary>
        /// <param name="date">统计</param>
        /// <returns>手术工作量月对比表</returns>
        public Statistics.DeptAnesWorkByMonthDataTable GetDeptAnesWorkByMonth(DateTime date)
        {
            Statistics.DeptAnesWorkByMonthDataTable data = new Statistics.DeptAnesWorkByMonthDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Stat_DeptAnesWorkByMonth");

            DbParameter previousYearParameter = database.BuildDbParameter("PREVIOUSYEAR", DbType.Int32, date.AddYears(-1).Year);
            DbParameter yearParameter = database.BuildDbParameter("YEAR", DbType.Int32, date.Year);
            DbParameter monthParameter = database.BuildDbParameter("MONTH", DbType.Int32, date.Month);

            database.Fill(sql, data, new DbParameter[] { previousYearParameter, yearParameter, monthParameter });
            return data;
            //return GetData<StatQuery.DeptAnesWorkByMonthDataTable>(GetSQL("DeptAnesWorkByMonth"), new object[] {date.AddYears(-1).Year, date.Year, date.Month });
            //return new StatQueryTableAdapters.DeptAnesWorkByMonthTableAdapter().GetData(date.Year, date.Month, date.AddYears(-1).Year);
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
            Statistics.DeptAnesWorkByMonthDataTable data = new Statistics.DeptAnesWorkByMonthDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_DeptAnesWorkByQuarter");

            DbParameter previousYearParameter = database.BuildDbParameter("PREVIOUSYEAR", DbType.Int32, year - 1);
            DbParameter yearParameter = database.BuildDbParameter("YEAR", DbType.Int32, year);
            DbParameter startMonthParameter = database.BuildDbParameter("STARTMONTH", DbType.Int32, startMonth);
            DbParameter endMonthParameter = database.BuildDbParameter("ENDMONTH", DbType.Int32, endMonth);

            database.Fill(sql, data, new DbParameter[] { previousYearParameter, yearParameter, startMonthParameter, endMonthParameter });
            return data;
            //return GetData<StatQuery.DeptAnesWorkByMonthDataTable>(GetSQL("DeptAnesWorkByQuarter"), new object[] {year - 1, year, startMonth, endMonth });
            //return new StatQueryTableAdapters.DeptAnesWorkByMonthTableAdapter().GetDataByQuarter(year, startMonth, endMonth, year - 1);
        }
        /// <summary>
        /// 根据创建者得到查询条件
        /// </summary>
        /// <param name="creatorID"></param>
        /// <returns></returns>
        public Statistics.QueryCondDataTable GetQueryCondByUser(string creatorID, string condTitle)
        {
            Statistics.QueryCondDataTable data = new Statistics.QueryCondDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetQueryCondByUser");

            DbParameter creatorIdParameter = database.BuildDbParameter("CREATOR_ID", DbType.String, creatorID);
            DbParameter condTitleParameter = database.BuildDbParameter("COND_TITLE", DbType.String, condTitle);

            database.Fill(sql, data, new DbParameter[] { creatorIdParameter, condTitleParameter });
            return data;
           // return GetData<StatQuery.QueryCondDataTable>(GetSQL("QueryCond"), new object[] { creatorID, condTitle });
        }

        /// <summary>
        /// 根据创建者得到查询条件名称
        /// </summary>
        /// <param name="creatorID"></param>
        /// <returns></returns>
        public Statistics.QueryCondSelectionDataTable GetQueryCondSelectionByUser(string creatorID)
        {
            Statistics.QueryCondSelectionDataTable data = new Statistics.QueryCondSelectionDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetQueryCondSelection");
            DbParameter creatorIdParameter = database.BuildDbParameter("USER_NAME", DbType.String, creatorID);

            database.Fill(sql, data, new DbParameter[] { creatorIdParameter });
            return data;
           // return GetData<StatQuery.QueryCondSelectionDataTable>(GetSQL("QueryCondSelection"), new object[] { creatorID });
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="QueryCondDB"></param>
        /// <param name="QueryCondSelectionDB"></param>
        /// <returns></returns>
        public int AddQueryCond(Statistics.QueryCondDataTable QueryCondDB, Statistics.QueryCondSelectionDataTable QueryCondSelectionDB)
        {
            //********由于我不清楚下面两张表中行的状态是否已经为Add状态,为了安全,我这里手动将行状态设置成Add状态,如果传进来的参数已经是Add状态,则下面的代码可以删掉*********
            QueryCondDB.AcceptChanges();
            QueryCondSelectionDB.AcceptChanges();
            if (QueryCondDB != null)
            {
                foreach (Statistics.QueryCondRow drQueryCond in QueryCondDB.Rows)
                {
                    drQueryCond.SetAdded();
                   
                }
            }
            if (QueryCondSelectionDB != null)
            {
                foreach (Statistics.QueryCondSelectionRow drQueryCondSelection in QueryCondSelectionDB.Rows)
                {
                    drQueryCondSelection.SetAdded();
                }

            }
            //************************************************************ by leo 2011/1/27  ********************************************************************************
          
            IDatabase database = DatabaseFactory.Create();
            using (DbWrapTransaction transaction = database.CreateDbTransaction())
            {
                    database.Update(QueryCondDB, "WIS_QUERY_COND", transaction);
                    database.Update(QueryCondSelectionDB, "WIS_QUERY_COND_SELECTION", transaction);
                    transaction.Commit();
                    return 1;
         
            }
            
           



            //QueryCondTableAdapter _QueryCondTableAdapter = new QueryCondTableAdapter();
            //QueryCondSelectionTableAdapter _QueryCondSelectionTableAdapter = new QueryCondSelectionTableAdapter();

            //DbTransaction _DbTransaction = DataFunction.BeginTransaction(_QueryCondTableAdapter);
            //try
            //{

            //    DataFunction.SetTransaction(_QueryCondTableAdapter, _DbTransaction);
            //    if (QueryCondDB != null)
            //    {
            //        foreach (StatQuery.QueryCondRow drQueryCond in QueryCondDB.Rows)
            //        {

            //            _QueryCondTableAdapter.Insert(drQueryCond.COND_TYPE, drQueryCond.COND_TITLE, drQueryCond.CONDITION, drQueryCond.CREATOR_ID, drQueryCond.CREATE_DATE_TIME, drQueryCond.PERMISSION);
            //        }
            //    }
            //    if (QueryCondSelectionDB != null)
            //    {
            //        foreach (StatQuery.QueryCondSelectionRow drQueryCondSelection in QueryCondSelectionDB.Rows)
            //        {
            //            _QueryCondSelectionTableAdapter.Insert(drQueryCondSelection.USER_NAME, drQueryCondSelection.COND_TITLE);
            //        }

            //    }
            //    _DbTransaction.Commit();
            //    return 1;

            //}
            //catch
            //{
            //    _DbTransaction.Rollback();
            //    return -1;
            //}



        }

        public Statistics.HospitalQueryDataTable GetHospitalQueryDataTable(string fieldName, DateTime startDate, DateTime endDate, string operateRoom, string departName)
        {
            Statistics.HospitalQueryDataTable data = new Statistics.HospitalQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = string.Format(StoredScript.Get("LocalDataModelProxy_GetHospitalQueryDataTable"), fieldName);
            DbParameter startTimeParameter = database.BuildDbParameter("STARTDATE", DbType.DateTime, startDate);
            DbParameter endTimeParameter = database.BuildDbParameter("ENDDATE", DbType.DateTime, endDate);
            DbParameter operateRoomParameter = database.BuildDbParameter("OPERATROOM", DbType.String, operateRoom);
            DbParameter departNameParameter = database.BuildDbParameter("DEPTNAME", DbType.String, departName);


            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter, operateRoomParameter, departNameParameter });
            return data;
        }

        public DataTable GetPunctureQueryTable(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Stat_GetPunctureQueryTable");
            DbParameter startTimeParameter = database.BuildDbParameter("STARTTIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("ENDTIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter});
            return data;
        }
        public DataTable GetAnesthesiaMethod(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetAnesthesiaMethod");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }
        public DataTable GetASAGrade(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetASAGrade");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }
        public DataTable GetThreeReview(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetThreeReview");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }
        public DataTable GetInPACUCount(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetInPACUCount");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }
        public DataTable GetStewardScore4(DateTime startTime, DateTime endTime)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetStewardScore4");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter });
            return data;
        }




        public DataTable GetAnalyzeSpec(DateTime startTime, DateTime endTime, string itemSpec)
        {
            DataTable data = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            string sql = StoredScript.Get("Analyze_GetAnalyzeSpec");
            DbParameter startTimeParameter = database.BuildDbParameter("START_DATE_TIME", DbType.DateTime, startTime);
            DbParameter endTimeParameter = database.BuildDbParameter("END_DATE_TIME", DbType.DateTime, endTime);
            DbParameter itemSpecParameter = database.BuildDbParameter("ITEM_SPEC", DbType.String, itemSpec);

            database.Fill(sql, data, new DbParameter[] { startTimeParameter, endTimeParameter, itemSpecParameter });
            return data;
        }
    }
}
