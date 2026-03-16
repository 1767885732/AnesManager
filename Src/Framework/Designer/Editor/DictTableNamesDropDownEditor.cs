using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Designer
{
    public class DictTableNamesDropDownEditor : ListDropDownEditor
    {
        public DictTableNamesDropDownEditor()
        {
            _dropDownEditorControl = new AliasNamesDropDownEditorControl(Tables,false);
        }

        public static List<KeyValue> Tables
        {
            get
            {
                List<KeyValue> list = new List<KeyValue>();
                list.Add(new KeyValue("录入字典表", "WIS_DICT_ANES_INPUT"));
                list.Add(new KeyValue("诊断字典表", "WIS_DICT_DIAGNOSIS"));
                list.Add(new KeyValue("手术名称字典表", "WIS_DICT_OPERATION"));
                list.Add(new KeyValue("医护人员字典表", "WIS_PERM_HIS_USER"));
                list.Add(new KeyValue("常用字典表", "WIS_DICT_ANES_COMM"));
                list.Add(new KeyValue("麻醉方法字典表", "WIS_DICT_ANES"));
                //list.Add(new KeyValue("入出库类别字典表", "MED_STORAGE_INOUT_TYPE"));
                //list.Add(new KeyValue("药品耗材字典表", "WIS_PRICE_LIST"));
                list.Add(new KeyValue("科室字典", "WIS_DICT_DEPT"));
                list.Add(new KeyValue("价表项目分类字典", "WIS_DICT_BILL_ITEM_CLASS"));
                list.Add(new KeyValue("手术间字典表", "WIS_OPER_ROOM"));
                //list.Add(new KeyValue("麻醉方法字典表", "WIS_DICT_ANES"));
                //list.Add(new KeyValue("手术名称字典表", "WIS_DICT_OPERATION"));
                //list.Add(new KeyValue("手术等级字典表", "MED_OPER_SCALE"));
                //list.Add(new KeyValue("手术审批字典表", "MED_OPERATION_STATUS_DICT"));
                //list.Add(new KeyValue("PACU记录评分表", "WIS_PACU_SCORE"));
                //list.Add(new KeyValue("器材记录表", "MED_ANESTHESIA_DEVICEPRICE"));
                list.Add(new KeyValue("职业字典表", "WIS_DICT_OCCUPATION"));
                list.Add(new KeyValue("CPB字典表", "WIS_DICT_CPB_METHOD"));
                list.Add(new KeyValue("CPB_INPUT字典表", "WIS_DICT_CPB_INPUT"));
                list.Add(new KeyValue("采集项目字典表", "WIS_MONITOR_FUNC_CODE"));
                list.Add(new KeyValue("药品字典表", "WIS_ANES_EVENT_OPEN"));
                list.Add(new KeyValue("血气字典表", "WIS_DICT_BLOOD_GAS"));
                list.Add(new KeyValue("麻醉总结表", "WIS_DICT_ANES_INPUT_DOCTOR"));
                return list;
            }
        }
    }
}
