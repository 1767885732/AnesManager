/*----------------------------------------------------------------
      // Copyright (C) 2008 麦迪斯顿(北京)医疗科技发展有限公司
      // 文件名：MedDBFiledSetting.cs
      // 文件功能描述：工具数据框组件
      //
      // 
      // 创建标识：于占涛-2008-10-20
      //
----------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Com.MedicalSystem.Icu;

namespace Com.ICIS.Common.Controls
{
    public partial class MedDBFiledSetting : UserControl
    {
        #region 私有常量
        /// <summary>
        /// 字段表配置名称
        /// </summary>
        private const string  FIELDSETTINGSTABLENAME = "FieldSettingsTable";
        #endregion

        #region 私有变量
        private Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_SPECIALCARE_FIELD_CONFIGDataTable _fieldSettingsDt = new Com.MedicalSystem.Icu.DataSetModel.CareDocs.MED_SPECIALCARE_FIELD_CONFIGDataTable();        
        #endregion

        #region 构造函数
        private string _configFileName;
        public MedDBFiledSetting()
        {
            InitializeComponent();
        }

        public void SetConfig(string configFileName)
        {
            //_configFileName = configFileName;
            //_fieldSettingsDt.TableName = FIELDSETTINGSTABLENAME;
            //DataColumn TableName = new DataColumn("TableName", typeof(string));
            //DataColumn FieldName = new DataColumn("FieldName", typeof(string));            
            //DataColumn ViewText = new DataColumn("ViewText", typeof(string));
            //DataColumn ClassType = new DataColumn("ClassType", typeof(string));
            //DataColumn CelerityInputTableName = new DataColumn("CelerityInputTableName", typeof(string));
            //DataColumn CelerityInputValueColumnName = new DataColumn("CelerityInputValueColumnName", typeof(string));
            //DataColumn CelerityInputCodeColumnName = new DataColumn("CelerityInputCodeColumnName", typeof(string));
            //DataColumn CelerityInputSqlWhere = new DataColumn("CelerityInputSqlWhere", typeof(string));
            //DataColumn BindList = new DataColumn("BindList", typeof(string));
            //DataColumn MultiSign = new DataColumn("MultiSign", typeof(string));                                

            //_fieldSettingsDt.Columns.Add(TableName);
            //_fieldSettingsDt.Columns.Add(FieldName);            
            //_fieldSettingsDt.Columns.Add(ViewText);
            //_fieldSettingsDt.Columns.Add(ClassType);
            //_fieldSettingsDt.Columns.Add(CelerityInputTableName);
            //_fieldSettingsDt.Columns.Add(CelerityInputValueColumnName);
            //_fieldSettingsDt.Columns.Add(CelerityInputCodeColumnName);
            //_fieldSettingsDt.Columns.Add(CelerityInputSqlWhere);
            //_fieldSettingsDt.Columns.Add(BindList);
            //_fieldSettingsDt.Columns.Add(MultiSign);
            
            LoadData();
            LoadDataField();
            if (panelMaster.Controls.ContainsKey("0"))
            {
                btnControl_Click(panelMaster.Controls["0"], null);
            }
        }
        #endregion

        #region 控件事件
        private void btnControl_Click(object sender, EventArgs e)
        {
            if (!(sender is DevExpress.XtraEditors.SimpleButton))
            {
                return;
            }
            foreach (Control Control1 in panelParent.Controls)
            {
                if (Control1.Name == (sender as DevExpress.XtraEditors.SimpleButton).Text)
                {
                    Control1.Visible = true;
                }
                else
                {
                    Control1.Visible = false;
                }
            }
            SortButtons(int.Parse((sender as DevExpress.XtraEditors.SimpleButton).Name));
        }     
        #endregion

        #region 私有方法

        private void Delete(DesignableField Field)
        {
            //DataSet SettingsDS = new DataSet();
            //SettingsDS.DataSetName = "SettingsDS";
            //if (System.IO.File.Exists(_configFileName))
            //{
            //    SettingsDS.ReadXml(_configFileName);
            //}
            //if (SettingsDS.Tables.Contains(FIELDSETTINGSTABLENAME))
            //{
            //    _fieldSettingsDt = SettingsDS.Tables[FIELDSETTINGSTABLENAME];
            //}
            //if (_fieldSettingsDt.Rows.Count > 0)
            //{
            //    int DeleteIndex = -1;
            //    for (int i = 0; i < _fieldSettingsDt.Rows.Count; i++)
            //    {
            //        if (_fieldSettingsDt.Rows[i]["TableName"].ToString().Trim() == Field.TableName
            //            && _fieldSettingsDt.Rows[i]["FieldName"].ToString().Trim() == Field.DataFieldName)
            //        {
            //            DeleteIndex = i;
            //            break;
            //        }
            //    }
            //    if (DeleteIndex != -1)
            //    {
            //        _fieldSettingsDt.Rows[DeleteIndex].Delete();
            //        SettingsDS.WriteXml(_configFileName, XmlWriteMode.IgnoreSchema);
            //    }
            //}
            //LoadData();
            //LoadDataField(Field.TableName);
        }

        private void LoadDataField()
        {         
            int SortIndex = 0;
            for (int i = panelMaster.Controls.Count -1 ; i >= 0; i--)
            {
                if (panelMaster.Controls[i] is DevExpress.XtraEditors.SimpleButton)
                {
                    panelMaster.Controls.RemoveAt(i);
                }
            }
            foreach (DataRow Row in _fieldSettingsDt.Rows)
            {
                //if (Row["PARENT_ITEM"].ToString().Trim() != "选取组件")
                //{
                //    AddControl("全部数据字段", Row, ref SortIndex,true);      
                //}
                AddControl(Row["PARENT_ITEM"].ToString().Trim(), Row, ref SortIndex, false);                       
            }
            SortButtons();
            foreach (Control control in panelParent.Controls)
            {
                if (control is ListView)
                {
                    (control as ListView).Sort();
                }
            }
        }

        private void AddControl(string buttonText,DataRow row, ref int sortIndex,bool hintTableName)
        {
            ListView listView = null;
            if (panelParent.Controls.ContainsKey(buttonText))
            {
                listView = (ListView)panelParent.Controls[buttonText];
            }
            else
            {
                listView = new ListView();
                listView.MultiSelect = false;
                listView.View = View.Details;
                listView.Columns.Add("Item");
                listView.Columns[0].Width = panelParent.Width - 25;
                listView.HeaderStyle = ColumnHeaderStyle.None;
                listView.MouseDown += new MouseEventHandler(listView_MouseDown);
                listView.MouseMove += new MouseEventHandler(listView_MouseMove);
                listView.KeyPress += new KeyPressEventHandler(listView_KeyPress);
                listView.Dock = DockStyle.Fill;
                listView.Name = buttonText;
                panelParent.Controls.Add(listView);
            }
            bool IsExist = false;
            foreach (Control Control1 in panelMaster.Controls)
            {
                if (Control1 is DevExpress.XtraEditors.SimpleButton)
                {
                    if (Control1.Tag != null)
                    {
                        if (Control1.Tag.ToString() == buttonText)
                        {
                            IsExist = true;
                            break;
                        }
                    }
                }
            }
            if (!IsExist)
            {
                MedButton Button1 = new MedButton();
                Button1.Text = buttonText;
                Button1.Dock = DockStyle.Top;
                Button1.Click += new EventHandler(btnControl_Click);
                Button1.Name = sortIndex.ToString();
                Button1.Tag = buttonText;
                sortIndex++;
                panelMaster.Controls.Add(Button1);
            }
            DesignableField.ClassType FieldType = (DesignableField.ClassType)System.Enum.Parse(typeof(DesignableField.ClassType), row["CLASS_TYPE"].ToString().Trim(), true);
            DesignableField Field = new DesignableField(FieldType);
            Field.AllowDrag = true;
            Field.TableName = row["PARENT_ITEM"].ToString().Trim();
            if (hintTableName)
            {
                Field.Hint = Field.TableName + "." + row["CHILD_ITEM"].ToString().Trim();
            }
            else
            {
                Field.Hint = row["CHILD_ITEM"].ToString().Trim();
            }
            Field.DataFieldName = row["CHILD_ITEM"].ToString().Trim();
            Field.CelerityInputTableName = row["CELERITY_INPUT_TABLE_NAME"].ToString().Trim();
            Field.CelerityInputValueColumnName = row["CELERITY_VALUE_COLUMN_NAME"].ToString().Trim();
            Field.CelerityInputCodeColumnName = row["CELERITY_CODE_COLUMN_NAME"].ToString().Trim();
            //Field.CelerityInputSqlWhere = row["CelerityInputSqlWhere"].ToString().Trim();
            Field.Text = row["VIEW_TEXT"].ToString().Trim();
            ListViewItem item = listView.Items.Add(Field.Text);
            item.Tag = Field;
            Field.BindList = row["BIND_LIST"].ToString().Trim();
            bool MultiSign;
            if (bool.TryParse(row["MULTI_SIGN"].ToString().Trim(), out MultiSign))
            {
                Field.MultiSign = MultiSign;
            }
        }

        private string filtString = "";
        private int filtIndex = -1;
        private void listView_KeyPress(object sender, KeyPressEventArgs e)
        {
            string fs = "" + e.KeyChar;
            if (filtString.Equals(fs))
            {
                filtIndex++;
            }
            else
            {
                filtString = fs;
                filtIndex = 0;
            }
            int fsi = 0;
            foreach (ListViewItem row in (sender as ListView).Items)
            {
                if (Com.MedicalSystem.Common.Utilities.StringManage.GetPYString(row.Text).ToLower().StartsWith(filtString.ToLower()))
                {
                    if (fsi == filtIndex)
                    {
                        row.Selected = true;
                        (sender as ListView).EnsureVisible(row.Index);
                        break;
                    }
                    else
                    {
                        fsi++;
                    }
                }
            }
        }

        private void listView_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = (sender as ListView).HitTest(e.X, e.Y);
            if (hitTestInfo.Item != null)
            {
                toolTip1.SetToolTip((sender as ListView), (hitTestInfo.Item.Tag as DesignableField).Hint);
            }
            else
            {
                toolTip1.SetToolTip((sender as ListView), null);
            }
        }

        private void listView_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hitTestInfo = (sender as ListView).HitTest(e.X, e.Y);
            if (hitTestInfo.Item != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    (sender as ListView).DoDragDrop(hitTestInfo.Item.Tag, DragDropEffects.Copy);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    hitTestInfo.Item.Selected = true;
                    selectedItem = hitTestInfo.Item;
                    contextMenuStrip1.Show(sender as ListView, e.Location);
                }
            }
        }

        private void SortButtons(int SortID)
        {
            panelMaster.Visible = false;
            for (int i = 0; i < panelMaster.Controls.Count - 1; i++)
            {
                if (panelMaster.Controls.ContainsKey(i.ToString()))
                { 
                    Control Control1 = panelMaster.Controls[i.ToString()];
                    if (Control1 is DevExpress.XtraEditors.SimpleButton)
                    {
                        //if (int.Parse(Control1.Name) > SortID)
                        //{
                        //    (Control1 as Button).Dock = DockStyle.Bottom;
                        //    Control1.SendToBack();
                        //}
                        //else
                        //{
                        (Control1 as DevExpress.XtraEditors.SimpleButton).Dock = DockStyle.Top;
                            Control1.BringToFront();
                        //}
                    }
                }
            }
            panelParent.BringToFront();
            panelMaster.Visible = true;
        }
        private void SortButtons()
        {
            for (int i = 0; i <= 11; i++)
            {
                if (panelMaster.Controls.ContainsKey(i.ToString()))
                {
                    Control Control1 = panelMaster.Controls[i.ToString()];
                    if (Control1 is DevExpress.XtraEditors.SimpleButton)
                    {
                        Control1.BringToFront();
                    }
                }
            }
            panelParent.BringToFront();
        }

        private void LoadDataField(string buttonName)
        {
            LoadDataField();
            bool IsExist = false;
            foreach (Control Control1 in panelMaster.Controls)
            {
                if (Control1 is DevExpress.XtraEditors.SimpleButton)
                {
                    if (Control1.Tag != null)
                    {
                        if (Control1.Tag.ToString() == buttonName)
                        {
                            IsExist = true;
                            (Control1 as DevExpress.XtraEditors.SimpleButton).PerformClick();
                            break;
                        }
                    }
                }
            }
            if (!IsExist)
            { 
                foreach (Control Control1 in panelMaster.Controls)
                {
                    if (Control1 is DevExpress.XtraEditors.SimpleButton)
                    {
                        (Control1 as DevExpress.XtraEditors.SimpleButton).PerformClick();
                        break;
                    }
                }
            }
            
        }

        private void LoadData()
        {
            _fieldSettingsDt = DataOperator.GetSpecialCareControlConfig();
            panelParent.Controls.Clear();
        }

        #endregion

        #region 公开方法

        /// <summary>
        /// 增加常用数据字段
        /// </summary>
        /// <param name="DesignableField">要增加的数据字段</param>
        /// <returns>成功返回1，数据已存在返回0</returns>
        public int AddDataField(DesignableField DesignableField)
        {                        
            //DataSet SettingsDS = new DataSet();
            //SettingsDS.DataSetName = "SettingsDS";
            //if (System.IO.File.Exists(_configFileName))
            //{
            //    SettingsDS.ReadXml(_configFileName);
            //}
            //_fieldSettingsDt.Clear();
            //if (SettingsDS.Tables.Contains(FIELDSETTINGSTABLENAME))
            //{
            //    _fieldSettingsDt = SettingsDS.Tables[FIELDSETTINGSTABLENAME];
            //}
            //else
            //{
            //    if (_fieldSettingsDt.DataSet != null)
            //    {
            //        _fieldSettingsDt.DataSet.Tables.Remove(_fieldSettingsDt);
            //    }                
            //    SettingsDS.Tables.Add(_fieldSettingsDt);
            //}
            //if (_fieldSettingsDt.Rows.Count > 0)
            //{
            //    string SqlWhere = "TableName='" + DesignableField.TableName + "'"
            //                    + " AND FieldName='" + DesignableField.DataFieldName + "'"
            //                    + " AND CelerityInputTableName  ='" + DesignableField.CelerityInputTableName + "'"
            //                    + " AND CelerityInputValueColumnName  ='" + DesignableField.CelerityInputValueColumnName + "'"
            //                    + " AND CelerityInputCodeColumnName  ='" + DesignableField.CelerityInputCodeColumnName + "'"
            //                    + " AND ViewText ='" + DesignableField.ViewText + "'";
            //    DataRow[] RowList = _fieldSettingsDt.Select(SqlWhere);
            //    if (RowList.Length > 0)
            //    {
            //        return 0;
            //    }
            //}
            //DataRow Row = _fieldSettingsDt.NewRow();
            //Row["TableName"] = DesignableField.TableName;
            //Row["FieldName"] = DesignableField.DataFieldName;            
            //Row["ViewText"]  = DesignableField.ViewText;
            //Row["ClassType"] = DesignableField.Type.ToString().Trim();
            //Row["CelerityInputTableName"] = DesignableField.CelerityInputTableName;
            //Row["CelerityInputValueColumnName"] = DesignableField.CelerityInputValueColumnName;
            //Row["CelerityInputCodeColumnName"] = DesignableField.CelerityInputCodeColumnName;
            //Row["CelerityInputSqlWhere"] = DesignableField.CelerityInputSqlWhere;
            //Row["BindList"] = DesignableField.BindList;  
            //Row["MultiSign"] = DesignableField.MultiSign.ToString();  
            //_fieldSettingsDt.Rows.Add(Row);
            //SettingsDS.WriteXml(_configFileName, XmlWriteMode.IgnoreSchema);
            //LoadData();
            //LoadDataField(DesignableField.TableName);                     
            return 1;
        }

        private ListViewItem selectedItem = null;
        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                Delete(selectedItem.Tag as DesignableField);
            }
        }

        #endregion

    }
}
