using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using Wis.Anes.BusinessEntity;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.DataAccess;
using Wis.Anes.Framework.Views.Equipment;
using DevExpress.XtraPrinting;

namespace Wis.Anes.Views
{
    [ToolboxItem(false)]
    public partial class UserControl_EquipmentEdit : BaseView
    {
        #region 界面初始化
        private Dict.WIS_EQIP_MANAGEMENTDataTable _equipmentDit = null;
        private Dict.WIS_EQIP_REPAIRDataTable _equipmentRepair = null;
        private Dict.WIS_EQIP_STATUSDataTable _equipmentStatus = null;
        private Dict.EQUIPMENTREPAIRSTATUSBYDAYDataTable _repairStatusByDay = null;
        DictDA _dictDA = new DictDA();
        private List<DataRow> _changedRowList = new List<DataRow>();
        bool _currentIsAdding = false;
        public int _deptType;
        public UserControl_EquipmentEdit(int deptType)
        {
            InitializeComponent();
            _deptType = deptType;
            dateTimePickerQuery.DateTime = DateTime.Today;
            dateTimePickerQueryEnd.DateTime = DateTime.Today;
            EquipmentManagementDict(deptType);
            EquipmentRepariStatusByDay(deptType);
            EquipmentSelect();
            this.btnAdd.Enabled = true;

        }
        private void UserControl_EquipmentEdit_Load(object sender, EventArgs e)
        {
          
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

    
       
        #region 数据操作
        /// <summary>
        /// 仪器维护界面
        /// </summary>
        public void EquipmentManagementDict(int deptType) 
        {
            _equipmentDit = _dictDA.GetEquipmentManagement(deptType);
            int index = 1;
            foreach (DataRow row in _equipmentDit.Rows)
            {
                row["INSTRUMENT_NO"] = index;
                index++;
            }

            gridControlDict.DataSource = _equipmentDit;

        }
        public void EquipmentRepariStatusByDay(int deptType)
        {
            _repairStatusByDay = _dictDA.GetEquipmentByDay(DateTime.Today, deptType);
            int index = 1;
            foreach (Dict.EQUIPMENTREPAIRSTATUSBYDAYRow row in _repairStatusByDay.Rows) {
                row.INSTRUMENT_NO = index;
                if (!string.IsNullOrEmpty(row.STATUS))
                {
                    row.ISCHECKED = false;
                }
                else {
                    row.ISCHECKED = true;
                }
                index++;
            }
            _equipmentStatus = _dictDA.GetEquipmentStatus();
            _equipmentRepair = _dictDA.GetEquipmentRepair();
            gridControlEquipmentInquiry.DataSource = _repairStatusByDay;
           
        }
        public void EquipmentSelect()
        { 
        
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
            this.btnDel.Enabled = true;
            _currentIsAdding = true;
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
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentEdit)
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
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentInquiry)
            {
                int statusCount = 0;
               
                foreach (DataRow row in ((DataTable)gridControlEquipmentInquiry.DataSource).Rows)
                {
                     var statusRow = _equipmentStatus.NewWIS_EQIP_STATUSRow();
                     foreach (Dict.WIS_EQIP_STATUSRow stRow in _equipmentStatus.Rows)
                     {
                         if (stRow.INSTRUMENT_CODE.Equals(row["INSTRUMENT_CODE"].ToString()))
                         {
                             if (stRow.STATUS_COUNT > statusCount)
                                 statusCount = Convert.ToInt32(stRow.STATUS_COUNT);
                         }
                     }
                    
                            if (row["ISCHECKED"].ToString() == "True")//勾选则提交，取消勾选则撤销
                            {
                                statusRow.STATUS = "正常";
                            }
                            else
                            {
                                statusCount++;
                                statusRow.INSTRUMENT_CODE = row["INSTRUMENT_CODE"].ToString();
                                statusRow.STATUS_COUNT = statusCount;
                                statusRow.STATUS_TIME = dateTimePickerQuery.DateTime;
                                statusRow.STATUS = "不正常";
                                _equipmentStatus.AddWIS_EQIP_STATUSRow(statusRow);
                            }
                           
                }
                if (_dictDA.UpdateEquipmentStatus(_equipmentStatus) > 0)
                {
                    MessageBox.Show("保存成功。", "",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                   
                }
                _equipmentRepair.AcceptChanges();
            }
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

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textSupplierName_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void SetEditControlState(bool isEnabled)
        {
          
        }
     /// <summary>
        /// 编辑,删除,新增行为操作
        /// </summary>
        /// <param name="editMode"></param>
        private void SetEditBehaviour(EditMode editMode)
        {
            
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentEdit)
            {
                if (editMode == EditMode.Add)
                {
                    AddGridViewEquipmentRow();
                }
                else if (editMode == EditMode.Cancel)
                {
                    _equipmentDit.RejectChanges();
                }
                else if (editMode == EditMode.Save)
                {
                    _dictDA.UpdateEquipmentManagement(_equipmentDit);
                    _equipmentDit.AcceptChanges();
                }
                else if (editMode == EditMode.Delete)
                {
                    DeleteGridViewEquipmentRow();
                } 
                gridControlDict.Enabled = true;
                this.btnDel.Enabled = this.gridViewDict.RowCount > 0; 
            }
        }
        /// <summary>
        /// 添加仪器数据数据行
        /// </summary>
        private void AddGridViewEquipmentRow()
        {
            if (_equipmentDit == null)
                return;
            var row = _equipmentDit.NewWIS_EQIP_MANAGEMENTRow();
            row.INSTRUMENT_CODE = "";
            decimal maxItemNo = -1;
            foreach (Dict.WIS_EQIP_MANAGEMENTRow datarow in _equipmentDit)
            {
                if (!datarow.IsINSTRUMENT_NONull() && maxItemNo < datarow.INSTRUMENT_NO) maxItemNo = datarow.INSTRUMENT_NO;
            }
            maxItemNo++;
            row.INSTRUMENT_NO = maxItemNo;
            row.DEPT_TYPE = _deptType;
            _equipmentDit.AddWIS_EQIP_MANAGEMENTRow(row);
            gridViewDict.FocusedRowHandle = _equipmentDit.Count - 1;
        }
        /// <summary>
        /// 删除仪器数据行
        /// </summary>
        private void DeleteGridViewEquipmentRow()
        {
            var row = gridViewDict.GetFocusedDataRow();
            if (row != null)
            {
                if (XtraMessageBox.Show("是否删除本条记录?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    row.Delete();
                    _dictDA.UpdateEquipmentManagement(_equipmentDit);

                }
            }
        }

        private void gridViewDict_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!_currentIsAdding)
            { 
                this.btnAdd.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnRefresh.Enabled = false;
                this.btnDel.Enabled = true;
                this.gridControlDict.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentEdit;
                this.gridControlEquipmentInquiry.Enabled = this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentInquiry;
               
            }
            this.btnSave.Enabled = true;
        }
        /// <summary>
        /// 验证新添加的数据行
        /// </summary>
        /// <returns></returns>
        private bool ValidateNewRow()
        {
           
           if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentEdit)
            {
                var row = this.gridViewDict.GetFocusedDataRow();
                if (row == null)
                    return false;

                if (row["INSTRUMENT_CODE"] == null || string.IsNullOrEmpty(row["INSTRUMENT_CODE"].ToString().Trim()))
                {
                    XtraMessageBox.Show("请输入监护仪标识!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;

        }
        private void gridControlEquipmentInquiry_Click(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow EquipmentRow in (gridControlEquipmentInquiry.DataSource as DataTable).Rows)
            {
                if (Convert.ToBoolean(EquipmentRow["ISCHECKED"]) != checkEdit1.Checked)//若全选过程中该行的Ischecked有变化，则把该行加入到有变化数据行列表中，用于最终提交时过滤数据
                {
                    if (!_changedRowList.Contains(EquipmentRow))
                    {
                        _changedRowList.Add(EquipmentRow);
                    }
                }
                EquipmentRow["ISCHECKED"] = checkEdit1.Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSerachDate();
        }
        private void GetSerachDate() {
            bool repair = false;
            int index = 1;
            if (this.ckbEquipment.Checked)
            {
                repair = true;
            }
            _repairStatusByDay = _dictDA.GetEquipmentByDay(_deptType, txtinstrumentCode.Text, txtinstrumentName.Text, txtSupplierName.Text,
                txtModelNumber.Text, txtSerialNumber.Text, cboState.Text, dateTimePickerQuery.DateTime, dateTimePickerQueryEnd.DateTime, repair);
            foreach (Dict.EQUIPMENTREPAIRSTATUSBYDAYRow row in _repairStatusByDay.Rows)
            {
                row.INSTRUMENT_NO = index;
                if (!string.IsNullOrEmpty(row.STATUS))
                {
                    row.ISCHECKED = false;
                }
                else
                {
                    row.ISCHECKED = true;
                }
                index++;
            }
            gridControlEquipmentInquiry.DataSource = _repairStatusByDay;
        }
        private void gridViewEquipmentInquiry_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if ( e.Clicks == 2)
            {
                DataRow dr = gridViewEquipmentInquiry.GetFocusedDataRow();
                int RowHandleIndex = gridViewEquipmentInquiry.FocusedRowHandle;
                DateTime rowClickTime = dateTimePickerQuery.DateTime;
                if (dr != null)
                {
                    Dict.EQUIPMENTREPAIRSTATUSBYDAYRow selectRowData = dr as Dict.EQUIPMENTREPAIRSTATUSBYDAYRow;
                    if (!string.IsNullOrEmpty(selectRowData.SITUATION)) rowClickTime = selectRowData.MAINTENANCE_TIME;
                    EquipmentRepair frm = new EquipmentRepair(selectRowData, rowClickTime);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        GetSerachDate();
                        gridViewEquipmentInquiry.FocusedRowHandle = RowHandleIndex;
                    }
                }
            }
        }

