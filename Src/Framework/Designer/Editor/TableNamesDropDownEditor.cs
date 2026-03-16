using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Designer
{
    public class TableNamesDropDownEditor : ListDropDownEditor
    {
        public TableNamesDropDownEditor()
        {
            List<KeyValue> list = new List<KeyValue>();
            list.Add(new KeyValue("手术信息表", "WIS_OPER_MASTER"));
            list.Add(new KeyValue("麻醉信息主表", "WIS_ANES_MASTER"));
            list.Add(new KeyValue("自定义表", "WIS_CUSTOM_DATA"));
            list.Add(new KeyValue("麻醉计划表", "WIS_ANES_PLAN"));
            list.Add(new KeyValue("事件字典表", "WIS_ANES_EVENT_OPEN"));
            list.Add(new KeyValue("麻醉总结表", "WIS_ANES_SUMMARY"));
            list.Add(new KeyValue("患者主表", "WIS_PAT_MASTER_INDEX"));
            list.Add(new KeyValue("入库登记表", "MED_STORAGE_IN"));
            list.Add(new KeyValue("出库登记表", "MED_STORAGE_OUT"));
            list.Add(new KeyValue("入出库类别字典表", "MED_STORAGE_INOUT_TYPE"));
            //list.Add(new KeyValue("药品耗材字典表", "WIS_PRICE_LIST"));
            list.Add(new KeyValue("科室字典表", "WIS_DICT_DEPT"));
            list.Add(new KeyValue("价表项目分类字典", "WIS_DICT_BILL_ITEM_CLASS"));
            list.Add(new KeyValue("手术间字典", "WIS_OPER_ROOM"));
            list.Add(new KeyValue("麻醉方法字典", "WIS_DICT_ANES"));
            list.Add(new KeyValue("手术名称字典", "WIS_DICT_OPERATION"));
            list.Add(new KeyValue("麻醉计划用药表", "WIS_ANES_DRUG_PLAN"));
            list.Add(new KeyValue("PACU记录评分表", "WIS_PACU_SCORE"));
            list.Add(new KeyValue("器材记录表", "MED_ANESTHESIA_DEVICEPRICE"));
            list.Add(new KeyValue("PACU医嘱表", "MED_PACU_ORDERS"));
            list.Add(new KeyValue("交班表", "MED_OPERATION_SHIFT_LIST"));
            list.Add(new KeyValue("收费记录表", "WIS_OPER_BILL_DETAIL"));
            _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, false);
        }
    }
}
