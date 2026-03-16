using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Custom.CustomProject.CustomSetting;
using Wis.Anes.Data;
using System.IO;
using Wis.Anes.Framework.Utilities;
using DevExpress.XtraEditors;

namespace Wis.Anes.Custom.CustomProject
{
    /// <summary>
    /// 客户化医院的数据上下文, 实现各类文书之间的数据共享
    /// </summary>
  public  class DataContext
    {
       private  static readonly DataContext _current = new DataContext();
       
       private Dictionary<string, DataTable> _data = new Dictionary<string, DataTable>();

       private string _key = string.Empty;
       /// <summary>
       /// 根据patientKey获取当前用户的数据上下文
       /// </summary>
       /// <param name="patientKey"></param>
       /// <returns></returns>
       public static  DataContext GetCurrent()
       {
           //if (patientKey.Trim() != _current._key.Trim())
           //{
           //    _current._key = patientKey;
           //   // _current._data.Clear();
           //}
           //清空缓存,每次都取新数据
           _current._data.Clear();
           return _current;
       }
      /// <summary>
      /// 清空缓存
      /// </summary>
       public void Clear()
       {
           _data.Clear();
       }
      /// <summary>
      /// 根据表名,获取数据
      /// </summary>
      /// <param name="tableName"></param>
      /// <returns></returns>
       public DataTable GetData(string tableName)
       {
           DataTable dt = null;
           if (_data.ContainsKey(tableName))
           {

               dt = _data[tableName];
             
           }
           else
           {

               //NetChecking.CheckDataBaseNetImmediately();
 
                   dt = BuildData(tableName);
                   _data.Add(tableName, dt);
               
           }
           return dt;
       }



       public DataTable GetData(string tableName,bool fromCache)
       {
           if (!fromCache)
           {
               DataTable data = BuildData(tableName);
               _data[tableName] = data;
               return data;
           }
           if (_data.ContainsKey(tableName))
           {
               return _data[tableName];
           }
           else
           {
               DataTable data = BuildData(tableName);
               _data.Add(tableName, data);
               return data;
           }
       }
      /// <summary>
      /// 获取麻醉事件数据
      /// </summary>
       /// <param name="eventNo">事件类型：0-麻醉 1-复苏</param>
      /// <returns></returns>
       public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent(int eventNo)
       {
           //if (_data.ContainsKey("AnesthesiaEventDataTable"))
           //    return _data["AnesthesiaEventDataTable"] as AnesInformations.AnesthesiaEventDataTable;

           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           var data= anesthesiaSheetDA.GetAnesthesiaEvent(patientId, visitId, operId, eventNo);
           //_data.Add("AnesthesiaEventDataTable", data);
           return data;

       }

       public int UpdateAnesthesiaEvent(AnesInformations.AnesthesiaEventDataTable dt)
       {
           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           return anesthesiaSheetDA.UpdateAnesthesiaEvent(dt);
       }
       public AnesInformations.AnesthesiaEventDataTable GetAnesthesiaEvent()
       {
           //if (_data.ContainsKey("AnesthesiaEventDataTable"))
           //    return _data["AnesthesiaEventDataTable"] as AnesInformations.AnesthesiaEventDataTable;

           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           var data = anesthesiaSheetDA.GetAnesthesiaEvent(patientId, visitId, operId);
           //_data.Add("AnesthesiaEventDataTable", data);
           return data;

       }
      /// <summary>
      /// 获取麻醉体征数据
      /// </summary>
       /// <param name="eventNo">事件类型：0-麻醉 1-复苏</param>
      /// <returns></returns>
       public AnesInformations.VitalSignDataTable GetVitalSignData(int eventNo)
       {
           //if (_data.ContainsKey("VitalSignDataTable"))
           //    return _data["VitalSignDataTable"] as AnesInformations.VitalSignDataTable;

           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           var data= anesthesiaSheetDA.GetVitalSignData(patientId, visitId, operId, ApplicationConfiguration.MergeMonitorData ? -1 : eventNo, false);
           //_data.Add("VitalSignDataTable", data);
           return data;
       }

