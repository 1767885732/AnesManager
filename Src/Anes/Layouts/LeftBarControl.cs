using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Wis.Anes.Framework;
using Wis.Anes.ServiceProxies;
using Wis.Anes.Constants;
using DevExpress.XtraNavBar;
using Wis.Anes.FrameWork;
using Wis.Anes.Views;

namespace Wis.Anes.Layouts
{
    /// <summary>
    /// 主界面左边导航菜单
    /// </summary>
    [ToolboxItem(false)]
    public partial class LeftBarControl : UserControl
    {
        private ProgramStatus currentSystemStatus=ProgramStatus.NoPatient;
        private bool isFirst = true;
        public LeftBarControl()
        {
            InitializeComponent();  
        }
        /// <summary>
        /// 初始化导航菜单界面
        /// </summary>
        private void Initalize()
        {
            
        }

        /// <summary>
        /// 菜单项点击事件
        /// </summary>
        public EventHandler<ViewChangedEventArgs> ViewChangedEvent;
       /// <summary>
        /// 发起菜单命令事件
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
        /// 根据当前程序状态设定导航菜单按钮
        /// </summary>
        /// <param name="status"></param>
        public void SetCurrentViewNavigateButtons()
        {
            SetCurrentViewNavigateButtons(ExtendApplicationContext.Current.SystemStatus, ExtendApplicationContext.Current.StatusButtonStrList);
        }
        /// <summary>
        /// 根据当前程序状态设定导航菜单按钮
        /// </summary>
        /// <param name="status"></param>
        public void SetCurrentViewNavigateButtons(bool refresh)
        {
            SetCurrentViewNavigateButtons(ExtendApplicationContext.Current.SystemStatus, ExtendApplicationContext.Current.StatusButtonStrList, refresh);
        }
        public void SetCurrentViewNavigateButtons(ProgramStatus status, Dictionary<ProgramStatus, string> statusButtonStrList, bool refresh)
        {
            if (!refresh)
            {
                if (!isFirst && currentSystemStatus.Equals(status)) return;
                isFirst = false;
            }

            //清空现有Menu
            AnesMenuCollection.ClearMenu();

            currentSystemStatus = status;
            string[] buttonStrings = statusButtonStrList[currentSystemStatus].Split(new char[] { ';' }, StringSplitOptions.None);

            for (int i = 0; i < navBarControlLeft.Groups.Count; i++)
            {
                //Menu相关
                ApplicationFramework.Model.Menu menu = new ApplicationFramework.Model.Menu();
                menu.MenuName = navBarControlLeft.Groups[i].Caption;

                navBarControlLeft.Groups[i].Visible = false;
                navBarControlLeft.Groups[i].Expanded = false;
                if (navBarControlLeft.Groups[i].ControlContainer.Controls.Count > 0)
                {
                    navBarControlLeft.Groups[i].ControlContainer.Controls.Clear();
                }
                navBarControlLeft.Groups[i].ControlContainer.Height = 0;
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (navBarControlLeft.Groups[i].Caption.Contains("大事件") && (!Framework.AccessControl.CheckBrowseRight("大事件") || !Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))) continue;
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if (navBarControlLeft.Groups[i].Caption.Contains("大事件") && (!Framework.AccessControl.CheckBrowseRight("大事件"))) continue;
                }
                if (!string.IsNullOrEmpty(buttonStrings[i]))
                {
                    string[] groupButtons = buttonStrings[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string text in groupButtons)
                    {
                        string btnText = text;
                        if (btnText.Contains("\t")) btnText = btnText.Replace("\t", "");

                        string key = btnText;
                        while (key.Contains(" "))
                        {
                            key = key.Replace(" ", "");
                        }
                        if ((i > 0) && !Framework.AccessControl.CheckBrowseRight(key))
                        {
                            continue;
                        }
                        if (key.Equals(ViewNames.LockPatient) && ExtendApplicationContext.Current.OperationStatus.Equals(OperationStatus.Done))
                        {
                            continue;
                        }
                        SimpleButton button = new SimpleButton();
                        if (i == 0)
                        {
                            button.Click += new EventHandler(NavButtonClick1);
                        }
                        else
                        {
                            button.Click += new EventHandler(NavButtonClick);
                        }
                        button.Text = text;
                        button.Cursor = Cursors.Hand;
                        navBarControlLeft.Groups[i].ControlContainer.Controls.Add(button);
                        button.Width = 65;
                        if ((navBarControlLeft.Groups[i].ControlContainer.Controls.Count % 2) == 1)
                        {
                            if (navBarControlLeft.Groups[i].ControlContainer.Height < button.Height)
                            {
                                button.Top = 5;
                            }
                            else
                            {
                                button.Top = navBarControlLeft.Groups[i].ControlContainer.Height;
                            }
                            button.Left = 2;
                            navBarControlLeft.Groups[i].ControlContainer.Height = button.Bottom + 5;
                        }
                        else
                        {
                            button.Top = navBarControlLeft.Groups[i].ControlContainer.Height - button.Height - 5;
                            button.Left = button.Width + 10;
                        }

                        //SubMenu相关
                        ApplicationFramework.Model.Menu subMenu = new ApplicationFramework.Model.Menu();
                        subMenu.MenuName = text;
                        menu.AddMenu(text, typeof(FloatFrm).AssemblyQualifiedName);                        
                    }
                    navBarControlLeft.Groups[i].Expanded = true;
                }
                //将Menu添加到Collection
                AnesMenuCollection.AddToNurseMenuCollection(menu);
                AnesMenuCollection.SetNurseMenuCollectionFirstView();
            }
            foreach (DevExpress.XtraNavBar.NavBarGroup group in navBarControlLeft.Groups)
            {
                if (group.ControlContainer.Controls.Count == 0 && group.Visible == true)
                {
                    group.Visible = false;
                }
                else if (group.ControlContainer.Controls.Count > 0)
                {
                    group.Visible = true;
                }
            }
        }
        public void SetCurrentViewNavigateButtons(ProgramStatus status, Dictionary<ProgramStatus, string> statusButtonStrList)
        {
            if (!isFirst && currentSystemStatus.Equals(status)) return;
            isFirst = false;
            currentSystemStatus = status;
            string[] buttonStrings = statusButtonStrList[currentSystemStatus].Split(new char[] { ';' }, StringSplitOptions.None);

            //清空现有Menu
            AnesMenuCollection.ClearMenu();

            for (int i = 0; i < navBarControlLeft.Groups.Count; i++)
            {
                //Menu相关
                ApplicationFramework.Model.Menu menu = new ApplicationFramework.Model.Menu();
                menu.MenuName = navBarControlLeft.Groups[i].Caption;

                navBarControlLeft.Groups[i].Visible = false;
                navBarControlLeft.Groups[i].Expanded = false;
                if (navBarControlLeft.Groups[i].ControlContainer.Controls.Count > 0)
                {
                    navBarControlLeft.Groups[i].ControlContainer.Controls.Clear();
                }
                navBarControlLeft.Groups[i].ControlContainer.Height = 0;
                if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                {
                    if (navBarControlLeft.Groups[i].Caption.Contains("大事件") && (!Framework.AccessControl.CheckBrowseRight("大事件") || !Framework.AccessControl.CheckModifyRightForOperator("麻醉单"))) continue;
                }
                else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                {
                    if (navBarControlLeft.Groups[i].Caption.Contains("大事件") && (!Framework.AccessControl.CheckBrowseRight("大事件"))) continue;
                }
                if (!string.IsNullOrEmpty(buttonStrings[i]))
                {
                    string[] groupButtons = buttonStrings[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string text in groupButtons)
                    {
                        string btnText = text;
                        if (btnText.Contains("\t")) btnText = btnText.Replace("\t", "");

                        string key = btnText;
                        while (key.Contains(" "))
                        {
                            key = key.Replace(" ", "");
                        }
                        if ((i>0)&&!Framework.AccessControl.CheckBrowseRight(key))
                        {
                            continue;
                        }
                        if (key.Equals(ViewNames.LockPatient) && ExtendApplicationContext.Current.OperationStatus.Equals(OperationStatus.Done))
                        {
                            continue;
                        }
                        SimpleButton button = new SimpleButton();
                        if (i == 0)
                        {
                            button.Click += new EventHandler(NavButtonClick1);
                        }
                        else
                        {
                            button.Click += new EventHandler(NavButtonClick);
                        }
                        button.Text = text;
                        button.Cursor = Cursors.Hand;
                        navBarControlLeft.Groups[i].ControlContainer.Controls.Add(button);
                        button.Width = 65;
                        if ((navBarControlLeft.Groups[i].ControlContainer.Controls.Count % 2) == 1)
                        {
                            if (navBarControlLeft.Groups[i].ControlContainer.Height < button.Height)
                            {
                                button.Top = 5;
                            }
                            else
                            {
                                button.Top = navBarControlLeft.Groups[i].ControlContainer.Height;
                            }
                            button.Left = 2;
                            navBarControlLeft.Groups[i].ControlContainer.Height = button.Bottom + 5;
                        }
                        else
                        {
                            button.Top = navBarControlLeft.Groups[i].ControlContainer.Height - button.Height - 5;
                            button.Left = button.Width + 10;
                        }

                        //SubMenu相关
                        ApplicationFramework.Model.Menu subMenu = new ApplicationFramework.Model.Menu();
                        subMenu.MenuName = text;
                        menu.AddMenu(text, typeof(FloatFrm).AssemblyQualifiedName);                        
                    }
                    navBarControlLeft.Groups[i].Expanded = true;
                }
                //将Menu添加到Collection
                AnesMenuCollection.AddToNurseMenuCollection(menu);
                AnesMenuCollection.SetNurseMenuCollectionFirstView();
            }
            foreach (DevExpress.XtraNavBar.NavBarGroup group in navBarControlLeft.Groups)
            {
                if (group.ControlContainer.Controls.Count == 0 && group.Visible == true)
                {
                    group.Visible = false;
                }
                else if (group.ControlContainer.Controls.Count > 0)
                {
                    group.Visible = true;
                }
            }            
        }

        public void SetLockPatBtn()
        {
            foreach (NavBarGroup group in navBarControlLeft.Groups)
            {
                if (group.Caption.Equals("患者操作"))
                {
                    foreach (Control ctr in group.ControlContainer.Controls)
                    {
                        if ((ctr is SimpleButton) && ((ctr as SimpleButton).Text.Trim().Equals("病案提交") || (ctr as SimpleButton).Text.Trim().Equals("病案归档")))
                        {
                            ctr.Visible = !ExtendApplicationContext.Current.OperationStatus.Equals(OperationStatus.Done);
                        }
                    }
                }
            }
        }

        private void LeftBarControl_Load(object sender, EventArgs e)
        {

        }

        private void NavButtonClick(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Text;
            while (key.Contains(" "))
            {
                key = key.Replace(" ", "");
            }
            if (!string.IsNullOrEmpty(key))
            {
                RaiseEvent(key);
            }
        }
        /// <summary>
        /// 大事件飘窗按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavButtonClick1(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Text;
            while (key.Contains(" "))
            {
                key = key.Replace(" ", "");
            }
            if (!string.IsNullOrEmpty(key))
            {
                RaiseEvent("飘窗@"+key);
            }
        }
    }
    
}
