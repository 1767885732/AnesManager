using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Constants;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Utilities;
using System.Reflection;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Views.BillManager;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class FeeTemplet : XtraUserControl
    {
        private bool _isApply = false;
        private UserControl_BillBody _billBody;
        private DataTable _dataSource = null;

        /// <summary>
        /// 模板管理构造方法
        /// </summary>
        public FeeTemplet()
        {
            _billBody = new UserControl_BillBody(2);
            InitializeComponent();
            btnExit.Visible = false;
            //btnClear.Visible = false;
            //btnSave.Enabled = false;
            //flowLayoutPanel1.Width = 250;
            medPanel1.Visible = false;
        }

        public bool IsDirty
        {
            get
            {
                return btnSave.Enabled;
            }
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            treeList1.Nodes.Clear();
            if (_isApply)
            {
            }
            else
            {
                TreeListNode anesFee = treeList1.AppendNode(new object[] { "麻醉收费模板" }, null);
                anesFee.Tag = "麻醉收费模板";
                TreeListNode operFee = treeList1.AppendNode(new object[] { "手术收费模板" }, null);
                operFee.Tag = "手术收费模板";

                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                foreach (Wis.Anes.BusinessEntity.Configuations.DocumentRow row in dataTable)
                {
                    if (row.DOCUMENTNAME.Equals("麻醉收费模板"))
                    {
                        treeList1.AppendNode(new object[] { row.DOCUMENTPATH }, anesFee);
                    }
                    else if (row.DOCUMENTNAME.Equals("手术收费模板"))
                    {
                        treeList1.AppendNode(new object[] { row.DOCUMENTPATH }, operFee);
                    }
                }
            }
            treeList1.ExpandAll();
        }

        private void CheckRight()
        {
            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                flowLayoutPanel1.Visible = false;
                _billBody.ReadOnly = true;
            }
        }

        public bool Save()
        {
            bool b = false;
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode != null)
            {
                if (!_billBody.IsValidData())
                {
                    Dialog.MessageBox("还有没填写完整的数据", MessageBoxIcon.Exclamation);
                    return false;
                }

                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                if (dataTable == null)
                {
                    Dialog.MessageBox("获取模板出错", MessageBoxIcon.Exclamation);
                    return false;
                }

                DataTable dt =  BillHelper.TransModelData(_billBody.DataSource);
                if(dt.Rows.Count == 0)
                {
                    Dialog.MessageBox("还没有输入数据", MessageBoxIcon.Exclamation);
                    return false;
                }

                string strTempletName = treeList1.FocusedNode.ParentNode.Tag.ToString();
                ApplicationConfiguration.ModifyDocumentTable(dataTable, strTempletName, treeList1.Selection[0].GetDisplayText(0), dt);
                int ret = new ConfigurationDA().UpdateDocument(dataTable);
                if (ret > 0)
                {
                    b = true;
                    Dialog.MessageBox("保存模板" + treeList1.Selection[0].GetDisplayText(0) + "成功");
                }
            }

            return b;
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!AccessControl.CheckModifyRight("模板管理"))
                {
                    return;
                }

                Point clickPoint = new Point(e.X, e.Y);
                DevExpress.XtraTreeList.TreeListHitInfo hInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                if (hInfo.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell) //在单元格上右击了 
                {
                    TreeListNode node = hInfo.Node;
                    treeList1.FocusedNode = node;
                    if (!_isApply)
                    {
                        if (hInfo.Node != null && hInfo.Node.ParentNode != null)
                        {
                            toolStripMenuItemAdd.Visible = false;
                            toolStripMenuItemDelete.Visible = true;
                            toolStripMenuItemRename.Visible = true;
                            contextMenuStrip1.Show(treeList1, e.X, e.Y);
                        }
                        else if (hInfo.Node != null)
                        {
                            toolStripMenuItemAdd.Visible = true;
                            toolStripMenuItemDelete.Visible = false;
                            toolStripMenuItemRename.Visible = false;
                            contextMenuStrip1.Show(treeList1, e.X, e.Y);
                        }
                    }

                }
                
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //if(_dataSource != null && _dataSource.der

            if (e.Node != null && !e.Node.HasChildren && e.Node.ParentNode != null)
            {
                //mRichBox.Enabled = true ;
                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                string strTempletName = treeList1.FocusedNode.ParentNode.Tag.ToString();
                _billBody.DataSource = ApplicationConfiguration.GetDataTableDocumentTable(dataTable, strTempletName, e.Node.GetDisplayText(0));
                if (_billBody.DataSource != null)
                {
                    _dataSource = _billBody.DataSource;
                }
                //else if (_dataSource != null)
                //{
                //    _billBody.DataSource = _dataSource;
                //}
                else
                {
                    Dict.OperationBillItemsDataTable table = new Dict.OperationBillItemsDataTable();
                    _billBody.DataSource = BillHelper.TransModelData(table);
                    _dataSource = _billBody.DataSource;
                }

                //btnClear.Enabled = true ;
            }
            else
            {
                //mRichBox.Text = string.Empty;
                //mRichBox.Enabled = false; ;
                //btnSave.Enabled = false;
                //btnClear.Enabled = false;
                _billBody.DataSource = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null)
            {
                if (ParentForm != null && ParentForm.Modal)
                {
                    ParentForm.DialogResult = DialogResult.OK;
                }
            }
        }

        private void DocumentTemplet_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                //btnClear.Visible = _isApply;
                btnExit.Visible = _isApply;
                btnSave.Visible = !_isApply;
                //mRichBox.Enabled = !_isApply;
                medSplitContainer1.Panel2.Controls.Add(_billBody);
                //medSplitContainer1.Panel2.Padding = new Padding(15, 15, 15, 15);
                _billBody.Dock = DockStyle.Fill;
                CheckRight();
                InitTreeList();
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode == null)
            {
                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                List<string> list = new List<string>();
                string strTempletName = treeList1.FocusedNode.Tag.ToString();
                foreach (Wis.Anes.BusinessEntity.Configuations.DocumentRow row in dataTable)
                {
                    if (row.DOCUMENTNAME.Equals(strTempletName) && !list.Contains(row.DOCUMENTPATH))
                    {
                        list.Add(row.DOCUMENTPATH);
                    }
                }
                object result = Dialog.SingleInputSelect("录入收费模板名称", "新增模板", "", "", list);
                if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
                {
                    treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                }
            }
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode != null)
            {
                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                string oldName = treeList1.FocusedNode.GetDisplayText(0);
                List<string> list = new List<string>();
                string strTempletName = treeList1.FocusedNode.ParentNode.Tag.ToString();
                foreach (Wis.Anes.BusinessEntity.Configuations.DocumentRow row in dataTable)
                {
                    if (row.DOCUMENTNAME.Equals(strTempletName) && !list.Contains(row.DOCUMENTPATH))
                    {
                        list.Add(row.DOCUMENTPATH);
                    }
                }
                object result = Dialog.SingleInputSelect("录入收费模板名称", "新增模板", oldName, "", list);
                if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()) && result.ToString().Trim() != oldName)
                {
                    Wis.Anes.BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(strTempletName, oldName);
                    if (row != null)
                    {
                        row.DOCUMENTPATH = result.ToString();
                    }
                    if (new ConfigurationDA().UpdateDocument(dataTable) > 0)
                    {
                        treeList1.FocusedNode.SetValue(0, result.ToString());
                    }
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null &&  treeList1.FocusedNode.ParentNode != null && Dialog.MessageBox("真的要删除模板" +treeList1.FocusedNode.GetDisplayText(0) + "吗？",Dialog.CAPTION
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string strTempletName = treeList1.FocusedNode.ParentNode.Tag.ToString();
                Wis.Anes.BusinessEntity.Configuations.DocumentDataTable dataTable = new ConfigurationDA().GetDocument();
                string oldName = treeList1.FocusedNode.GetDisplayText(0);
                Wis.Anes.BusinessEntity.Configuations.DocumentRow row = dataTable.FindByDOCUMENTNAMEDOCUMENTPATH(strTempletName, oldName);
                if (row != null)
                {
                    row.Delete();
                    if (new ConfigurationDA().UpdateDocument(dataTable) > 0)
                    {
                        treeList1.Nodes.Remove(treeList1.FocusedNode);
                    }
                }
                else
                {
                    treeList1.Nodes.Remove(treeList1.FocusedNode);
                }
            }
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode != null)
            {
                DataTable dt = _billBody.DataSource as DataTable;
                if (dt == null)
                    return;

                dt.Rows.Add(dt.NewRow());
            }
            //BillHelper.AddRow(dt,null,0,0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode != null)
            {
                _billBody.DeleteRow(null, 0, 0, 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            if (treeList1.FocusedNode != null && treeList1.FocusedNode.ParentNode != null)
            {
                string strTempletName = treeList1.FocusedNode.ParentNode.Tag.ToString();
                if (Dialog.MessageBox("确定要清空 " + treeList1.Selection[0].GetDisplayText(0) + " 吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Dict.OperationBillItemsDataTable table = new Dict.OperationBillItemsDataTable();
                    _billBody.DataSource = BillHelper.TransModelData(table);
                    _dataSource = _billBody.DataSource;
                }
            }
        }
      
    }
}
