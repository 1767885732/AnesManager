/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：WorkSpaceControl.cs
// 文件功能描述：WorkSpaceControl
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
using DevExpress.XtraTab;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Documents;
using Wis.Anes.Framework;
using  Wis.Anes.Views.Patient;

using DevExpress.XtraBars.Docking;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Views;

namespace Wis.Anes.Layouts
{
    /// <summary>
    /// 界面主要工作区域
    /// </summary>
    [ToolboxItem(false)]
    public partial class WorkSpaceControl : UserControl
    {
        PatientListView _patientView = null;
        public OperationRoomPandect operationRoomPandect = new OperationRoomPandect();
        public WorkSpaceControl()
        {
    
                InitializeComponent();
                this.BackColor = Color.White;
                this.dockPanel1.MouseLeave += new EventHandler(dockPanel1_MouseLeave);
            
        }

        public void Initial(PatientListView view)
        {
            hideContainerLeft.Visible = false;
            _patientView = view;

            operationRoomPandect = new OperationRoomPandect();
            operationRoomPandect.OrginWidth = 205;
            operationRoomPandect.NeedAlarm = false;
            
            operationRoomPandect.Dock = DockStyle.Fill;
            dockPanel1_Container.Controls.Add(operationRoomPandect);
        }

        public void AddPatientView()
        {
            dockPanel1.Visibility = DockVisibility.AutoHide;
            
            hideContainerLeft.Visible = false;
            //dockManager1.AutoHideContainers.Clear();
            Application.DoEvents();
            AddViewToWorkSpace(_patientView, "PatientListView");
        }

        /// <summary>
        /// 
        /// 在主界面中打开View
        /// </summary>
        /// <param name="view"></param>
        public void AddViewToWorkSpace(BaseView view,string viewName)
        {
            view.Name = viewName;
            view.Dock = DockStyle.Fill;

            //while (Controls.Count > 1)
            //{
            //    if (Controls[0] is AutoHideContainer)
            //        Controls.RemoveAt(1);
            //    else
            //        Controls.RemoveAt(0);
            //}

            panelControlContainter.Controls.Clear();

            panelControlContainter.Controls.Add(view);
            //如果为竖屏
            if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
            {
                this.Padding = new Padding(0, 0, 0, 0);

            }
            RaiseEvent(viewName);
        }
        /// <summary>
        /// 添加医疗文书
        /// </summary>
        /// <param name="baseDoc"></param>
        public void AddDocToWorkSpace(BaseDoc baseDoc)
        {
            if (!hideContainerLeft.Visible)
            {
                hideContainerLeft.Dock = DockStyle.Left;
                hideContainerLeft.Visible = true;
                operationRoomPandect.RefreshSelect();

                //dockManager1.AutoHideContainers.AddRange(new AutoHideContainer[] { hideContainerLeft });
                //dockPanel1_Container.Controls.Add(_patientView);
            }

            //while (Controls.Count > 1)
            //{
            //    if (Controls[0] is AutoHideContainer)
            //        Controls.RemoveAt(1);
            //    else
            //        Controls.RemoveAt(0);
            //}

            panelControlContainter.Controls.Clear();

            if (baseDoc != null)
            {
                
                baseDoc.Dock = DockStyle.Fill;
                panelControlContainter.Controls.Add(baseDoc);
                ////如果为竖屏
                //if (Screen.PrimaryScreen.Bounds.Width < Screen.PrimaryScreen.Bounds.Height)
                //{
                //    this.Padding = new Padding(50, 0, 0, 0);

                //}
                
                RaiseEvent("");
               
                Application.DoEvents();
                //dockPanel1.HideImmediately();
                //baseDoc.Focus();
                
            }
        }
        
        /// <summary>
        /// 界面切换事件
        /// </summary>
        public EventHandler<ViewChangedEventArgs> ViewChangedEvent;
        /// <summary>
        /// 发起界面切换事件
        /// </summary>
        /// <param name="viewName">界面名称</param>
        /// <param name="viewType">界面类型名称</param>
        /// <param name="isShowDialog">是否以模式窗口显示</param>
        public void RaiseEvent(string viewName)
        {
            if (ViewChangedEvent != null)
                ViewChangedEvent(this, new ViewChangedEventArgs(viewName));
        }
        
        /// <summary>
        /// 根据ViewId尝试从现有界面中打开View,并强制刷新数据
        /// </summary>
        /// <param name="viewId"></param>
        /// <returns></returns>
        public bool TryOpenExistedView(string viewName)
        {

            return false;
        }
        /// <summary>
        /// 模式显示窗体
        /// </summary>
        /// <param name="view"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public DialogResult ShowViewDialog(BaseView view, int width, int height)
        {
            DialogHostForm dialogHostForm = new DialogHostForm(view.Caption, width, height);
            dialogHostForm.Child = view;
            return  dialogHostForm.ShowDialog();
        }
        /// <summary>
        /// 模式显示窗体
        /// </summary>
        /// <param name="view"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public DialogResult ShowViewDialog(BaseView view, int width, int height, int left,int top)
        {
            DialogHostForm dialogHostForm = new DialogHostForm(view.Caption, width, height);
            dialogHostForm.StartPosition = FormStartPosition.Manual;
            dialogHostForm.Child = view;
            dialogHostForm.Left = left;
            dialogHostForm.Top = top;
            
            return dialogHostForm.ShowDialog();
        }
        /// <summary>
        /// 模式最大化显示窗体
        /// </summary>
        /// <param name="view"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public DialogResult ShowViewDialog(BaseView view, bool isMaximized)
        {
            DialogHostForm dialogHostForm = new DialogHostForm(view.Caption, isMaximized);
            dialogHostForm.Child = view;
            return dialogHostForm.ShowDialog();
        }
        public DialogResult ShowViewDialog2(BaseView view, bool isMaximized)
        {
            DialogHostForm dialogHostForm = new DialogHostForm(view.Caption, false);
            dialogHostForm.Child = view;
            dialogHostForm.MaximizeBox = false;
            dialogHostForm.Height = Screen.PrimaryScreen.WorkingArea.Height - 80; ;
            dialogHostForm.Width = Screen.PrimaryScreen.WorkingArea.Width-80;
            dialogHostForm.StartPosition = FormStartPosition.CenterScreen;
            dialogHostForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            return dialogHostForm.ShowDialog();
        }
        /// <summary>.
        /// 关闭当前界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HostTabControl_CloseButtonClick(object sender, EventArgs e)
        {

               
        }
        /// <summary>
        /// 清空,并释放所有界面资源
        /// </summary>
        public void Clear()
        {
            //foreach (XtraTabPage childPage in this.HostTabControl.TabPages)
            //{
            //    foreach(Control childControl in childPage.Controls)
            //    {
            //        childControl.Dispose();
            //    }
            //}
            //this.HostTabControl.TabPages.Clear();
        }

        private void WorkSpaceControl_Load(object sender, EventArgs e)
        {
           
        }

        private void dockPanel1_MouseLeave(object sender, EventArgs e)
        {
            CurrentControl.Focus();
        }
        

        public Control CurrentControl
        {
            get
            {
                if (panelControlContainter.Controls.Count > 0)
                    return panelControlContainter.Controls[0];
                else
                    return this;
           }
        }
    }
}
