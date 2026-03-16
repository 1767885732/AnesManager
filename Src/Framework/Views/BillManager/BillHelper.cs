/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：BillHelper.cs
      // 文件功能描述：收费管理业务辅助类
      //
      // 
      // 创建标识：XXX-2011-09-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.DataAccess;
using Microsoft.Win32;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Data;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework.Views.BillManager
{
    public class BillHelper
    {
        protected static string _dortor_in_charge = "";
        protected static string _patient_depetCode = "";

        public static bool GetChargeDoctor(string patientID, decimal visitID)
        {
            PatientBaseInformations.PatsInHospitalDataTable dt = (new PatientInformationsDA()).GetPatsInHospital(patientID, visitID);
            if(dt.Rows.Count > 0)
            {
                PatientBaseInformations.PatsInHospitalRow row = dt.Rows[0] as PatientBaseInformations.PatsInHospitalRow;
                _dortor_in_charge = row.IsDOCTOR_IN_CHARGENull() ? string.Empty : row.DOCTOR_IN_CHARGE;
                _patient_depetCode = row.DEPT_CODE;
                return true;
            }
           
            return false;
        }

        public static DataTable GetAnesthesiaEvent(string patientID, decimal visitID, decimal operID)
        {
            DataTable dataTable = new AnesthesiaSheetDA().GetAnesthesiaEvent(patientID, visitID, operID);
            if (dataTable != null)
            {
                dataTable.Columns.Add("ITEM_CLASS_NAME");
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["ITEM_CLASS"] != System.DBNull.Value)
                    {
                        if (EventTypeHelper.List.ContainsKey(row["ITEM_CLASS"].ToString()))
                        {
                            row["ITEM_CLASS_NAME"] = EventTypeHelper.List[row["ITEM_CLASS"].ToString()];
                        }
                    }
                }
                dataTable.DefaultView.Sort = "ITEM_CLASS";
                dataTable = dataTable.DefaultView.ToTable();
            }
            return dataTable;
        }

        private static void SetRowDefaultValues(Dict.OperationBillItemsRow r,string patientID, decimal visitID, decimal operID)
        {
            r.PAT_ID = patientID;
            r.VISIT_ID = visitID;
            r.OPER_ID = operID;
            r.PERFORMED_BY = ExtendApplicationContext.Current.LoginUserContext.DeptID;
            r.ORDERED_BY = _patient_depetCode;
            r.ENTERED_BY = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
            r.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.UserName;
            r.PRICE_MODIFY = 0;
            r.EXCHANGE_INDICATOR = 0;
            r.ORDERED_DOCTOR = _dortor_in_charge;
            r.PERFORMED_DOCTOR = _dortor_in_charge;
  
        }

        // 获取收费表单 billType - 收费类型 1 麻醉 2 手术
        public static DataTable GetAnesthesiaBill(string patientID, decimal visitID, decimal operID, int BillType)
        {
            Dict.OperationBillItemsDataTable dataTable = new DictDA().GetOperationBillItems(patientID,visitID,operID);
            Dict.OperationBillItemsDataTable talbe = dataTable.Clone() as Dict.OperationBillItemsDataTable;
 
            DataRow [] rows = dataTable.Select("BILL_ATTR = " + BillType.ToString());
            foreach (DataRow row in rows)
            {
                talbe.ImportRow(row);


            }
            //为什么要进行这个转化，会出问题的
            //foreach (Dict.OperationBillItemsRow row in talbe)
            //{
            //    if (!row.IsITEM_CLASSNull())
            //    {
            //        if (EventTypeHelper.List.ContainsKey(row.ITEM_CLASS))
            //        {
            //            row.ITEM_CLASS_NAME = EventTypeHelper.List[row.ITEM_CLASS];
            //        }
            //    }
            //    //if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull())
            //    //{
            //    //    row.PRICE = GetPrice(GetMatchCode(row.ITEM_CLASS, row.ITEM_NAME));
            //    //}
            //    //row.COSTS = CalFee();
            //}


            return talbe;
            /*
            if (dataTable != null)
            {
                AnesInformations.AnesthesiaEventDataTable dataSource = new AnesthesiaSheetDA().GetAnesthesiaEvent(patientID, visitID, operID);
                if (dataSource != null)
                {
                    foreach (AnesInformations.AnesthesiaEventRow row in dataSource)
                    {
                        Dict.OperationBillItemsRow r = dataTable.FindByPATIENT_IDVISIT_IDOPER_IDITEM_NO(row.PATIENT_ID, row.VISIT_ID, row.OPER_ID, row.ITEM_NO);
                        if (r == null && !row.IsITEM_NAMENull())
                        {
                            r = dataTable.NewOperationBillItemsRow();
                            r.ITEM_NO = row.ITEM_NO;
                            if (!row.IsDOSAGENull())
                            {
                                r.AMOUNT = row.DOSAGE;
                            }
                            if (!row.IsDOSAGE_UNITSNull())
                            {
                                r.UNITS = row.DOSAGE_UNITS;
                            }
                            r.ITEM_CLASS = row.ITEM_CLASS;
                            r.ITEM_NAME = row.ITEM_NAME;
                            if (!row.IsITEM_SPECNull())
                            {
                                r.ITEM_SPEC = row.ITEM_SPEC;
                            }
                            SetRowDefaultValues(r, patientID, visitID, operID);
                            dataTable.AddOperationBillItemsRow(r);
                        }
                    }
                }
                foreach (Dict.OperationBillItemsRow row in dataTable)
                {
                    if (!row.IsITEM_CLASSNull())
                    {
                        if (EventTypeHelper.List.ContainsKey(row.ITEM_CLASS))
                        {
                            row.ITEM_CLASS_NAME = EventTypeHelper.List[row.ITEM_CLASS];
                        }
                    }
                    if (!row.IsITEM_CLASSNull() && !row.IsITEM_NAMENull())
                    {
                        row.PRICE = GetPrice(GetMatchCode(row.ITEM_CLASS, row.ITEM_NAME));
                    }
                    row.COSTS = CalFee();
                }
            }
            return dataTable;
             * */
        }

        public static int Save(DataTable dataTable)
        {
            if (dataTable != null && dataTable is Dict.OperationBillItemsDataTable)
            {
                foreach(Dict.OperationBillItemsRow row in dataTable.Rows)
                {
                    if(row.RowState != DataRowState.Deleted)
                        row.PRICE_MODIFY = 0;
                }

                int result = new DictDA().UpdateOperationBillItems(dataTable as Dict.OperationBillItemsDataTable);
                return result;
            }
            return -1;
        }

        public static DataRow AddRow(DataTable dataTable, string patientID, decimal visitID, decimal operID, decimal billType)
        {
            if (dataTable != null)
            {
                decimal itemNo = billType == 1 ? 600 : 200;
                foreach (DataRow row1 in dataTable.Rows)
                {
                    decimal no;
                    if (row1.RowState == DataRowState.Deleted)
                    {
                        no = decimal.Parse(row1["ITEM_NO", DataRowVersion.Original].ToString());
                    }
                    else
                    {
                        no = decimal.Parse(row1["ITEM_NO"].ToString());
                    }
                    if (itemNo < no)
                    {
                        itemNo = no;
                    }
                }
                itemNo++;
                DataRow row = dataTable.NewRow();
                if (row is Dict.OperationBillItemsRow)
                {
                    SetRowDefaultValues(row as Dict.OperationBillItemsRow, patientID, visitID, operID);
                }

                //if (!string.IsNullOrEmpty(patientID))
                //{
                //    row["PAT_ID"] = patientID;
                //    row["VISIT_ID"] = visitID;
                //    row["OPER_ID"] = operID;
                //}

                row["ITEM_NO"] = itemNo;
                row["EXCHANGE_INDICATOR"] = 0;
                row["PRICE_MODIFY"] = 0;
                row["CLASS_ON_INP_RCPT"] = "";

                //if (dataTable.Columns.Contains("CLASS_ON_IN_RCPT"))
                //    row["CLASS_ON_IN_RCPT"] = "";

                row["CLASS_ON_OUTP_RCPT"] = "";
                row["CLASS_ON_RECKONING"] = "";
                row["SUBJ_CODE"] = "";
                row["CLASS_ON_MR"] = "";
                row["BILL_ATTR"] = billType;
                dataTable.Rows.Add(row);

                return row;
            }
            return null;
        }

        private static decimal CalFee()
        {
            return 0;
        }

        private static string GetMatchCode(string itemClass,string itemName)
        {
            return "*";
        }

        private static decimal GetPrice(string itemCode)
        {
            DataTable dataTable = GetPriceList();
            if (dataTable != null)
            {
                DataRow[] rows = dataTable.Select("ITEM_CODE = '" + itemCode + "'");
                if (rows.Length == 1 && rows[0]["PRICE"] != System.DBNull.Value)
                {
                    return decimal.Parse(rows[0]["PRICE"].ToString());
                }
            }
            return 0;
        }

        private static DataTable _priceList;
        public static DataTable GetPriceList()
        {
            if (_priceList == null)
            {
                //DataTable dataTable = new DataTable();
                //dataTable.Columns.Add("ITEM_CLASS");
                //dataTable.Columns.Add("ITEM_CODE");
                //dataTable.Columns.Add("ITEM_NAME");
                //dataTable.Columns.Add("ITEM_SPEC");
                //dataTable.Columns.Add("UNITS");
                //dataTable.Columns.Add("PRICE");
                //dataTable.Columns.Add("PREFER_PRICE");
                //dataTable.Columns.Add("FOREIGNER_PRICE");
                //dataTable.Columns.Add("PERFORMED_BY");
                //dataTable.Columns.Add("FEE_TYPE_MASK");
                //dataTable.Columns.Add("CLASS_ON_INP_RCPT");
                //dataTable.Columns.Add("CLASS_ON_OUTP_RCPT");
                //dataTable.Columns.Add("CLASS_ON_RECKONING");
                //dataTable.Columns.Add("SUBJ_CODE");
                //dataTable.Columns.Add("CLASS_ON_MR");
                //dataTable.Columns.Add("MEMO");
                //dataTable.Columns.Add("OPERATOR");
                //dataTable.Columns.Add("ENTER_DATE");
                //DataRow row = dataTable.NewRow();
                //row["ITEM_CODE"] = "*";
                //row["PRICE"] = "12";
                //dataTable.Rows.Add(row);
                ////RegistryKey reg = Registry.LocalMachine.OpenSubKey("")
                //_priceList = DatabaseFactory.Create("PriceListConn").GetTable<Dict.CURRENT_PRICE_LISTDataTable>("CURRENT_PRICE_LIST");
                return RefreshPriceList();
            }
            return _priceList;
        }

        public static DataTable RefreshPriceList()
        {
            try
            {
                _priceList = DatabaseFactory.Create("PriceListConn").GetTable<DataTable>("CURRENT_PRICE_LIST");
                return _priceList;
            }
            catch (Exception ex)
            {
                Dialog.MessageBox("温馨提示：无法获取到物价信息，请联系管理员解决。");
                ExceptionHandler.Handle(ex, false);
                return _priceList == null ? new DataTable() : _priceList;
            }
        }

        public static DataTable TransModelData(DataTable dataTable)
        {
            DataTable tagDataTable = dataTable.Clone();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i].RowState != DataRowState.Deleted)
                {
                    DataRow row = tagDataTable.NewRow();
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j] != System.DBNull.Value)
                        {
                            row[j] = dataTable.Rows[i][j];
                        }
                    }

                    row["EXCHANGE_INDICATOR"] = 0;
                    row["PRICE_MODIFY"] = 0;

                   
                    tagDataTable.Rows.Add(row);
                }
            }
            tagDataTable.PrimaryKey = null;
            if (tagDataTable.Columns.Contains("PAT_ID"))
            {
                tagDataTable.Columns.Remove(tagDataTable.Columns["PAT_ID"]);
            }
            if (tagDataTable.Columns.Contains("VISIT_ID"))
            {
                tagDataTable.Columns.Remove(tagDataTable.Columns["VISIT_ID"]);
            }
            if (tagDataTable.Columns.Contains("OPER_ID"))
            {
                tagDataTable.Columns.Remove(tagDataTable.Columns["OPER_ID"]);
            }

            if (tagDataTable.Columns.Contains("ITEM_NO"))
            {
                tagDataTable.Columns.Remove(tagDataTable.Columns["ITEM_NO"]);
            }
            return tagDataTable;
        }

        public static void CopyModelData(DataTable dataTable, DataTable modelData, string patientID, decimal visitID, decimal operID, decimal billType)
        {
            if (modelData != null)
            {
                foreach (DataRow row in modelData.Rows)
                {
                    if(row.RowState != DataRowState.Deleted)
                    //DataRow[] rows = dataTable.Select("ITEM_NO = " + row["ITEM_NO"].ToString());
                    //if (rows == null || rows.Length == 0)
                    {
                        DataRow dataRow = AddRow(dataTable, patientID, visitID, operID, Convert.ToInt32(billType));
                        foreach (DataColumn column in modelData.Columns)
                        {
                            if (column.ColumnName != "ITEM_NO" && column.ColumnName != "BILL_ATTR")
                            {
                                if(dataTable.Columns.Contains(column.ColumnName))
                                    dataRow[column.ColumnName] = row[column];
                            }
                        }
                        if (dataRow is Dict.OperationBillItemsRow)
                        {
                            SetRowDefaultValues(dataRow as Dict.OperationBillItemsRow, patientID, visitID, operID);
                        }
                        //dataTable.Rows.Add(dataRow);
                    }
                }
            }
        } 
    }
}
