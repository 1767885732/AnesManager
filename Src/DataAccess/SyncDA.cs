/*----------------------------------------------------------------
      // Copyright (C) 2008 北京拓扑工厂科技发展有限公司
      // 文件名：Common.cs
      // 文件功能描述：公共接口本地实现类
      //
      // 
      // 创建标识：XXX-2011-02-22
      //
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.BusinessEntity;
using System.IO;
using Wis.Anes.Data;
using System.Data.Common;
using System.Configuration;

namespace Wis.Anes.DataAccess
{
    /// <summary>
    /// 公共接口本地实现类
    /// </summary>
    public partial class SyncDA
    {
        private static string RunInterFace(string strapptype, string assystemclass, string asinterfacetype, WisServiceReference.ParmInputData parmIn)
        {
            //return InterFaceV4.InterFaceV4.of_systeminterface(strapptype, assystemclass, asinterfacetype, parmIn);            

            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string value = config.AppSettings.Settings["WSURL"].Value;
                if (value.ToUpper().Contains("?WSDL"))
                {
                    value = value.Replace("?WSDL", "");
                }

                using (var docareWebServices = new WisServiceReference.WebServices())
                {
                    docareWebServices.Timeout = 600000;
                    docareWebServices.Url = value;
                    return docareWebServices.SyncInterface(strapptype, assystemclass, asinterfacetype, parmIn);
                }
            }
            catch (Exception ex)
            {
                Logger.Write(" 同步检验错误 " + ex.Message);

                Logger.Write("RecordInterFaceLog Read key RecordInterfaceLog Err " + ex.StackTrace);
            }

            return "";
        }
        private static void RecordInterFaceLog(string strapptype, string assystemclass, string asinterfacetype, string parmInData)
        {
            bool bRecordInterfaceLog = false;
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string value = config.AppSettings.Settings["RecordInterfaceLog"].Value;
                if (!bool.TryParse(value, out bRecordInterfaceLog))
                {
                    bRecordInterfaceLog = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("RecordInterFaceLog Read key RecordInterfaceLog Err " + ex.StackTrace);
            }

            if (bRecordInterfaceLog)
            {
                Logger.Write("调用接口，传入参数 【AppType】:" + strapptype + " ，【SyatemClass】:" + assystemclass + "，【InterfaceType】:" + asinterfacetype + "，【ParmInputData】:" + parmInData);

            }
        }

        ///// <summary>
        /// 同步供应室物品信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public string SyncQiXieBao(string barCode)
        {
            if (!string.IsNullOrEmpty(barCode))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.reserved01 = barCode;

                string parmInString = "";
                parmInString = "reserved01 : " + inputPara.reserved01;
                RecordInterFaceLog("ANESMGR", "CSSD", "CSSD001", parmInString);

                string ret = RunInterFace("ANESMGR", "CSSD", "CSSD001", inputPara);
                return ret;
            }
            else
            {
                return "空的条形码";
            }
        }

        /// <summary>
        ///回传供应室物品使用信息
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public string SyncReturnQiXieBao(string barCode, string patientID, string patientName, string inpNo, string operationName, DateTime operDate, string operRoomNo)
        {
            if (!string.IsNullOrEmpty(barCode))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.reserved01 = barCode;
                inputPara.reserved02 = patientID;
                inputPara.reserved03 = patientName;
                inputPara.reserved04 = inpNo;
                inputPara.reserved05 = operationName;
                inputPara.reserved06 = operRoomNo;
                inputPara.reserved14 = operDate;


                string parmInString = "";
                parmInString = "reserved01 : " + inputPara.reserved01;
                parmInString += " reserved02 : " + inputPara.reserved02;
                parmInString += " reserved03 : " + inputPara.reserved03;
                parmInString += " reserved04 : " + inputPara.reserved04;
                parmInString += " reserved05 : " + inputPara.reserved05;
                parmInString += " reserved06 : " + inputPara.reserved06;
                parmInString += " reserved14 : " + inputPara.reserved14.ToString("yyyy-MM-dd"); ;
                RecordInterFaceLog("ANESMGR", "CSSD", "CSSD001", parmInString);


                string ret = RunInterFace("ANESMGR", "CSSD", "CSSD201", inputPara);
                return ret;
            }
            else
            {
                return "空的条形码";
            }
        }

        /// <summary>
        /// 回写手术状态到HIS
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncWriteHisOperStatus(string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.patientid = patientID;
                inputPara.visitid = visitID;
                inputPara.operid = operID;

                string parmInString = "";
                parmInString = "patientid : " + inputPara.patientid;
                parmInString += " visitid : " + inputPara.visitid;
                parmInString += " operid : " + inputPara.operid;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS202", parmInString);

                string ret = RunInterFace("ANESMGR", "HIS", "HIS202", inputPara);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }


        /// <summary>
        /// 回写手术状态到HIS 202回写状态 203 回写信息 212 取消手术
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.patientid = patientID;
                inputPara.visitid = visitID;
                inputPara.operid = operID;

                string sycID = "";
                switch (state)
                {
                    case 0:
                        sycID = "HIS202";
                        break;
                    case 1:
                        sycID = "HIS203";
                        break;
                    case 2:
                        sycID = "HIS212";
                        break;
                }


                string parmInString = "";
                parmInString = "patientid : " + inputPara.patientid;
                parmInString += " visitid : " + inputPara.visitid;
                parmInString += " operid : " + inputPara.operid;
                RecordInterFaceLog("ANESMGR", "HIS", sycID, parmInString);


                string ret = RunInterFace("ANESMGR", "HIS", sycID, inputPara);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }


        /// <summary>
        /// 同步单病人医嘱信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncOrderInfo(string patientID, int visitID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.patientid = patientID;
                inputPara.visitid = visitID;


                string parmInString = "";
                parmInString = "patientid : " + inputPara.patientid;
                parmInString += " visitid : " + inputPara.visitid;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS103", parmInString);

                string ret = RunInterFace("ANESMGR", "HIS", "HIS103", inputPara);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospital(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.patientid = patientID;


                string parmInString = "";
                parmInString = "patientid : " + inputPara.patientid;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS101", parmInString);

                string ret = RunInterFace("ANESMGR", "HIS", "HIS101", inputPara);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        // 将收费结束标志回转到HIS
        public string SyncEndBill(string patientid, int visitid, int operid)
        {
            WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
            inputPara.patientid = patientid;
            inputPara.visitid = visitid;
            inputPara.operid = operid;
            inputPara.reserved20 = "500";


            string parmInString = "";
            parmInString = "patientid : " + inputPara.patientid;
            parmInString += " visitid : " + inputPara.visitid;
            parmInString += " operid : " + inputPara.operid;
            parmInString += " reserved20 : " + inputPara.reserved20;
            RecordInterFaceLog("ANESMGR", "HIS", "HIS211", parmInString);


            string ret = RunInterFace("ANESMGR", "HIS", "HIS211", inputPara);
            return ret;
        }

        /// <summary>
        /// 同步手术收费到HIS
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncBillItems(string patientid, int visitid, int operid, int isAnesBill)
        {
            WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
            inputPara.patientid = patientid;
            inputPara.visitid = visitid;
            inputPara.operid = operid;
            inputPara.reserved02 = isAnesBill.ToString();


            string parmInString = "";
            parmInString = "patientid : " + inputPara.patientid;
            parmInString += " visitid : " + inputPara.visitid;
            parmInString += " operid : " + inputPara.operid;
            parmInString += " reserved02 : " + inputPara.reserved02;
            RecordInterFaceLog("ANESMGR", "HIS", "HIS209", parmInString);

            string ret = RunInterFace("ANESMGR", "HIS", "HIS209", inputPara);
            return ret;
        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="inpno">住院号</param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            if (!string.IsNullOrEmpty(inpNo))
            {
                WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
                inputPara.inpno = inpNo;



                string parmInString = "";
                parmInString = "inpno : " + inputPara.inpno;
                RecordInterFaceLog("ANESMGR", "HIS", "HIS104", parmInString);


                string ret = RunInterFace("ANESMGR", "HIS", "HIS104", inputPara);
                return ret;
            }
            else
            {
                return "空的住院号";
            }
        }

        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfoByDeptCode(string performedcode)
        {
            WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
            inputPara.performedcode = performedcode;

            inputPara.startdatetime = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00");
            inputPara.stopdatetime = DateTime.Parse(DateTime.Today.AddDays(3).ToString("yyyy-MM-dd") + " 23:59:59");

            string parmInString = "";
            parmInString = "performedcode : " + inputPara.performedcode;
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);


            string ret = RunInterFace("ANESMGR", "HIS", "HIS201", inputPara);
            return ret;
        }

        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfo(string patientID)
        {
            WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
            //inputPara.startdatetime = DateTime.Now.AddDays(-1);
            //inputPara.stopdatetime = DateTime.Now.AddDays(7);

            inputPara.startdatetime = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00");
            inputPara.stopdatetime = DateTime.Parse(DateTime.Today.AddDays(3).ToString("yyyy-MM-dd") + " 23:59:59");

            if (!string.IsNullOrEmpty(patientID))
            {

                inputPara.patientid = patientID;
            }
            else
            {
                inputPara.patientid = "ALL";
            }


            string parmInString = "";
            parmInString = "patientid : " + inputPara.patientid;
            parmInString += " startdatetime : " + inputPara.startdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + inputPara.stopdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);


            string ret = RunInterFace("ANESMGR", "HIS", "HIS201", inputPara);
            return ret;
        }


        /// <summary>
        /// 同步病人申请或预约信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncScheduleInfo(string patientID, int dateDiff)
        {
            WisServiceReference.ParmInputData inputPara = new WisServiceReference.ParmInputData();
            //inputPara.startdatetime = DateTime.Now.AddDays(-1);
            //inputPara.stopdatetime = DateTime.Now.AddDays(7);

            inputPara.startdatetime = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 00:00:00");
            inputPara.stopdatetime = DateTime.Parse(DateTime.Today.AddDays(dateDiff).ToString("yyyy-MM-dd") + " 23:59:59");

            if (!string.IsNullOrEmpty(patientID))
            {

                inputPara.patientid = patientID;
            }
            else
            {
                inputPara.patientid = "ALL";
            }


            string parmInString = "";
            parmInString = "patientid : " + inputPara.patientid;
            parmInString += " startdatetime : " + inputPara.startdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + inputPara.stopdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS201", parmInString);


            string ret = RunInterFace("ANESMGR", "HIS", "HIS201", inputPara);
            return ret;
        }

        private EventHandler _eventHandle = null;
        /// <summary>
        /// 根据病人ID提取同步检验信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="eventHandle"></param>
        public string SyncLis(string patientID, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, System.ComponentModel.DoWorkEventArgs e)
                {
                    WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
                    InputParam.patientid = patientID;



                    string parmInString = "";
                    parmInString = "patientid : " + InputParam.patientid;
                    RecordInterFaceLog("Step1ANESMGR", "LIS", "LIS001", parmInString);


                    ret = RunInterFace("ANESMGR", "LIS", "LIS001", InputParam);
                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }
        public string SyncLis(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string ret = "";
            _eventHandle = eventHandle;
            using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, System.ComponentModel.DoWorkEventArgs e)
                {
                    WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
                    InputParam.patientid = patientID;
                    InputParam.visitid = (int)visitID;


                    string parmInString = "";
                    parmInString = "patientid : " + InputParam.patientid;
                    parmInString += " visitid : " + InputParam.visitid;
                    RecordInterFaceLog("ANESMGR", "LIS", "LIS001", parmInString);


                    ret = RunInterFace("ANESMGR", "LIS", "LIS001", InputParam);
                };
                worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync();
            }
            return ret;
        }
        public string SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
            InputParam.patientid = patientID;
            InputParam.visitid = (int)visitID;
            InputParam.operid = 1;
            InputParam.startdatetime = System.DateTime.Today.AddDays(-1);
            InputParam.stopdatetime = System.DateTime.Today;



            string parmInString = "";
            parmInString = "patientid : " + InputParam.patientid;
            parmInString += " visitid : " + InputParam.visitid;
            parmInString += " operid : " + InputParam.operid;
            parmInString += " startdatetime : " + InputParam.startdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            parmInString += " stopdatetime : " + InputParam.stopdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "PACS", "PACS001", parmInString);


            string ret = RunInterFace("ANESMGR", "PACS", "PACS001", InputParam);
            return ret;

        }
        public string SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
            InputParam.patientid = patientID;
            InputParam.visitid = (int)visitID;


            string parmInString = "";
            parmInString = "patientid : " + InputParam.patientid;
            parmInString += " visitid : " + InputParam.visitid;
            RecordInterFaceLog("ANESMGR", "EMR", "EMR001", parmInString);


            string ret = RunInterFace("ANESMGR", "EMR", "EMR001", InputParam);
            return ret;
            //string ret = "";
            //string ret =  = eventHandle;
            //using (System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker())
            //{
            //    worker.DoWork += delegate(object sender, System.ComponentModel.DoWorkEventArgs e)
            //    {
            //        WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
            //        InputParam.patientid = patientID;
            //        InputParam.visitid = (int)visitID;
            //        ret = RunInterFace("ANESMGR", "EMR", "EMR001", InputParam);
            //    };
            //    worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //    worker.RunWorkerAsync();
            //}
            //return ret;
        }
        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (_eventHandle != null)
            {
                _eventHandle(null, null);
            }
        }

        public Sync.CheckReportDataTable GetCheckReport(string patientID, decimal visitID)
        {
            Sync.CheckReportDataTable dataTable = new Sync.CheckReportDataTable();
            IDatabase database = DatabaseFactory.Create();
            database.Fill(StoredScript.Get("Sync_GetCheckReport"), dataTable, new DbParameter[] {
                database.BuildDbParameter("PATIENT_ID", DbType.String, patientID), database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID) });
            return dataTable;
        }

        public Sync.WIS_MR_INDEXDataTable GetMrIndex(string patientID, decimal visitID)
        {
            Sync.WIS_MR_INDEXDataTable dataTable = new Sync.WIS_MR_INDEXDataTable();
            IDatabase database = DatabaseFactory.Create();
            database.Fill(StoredScript.Get("Sync_GetMrIndex"), dataTable, new DbParameter[] {
                database.BuildDbParameter("PATIENT_ID", DbType.String, patientID), database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID) });
            return dataTable;
        }

        public Sync.WIS_MR_FILE_INDEXDataTable GetMrFileIndex(string patientID, decimal visitID, decimal fileNo)
        {
            Sync.WIS_MR_FILE_INDEXDataTable dataTable = new Sync.WIS_MR_FILE_INDEXDataTable();
            IDatabase database = DatabaseFactory.Create();
            database.Fill(StoredScript.Get("Sync_GetMrFileIndex"), dataTable, new DbParameter[] {
                database.BuildDbParameter("PATIENT_ID", DbType.String, patientID), database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID)
                , database.BuildDbParameter("file_no", DbType.Decimal, fileNo)});
            return dataTable;
        }

        public Sync.LabQueryDataTable GetLabQuery(string patientID, decimal visitID)
        {
            Sync.LabQueryDataTable dataTable = new Sync.LabQueryDataTable();
            IDatabase database = DatabaseFactory.Create();
            database.Fill(StoredScript.Get("Sync_GetLabQuery"), dataTable, new DbParameter[] {
                database.BuildDbParameter("PATIENT_ID", DbType.String, patientID), database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID)});
            return dataTable;
        }

        /// <summary>
        /// 获取检验信息主表
        /// </summary>
        /// <returns>检验信息主表</returns>
        public Sync.MedLabTestMasterDataTable GetLabTestMaster(string patientID, decimal visitID)
        {
            Sync.MedLabTestMasterDataTable data = new Sync.MedLabTestMasterDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetLabTestMaster");
            DbParameter patientId = database.BuildDbParameter("PatientID", DbType.String, patientID);
            DbParameter visitId = database.BuildDbParameter("VisitID", DbType.Decimal, visitID);

            database.Fill(sql, data, new DbParameter[] { patientId, visitId });
            return data;
            //return GetData<PatientDocument.MedLabTestMasterDataTable>(GetSQL("GetLabTestMaster"), new object[] { patientID, visitID });
        }

        /// <summary>
        /// 获取检验信息结果
        /// </summary>
        /// <returns>检验信息结果</returns>
        public Sync.MedLabResultDataTable GetLabResult(string testNo)
        {
            Sync.MedLabResultDataTable data = new Sync.MedLabResultDataTable();
            IDatabase database = DatabaseFactory.Create();

            string sql = StoredScript.Get("Dict_GetLabResult");
            DbParameter testNoParameter = database.BuildDbParameter("TestNo", DbType.String, testNo);
            database.Fill(sql, data, new DbParameter[] { testNoParameter });
            return data;
            // return GetData<PatientDocument.MedLabResultDataTable>(GetSQL("GetLabTestResult"), new object[] { testNo });
        }

        public DataTable GetOrders(string patientID, decimal visitID)
        {
            DataTable dataTable = new DataTable();
            IDatabase database = DatabaseFactory.Create();
            database.Fill(StoredScript.Get("Sync_GetOrders"), dataTable, new DbParameter[] {
                database.BuildDbParameter("PATIENT_ID", DbType.String, patientID), database.BuildDbParameter("VISIT_ID", DbType.Decimal, visitID) });
            return dataTable;
        }


        public int SyncOperationNameToMaster(string patientID, decimal visitID, decimal operID)
        {
            //手术名称
            CareDocs.OperationNameDataTable operationNameDataTable = (new CareDocsDA()).GetOperationName(patientID, visitID, operID);
            AnesInformations.OperationMasterDataTable operationMasterDataTable = (new AnesthesiaSheetDA()).GetOperationMaster(patientID, visitID, operID);

            if (operationMasterDataTable.Rows.Count > 0)
            {
                AnesInformations.OperationMasterRow masterRow = operationMasterDataTable.Rows[0] as AnesInformations.OperationMasterRow;
                string operName = "";
                foreach (CareDocs.OperationNameRow operationNameRow in operationNameDataTable.Rows)
                {
                    operName += operationNameRow.OPER_NAME;
                }
                masterRow.OPER_NAME = operName;

                return (new AnesthesiaSheetDA()).UpdateOperationMaster(operationMasterDataTable);
            }
            return -1;
        }

        public string SyncOperationTimesInfo(string patientID, decimal visitID, decimal operID, DateTime dt, string type)
        {
            string vid = "";
            string oid = "";
            DataTable dataTable = new CommonDA().GetDataWithPrimaryKey("WIS_OPER_SCHEDULE", " WHERE PAT_ID = '" + patientID + "' AND VISIT_ID = " + visitID.ToString() + " AND schedule_id = " + operID.ToString());
            if (dataTable.Rows.Count > 0)
            {
                vid = dataTable.Rows[0]["RESERVED4"].ToString();
                oid = dataTable.Rows[0]["RESERVED5"].ToString();
            }
            
            WisServiceReference.ParmInputData InputParam = new WisServiceReference.ParmInputData();
            InputParam.patientid = patientID;
            InputParam.reserved01 = vid;
            InputParam.reserved02 = oid;
            InputParam.startdatetime = dt;
            InputParam.inpno = type;



            string parmInString = "";
            parmInString = "patientid : " + InputParam.patientid;
            parmInString += " visitid : " + InputParam.reserved01;
            parmInString += " operid : " + InputParam.reserved02;
            parmInString += " startdatetime : " + InputParam.startdatetime.ToString("yyyy-MM-dd HH:mm:ss");
            RecordInterFaceLog("ANESMGR", "HIS", "HIS401", parmInString);


            string ret = RunInterFace("ANESMGR", "HIS", "HIS401", InputParam);
            return ret;

        }




    }



    class Logger
    {
        private static object _object = new object();

        public static void Write(string logEntity)
        {
            //if (!System.IO.Directory.Exists(string.Format(@"{0}\Log", Application.StartupPath)))
            //    System.IO.Directory.CreateDirectory(string.Format(@"{0}\Log", Application.StartupPath));


            if (!System.IO.Directory.Exists(string.Format(@"{0}\Log\InterFace", AppDomain.CurrentDomain.BaseDirectory)))
                System.IO.Directory.CreateDirectory(string.Format(@"{0}\Log\InterFace", AppDomain.CurrentDomain.BaseDirectory));



            SyncLoggerWriter logWriter = new SyncLoggerWriter(WriteLog);
            logWriter.BeginInvoke(logEntity, new AsyncCallback(CallBack), logWriter);


        }
        private static void CallBack(IAsyncResult result)
        {
            SyncLoggerWriter writer = result.AsyncState as SyncLoggerWriter;
            writer.EndInvoke(result);
        }
        private static void WriteLog(string logEntity)
        {
            try
            {
                lock (_object)
                {

                    //System.IO.File.AppendAllText(string.Format(@"{0}\Log\{1}.txt", Application.StartupPath,
                    //           DateTime.Today.ToString("yyyyMMdd")), logEntity + Environment.NewLine, Encoding.Default);


                    System.IO.File.AppendAllText(string.Format(@"{0}\Log\InterFace\{1}.txt", AppDomain.CurrentDomain.BaseDirectory,
                    DateTime.Today.ToString("yyyyMMdd")), logEntity + Environment.NewLine, Encoding.Default);

                }


            }
            catch (Exception e)
            {
                throw e;
                //XtraMessageBox.Show(e.Message, "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        delegate void SyncLoggerWriter(string logEntity);
    }
}
