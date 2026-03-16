/*----------------------------------------------------------------
      //北京拓扑工厂科技发展有限公司
      // 文件名：UserControl_BillBody.cs
      // 文件功能描述：收费管理界面主信息控件
      //
      // 
      // 创建标识：XXX-2011-09-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework.Views.BillManager
{
    [ToolboxItem(false)]
    public partial class UserControl_BillBody : UserControl
    {
        public UserControl_BillBody(int billType):this(null, billType) { }
        public UserControl_BillBody(DataTable dataSource, int billType)
        {
            InitializeComponent();
            if (dataSource != null)
            {
                gridControlLeftList.DataSource = dataSource;
                RefreshPrice();
                CalculateSumCost();
            }
            gridViewLeftList.ShownEditor += new EventHandler(gridViewLeftList_ShownEditor);

            if ((billType == 1 && !AccessControl.CheckModifyRight("麻醉退费")) || billType == 0 && !AccessControl.CheckModifyRight("手术退费"))
            {
                panelAllCost.Visible = false;
                gridViewLeftList.Columns["COSTS"].Visible = false;
            }

            if (billType == 2 && !AccessControl.CheckModifyRight("模板管理"))
            {
                gridViewLeftList.OptionsBehavior.Editable = false;
                //foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridViewLeftList.Columns)
                //{
                //    column.OptionsColumn.AllowEdit = false;
                //}
            }
        }

        private void gridViewLeftList_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewLeftList.ActiveEditor != null)
            {
                gridViewLeftList.ActiveEditor.DoubleClick -= new EventHandler(ActiveEditor_DoubleClick);
                gridViewLeftList.ActiveEditor.DoubleClick += new EventHandler(ActiveEditor_DoubleClick);
                gridViewLeftList.ActiveEditor.KeyDown -= new KeyEventHandler(ActiveEditor_KeyDown);
                gridViewLeftList.ActiveEditor.KeyDown += new KeyEventHandler(ActiveEditor_KeyDown);
                gridViewLeftList.CellValueChanged += new CellValueChangedEventHandler(gridViewLeftList_CellValueChanged);
            }
        }

        private void ActiveEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                ActiveEditor_PopupList(sender);
            }
        }

        public bool ReadOnly
        {
            set
            {
                gridViewLeftList.OptionsBehavior.ReadOnly = value;
            }
        }

        public DataTable DataSource
        {
            get
            {
                if (gridControlLeftList != null && gridControlLeftList.DataSource != null && gridControlLeftList.DataSource is DataTable)
                {
                    return gridControlLeftList.DataSource as DataTable;
                }
                return null;
            }
            set
            {
                if (gridControlLeftList != null)
                {
                    gridControlLeftList.DataSource = value;
                    //RefreshPrice();
                    //CalculateSumCost();
                }
            }
        }

        public void DeleteRow(string patientID, decimal visitID, decimal operID, decimal billType)
        {
            try
            {
            if (gridViewLeftList.SelectedRowsCount > 0)
            {
                int [] selectRows = gridViewLeftList.GetSelectedRows();
                DataRow row = gridViewLeftList.GetDataRow(selectRows[0]);
                if (!row.IsNull("EXCHANGE_INDICATOR") && Convert.ToInt32(row["EXCHANGE_INDICATOR"]) == 1)
                {
                    double amount = Convert.ToDouble(row["AMOUNT"]);
                    if(amount == 0.0)
                        return;

                    if (amount > 0)
                    {
                        if ((billType == 1 && !AccessControl.CheckModifyRight("麻醉退费")) || billType == 0 && !AccessControl.CheckModifyRight("手术退费"))
                        {
                            Dialog.MessageBox("该费用已收取，您没有退费的权限");
                            return;
                        }
                    }

                    string strMessage;
                    if (amount > 0)
                        strMessage = "该费用已收取，要对此记录进行退费吗？";
                    else
                        strMessage = "该费用已被退费，要恢复对此记录收费吗？";

                    if (Dialog.MessageBox(strMessage, Dialog.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataRow rowAdd = BillHelper.AddRow(DataSource, patientID, visitID, operID, billType);
                        foreach(DataColumn col in DataSource.Columns)
                        {
                            if (col.ColumnName == "ITEM_NO")
                                continue;

                            if (col.ColumnName == "EXCHANGE_INDICATOR")
                                rowAdd[col] = 0;
                            else if (col.ColumnName == "AMOUNT")
                                rowAdd[col] = -Convert.ToDouble(row[col]);
                            else
                                rowAdd[col] = row[col];
                        }
                        
                    }
                }
                else if(Dialog.MessageBox("真的要删除所选行吗？", Dialog.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    gridViewLeftList.DeleteSelectedRows();
            }
            }
            catch(Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

      

        // 重新计算总价
        public void CalculateSumCost()
        {
            try
            {
                DataTable  datatable = gridControlLeftList.DataSource as DataTable;
                if (datatable == null)
                    return;

                double allPrice = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                        continue;

                    if (row.IsNull("PRICE") || row.IsNull("AMOUNT"))
                        continue;

                    double price = Convert.ToDouble(row["PRICE"]);
                    double count = Convert.ToDouble(row["AMOUNT"]);
                    double current = Math.Round(price * count, 4);
                    row["COSTS"] = Convert.ToDecimal(current);
                    row["CHARGES"] = Convert.ToDecimal(current);
                     
                    allPrice += current;

                }

                labelSumCost.Text = allPrice.ToString("F04");
                gridViewLeftList.RefreshData();
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

        
        // 计算当前行的价格
        protected void CalcualteRowCost(Dict.OperationBillItemsRow row)
        {
            if (row.IsPRICENull() || row.IsAMOUNTNull())
                return;

            double price = Convert.ToDouble(row.PRICE);
            double count = Convert.ToDouble(row.AMOUNT);
            double current = Math.Round(price * count, 2);
            row.COSTS = Convert.ToDecimal(current);
        }

        private void ActiveEditor_PopupList(object sender)
        {
            if (sender is DevExpress.XtraEditors.TextEdit)
            {
                if (gridViewLeftList.FocusedColumn.Equals(gridColumnITEM_NAME))   // 收费项目
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    DataRow selectRow = gridViewLeftList.GetFocusedDataRow();

                    if (selectRow != null)
                    {
                        DataTable dataTable = BillHelper.GetPriceList();
                        DataTable dataTableClass = new DictDA().GetDictTable("His收费类别");
                        DataRow[] classRows = dataTableClass.Select("ITEM_NAME = '" + selectRow["ITEM_CLASS_NAME"] + "'");
                        if(classRows.Length > 0)
                        {
                            DataRow[] useRows = dataTable.Select("ITEM_CLASS = '" + classRows[0]["ITEM_CODE"] + "'"); ;
                            DataTable dtInput = dataTable.Clone();
                            DataColumn addColumn = dtInput.Columns.Add("ITEM_NAME_ALIAS");
                            foreach (DataRow inputRow in useRows)
                            {
                                dtInput.ImportRow(inputRow);
                            }

                            foreach (DataRow inputRow in dtInput.Rows)
                            {
                                inputRow["ITEM_NAME_ALIAS"] = string.Format("{0}(￥{1})", inputRow["ITEM_NAME"], inputRow["PRICE"]);
                            }

                            Dialog.ShowDataTableSelection(dtInput, "ITEM_NAME_ALIAS", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                                , new EventHandler(delegate(object s1, EventArgs e1)
                                {
                                    if (s1 is DataRow)
                                    {
                                        edit.Text = ((DataRow)s1).IsNull("ITEM_NAME") ? "" : ((DataRow)s1)["ITEM_NAME"].ToString();
                                        //selectRow["ITEM_SPEC"] = ((DataRow)s1)["ITEM_SPEC"];
                                        //selectRow["UNITS"] = ((DataRow)s1)["UNITS"];
                                        //selectRow["PRICE"] = ((DataRow)s1)["PRICE"];
                                        selectRow["ITEM_CODE"] = ((DataRow)s1)["ITEM_CODE"];
                                        selectRow["CLASS_ON_INP_RCPT"] = ((DataRow)s1)["CLASS_ON_INP_RCPT"];

                                        //if (dataTable.Columns.Contains("CLASS_ON_IN_RCPT"))
                                        //    selectRow["CLASS_ON_IN_RCPT"] = ((DataRow)s1)["CLASS_ON_INP_RCPT"];

                                        selectRow["CLASS_ON_OUTP_RCPT"] = ((DataRow)s1)["CLASS_ON_OUTP_RCPT"];
                                        selectRow["CLASS_ON_RECKONING"] = ((DataRow)s1)["CLASS_ON_RECKONING"];
                                        selectRow["SUBJ_CODE"] = ((DataRow)s1)["SUBJ_CODE"];
                                        selectRow["CLASS_ON_MR"] = ((DataRow)s1)["CLASS_ON_MR"];
                                        gridViewLeftList.SetRowCellValue(gridViewLeftList.FocusedRowHandle, gridColumnITEM_SPEC, ((DataRow)s1)["ITEM_SPEC"]);
                                        gridViewLeftList.SetRowCellValue(gridViewLeftList.FocusedRowHandle, gridColumnPrice, ((DataRow)s1)["PRICE"]);
                                        gridViewLeftList.SetRowCellValue(gridViewLeftList.FocusedRowHandle, gridColumnFee, ((DataRow)s1)["PRICE"]);
                                        gridViewLeftList.SetRowCellValue(gridViewLeftList.FocusedRowHandle, gridColumnDOSAGE, 1);
                                        gridViewLeftList.SetRowCellValue(gridViewLeftList.FocusedRowHandle, gridColumnUNIT, ((DataRow)s1)["UNITS"]);
                                        //CalculateSumCost();
                                    }
                                }), false, false, null);
                        }
                    }
                }
                else if (gridViewLeftList.FocusedColumn.Equals(gridColumnUNIT))  // 单位
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    DataTable dataTable = new DictDA().GetDictTable("用药单位");
                    Dialog.ShowDataTableSelection(dataTable, "ITEM_NAME", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is Dict.AnesthesiaInputDictRow)
                            {
                                edit.Text = ((Dict.AnesthesiaInputDictRow)s1).ITEM_NAME;
                            }
                        }), false, false, null);
                }
                else if (gridViewLeftList.FocusedColumn.Equals(gridColumnITEM_CLASS)) // 类别
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    
                    
                    DataTable dataTable = new DictDA().GetDictTable("His收费类别");
                    Dialog.ShowDataTableSelection(dataTable, "ITEM_NAME", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is Dict.AnesthesiaInputDictRow)
                            {
                                DataRow selectRow = gridViewLeftList.GetFocusedDataRow();
                                if (selectRow != null)
                                {
                                    selectRow["ITEM_CLASS"] =  ((DataRow)s1)["ITEM_CODE"];
                                }

                                edit.Text = ((Dict.AnesthesiaInputDictRow)s1).ITEM_NAME;

                            }
                        }), false, false, null);

                       
                }
                else if (gridViewLeftList.FocusedColumn.Equals(gridColumnITEM_SPEC))  // 规格
                {
                    DevExpress.XtraEditors.TextEdit edit = sender as DevExpress.XtraEditors.TextEdit;
                    DataTable dataTable = new DictDA().GetDictTable("规格");
                    Dialog.ShowDataTableSelection(dataTable, "ITEM_NAME", edit, new Point(0, edit.Height), new Size(edit.Width, 300)
                        , new EventHandler(delegate(object s1, EventArgs e1)
                        {
                            if (s1 is Dict.AnesthesiaInputDictRow)
                            {
                                edit.Text = ((Dict.AnesthesiaInputDictRow)s1).ITEM_NAME;
                            }
                        }), false, false, null);
                }
               
            }
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            ActiveEditor_PopupList(sender);
        }

       
        protected void gridViewLeftList_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            DataRow selectRow = gridViewLeftList.GetDataRow(e.RowHandle);
            if (e.Column.Equals(gridColumnITEM_NAME)) // 更新规格等
            {
                DataTable dtPriceList = BillHelper.GetPriceList();

                if(!selectRow.IsNull("ITEM_NAME"))
                {
                    string filter = string.Format("ITEM_CLASS = '{0}' and ITEM_NAME = '{1}' and ITEM_SPEC='{2}'", selectRow["ITEM_CLASS"], selectRow["ITEM_NAME"], selectRow["ITEM_SPEC"]);
                    DataRow[] rowPrice = dtPriceList.Select(filter);
                    if (rowPrice.Length > 0)
                    {
                        DataRow row = rowPrice[0];
                        selectRow["ITEM_SPEC"] = row["ITEM_SPEC"];
                        selectRow["UNITS"] = row["UNITS"];
                        selectRow["PRICE"] = row["PRICE"];
                        selectRow["ITEM_CODE"] = row["ITEM_CODE"];
                        selectRow["CLASS_ON_INP_RCPT"] = row["CLASS_ON_INP_RCPT"];

                        //if (dtPriceList.Columns.Contains("CLASS_ON_IN_RCPT"))
                        //   selectRow["CLASS_ON_IN_RCPT"] = row["CLASS_ON_INP_RCPT"];

                        selectRow["CLASS_ON_OUTP_RCPT"] = row["CLASS_ON_OUTP_RCPT"];
                        selectRow["CLASS_ON_RECKONING"] = row["CLASS_ON_RECKONING"];
                        selectRow["SUBJ_CODE"] = row["SUBJ_CODE"];
                        selectRow["CLASS_ON_MR"] = row["CLASS_ON_MR"];
                    }
                    else
                    {
                        selectRow["ITEM_SPEC"] = "/";
                        selectRow["UNITS"] = "/";
                        selectRow["PRICE"] = "0";
                        selectRow["ITEM_CODE"] = "unknow";

                        selectRow["CLASS_ON_INP_RCPT"] = "";

                        //if (dtPriceList.Columns.Contains("CLASS_ON_IN_RCPT"))
                        //    selectRow["CLASS_ON_IN_RCPT"] = "";
                        selectRow["CLASS_ON_OUTP_RCPT"] = "";
                        selectRow["CLASS_ON_RECKONING"] = "";
                        selectRow["SUBJ_CODE"] = "";
                        selectRow["CLASS_ON_MR"] = "";
                    }
                }
            }

            if (e.Column.Equals(gridColumnDOSAGE) || e.Column.Equals(gridColumnPrice) || e.Column.Equals(gridColumnFee))
            {
                if (e.Column.Equals(gridColumnDOSAGE)) 
                {
                    float fee = Convert.ToSingle(selectRow["PRICE"].ToString()) * Convert.ToSingle(e.Value.ToString());
                    gridViewLeftList.SetRowCellValue(e.RowHandle, gridColumnFee, fee);
                }
                CalculateSumCost();
            }
        }
        
        // 从价表更新价格
        public void RefreshPrice()
        {
            try
            {
                DataTable datatable = gridControlLeftList.DataSource as DataTable;
                if (datatable == null)
                    return;

                DataTable dtPriceList = BillHelper.RefreshPriceList();
                if (dtPriceList == null)
                    return;

                // 更新每一行
                DataRow[] rows = datatable.Select("EXCHANGE_INDICATOR <> 1");
                foreach (DataRow row in rows)
                {
                    string filter = string.Format("ITEM_CLASS = '{0}' and ITEM_CODE = '{1}' and ITEM_SPEC='{2}'", row["ITEM_CLASS"], row["ITEM_CODE"], row["ITEM_SPEC"]);
                    DataRow[] rowPrice = dtPriceList.Select(filter);
                    if (rowPrice.Length > 0)
                    {
                        if (!row["ITEM_SPEC"].Equals(rowPrice[0]["ITEM_SPEC"]) || !row["UNITS"].Equals(rowPrice[0]["UNITS"]) || !row["PRICE"].Equals(rowPrice[0]["PRICE"]))
                        {
                            row["ITEM_SPEC"] = rowPrice[0]["ITEM_SPEC"];
                            row["UNITS"] = rowPrice[0]["UNITS"];
                            row["PRICE"] = rowPrice[0]["PRICE"];
                            row["PRICE_MODIFY"] = 1;
                        }
                        else
                        {
                            row["PRICE_MODIFY"] = 0;
                        }
                    }
                    else
                    {
                        row["PRICE_MODIFY"] = -1;
                    }
                }
            }
            catch (Exception err)
            {
                ExceptionHandler.Handle(err);
            }
        }

  
        private void gridViewLeftList_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            GridView view = gridControlLeftList.MainView as GridView;
            if(view == null)
                return ;

            DataRow row = view.GetDataRow(e.RowHandle);
            if (!row.IsNull("EXCHANGE_INDICATOR") && Convert.ToInt32(row["EXCHANGE_INDICATOR"]) == 1)  // 已经收费
                e.Appearance.ForeColor = Color.DarkGray;
            else if (!row.IsNull("EXCHANGE_INDICATOR") && Convert.ToInt32(row["EXCHANGE_INDICATOR"]) == 2)  // 收费到HIS时异常 
            {
                e.Appearance.BackColor2 = Color.Yellow;
                e.Appearance.BackColor = Color.Yellow;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (!row.IsNull("PRICE_MODIFY") && Convert.ToInt32(row["PRICE_MODIFY"]) == -1)  // 项目已不存在 
            {
                e.Appearance.BackColor2 = Color.Red;
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (!row.IsNull("PRICE_MODIFY") && Convert.ToInt32(row["PRICE_MODIFY"]) == 1)  // 价表价格更新过
                e.Appearance.ForeColor = Color.Blue;
            else if (!row.IsNull("AMOUNT") && Convert.ToDouble(row["AMOUNT"]) < 0)  // 负额充红
                e.Appearance.ForeColor = Color.Red;
            else
                e.Appearance.ForeColor = Color.Black;
        }

        private void gridViewLeftList_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = gridControlLeftList.MainView as GridView;
            if (view == null)
                return;

            DataRow row = view.GetFocusedDataRow();
            if (row == null)
                return;

            if (!row.IsNull("EXCHANGE_INDICATOR") && Convert.ToInt32(row["EXCHANGE_INDICATOR"]) == 1)  // 已经收费
                e.Cancel = true;
        }

        // 清除没提交HIS的所有记录
        public void DeleteAllRowButHIS()
        {
            if (DataSource == null)
                return;

            DataRow[] rows = DataSource.Select("EXCHANGE_INDICATOR <> 1");
            foreach (DataRow row in rows)
            {
                if(row.RowState != DataRowState.Deleted)
                    row.Delete();
            }
        }

        // 设置保存标置
        public void SetConfirmFlag(int flag, int orgFlag)
        {
            if (DataSource == null)
                return;

            DataRow[] rows = DataSource.Select("EXCHANGE_INDICATOR = " + orgFlag.ToString());
            foreach (DataRow row in rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;

                row["EXCHANGE_INDICATOR"] = flag;
            }
        }

        // 是否有不正常收费确认数据
        public bool HasAbnormalConfirmFlag()
        {
            if (DataSource == null)
                return false;

            DataRow[] rows = DataSource.Select("EXCHANGE_INDICATOR = 2");
            if (rows.Length > 0)
                return true;
            else
                return false;
        }

        // 是否有已提交的费用
        public bool HasConfirmFee()
        {
            if (DataSource == null)
                return false;

            DataRow[] rows = DataSource.Select("EXCHANGE_INDICATOR = 1");
            if (rows.Length > 0)
                return true;
            else
                return false;
        }

        // 数据是否有效
        public bool IsValidData()
        {
            if (DataSource == null)
                return false;

            int index = 0;
            foreach (DataRow row in DataSource.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;

                if (row.IsNull("AMOUNT") || row.IsNull("ITEM_CLASS_NAME") || row.IsNull("ITEM_NAME") || row.IsNull("ITEM_CODE")
                    || row.IsNull("ITEM_SPEC") || row.IsNull("UNITS") || row.IsNull("PRICE"))
                {
                    gridViewLeftList.FocusedRowHandle = gridViewLeftList.GetRowHandle(index);
                    return false;
                }

                if (!row.IsNull("PRICE_MODIFY") && Convert.ToInt32(row["PRICE_MODIFY"]) == -1)
                {
                    gridViewLeftList.FocusedRowHandle = gridViewLeftList.GetRowHandle(index);
                    return false;
                }

                index++;
            }

            return true;
        }

        public string FullCost
        {
            get
            {
                return labelSumCost.Text;
            }
        }
    }
}
