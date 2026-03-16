using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Utilities;

namespace Wis.Anes.Framework.Controls
{
    /// <summary>
    /// 基类窗口代码模块
    /// </summary>
    public partial class BaseFrm : Form
    {
        #region 常量

        private const int IME_CMODE_FULLSHAPE = 0x8;
        private const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        #endregion 常量

        #region 私有变量

        /// <summary>
        /// 鼠标位置
        /// </summary>
        private int XX = -1, YY = -1;

        private Image _titleImage, _backGroundImage;

        private bool _isMovable = true, _lockMouseEvent = false;

        private Font _titleFont = new Font("宋体", 10.5f, FontStyle.Bold);

        private Color _titleFontColor = Color.Black;

        #endregion 私有变量

        #region 属性

        /// <summary>
        /// 是否锁定(禁用)鼠标事件
        /// </summary>
        public bool LockMouseEvent
        {
            get
            {
                return _lockMouseEvent;
            }
            set
            {
                _lockMouseEvent = value;
            }
        }

        /// <summary>
        /// 窗口是否可移动
        /// </summary>
        public bool IsMovable
        {
            get
            {
                return _isMovable;
            }
            set
            {
                _isMovable = value;
            }
        }

        /// <summary>
        /// 窗口标题左边图片
        /// </summary>
        public Image TitleImage
        {
            get
            {
                return _titleImage;
            }
            set
            {
                _titleImage = value;
                if (value == null)
                {
                    pnlTop.Height = 27;
                    picLeft.Visible = true;
                    picRight.Visible = true;
                    picTop.Visible = true;
                    picBottom.Visible = true;
                }
                else
                {
                    if (_titleImage.Height > pnlTop.Height) pnlTop.Height = _titleImage.Height;
                    picLeft.Visible = false;
                    picRight.Visible = false;
                    picTop.Visible = false;
                    picBottom.Visible = false;
                }
            }
        }

        /// <summary>
        /// 窗口标题填充图片
        /// </summary>
        public Image TitleBackGroundImage
        {
            get
            {
                return _backGroundImage;
            }
            set
            {
                _backGroundImage = value;
            }
        }

        public Font TitleFont
        {
            get
            {
                return _titleFont;
            }
            set
            {
                _titleFont = value;
            }
        }

