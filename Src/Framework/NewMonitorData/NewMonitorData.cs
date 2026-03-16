using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.DataAccess;
using Wis.Anes.BusinessEntity;

namespace Wis.Anes.Framework
{
    public class NewMonitorData
    {
        private decimal _eventNo;
        private string _patientID;
        private decimal _visitID;
        private decimal _operID;
        private bool _isChanged = false;
        private List<NewMonitorDataItem> _items = new List<NewMonitorDataItem>();
        public NewMonitorData(string patientID, decimal visitID, decimal operID, decimal eventNo)
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            _eventNo = eventNo;
        }

        private NewMonitorDataItem FindItem(DateTime timePoint, string itemName)
        {
            foreach (NewMonitorDataItem item in _items)
            {
                if (item.TimePoint.Date.Equals(timePoint.Date) && item.TimePoint.Hour.Equals(timePoint.Hour) && item.TimePoint.Minute.Equals(timePoint.Minute) && item.ItemName.Equals(itemName)) return item;
            }
            return null;
        }

        public void SetItem(DateTime timePoint, string itemName, object itemValue, object oldValue)
        {
            NewMonitorDataItem item = FindItem(timePoint, itemName);
            if (item == null)
            {
                _items.Add(new NewMonitorDataItem(timePoint, itemName, itemValue, oldValue));
            }
            else
            {
                item.ItemValue = itemValue;
                //item.OldValue = oldValue;
            }
            _isChanged = true;
        }

        public bool Save()
        {
            if (_items.Count > 0)
            {
                CareDocsDA careDocDA = new CareDocsDA();
                CommonDA commonDA = new CommonDA();
                DateTime dtServer = commonDA.GetSysDateTime();
                CareDocs.PatientMonitorDataDataTable patientMonitorData = careDocDA.GetPatientMonitorData(_patientID, _visitID, _operID, _eventNo);
                CareDocs.ModifyHistoryDataTable modifyHistoryDataTable = careDocDA.GetModifyHistory("WIS_PATIENT_MONITOR_DATA", "ITEM_VALUE");
                foreach (NewMonitorDataItem item in _items)
                {

                    string valueString = "";
                    string oldValueString = "";
                    if (item.ItemValue != null)
                    {
                        valueString = item.ItemValue.ToString();
                    }
                    if (string.IsNullOrEmpty(valueString))
                    {
                        valueString = "0";
                    }
                    if (item.OldValue != null)
                    {
                        oldValueString = item.OldValue.ToString();
                    }
                    CareDocs.PatientMonitorDataRow patientMonitorDataRow = patientMonitorData.FindByPAT_IDVISIT_IDOPER_IDTIME_POINTITEM_NAMEEVENT_NO(_patientID, _visitID, _operID, item.TimePoint, item.ItemName,_eventNo);
                    if (patientMonitorDataRow != null)
                    {
                        patientMonitorDataRow.ITEM_VALUE = valueString;
                        patientMonitorDataRow.RECORD_DATE = dtServer;
                        patientMonitorDataRow.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                    }
                    else
                    {
                        if (ExtendApplicationContext.Current.MonitorFunctionCodeDict.ContainsKey(item.ItemName))
                        {
                            patientMonitorDataRow = patientMonitorData.FindByPAT_IDVISIT_IDOPER_IDTIME_POINTITEM_NAMEEVENT_NO(_patientID, _visitID, _operID, item.TimePoint, ExtendApplicationContext.Current.MonitorFunctionCodeDict[item.ItemName],_eventNo);
                        }
                        if (patientMonitorDataRow == null)
                        {
                            patientMonitorDataRow = patientMonitorData.NewPatientMonitorDataRow();
                            patientMonitorDataRow.PAT_ID = _patientID;
                            patientMonitorDataRow.VISIT_ID = _visitID;
                            patientMonitorDataRow.OPER_ID = _operID;
                            patientMonitorDataRow.TIME_POINT = item.TimePoint;
                            patientMonitorDataRow.ITEM_NAME = item.ItemName;
                            patientMonitorDataRow.ITEM_VALUE = valueString;
                            patientMonitorDataRow.EVENT_NO = _eventNo;
                            patientMonitorDataRow.RECORD_DATE = dtServer;
                            patientMonitorDataRow.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                            patientMonitorData.AddPatientMonitorDataRow(patientMonitorDataRow);
                        }
                        else
                        {
                            patientMonitorDataRow.ITEM_NAME = item.ItemName;
                            patientMonitorDataRow.ITEM_VALUE = valueString;
                            patientMonitorDataRow.EVENT_NO = _eventNo;
                            patientMonitorDataRow.RECORD_DATE = dtServer;
                            patientMonitorDataRow.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                        }
                    }

                    if (valueString != oldValueString)
                    {
                        string primarykey = _patientID + "," + _visitID.ToString() + "," + _operID.ToString() + "," + item.TimePoint.ToString() + "," + item.ItemName;
                        if (modifyHistoryDataTable.FindByTABLE_NAMEFIELD_NAMEPRIMARY_KEYMODIFY_TIME("WIS_PATIENT_MONITOR_DATA", "ITEM_VALUE", primarykey, dtServer) == null)
                        {
                            CareDocs.ModifyHistoryRow modifyHistoryRow = modifyHistoryDataTable.NewModifyHistoryRow();
                            modifyHistoryRow.TABLE_NAME = "WIS_PATIENT_MONITOR_DATA";
                            modifyHistoryRow.FIELD_NAME = "ITEM_VALUE";
                            modifyHistoryRow.PRIMARY_KEY = primarykey;
                            modifyHistoryRow.OLD_VALUE = oldValueString;
                            modifyHistoryRow.NEW_VALUE = valueString;
                            modifyHistoryRow.MODIFY_TIME = dtServer;
                            modifyHistoryRow.OPERATOR = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                            modifyHistoryDataTable.AddModifyHistoryRow(modifyHistoryRow);
                        }
                    }
                }
                careDocDA.UpdatePatientMonitorData(patientMonitorData);
                careDocDA.UpdateModifyHistory(modifyHistoryDataTable);
                _items.Clear();
                return true;
            }
            return false;
        }

