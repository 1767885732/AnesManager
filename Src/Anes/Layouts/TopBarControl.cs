/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：TopBarControl.cs
// 文件功能描述：TopBarControl
// 创建标识：XXX-2008-10-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework;
using Wis.Anes.Framework.Views.PatientStatus;

namespace Wis.Anes.Layouts
{
    /// <summary>
    /// 顶端手术状态条
    /// </summary>
    [ToolboxItem(false)]
    public partial class TopBarControl : XtraUserControl, IOperationStatusObserver
    {
        public TopBarControl()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 初始化手术状态栏界面
        /// </summary>
        private void Initalize()
        {
            
        }

        private Image _NormalImage = null;
        private Image _PassedImage = null;
        private Image _LightImage = null;

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

        public MecicalDocBarControl MecicalDocBarControl
        {
            get { return mecicalDocBarControl1; }
        }


        /// <summary>
        /// 状态改变事件
        /// </summary>
        public EventHandler<StatusChangedEventArges> StatusChangedEvent;
        public EventHandler RefreshStatusEvent;

        /// <summary>
        /// 工作区域引用封装
        /// </summary>
        private MainForm _MainFormRef = null;
        /// <summary>
        /// 工作区域引用封装
        /// </summary>
        public MainForm MainFormRef
        {
            get { return _MainFormRef; }
            set { _MainFormRef = value; }
        }

        public Wis.Anes.Framework.Views.PatientStatusContrl PatientStatusControl
        {
            get { return patientStatusContrl1; }
        }

        /// <summary>
        /// 发起状态改变事件
        /// </summary>
        /// <param name="commandName"></param>
        private void RaiseEvent(string statusName)
        {
            if (StatusChangedEvent != null)
                StatusChangedEvent(this, new StatusChangedEventArges(statusName));
        }

        private void RaiseRefreshEvent()
        {
            if (RefreshStatusEvent != null)
                RefreshStatusEvent(this, new EventArgs());
        }


        /// <summary>
        /// 设置当前的手术状态
        /// </summary>
        public void SetCurrentStatus(string statusName)
        {

        }
        /// <summary>
        /// 设置手术状态触发的事件
        /// </summary>
       // private IPatientStatusAction patientStatusAction = null;
        public void SetPatientStatusAction(IPatientStatusAction patientStatusAction)
        {
            patientStatusContrl1.SetPatientStatusAction( patientStatusAction);
        }
        /// <summary>
        /// 设置状态控件是否可用
        /// </summary>
        public void SetPatientStatusContrlEnable(bool enable)
        {
            this.patientStatusContrl1.Enabled = enable;

        }

        /// <summary>
        /// 设置状态控件是否可用
        /// </summary>
        public void SetPatientStatusContrlReadOnly(bool readonlyable)
        {
            this.patientStatusContrl1.SetPatientStatusContrlReadOnly(readonlyable);

        }
        /// <summary>
        /// 设置背景图片
        /// </summary>
        /// <param name="picLogoImage"></param>
        /// <param name="picBackGroundImage"></param>
        /// <param name="picLbSelect"></param>
        /// <param name="picTopSpliter"></param>
        /// <param name="picPatientInfoLine"></param>
        public void SetBackGroundImage(Image picLogoImage, Image picBackGroundImage, Image picTopSpliterImage, Image picPatientInfoLine, Image picPersonIconImage, Image picPatientStatusContrlImage)
        { 
            picLogo.BackgroundImage = picLogoImage ;
            this.BackgroundImage = picBackGroundImage;
            panel1.BackgroundImage = picBackGroundImage;
            picPersonIcon.Image = picPersonIconImage;
            picTopSpliter.BackgroundImage =picTopSpliterImage ;
            

            lblPatInfoLine.Appearance.Image = picPatientInfoLine;

            patientStatusContrl1.BackgroundImage = picBackGroundImage;
            //patientStatusContrl1.SetBackground(picPatientStatusContrlImage);
            patientStatusContrl1.SetBackground(picBackGroundImage);
            panelRight.BackgroundImage = picBackGroundImage;
        }
        public void ShowLogButtom(bool show)
        {
            this.LogButton.Visible = show;
        }
        /// <summary>
        /// 设置状态灯图片
        /// </summary>
        public void SetStatusLightImage()
        {
            patientStatusContrl1.NormalImage = this.NormalImage;
            patientStatusContrl1.PassedImage = this.PassedImage;
            patientStatusContrl1.LightImage = this.LightImage;
        }
        /// <summary>
        /// 刷新 患者列表信息
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="patientID"></param>
        /// <param name="lblName"></param>
        public void RefreshPatientInfo(string roomNo, string patientID, string name)
        {
            lblRoomNo.Text = roomNo;
            lblPatientID.Text = patientID;
            lblName.Text = name;
            if (patientID != null && patientID.Trim().Length > 0)
            {
                lblPatInfoLine.Visible = true;
                picPersonIcon.Visible = true;
                lblRoomNo.Visible = true;
                lblPatientID.Visible = true;
                lblName.Visible = true;
            }
            else
            {
                lblPatInfoLine.Visible = false ;
                picPersonIcon.Visible = false;
                lblRoomNo.Visible = false;
                lblPatientID.Visible = false;
                lblName.Visible = false;
            }

           // this.Invalidate();
        }


