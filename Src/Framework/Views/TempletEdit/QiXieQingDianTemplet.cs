using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.DataAccess;
using DevExpress.XtraTreeList.Nodes;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class QiXieQingDianTemplet : XtraUserControl
    {
        public string DialogResultData=string.Empty;
        public bool IsAddTempletData = false;
        private bool _hasTotalRight = false;
        private List<string> deptNames = new List<string>();
        CareDocsDA _careDocsDA = new CareDocsDA();
        DictDA _dictDA = new DictDA();
        Dict.DeptDictDataTable _deptDict;
        CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERDataTable _qiXieTempletMaster = null;
        CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILDataTable _qiXieTempletDetail = null;
        private bool _isApply = false;

        public bool IsApply
        {
            get { return _isApply; }
            set { _isApply = value; }
        }

        public QiXieQingDianTemplet()
        {
            InitializeComponent();
            btnApply.Visible = false; ;
            btnExit.Visible = false;
            btnDel.Visible = false;
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
            TreeListNode nodeZhuBao = treeList1.AppendNode(new object[] { "主包" }, null);
            nodeZhuBao.Tag = 0;
            TreeListNode nodeFuBao = treeList1.AppendNode(new object[] { "副包" }, null);
            nodeFuBao.Tag = 1;
            if (_qiXieTempletMaster != null && _qiXieTempletMaster.Count > 0)
            {
                foreach (CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow in _qiXieTempletMaster.Rows)
                {
                    AppendNode(prow);
                }
            }
            treeList1.ExpandAll();
        }

        private void AppendNode(CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow)
        {
            if (prow.OPER_BAG_FLAG == 0)
            {
                AppendNode(treeList1.Nodes[0], prow);
            }
            else if (prow.OPER_BAG_FLAG == 1)
            {
                AppendNode(treeList1.Nodes[1], prow);
            }
        }

        private void AppendNode(TreeListNode parentNode, CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow)
        {
            if (parentNode != null)
            {
                TreeListNode newNode = null;
                foreach (TreeListNode node in parentNode.Nodes)
                {
                    if (node.GetDisplayText(0).Equals(prow.CLASS_NAME))
                    {
                        newNode = treeList1.AppendNode(new object[] { prow.TEMPLET_NAME }, node);
                        newNode.Tag = prow.TEMPLET_GUID;
                        break;
                    }
                }
                if (newNode == null)
                {
                    newNode= treeList1.AppendNode(new object[] { prow.TEMPLET_NAME }, treeList1.AppendNode(new object[] { prow.CLASS_NAME }, parentNode));
                    newNode.Tag = prow.TEMPLET_GUID;
                }
            }
        }

        private void CheckRight()
        {
            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                flowLayoutPanel1.Visible = false;
                dataGridView1.ReadOnly = true;
            }
            else
            {
                _hasTotalRight = true;
            }
        }

        /// <summary>
        /// 载入表格数据
        /// </summary>
        private void LoadGridData(string templetGuid)
        {
            dataGridView1.Rows.Clear();
            _qiXieTempletDetail = _careDocsDA.GetQiXieTempletDetailByGuid(templetGuid);
            if (_qiXieTempletDetail != null && _qiXieTempletDetail.Count > 0)
            {
                int detailCount = _qiXieTempletDetail.Count;
               //int rowCount = (detailCount % 2 == 0) ? detailCount / 2 : detailCount / 2 + 1;
                dataGridView1.RowCount = detailCount+1;//rowCount + 1;
                for (int i = 0; i < detailCount; i++)//rowCount; i++)
                {
                    dataGridView1[0, i].Value = _qiXieTempletDetail[i].ITEM_NAME;
                    if (!_qiXieTempletDetail[i].IsITEM_VALUENull())
                    {
                        dataGridView1[1, i].Value = _qiXieTempletDetail[i].ITEM_VALUE;
                    }
                    //if ((i + rowCount) < detailCount)
                    //{
                    //    dataGridView1[2, i].Value = _qiXieTempletDetail[i + rowCount].ITEM_NAME;
                    //    if (!_qiXieTempletDetail[i + rowCount].IsITEM_VALUENull())
                    //    {
                    //        dataGridView1[3, i].Value = _qiXieTempletDetail[i + rowCount].ITEM_VALUE;
                    //    }
                    //}
                }
            }
            btnSave.Enabled = false;
        }

        private void QiXieQingDianTemplet_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                btnApply.Visible = IsApply;
                btnExit.Visible = IsApply;
                btnSave.Visible = !IsApply;
                checkEdit1.Visible = false;//IsApply;
                checkEdit1.Checked = true;
                CheckRight();
                _qiXieTempletMaster = _careDocsDA.GetQiXieTempletMaster();
                _deptDict = _dictDA.GetDeptDict();
                foreach (Dict.DeptDictRow row in _deptDict.Rows)
                {
                    deptNames.Add(row.DEPT_NAME);
                }
                InitTreeList();
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.ParentNode != null && e.Node.ParentNode.ParentNode != null && !e.Node.HasChildren)
            {
                LoadGridData(e.Node.Tag.ToString());
                dataGridView1.ReadOnly=false;
                btnApply.Enabled = true; ;
            }
            else
            {          
                dataGridView1.Rows.Clear();
                dataGridView1.ReadOnly=true;;
                btnSave.Enabled = false;
                btnApply.Enabled = false;
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
                    if (!_isApply && hInfo.Node != null)
                    {
                        toolStripMenuItemAdd.Visible = false; ;
                        toolStripMenuItemDelete.Visible = false;
                        toolStripMenuItemRename.Visible = false;
                        if (hInfo.Node.ParentNode != null && hInfo.Node.ParentNode.ParentNode != null && !hInfo.Node.HasChildren)
                        {
                            toolStripMenuItemAdd.Visible = false;
                            toolStripMenuItemDelete.Visible = true;
                            toolStripMenuItemRename.Visible = true;
                        }
                        else if (hInfo.Node.HasChildren || hInfo.Node.ParentNode == null || hInfo.Node.ParentNode.ParentNode==null)
                        {
                            toolStripMenuItemAdd.Visible = true;
                            toolStripMenuItemDelete.Visible = false;
                            toolStripMenuItemRename.Visible = false;
                        }
                        contextMenuStrip1.Show(treeList1, e.X, e.Y);
                    }
                }
            }
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag!=null&&!string.IsNullOrEmpty(treeList1.FocusedNode.Tag.ToString()))
            {
                CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow= _qiXieTempletMaster.FindByTEMPLET_GUID(treeList1.FocusedNode.Tag.ToString());
                if (prow != null)
                {
                    object result = Dialog.SingleInputSelect("手术清点模板名称", prow.TEMPLET_NAME);
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()) && result.ToString().Trim() != prow.TEMPLET_NAME)
                    {
                        DataRow[] prows = _qiXieTempletMaster.Select("OPER_BAG_FLAG=" + prow.OPER_BAG_FLAG.ToString() + " AND CLASS_NAME='" + prow.CLASS_NAME + "' AND TEMPLET_NAME='" + result.ToString().Trim() + "'");
                        if (prows.Length > 0)
                        {
                            Dialog.MessageBox("所在模板分类中已存在该名字");
                        }
                        else
                        {
                            prow.TEMPLET_NAME = result.ToString().Trim();
                            if (_careDocsDA.UpdateQiXieTempletMaster(_qiXieTempletMaster) > 0)
                            {
                                treeList1.FocusedNode.SetValue(0, prow.TEMPLET_NAME);
                            }
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && !treeList1.FocusedNode.HasChildren && treeList1.FocusedNode.Tag != null)
            {
                for (int i = 0; i < _qiXieTempletDetail.Count; i++)
                {
                    _qiXieTempletDetail[i].Delete();
                }
                if (_careDocsDA.UpdateQiXieTempletDetail(_qiXieTempletDetail) > 0 || _qiXieTempletDetail.Count == 0)
                {
                    CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow = _qiXieTempletMaster.FindByTEMPLET_GUID(treeList1.FocusedNode.Tag.ToString());
                    if (prow != null)
                    {
                        prow.Delete();
                        if (_careDocsDA.UpdateQiXieTempletMaster(_qiXieTempletMaster) > 0)
                        {
                            treeList1.FocusedNode.ParentNode.Nodes.Remove(treeList1.FocusedNode);
                            //treeList1.Nodes.Clear();
                            //InitTreeList();
                        }

                    }
                }
            }
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                if (treeList1.FocusedNode.ParentNode == null)
                {
                    object result = Dialog.SingleInputSelect("手术清点模板分类", deptNames.ToArray());
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
                    {
                        bool isFind = false;
                        foreach (TreeListNode node in treeList1.FocusedNode.Nodes)
                        {
                            if (node.GetDisplayText(0).Equals(result.ToString().Trim()))
                            {
                                Dialog.MessageBox("分类已存在");
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                        }
                    }
                }
                else
                {
                    object result = Dialog.SingleInputSelect("手术清点模板名称", "");
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()))
                    {
                        bool isFind = false;
                        foreach (TreeListNode node in treeList1.FocusedNode.Nodes)
                        {
                            if (node.GetDisplayText(0).Equals(result.ToString().Trim()))
                            {
                                Dialog.MessageBox("名称已存在");
                                isFind = true;
                                break;
                            }
                        }
                        if (!isFind)
                        {
                            TreeListNode newnode= treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                            CareDocs.WIS_INSTRUMENT_TEMPLET_MASTERRow prow = _qiXieTempletMaster.NewWIS_INSTRUMENT_TEMPLET_MASTERRow();
                            prow.TEMPLET_GUID = Guid.NewGuid().ToString();
                            newnode.Tag = prow.TEMPLET_GUID;
                            prow.OPER_BAG_FLAG = decimal.Parse(treeList1.FocusedNode.RootNode.Tag.ToString());
                            prow.CLASS_NAME = treeList1.FocusedNode.GetDisplayText(0);
                            prow.TEMPLET_NAME = result.ToString().Trim();
                            _qiXieTempletMaster.AddWIS_INSTRUMENT_TEMPLET_MASTERRow(prow);
                            _careDocsDA.UpdateQiXieTempletMaster(_qiXieTempletMaster);
                            treeList1.FocusedNode = newnode;
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string templetGuid=treeList1.FocusedNode.Tag.ToString();
            CareDocs.WIS_INSTRUMENT_TEMPLET_DETAILRow prow = null;
            for (int i = 0; i < _qiXieTempletDetail.Count;i++ )
            {
                _qiXieTempletDetail[i].Delete();
            }
            int n=0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && !string.IsNullOrEmpty(row.Cells[0].Value.ToString().Trim()))
                {
                    prow = _qiXieTempletDetail.NewWIS_INSTRUMENT_TEMPLET_DETAILRow();
                    prow.TEMPLET_GUID = templetGuid;
                    prow.SERIAL_NO = (decimal)n;
                    prow.ITEM_NAME = row.Cells[0].Value.ToString().Trim();
                    if (row.Cells[1].Value != null && !string.IsNullOrEmpty(row.Cells[1].Value.ToString().Trim()))
                    {
                        prow.ITEM_VALUE = row.Cells[1].Value.ToString().Trim();
                    }
                    _qiXieTempletDetail.AddWIS_INSTRUMENT_TEMPLET_DETAILRow(prow);
                    n++;
                }
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells[2].Value != null && !string.IsNullOrEmpty(row.Cells[2].Value.ToString().Trim()))
            //    {
            //        prow = _qiXieTempletDetail.NewWIS_INSTRUMENT_TEMPLET_DETAILRow();
            //        prow.TEMPLET_GUID = templetGuid;
            //        prow.SERIAL_NO = (decimal)n;
            //        prow.ITEM_NAME = row.Cells[2].Value.ToString().Trim();
            //        if (row.Cells[3].Value != null && !string.IsNullOrEmpty(row.Cells[3].Value.ToString().Trim()))
            //        {
            //            prow.ITEM_VALUE = row.Cells[3].Value.ToString().Trim();
            //        }
            //        _qiXieTempletDetail.AddWIS_INSTRUMENT_TEMPLET_DETAILRow(prow);
            //        n++;
            //    }
            //}
            if (_careDocsDA.UpdateQiXieTempletDetail(_qiXieTempletDetail) > 0)
            {
                btnSave.Enabled = false;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)// || e.ColumnIndex == 2)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (e.FormattedValue != null && dataGridView1[0, i].Value != null && dataGridView1[0, i].Value.ToString().Trim().Equals(e.FormattedValue.ToString().Trim()))
                    {
                        if (e.RowIndex == i && e.ColumnIndex == 0) continue;
                        Dialog.MessageBox("品名已存在");
                        e.Cancel = true;
                        break;
                    }
                    //if (e.FormattedValue != null && dataGridView1[2, i].Value != null && dataGridView1[2, i].Value.ToString().Trim().Equals(e.FormattedValue.ToString().Trim()))
                    //{
                    //    if (e.RowIndex == i && e.ColumnIndex == 2) continue;
                    //    Dialog.MessageBox("品名已存在");
                    //    e.Cancel = true;
                    //    break;
                    //}
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null)
            {
                DialogResultData = treeList1.FocusedNode.Tag.ToString();
                IsAddTempletData = checkEdit1.Checked;
                if (ParentForm != null && ParentForm.Modal)
                {
                    ParentForm.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