        public bool IsChanged
        {
            get
            {
                return _isChanged;
            }
        }

        public bool Delete(string itemCode)
        {
            bool result = false;

            CareDocsDA careDocDA = new CareDocsDA();
            CareDocs.PatientMonitorDataDataTable patientMonitorDataDataTable = careDocDA.GetPatientMonitorData(_patientID, _visitID, _operID, _eventNo);
            if (patientMonitorDataDataTable != null && patientMonitorDataDataTable.Count > 0)
            {
                foreach (CareDocs.PatientMonitorDataRow row in patientMonitorDataDataTable)
                {
                    if (row.ITEM_NAME.Equals(itemCode))
                    {
                        row.Delete();
                    }
                }
                int rec = careDocDA.UpdatePatientMonitorData(patientMonitorDataDataTable);
                if (rec > 0)
                {
                    result = true;
                }
            }
            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = careDocDA.GetPatMonitorDataExtDataTable(_patientID, _visitID, _operID);
            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                foreach (CareDocs.PatMonitorDataExtRow row in patMonitorDataExtDataTable)
                {
                    if (row.ITEM_CODE.Equals(itemCode))
                    {
                        row.Delete();
                    }
                }
                int rec = careDocDA.UpdatePatMonitorExtData(patMonitorDataExtDataTable);
                if (rec > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool Delete(DateTime timePoint)
        {
            bool result = false;
            CareDocsDA careDocDA = new CareDocsDA();

            CareDocs.PatMonitorDataExtDataTable patMonitorDataExtDataTable = careDocDA.GetPatMonitorDataExtDataTable(_patientID, _visitID, _operID);
            if (patMonitorDataExtDataTable != null && patMonitorDataExtDataTable.Count > 0)
            {
                foreach (CareDocs.PatMonitorDataExtRow row in patMonitorDataExtDataTable)
                {
                    if (IsDateTimeEqual(row.TIME_POINT, timePoint))
                    {
                        row.Delete();
                    }
                }
                int rec = careDocDA.UpdatePatMonitorExtData(patMonitorDataExtDataTable);
                if (rec > 0)
                {
                    result = true;
                }
            }
            if (DeletePatMonitorData(timePoint, _eventNo))
            {
                result = true;
            }

            CareDocs.PatientMonitorDataDataTable patientMonitorDataDataTable = careDocDA.GetPatientMonitorData(_patientID, _visitID, _operID, _eventNo);
            if (patientMonitorDataDataTable != null && patientMonitorDataDataTable.Count > 0)
            {
                foreach (CareDocs.PatientMonitorDataRow row in patientMonitorDataDataTable)
                {
                    if (IsDateTimeEqual(row.TIME_POINT, timePoint))
                    {
                        row.Delete();
                    }
                }
                int rec = careDocDA.UpdatePatientMonitorData(patientMonitorDataDataTable);
                if (rec > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        private bool DeletePatMonitorData(DateTime timePoint, decimal eventNo)
        {
            AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            bool result = false;
            AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = anesthesiaSheetDA.GetPatMonitorDate(_patientID, _visitID, _operID, eventNo);
            if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count > 0)
            {
                string value;
                ///读取监测原始数据并按体征项目名称解析出来
                for (int i = 0; i < patMonitorDateDataTable.Count; i++)
                {
                    ///必须有体征项目描述行(ITEM_NO == 0)
                    if (patMonitorDateDataTable[i].ITEM_NO > 0)
                    {
                        value = patMonitorDateDataTable[i].MONITOR_VALUE.Trim();
                        if (!value.Trim().Equals(""))
                        {
                            string[] values = value.Split(new char[] { '=', ',' });
                            DateTime time = DateTime.Parse(values[0].Trim());
                            //if(time.Equals(timePoint))
                            if (IsDateTimeEqual(time, timePoint))
                            {
                                patMonitorDateDataTable[i].Delete();
                                break;
                            }
                        }
                    }
                }

                if (anesthesiaSheetDA.UpdatePatMonitorDate(patMonitorDateDataTable) > 0)
                {
                    result = true;
                }
            }
            return result;
            //string applicationVision = new CommonDA().GetApplicationVision();
            //if (applicationVision == "ANES5")//如果是麻醉5.0版本 
            //{

            //    //AnesthesiaSheetDA anesthesiaSheetDA = new AnesthesiaSheetDA();
            //    //bool result = false;
            //    //AnesInformations.PatMonitorDateDataTable patMonitorDateDataTable = anesthesiaSheetDA.GetPatMonitorDate(_patientID, _visitID, _operID, eventNo);
            //    //if (patMonitorDateDataTable != null && patMonitorDateDataTable.Count > 0)
            //    //{
            //    //    string value;
            //    //    ///读取监测原始数据并按体征项目名称解析出来
            //    //    for (int i = 0; i < patMonitorDateDataTable.Count; i++)
            //    //    {
            //    //        ///必须有体征项目描述行(ITEM_NO == 0)
            //    //        if (patMonitorDateDataTable[i].ITEM_NO > 0)
            //    //        {
            //    //            value = patMonitorDateDataTable[i].MONITOR_VALUE.Trim();
            //    //            if (!value.Trim().Equals(""))
            //    //            {
            //    //                string[] values = value.Split(new char[] { '=', ',' });
            //    //                DateTime time = DateTime.Parse(values[0].Trim());
            //    //                //if(time.Equals(timePoint))
            //    //                if (IsDateTimeEqual(time, timePoint))
            //    //                {
            //    //                    patMonitorDateDataTable[i].Delete();
            //    //                    break;
            //    //                }
            //    //            }
            //    //        }
            //    //    }

            //    //    if (anesthesiaSheetDA.UpdatePatMonitorDate(patMonitorDateDataTable) > 0)
            //    //    {
            //    //        result = true;
            //    //    }
            //    //}
            //    //return result;

            //    return true;
            //}
            //else //如果是麻醉6.0版本 
            //{ 
            //    return true ;
            //}
        }

        private bool IsDateTimeEqual(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Year.Equals(dateTime2.Year) && dateTime1.Month.Equals(dateTime2.Month) && dateTime1.Day.Equals(dateTime2.Day)
                && dateTime1.Hour.Equals(dateTime2.Hour) && dateTime1.Minute.Equals(dateTime2.Minute);
        }
    }
}
