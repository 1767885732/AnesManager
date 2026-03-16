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
using System.IO;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class DocumentTemplet : XtraUserControl
    {
        public string DialogResultData;
        public DataTable DialogResultDataTable;
        private bool _isApply = false;
        private decimal _eventNo = 0;
        private MRichTextBox mRichBox = null;
        //private bool _hasPublicTempletRight = false;
        private bool _hasTotalRight = false;
        private DocTempletType _templetFlag = DocTempletType.None;
        CareDocsDA _careDocsDA = new CareDocsDA();
        DictDA _dictDA = new DictDA();
        Dict.DocumentTempletDataTable _documentTempletDataTable;
        private string _customTempletFlagName = string.Empty;
        /// <summary>
        /// 模板管理构造方法
        /// </summary>
        public DocumentTemplet()
        {
            InitializeComponent();
            btnExit.Visible = false;
            btnApply.Visible = false;
            btnSave.Enabled = false;
            flowLayoutPanel1.Width = 250;
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
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(DocTempletType templetFlag, decimal eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _templetFlag = templetFlag;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }
        /// <summary>
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(string customTempletFlagName, decimal eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _customTempletFlagName = customTempletFlagName;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }

        /// <summary>
        /// 模板套用
        /// </summary>
        /// <param name="templetFlag">控件模板标示属性值</param>
        /// <param name="customTempletFlagName">控件模板标示名称</param>
        /// <param name="eventNo">0麻醉，1复苏，2体外</param>
        public DocumentTemplet(DocTempletType templetFlag, string customTempletFlagName, decimal eventNo)
        {
            InitializeComponent();
            _eventNo = eventNo;
            _customTempletFlagName = customTempletFlagName;
            _templetFlag = templetFlag;
            _isApply = true;
            btnSave.Visible = false;
            flowLayoutPanel1.Width = 350;
        }

        public static DocTempletType TempletTypeFromString(string templetTypeName)
        {
            List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(DocTempletType), true);
            foreach (MemberDetail item in list)
            {
                if (item.Name.Equals(templetTypeName))
                {
                    return (DocTempletType)item.Value;
                }
            }
            return DocTempletType.None;
        }

        public static string TempletTypeToString(DocTempletType templetType)
        {
            List<MemberDetail> list = AssemblyHelper.GetEnumList(typeof(DocTempletType), true);
            List<string> itemNames = new List<string>();
            foreach (MemberDetail item in list)
            {
                if (((DocTempletType)item.Value) == templetType)
                {
                    return item.Name;
                }
            }
            return "";
        }

        /// <summary>
        /// treelist初始化
        /// </summary>
        private void InitTreeList()
        {
            treeList1.Nodes.Clear();
            if (_isApply)
            {
                if ((_templetFlag == DocTempletType.None || _templetFlag == DocTempletType.ALL) && !string.IsNullOrEmpty(_customTempletFlagName))
                {
                    treeList1.AppendNode(new object[] { _customTempletFlagName }, null);
                    DataRow[] rows = _documentTempletDataTable.Select("DOC_NAME='" + _customTempletFlagName + "' AND EVENT_NO=" + _eventNo.ToString());
                    foreach (DataRow row in rows)
                    {
                        AppendNode(row);
                    }
                }
                else
                {
                    AppendRootNode(_templetFlag);
                    DataRow[] rows = _documentTempletDataTable.Select("DOC_NAME='" + TempletTypeToString(_templetFlag) + "' AND EVENT_NO=" + _eventNo.ToString());
                    foreach (DataRow row in rows)
                    {
                        AppendNode(row);
                    }
                }
            }
            else
            {
                _eventNo = ExtendApplicationContext.Current.EventNo;
                AppendRootNode(DocTempletType.PreAnesSummary);
                AppendRootNode(DocTempletType.AnesSummary);
                AppendRootNode(DocTempletType.VisitRecord);
                if (ExtendApplicationContext.Current.CustomSettingContext.CustomTempletFlagNames.Count > 0)
                {
                    foreach (string flagName in ExtendApplicationContext.Current.CustomSettingContext.CustomTempletFlagNames)
                    {
                        bool find = false;
                        foreach (TreeListNode node in treeList1.Nodes)
                        {
                            if (node.GetDisplayText(0) == flagName)
                            {
                                find = true;
                                break;
                            }
                        }
                        if (!find)
                        {
                            treeList1.AppendNode(new object[] { flagName }, null);
                        }
                    }
                }
                AppendRootNode(DocTempletType.Other);
                DataRow[] rows = _documentTempletDataTable.Select("EVENT_NO=" + _eventNo.ToString());
                foreach (DataRow row in rows)
                {
                    AppendNode(row);
                }
            }
            treeList1.ExpandAll();
        }

        private void AppendNode(DataRow row)
        {
            TreeListNode rootnode = null;
            foreach (TreeListNode node in treeList1.Nodes)
            {
                if (node.GetDisplayText(0) == row["DOC_NAME"].ToString())
                {
                    rootnode = node;
                    break;
                }
            }
            if (rootnode != null)
            {
                TreeListNode classNode = null;
                foreach (TreeListNode node in rootnode.Nodes)
                {
                    if (node.GetDisplayText(0) == row["CLASS_NAME"].ToString())
                    {
                        classNode = node;
                        break;
                    }
                }
                if (classNode == null)
                {
                    classNode = treeList1.AppendNode(new object[] { row["CLASS_NAME"].ToString() }, rootnode);
                }
                TreeListNode newNode=treeList1.AppendNode(new object[] { row["TEMPLET_NAME"].ToString() }, classNode);
                newNode.Tag = row["TEMPLET_GUID"].ToString();
            }
        }

        private void AppendRootNode(DocTempletType templetType)
        {
            string templetTypeName = TempletTypeToString(templetType);
            if (!string.IsNullOrEmpty(templetTypeName))
            {
                treeList1.AppendNode(new object[] { templetTypeName }, null);
            }
        }

        private void CheckRight()
        {
            if (!AccessControl.CheckModifyRight("模板管理"))
            {
                flowLayoutPanel1.Visible = false;
                mRichBox.ReadOnly = true;
            }
            else
            {
                _hasTotalRight = true;
            }
        }

        private void LoadRichBoxData(string templetGuid)
        {
            mRichBox.Text = string.Empty;
            Dict.DocumentTempletRow prow = _documentTempletDataTable.FindByTEMPLET_GUID(templetGuid);
            DataRow[] prows = _documentTempletDataTable.Select("TEMPLET_GUID='" + templetGuid + "'");
            if (prow != null && !prow.IsTEMPLET_VALUENull())
            {
                if (_templetFlag == DocTempletType.ALL)
                {
                    MemoryStream stream = new MemoryStream(prow.TEMPLET_VALUE);
                    stream.Position = 0;
                    DialogResultDataTable.Rows.Clear();
                    DialogResultDataTable.ReadXml(stream);
                    mRichBox.Text = prow.TEMPLET_NAME;
                    stream.Close();
                    stream.Dispose();
                }
                else
                {
                    string ret = StringHelper.Arr2Str(prow.TEMPLET_VALUE);
                    mRichBox.Text = ret;
                }
            }
            btnSave.Enabled = false;
        }

        public bool Save()
        {
            bool b = false;
            Dict.DocumentTempletRow prow = _documentTempletDataTable.FindByTEMPLET_GUID(treeList1.FocusedNode.Tag.ToString());
            if (string.IsNullOrEmpty(mRichBox.Text.Trim()))
            {
                prow.SetTEMPLET_VALUENull();
            }
            else
            {
                prow.TEMPLET_VALUE = StringHelper.Str2Arr(mRichBox.Text.Trim());
            }
            if (_dictDA.UpdateDocumentTemplet(_documentTempletDataTable) > 0)
            {
                b = true;
                btnSave.Enabled = false;
            }
            return b;
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
                        else if (hInfo.Node.HasChildren || hInfo.Node.ParentNode == null || hInfo.Node.ParentNode.ParentNode == null)
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

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.ParentNode != null && e.Node.ParentNode.ParentNode != null && !e.Node.HasChildren)
            {
                LoadRichBoxData(e.Node.Tag.ToString());
                mRichBox.Enabled = true ;
                btnApply.Enabled = true ;
            }
            else
            {
                mRichBox.Text = string.Empty;
                mRichBox.Enabled = false; ;
                btnSave.Enabled = false;
                btnApply.Enabled = false;
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
                DialogResultData = mRichBox.Text;
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
                btnApply.Visible = _isApply;
                btnExit.Visible = _isApply;
                btnSave.Visible = !_isApply;
                DialogResultDataTable = new DataTable();
                DialogResultDataTable.Columns.Add(new DataColumn("ControlName", typeof(string)));
                DialogResultDataTable.Columns.Add(new DataColumn("ControlValue", typeof(string)));
                DialogResultDataTable.TableName = "TOTALMODEL";
                mRichBox = new MRichTextBox();
                mRichBox.Enabled = !_isApply;
                medSplitContainer1.Panel2.Controls.Add(mRichBox);
                medSplitContainer1.Panel2.Padding = new Padding(15, 15, 15, 15);
                mRichBox.Dock = DockStyle.Fill;
                mRichBox.WordWrap = true;
                mRichBox.Multiline = true;
                mRichBox.BackColor = Color.White;
                mRichBox.BorderStyle = BorderStyle.Fixed3D;
                mRichBox.TextChanged += new EventHandler(mRichBox_TextChanged);
                _documentTempletDataTable = _dictDA.GetDocumentTemplet();
                CheckRight();
                InitTreeList();
            }
        }

        void mRichBox_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                if (treeList1.FocusedNode.ParentNode == null)
                {
                    object result = Dialog.SingleInputSelect("添加模板分类","");
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
                    object result = Dialog.SingleInputSelect("添加模板名称", "");
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
                            TreeListNode newnode = treeList1.AppendNode(new object[] { result.ToString().Trim() }, treeList1.FocusedNode);
                            Dict.DocumentTempletRow prow = _documentTempletDataTable.NewDocumentTempletRow();
                            prow.TEMPLET_GUID = Guid.NewGuid().ToString();
                            newnode.Tag = prow.TEMPLET_GUID;
                            prow.DOC_NAME = treeList1.FocusedNode.RootNode.GetDisplayText(0);
                            prow.CLASS_NAME = treeList1.FocusedNode.GetDisplayText(0);
                            prow.TEMPLET_NAME = result.ToString().Trim();
                            prow.EVENT_NO =_eventNo;
                            prow.IS_PART = 1;
                            prow.IS_PRIVATE = 0;
                            prow.USER_ID = ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                            _documentTempletDataTable.AddDocumentTempletRow(prow);
                            _dictDA.UpdateDocumentTemplet(_documentTempletDataTable);
                            treeList1.FocusedNode = newnode;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemRename_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag != null && !string.IsNullOrEmpty(treeList1.FocusedNode.Tag.ToString()))
            {
                Dict.DocumentTempletRow prow = _documentTempletDataTable.FindByTEMPLET_GUID(treeList1.FocusedNode.Tag.ToString());
                if (prow != null)
                {
                    object result = Dialog.SingleInputSelect("重命名模板名称", prow.TEMPLET_NAME);
                    if (result != null && !string.IsNullOrEmpty(result.ToString().Trim()) && result.ToString().Trim() != prow.TEMPLET_NAME)
                    {
                        DataRow[] prows = _documentTempletDataTable.Select("EVENT_NO=" + _eventNo.ToString() + " AND CLASS_NAME='" + prow.CLASS_NAME + "' AND TEMPLET_NAME='" + result.ToString().Trim() + "' AND DOC_NAME='" + treeList1.FocusedNode.RootNode.GetDisplayText(0)+ "'");
                        if (prows.Length > 0)
                        {
                            Dialog.MessageBox("所在模板分类中已存在该名字");
                        }
                        else
                        {
                            prow.TEMPLET_NAME = result.ToString().Trim();
                            if (_dictDA.UpdateDocumentTemplet(_documentTempletDataTable) > 0)
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
                mRichBox.Text = string.Empty;
                Dict.DocumentTempletRow prow = _documentTempletDataTable.FindByTEMPLET_GUID(treeList1.FocusedNode.Tag.ToString());
                if (prow != null)
                {
                    prow.Delete();
                    if (_dictDA.UpdateDocumentTemplet(_documentTempletDataTable) > 0)
                    {
                        treeList1.FocusedNode.ParentNode.Nodes.Remove(treeList1.FocusedNode);
                        btnSave.Enabled = false;
                    }

                }
            }
        }
    }
}
