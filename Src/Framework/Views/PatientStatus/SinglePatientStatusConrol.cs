using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.BusinessEntity;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Utilities;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.DataAccess;

namespace Wis.Anes.Framework.Views
{
    [Serializable(),ToolboxItem(false)]
    public partial class SinglePatientStatusConrol : XtraUserControl
    {
        public SinglePatientStatusConrol()
        {
            InitializeComponent();
        }
        private Image _NormalImage = null;
        private Image _PassedImage = null;
        private Image _LightImage = null;
        private Image _BackGroundImage = null;
        private string _StatusName = "";
        private Wis.Anes.Framework.Views.PatientStatusContrl.OperationLightStatus _ConrolLightStatus = PatientStatusContrl.OperationLightStatus.Nomal;
        private PatientStatusContrl _ServicePatientStatusContrl = null;
        private DateTime _ControlDateTime = DateTime.MinValue;
        private bool _canEdit = true ;

        public string StatusName
        {
            get { return _StatusName; }
            set
            {

                _StatusName = value;
                lbStatusName.Text = _StatusName;
            }
        }
        public Image NormalImage
        {
            get { return _NormalImage; }
            set { _NormalImage = value; }
        }
        public Image PassedImage
        {
            get { return _PassedImage; }
            set { _PassedImage = value; }
        }
        public Image LightImage
        {
            get { return _LightImage; }
            set { _LightImage = value; }
        }
        public Image BackGroundImage
        {
            get { return _BackGroundImage; }
            set { _BackGroundImage = value; }
        }
        
        public Wis.Anes.Framework.Views.PatientStatusContrl.OperationLightStatus ConrolLightStatus
        {
            get { return _ConrolLightStatus; }
            set { _ConrolLightStatus = value; }
        }
        /// <summary>
        /// 获取控件时间
        /// </summary>
        public DateTime ControlDateTime
        {
            get
            {
                if (dtpStatusDateTime.EditValue == null)
                    return DateTime.MinValue;
                else
                {
                    return (DateTime)dtpStatusDateTime.EditValue;
                }

            }
            set { dtpStatusDateTime.EditValue = value; }
        }

        /// <summary>
        /// 该 SinglePatientStatusConrol 服务的控件
        /// </summary>
        public PatientStatusContrl ServicePatientStatusContrl
        {
            get { return _ServicePatientStatusContrl; }
            set { _ServicePatientStatusContrl = value; }
        }

        /// <summary>
        /// 设置状态灯的图片
        /// </summary>
        /// <param name="operationLightStatus"></param>
        public void SetStatusLightImage(PatientStatusContrl.OperationLightStatus operationLightStatus)
        {
            _ConrolLightStatus = operationLightStatus;
            if (operationLightStatus == PatientStatusContrl.OperationLightStatus.Nomal)
            {
                picLight.Image = NormalImage;

            }
            else if (operationLightStatus == PatientStatusContrl.OperationLightStatus.Light)
            {
                picLight.Image = LightImage;
            }
            else if (operationLightStatus == PatientStatusContrl.OperationLightStatus.Passed)
            {
                picLight.Image = PassedImage;
            }
            else
            {
                picLight.Image = null;
            }
            picLight.Invalidate();

        }
        /// <summary>
        /// 设置状态控件是否可用
        /// </summary>
        public void SetPatientStatusContrlReadOnly(bool readonlyable)
        {
           //this.Enabled = readonlyable;
            _canEdit = readonlyable;
            dtpStatusDateTime.Enabled = readonlyable;

        }

        /// <summary>
        /// 设置状态时间
        /// </summary>
        /// <param name="operationLightStatus"> 参数如果是 DateTime.MinValue，则显示为空 </param>
        public void SetOperationStatusTimeText(DateTime operationStatusTime)
        {
            if (operationStatusTime == DateTime.MinValue)
            {
                dtpStatusDateTime.EditValue = null;
                toolTipStatusTime.SetToolTip(dtpStatusDateTime, "");
                SetStyle(false);
            }
            else
            {
                dtpStatusDateTime.EditValue = operationStatusTime;
                toolTipStatusTime.SetToolTip(dtpStatusDateTime, operationStatusTime.ToString("yyyy-MM-dd HH:mm"));
                SetStyle(true);
            }

            _ControlDateTime = operationStatusTime;
        }

