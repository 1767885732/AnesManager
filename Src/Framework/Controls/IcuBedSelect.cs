using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    public class IcuBedSelect:UserControl
    {

        #region 私有变量

        /// <summary>
        /// 间距
        /// </summary>
        private const int SPAN = 10;

        /// <summary>
        /// 下拉列表宽度
        /// </summary>
        private int _dropDownWidth = 500;

        /// <summary>
        /// 下拉列表高度
        /// </summary>
        private int _dropDownHeight = 300;

        /// <summary>
        /// 下拉框
        /// </summary>
        private Rectangle _rect = new Rectangle(SPAN, SPAN, Resources.ComboBoxBorder.Width, 58);

        /// <summary>
        /// 项目集
        /// </summary>
        private List<BedInformation> _items = new List<BedInformation>();

        private DataTable _patients = null;

        //private System.ComponentModel.IContainer components;

        /// <summary>
        /// 当前项目索引
        /// </summary>
        private int _itemIndex = -1;

        /// <summary>
        /// 弹出窗口
        /// </summary>
        private MedPopupForm _popupForm;

        /// <summary>
        /// 弹出窗口关闭点
        /// </summary>
        private Point _popupClosedPoint = new Point(-1,-1);

        private int _rowIndex;
        private Label labelBedNo;
        private Label labelName;
        private PictureBox pictureBoxHead;
        private Label labelOut;
        private Panel panel1;
        private DataRow _currentPatient;

        #endregion

        #region 属性

        /// <summary>
        /// 选择改变事件
        /// </summary>
        public event EventHandler ItemChanged;

        /// <summary>
        /// 选择改变事件结束
        /// </summary>
        public event EventHandler ItemChangedFinish;

        /// <summary>
        /// 下拉列表展开事件
        /// </summary>
        public event EventHandler DropDown;

        /// <summary>
        /// 下拉列表关闭事件
        /// </summary>
        public event EventHandler DropDownClosed;

        public event EventHandler CurrentPatientChanged;


        public DataTable Patients
        {
            get
            {
                return _patients;
            }
            set
            {
                _patients = value;
                //medSelectPatientComboBox1.Patients = _patients;
                if (_patients != null)
                {
                    if (_patients.Rows.Count <= 30)
                    {
                        DropDownHeight = 200;
                    }
                    else
                    {
                        DropDownHeight = 300;
                    }
                }
               
            }
        }

        public int ItemIndex
        {
            get
            {
                return _itemIndex;
            }
            set
            {
                _itemIndex = value;
            }
        }

        public DataRow CurrentPatient
        {
            get
            {
                return _currentPatient;
            }
            set
            {
                _currentPatient = value;
                if (value != null)
                {
                    labelBedNo.Text = _currentPatient["BED_LABEL"].ToString()+"床";
                    string name = _currentPatient["NAME"].ToString();
                    this.labelName.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    if (name.Length == 2)
                    {
                        labelName.Text = name.Substring(0, 1) + " " + name.Substring(1);
                    }
                    else if (name.Length >= 4)
                    {
                        labelName.Text = name;
                        labelName.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        //labelName.Location = new Point(106, 12);
                    }
                    else
                    {
                        labelName.Text = name;
                    }
                    if (_currentPatient["SEX"].ToString() == "男")
                    {
                        this.pictureBoxHead.Image = Resources.male_small;
                    }
                    else
                    {
                        this.pictureBoxHead.Image = Resources.femal_small;
                    }
                }
            }
        }

        /// <summary>
        /// 选择的床号
        /// </summary>
        /// 
        //public int RowIndex
        //{
        //    get
        //    {
        //        if ((_itemIndex < _items.Count) && (_itemIndex > -1))
        //        {
        //            return _items[_itemIndex].RowIndex;
        //        }
        //        else
        //        {
        //            return -1;
        //        }
        //    }
        //    set
        //    {
        //        if (_items.Count > 0)
        //        {
        //            _rowIndex = value;
        //            Invalidate();
        //        }
        //    }
        //}


        //public string SelectedBedNo
        //{
        //    get
        //    {
        //        if ((_itemIndex < _items.Count) && (_itemIndex > -1))
        //        {
        //            return _items[_itemIndex].BedNo.ToString();
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    set
        //    {
        //        if (_items.Count > 0)
        //        {
        //            int i = 0;
        //            foreach (BedInformation item in _items)
        //            {
        //                if (item.BedNo.ToString().Equals(value))
        //                {
        //                    _itemIndex = i;
        //                    Invalidate();
        //                    break;
        //                }
        //                i++;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 下拉列表宽度
        /// </summary>
        public int DropDownWidth
        {
            get
            {
                return _dropDownWidth;
            }
            set
            {
                _dropDownWidth = value;
            }
        }

        /// <summary>
        /// 下拉列表高度
        /// </summary>
        public int DropDownHeight
        {
            get
            {
                return _dropDownHeight;
            }
            set
            {
                _dropDownHeight = value;
            }
        }

        #endregion

        # region 构造方法

        public IcuBedSelect()
        {
            InitializeComponent();
        }

        #endregion

        #region 方法

        public void Clear()
        {
            Patients = null;
        }

        public void SetStatus(bool inHospital,string patName)
        {
            if (inHospital)
            {
                labelOut.Visible = false;
            }
            else
            {
                labelOut.Visible = true;
                labelOut.Text = " 已出科  " + patName;
                labelOut.BringToFront();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            //g.FillRectangle(new TextureBrush(Skin.Skin.GetLeftBedImage()), 0, 0, Resources.ComboBoxBorder.Width + SPAN * 2, this.Height);
            //g.DrawImage(Resources.ComboBoxBorder, SPAN, SPAN);
            //g.DrawImage(Resources.ComboBoxBorder, 59,22);
            //Rectangle rect = new Rectangle(Resources.ComboBoxBorder.Width + SPAN * 2, (int)((this.Height - Resources.BedBack.Height) / 2), Resources.BedBack.Height + 20, Resources.BedBack.Height);
            Rectangle rect = new Rectangle(61, 23, Resources.BedBack.Height + 20, Resources.BedBack.Height);
            if (this.Enabled)
            {
                //g.FillRectangle(new TextureBrush(Resources.BedBack), rect);
                //g.FillRectangle(new TextureBrush(Skin.Skin.GetRightBedImage()), rect);
                if (CurrentPatient != null)
                {
                    Font ft = new Font("微软雅黑", 12);
                    //g.DrawString("床", new Font("微软雅黑", 12), Brushes.White, rect.X + 35, 20);
                    //g.DrawString(string.Format("当前为{0}号床", new object[] { _items[_itemIndex].Bed_Label }), ft, Brushes.Green, _rect.X, _rect.Y + 2);
                    //g.DrawString(string.Format("当前为{0}号床", new object[] { CurrentPatient["Bed_Label"].ToString() }), ft, Brushes.Black, _rect.X, _rect.Y + 2);
                    //if (CurrentPatient["Bed_Label"].ToString().Length > 1) ft = new Font("微软雅黑", 20); else ft = new Font("微软雅黑", 24);
                    //if (CurrentPatient["Bed_Label"].ToString().Length > 2)
                    //{
                    //    g.DrawString(CurrentPatient["Bed_Label"].ToString(), ft, Brushes.White, rect.X + 45 - g.MeasureString(CurrentPatient["Bed_Label"].ToString(), ft).Width, 10);
                    //}
                    //else
                    //{
                    //    g.DrawString(CurrentPatient["Bed_Label"].ToString(), ft, Brushes.White, rect.X + 38 - g.MeasureString(CurrentPatient["Bed_Label"].ToString(), ft).Width, 10);
                    //}
                    ft.Dispose();
                }
            }
            else
            {
                g.FillRectangle(new TextureBrush(Resources.BedBackDisable), rect);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((e.Button == MouseButtons.Left) && (_rect.Contains(e.X, e.Y)))
            {
                if (_popupForm == null)
                {
                    Point pt = TransPoint(new Point(e.X, e.Y));
                    ///是否在当前点关闭了弹出窗口，如果是这次不弹出窗口
                    if ((_popupClosedPoint.X == pt.X) && (_popupClosedPoint.Y == pt.Y))
                    {
                        _popupClosedPoint = new Point(-1, -1);
                    }
                    else
                    {
                        //DoDropDown();
                    }
                }
            }
        }

        /// <summary>
        /// 显示下拉列表
        /// </summary>
        private void DoDropDown()
        {
            //int index = 0;
            //foreach (DataRow patientinfo in Patients.Rows)
            //{
            //    if (patientinfo["BED_NO"].ToString() == _currentPatient["BED_NO"].ToString())
            //        break;
            //    index++;
            //}
            //_itemIndex=index;
            //MedPatientSelectListView listView1 = new MedPatientSelectListView(Patients);
            //if ((_itemIndex >= 0) && (_itemIndex < listView1.Items.Count)) 
            //    listView1.Items[_itemIndex].Selected = true;
            //_popupForm = new MedPopupForm();
            //_popupForm.Width = _dropDownWidth;
            //_popupForm.Height = _dropDownHeight;
            //listView1.Click += new EventHandler(delegate(object sender1, EventArgs e1)
            //{
            //    if (listView1.SelectedItems.Count > 0)
            //    {
            //        if(_itemIndex != listView1.SelectedItems[0].Index)
            //        {
            //            _itemIndex = listView1.SelectedItems[0].Index;
            //            listView1.BackgroundImage = Resources.卡片2;
            //            CurrentPatient = Patients.Rows[listView1.SelectedItems[0].Index];
            //            if (ItemChanged != null)
            //                ItemChanged(this, new EventArgs());
            //            Invalidate();
            //        }
            //        if(_popupForm!=null) _popupForm.Close();
            //        if (_itemIndex != listView1.SelectedItems[0].Index)
            //        {
            //            ItemChangedFinish(this, new EventArgs());
            //        }
            //    }
            //});
            //_popupForm.Load += new EventHandler(
            //    delegate(object sender1, EventArgs e1)
            //    {
            //        listView1.AdjustSpacing();
            //    }
            //);
            //_popupForm.FormClosed += new FormClosedEventHandler(
            //    delegate(object sender2, FormClosedEventArgs e2)
            //    {
            //        _popupForm = null;
            //        ///激活弹出列表关闭后事件
            //        if (DropDownClosed != null) DropDownClosed(this, new EventArgs());
            //    }
            //);
            //_popupForm.HookClosed += new MedPopupForm.HookClosedEventHandle(
            //    delegate(Point mousePoint)
            //    {
            //        ///保存弹出窗口关闭点
            //        _popupClosedPoint = mousePoint;
            //    }
            //);
            //Point pt = TransPoint(_rect.Location);

            /////弹出下拉列表
            //_popupForm.Popup(pt.X-10, pt.Y + _rect.Height, listView1);
            /////激活下拉列表弹出时事件
            //if (DropDown != null) DropDown(this, new EventArgs());

            //if (_popupForm != null)
            //{
            //    _popupForm.Activate();
            //    _popupForm.Active = true;
            //}
            
        }

        /// <summary>
        /// 将相对本控件坐标的点转换成屏幕坐标的点
        /// </summary>
        /// <param name="pt">相对本控件坐标的点</param>
        /// <returns>屏幕坐标的点</returns>
        private Point TransPoint(Point pt)
        {
            int x = 0, y = 0;
            Control parent = this.Parent;
            while (parent != null)
            {
                x += parent.Left;
                y += parent.Top;
                parent = parent.Parent;
            }
            return new Point(pt.X + x, pt.Y + y);
        }

        private void InitializeComponent()
        {
            this.labelBedNo = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxHead = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBedNo
            // 
            this.labelBedNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBedNo.AutoSize = true;
            this.labelBedNo.BackColor = System.Drawing.Color.Transparent;
            this.labelBedNo.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBedNo.ForeColor = System.Drawing.Color.White;
            this.labelBedNo.Location = new System.Drawing.Point(3, 10);
            this.labelBedNo.Name = "labelBedNo";
            this.labelBedNo.Size = new System.Drawing.Size(100, 39);
            this.labelBedNo.TabIndex = 2;
            this.labelBedNo.Text = "02床  ";
            this.labelBedNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBedNo_MouseDown);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.labelName.Location = new System.Drawing.Point(150, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(58, 27);
            this.labelName.TabIndex = 3;
            this.labelName.Text = " 测试";
            // 
            // labelOut
            // 
            this.labelOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.labelOut.Enabled = false;
            this.labelOut.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOut.ForeColor = System.Drawing.Color.Maroon;
            this.labelOut.Location = new System.Drawing.Point(122, 10);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(199, 39);
            this.labelOut.TabIndex = 8;
            this.labelOut.Text = " 已出科  将卡罗拉";
            this.labelOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOut.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.labelBedNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(114, 58);
            this.panel1.TabIndex = 9;
            // 
            // pictureBoxHead
            // 
            this.pictureBoxHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxHead.Image = Resources.male_small;
            this.pictureBoxHead.Location = new System.Drawing.Point(126, 21);
            this.pictureBoxHead.Name = "pictureBoxHead";
            this.pictureBoxHead.Size = new System.Drawing.Size(24, 28);
            this.pictureBoxHead.TabIndex = 7;
            this.pictureBoxHead.TabStop = false;
            // 
            // IcuBedSelect
            // 
            this.Controls.Add(this.labelOut);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxHead);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "IcuBedSelect";
            this.Size = new System.Drawing.Size(369, 58);
            this.Load += new System.EventHandler(this.IcuBedSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region 控件事件

        private void IcuBedSelect_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        #endregion

        private void labelBedNo_MouseDown(object sender, MouseEventArgs e)
        {
            if (_popupForm == null)
            {
                Point pt = TransPoint(new Point(e.X, e.Y));
                ///是否在当前点关闭了弹出窗口，如果是这次不弹出窗口
                if ((_popupClosedPoint.X == pt.X) && (_popupClosedPoint.Y == pt.Y))
                {
                    _popupClosedPoint = new Point(-1, -1);
                }
                else
                {
                    //DoDropDown();
                }
            }
        }

    }
}