        /// <summary>
        /// 生成状态按钮
        /// </summary>
        public void CreatePatientStatusButtons(string sPatientStatus)
        {
            patientStatusContrl1.CreatePatientStatusButtons(sPatientStatus);
        }


        private void TopBarControl_Load(object sender, EventArgs e)
        {
            patientStatusContrl1.Width = this.Width - (picTopSpliter.Left + picTopSpliter.Width + 2) - panelRight.Width;
            panelRight.Left = patientStatusContrl1.Right + 1;

            Resize += new EventHandler(TopBarControl_Resize);
            //注册服务项
            patientStatusContrl1.ServiceObject = this;
            patientStatusContrl1.RefreshPatientHandler += delegate
            {
                if (ExtendApplicationContext.Current.PatientInformation != null)
                {
                    #region Modify @2014-02-14  复苏程序的手术间号显示为复苏床位号
                    //RefreshPatientInfo((string)ExtendApplicationContext.Current.PatientInformation.OperRoom, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);
                    BusinessEntity.Dict.OperatingRoomDataTable dt = new DataAccess.DictDA().GetOperatingRoomDict();
                    BusinessEntity.Dict.OperatingRoomRow[] row = null;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        row = dt.Select(string.Format("PAT_ID='{0}' AND VISIT_ID={1} AND OPER_ID={2}", (string)ExtendApplicationContext.Current.PatientInformation.PatientID,
                            ExtendApplicationContext.Current.PatientInformation.VisitID, ExtendApplicationContext.Current.PatientInformation.OperID)) as BusinessEntity.Dict.OperatingRoomRow[];
                    }
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU && row != null && row.Length > 0)
                    {
                        RefreshPatientInfo(row[0].ROOM_NO, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);
                    }
                    else
                    {
                        RefreshPatientInfo((string)ExtendApplicationContext.Current.PatientInformation.OperRoom, (string)ExtendApplicationContext.Current.PatientInformation.PatientID, (string)ExtendApplicationContext.Current.PatientInformation.Name);
                    }
                    #endregion
                    
                }
            };
          
        }

        private void TopBarControl_Resize(object sender, EventArgs e)
        {
            patientStatusContrl1.Width = this.Width - picLogo.Width - panel1.Width - panelRight.Width - 5;//this.Width - (picTopSpliter.Left + picTopSpliter.Width + 2) - panelRight.Width - panel1.Width;
            panelRight.Left = patientStatusContrl1.Right - 1;
            this.mecicalDocBarControl1.DocButtonStartLeft = panel1.Left;
        }

        /// <summary>
        /// 返回PatientList事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelControl1_Click(object sender, EventArgs e)
        {
            ReturnPatientList();
        }
        /// <summary>
        ///  返回PatientList事件
        /// </summary>
        private void  ReturnPatientList()
        {
            if (MainFormRef != null)
            { 
                MainFormRef.ReturnPatientList();
            }
        }



        public void SetStatusLight(OperationStatus operationStatus)
        {
            this.patientStatusContrl1.SetStatusLight(operationStatus);
        }

        /// <summary>
        /// 显示各状态时间
        /// </summary>
        /// <param name="row"></param>
        /// <param name="operationStatus"></param>
        public void SetOperationStatusTimeText(OperationStatus operationStatus)
        {
            this.patientStatusContrl1.SetOperationStatusTimeText(operationStatus);
        }



        /// <summary>
        /// 设置手术状态,更新注重界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationStatusChange(OperationStatus operationStatus)
        {
            if (MainFormRef != null )
                MainFormRef.SetOperationStatus(operationStatus);

        }
                /// <summary>
        /// 设置手术状态,更新注重界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationTimeChange()
        {
            if (MainFormRef != null )
                MainFormRef.RefreshCurrentWorkControl();
        }

        /// <summary>
        /// 取消手术 病案提交
        /// </summary>
        /// <param name="operationStatus"></param>
        public void CancelOrCommitOperation(OperationStatus operationStatus, string cancelReason)
        {
            patientStatusContrl1.CancelOrCommitOperation(operationStatus, cancelReason);
        }

        private void lblPatientID_Click(object sender, EventArgs e)
        {
            ReturnPatientList();
        }
        /// <summary>
        /// 返回PatientList事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picPersonIcon_Click(object sender, EventArgs e)
        {
            ReturnPatientList();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            ReturnPatientList();
        }

        private void lblRoomNo_Click(object sender, EventArgs e)
        {
            ReturnPatientList();
        }

        private void TopBarControl_Click(object sender, EventArgs e)
        {
            LogButton.Focus();
        }

        private void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            RaiseRefreshEvent();
        }

    }

        
}
