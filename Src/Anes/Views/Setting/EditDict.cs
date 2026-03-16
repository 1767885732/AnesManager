using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Wis.Anes.Framework.Utilities;
using System.Xml;
using Wis.Anes.BusinessEntity;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Constants;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.BusinessComponent;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class EditDict : BaseView
    {
        #region 界面初始化

        private Dict.AnesthesiaInputDictDataTable _inputDictData;
        private Dict.AnesthesiaEventOpenDataTable _eventOpenDataTalbe;
        private Dict.AnessthestaDictDataTable _dictDataTable;
        private Dict.AnesthesiaEventOpenDataTable _eventOpenCommonDataTalbe;
        private Dict.WisDiagnosisDictDataTable _diagnosisDataTable;
        private Dict.HisUserDataTable _hisUserDataTable;
        private Dict.OperationDictDataTable _operationDictTable;
        private Dict.DeptDictDataTable _deptDictDataTable;
        private Dict.MonitorDictDataTable _monitorTable;
        private Dict.OperatingRoomDataTable _operRoomTable;
        private Dict.WIS_USER_ASA_GRADEDataTable _anesDocAsaGradeTable;
        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit deptDictLookUp;
        //指示当前是否处于新增状态
        bool _currentIsAdding = false;

        public EditDict()
        {
            InitializeComponent();
            Caption = ViewNames.EditDict;
            
        }
        private void EditDict_Load(object sender, EventArgs e)
        {
            InitalizationData();
            InitalizeTreeList();
            InitalizeComboBox();
            InitalDosageColumns();
            
        }
        
        private void InitalizeTreeList()
        {
            //初始化常用术语树
            XmlDocument xmlDoc = new XmlDocument();

            if (System.IO.File.Exists(ExtendApplicationContext.Current.AppPath + "DictNormal.xml"))
            {
                xmlDoc.Load(ExtendApplicationContext.Current.AppPath + "DictNormal.xml");
            }
            treeListNormal.Nodes.Clear();

            //TreeListNode treeListNode = treeListNormal.AppendNode("root", -1);
            //treeListNode.SetValue(0, "常用术语");
            
            foreach (XmlNode xmlNode in xmlDoc.ChildNodes[0].ChildNodes)
            {
               AppendXtraTreeNode(xmlNode, null);
            }
            treeListNormal.Nodes[0].ExpandAll();
            treeListNormal_FocusedNodeChanged(this, new FocusedNodeChangedEventArgs(treeListNormal.FocusedNode, treeListNormal.FocusedNode));
            //初始化麻醉事件树
            EventTypeHelper.InitTree(treeListEventTypes);
            //初始化麻醉常用量树
            EventTypeHelper.InitTree(treeListEventType);
            //初始化事件字典树
            EventTypeHelper.InitalizeOtherTabTree(treeListOther);
            //移除不用的两个TabPage
            this.xtraTabControl1.TabPages.Remove(this.xtraTabPageCustomFields);
            this.xtraTabControl1.TabPages.Remove(this.tabPageSimple);
        }
       
        private void AppendXtraTreeNode(XmlNode xmlNode, TreeListNode node)
        {
            if (xmlNode is XmlComment) return;
            TreeListNode nd;
            if(node!=null)
              nd= treeListNormal.AppendNode(xmlNode.Name, node);
            else
              nd=treeListNormal.AppendNode(xmlNode.Name, -1);
           
            nd.SetValue(0, xmlNode.Name);
            //if(!xmlNode.HasChildNodes)
            //   repositoryItemComboBox1.Items.Add(xmlNode.Name);
            if (xmlNode.ChildNodes.Count > 0)
            {
                foreach (XmlNode xmlnd in xmlNode.ChildNodes)
                {
                    AppendXtraTreeNode(xmlnd, nd);
                }
            }
        }
        /// <summary>
        /// 界面初始化
        /// </summary>
        private void InitalizationData()
        {
            SetButtonState(false);
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    //获取常用术语数据
                   _dictDataTable = DictProxy.GetAnesDict();


                   // 重新排序号
                   //int index = 0;
                   //foreach (DataRow row in _dictDataTable.Rows)
                   //{
                   //    row["SERIAL_NO"] = index;
                   //    index++;
                   //}

                   _operationDictTable = DictProxy.GetOperationDict();
                   _diagnosisDataTable = DictProxy.GetDiagnosisDict();
                   _monitorTable = DictProxy.GetMonitorDict();
                   _operRoomTable = DictProxy.GetOperatingRoomDict();
                   _anesDocAsaGradeTable = new DictBC().GetAnesDocGradeDict();

                };
                worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    gridControlMethod.DataSource = _dictDataTable;
                    gridControlEQ.DataSource = _monitorTable;
                    gridControlOperRoom.DataSource = _operRoomTable;
                    gridAnesGrade.DataSource = _anesDocAsaGradeTable;
                };

                worker.RunWorkerAsync();
            }

        }
        private void InitalizeComboBox()
        {
            Dict.AnesthesiaInputDictDataTable inputDict = DictProxy.GetDict("用药单位");
            
            foreach (Dict.AnesthesiaInputDictRow row in inputDict)
            {
                this.repositoryItemComboBox2.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox4.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox5.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox6.Items.Add(row.ITEM_NAME);
            }
            inputDict = DictProxy.GetDict("用药途径");
            
            foreach (Dict.AnesthesiaInputDictRow row in inputDict)
            {
                this.repositoryItemComboBox3.Items.Add(row.ITEM_NAME);
            }
            foreach (string str in ApplicationConfiguration.LiquidAttrs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                this.repositoryItemComboBox7.Items.Add(str);
            }
            //医嘱分类OPER_CLASS
            List<LookUpEditItem> data1=new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("医嘱", "1"));
            data1.Add(new LookUpEditItem("其他", "2"));
            data1.Add(new LookUpEditItem("", "0"));
            repositoryItemLookUpEdit1.DataSource = data1;
            //收费REL_BILL
            List<LookUpEditItem> data2=new List<LookUpEditItem>();
            data2.Add(new LookUpEditItem("麻醉",1M));
            data2.Add(new LookUpEditItem("手术",2M));
            data2.Add(new LookUpEditItem("其他",3M));
            data2.Add(new LookUpEditItem("",0M));
            repositoryItemLookUpEdit2.DataSource = data2;
            //持续/一次性 DURATIVE_INDICATOR
            List<LookUpEditItem> data3=new List<LookUpEditItem>();
            data3.Add(new LookUpEditItem("是", 1M));
            data3.Add(new LookUpEditItem("否",2M));
            repositoryItemLookUpEdit3.DataSource = data3;

            repositoryItemLookUpEdit4.DataSource = EventTypeHelper.GetItemList();
            repositoryItemLookUpEdit5.DataSource = repositoryItemLookUpEdit4.DataSource;

            deptDictLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            deptDictLookUp.DisplayMember = "DisplayText";
            deptDictLookUp.ValueMember = "ItemValue";
            deptDictLookUp.NullText = "";
            gridControlOther.RepositoryItems.Add(deptDictLookUp);
            List<LookUpEditItem> data4 = new List<LookUpEditItem>();
            _deptDictDataTable = DictProxy.GetDeptDict();
            foreach (Dict.DeptDictRow row in _deptDictDataTable.Rows)
            {
                data4.Add(new LookUpEditItem(row.DEPT_NAME, row.DEPT_CODE));
            }
            deptDictLookUp.DataSource = data4;
            deptDictLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        /// <summary>
        /// 根据配置插入常用量列
        /// </summary>
        private void InitalDosageColumns()
        {
            for (int i = 1; i <= ApplicationConfiguration.DosageButtonsCount; i++)
            {
              GenerateColumn(gridViewEventDosage, "常用量" + i.ToString(), "STANDARD_DOSAGE_" + i.ToString());
            }
        }

        

        private GridColumn GenerateColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView, string caption, string fieldName, int width)
        {
           DevExpress.XtraGrid.Columns.GridColumn column = gridView.Columns.AddVisible(fieldName, caption);
            column.Width = width;
            return column;
        }

        private GridColumn GenerateColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView, string caption, string fieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = gridView.Columns.AddVisible(fieldName, caption);
            return column;
        }

        #endregion

        #region 菜单导航
        /// <summary>
       /// 常用术语分类
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void treeListNormal_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null )
            {
                string category= e.Node.GetDisplayText(0);
                if (string.IsNullOrEmpty(category.Trim()))
                    return;
                SetButtonState(!e.Node.HasChildren);
                _inputDictData = DictProxy.GetDict(category);

                // 重新排序号
                int index = 0;
                foreach (DataRow row in _inputDictData.Rows)
                {
                    row["SERIAL_NO"] = index;
                    index++;
                }


                this.gridControlKind.DataSource = _inputDictData;
                
                this.btnSave.Enabled = false;
                this.btnAdd.Enabled = e.Node.GetDisplayText(0) != "常用术语" && e.Node.GetDisplayText(0).Trim()!=string.Empty;
                this.btnDel.Enabled = e.Node.GetDisplayText(0) != "常用术语" && e.Node.GetDisplayText(0).Trim() != string.Empty && this.gridViewKind.RowCount > 0;
            }
        }
        /// <summary>
        /// 麻醉事件分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEventTypes_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (!e.Node.GetDisplayText(0).Equals("呼吸") )
                {
                    string category = e.Node.GetDisplayText(0);
                    if (!category.Equals("全部"))
                    {
                        string eventType = EventTypeHelper.GetEventType(category);
                        category = EventTypeHelper.FindItemClass(category);

                        _eventOpenDataTalbe = EventTypeHelper.RefreshEventOpenDataTalbe(category, eventType);


                        // 重新排序号
                        if (string.IsNullOrEmpty(eventType))
                        {
                            int index = 0;
                            foreach (DataRow row in _eventOpenDataTalbe.Rows)
                            {
                                row["ITEM_NO"] = index;
                                index++;
                            }
                        }


                        gridControlEvent.DataSource = _eventOpenDataTalbe;
                        this.btnDel.Enabled = this.gridViewEvent.RowCount > 0;
                        this.btnSave.Enabled = false;
                        this.btnAdd.Enabled = true;
                    }
                    else
                    {
                        SetButtonState(false);
                    }
                    
                }
                if (e.Node.GetDisplayText(0).Equals("呼吸") || e.Node.GetDisplayText(0).Equals("麻药"))
                {
                    this.btnAdd.Enabled = false;
                }
               
            }
            
        }
        /// <summary>
        /// 麻醉常用量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListEventType_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                if (!e.Node.GetDisplayText(0).Equals("呼吸"))
                {
                    string category = EventTypeHelper.FindItemClass(e.Node.GetDisplayText(0));
                    string eventType = EventTypeHelper.GetEventType(e.Node.GetDisplayText(0));
                  
                    if (!string.IsNullOrEmpty(eventType))
                    {
                        _eventOpenCommonDataTalbe = DictProxy.GetAnesthesiaEventOpen(category, eventType);
                    }
                    else
                    {
                        _eventOpenCommonDataTalbe = DictProxy.GetAnesthesiaEventOpen(category);
                    }
                    gridControlEventDosage.DataSource = _eventOpenCommonDataTalbe;
                    this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0;
                    this.btnSave.Enabled = false;
                    this.btnAdd.Enabled = true;
                    if (e.Node.GetDisplayText(0) == "全部" || e.Node.GetDisplayText(0).Trim()==string.Empty)
                    {
                        SetButtonState(false);
                    }
                }
                if (e.Node.GetDisplayText(0).Equals("呼吸") || e.Node.GetDisplayText(0).Equals("麻药"))
                {
                    this.btnAdd.Enabled = false;
                }
            }
            
        }
        /// <summary>
        /// 其它分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeListOther_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.GetDisplayText(0).Equals("诊断字典"))
            {
                this.gridControlOther.DataSource = _diagnosisDataTable;
                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "诊断代码", "DIAGNOSIS_CODE", 100);
                GenerateColumn(gridViewOther, "诊断名称", "DIAGNOSIS_NAME", 100);
                GenerateColumn(gridViewOther, "正名标志", "STD_INDICATOR", 100);
                GenerateColumn(gridViewOther, "标准化标志", "APPROVED_INDICATOR", 100);
                GenerateColumn(gridViewOther, "创建日期", "CREATE_DATE_TIME", 160);
                GenerateColumn(gridViewOther, "输入码", "INPUT_CODE", 100);
                gridViewOther.Columns["DIAGNOSIS_CODE"].OptionsColumn.AllowEdit = false;
            }
            else if (e.Node.GetDisplayText(0).Equals("医生字典") || e.Node.GetDisplayText(0).Equals("护士字典"))
            {

                _hisUserDataTable = e.Node.GetDisplayText(0).Equals("医生字典") ? DictProxy.GetHisUsers("医生") : DictProxy.GetHisUsers("护士");
                gridControlOther.DataSource = _hisUserDataTable;
                
                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "用户ID", "USER_ID");
                GenerateColumn(gridViewOther, "名称", "USER_NAME");
                GenerateColumn(gridViewOther, "科室", "USER_DEPT");
                GenerateColumn(gridViewOther, "输入码", "INPUT_CODE");
                GenerateColumn(gridViewOther, "类别", "USER_JOB");
                GenerateColumn(gridViewOther, "创建日期", "CREATE_DATE_TIME");
                gridViewOther.Columns["USER_ID"].OptionsColumn.AllowEdit = false;
                gridViewOther.Columns["USER_ID"].Visible = false;
                gridViewOther.Columns["USER_JOB"].OptionsColumn.AllowEdit = false;
                gridViewOther.Columns["USER_DEPT"].ColumnEdit = deptDictLookUp;
            }
           
            else if (e.Node.GetDisplayText(0).Equals("手术名称"))
            {
                gridControlOther.DataSource = _operationDictTable;
                gridViewOther.Columns.Clear();
                GenerateColumn(gridViewOther, "名称", "OPER_NAME", 300);
            }
            this.btnDel.Enabled = this.gridViewOther.RowCount > 0;
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
        }
        #endregion
       
        #region 数据操作
        //新增常用术语数据行
        private void AddgGidViewKindRow()
        {
            if (_inputDictData == null)
                return;
            var row = _inputDictData.NewAnesthesiaInputDictRow();
            row.ITEM_CLASS = treeListNormal.Selection[0].GetDisplayText(0);
            row.ITEM_NAME = "";
            decimal maxItemNo = -1;
            foreach (Dict.AnesthesiaInputDictRow datarow in _inputDictData)
            {
                if (!datarow.IsSERIAL_NONull() && maxItemNo < datarow.SERIAL_NO) maxItemNo = datarow.SERIAL_NO;
            }
            maxItemNo++;
            row.SERIAL_NO = maxItemNo;
            _inputDictData.AddAnesthesiaInputDictRow(row);
            gridViewKind.FocusedRowHandle = _inputDictData.Count - 1;
        }
        /// <summary>
        /// 删除常用术语数据行
        /// </summary>
        private void DeleteGridViewKindRow()
        {
            var row = gridViewKind.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateAnesthesiaDictDT(_inputDictData);

                }
            }
        }
        /// <summary>
        /// 添加麻醉事件数据行
        /// </summary>
        private void AddGridViewEventRow()
        {
            if (_eventOpenDataTalbe == null)
                return;
            var row = _eventOpenDataTalbe.NewAnesthesiaEventOpenRow();
            row.ITEM_CLASS = EventTypeHelper.FindItemClass(treeListEventTypes.Selection[0].GetDisplayText(0));
            row.ITEM_NAME = "";
            row.EVENT_ATTR_2 = EventTypeHelper.GetEventType(treeListEventTypes.Selection[0].GetDisplayText(0));
            decimal maxItemNo = -1;
            var data = EventTypeHelper.RefreshEventOpenDataTalbe(row.ITEM_CLASS, null);
            foreach (Dict.AnesthesiaEventOpenRow datarow in data)
            {
                if (maxItemNo < datarow.ITEM_NO) maxItemNo = datarow.ITEM_NO;
            }
            maxItemNo++;
            row.ITEM_NO = maxItemNo;
            _eventOpenDataTalbe.AddAnesthesiaEventOpenRow(row);
            gridViewEvent.FocusedRowHandle = _eventOpenDataTalbe.Count - 1;
        }
        /// <summary>
        /// 删除麻醉事件数据行
        /// </summary>
        private void DeleteGridViewEventRow()
        {
            var row = gridViewEvent.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateAnesthesiaEventOpen(_eventOpenDataTalbe);

                }
            }
        }
        /// <summary>
        /// 添加麻醉方法数据行
        /// </summary>
        private void AddGridViewMethodRow()
        {
            if (_dictDataTable == null)
                return;
            var row = _dictDataTable.NewAnessthestaDictRow();
            row.ANES_NAME = ""; ;
            decimal serialNo = -1;
            foreach (Dict.AnessthestaDictRow dr in _dictDataTable)
            {
                if (!dr.IsSERIAL_NONull() && dr.SERIAL_NO > serialNo) serialNo = dr.SERIAL_NO;
            }
            serialNo++;
            row.SERIAL_NO = serialNo;
            _dictDataTable.AddAnessthestaDictRow(row);
            gridViewMethod.FocusedRowHandle = _dictDataTable.Count - 1;
        }
        /// <summary>
        /// 删除麻醉方法数据行
        /// </summary>
        private void DeleteGridViewMethodRow()
        {
            var row = gridViewMethod.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateDict(_dictDataTable);

                }
            }
        }
        /// <summary>
        /// 添加麻醉常用量数据行
        /// </summary>
        private void AddGridViewCommonRow()
        {
            if (_eventOpenCommonDataTalbe == null)
                return;
            var row = _eventOpenCommonDataTalbe.NewAnesthesiaEventOpenRow();
            row.ITEM_CLASS = EventTypeHelper.FindItemClass(treeListEventType.Selection[0].GetDisplayText(0));
            row.ITEM_NAME = "";
            decimal maxItemNo = -1;
            var data = EventTypeHelper.RefreshEventOpenDataTalbe(row.ITEM_CLASS, null);
            foreach (Dict.AnesthesiaEventOpenRow datarow in data)
            {
                if (maxItemNo < datarow.ITEM_NO) maxItemNo = datarow.ITEM_NO;
            }
            //foreach (Dict.AnesthesiaEventOpenRow dr in _eventOpenCommonDataTalbe)
            //{
            //    if (dr.ITEM_CLASS.Equals(row.ITEM_CLASS))
            //    {
            //        if (maxItemNo < dr.ITEM_NO) maxItemNo = dr.ITEM_NO;
            //    }
            //}
            maxItemNo++;
            row.ITEM_NO = maxItemNo;
            _eventOpenCommonDataTalbe.AddAnesthesiaEventOpenRow(row);
            gridViewEventDosage.FocusedRowHandle = _eventOpenCommonDataTalbe.Count - 1;
        }
        /// <summary>
        /// 删除麻醉常用量数据行
        /// </summary>
        /// <returns></returns>
        private void  DeleteGridViewCommmonRow()
        {
            var row = gridViewEventDosage.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateAnesthesiaEventOpen(_eventOpenCommonDataTalbe);

                }
            }
        }
        /// <summary>
        /// 添加诊断字典数据行
        /// </summary>
        private void AddGridViewOtherRow1()
        {
            if (_diagnosisDataTable == null)
                return;
            var row = _diagnosisDataTable.NewWisDiagnosisDictRow();
            decimal serialNo = -1;
            foreach (Dict.WisDiagnosisDictRow dr in _diagnosisDataTable)
            {
                decimal code = 0;
                if (decimal.TryParse(dr.DIAGNOSIS_CODE, out code) && code > serialNo)
                {
                    serialNo = code;
                }
            }
            serialNo++;
            row.DIAGNOSIS_NAME = "";
            row.DIAGNOSIS_CODE = serialNo.ToString();
            _diagnosisDataTable.AddWisDiagnosisDictRow(row);
            gridViewOther.FocusedRowHandle = _diagnosisDataTable.Count - 1;
        }
        /// <summary>
        /// 删除诊断字典数据行
        /// </summary>
        private void DeleteGridViewOtherRow1()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateDiagnosisDict(_diagnosisDataTable);

                }
            }
        }
        /// <summary>
        /// 添加用户字典数据行
        /// </summary>
        private void AddGridViewOtherRow3()
        {
            if (_hisUserDataTable == null)
                return;
            var row = _hisUserDataTable.NewHisUserRow();
            //decimal serialNo = -1;
            //foreach (Dict.HisUserRow dr in _hisUserDataTable)
            //{
            //    decimal code = 0;
            //    if (decimal.TryParse(dr.USER_ID, out code) && code > serialNo)
            //    {
            //        serialNo = code;
            //    }
            //}
            //serialNo++;
            //int max = DataHelper.GetMaxHisUserId()+1;
            //row.USER_ID = max.ToString();
            row.USER_ID = "";
            row.USER_JOB = treeListOther.Selection[0].GetDisplayText(0).Equals("医生字典") ? "医生" : "护士";
            row.USER_NAME = "";
            row.CREATE_DATE_TIME = DateTime.Today;
            _hisUserDataTable.AddHisUserRow(row);
            gridViewOther.FocusedRowHandle = _hisUserDataTable.Count - 1;
        }
        /// <summary>
        /// 删除用户字典数据行
        /// </summary>
        private void DeleteGridViewRow3()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateHisUsers(_hisUserDataTable);
                }
            }
        }
        /// <summary>
        /// 添加手术名称数据行
        /// </summary>
        private void AddGridViewOtherRow2()
        {
            if (_operationDictTable == null)
                return;
            var row = _operationDictTable.NewOperationDictRow();
            row.OPER_NAME = "";
            _operationDictTable.AddOperationDictRow(row);
            gridViewOther.FocusedRowHandle = _operationDictTable.Count - 1;
        }
        /// <summary>
        /// 删除手术名称数据行
        /// </summary>
        private void DeleteGridViewOtherRow2()
        {
            var row = gridViewOther.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateOperationDict(_operationDictTable);
                }
            }
        }

        /// <summary>
        /// 添加监护仪数据行
        /// </summary>
        private void AddGridViewEQRow()
        {
            if (_monitorTable == null)
                return;
            var row = _monitorTable.NewMonitorDictRow();
            row.MONITOR_LABEL = "";
            _monitorTable.AddMonitorDictRow(row);
            gridViewEQ.FocusedRowHandle = _monitorTable.Count - 1;
        }
        /// <summary>
        /// 删除监护仪数据行
        /// </summary>
        private void DeleteGridViewEQRow()
        {
            var row = gridViewEQ.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateMonitorDict(_monitorTable);

                }
            }
        }

        /// <summary>
        /// 添加手术间数据行
        /// </summary>
        private void AddGridViewOperRoomRow()
        {
            if (_operRoomTable == null)
                return;
            var row = _operRoomTable.NewOperatingRoomRow();
            row.ROOM_NO = "";
            row.DEPT_CODE = ApplicationConfiguration.OpertionDeptCode;
            row.BED_TYPE = "0";
            _operRoomTable.AddOperatingRoomRow(row);
            gridViewOperRoom.FocusedRowHandle = _operRoomTable.Count - 1;
        }
        /// <summary>
        /// 删除手术间数据行
        /// </summary>
        private void DeleteGridViewOperRoomRow()
        {
            var row = gridViewOperRoom.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    DictProxy.UpdateOperatingRoomDict(_operRoomTable);

                }
            }
        }

        /// <summary>
        /// 编辑,删除,新增行为操作
        /// </summary>
        /// <param name="editMode"></param>
        private void SetEditBehaviour(EditMode editMode)
        {
            //常用术语
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal && this.treeListNormal.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddgGidViewKindRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _inputDictData.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    //if(gridViewKind.ValidateEditor())
                    DictProxy.UpdateAnesthesiaDictDT(_inputDictData);
                    _inputDictData.AcceptChanges();
                }
                else if(editMode==EditMode.Delete)
                {
                    DeleteGridViewKindRow();
                }
                gridControlKind.Enabled = true;
                this.btnDel.Enabled = this.gridViewKind.RowCount > 0;
            }
            //麻醉事件
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents && this.treeListEventTypes.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewEventRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _eventOpenDataTalbe.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                     gridViewEvent.Focus();
                     DictProxy.UpdateAnesthesiaEventOpen(_eventOpenDataTalbe);
                     _eventOpenDataTalbe.AcceptChanges();
                }
                else if(editMode==EditMode.Delete)
                {
                    DeleteGridViewEventRow();
                }
                
                gridControlEvent.Enabled = true;
                this.btnDel.Enabled = this.gridViewEvent.RowCount > 0;
            }
            //麻醉方法
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewMethodRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _dictDataTable.RejectChanges();
                }
               else if (editMode == EditMode.Save)
                {
                    gridViewMethod.Focus();
                    DictProxy.UpdateDict(_dictDataTable);
                    _dictDataTable.AcceptChanges();
                }
                else if(editMode==EditMode.Delete)
                {
                    DeleteGridViewMethodRow();
                }
                gridControlMethod.Enabled = true;
                this.btnDel.Enabled = this.gridViewMethod.RowCount > 0;
            }
            //麻醉常用量
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage && this.treeListEventType.Selection != null)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewCommonRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _eventOpenCommonDataTalbe.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEventDosage.Focus();
                    DictProxy.UpdateAnesthesiaEventOpen(_eventOpenCommonDataTalbe);
                    _eventOpenCommonDataTalbe.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewCommmonRow();
                }
                gridControlEventDosage.Enabled = true;
                this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0;
            }
            //监护仪
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewEQRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _monitorTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEQ.Focus();
                    DictProxy.UpdateMonitorDict(_monitorTable);
                    _monitorTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewEQRow();
                }
                gridControlEQ.Enabled = true;
                this.btnDel.Enabled = this.gridViewEQ.RowCount > 0;
            }
            //手术间
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewOperRoomRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _operRoomTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewEQ.Focus();
                    DictProxy.UpdateOperatingRoomDict(_operRoomTable);
                    _operRoomTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewOperRoomRow();
                }
                gridControlOperRoom.Enabled = true;
                this.btnDel.Enabled = this.gridViewOperRoom.RowCount > 0;
            }
            //麻醉资格等级
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageASAGrade)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewAnesGradeRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _anesDocAsaGradeTable.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    gridViewAnesGrade.Focus();
                    new DictBC().UpdateAnesDocGradeDict(_anesDocAsaGradeTable);
                    _anesDocAsaGradeTable.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewAnesGradeRow();
                }
                gridAnesGrade.Enabled = true;
                this.btnDel.Enabled = this.gridViewAnesGrade.RowCount > 0;
            }
            //其它
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther && this.treeListOther.Selection != null)
            {
                if (treeListOther.Selection[0].GetDisplayText(0).Equals("诊断字典"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow1();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _diagnosisDataTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        gridViewOther.Focus();
                        DictProxy.UpdateDiagnosisDict(_diagnosisDataTable);
                        _diagnosisDataTable.AcceptChanges();
                    }
                    else if(editMode==EditMode.Delete)
                    {
                        DeleteGridViewOtherRow1();
                    }
                  
                }
                else if (treeListOther.Selection[0].GetDisplayText(0).Equals("手术名称"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow2();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _operationDictTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        DictProxy.UpdateOperationDict(_operationDictTable);
                      _operationDictTable.AcceptChanges();
                    }
                    else if(editMode==EditMode.Delete)
                    {
                        DeleteGridViewOtherRow2();
                    }
                    
                }
                else if (treeListOther.Selection[0].GetDisplayText(0).Equals("医生字典") || treeListOther.Selection[0].GetDisplayText(0).Equals("护士字典"))
                {
                    if (editMode == EditMode.Add)
                    {
                        AddGridViewOtherRow3();
                    }
                    else if (editMode == EditMode.Cancel)
                    {
                        _hisUserDataTable.RejectChanges();
                    }
                    else if (editMode == EditMode.Save)
                    {
                        gridViewOther.Focus();
                        DictProxy.UpdateHisUsers(_hisUserDataTable);
                       _hisUserDataTable.AcceptChanges();
                    }
                    else if(editMode==EditMode.Delete)
                    {
                        DeleteGridViewRow3();
                    }

                }
                 gridControlOther.Enabled = true;
                 this.btnDel.Enabled = this.gridViewOther.RowCount > 0;
            }
        }
        /// <summary>
        /// 添加麻醉资格等级数据行
        /// </summary>
        private void AddGridViewAnesGradeRow()
        {
            if (_anesDocAsaGradeTable == null)
                return;
            var row = _anesDocAsaGradeTable.NewWIS_USER_ASA_GRADERow();
            row.USER_ID = "";
            row.USER_NAME = "";
            row.ASA_GRADE = "";
            _anesDocAsaGradeTable.AddWIS_USER_ASA_GRADERow(row);
            gridViewAnesGrade.FocusedRowHandle = _anesDocAsaGradeTable.Count - 1;
            this.btnSave.Enabled = true;
        }
        /// <summary>
        /// 删除麻醉资格等级数据行
        /// </summary>
        private void DeleteGridViewAnesGradeRow()
        {
            var row = gridViewAnesGrade.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    new DictBC().UpdateAnesDocGradeDict(_anesDocAsaGradeTable);

                }
            }
        }
        /// <summary>
        /// 添加新行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            SetEditControlState(false);
            SetEditBehaviour(EditMode.Add);
             this.btnSave.Enabled = false;
            this.btnAdd.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnRefresh.Enabled = false;
            this.btnDel.Enabled = false;
            _currentIsAdding = true;
            
        }
        private void AnesGradeActiveEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                AnesGradeActiveEditor_PopupList(sender);
            }
        }
        private void gridViewAnesGrade_ShowingEditor(object sender, EventArgs e)
        {
            if (gridViewAnesGrade.ActiveEditor != null)
            {
                gridViewAnesGrade.ActiveEditor.DoubleClick -= new EventHandler(AnesGradeActiveEditor_DoubleClick);
                gridViewAnesGrade.ActiveEditor.DoubleClick += new EventHandler(AnesGradeActiveEditor_DoubleClick);
                gridViewAnesGrade.ActiveEditor.KeyDown -= new KeyEventHandler(AnesGradeActiveEditor_KeyDown);
                gridViewAnesGrade.ActiveEditor.KeyDown += new KeyEventHandler(AnesGradeActiveEditor_KeyDown);
            }
        }
        private void AnesGradeActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            AnesGradeActiveEditor_PopupList(sender);
        }

        private void AnesGradeActiveEditor_PopupList(object sender)
        {
            if (sender is DevExpress.XtraEditors.TextEdit)
            {
                if (gridViewAnesGrade.FocusedColumn.Equals(gridColumn61))
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    DataTable dataTable = new DictDA().GetDictTable("ASA分级");
                    Dialog.ShowDataTableSelection(dataTable, "ITEM_NAME", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is Dict.AnesthesiaInputDictRow)
                            {
                                edit.Text = ((Dict.AnesthesiaInputDictRow)s1).ITEM_NAME;
                            }
                        }), false, false, null);
                }
                else if (gridViewAnesGrade.FocusedColumn.Equals(gridColumn60))
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    DataTable dataTable = new CommonDA().GetDataFromSQLString("select * from WIS_PERM_HIS_USER where user_dept='70000702' and user_job='医生'");
                    Dialog.ShowDataTableSelection(dataTable, "USER_NAME", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is DataRow)
                            {
                                edit.Text = (s1 as DataRow)["USER_NAME"].ToString();
                                gridViewAnesGrade.SetRowCellValue(gridViewAnesGrade.FocusedRowHandle, gridColumn62, (s1 as DataRow)["USER_ID"].ToString());
                            }
                        }), false, false, null);
                }
            }
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            SetEditBehaviour(EditMode.Delete);

        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentIsAdding && ValidateNewRow() == false)
                return;
            
            SetEditBehaviour(EditMode.Save);

            SetEditControlState(true);
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnRefresh.Enabled = true;
            _currentIsAdding = false;
        }
        
       
        /// <summary>
        /// 取消编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == XtraMessageBox.Show("是否取消本次操作?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                return;
            SetEditControlState(true);

            SetEditBehaviour(EditMode.Cancel);

            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnRefresh.Enabled = true;
            _currentIsAdding = false;
        }
        #endregion

        #region 设置控件状态
        private void SetEditControlState(bool isEnabled)
        {
            SetTreeListState(isEnabled);

            this.gridControlKind.Enabled = isEnabled;
            this.gridControlEvent.Enabled = isEnabled;
            this.gridControlMethod.Enabled = isEnabled;
            this.gridControlEventDosage.Enabled = isEnabled;
            this.gridControlOther.Enabled = isEnabled;
            this.gridControlEQ.Enabled = isEnabled;
            this.gridControlOperRoom.Enabled = isEnabled;
        }
        private void SetTreeListState(bool isEnabled)
        {
            this.treeListEventTypes.Enabled = isEnabled;
            this.treeListNormal.Enabled = isEnabled;
            this.treeListEventType.Enabled = isEnabled;
            this.treeListOther.Enabled = isEnabled;
        }
        /// <summary>
        /// 设置按纽的状态
        /// </summary>
        /// <param name="isEnabled"></param>
        private void SetButtonState(bool isEnabled)
        {
            this.btnAdd.Enabled = isEnabled;
            this.btnDel.Enabled = isEnabled;
            this.btnSave.Enabled = isEnabled;
            this.btnRefresh.Enabled = isEnabled;
        }
        private void gridViewKind_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_currentIsAdding)
            {
                SetTreeListState(false);
                this.btnAdd.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnRefresh.Enabled = false;
                this.btnDel.Enabled = true;
                this.gridControlKind.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal;
                this.gridControlEvent.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents;
                this.gridControlMethod.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod;
                this.gridControlEventDosage.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage;
                this.gridControlOther.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther;
                this.gridControlEQ.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict;
                this.gridControlOperRoom.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom; ;
            }
            this.btnSave.Enabled = true;
        }
        private void gridViewKind_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //处于新增状态时,不可以将焦点从当前行中移去
            e.Allow = !_currentIsAdding;

        }
       
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //常用术语
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal)
            {
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = this.treeListNormal.Selection != null && this.treeListNormal.Selection[0].GetDisplayText(0).Trim()!=string.Empty && this.treeListNormal.Selection[0].GetDisplayText(0) != "常用术语";
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewKind.RowCount > 0  && this.treeListNormal.Selection[0].GetDisplayText(0).Trim()!=string.Empty && this.treeListNormal.Selection[0].GetDisplayText(0) != "常用术语";;
            }
            //麻醉事件
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents)
            {
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = this.treeListEventTypes.Selection != null && this.treeListEventTypes.Selection[0].GetDisplayText(0) != "全部" && this.treeListEventTypes.Selection[0].GetDisplayText(0).Trim() != string.Empty;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEvent.RowCount > 0  && this.treeListEventTypes.Selection[0].GetDisplayText(0) != "全部" &&  this.treeListEventTypes.Selection[0].GetDisplayText(0).Trim() != string.Empty;;;
            }
            //麻醉方法
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                labelControlTip.Visible = true;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewMethod.RowCount > 0;
            }
            //麻醉常用量
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage)
            {
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = this.treeListEventType.Selection != null && this.treeListEventType.Selection[0].GetDisplayText(0) != "全部" && this.treeListEventType.Selection[0].GetDisplayText(0).Trim() != string.Empty; ;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEventDosage.RowCount > 0 && this.treeListEventType.Selection[0].GetDisplayText(0) != "全部" && this.treeListEventType.Selection[0].GetDisplayText(0).Trim() != string.Empty; ;
            }
            //监护仪
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewEQ.RowCount > 0;
            }
            //手术间
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                labelControlTip.Visible = false;
                this.btnAdd.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnDel.Enabled = this.gridViewOperRoom.RowCount > 0;
            }
            //其它
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther)
            {
                labelControlTip.Visible = false;
                //this.btnAdd.Enabled = false;
                //this.btnSave.Enabled = false;
                //this.btnDel.Enabled = this.gridViewOther.RowCount > 0;
                if (treeListOther.FocusedNode == treeListOther.Nodes[0])
                    treeListOther.FocusedNode = treeListOther.Nodes[1];
            }
        }
        private void treeListNormal_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (e.Node.GetDisplayText(0) == "常用术语" || e.Node.GetDisplayText(0) == "全部")
                e.CanFocus = false;
        }
        #endregion

        #region 输入校验
        private void gridViewKind_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_NAME" )
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 500)
                    {
                        e.ErrorText = "名称长度超出范围,应小于等于500个字符!";
                        e.Valid = false;
                        return;
                    }
                    if (_inputDictData != null)
                    {
                       
                        int index = gridViewKind.GetDataSourceRowIndex(gridViewKind.FocusedRowHandle);

                        for(int i=0;i<_inputDictData.Count;i++)
                        {
                            if(_inputDictData[i].ITEM_NAME.Trim()== e.Value.ToString().Trim() && i!=index)
                            {
                                e.ErrorText = string.Format("已存在相同的名称'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }
                        
                    }
                }
                
            }
            else if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_CLASS" )
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "分类不能为空!";
                    e.Valid = false;
                }
               
            }
            else if (this.gridViewKind.FocusedColumn.FieldName == "ITEM_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length >= 39)
                {
                    e.Valid = false;
                    e.ErrorText = "编码长度超出范围,应小于等于40个字符!";
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
            
        }


        private void gridViewEvent_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow row = gridViewEvent.GetDataRow(gridViewEvent.FocusedRowHandle);
            Dict.AnesthesiaEventOpenRow openrow = _eventOpenDataTalbe.FindByITEM_NOITEM_CLASS((decimal)row["ITEM_NO"], row["ITEM_CLASS"].ToString());
            if (gridViewEvent.FocusedColumn.FieldName == "ITEM_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "事件名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 59)
                    {
                        e.Valid = false;
                        e.ErrorText = "事件名称长度超出范围,应小于等于60个字符!";
                        return;
                    }
                    if (_eventOpenDataTalbe != null)
                    {
                        int index = gridViewEvent.GetDataSourceRowIndex(gridViewEvent.FocusedRowHandle);

                        for (int i = 0; i < _eventOpenDataTalbe.Count; i++)
                        {
                            if (_eventOpenDataTalbe[i].IsITEM_NAMENull())
                                continue;
                            if (_eventOpenDataTalbe[i].ITEM_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("已存在相同的事件名称'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }
                    }
                }
            }

            //else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE_UNITS")
            //{
            //    if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
            //    {
            //        e.ErrorText = "剂量单位不能为空!";
            //        e.Valid = false;
            //    }
            //}
            else if (gridViewEvent.FocusedColumn.FieldName == "ITEM_SPEC")
            {
                if (e.Value != null && e.Value.ToString().Length >= 20)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于20个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于20个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "REL_BILL")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetREL_BILLNull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 1)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于1个字符!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "DOSAGE")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetDOSAGENull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "CONCENTRATION")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetCONCENTRATIONNull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "CONCENTRATION_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于20个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "PERFORM_SPEED")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetPERFORM_SPEEDNull();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "SPEED_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于20个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "ADMINISTRATOR")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于8个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "DURATIVE_INDICATOR")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于1个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "EVENT_ATTR")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于10个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "EVENT_ATTR_2")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于20个字符!";
                }
            }
            else if (gridViewEvent.FocusedColumn.FieldName == "OPER_CLASS")
            {
                if (e.Value != null && e.Value.ToString().Length > 16)
                {
                    e.Valid = false;
                    e.ErrorText = "长度超出范围,应小于等于16个字符!";
                }
            }
                
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;

        }
        

        private void gridViewMethod_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewMethod.FocusedColumn.FieldName == "ANES_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "麻醉方法名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 39)
                    {
                        e.Valid = false;
                        e.ErrorText = "麻醉方法名称长度超出范围,应小于等于40个字符!";
                        return;
                    }

                    if (_dictDataTable != null)
                    {

                        int index = gridViewMethod.GetDataSourceRowIndex(gridViewMethod.FocusedRowHandle);

                        for (int i = 0; i < _dictDataTable.Count; i++)
                        {
                            if (_dictDataTable[i].ANES_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("已存在相同的名称'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "INPUT_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "输入码长度超出范围,应小于等于8个字符!";
                   
                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "ANES_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "编码长度超出范围,应小于等于1个字符!";
                  
                }
            }
            else if (gridViewMethod.FocusedColumn.FieldName == "ANAESTHESIA_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 15)
                {
                    e.Valid = false;
                    e.ErrorText = "分类长度超出范围,应小于等于16个字符!";
                   
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }
        
        private void gridViewEventDosage_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow row = gridViewEventDosage.GetDataRow(gridViewEventDosage.FocusedRowHandle);
            Dict.AnesthesiaEventOpenRow openrow = _eventOpenCommonDataTalbe.FindByITEM_NOITEM_CLASS((decimal)row["ITEM_NO"], row["ITEM_CLASS"].ToString());
            if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "事件名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >= 59)
                    {
                        e.Valid = false;
                        e.ErrorText = "事件名称长度超出范围,应小于等于60个字符!";
                        return;
                    }
                    if (_eventOpenCommonDataTalbe != null)
                    {
                        int index = gridViewEventDosage.GetDataSourceRowIndex(gridViewEventDosage.FocusedRowHandle);

                        for (int i = 0; i < _eventOpenCommonDataTalbe.Count; i++)
                        {
                            if (_eventOpenCommonDataTalbe[i].IsITEM_NAMENull())
                                continue;
                            if (_eventOpenCommonDataTalbe[i].ITEM_NAME.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("已存在相同的事件名称'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }
                    }
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_CLASS")
            {
                if (e.Value != null && e.Value.ToString().Length > 2)
                {
                    e.Valid = false;
                    e.ErrorText = "分类长度超出范围,应小于等于2个字符!";
                   
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "ITEM_SPEC")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "药品规格长度超出范围,应小于等于20个字符!";
                   
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "DOSAGE_UNITS")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "单位长度超出范围,应小于等于8个字符!";

                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE_1")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetSTANDARD_DOSAGE_1Null();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE_2")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetSTANDARD_DOSAGE_2Null();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE_3")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetSTANDARD_DOSAGE_3Null();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            else if (gridViewEventDosage.FocusedColumn.FieldName == "STANDARD_DOSAGE_4")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.Value = null;
                    openrow.SetSTANDARD_DOSAGE_4Null();
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "长度超出范围,应小于等于8个字符!";
                    }
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        private void gridViewOther_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewOther.FocusedColumn.FieldName == "DIAGNOSIS_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "诊断名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if ( e.Value.ToString().Length >= 39)
                    {
                        e.Valid = false;
                        e.ErrorText = "诊断名称长度超出范围,应小于等于40个字符!";
                       
                    }
                }
            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_ID")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "ID不能为空!";
                    e.Valid = false;
                }
                
            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 29)
                    {
                        e.Valid = false;
                        e.ErrorText = "名称长度超出范围,应小于等于30个字符!";
                      
                    }
                }
               
            }
            else if (gridViewOther.FocusedColumn.FieldName == "USER_DEPT")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "科室不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 16)
                    {
                        e.Valid = false;
                        e.ErrorText = "科室长度超出范围,应小于等于16个字符!";
                       
                    }
                }
            }
            else if (gridViewOther.FocusedColumn.FieldName == "OPER_NAME")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "手术名称不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value.ToString().Length >= 60)
                    {
                        e.Valid = false;
                        e.ErrorText = "手术名称长度超出范围,应小于等于60个字符!";
                      
                    }
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        private void gridViewEQ_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewEQ.FocusedColumn.FieldName == "MONITOR_LABEL")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "监护仪标识不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 10)
                    {
                        e.Valid = false;
                        e.ErrorText = "监护仪标识长度超出范围,应小于等于10个字符!";
                        return;
                    }

                    if (_monitorTable != null)
                    {

                        int index = gridViewEQ.GetDataSourceRowIndex(gridViewEQ.FocusedRowHandle);

                        for (int i = 0; i < _monitorTable.Count; i++)
                        {
                            if (_monitorTable[i].MONITOR_LABEL.Trim() == e.Value.ToString().Trim() && i != index)
                            {
                                e.ErrorText = string.Format("已存在相同的名称'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MANU_FIRM_NAME")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "厂家长度超出范围,应小于等于20个字符!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MODEL")
            {
                if (e.Value != null && e.Value.ToString().Length > 20)
                {
                    e.Valid = false;
                    e.ErrorText = "型号长度超出范围,应小于等于20个字符!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "INTERFACE_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "接口类型超出范围,应等于1个字符!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "IP_ADDR")
            {
                if (e.Value != null && e.Value.ToString().Length > 15)
                {
                    e.Valid = false;
                    e.ErrorText = "IP地址长度超出范围,应小于等于15个字符!";

                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "COMM_PORT")
            {
                if (e.Value != null && e.Value.ToString().Length > 6)
                {
                    e.Valid = false;
                    e.ErrorText = "通讯串口长度超出范围,应小于等于6个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "DRIVER_PROG")
            {
                if (e.Value != null && e.Value.ToString().Length > 100)
                {
                    e.Valid = false;
                    e.ErrorText = "采集程序长度超出范围,应小于等于100个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "ITEM_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "仪器分类长度超出范围,应等于个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "CURRENT_RECV_ITEMS")
            {
                if (e.Value != null && e.Value.ToString().Length > 100)
                {
                    e.Valid = false;
                    e.ErrorText = "必采项长度超出范围,应小于等于100个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "WARD_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 8)
                {
                    e.Valid = false;
                    e.ErrorText = "科室代码长度超出范围,应小于等于8个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "WARD_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "科室类型长度超出范围,应小于等于1个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "BED_NO")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "床号(手术间)长度超出范围,应小于等于10个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "PC_PORT")
            {
                if (e.Value != null && e.Value.ToString().Length > 5)
                {
                    e.Valid = false;
                    e.ErrorText = "PC端口长度超出范围,应小于等于5个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "DATALOG_STATUS")
            {
                if (e.Value != null && e.Value.ToString().Length > 4)
                {
                    e.Valid = false;
                    e.ErrorText = "状态长度超出范围,应小于等于4个字符!";
                }
            }
            else if (gridViewEQ.FocusedColumn.FieldName == "MEMO")
            {
                if (e.Value != null && e.Value.ToString().Length > 50)
                {
                    e.Valid = false;
                    e.ErrorText = "备注长度超出范围,应小于等于50个字符!";
                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }
        private void gridViewOperRoom_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridViewOperRoom.FocusedColumn.FieldName == "ROOM_NO")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "手术间号不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length >4)
                    {
                        e.Valid = false;
                        e.ErrorText = "手术间号长度超出范围,应小于等于4个字符!";
                        return;
                    }

                    if (_operRoomTable != null)
                    {

                        int index = gridViewOperRoom.GetDataSourceRowIndex(gridViewOperRoom.FocusedRowHandle);

                        for (int i = 0; i < _operRoomTable.Count; i++)
                        {
                            if (_operRoomTable[i].ROOM_NO.Trim() == e.Value.ToString().Trim() && _operRoomTable[i].DEPT_CODE.Trim() == _operRoomTable[index].DEPT_CODE.Trim() && i != index)
                            {
                                e.ErrorText = string.Format("同一科室已存在相同手术间号'{0}'!", e.Value);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "DEPT_CODE")
            {
                if (e.Value == null || (e.Value != null && string.IsNullOrEmpty(e.Value.ToString().Trim())))
                {
                    e.ErrorText = "科室代码不能为空!";
                    e.Valid = false;
                }
                else
                {
                    if (e.Value != null && e.Value.ToString().Length > 8)
                    {
                        e.Valid = false;
                        e.ErrorText = "科室代码长度超出范围,应小于等于8个字符!";
                        return;
                    }

                    if (_operRoomTable != null)
                    {

                        int index = gridViewOperRoom.GetDataSourceRowIndex(gridViewOperRoom.FocusedRowHandle);

                        for (int i = 0; i < _operRoomTable.Count; i++)
                        {
                            if (_operRoomTable[i].DEPT_CODE.Trim() == e.Value.ToString().Trim() && _operRoomTable[i].ROOM_NO.Trim() == _operRoomTable[index].ROOM_NO.Trim() && i != index)
                            {

                                e.ErrorText = string.Format("同一科室已存在相同手术间号'{0}'!", _operRoomTable[index].ROOM_NO);
                                e.Valid = false;
                                break;
                            }
                        }

                    }
                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "LOCATION")
            {
                if (e.Value != null && e.Value.ToString().Length > 10)
                {
                    e.Valid = false;
                    e.ErrorText = "位置长度超出范围,应小于等于10个字符!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "STATUS")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "状态长度超出范围,应等于1个字符!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_ID")
            {
                if (e.Value != null && e.Value.ToString().Length > 4)
                {
                    e.Valid = false;
                    e.ErrorText = "床号长度超出范围,应小于等于4个字符!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_LABEL")
            {
                if (e.Value != null && e.Value.ToString().Length > 12)
                {
                    e.Valid = false;
                    e.ErrorText = "床位标号长度超出范围,应小于等于12个字符!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "MONITOR_CODE")
            {
                if (e.Value != null && e.Value.ToString().Length > 5)
                {
                    e.Valid = false;
                    e.ErrorText = "监护仪代码长度超出范围,应小于等于5个字符!";

                }
            }
            else if (gridViewOperRoom.FocusedColumn.FieldName == "BED_TYPE")
            {
                if (e.Value != null && e.Value.ToString().Length > 1)
                {
                    e.Valid = false;
                    e.ErrorText = "手术间类型长度超出范围,应等于1个字符!";

                }
            }
            this.btnDel.Enabled = e.Valid;
            this.btnCancel.Enabled = e.Valid;
        }

        /// <summary>
        /// 验证新添加的数据行
        /// </summary>
        /// <returns></returns>
        private bool ValidateNewRow()
        {
            //常用术语
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormal)
            {
                var row = this.gridViewKind.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ITEM_NAME"] == null || string.IsNullOrEmpty(row["ITEM_NAME"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
            //麻醉事件
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesEvents)
            {
                var row = this.gridViewEvent.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ITEM_NAME"] == null || string.IsNullOrEmpty(row["ITEM_NAME"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入事件名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
              //if (row["DOSAGE_UNITS"] == null || string.IsNullOrEmpty(row["DOSAGE_UNITS"].ToString().Trim()))
                //{
                //    XtraMessageBox.Show("请输入剂量单位!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}

                
            }
            //麻醉方法
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageAnesMethod)
            {
                var row = this.gridViewMethod.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ANES_NAME"] == null || string.IsNullOrEmpty(row["ANES_NAME"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入麻醉方法名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //麻醉常用量
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageNormalDosage)
            {
                var row = this.gridViewEventDosage.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ITEM_NAME"] == null || string.IsNullOrEmpty(row["ITEM_NAME"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入事件名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //监护仪
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageMonitorDict)
            {
                var row = this.gridViewEQ.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["MONITOR_LABEL"] == null || string.IsNullOrEmpty(row["MONITOR_LABEL"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入监护仪标识!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //手术间
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOperRoom)
            {
                var row = this.gridViewOperRoom.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["ROOM_NO"] == null || string.IsNullOrEmpty(row["ROOM_NO"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入手术间号!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (row["DEPT_CODE"] == null || string.IsNullOrEmpty(row["DEPT_CODE"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入手术间科室代码!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            //其它
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageOther)
            {
                var row = this.gridViewOther.GetFocusedDataRow();
                if (row == null)
                    return false;
                if (row.Table.Columns.Contains("DIAGNOSIS_NAME"))
                {
                    if (row["DIAGNOSIS_NAME"] == null || string.IsNullOrEmpty(row["DIAGNOSIS_NAME"].ToString().Trim()))
                    {
                        XtraMessageBox.Show("请输入诊断名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("USER_NAME"))
                {
                    if (row["USER_NAME"] == null || string.IsNullOrEmpty(row["USER_NAME"].ToString().Trim()))
                    {
                        XtraMessageBox.Show("请输入名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("USER_ID"))
                {
                    string userName = row["USER_NAME"].ToString().Trim().Length > 7 ? row["USER_NAME"].ToString().Trim().Remove(7) : row["USER_NAME"].ToString().Trim();
                    string filterString = "USER_ID LIKE'" + userName + "%'";
                    Dict.HisUserDataTable data = DictProxy.GetHisUsers();
                    if (data != null && data.Select(filterString).Length > 0)
                    {
                        row["USER_ID"] = userName + data.Select(filterString).Length.ToString();
                    }
                    else
                    {
                        row["USER_ID"] = userName;
                    }
                }
                if (row.Table.Columns.Contains("USER_DEPT"))
                {
                    if (row["USER_DEPT"] == null || string.IsNullOrEmpty(row["USER_DEPT"].ToString().Trim()))
                    {
                        XtraMessageBox.Show("请输入科室!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (row.Table.Columns.Contains("OPER_NAME"))
                {
                    if (row["OPER_NAME"] == null || string.IsNullOrEmpty(row["OPER_NAME"].ToString().Trim()))
                    {
                        XtraMessageBox.Show("请输入手术名称!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;

        }
        #endregion
        private void gridViewKind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewKind.FocusedRowHandle;
                    if (rowHandler < gridViewKind.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewKind.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewKind.GetDataRow(rowHandler + 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SERIAL_NO"]);
                        rowcurrent["SERIAL_NO"] = rowNext["SERIAL_NO"];
                        rowNext["SERIAL_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewKind.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewKind.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewKind.GetDataRow(rowHandler - 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SERIAL_NO"]);
                        rowcurrent["SERIAL_NO"] = rowNext["SERIAL_NO"];
                        rowNext["SERIAL_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }


            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void gridViewEvent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewEvent.FocusedRowHandle;
                    if (rowHandler < gridViewEvent.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewEvent.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewEvent.GetDataRow(rowHandler + 1);

                        foreach (DataColumn column in rowcurrent.Table.Columns)
                        {
                            if (column.ColumnName.ToUpper() == "ITEM_NO")
                                continue;

                            object obj = rowcurrent[column];
                            rowcurrent[column] = rowNext[column];
                            rowNext[column] = obj;
                        }

                        //e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewEvent.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewEvent.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewEvent.GetDataRow(rowHandler - 1);

                        foreach (DataColumn column in rowcurrent.Table.Columns)
                        {
                            if (column.ColumnName.ToUpper() == "ITEM_NO")
                                continue;

                            object obj = rowcurrent[column];
                            rowcurrent[column] = rowNext[column];
                            rowNext[column] = obj;
                        }

                        //e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }


            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void gridViewMethod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridViewMethod.FocusedRowHandle;
                    if (rowHandler < gridViewMethod.RowCount - 1)
                    {
                        DataRow rowcurrent = gridViewMethod.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewMethod.GetDataRow(rowHandler + 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SERIAL_NO"]);
                        rowcurrent["SERIAL_NO"] = rowNext["SERIAL_NO"];
                        rowNext["SERIAL_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }
                else if (e.KeyValue == 38 && e.Alt)
                {
                    int rowHandler = gridViewMethod.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridViewMethod.GetDataRow(rowHandler);
                        DataRow rowNext = gridViewMethod.GetDataRow(rowHandler - 1);

                        int tempIndex = Convert.ToInt32(rowcurrent["SERIAL_NO"]);
                        rowcurrent["SERIAL_NO"] = rowNext["SERIAL_NO"];
                        rowNext["SERIAL_NO"] = tempIndex;

                        e.Handled = true;
                        btnSave.Enabled = true;
                    }
                }


            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (_currentIsAdding)
            {
                Dialog.MessageBox("当前处于新增状态，请先完成新增操作后再选择其他字典页。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
    }


    public enum EditMode
    {
        Add,
        Save,
        Cancel,
        Delete,
        Refresh
    }
}