       public AnesInformations.VitalSignDataTable GetVitalSignData()
       {
           AnesInformations.VitalSignDataTable data = GetVitalSignData(0);
           AnesInformations.VitalSignDataTable pacudata = GetVitalSignData(1);
           foreach (AnesInformations.VitalSignRow prow in pacudata.Rows)
           {
               AnesInformations.VitalSignRow proww = data.FindByTIME_POINTITEM_CODE(prow.TIME_POINT, prow.ITEM_CODE);
               if (proww != null)
               {
                   continue;
                   //proww.VALUE = prow.VALUE;
               }
               else
               {
                   data.ImportRow(prow);
               }
           }
           return data;
       }
      /// <summary>
      /// 根据表名从数据库中获取数据
      /// </summary>
      /// <param name="tableName"></param>
      /// <returns></returns>
       private DataTable BuildData(string tableName)
       {
           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;

           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           CareDocsDA careDocsDA = new CareDocsDA();
           PatientInformationsDA patientDA = new PatientInformationsDA();

           DataTable data = null;
           switch (tableName)
           {
               case "WIS_OPER_ANALGESIC":
                   data = new CommonDA().GetDataFromSQLString("SELECT * FROM " + tableName + " WHERE PAT_ID = '"
                       + patientId + "' AND VISIT_ID = " + visitId.ToString() + " AND OPER_ID = " + operId.ToString());
                   if (data.Rows.Count == 0)
                   {
                       DataRow row = data.NewRow();
                       row["PAT_ID"] = patientId;
                       row["VISIT_ID"] = visitId;
                       row["OPER_ID"] = operId;
                       data.Rows.Add(row);
                   }
                   break;
               case "WIS_PAT_MONITOR_DATA_EXT":
                   data = careDocsDA.GetPatMonitorDataExtDataTable(patientId, visitId, operId);
                   break;
               case "WIS_OPER_MASTER":
                   data = GetOperationMasterDataTable(patientId, visitId, operId);
                  //data= anesthesiaSheetDA.GetOperationMaster(patientId, visitId, operId);
                  break;
               case "WIS_CUSTOM_DATA":
                  data = careDocsDA.GetCustomData(patientId, visitId, operId);
                  break;
               case "WIS_ANES_OPER_HANDOVER":
                  data = GetHandOverData(patientId, visitId, operId);
                  break;
               case "WIS_ANES_PLAN":
                  data = GetAnesthesiaPlanData(patientId, visitId, operId);
                  break;
               case "WIS_PAT_MASTER_INDEX":
                  data = patientDA.GetPatMasterIndexDataTable(patientId);
                  break;
               case "WIS_PAT_IN_HOS":
                  data = GetPatsInHospitalData(patientId, visitId);
                  break;
               case "WIS_OPER_SCHEDULE":
                  data = anesthesiaSheetDA.GetOperationScheduleData(patientId, visitId,operId);
                  if (data.Rows.Count == 0)
                  {
                      DataRow row = data.NewRow();
                      row["PAT_ID"] = patientId;
                      row["VISIT_ID"] = visitId;
                      row["SCHEDULE_ID"] = operId;
                      data.Rows.Add(row);
                  }
                  break;
               case "WIS_PAT_VISIT":
                  PatientBaseInformations.PatVisitDataTable patVisitDataTable = patientDA.GetVisitDataTable(patientId, visitId);
                  if (patVisitDataTable.Count == 0)
                  {
                      PatientBaseInformations.PatVisitRow row = patVisitDataTable.NewPatVisitRow();
                      row.PAT_ID = patientId;
                      row.VISIT_ID = visitId;
                      patVisitDataTable.AddPatVisitRow(row);
                  }
                  data = patVisitDataTable;
                  break;
               case "WIS_ANES_SUMMARY":
                  data = GetAnesthesiaSummary(patientId, visitId, operId);
                  break;
               case "WIS_PACU_SCORE":
                  data = GetPACUSorceData(patientId, visitId, operId);
                  break;
               case "WIS_INSTRUMENT_INVENTORY":
                  data = careDocsDA.GetQiXieQingDian(patientId, visitId, operId);
                  break;
               case "MED_PACU_NURSE_RECORD":
                  data = GetPACUNurseRecord(patientId, visitId, operId);
                  break;
               case "MED_OPERATING_INSTRUMENTS_DISTINCT":
                  data = GetInstrumentsTable(patientId, visitId, operId);
                  break;
               case "MED_PACKAGE_MASTER":
                  data = GetPackageMasterTable(patientId, visitId, operId);
                  break;
               case "WIS_ANES_BAD_EVENT":
                  data = GetDataTable("WIS_ANES_BAD_EVENT", patientId, visitId, operId);
                  if (data != null && data.Rows.Count == 0)
                  {
                      DataRow row = data.NewRow();
                      row["PAT_ID"] = patientId;
                      row["VISIT_ID"] = visitId;
                      row["OPER_ID"] = operId;
                      data.Rows.Add(row);
                  }
                  break;
                case "WIS_ANES_EVENT":
                    data = GetDataTable("WIS_ANES_EVENT", patientId, visitId, operId);
                    if (data != null && data.Rows.Count == 0)
                    {
                        DataRow row = data.NewRow();
                        row["PAT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        data.Rows.Add(row);
                    }
                    break;
                default:
                  throw new NotImplementedException(string.Format("当前未定义从表{0}中获取数据的方法!", tableName));

           }





           return data;
       }

       public DataTable GetDataTable(string tableName, string PatientID, decimal VisitId, decimal OperId)
       {
           try
           {
               string sqlSelect = string.Format("select * from {0} where PAT_ID = '{1}' and Visit_Id = {2} and Oper_id = {3}",
                   tableName, PatientID, VisitId, OperId);

               IDatabase database = DatabaseFactory.Create();
               DataTable dt = new DataTable();
               database.Fill(sqlSelect, dt);
               dt.TableName = tableName;

               return dt;
           }
           catch (Exception err)
           {
               ExceptionHandler.Handle(err);
           }

           return null;
       }

       private string GetOperationNamePlan(string patientId, decimal visitId, decimal operId)
       {
           string operationName = "";
           DataTable dataTable1 = DatabaseFactory.GetDataWithPrimaryKey("WIS_SCHEDULE_OPER_NAME", " WHERE PAT_ID='" + patientId + "' AND VISIT_ID=" + visitId.ToString() + " AND SCHEDULE_ID=" + operId.ToString());
           if (dataTable1 != null && dataTable1.Rows.Count > 0)
           {
               List<string> operationNames = new List<string>();
               foreach (DataRow row1 in dataTable1.Rows)
               {
                   if (row1["OPER_NAME"] != System.DBNull.Value && !string.IsNullOrEmpty(row1["OPER_NAME"].ToString()))
                   {
                       operationNames.Add(row1["OPER_NAME"].ToString());
                   }
               }
               if (operationNames.Count > 0)
               {
                   operationName = string.Join(",", operationNames.ToArray());
                   //if (operationName.Length > 100) operationName = operationName.Substring(0, 100);
               }
           }
           return operationName;
       }

       private string GetOperationName(string patientId, decimal visitId, decimal operId)
       {
           string operationName = "";
           DataTable dataTable1 = DatabaseFactory.GetDataWithPrimaryKey("WIS_OPER_NAME", " WHERE PAT_ID='" + patientId + "' AND VISIT_ID=" + visitId.ToString() + " AND OPER_ID=" + operId.ToString());
           if (dataTable1 != null && dataTable1.Rows.Count > 0)
           {
               List<string> operationNames = new List<string>();
               foreach (DataRow row1 in dataTable1.Rows)
               {
                   if (row1["OPER_NAME"] != System.DBNull.Value && !string.IsNullOrEmpty(row1["OPER_NAME"].ToString()))
                   {
                       operationNames.Add(row1["OPER_NAME"].ToString());
                   }
               }
               if (operationNames.Count > 0)
               {
                   operationName = string.Join(",", operationNames.ToArray());
                   //if (operationName.Length > 100) operationName = operationName.Substring(0, 100);
               }
           }
           return operationName;
       }

       public AnesInformations.OperationMasterDataTable GetOperationMasterDataTable(string patientId, decimal visitId, decimal operId)
       {
           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           AnesInformations.OperationMasterDataTable data = anesthesiaSheetDA.GetOperationMaster(patientId, visitId, operId);
           if (data[0].IsOPER_NAMENull() || (!data[0].IsOPER_NAMENull() && string.IsNullOrEmpty(data[0].OPER_NAME)))
           {
               data[0].OPER_NAME = GetOperationName(patientId, visitId, operId);
           }

           if (data.Rows.Count > 0)
           {
               AnesInformations.OperationMasterRow row = data.Rows[0] as AnesInformations.OperationMasterRow;
               if ((row.IsDIAG_AFTER_OPERNull() || string.IsNullOrEmpty(row.DIAG_AFTER_OPER)) && !row.IsDIAG_BEFORE_OPERNull())
                   row.DIAG_AFTER_OPER = row.DIAG_BEFORE_OPER;
           }
           return data;
       }


       public AnesInformations.AnesthesiaPlanDataTable GetAnesthesiaPlanData(string patientId, decimal visitId, decimal operId)
       {
           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           AnesInformations.AnesthesiaPlanDataTable data = anesthesiaSheetDA.GetAnesthesiaPlan(patientId, visitId, operId);
           if (data.Count == 0)
           {
               AnesInformations.AnesthesiaPlanRow row = data.NewAnesthesiaPlanRow();
               row.PAT_ID = patientId;
               row.VISIT_ID = visitId;
               row.OPER_ID = operId;

               data.AddAnesthesiaPlanRow(row);
           }
           if (data[0].IsOPER_NAMENull() || (!data[0].IsOPER_NAMENull() && string.IsNullOrEmpty(data[0].OPER_NAME)))
           {
               data[0].OPER_NAME = GetOperationNamePlan(patientId, visitId, operId);
           }
           return data;
       }

       private DataTable GetPackageMasterTable(string patientId, decimal visitId, decimal operId)
       {
           return DatabaseFactory.GetDataWithPrimaryKey("MED_PACKAGE_MASTER", " where bar_code in (select bar_code from med_operating_instruments where PAT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid)", new object[] { patientId, visitId, operId });
       }

       private DataTable GetInstrumentsTable(string patientId, decimal visitId, decimal operId)
       {
           DataTable patientInstrumentsTable = DatabaseFactory.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where PAT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid order by ITEM_NO", new object[] { patientId, visitId, operId });
           DataTable patientInstrumentsDistinctTable = DatabaseFactory.GetDataWithPrimaryKey("MED_OPERATING_INSTRUMENTS", "where (ITEM_NO IN (SELECT min(ITEM_NO) FROM med_operating_instruments where  PAT_ID=@pid and  VISIT_ID=@vid and OPER_ID=@oid  GROUP BY item_name )) order by ITEM_NO", new object[] { patientId, visitId, operId });           
           List<string> namelist = new List<string>();
           foreach (DataRow row in patientInstrumentsTable.Rows)
           {
               if (!namelist.Contains(row["ITEM_NAME"].ToString()))
               {
                   namelist.Add(row["ITEM_NAME"].ToString());
               }
               else
               {
                   DataRow[] findrows = patientInstrumentsDistinctTable.Select("ITEM_NAME='" + row["ITEM_NAME"].ToString() + "'");
                   if (findrows != null && findrows.Length > 0)
                   {
                       findrows[0]["QUANTITY1"] = decimal.Parse(findrows[0]["QUANTITY1"].ToString()) + decimal.Parse(row["QUANTITY1"].ToString());
                       findrows[0]["QUANTITY2"] = decimal.Parse(findrows[0]["QUANTITY2"].ToString()) + decimal.Parse(row["QUANTITY2"].ToString());
                       row["QUANTITY4"] = 0;
                       row["QUANTITY5"] = 0;
                       //row["MEMO"] = "重复器械术中术后合并到最前";
                   }
               }
           }
           return patientInstrumentsDistinctTable;
       }

       private DataTable GetPACUNurseRecord(string patientId, decimal visitId, decimal operId)
       {
           DataTable dataTable = DatabaseFactory.GetDataWithPrimaryKey("MED_PACU_NURSE_RECORD", " WHERE PAT_ID='" + patientId + "' AND VISIT_ID=" + visitId.ToString() + " AND OPER_ID=" + operId.ToString());
           return dataTable;
       }

       private PatientBaseInformations.PatsInHospitalDataTable GetPatsInHospitalData(string patientId, decimal visitId)
       {
           PatientInformationsDA patientDA = new PatientInformationsDA();
           PatientBaseInformations.PatsInHospitalDataTable patsInHospitalData = patientDA.GetPatsInHospital(patientId, visitId);
           if (patsInHospitalData.Count == 0)
           {
               PatientBaseInformations.PatsInHospitalRow row = patsInHospitalData.NewPatsInHospitalRow();
               row.PAT_ID = patientId;
               row.VISIT_ID = visitId;

               patsInHospitalData.AddPatsInHospitalRow(row);
           }
           return patsInHospitalData;
       }

       private DataTable GetPACUSorceData(string patientId, decimal visitId, decimal operId)
       {

           CareDocsDA careDocsDA = new CareDocsDA();
           DataTable table = careDocsDA.GetPACUSorce(patientId, (int)visitId, (int)operId);

           if (table.Rows.Count == 0)
           {

               DataRow row = table.NewRow();
               table.ImportRow(row);
           }
           return table;
       }
       private AnesInformations.AnesOperHandoverDataTable GetHandOverData(string patientId, decimal visitId, decimal operId)
       {
           AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
           AnesInformations.AnesOperHandoverDataTable handOverData = anesthesiaSheetDA.GetAnesOperHandoverDataTable(patientId, visitId, operId);
           if (handOverData.Count == 0)
           {
               AnesInformations.AnesOperHandoverRow row = handOverData.NewAnesOperHandoverRow();
               row.PAT_ID = patientId;
               row.VISIT_ID = visitId;
               row.OPER_ID = operId;

               handOverData.AddAnesOperHandoverRow(row);
           }
           return handOverData;
       }

       protected AnesInformations.AnesthesiaSummaryDataTable GetAnesthesiaSummary(string patientID, decimal visitID, decimal operID)
       {
           CareDocsDA careDocsDA = new CareDocsDA();
           AnesInformations.AnesthesiaSummaryDataTable data = careDocsDA.GetAnesthesiaSummary(patientID, visitID, operID);
           if (data.Count == 0)
           {
               AnesInformations.AnesthesiaSummaryRow row = data.NewAnesthesiaSummaryRow();
               row.PAT_ID = patientID;
               row.VISIT_ID = visitID;
               row.OPER_ID = operID;
               data.AddAnesthesiaSummaryRow(row);
           }
           return data;
       }
        /// <summary>
       /// 根据条件获取输血汇总
        /// </summary>
        /// <returns></returns>
       public string GetSumBlood()
       {
            CareDocsDA careDocsDA = new CareDocsDA();
            string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
            decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
            decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;
            DataTable table = careDocsDA.GetSumBlood(patientId, visitId, operId, 0);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["total"].ToString();
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
       /// 根据条件获取输液汇总
        /// </summary>
        /// <param name="eventNo"></param>
        /// <returns></returns>
       public string GetSumLiquid(string type)
       {
           CareDocsDA careDocsDA = new CareDocsDA();
           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;
           DataTable table = careDocsDA.GetSumLiquid(patientId, visitId, operId, 0,type);
           if (table.Rows.Count > 0)
           {
               return table.Rows[0]["total"].ToString();
           }
           else
           {
               return "0";
           }
       }

      /// <summary>
      /// 获取麻醉单血气记录
      /// </summary>
      /// <param name="patientID"></param>
      /// <param name="visitID"></param>
      /// <param name="operID"></param>
      /// <returns></returns>
       public List<BloodGasMaster> GetBloodGasItems(string patientID, decimal visitID, decimal operID)
       {
           List<BloodGasMaster> list = new List<BloodGasMaster>();
           CareDocsDA _careDocsDA = new CareDocsDA();
           string[] detailList = ExtendApplicationContext.Current.DefaultBloodGasItem.ToArray();
           CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = _careDocsDA.GetBloodGasMasterTable(patientID, visitID, operID);
           if (bloodGasMasterDataTable != null)
           {
               CareDocs.BloodGasDetailDataTable bloodGasDetailDataTable = null;
               foreach (CareDocs.BloodGasMasterRow row in bloodGasMasterDataTable)
               {
                   if (!row.IsNURSE_MEMO_2Null() && row.NURSE_MEMO_2.StartsWith("ok@"))
                   {
                       string typeName = "静脉";
                       if (!row.IsNURSE_MEMO_1Null() && !string.IsNullOrEmpty(row.NURSE_MEMO_1))
                       {
                           typeName = row.NURSE_MEMO_1;
                       }
                       BloodGasMaster item = new BloodGasMaster();
                       item.DetailId = row.DETAIL_ID;
                       item.DisplayName = typeName + "血气";
                       item.Recorddate = row.RECORD_DATE_TIME;
                       bloodGasDetailDataTable = _careDocsDA.GetBloodGasDetailTable(row.DETAIL_ID);
                       if (bloodGasDetailDataTable != null)
                       {
                           CareDocs.BloodGasDetailRow detailRow = null;
                           BloodGasDetail detail = null;
                           string itemsString = ApplicationConfiguration.GetFromConfigTable("BloodGasItems@"+row.NURSE_MEMO_2.Replace("ok@", ""));
                           if (!string.IsNullOrEmpty(itemsString))
                           {
                               string[] items = itemsString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                               
                               if (items.Length > 0)
                               {
                                   detailList = items;
                               }
                           }
                           foreach (string str in detailList)
                           {
                               detail = new BloodGasDetail();
                               detail.DetailId = row.DETAIL_ID;
                               detail.BloodGasCode = str;
                               item.Details.Add(detail);
                               detailRow = bloodGasDetailDataTable.FindByDETAIL_IDBLG_CODE(row.DETAIL_ID, str);
                               if (detailRow != null && !detailRow.IsBLG_VALUENull())
                               {
                                   detail.BloodGasValue = detailRow.BLG_VALUE;
                               }
                               else
                               {
                                   detail.BloodGasValue = "";
                               }
                           }
                       }
                       list.Add(item);
                   }
               }
           }
           if (list.Count > 0)
           {
               foreach (BloodGasMaster item in list)
               {
                   foreach (BloodGasDetail detail in item.Details)
                   {
                       if (ExtendApplicationContext.Current.BloodGasItemDict.ContainsKey(detail.BloodGasCode))
                       {
                           detail.BloodGasName = ExtendApplicationContext.Current.BloodGasItemDict[detail.BloodGasCode];
                       }
                   }
               }
           }
           return list;
       }

       public int CancelBloodGas(MedVitalSignGraph vitalSignGraph)
      {
           int n=0;
          if (vitalSignGraph != null && vitalSignGraph.MouseTime >= vitalSignGraph.StartTime && vitalSignGraph.MouseTime <= vitalSignGraph.EndTime && vitalSignGraph.SelectedBlood != null)
          {
              CareDocsDA careDocsDA = new CareDocsDA();
              CareDocs.BloodGasMasterDataTable bloodGasMasterDataTable = careDocsDA.GetBloodGasMasterTable(vitalSignGraph.SelectedBlood.DetailId);
              if (bloodGasMasterDataTable != null && bloodGasMasterDataTable.Count == 1)
              {
                  bloodGasMasterDataTable[0].SetNURSE_MEMO_2Null();
                  n = careDocsDA.UpdateBloodGasMaster(bloodGasMasterDataTable);
              }
          }
          return n;
      }

       /// <summary>
       /// 获取记录信息，如为空，则加入一新行
       /// </summary>
       /// <param name="patientId"></param>
       /// <param name="visitId"></param>
       /// <param name="operId"></param>
       /// <returns></returns>
       public CareDocs.MED_ANES_PRINTRECORDDataTable GetAnesPrintRecord(string patientId, decimal visitId, decimal operId, string docName)
       {
           string printUserID = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
           CareDocsDA careDocsDA = new CareDocsDA();
           CareDocs.MED_ANES_PRINTRECORDDataTable table = careDocsDA.GetAnesPrintRecord(patientId, (int)visitId, (int)operId, printUserID, DocNames.AnesDoc);
           if (table.Count == 0)
           {
               CareDocs.MED_ANES_PRINTRECORDRow row = table.NewMED_ANES_PRINTRECORDRow();
               row.PAT_ID = patientId;
               row.VISIT_ID = visitId;
               row.OPER_ID = operId;
               row.PRINT_USERID = printUserID;
               row.PRINT_DOC_NAME = docName;
               row.PRINT_COUNT = 0;
               table.AddMED_ANES_PRINTRECORDRow(row);
           }

           return table;
       }
       public decimal GetAnesPrintRecordCount(bool byLoginUser , string docName )
       {
           string patientId = ExtendApplicationContext.Current.PatientContext.PatientID;
           decimal visitId = ExtendApplicationContext.Current.PatientContext.VisitID;
           decimal operId = ExtendApplicationContext.Current.PatientContext.OperID;
           string printUserID = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
           decimal count = 0;

           CareDocsDA careDocsDA = new CareDocsDA();
           CareDocs.MED_ANES_PRINTRECORDDataTable table = new CareDocs.MED_ANES_PRINTRECORDDataTable();
           if (byLoginUser)
           {
               table = careDocsDA.GetAnesPrintRecord(patientId, (int)visitId, (int)operId, printUserID, docName);
           }
           else
           {
               table = careDocsDA.GetAnesPrintRecord(patientId, (int)visitId, (int)operId, docName);
           }

           foreach (CareDocs.MED_ANES_PRINTRECORDRow row in table)
           {
               count += row.PRINT_COUNT;
           }

           return count;
       }


       private void UpdateBreathPara(CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable, string patientID, decimal visitID, decimal operID, DateTime timePoint, string code, string value)
       {
           DataRow[] rows = patMonitorDataExtDataTable.Select("ITEM_CODE = '" + code + "' AND TIME_POINT = '" + timePoint.ToString() + "'");
           if (rows.Length == 1)
           {
               rows[0]["ITEM_VALUE"] = value;
           }
           else
           {
               CareDocs.PatMonitorDataExtRow row = patMonitorDataExtDataTable.NewPatMonitorDataExtRow();
               row.PAT_ID = patientID;
               row.VISIT_ID = visitID;
               row.OPER_ID = operID;
               row.TIME_POINT = timePoint;
               row.ITEM_CODE = code;
               row.ITEM_VALUE = value;
               row.RECORD_DATE = timePoint.Date;
               patMonitorDataExtDataTable.AddPatMonitorDataExtRow(row);
           }
       }

       public bool SetBreathParas(string patientID, decimal visitID, decimal operID, DateTime timePoint, string code1, string code2, string code3, string value1, string value2, string value3)
       {
           CareDocsDA careDocsDA = new CareDocsDA();
           CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = careDocsDA.GetPatMonitorDataExtDataTable(patientID, visitID, operID);
           if (patMonitorDataExtDataTable != null)
           {
               UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code1, value1);
               UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code2, value2);
               UpdateBreathPara(patMonitorDataExtDataTable, patientID, visitID, operID, timePoint, code3, value3);
               if (careDocsDA.UpdatePatMonitorExtData(patMonitorDataExtDataTable) > 0)
               {
                   return true;
               }
           }
           return false;
       }