        public void RobackTime()
        {
            SetOperationStatusTimeText(_ControlDateTime);
        }

        private void SinglePatientStatusConrol_Load(object sender, EventArgs e)
        {
            lbStatusName.BackColor = Color.Transparent;

           



        }





        /// <summary>
        /// 根据是否有时间值来设置样式
        /// </summary>
        /// <param name="hasDate"></param>
        public void SetStyle(bool hasDate)
        {
            if (hasDate)
            {
                dtpStatusDateTime.BackColor = this.BackColor;
            }
            else
            {
                dtpStatusDateTime.BackColor = Color.White;
            }
        }







        /// <summary>
        /// 双击时间框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatusDateTime_Properties_DoubleClick(object sender, EventArgs e)
        {
            //验证是否可触发
            if (!_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeKeyDown(this))
            {
                SetOperationStatusTimeText(DateTime.MinValue);
                return;
            }

            //如果是空，并且可编辑的话
            if (IsDateTimeEmpty())
            {
                DateTime dt = System.DateTime.Now;
                string dtString = dt.ToString("yyyy-MM-dd HH:mm");
                DateTime.TryParse(dtString, out dt);
                SetOperationStatusTimeText(dt);
                
            }
        }
        /// <summary>
        /// 小灯鼠标按下事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLight_MouseDown(object sender, MouseEventArgs e)
        {

            if (AccessControl.PermissionProviderCustom.CheckModifyRightForOperator("麻醉记录单", "NotCheckPrint"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    _ServicePatientStatusContrl.OnPopUpOperationSatusMouseDown(this);
                }
            }
            //if (!_canEdit)//如果不可编辑
            //{
            //    return;
            //}

        }
        /// <summary>
        /// 控件被单击事件，判断是否可被修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatusDateTime_Properties_Click(object sender, EventArgs e)
        {
            
                if (!_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeClick(this))
                {
                    this.ParentForm.Controls[0].Focus();
                }
            
                //_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeClick(this);
                
        }

        /// <summary>
        /// 图片控件被单击事件，判断是否可被修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picLight_Click(object sender, EventArgs e)
        {
            _ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeClick(this);
        }


        /// <summary>
        /// 键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatusDateTime_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            dtpStatusDateTime.ErrorText = "";
            if (e.KeyCode == Keys.Escape)
            {
                return;
            }
            if (!_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeKeyDown(this))
            {
                SetOperationStatusTimeText(DateTime.MinValue);
                return;
            }
        }

        /// <summary>
        /// 输入时间验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatusDateTime_Properties_Validating(object sender, CancelEventArgs e)
        {
            //int validateFlag = 0; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示

            


            if (!_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeValidate(this))
            {
                e.Cancel = true;
                dtpStatusDateTime.ErrorText = "输入时间错误，请重新输入！";
            }
           
        }


        public bool IsValidated()
        {

            return _ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeValidate(this);
        }
     

        /// <summary>
        /// 验证结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStatusDateTime_Validated(object sender, EventArgs e)
        {
            dtpStatusDateTime.ErrorText = "";
        }
        /// <summary>
        /// 判断时间是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsDateTimeEmpty()
        {
            string text = dtpStatusDateTime.Text;

            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            return false;
        }

        private void dtpStatusDateTime_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void dtpStatusDateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                dtpStatusDateTime_Properties_Validating(sender,new CancelEventArgs());

                lbStatusName.Focus();//自动触发 dtpStatusDateTime_Properties_Validating 事件
            }
            
        }
        private void dtpStatusDateTime_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //验证是否可触发
            if (!_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeKeyDown(this))
            {
                SetOperationStatusTimeText(DateTime.MinValue);
                return;
            }
        }

        private void dtpStatusDateTime_EditValueChanged(object sender, EventArgs e)
        {

        }





    }
}
