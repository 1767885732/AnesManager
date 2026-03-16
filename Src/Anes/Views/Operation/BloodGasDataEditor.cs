/*----------------------------------------------------------------
      // Copyright (C) 2010 北京拓扑工厂科技发展有限公司
      // 文件名：BloodGasDataEditor.cs
      // 文件功能描述：血气分析手工录入界面控件
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.BusinessEntity;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework;
using Wis.Anes.Constants;

namespace Wis.Anes.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class BloodGasDataEditor : BaseView
    {
        private List<BloodGasMaster> newMasters = new List<BloodGasMaster>();
        private List<BloodGasMaster> oldMasters = new List<BloodGasMaster>();

        private string patientId;
        private decimal visitId;
        private decimal operId;
        private string oldValue;
        private int masterCount = 0;
        private bool valueChanged = false;
        DataTable sourceTable;
        CareDocs.BloodGasMasterDataTable gasMaster;
        CareDocs.BloodGasDetailDataTable detailTable;

        public BloodGasDataEditor()
        {
            InitializeComponent();
            Caption = ViewNames.BloodGasData;
        }

        public BloodGasDataEditor(string patientID, decimal visitID, decimal operID)
            : this()
        {
            patientId = patientID;
            visitId = visitID;
            operId = operID;
        }

        private void BindGrid()
        {
            if (gridView1.Columns.Count > 3)
            {
                for (int i = 3; i < gridView1.Columns.Count; )
                {
                    gridView1.Columns.RemoveAt(i);
                }
            }
            sourceTable = DictProxy.GetBlgGasDictPartial("1");
            gasMaster = CareDocsProxy.GetBloodGasMasterTable(patientId, visitId, operId);
            masterCount = gasMaster.Rows.Count;
            foreach (DataRow row in gasMaster.Rows)
            {
                detailTable = CareDocsProxy.GetBloodGasDetailTable(row["DETAIL_ID"].ToString());
                GenerateColumn(((DateTime)row["RECORD_DATE"]).ToString("yyyy-MM-dd HH:mm"), row["DETAIL_ID"].ToString(), 130);
                sourceTable.Columns.Add(row["DETAIL_ID"].ToString());
                foreach (DataRow rw in sourceTable.Rows)
                {
                    foreach (DataRow dr in detailTable.Rows)
                    {
                        if (rw["BLG_CODE"].Equals(dr["BLG_CODE"]))
                        {
                            rw[row["DETAIL_ID"].ToString()] = dr["BLG_VALUE"].ToString();
                            break;
                        }
                    }
                }
            }
            gridControl1.DataSource = sourceTable;
            //if (gridView1.Columns.Count > 3)
            //{
            //    for (int i = 3; i < gridView1.Columns.Count; i++)
            //    {
            //        gridView1.Columns[i].Width = 130;
            //    }
            //}
        }

        private void GenerateColumn(string caption, string fieldName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();
            if (caption == null && fieldName == null)
            {
                DateTime dt = DateTime.Now;
                object result = Dialog.SingleInputSelect("请输入时间点", "血气分析录入时间", dt, "yyyy-MM-dd HH:mm");
                if (result != null)
                {
                    dt = (DateTime)result;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn colum in gridView1.Columns)
                    {
                        if (dt.ToString("yyyy-MM-dd HH:mm").Equals(colum.Caption))
                        {
                            Dialog.MessageBox("时间点重复，请选择其他时间点！");
                            return;
                        }
                    }
                    caption = dt.ToString("yyyy-MM-dd HH:mm");
                    fieldName = dt.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                    DataColumn dcol = new DataColumn(fieldName, Type.GetType("System.String"));

                    sourceTable.Columns.Add(dcol);
                }
                else
                {
                    return;
                }
            }
            column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            column = gridView1.Columns.AddVisible(fieldName, caption);
            column.OptionsColumn.AllowSize = true;
            column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.Width = width;

        }

        private void BloodGasDataEditor_Load(object sender, EventArgs e)
        {
            if (!Framework.AccessControl.CheckModifyRight(ViewNames.BloodGasData))
            {
                gridView1.OptionsBehavior.ReadOnly = true;
            }
            //this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            lblMsg.Text = "";
            BindGrid();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            valueChanged = true;
            btnSave.Enabled = true;
            GenerateColumn(null, null, 130);
            //if (sourceTable.Columns.Count > 4)
            //{
            //    for (int i = 0; i < sourceTable.Rows.Count; i++)
            //    {
            //        if (sourceTable.Rows[i][sourceTable.Columns.Count - 2] != DBNull.Value)
            //        {
            //            sourceTable.Rows[i][sourceTable.Columns.Count - 1] = sourceTable.Rows[i][sourceTable.Columns.Count - 2].ToString();
            //        }
            //    }
            //}
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(gridView1.FocusedColumn.Caption);
            object result = Dialog.SingleInputSelect("请修改时间点", "血气分析录入时间", dt, "yyyy-MM-dd HH:mm");
            if (result != null)
            {
                dt = (DateTime)result;
                string fieldname = dt.ToString("yyyy-MM-dd HH:mm") + "|" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
                sourceTable.Columns[gridView1.FocusedColumn.ColumnHandle].ColumnName = fieldname;
                gridView1.FocusedColumn.Caption = dt.ToString("yyyy-MM-dd HH:mm");
                gridView1.FocusedColumn.FieldName = fieldname;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (valueChanged && sourceTable.Columns.Count > 3)
            {
                int n = 0;
                DateTime dt = DateTime.Now;
                if (masterCount < (sourceTable.Columns.Count - 3))
                {

                    for (int i = 3 + masterCount; i < sourceTable.Columns.Count; i++)
                    {
                        DataRow row = gasMaster.NewRow();
                        row["PAT_ID"] = patientId;
                        row["VISIT_ID"] = visitId;
                        row["OPER_ID"] = operId;
                        row["RECORDING_DATE"] = DateTime.Parse(gridView1.Columns[i].Caption);
                        row["DETAIL_ID"] = gridView1.Columns[i].FieldName;
                        row["OPERATOR"] = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUserContext.HisUserID) ? ExtendApplicationContext.Current.LoginUserContext.LoginName : ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                        row["OP_DATE"] = dt;
                        gasMaster.Rows.Add(row);
                    }
                    n += CareDocsProxy.UpdateBloodGasMaster(gasMaster); //adapter.Update(gasMaster);
                }
                if (sourceTable.Columns.Count > 3)
                {
                    for (int j = 3; j < sourceTable.Columns.Count; j++)
                    {
                        detailTable = CareDocsProxy.GetBloodGasDetailTable(sourceTable.Columns[j].ColumnName);
                        foreach (DataRow dr in detailTable.Rows)
                        {
                            dr.Delete();
                        }
                        DataRow drow;
                        foreach (DataRow row in sourceTable.Rows)
                        {
                            drow = detailTable.NewRow();
                            drow["DETAIL_ID"] = sourceTable.Columns[j].ColumnName;
                            drow["BLG_CODE"] = row["BLG_CODE"].ToString();
                            drow["BLG_VALUE"] = row[sourceTable.Columns[j].ColumnName].ToString();
                            drow["OPERATOR"] = string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUserContext.HisUserID) ? ExtendApplicationContext.Current.LoginUserContext.LoginName : ExtendApplicationContext.Current.LoginUserContext.HisUserID;
                            drow["OP_DATE"] = dt;
                            detailTable.Rows.Add(drow.ItemArray);
                        }
                        CareDocsProxy.UpdateBloodGasDetail(detailTable);
                    }
                }
                BindGrid();
                if (n > 0)
                {
                    lblMsg.Text = "保存成功";
                }
            }
            valueChanged = false;
            btnSave.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //double d = 0.0;
            //valueChanged = true;
            //btnSave.Enabled = true;
            //if (e.Value != null && e.Value != DBNull.Value && !e.Value.Equals(string.Empty) && !double.TryParse(e.Value.ToString(), out d))
            //{
            //    sourceTable.Rows[e.RowHandle][e.Column.AbsoluteIndex]= oldValue;
            //    //btnSave.Enabled = false;
            //}
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("添加一组数据");
                item.Click += new EventHandler(toolStripMenuItem1_Click);
                menu.Items.Add(item);

                if (gridView1.FocusedColumn.FieldName != "BLG_CODE" & gridView1.FocusedColumn.FieldName != "BLG_NAME" & gridView1.FocusedColumn.FieldName != "BLG_REFER_VALUE")
                {
                    item = new ToolStripMenuItem("删除此时间点的数据");
                    item.Click += new EventHandler(item_Click);
                    menu.Items.Add(item);
                }


                if (gridView1.FocusedColumn != null && gridView1.FocusedColumn.ColumnHandle - 2 > masterCount)
                {
                    item = new ToolStripMenuItem("修改时间点");
                    item.Click += new EventHandler(toolStripMenuItem2_Click);
                    menu.Items.Add(item);


                }
                menu.Show(Control.MousePosition);
            }
            lblMsg.Text = "";
        }


        void item_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedColumn == null)
            {
                return;
            }
            if (gridView1.FocusedColumn.FieldName == "BLG_CODE" || gridView1.FocusedColumn.FieldName == "BLG_NAME" || gridView1.FocusedColumn.FieldName == "BLG_REFER_VALUE")
            {
                return;
            }
            if (XtraMessageBox.Show("是否删除所选时间点的数据?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            string filedName = this.gridView1.FocusedColumn.FieldName;
            gridView1.Columns.Remove(this.gridView1.FocusedColumn);
            sourceTable.Columns.Remove(filedName);
            CareDocsProxy.DeleteBloodGasData(filedName);
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedValue == null)
                oldValue = string.Empty;
            else
                oldValue = gridView1.FocusedValue.ToString().Trim();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            //if (gridView1.FocusedColumn == null)
            //{
            //    e.Allow = false;
            //    return;
            //}

            //if (gridView1.FocusedColumn.FieldName == "BLG_CODE" || gridView1.FocusedColumn.FieldName == "BLG_NAME" || gridView1.FocusedColumn.FieldName == "BLG_REFER_VALUE")
            //{
            //    e.Allow = false;
            //    return;
            //}
            //e.Menu.Items.Clear();
            //e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("删除所选时间点的整列值",new EventHandler(RemoveGridColumns)));

        }

        private void RemoveGridColumns(object sender, EventArgs e)
        {
            // if (gridView1.FocusedColumn == null)
            // {
            //      return;
            // }
            // if (gridView1.FocusedColumn.FieldName == "BLG_CODE" || gridView1.FocusedColumn.FieldName == "BLG_NAME" || gridView1.FocusedColumn.FieldName == "BLG_REFER_VALUE")
            // {
            //      return;
            // }
            // if (XtraMessageBox.Show("是否删除所选时间点的整列值?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //     return;
            //// gridView1.Columns.Remove(this.gridView1.FocusedColumn);
            // sourceTable.Columns.Remove(this.gridView1.FocusedColumn.FieldName);
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn == null)
            {
                return;
            }
            if (gridView1.FocusedColumn.FieldName == "BLG_CODE" || gridView1.FocusedColumn.FieldName == "BLG_NAME" || gridView1.FocusedColumn.FieldName == "BLG_REFER_VALUE")
            {
                return;
            }
            else
            {
                if (e.Value != null)
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        decimal cellValue;
                        if (!decimal.TryParse(e.Value.ToString().Trim(), out cellValue))
                        {
                            e.ErrorText = "请输入数值类型的数据!";
                            e.Valid = false;
                        }
                    }
                }
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = true;
            valueChanged = true;
        }


    }
}