        private void gridViewEquipmentInquiry_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void dateTimePickerQuery_EditValueChanged(object sender, EventArgs e)
        {
            //_repairStatusByDay = _dictDA.GetEquipmentByDay(dateTimePickerQuery.DateTime);
            //foreach (Dict.EQUIPMENTREPAIRSTATUSBYDAYRow row in _repairStatusByDay.Rows) {
            //    if (!string.IsNullOrEmpty(row.STATUS))
            //    {
            //        row.ISCHECKED = false;
            //    }
            //    else {
            //        row.ISCHECKED = true;
            //    }
            //}
            //gridControlEquipmentInquiry.DataSource = _repairStatusByDay;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            //System.Drawing.Printing.PageSettings set_print_page = new System.Drawing.Printing.PageSettings();
            //DevExpress.XtraPrinting.DynamicPrintHelper ph = new DevExpress.XtraPrinting.DynamicPrintHelper();
            //if (ph.IsPrintingAvailable)
            //{
            //    ph.PageSettings = set_print_page;
            //    ph.PageSettings.Landscape = true;
            //    ph.ShowPreview(this.gridControlEquipmentInquiry, true);
            //}

            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
         

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = this.gridControlEquipmentInquiry;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            var margins = new System.Drawing.Printing.Margins(10, 10, 100, 50);
            link.Margins = margins;
       
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateDocument();
            link.ShowPreview();

        }
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            //string title = string.Format("{0}目标性监测日志", Utility.GetHospitalName());
            //PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.None, title, Color.Black,
            //   new RectangleF(0, 0, 100, 30), BorderSide.None);

