using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;

namespace Com.ICIS.Icu
{
    public partial class CelerityInputFrm : DevExpress.XtraEditors.XtraForm
    {
        #region 私有变量
        /// <summary>
        /// 距底部屏幕边距
        /// </summary>
        private const int BOTTOMMARGIN = 10;
        /// <summary>
        /// 字典表数据集
        /// </summary>
        private DataTable DictDT = new DataTable();
        /// <summary>
        /// 调用该窗体的TextBox组件
        /// </summary>
        private TextBoxBase TxtControl;
        /// <summary>
        /// 调用该窗体的DataGridViewCell组件
        /// </summary>
        private DataGridViewCell DataGridViewCell;
        /// <summary>
        /// 调用该窗体的TextEdit组件
        /// </summary>
        private TextEdit TextEditControl;
        /// <summary>
        /// 值字段列名称
        /// </summary>
        private string ValueColumnName;
        /// <summary>
        /// 拼音首字母字段列名称
        /// </summary>
        private string CodeColumnName;
        /// <summary>
        /// 自增ID列名称
        /// </summary>
        private string FIDColumnName;
        /// <summary>
        /// 每个字节所占长度
        /// </summary>
        private const int CHARWIDTH = 10;
        /// <summary>
        /// 存放页自增ID起始值结构体
        /// </summary>
        public struct FIDStruct
        {
            public string PageMinFID;
            public string PageMaxFID;
        }
        /// <summary>
        /// 存放页自增ID起始值结构体数组
        /// </summary>
        private ArrayList FIDStructList;
        /// <summary>
        /// 当前页索引
        /// </summary>
        private int PageIndex = 0;
        #endregion

        #region 构造函数
        /// <summary>
        /// F9输入窗体功能初始化
        /// </summary>
        /// <param name="dictDT">字典表数据集</param>
        /// <param name="valueColumnName">值字段列名称</param>
        /// <param name="codeColumnName">拼音首字母字段列名称</param>
        /// <param name="fIDCloumnName">自增ID列名称</param>
        public CelerityInputFrm(DataTable dictDT, string valueColumnName, string codeColumnName, string fIDCloumnName)
        {
            InitializeComponent();
            ValueColumnName = valueColumnName;
            CodeColumnName = codeColumnName;
            FIDColumnName = fIDCloumnName;
            DictDT = dictDT.Clone();
            DataRow[] DtRows;

            DtRows = dictDT.Select("", FIDColumnName + " ASC ");

            foreach (DataRow Row in DtRows)
            {
                DictDT.ImportRow(Row);
            }
            int ArrLength = dictDT.Rows.Count / 10 + 1;
            FIDStructList = new ArrayList();
            for (int i = 0; i < ArrLength; i++)
            {
                FIDStruct FIDStruct1 = new FIDStruct();
                FIDStructList.Add(FIDStruct1);
            }
        }
        #endregion

        #region 公开方法