        public Color TitleFontColor
        {
            get
            {
                return _titleFontColor;
            }
            set
            {
                _titleFontColor = value;
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseFrm()
        {
            InitializeComponent();

            ///设置双缓存
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

        }

        #endregion

        #region 方法

        /// <summary>
        /// 解决微软自动更新输入法为全角BUG
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            try
            {
                base.OnActivated(e);
                IntPtr HIme = WinAPI.ImmGetContext(this.Handle);
                if (WinAPI.ImmGetOpenStatus(HIme))  //如果输入法处于打开状态
                {
                    int iMode = 0;
                    int iSentence = 0;
                    bool bSuccess = WinAPI.ImmGetConversionStatus(HIme, ref iMode, ref iSentence);  //检索输入法信息
                    if (bSuccess)
                    {
                        if ((iMode & WinAPI.IME_CMODE_FULLSHAPE) > 0)   //如果是全角
                            WinAPI.ImmSimulateHotKey(this.Handle, WinAPI.IME_CHOTKEY_SHAPE_TOGGLE);  //转换成半角
                    }

                }
            }
            catch
            {

            }
        }

        private void PaintTitlePanel()
        {
            using (Graphics g = pnlTop.CreateGraphics())
            {
                Rectangle rect = pnlTop.Bounds;
                //if (_titleImage != null)
                //{
                //    #region 画左边图片

                //    g.DrawImage(_titleImage, new RectangleF(0, 0, _titleImage.Width, _titleImage.Height));

                //    #endregion 画左边图片

                //    #region 填充标题栏

                //    if (_backGroundImage != null)
                //    {
                //        float X = _titleImage.Width;
                //        while (X < rect.Width)
                //        {
                //            g.DrawImage(_backGroundImage, new RectangleF(X, 0, _backGroundImage.Width, _backGroundImage.Height));
                //            X += _backGroundImage.Width;
                //        }
                //    }

                //    #endregion 填充标题栏
                //}
                //else
                //{
                #region 根据图片边框

                //float X = 0;
                //while (X < rect.Width)
                //{
                //    g.DrawImage(picTitleFill.Image, new RectangleF(X, 0, picTitleFill.Image.Width, picTitleFill.Image.Height));
                //    X += picTitleFill.Image.Width;
                //}

                #endregion 根据图片边框

                #region 画窗体图标

                int iconHeight = 22, iconWidth = 22, iconSpan = 2;
                Rectangle iconRect = new Rectangle(20 + iconSpan, 6, iconWidth, iconHeight);
                g.DrawIcon(Icon, iconRect);
                g.DrawString(Text, _titleFont, new SolidBrush(_titleFontColor), iconRect.Left + iconRect.Width + 130, (pnlTop.Height - g.MeasureString("A", _titleFont).Height) / 2 + 2);

                #endregion 画窗体图标

                //}
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!DesignMode)
            {
                PaintTitlePanel();
                btnClose.Refresh();
                btnMin.Refresh();
                btnRestore.Refresh();
                btnMax.Refresh();
            }
        }

        #region 查询条件
        /// <summary>
        /// 显示所选择条件
        /// </summary>
        protected void OK()
        {
            ArrayList strings = new ArrayList();
            AddControlTextToStrings(strings, this);
            string conditions = "";
            foreach (string strline in strings)
            {
                if (conditions == "") conditions = strline; else conditions += " And " + strline;
            }
            Sundries.MessageBox(conditions);
        }
        #endregion

        #region 保存/装入控件文本
        /// <summary>
        /// 将控件Text写入字符串集合
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="container"></param>
        private void AddControlTextToStrings(ArrayList strings, Control container)
        {
            foreach (Control control in container.Controls)
            {
                if ((control is MedTextBox) && (((MedTextBox)control).Text.Trim().Length > 0))
                {
                    strings.Add(((MedTextBox)control).FieldName + "='" + control.Text.Trim() + "'");
                }
                else if (control.Controls.Count > 0) AddControlTextToStrings(strings, control);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        protected void SaveFile()
        {
            string fileName;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "*.qtm|*.qtm";
                saveFileDialog.ShowDialog();
                fileName = saveFileDialog.FileName;
            }
            if ((fileName == "") || (fileName == null)) return;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Key");
            dataTable.Columns.Add("Value");
            AddControlTextToTable(dataTable, this);
            dataSet.Tables.Add(dataTable);
            dataSet.WriteXml(fileName);
            Sundries.MessageBox("保存成功");
        }

        /// <summary>
        /// 将控件Text写入DataTable
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="container"></param>
        private void AddControlTextToTable(DataTable dataTable, Control container)
        {
            foreach (Control control in container.Controls)
            {
                if ((control is TextBoxBase) || (control is ComboBox))
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = control.Name;
                    dataRow[1] = control.Text;
                    dataTable.Rows.Add(dataRow);
                }
                else if (control.Controls.Count > 0) AddControlTextToTable(dataTable, control);
            }
        }

        /// <summary>
        /// 从DataTable读取控件Text
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="container"></param>
        private void ReadControlTextFromTable(DataTable dataTable, Control container)
        {
            foreach (Control control in container.Controls)
            {
                if ((control is TextBoxBase) || (control is ComboBox))
                {
                    DataRow dataRow = dataTable.Rows.Find(control.Name);
                    if (dataRow != null) control.Text = dataRow[1].ToString();
                }
                else if (control.Controls.Count > 0) ReadControlTextFromTable(dataTable, control);
            }
        }

        /// <summary>
        /// 装入文件
        /// </summary>
        protected void LoadFile()
        {
            string fileName;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "*.qtm|*.qtm";
                openFileDialog.ShowDialog();
                fileName = openFileDialog.FileName;
            }
            if ((fileName == "") || (fileName == null)) return;
            DataSet dataSet = new DataSet();
            try
            {
                dataSet.ReadXml(fileName);
                DataTable dataTable = dataSet.Tables[0];
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };
                ReadControlTextFromTable(dataTable, this);
            }
            catch (Exception ex) { ex.Message.ToString(); return; }
        }
        #endregion

        #endregion 方法

        #region 窗体事件

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender">窗体</param>
        /// <param name="e">事件参数</param>
        private void BaseFrm_Load(object sender, EventArgs e)
        {
            this.Height = Screen.GetWorkingArea(this).Height;
            this.Width = Screen.GetWorkingArea(this).Width;
            this.Location = new Point(0, 0);
            this.label1.Image = Skin.Skin.GetLogoImage();
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    if (MaximizeBox)
            //    {
            //        btnRestore.Visible = true;
            //    }
            //}
            //else
            //{
            //    if (MaximizeBox)
            //    {
            //        btnMax.Visible = true;
            //    }
            //}
            //btnMin.Visible = MinimizeBox;
        }