       public string GetMonitorFunctionName(string code)
       {
           string result = code;
           if (ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_MONITOR_FUNC_CODE"))
           {
               DataRow[] rows = ExtendApplicationContext.Current.CodeTables["WIS_MONITOR_FUNC_CODE"].Select("ITEM_CODE = '" + code + "'");
               if (rows != null && rows.Length > 0 && rows[0]["ITEM_NAME"] != System.DBNull.Value)
               {
                   result = rows[0]["ITEM_NAME"].ToString();
               }
           }
           return result;
       }

        /// <summary>
        /// 自动计算时长
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="dataSources"></param>
        public void CalTimeRange(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources)
        {
            AnesInformations.OperationMasterDataTable operationMaster = GetData("MED_OPERATION_MASTER") as AnesInformations.OperationMasterDataTable;
            if (operationMaster.Rows.Count > 0)
            {
                AnesInformations.OperationMasterRow drMaster = operationMaster.Rows[0] as AnesInformations.OperationMasterRow;

                if (textbox.SummaryName.Contains("麻醉")) // 麻醉时长
                {
                    if (!drMaster.IsANES_END_TIMENull() && !drMaster.IsANES_START_TIMENull())
                    {
                        TimeSpan ts = drMaster.ANES_END_TIME - drMaster.ANES_START_TIME;
                        textbox.Text = ts.Hours + "小时" + ts.Minutes + "分钟";
                    }
                }
                else if (textbox.SummaryName.Contains("手术")) //手术时长
                {
                    if (!drMaster.IsEND_DATE_TIMENull() && !drMaster.IsSTART_DATE_TIMENull())
                    {
                        TimeSpan ts = drMaster.END_DATE_TIME - drMaster.START_DATE_TIME;
                        textbox.Text = ts.Hours + "小时" + ts.Minutes + "分钟";
                    }
                }
                else if (textbox.SummaryName.Contains("入出室") || textbox.SummaryName.Contains("出入室")) // 出入室时长
                {
                    if (!drMaster.IsOUT_DATE_TIMENull() && !drMaster.IsIN_DATE_TIMENull())
                    {
                        TimeSpan ts = drMaster.OUT_DATE_TIME - drMaster.IN_DATE_TIME;
                        textbox.Text = ts.Hours + "小时" + ts.Minutes + "分钟";
                    }
                }
            }
        }

        /// <summary>
        /// 自动计算实时体征
        /// </summary>
        /// <param name="textbox">需要计算体征的控件</param>
        /// <param name="dataSources"></param>
        /// <param name="sort">ASC：首例体征 DESC：实时体征</param>
        public void CalCurrentVitalSign(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources, string sort)
        {
            // 体征信息
            AnesInformations.VitalSignDataTable vitalSign = GetVitalSignData((int)ExtendApplicationContext.Current.EventNo);
            Dict.MonitorFunctionCodeDataTable monitorFunctionCodeDataTable = ExtendApplicationContext.Current.CodeTables["MED_MONITOR_FUNCTION_CODE"] as Dict.MonitorFunctionCodeDataTable;

            // 实时体征
            string currentVitalSign = string.Empty;

            //if (textbox.SummaryName.Contains("动脉血压"))
            //{
            //    DataRow[] rowsHigh = vitalSign.Select("ITEM_CODE = '65' AND VALUE <> '0'", "TIME_POINT DESC");
            //    DataRow[] rowsLow = vitalSign.Select("ITEM_CODE = '66' AND VALUE <> '0'", "TIME_POINT DESC");
            //    currentVitalSign = (rowsHigh.Length > 0 ? rowsHigh[0]["VALUE"].ToString() : "") + "/" + (rowsLow.Length > 0 ? rowsLow[0]["VALUE"].ToString() : "");
            //}
            //else if (textbox.SummaryName.Contains("血压"))
            //{
            //    DataRow[] rowsHigh = vitalSign.Select("ITEM_CODE = '89' AND VALUE <> '0'", "TIME_POINT DESC");
            //    DataRow[] rowsLow = vitalSign.Select("ITEM_CODE = '90' AND VALUE <> '0'", "TIME_POINT DESC");
            //    currentVitalSign = (rowsHigh.Length > 0 ? rowsHigh[0]["VALUE"].ToString() : "") + "/" + (rowsLow.Length > 0 ? rowsLow[0]["VALUE"].ToString() : "");
            //}
            //else
            //{
            string filterKey = textbox.SummaryName.Replace("实时", "").Replace("当前", "").Replace("首例", "").Replace("首次", "");

            // 查找满足ITEM_NAME或ITEM_CODE满足条件的体征
            Dict.MonitorFunctionCodeRow[] dictRows = monitorFunctionCodeDataTable.Select(string.Format("ITEM_CODE = '{0}' OR ITEM_NAME = '{0}'", filterKey), "ITEM_ID") as Dict.MonitorFunctionCodeRow[];
            if (dictRows.Length > 0)
            {
                DataRow[] rowsvitalSign = vitalSign.Select("ITEM_CODE = '" + dictRows[0].ITEM_CODE + "' AND VALUE <> '0'", "TIME_POINT " + sort);
                currentVitalSign = (rowsvitalSign.Length > 0 ? rowsvitalSign[0]["VALUE"].ToString() : "");
            }
            //}

            textbox.Text = currentVitalSign;
        }

        /// <summary>
        /// 自动计算出入量
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="dataSources"></param>
        public void CalTextValue(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources)
        {
            double d = CalLiquiedSum(textbox.SummaryName, dataSources);
            // f#保留#位小数 
            textbox.Text = (d > 0 ? (d.ToString("f2") + "ml") : textbox.Text);
            //textbox.Data = textbox.Text;
        }

        /// <summary>
        /// 自动计算出入量(公式)
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="dataSources"></param>
        public void CalTextValueFormula(MTextBox textbox, Dictionary<string, System.Data.DataTable> dataSources)
        {
            textbox.Text = CalLiquiedSumFormula(textbox.SummaryFormula, dataSources);
            //textbox.Data = textbox.Text;
        }

        /// <summary>
        /// 根据【汇总项目公式】进行计算
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="dataSources"></param>
        /// <returns></returns>
        private string CalLiquiedSumFormula(string formula, Dictionary<string, System.Data.DataTable> dataSources)
        {
            // 要返回的汇总结果dosageUnit
            string dosageUnit = string.Empty;
            if (!dataSources.ContainsKey("AnesAllEvent")) return dosageUnit;
            AnesInformations.AnesthesiaEventDataTable anesAllEvent = dataSources["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
            if (anesAllEvent == null) return dosageUnit;
            AnesInformations.AnesthesiaEventRow[] anesAllEventRows;

            // 根据公式筛选出的数据anesAllEventRows
            try
            {
                anesAllEventRows = anesAllEvent.Select(formula) as AnesInformations.AnesthesiaEventRow[];
            }
            catch
            {
                XtraMessageBox.Show(string.Format("汇总项目公式：{0}写法有误，请通过文书【配置】按钮对【汇总项目公式】进行确认！", formula));
                return dosageUnit;
            }
            // 不同单位分开存放在dosageUnitDic字典中
            Dictionary<string, decimal> dosageUnitDic = new Dictionary<string, decimal>();

            foreach (AnesInformations.AnesthesiaEventRow row in anesAllEventRows)
            {
                if (!row.IsDOSAGENull() && row.DOSAGE > 0)
                {
                    if (!dosageUnitDic.ContainsKey(row.DOSAGE_UNITS.ToLower()))
                    {
                        // 不同单位分开存放在dosageUnitDic字典中
                        if (row.DOSAGE_UNITS.ToLower() == "u" || row.DOSAGE_UNITS.ToLower() == "υ")
                        {
                            // 单位换算1u = 200ml
                            if (!dosageUnitDic.ContainsKey("ml"))
                            {
                                dosageUnitDic.Add("ml", row.DOSAGE * 200);
                            }
                            else
                            {
                                // 相同单位剂量累加
                                dosageUnitDic["ml"] = dosageUnitDic["ml"] + row.DOSAGE * 200;
                            }
                        }
                        else
                        {
                            dosageUnitDic.Add(row.DOSAGE_UNITS.ToLower(), row.DOSAGE);
                        }
                    }
                    else
                    {
                        // 相同单位剂量累加
                        dosageUnitDic[row.DOSAGE_UNITS.ToLower()] = dosageUnitDic[row.DOSAGE_UNITS.ToLower()] + row.DOSAGE;
                    }
                }
                else
                {
                    continue;
                }
            }

            // 对字典中的汇总进行拼接，放入dosageUnit中
            foreach (string key in dosageUnitDic.Keys)
            {
                dosageUnit += Math.Round(dosageUnitDic[key], 0).ToString() + key + ",";
            }
            // 去掉最末尾的逗号
            if (dosageUnit.Length > 0)
            {
                dosageUnit = dosageUnit.Remove(dosageUnit.Length - 1);
            }

            return dosageUnit;
        }

        double CalLiquiedSum(string liquiedName, Dictionary<string, System.Data.DataTable> dataSources)
       {
           if (!dataSources.ContainsKey("AnesAllEvent")) return 0;
           AnesInformations.AnesthesiaEventDataTable anesAllEvent = dataSources["AnesAllEvent"] as AnesInformations.AnesthesiaEventDataTable;
           if (!ExtendApplicationContext.Current.CodeTables.ContainsKey("WIS_ANES_EVENT_OPEN")) return 0;
           Dict.AnesthesiaEventOpenDataTable eventOpenTable = ExtendApplicationContext.Current.CodeTables["WIS_ANES_EVENT_OPEN"] as Dict.AnesthesiaEventOpenDataTable;
           double d = 0;
           foreach (AnesInformations.AnesthesiaEventRow row in anesAllEvent.Rows)
           {
               if (!row.IsDOSAGENull() && row.DOSAGE > 0)
               {
                   DataRow[] prows = eventOpenTable.Select("ITEM_CLASS='" + row.ITEM_CLASS + "' AND ITEM_NAME='" + row.ITEM_NAME + "'");
                   if (prows != null && prows.Length > 0 && prows[0]["EVENT_ATTR"] != DBNull.Value && prows[0]["EVENT_ATTR"].ToString().Trim().Equals(liquiedName))
                   {
                       d += (double)row.DOSAGE;
                   }
                   else
                   {
                       continue;
                   }
               }
               else
               {
                   continue;
               }
           }
           return d;
       }


       public decimal GetMaxNo(string fieldName, DataTable data)
       {
           decimal maxNo = 0;
           foreach (DataRow row in data.Rows)
           {
               if (decimal.Parse(row[fieldName].ToString()) > maxNo)
               {
                   maxNo = decimal.Parse(row[fieldName].ToString());
               }
           }
           maxNo++;
           return maxNo;
       }


       public CareDocs.AnesDocCheckRecordDataTable GetAnesDocCheckRecord(string docName)
       { 
            string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
            decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
            decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
            string user = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
            CareDocsDA careDocsDA = new CareDocsDA();
            CareDocs.AnesDocCheckRecordDataTable docCheckRecordDataTable = careDocsDA.GetAnesCareCheckRecord(patientID, (int)visitID, (int)operID, docName);
            if (docCheckRecordDataTable.Count == 0)
            {
                CareDocs.AnesDocCheckRecordRow row = docCheckRecordDataTable.NewAnesDocCheckRecordRow();
                row.PAT_ID = patientID;
                row.VISIT_ID = visitID;
                row.OPER_ID = operID;
                row.DOC_NAME = docName;
                row.OPERATE_DATE_TIME = DateTime.Now;
                row.OPER_TIMES = 1;
                row.OPERATOR = user;
                docCheckRecordDataTable.AddAnesDocCheckRecordRow(row);
            }
            else
            {
                CareDocs.AnesDocCheckRecordRow row = docCheckRecordDataTable[0];
                row.OPERATE_DATE_TIME = DateTime.Now;
                row.OPER_TIMES += 1;
                row.OPERATOR = user;
            
            }

            return docCheckRecordDataTable;

       }




       public int UpdateAnesDocCheckRecord(CareDocs.AnesDocCheckRecordDataTable dt)
       {
           CareDocsDA careDocsDA = new CareDocsDA();
           return careDocsDA.UpdateAnesCareCheckRecord(dt);
       }





       public int InsertEmrArchiveRecord(string pageName, int times, string fileName, string path)
       {
           try
           {
               string patientID = ExtendApplicationContext.Current.PatientContext.PatientID;
               decimal visitID = ExtendApplicationContext.Current.PatientContext.VisitID;
               decimal operID = ExtendApplicationContext.Current.PatientContext.OperID;
               string user = ExtendApplicationContext.Current.LoginUserContext.HisUserID;


                /*string sqlSelect = string.Format("select * from WIS_EMR_ARCHIVE_DETAIL where pat_id='{0}' and visit_id = '{1}' and mr_class = '麻醉' and mr_sub_class = '{2}'" +
                                                  " and archive_key = '{3}'", patientID, visitID, pageName, operID);
                */
                string sql;
               IDatabase database = DatabaseFactory.Create();
                /*DataTable dt = new DataTable("WIS_EMR_ARCHIVE_DETAIL");
                database.Fill(sqlSelect, dt);


                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["archive_times"] = times;
                    return database.Update(dt);
                }
                else*/
                {
                    sql = string.Format("insert into WIS_EMR_ARCHIVE_DETAIL(pat_id, visit_id, mr_class, mr_sub_class, archive_key, EMR_FILE_INDEX, archive_times, topic," +
                                          "emr_file_name,EMR_TYPE, archive_date_time, archive_type, archive_status, emr_owner, operator,  archive_mode,  archive_access)" +
                                         "values('{0}', {1}, '麻醉',  '{2}', '{3}', 0, {4}, '{5}', '{6}', 'PDF', getdate(), '正常', '已归档', '{7}', '{7}', '分布', '{8}')",
                                         patientID, visitID, pageName, operID, times, pageName + "_" + operID.ToString(), fileName, user, path);

                   int result = database.ExecuteNonQuery(sql);
                   return result;
               }
           }
           catch (Exception err)
           {
               ExceptionHandler.Handle(err);
           }

           return -1;
       }
       public AnesInformations.AnesthesiaEventRow NewAnesthesiaEventRow(AnesInformations.AnesthesiaEventDataTable anesthestaEventDataTable, decimal eventNo)
       {
           decimal maxItemNo = 0;
           //Modify by wenpei.x@2014-03-04
           //通过冗余的datatable计算Max的ItemNo有风险，改为从数据库获取最大ItemNo；
           //foreach (AnesInformations.AnesthesiaEventRow dataRow in anesthestaEventDataTable)
           //{
           //    if (dataRow.ITEM_NO > maxItemNo)
           //    {
           //        maxItemNo = dataRow.ITEM_NO;
           //    }

           //}
           maxItemNo = new AnesthesiaSheetDA().GetMaxItemNO(ExtendApplicationContext.Current.PatientContext.PatientID, ExtendApplicationContext.Current.PatientContext.VisitID, ExtendApplicationContext.Current.PatientContext.OperID, eventNo);
           maxItemNo++;
           AnesInformations.AnesthesiaEventRow row = anesthestaEventDataTable.NewAnesthesiaEventRow();
           row.PAT_ID = ExtendApplicationContext.Current.PatientContext.PatientID;
           row.VISIT_ID = ExtendApplicationContext.Current.PatientContext.VisitID;
           row.OPER_ID = ExtendApplicationContext.Current.PatientContext.OperID;
           row.EVENT_NO = eventNo;
           row.ITEM_NO = maxItemNo;

           //anesthestaEventDataTable.Rows.Add(row);
           return row;
       }

       #region 处理护理和麻醉同时操作同一患者文书时并发数据的问题 Add by wenpei.x@2014-03-05

       //定义需要处理的表集合
       private string _customDataTableNameList = "WIS_OPER_ANALGESIC,WIS_PAT_MASTER_INDEX,WIS_ANES_PLAN,WIS_ANES_OPER_HANDOVER,WIS_OPER_MASTER,WIS_PAT_IN_HOS,WIS_OPER_SCHEDULE,WIS_PAT_VISIT,WIS_ANES_SUMMARY";

       /// <summary>
       /// 刷新已经修改过的数据源，与源数据对比处理并发数据的问题
       /// </summary>
       /// <param name="dataSource"></param>
       public void RefreshDataSource(Dictionary<string, DataTable> dataSource)
       {
           List<string> keyList = new List<string>();//定义表名集合，用于处理字典内部的DataTable
           foreach (var item in dataSource)
           {
               keyList.Add(item.Key);
           }
           foreach (string tableName in keyList)
           {
               if (!_customDataTableNameList.Contains(tableName)) continue;//如果不在需要处理的表集合内就不处理
               dataSource[tableName] = CopyRow(dataSource[tableName], BuildData(tableName));
           }
       }

       /// <summary>
       /// 与源数据对比处理并发数据的问题
       /// </summary>
       /// <param name="sourceDT">源数据表</param>
       /// <param name="currentDT">当前数据库的数据</param>
       /// <returns></returns>
       private DataTable CopyRow(DataTable sourceDT, DataTable currentDT)
       {
           if (sourceDT.TableName == currentDT.TableName && sourceDT.Rows.Count > 0 && currentDT.Rows.Count > 0)//表名不同或者没数据的不考虑
           {
               DataRow sourceRow = sourceDT.Rows[0];
               DataRow currentRow = currentDT.Rows[0];
               if (sourceRow.RowState != DataRowState.Added) return sourceDT;//如果不是内存数据表新增的行就不考虑
               foreach (DataColumn col in sourceDT.Columns)
               {
                   if (!sourceRow.IsNull(col.ColumnName) && !string.IsNullOrEmpty(sourceRow[col].ToString()))//遍历列数据
                   {
                       currentRow[col.ColumnName] = sourceRow[col.ColumnName];
                   }
               }
               return currentDT;//如果需要处理就返回处理过的数据表
           }
           else
           {
               return sourceDT;
           }
       }
       #endregion
    }
}