        /// <summary>
        /// 将窗体显示为模式对话框，窗体位置为传入TextBox组件下方。
        /// </summary>
        /// <param name="control">传入组件</param>
        public void ShowDialog(TextBoxBase txtControl)
        {
            TxtControl = txtControl;
            Point P = new Point(0, 0);
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            Point ScreenPoint = txtControl.PointToScreen(P);
            if (txtControl.Multiline)
            {
                ScreenPoint.Y += txtControl.GetPositionFromCharIndex(txtControl.GetFirstCharIndexOfCurrentLine()).Y
                    + (int)txtControl.CreateGraphics().MeasureString("A", txtControl.Font).Height;
                if ((ScreenPoint.Y + this.Height + BOTTOMMARGIN) >= ScreenHeight)
                {
                    ScreenPoint.Y = ScreenPoint.Y - this.Height - (int)txtControl.CreateGraphics().MeasureString("A", txtControl.Font).Height - 1;
                }
            }
            else
            {
                if ((ScreenPoint.Y + txtControl.Size.Height + this.Height + BOTTOMMARGIN) >= ScreenHeight)
                {
                    ScreenPoint.Y -= this.Height;
                }
                else
                {
                    ScreenPoint.Y += txtControl.Size.Height;
                }
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Location = ScreenPoint;
            ListBind(DictDT);
            ShowDialog();
        }

        /// <summary>
        /// 将窗体显示为模式对话框，窗体位置为传入TextBox组件下方。
        /// </summary>
        /// <param name="control">传入组件</param>
        public void ShowDialog(TextEdit txtControl)
        {
            TextEditControl = txtControl;
            Point P = new Point(0, 0);
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            Point ScreenPoint = txtControl.PointToScreen(P);
            if ((ScreenPoint.Y + txtControl.Size.Height + this.Height + BOTTOMMARGIN) >= ScreenHeight)
            {
                ScreenPoint.Y -= this.Height;
            }
            else
            {
                ScreenPoint.Y += txtControl.Size.Height;
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Location = ScreenPoint;
            ListBind(DictDT);
            ShowDialog();
        }

        public void ShowDialog(DataGridViewCell gridViewCellControl, Point point)
        {
            DataGridViewCell = gridViewCellControl;
            int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            if ((point.Y + gridViewCellControl.Size.Height + this.Height + BOTTOMMARGIN) >= ScreenHeight)
            {
                point.Y -= this.Height;
            }
            else
            {
                point.Y += gridViewCellControl.Size.Height;
            }
            if ((point.X + this.Width) > ScreenWidth)
            {
                point.X = point.X - (point.X + this.Width - ScreenWidth);
            }
            this.StartPosition = FormStartPosition.Manual;
            this.Location = point;
            ListBind(DictDT);
            ShowDialog();
        }
        #endregion

        #region 私有方法
        private void ListBind(DataTable dtResult)
        {
            listValues.Items.Clear();
            lblValue.Text = string.Empty;
            if (dtResult == null)
            {
                return;
            }
            if (dtResult.Rows.Count == 0)
            {
                return;
            }
            int StringMaxLength = 0;
            int TableCount = dtResult.Rows.Count;
            FIDStruct FIDStruct1 = new FIDStruct();
            for (int i = 1; i <= 10; i++)
            {
                if (TableCount == 0)
                {
                    break;
                }
                TableCount--;
                int No = i;
                if (No == 10)
                {
                    No = 0;
                }
                if (i == 1)
                {
                    FIDStruct1.PageMinFID = dtResult.Rows[i - 1][FIDColumnName].ToString();
                }
                FIDStruct1.PageMaxFID = dtResult.Rows[i - 1][FIDColumnName].ToString();
                listValues.Items.Add(No.ToString() + ":" + dtResult.Rows[i - 1][ValueColumnName].ToString());
                if (Encoding.Default.GetByteCount(dtResult.Rows[i - 1][ValueColumnName].ToString()) > StringMaxLength)
                {
                    StringMaxLength = Encoding.Default.GetByteCount(dtResult.Rows[i - 1][ValueColumnName].ToString());
                }
            }
            FIDStructList[PageIndex] = FIDStruct1;
            lblValue.Text = listValues.Items[0].ToString().Replace("\r\n", ""); ;
            this.Width = 400;//2008-02-28 朱延传 修改 将宽度改为写死 StringMaxLength * CHARWIDTH;
        }
        private DataTable DataTableFill(string filtrate)
        {
            DataTable DTTemp = DictDT.Clone();
            DataRow[] DtRows = DictDT.Select(filtrate, FIDColumnName + " ASC ");
            foreach (DataRow Row in DtRows)
            {
                DTTemp.ImportRow(Row);
            }
            return DTTemp;
        }
        #endregion

        #region 控件事件
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Graphics1 = e.Graphics;
            Pen Pen1 = new Pen(Color.Black, 1);
            Graphics1.DrawLine(Pen1, txtValue.Location.X, txtValue.Location.Y + txtValue.Height + 2,
                               txtValue.Location.X + this.Width, txtValue.Location.Y + txtValue.Height + 2);
        }
        private void MedInputFrm_KeyDown(object sender, KeyEventArgs e)
        {
            string Filtrate = string.Empty;
            DataTable DtTemp = new DataTable();
            FIDStruct FIDStructNow = (FIDStruct)FIDStructList[PageIndex];
            FIDStruct FIDStructPrevious;
            if (PageIndex > 0)
            {
                FIDStructPrevious = (FIDStruct)FIDStructList[PageIndex - 1];
            }
            else
            {
                FIDStructPrevious = FIDStructNow;
            }
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (lblValue.Text.Length <= 2)
                    {
                        return;
                    }
                    if (TxtControl != null)
                    {
                        if (TxtControl.Multiline)
                        {
                            TxtControl.SelectedText = lblValue.Text.Remove(0, 2);
                        }
                        else
                        {
                            TxtControl.Text = lblValue.Text.Remove(0, 2);
                        }
                    }
                    else if (DataGridViewCell != null)
                    {
                        DataGridViewCell.Value = lblValue.Text.Remove(0, 2);
                    }
                    else if (TextEditControl != null)
                    {
                        TextEditControl.Text = lblValue.Text.Remove(0, 2);
                    }
                    Close();
                    return;
                case Keys.Escape:
                    Close();
                    return;
                case Keys.Oemplus:
                    Filtrate = CodeColumnName + " LIKE '%" + txtValue.Text.Trim() + "%' AND FID >'" + FIDStructNow.PageMaxFID + "'";
                    DtTemp = DataTableFill(Filtrate);
                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        PageIndex++;
                        ListBind(DtTemp);
                    }

                    break;
                case Keys.OemMinus:
                    Filtrate = CodeColumnName + " LIKE '%" + txtValue.Text.Trim() + "%' AND FID <'" + FIDStructNow.PageMinFID + "' AND FID >='" + FIDStructPrevious.PageMinFID + "'";
                    DtTemp = DataTableFill(Filtrate);
                    if (DtTemp != null && DtTemp.Rows.Count > 0)
                    {
                        if (PageIndex > 0)
                        {
                            PageIndex--;
                        }
                        ListBind(DtTemp);
                    }

                    break;
            }
        }
        private void listValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listValues.SelectedItem != null)
            {
                try
                {
                    DictDT.DefaultView.RowFilter = "TEMPLETE_NAME='" + listValues.SelectedItem.ToString().Remove(0, 2) + "'";
                    lblValue.Text = (listValues.SelectedIndex + 1) + ":" + DictDT.DefaultView[0]["TEMPLETE_DESC"].ToString();
                }
                catch (Exception)
                { 
                    lblValue.Text = listValues.SelectedItem.ToString(); 
                }
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                int Index = e.KeyChar - 48;
                if (Index == 0)
                {
                    Index = 9;
                }
                else
                {
                    Index--;
                }
                if (listValues.Items.Count > Index)
                {
                    if (TxtControl != null)
                    {
                        if (TxtControl.Multiline)
                        {
                            try
                            {
                                DictDT.DefaultView.RowFilter = "MONITOR_DATA_ALIAS='" + listValues.SelectedItem.ToString().Remove(0, 2) + "'";
                                lblValue.Text = DictDT.DefaultView[0]["MONITOR_DATA_VALUE"].ToString();
                            }
                            catch
                            {
                                DictDT.DefaultView.RowFilter = "TEMPLETE_NAME='" + listValues.Items[Index].ToString().Remove(0, 2) + "'";
                                TxtControl.SelectedText = DictDT.DefaultView[0]["TEMPLETE_DESC"].ToString();
                                //lblValue.Text = listValues.SelectedItem.ToString();
                            }
                        }
                        else
                        {
                            TxtControl.Text = listValues.Items[Index].ToString().Remove(0, 2);
                        }
                    }
                    else if (DataGridViewCell != null)
                    {
                        DataGridViewCell.Value = listValues.Items[Index].ToString().Remove(0, 2);
                    }
                    else if (TextEditControl != null)
                    {
                        TextEditControl.Text = listValues.Items[Index].ToString().Remove(0, 2);
                    }
                    Close();
                }
                e.Handled = true;
            }
            else if (e.KeyChar != 8 && (e.KeyChar < 'A' || e.KeyChar > 'Z') && (e.KeyChar < 'a' || e.KeyChar > 'z'))
            {
                e.Handled = true;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            string Filtrate = CodeColumnName + " LIKE '%" + txtValue.Text.Trim() + "%' ";
            ListBind(DataTableFill(Filtrate));
        }

        private void listValues_DoubleClick(object sender, EventArgs e)
        {
            if (listValues.SelectedItem == null) return;
            if (TxtControl != null)
            {
                if (TxtControl.Multiline)
                {
                     TxtControl.SelectedText = listValues.SelectedItem.ToString().Remove(0, 2);
                }
                else
                {
                    TxtControl.Text = listValues.SelectedItem.ToString().Remove(0, 2);
                }
                Close();
            }
            else if (DataGridViewCell != null)
            {
                DataGridViewCell.Value = listValues.SelectedItem.ToString().Remove(0, 2);
                Close();
            }
            else if (TextEditControl != null)
            {
                TextEditControl.Text = listValues.SelectedItem.ToString().Remove(0, 2);
                Close();
            }
        }

        #endregion

    }
}