        #endregion 窗体事件

        #region 控件事件

        /// <summary>
        /// 点击关闭窗体按钮
        /// </summary>
        /// <param name="sender">关闭按钮</param>
        /// <param name="e">事件参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 画标题Panel事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            PaintTitlePanel();
        }

        /// <summary>
        /// 标题Panel大小改变事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_Resize(object sender, EventArgs e)
        {
            btnClose.Left = pnlTop.Width - btnClose.Width - 5;
            btnRestore.Left = btnClose.Left - btnRestore.Width - 2;
            btnMax.Left = btnRestore.Left;
            btnMin.Left = btnRestore.Left - btnMin.Width - 2;
        }

        /// <summary>
        /// 标题Panel鼠标按下事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) || (this.WindowState == FormWindowState.Normal))
            {
                XX = e.X;
                YY = e.Y;
            }
        }

        /// <summary>
        /// 标题Panel鼠标放开事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) || (this.WindowState == FormWindowState.Normal))
            {
                XX = -1;
                YY = -1;
            }
        }

        /// <summary>
        /// 标题Panel鼠标移动事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && (XX > -1) && (YY > -1))
            {
                this.Left += e.X - XX;
                this.Top += e.Y - YY;
            }
        }

        /// <summary>
        /// 最小化按钮事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 还原按钮事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            btnMax.Visible = true;
            btnRestore.Visible = false;
            this.Height = Screen.GetWorkingArea(this).Height - 100;
            this.Width = Screen.GetWorkingArea(this).Width - 400;
            this.Location = new Point(200, 50);
            //WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 最大化按钮事件
        /// </summary>
        /// <param name="sender">标题Panel</param>
        /// <param name="e">事件参数</param>
        private void btnMax_Click(object sender, EventArgs e)
        {
            btnMax.Visible = false;
            btnRestore.Visible = true;

            WindowState = FormWindowState.Normal;
            this.Height = Screen.GetWorkingArea(this).Height;
            this.Width = Screen.GetWorkingArea(this).Width;
            this.Location = new Point(0, 0);
        }

        #endregion 控件事件

        /// <summary>
        /// 双击标题栏实现最大化、还原功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlTop_DoubleClick(object sender, EventArgs e)
        {

            if (btnMax.Visible == false)
            {
                //还原
                btnMax.Visible = true;
                btnRestore.Visible = false;
                this.Height = Screen.GetWorkingArea(this).Height - 100;
                this.Width = Screen.GetWorkingArea(this).Width - 400;
                this.Location = new Point(200, 50);
            }
            else
            {
                //最大化
                btnMax.Visible = false;
                btnRestore.Visible = true;

                WindowState = FormWindowState.Normal;
                this.Height = Screen.GetWorkingArea(this).Height;
                this.Width = Screen.GetWorkingArea(this).Width;
                this.Location = new Point(0, 0);
            }
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.Image = Skin.Skin.GetbtnMinImage2();
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.Image = Skin.Skin.GetbtnMinImage1();
        }

        private void btnMin_MouseDown(object sender, MouseEventArgs e)
        {
            btnMin.Image = Skin.Skin.GetbtnMinImage3();
        }

        private void btnMax_MouseDown(object sender, MouseEventArgs e)
        {
            btnMax.Image = Skin.Skin.GetbtnMaxImage3();
        }

        private void btnMax_MouseEnter(object sender, EventArgs e)
        {
            btnMax.Image = Skin.Skin.GetbtnMaxImage2();
        }

        private void btnMax_MouseLeave(object sender, EventArgs e)
        {
            btnMax.Image = Skin.Skin.GetbtnMaxImage1();
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = Skin.Skin.GetbtnCloseImage3();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Skin.Skin.GetbtnCloseImage2();
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Skin.Skin.GetbtnCloseImage1();
        }

        private void btnRestore_MouseDown(object sender, MouseEventArgs e)
        {
            btnRestore.Image = Skin.Skin.GetbtnRestoreImage3();
        }

        private void btnRestore_MouseEnter(object sender, EventArgs e)
        {
            btnRestore.Image = Skin.Skin.GetbtnRestoreImage2();
        }

        private void btnRestore_MouseLeave(object sender, EventArgs e)
        {
            btnRestore.Image = Skin.Skin.GetbtnRestoreImage1();
        }

        private void tCheckList_Click(object sender, EventArgs e)
        {
            VirtualRefreshWarnmingInfo(sender, e);
        }

        protected virtual void VirtualRefreshWarnmingInfo(object sender, EventArgs e)
        {

        }

    }
}