            //brick.LineAlignment = BrickAlignment.Center;
            //brick.Alignment = BrickAlignment.Center;
            //brick.AutoWidth = true;

            //brick.Font = new System.Drawing.Font("宋体", 11f, FontStyle.Bold);
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentEdit)
            {
                btnPrint.Visible = false;
                btnExport.Visible = false;
                btnRefresh.Visible = false;
                btnAdd.Visible = true;
                btnDel.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;
            }
            else if (this.xtraTabControl1.SelectedTabPage == this.xtraTabPageEquipmentInquiry)
            {
                btnPrint.Visible = true; 
                btnExport.Visible = true;
                btnRefresh.Visible = true;
                btnAdd.Visible = false;
                btnDel.Visible = false;
                btnSave.Visible = true;
                btnCancel.Visible = false;

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //System.Drawing.Printing.PageSettings set_print_page = new System.Drawing.Printing.PageSettings();
            //DevExpress.XtraPrinting.DynamicPrintHelper ph = new DevExpress.XtraPrinting.DynamicPrintHelper();
            //if (ph.IsPrintingAvailable)
            //{
            //    ph.PageSettings = set_print_page;
            //    ph.PageSettings.Landscape = true;
            //    ph.ShowPreview(this.gridControlEquipmentInquiry, true);
            //}

            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = this.gridControlEquipmentInquiry;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;

            var margins = new System.Drawing.Printing.Margins(10, 10, 100, 50);
            link.Margins = margins;

            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateDocument();
            link.ShowPreview();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EquipmentRepariStatusByDay(_deptType);
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
