//2013-12-11 周青 监测项目个性化设置
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Utilities;
using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.DataAccess;
using System.Collections;
using System.Reflection;

namespace Wis.Anes.Framework
{
    [ToolboxItem(false)]
    public partial class MedSheetShowEditor : UserControl
    {
        List<MedSheetDetail> _list = new List<MedSheetDetail>();
        List<MemberDetail> _memberDetails = new List<MemberDetail>();
        public MedSheetShowEditor()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            InitCombobox();
        }

        public MedSheetShowEditor(List<MedSheetDetail> list)
            : this()
        {
            _list = list;
        }

        private void MedSheetShowEditor_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            dataGridView1.DataSource = _list;
            if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
            {
                if (!AccessControl.CheckModifyRightForOperator("麻醉记录单"))
                {
                    btnOK.Enabled = false;
                    dataGridView1.ReadOnly = true;
                }
            }
            else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {

            }

        }

        private void InitCombobox()
        {

            List<LookUpEditItem> data1 = new List<LookUpEditItem>();
            data1.Add(new LookUpEditItem("是", true));
            data1.Add(new LookUpEditItem("否", false));
            (dataGridView1.Columns[1] as DataGridViewComboBoxColumn).DataSource = data1;
            (dataGridView1.Columns[1] as DataGridViewComboBoxColumn).DisplayMember = "DisplayText";
            (dataGridView1.Columns[1] as DataGridViewComboBoxColumn).ValueMember = "ItemValue";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bl = true;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (!string.IsNullOrEmpty(cell.ErrorText))
            //        {
            //            bl = false;
            //            break;
            //        }
            //    }
            //}
            if (label1.Text != "") bl = false;
            if (bl && ParentForm != null && ParentForm.Modal)
            {
                if (dataGridView1.DataSource != null)
                {
                    _list = (List<MedSheetDetail>)dataGridView1.DataSource;
                }
                ParentForm.DialogResult = DialogResult.OK;
                //Globals.DialogResult = DialogResult.OK;
            }
        }

        public bool IsTongYong
        {
            get
            {
                return checkEdit1.Checked;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.Modal)
            {
                ParentForm.DialogResult = DialogResult.Cancel;
                //Globals.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Value != null)
            {
                Rectangle rect = e.CellBounds;
                if (e.Value.GetType() == typeof(Color))
                {
                    e.Handled = true;
                    e.PaintBackground(e.ClipBounds, true);
                    rect.Inflate(-10, -5);
                    e.Graphics.FillRectangle(new SolidBrush((Color)e.Value), rect);
                }
            }
            else if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                GridViewHelper.DataGridViewCellPainting(e);
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Color")
                {
                    e.Cancel = true;
                    ColorDialog colorDialog = new ColorDialog();
                    if (dataGridView1.CurrentCell.Value != null)
                    {
                        colorDialog.Color = (Color)dataGridView1.CurrentCell.Value;
                    }
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.CurrentCell.Value = colorDialog.Color;
                    }
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (dataGridView1.Columns[grid.CurrentCell.ColumnIndex].DataPropertyName == "DotNumber")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputInteger);
            }
        }

        private void InputInteger(object sender, KeyPressEventArgs e)
        { //限制数量只能输入整数
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26)
            {
                e.Handled = true;
            }
            else
            {
                //如果是回车键，则按tab序进行跳转
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "DotNumber")
            {
                int n = 0;
                bool bl = int.TryParse(e.FormattedValue.ToString(), out n);
                if (e.FormattedValue == null || e.FormattedValue == DBNull.Value || e.FormattedValue.ToString() == string.Empty)
                {
                    label1.Text = "小数位数不能为空";
                    e.Cancel = true;
                    return;
                }
                else if (e.FormattedValue != null && e.FormattedValue != DBNull.Value && e.FormattedValue.ToString() != string.Empty && !bl)
                {
                    label1.Text = "小数位数过长";
                    //dataGridView1.CurrentCell.ErrorText = "小数位数过长";
                    e.Cancel = true;
                    return;
                }
                else if (e.FormattedValue != null && e.FormattedValue != DBNull.Value && e.FormattedValue.ToString() != string.Empty && n >= 4)
                {
                    label1.Text = "小数位数过长";
                    //dataGridView1.CurrentCell.ErrorText = "小数位数过长";
                    e.Cancel = true;
                    return;
                }
                //dataGridView1.CurrentCell.ErrorText = string.Empty;
                label1.Text = "";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.ReadOnly || e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            Rectangle rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "HideStartTime" || dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "HideEndTime")
            {
                DateTime dt = (dataGridView1[e.ColumnIndex, e.RowIndex].Value == null) || (((DateTime)dataGridView1[e.ColumnIndex, e.RowIndex].Value) == DateTime.MinValue) ? DateTime.Now.AddSeconds(-(DateTime.Now.Second)) : (DateTime)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
                Dialog.ShowDevDateTimeEditor(dt, dataGridView1, rect, new EventHandler(delegate(object s1, EventArgs e1)
                {
                    if (s1 != null && s1.ToString() != string.Empty)
                    {
                        dataGridView1.CurrentCell.Value = ((DateTime)s1);//.ToString("yyyy-MM-dd HH:mm");
                    }
                    else
                    {
                        dataGridView1.CurrentCell.Value = null;
                    }
                }), "t");
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                List<MedSheetDetail> list = new List<MedSheetDetail>();
                BusinessEntity.Configuations.PatientMonitorConfigDataTable configTable = new ConfigurationDA().GetPatientMonitorConfigDataTable("999", 0, 0);
                if (configTable.Count > 0 && !configTable[0].IsCONTENTNull())
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(configTable[0].CONTENT);
                    stream.Position = 0;
                    DataSet ds = new DataSet();
                    ds.ReadXml(stream);
                    decimal eventNo = 0;
                    if (ds.Tables.Count > 0)
                    {
                        string tableName = "UserVitalShowSet" + ((eventNo < 0) ? 0 : eventNo).ToString();
                        DataTable dataTable = ds.Tables[tableName];
                        ListFromTable(list, typeof(MedSheetDetail), dataTable);
                    }
                    ds.Dispose();
                    stream.Close();
                    stream.Dispose();
                }
                if (list != null && list.Count > 0)
                {
                    _list = list;
                    dataGridView1.DataSource = _list;
                }
            }
        }

        private void ListFromTable(IList list, Type type, DataTable dataTable)
        {
            if (dataTable != null)
            {
                List<MemberDetail> memberDetails = AssemblyHelper.GetPropertyList(type);
                foreach (DataRow row in dataTable.Rows)
                {
                    object obj = Activator.CreateInstance(type);
                    foreach (MemberDetail memberDetail in memberDetails)
                    {
                        PropertyInfo propertyInfo = memberDetail.PropertyInfo;
                        if (dataTable.Columns.Contains(memberDetail.Name) && row[memberDetail.Name] != System.DBNull.Value)
                        {
                            try
                            {
                                AssemblyHelper.SetPropertyValue(propertyInfo, obj, row[memberDetail.Name].ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    list.Add(obj);
                }
            }
        }
    }
}
