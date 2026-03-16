using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls;
using DevExpress.XtraTreeList.Nodes;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Permissions;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class EventTemplet : XtraUserControl
    {
        private bool _isApply=false;
        private EventTempletDetail currentTemplet;
        Dictionary<string, string> rootDict;
        private Dict.AnesthesiaEventTempletDataTable _anesthesiaEventTemplet;
        private decimal _eventNo = 0;
        private bool _hasPublicTempletRight = false;
        private bool _hasTotalRight = false;

        public EventTemplet()
        {
            InitializeComponent();
            btnExit.Visible = false;
            btnApply.Visible = false;
            checkEdit1.Visible = false;
            btnSave.Enabled = false;
            flowLayoutPanel1.Width = 250;
            medPanel1.Visible = false;

            dateEditStart.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventNo">0麻醉事件，1复苏事件，2体外事件</param>
        public EventTemplet(decimal eventNo)
        {
            
            InitializeComponent();
            _eventNo = eventNo;
            _isApply = true;
            btnDel.Visible = false;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
            gridView1.OptionsBehavior.Editable = false;
            //Add By chengying.x @20140213 
            dateEditStart.Location = new Point(flowLayoutPanel1.Left + this.checkEdit1.Left - 30, checkEdit1.Top+4);
            dateEditStart.DateTime = DateTime.Now;
            //End Add
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            rootDict = new Dictionary<string, string>();
            rootDict.Add("0", "麻醉事件模板");
            rootDict.Add("1", "复苏事件模板");
            rootDict.Add("2", "体外事件模板");
            Dictionary<string, EventTempletDetail> tmplist1 = new Dictionary<string, EventTempletDetail>();
            treeList1.Nodes.Clear();
            if (_isApply)
            {
                TreeListNode node = treeList1.AppendNode(new object[] { rootDict[_eventNo.ToString()] }, null);
                treeList1.AppendNode(new object[] { "公用" }, node);
                treeList1.AppendNode(new object[] { "私有" }, node);
            }
            else
            {
                _eventNo = ExtendApplicationContext.Current.EventNo;
                TreeListNode node = treeList1.AppendNode(new object[] { rootDict[_eventNo.ToString()] }, null);
                treeList1.AppendNode(new object[] { "公用" }, node);
                treeList1.AppendNode(new object[] { "私有" }, node);
                //if (ExtendApplicationContext.Current.AppType.Equals(ApplicationType.CardiopulmonaryBypass))
                //{
                //    TreeListNode node = treeList1.AppendNode(new object[] { "体外事件模板" }, null);
                //    treeList1.AppendNode(new object[] { "公用" }, node);
                //    treeList1.AppendNode(new object[] { "私有" }, node);
                //}
                //else
                //{
                //    TreeListNode node1 = treeList1.AppendNode(new object[] { "麻醉事件模板" }, null);
                //    treeList1.AppendNode(new object[] { "公用" }, node1);
                //    treeList1.AppendNode(new object[] { "私有" }, node1);
                //    TreeListNode node2 = treeList1.AppendNode(new object[] { "复苏事件模板" }, null);
                //    treeList1.AppendNode(new object[] { "公用" }, node2);
                //    treeList1.AppendNode(new object[] { "私有" }, node2);
                //}
            }
            DictDA _dictDA = new DictDA();
            _anesthesiaEventTemplet = _dictDA.GetAnesthesiaEventTemplet();
            string filterStr = "(CREATE_BY='公用' OR CREATE_BY='" + ExtendApplicationContext.Current.LoginUserContext.HisUserID+ "')";
            //if (_isApply)
            //{
                filterStr += " AND TEMPLET_CLASS='"+_eventNo+"'";
            //}
            DataRow[] rows = _anesthesiaEventTemplet.Select(filterStr);

            foreach (DataRow row in rows)
            {
                if (!tmplist1.ContainsKey(row["TEMPLET"].ToString()))
                {
                    EventTempletDetail tmp = new EventTempletDetail();
                    tmp.Owner = row["CREATE_BY"].ToString();
                    tmp.Name = row["TEMPLET"].ToString();
                    tmp.AnesMethod = row["ANES_METHOD"].Equals("*")?"通用":row["ANES_METHOD"].ToString();
                    tmp.TempletClass = row["TEMPLET_CLASS"].ToString();
                    tmplist1.Add(row["TEMPLET"].ToString(), tmp);
                }
            }          
            Dictionary<string, EventTempletDetail>.Enumerator enumertor = tmplist1.GetEnumerator();
            while (enumertor.MoveNext())
            {
                if (rootDict.ContainsKey(enumertor.Current.Value.TempletClass))
                {
                    AppendNode(enumertor.Current.Value);
                }
            }
            treeList1.ExpandAll();
        }

        private void AppendNode(EventTempletDetail templet)
        {
            TreeListNode rootnode=treeList1.Nodes[0];
            foreach (TreeListNode node in treeList1.Nodes)
            {
                if (node.GetDisplayText(0) ==rootDict[templet.TempletClass])
                {
                    rootnode = node;
                }
            }
            if(templet.Owner.Equals("公用"))
            {
                AppendNode(rootnode.Nodes[0], templet);
            }
            else
            {
                AppendNode(rootnode.Nodes[1], templet);
            }
        }

        private void AppendNode(TreeListNode parentNode, EventTempletDetail templet)
        {
            if (parentNode != null)
            {
                TreeListNode newNode = null;
                foreach (TreeListNode node in parentNode.Nodes)
                {
                    if (node.GetDisplayText(0).Equals(templet.AnesMethod))
                    {
                        newNode = treeList1.AppendNode(new object[] { templet.Name }, node);
                        break;
                    }
                }
                if (newNode == null)
                {
                    treeList1.AppendNode(new object[]{templet.Name},treeList1.AppendNode(new object[] { templet.AnesMethod }, parentNode));
                }
            }
        }

        /// <summary>
        /// 下拉菜单初始化
        /// </summary>
        private void InitSelectItems()
        {
            DictDA _dictDA = new DictDA();
            Dict.AnesthesiaInputDictDataTable inputDict = _dictDA.GetDictTable("用药途径");
            foreach (Dict.AnesthesiaInputDictRow row in inputDict)
            {
                this.repositoryItemComboBox1.Items.Add(row.ITEM_NAME);
            }
            inputDict = _dictDA.GetDictTable("用药单位");
            foreach (Dict.AnesthesiaInputDictRow row in inputDict)
            {
                this.repositoryItemComboBox2.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox3.Items.Add(row.ITEM_NAME);
                this.repositoryItemComboBox4.Items.Add(row.ITEM_NAME);
            }
            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            Dictionary<string, string>.Enumerator enumerator;
            if (_eventNo != 2)
            {
                repositoryItemLookUpEdit1.DataSource = EventTypeHelper.GetItemList();
            }
            else
            {
                enumerator = EventTypeHelper.CPBEventType.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    data1.Add(new LookUpEditItem(enumerator.Current.Key, enumerator.Current.Value));
                }
                repositoryItemLookUpEdit1.DataSource = data1;
            }
        }

        public bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        public bool Save()
        {
            bool b=false;
            DictDA _dictDA = new DictDA();
            if (_dictDA.UpdateAnesthesiaEventTemplet(_anesthesiaEventTemplet) > 0)
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// 绑定表格数据源
        /// </summary>
        private void BindGrid(string templetName)
        {
            _anesthesiaEventTemplet.DefaultView.RowFilter = "TEMPLET = '" + templetName + "'";
            gridControl1.DataSource = _anesthesiaEventTemplet;
        }

        private void CheckRight()
        {
            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                flowLayoutPanel1.Visible = false;
                gridView1.OptionsBehavior.Editable = false;
            }
            else
            {
                _hasTotalRight = true;
            }
            if (AccessControl.CheckModifyRight(PermissionContext.PublicTempletEdit))
            {
                _hasPublicTempletRight = true;
            }
        }

        private void EventTemplet_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CheckRight();
                InitTreeList();
                InitSelectItems();
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.ParentNode!=null&&e.Node.ParentNode.ParentNode != null && !e.Node.HasChildren)
            {
                BindGrid(e.Node.GetDisplayText(0));
                if (gridView1.RowCount > 0 && gridView1.FocusedRowHandle > -1)
                {
                    btnDel.Enabled = true;
                }
                else
                {
                    btnDel.Enabled = false;
                }
                btnApply.Enabled = true;
                EventTempletDetail templet = new EventTempletDetail();
                templet.Name = e.Node.GetDisplayText(0);
                templet.AnesMethod = e.Node.ParentNode.GetDisplayText(0);
                if (e.Node.ParentNode.ParentNode.GetDisplayText(0).Equals("私有"))
                {
                    templet.Owner = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                }
                else
                {
                    templet.Owner = "公用";
                    if (!ExtendApplicationContext.Current.LoginUserContext.IsManager && !_hasPublicTempletRight)
                    {
                        btnDel.Enabled = false;
                    }
                }
                currentTemplet = templet;
            }
            else
            {
                gridControl1.DataSource = null;
                btnApply.Enabled = false;
                btnDel.Enabled = false;
            }
            btnSave.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridControl1.DataSource != null)
            {
                DataRow row= gridView1.GetFocusedDataRow();
                if (row != null)
                {
                    row.Delete();
                    btnSave.Enabled = true;
                }
            }
        }
        public object DialogResultData;
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                currentTemplet.IsApplyDosage = !checkEdit1.Checked;
                currentTemplet.StartTime = dateEditStart.DateTime;
                DialogResultData = currentTemplet;
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Dialog.MessageBox("保存成功");
                btnSave.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
                DialogResultData = null;
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!_hasTotalRight) return;
                Point clickPoint = new Point(e.X, e.Y);
                DevExpress.XtraTreeList.TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell) //在单元格上右击了 
                {
                    TreeListNode node = hInfo.Node;
                    treeList1.FocusedNode = node;
                    if (!_isApply && hInfo.Node != null && hInfo.Node.ParentNode != null && hInfo.Node.ParentNode.ParentNode != null && !hInfo.Node.HasChildren)
                    {
                        ToolStripMenuItemChangePrivate.Visible = ExtendApplicationContext.Current.LoginUserContext.IsManager && hInfo.Node.ParentNode.ParentNode.GetDisplayText(0).Equals("私有");
                        if (ExtendApplicationContext.Current.LoginUserContext.IsManager || hInfo.Node.ParentNode.ParentNode.GetDisplayText(0).Equals("私有")||_hasPublicTempletRight)
                        {
                            contextMenuStrip1.Show(treeList1, e.X, e.Y);
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTemplet.Name))
            {
                object model = Dialog.SingleInputSelect("请输入新的模板名称", currentTemplet.Name);
                if (model != null)
                {
                    string modelName = model.ToString().Trim();
                    if (!string.IsNullOrEmpty(modelName)&&!modelName.Equals(currentTemplet.Name))
                    {
                        if (_anesthesiaEventTemplet.Select("TEMPLET='" + modelName + "'").Length > 0)
                        {
                            Dialog.MessageBox("模板名已存在！");
                            return;
                        }
                        _anesthesiaEventTemplet.AcceptChanges();
                        foreach (Dict.AnesthesiaEventTempletRow row in _anesthesiaEventTemplet)
                        {
                            if (row.TEMPLET.Equals(currentTemplet.Name))
                            {
                                row.TEMPLET = modelName;
                            }
                        }
                        DictDA _dictDA = new DictDA();
                        if (_dictDA.UpdateAnesthesiaEventTemplet(_anesthesiaEventTemplet) >= 0)
                        {
                            InitTreeList();
                        }
                    }
                }
            }
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTemplet.Name))
            {
                if (Dialog.MessageBox("真的要删除当前所选模板吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0) == DialogResult.Yes)
                {
                    _anesthesiaEventTemplet.AcceptChanges();
                    for (int i = _anesthesiaEventTemplet.Count - 1; i >= 0; i--)
                    {
                        Dict.AnesthesiaEventTempletRow row = _anesthesiaEventTemplet[i];
                        if (row.TEMPLET.Equals(currentTemplet.Name))
                        {
                            row.Delete();
                        }
                    }
                    DictDA _dictDA = new DictDA();
                    if (_dictDA.UpdateAnesthesiaEventTemplet(_anesthesiaEventTemplet) >= 0)
                    {
                        InitTreeList(); ;
                    }
                }
            }
        }

        private void ToolStripMenuItemChangePrivate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTemplet.Name) && !string.IsNullOrEmpty(currentTemplet.Owner) && currentTemplet.Owner!="公用")
            {
                foreach (Dict.AnesthesiaEventTempletRow row in _anesthesiaEventTemplet)
                {
                    if (row.TEMPLET.Equals(currentTemplet.Name))
                    {
                        row.CREATE_BY = "公用";
                    }
                }
                DictDA _dictDA = new DictDA();
                if (_dictDA.UpdateAnesthesiaEventTemplet(_anesthesiaEventTemplet) >= 0)
                {
                    InitTreeList();
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void treeList1_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult dr = Dialog.MessageBox("当前模板修改未保存，是否确定要离开？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    _anesthesiaEventTemplet.RejectChanges();
                }
                else
                {
                    e.CanFocus = false;
                }
            }

        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 40 && e.Alt)
                {
                    int rowHandler = gridView1.FocusedRowHandle;
                    if (rowHandler < gridView1.RowCount - 1)
                    {
                        DataRow rowcurrent = gridView1.GetDataRow(rowHandler);
                        DataRow rowNext = gridView1.GetDataRow(rowHandler + 1);

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
                    int rowHandler = gridView1.FocusedRowHandle;
                    if (rowHandler > 0)
                    {
                        DataRow rowcurrent = gridView1.GetDataRow(rowHandler);
                        DataRow rowNext = gridView1.GetDataRow(rowHandler - 1);

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
    }
}
