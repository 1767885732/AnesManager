using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Wis.Anes.Framework.Doc;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Designer;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Interface;
using Wis.Anes.DataAccess;
using Medicalsystem.Macs.Interface;

namespace Wis.Anes.Custom.CustomProject
{
    public class AnesDocuments : AnesDoc, IAnesPapers
    {
        public AnesDocuments()
        {
            base.SaveButton.Visible = false;
            base.PrintButton.Visible = false;
        }

        public UserControl ReturnFileToBoss(string patientId, decimal visitId, decimal operId)
        {
            ExtendApplicationContext.Current.PatientContext.PatientID = patientId;
            ExtendApplicationContext.Current.PatientContext.VisitID = visitId;
            ExtendApplicationContext.Current.PatientContext.OperID = operId;

            //生成麻醉单
            this.LoadReport(ExtendApplicationContext.Current.AppPath + "麻醉记录单.xml");
            SetAllControlEditable(false);
            return this;
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            base.BuildData(dataSource);
            List<KeyValue> list = DictTableNamesDropDownEditor.Tables;
            //ExtendApplicationContext.Current.CodeTables.Clear();
            DictDA dictDA = new DictDA();
            foreach (KeyValue keyValue in list)
            {
                if (!ExtendApplicationContext.Current.CodeTables.ContainsKey(keyValue.Value))
                {
                    if (keyValue.Value.ToUpper() == "WIS_MONITOR_FUNC_CODE")
                    {
                        Dict.MonitorFunctionCodeDataTable dt = dictDA.GetMonitorFunctionCode();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    //药品字典表
                    else if (keyValue.Value.ToUpper() == "WIS_ANES_EVENT_OPEN")
                    {
                        Dict.AnesthesiaEventOpenDataTable dt = dictDA.GetAnesthesiaEventOpen();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }//WIS_OPER_ROOM
                    else if (keyValue.Value.ToUpper() == "WIS_OPER_ROOM".ToUpper())
                    {
                        Dict.OperatingRoomDataTable dt = dictDA.GetOperatingRoomDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_ANES_INPUT".ToUpper())//录入字典表
                    {
                        Dict.AnesthesiaInputDictDataTable dt = dictDA.GetAnesthesiaInputDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_DIAGNOSIS".ToUpper())//诊断字典表
                    {
                        Dict.WisDiagnosisDictDataTable dt = dictDA.GetDiagnosisDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_OPERATION".ToUpper())//手术名称字典表
                    {
                        Dict.OperationDictDataTable dt = dictDA.GetOperationDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_PERM_HIS_USER".ToUpper())//医护人员字典表
                    {
                        Dict.HisUserDataTable dt = dictDA.GetHisUsers();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_ANES".ToUpper())//麻醉方法字典表
                    {
                        Dict.AnessthestaDictDataTable dt = dictDA.GetAnesDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_PRICE_LIST")//药品耗材字典表
                    {
                        Dict.PriceListDataTable dt = dictDA.GetPriceList();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_DEPT".ToUpper())//科室字典
                    {
                        Dict.DeptDictDataTable dt = dictDA.GetDeptDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else if (keyValue.Value.ToUpper() == "WIS_DICT_BLOOD_GAS")
                    {
                        Dict.BloodGasDictDataTable dt = dictDA.GetBloodGasDict();
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                    else//WIS_DICT_ANES_COMM
                    {
                        DataTable dt = (new CommonDA()).GetDataWithPrimaryKey(keyValue.Value);
                        ExtendApplicationContext.Current.CodeTables.Add(keyValue.Value, dt);
                    }
                }
            }
        }

        

    }
}
