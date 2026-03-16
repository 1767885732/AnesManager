using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Wis.Anes.Framework.Designer
{
    public class FieldNamesDropDownEditor:ListDropDownEditor
    {

        public FieldNamesDropDownEditor() : this(false) { }
        public FieldNamesDropDownEditor(bool mulitSelect) : this("TableName", mulitSelect) { }
        public FieldNamesDropDownEditor(string tableNamePropertyName, bool mulitSelect) : this(tableNamePropertyName, mulitSelect, "","","") { }
        public FieldNamesDropDownEditor(string tableNamePropertyName, bool mulitSelect,string tableName,string codeFieldName,string nameFieldName)
        {
            MulitSelect = mulitSelect;
            _tableName = tableName;
            _tableNamePropertyName = tableNamePropertyName;
            _nameField = nameFieldName;
            _codeField = codeFieldName;
            _fieldAlias.Add("ITEM_CODE", "编码");
            _fieldAlias.Add("ITEM_NAME", "名称");
        }

        private string _tableNamePropertyName;
        private string _tableName,_codeField,_nameField;
        private Dictionary<string, string> _fieldAlias = new Dictionary<string, string>();

        protected override void SpecialInstance(object instance)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                List<KeyValue> list = GetFieldNames(_tableName);
                _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, MulitSelect);
            }
            else
            {
                object obj = instance.GetType().GetProperty(_tableNamePropertyName).GetValue(instance, null);
                if (obj != null)
                {
                    string tableName = obj.ToString();
                    List<KeyValue> list = GetFieldNames(tableName);
                    _dropDownEditorControl = new AliasNamesDropDownEditorControl(list, MulitSelect);
                }
            }
        }

        private string GetFieldAlias(string fieldName)
        {
            if (_fieldAlias.ContainsKey(fieldName))
            {
                return _fieldAlias[fieldName];
            }
            return fieldName;
        }

        private List<KeyValue> GetFieldNames(string tableName)
        {
            List<KeyValue> list = new List<KeyValue>();
            DataTable dataTable = new DataTable();
            if (tableName.ToUpper().Trim().Equals("MED_OPERATION_STATUS_DICT"))
            {
                dataTable.Columns.Add("STATUS_NAME");
                dataTable.Columns.Add("STATUS_VALUE");
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = "审批";
                dataRow[1] = "-1";
                dataTable.Rows.Add(dataRow);
            }
            else if (tableName.ToUpper().Trim().Equals("MED_OPER_SCALE"))
            {
                Wis.Anes.Data.IDatabase dataBase = Wis.Anes.Data.DatabaseFactory.Create();
                dataBase.Fill("SELECT ITEM_CODE,ITEM_NAME FROM WIS_DICT_ANES_INPUT WHERE ITEM_CLASS = '手术等级' ORDER BY SERIAL_NO", dataTable);
            }
            else if (!string.IsNullOrEmpty(_tableName))
            {
                Wis.Anes.Data.IDatabase dataBase = Wis.Anes.Data.DatabaseFactory.Create();
                dataBase.Fill("SELECT * FROM " + tableName, dataTable);
            }
            else
            {
                Wis.Anes.Data.IDatabase dataBase = Wis.Anes.Data.DatabaseFactory.Create();
                dataBase.Fill("SELECT * FROM " + tableName + " WHERE 1 = 2", dataTable);
            }
            if (!string.IsNullOrEmpty(_tableName))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(new KeyValue(row[_codeField].ToString(),row[_nameField].ToString()));
                }
            }
            else
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    list.Add(new KeyValue(GetFieldAlias(column.ColumnName), column.ColumnName));
                }
            }
            return list;
        }
    }
}
