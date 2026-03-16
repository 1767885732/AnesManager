using ApplicationFramework;
using ApplicationFramework.Model;
using App = ApplicationFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTab;
using System.Drawing;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.CostomDoc;
using Wis.Anes.Framework.Documents;

namespace Wis.Anes.FrameWork
{
    public class CommonViewBuilder : IViewBuilder
    {
        #region IMenuViewBuilder 成员

        bool isNewCreatPage = false;
        public Control BuildViewControl(App.Menu menu)
        {
            if (menu == null || menu.IsCommand)
                return null;
            TabPage tabPage = FindTabPageByMenu(menu);
            if (tabPage == null)
            {
                isNewCreatPage = true;
                BaseControl ctl;
                //TODO 根据权限，1 Module 是否只读？ 2， Module中是否有Control资源，并且该资源的操作是如何的。
                if (string.IsNullOrEmpty(menu.Args))
                {
                    ctl = menu.Load(ApplicationManager.CurrentPatient) as BaseControl;
                    if (!string.IsNullOrEmpty(menu.LoadResoucesPath))
                    {
                        if (ctl is BaseDoc)
                        {
                            ((BaseDoc)ctl).Tag = menu.LoadResoucesPath;
                        }
                        else if (ctl is CustomAssessmentBase)
                        {
                            ((CustomAssessmentBase)ctl).Tag = menu.LoadResoucesPath;
                        }
                        else if (ctl is CustomCommonBase)
                        {
                            ((CustomCommonBase)ctl).Tag = menu.LoadResoucesPath;
                        }
                    }
                }
                else
                {
                    string[] args = menu.Args.Split(',');
                    List<object> obj = new List<object>();
                    obj.Add(ApplicationManager.CurrentPatient);
                    foreach (string str in args)
                    {
                        obj.Add(str);
                    }
                    //ctl = menu.Load(ApplicationManager.CurrentPatient, menu.Args) as BaseControl;
                    ctl = menu.Load(obj.ToArray()) as BaseControl;
                }
                tabPage = CreatePage(ctl, menu);
                if (AnesMenuCollection.NavBarContainer != null)
                {                    
                    //if (menu.Parent.SubMenus.Length <= 1)
                    //((HorizontalNavBar)ICUMenuCollection.NavBarContainer).Shrink();
                    //else
                    //((HorizontalNavBar)ICUMenuCollection.NavBarContainer).Expand();
                }
            }
            else
            {
                isNewCreatPage = false;
            }

            return tabPage;
        }

        bool isManual = true;
 
        public void ShowViewControl(Control viewControl, Control viewContainer)
        {
            TabPage tabPage = viewControl as TabPage;
            CommonTabControl tabPageContainer = viewContainer as CommonTabControl;
            if (tabPage == null || tabPageContainer == null)
                return;
            if (!tabPageContainer.TabPages.Contains(tabPage))
                tabPageContainer.TabPages.Add(tabPage);
            if (tabPageContainer.Tag == null)
            {
                isManual = false;
            }

            tabPageContainer.SelectedTab = tabPage;

            //FirstForViewMenu加载时，手动切换二级菜单选中项
            ApplicationFramework.Model.Menu menu = tabPage.Tag as ApplicationFramework.Model.Menu;
            if (menu != null && menu == AnesMenuCollection.CurrentMenuCollection.FirstForView)
            {
                SwitchCurrentMenu(tabPage.Tag as ApplicationFramework.Model.Menu);
            }            

            BindSelectedPageChangedAndCloseButtonClickEventsIfNecessary(tabPageContainer);
        }

        public IView CalcuateCurrentView(Control viewControl)
        {
            TabPage tabPage = viewControl as TabPage;
            if (tabPage == null || tabPage.Controls.Count == 0 || !(tabPage.Controls[0] is IView))
                return null;
            return tabPage.Controls[0] as IView;
        }

        private void BindSelectedPageChangedAndCloseButtonClickEventsIfNecessary(CommonTabControl tabPageContainer)
        {
            //Tag有值表示已经绑定过事件了
            if (tabPageContainer.Tag == null)
            {
                tabPageContainer.CloseButtonClick += CloseButtonClick;
                tabPageContainer.SelectedPageChanged += SelectedPageChanged;
                tabPageContainer.Tag = tabPageContainer;
            }
        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageEventArgs closeEvent = e as ClosePageEventArgs;
            CommonTabControl tabPageContainer = sender as CommonTabControl;
            if (closeEvent.PrevPage == null)
            {
                if (tabPageContainer.TabPages.Count > 1 &&
                    Sundries.MessageBox("是否关闭所有标签页?", Sundries.CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = tabPageContainer.TabPages.Count - 1; i >= 0; i--)//wwj 关闭所有的时候留最后一个，不然丑  　　BUG31  ICU产品测试错误描述20140528——合并.doc
                    {
                        BaseControl bctl = tabPageContainer.TabPages[i].Controls[0] as BaseControl;
                        if (bctl != null)
                        {
                            bctl.CheckHasDataChangedThenSaveData();
                        }
                        tabPageContainer.TabPages[i].Dispose();
                    }
                    tabPageContainer.TabPages.Clear();
                }
                else
                {
                    return;
                }
            }
            else
            {
                TabPage tabPage = closeEvent.Page as TabPage;
                if (tabPage.Controls.Count > 0)
                {
                    BaseControl bCtl = (tabPage.Controls[0] as BaseControl);
                    bCtl.CheckHasDataChangedThenSaveData();
                }
                tabPageContainer.TabPages.Remove(tabPage);
                tabPage.Dispose();
            }
            GC.Collect();

            if (tabPageContainer.TabPages.Count == 0)
            {
                ApplicationManager.CurrentMenu = null;
                HorizontalNavBar navBar = ApplicationManager.CurrentSubMenuContainer as HorizontalNavBar;
                //navBar.ClearItems();
                //初始化子菜单项状态
                navBar.SetItemsUnSelected();
            }
            //关闭标签页后，默认选中第一个标签页
            //else
            //{
            //    tabPageContainer.SelectedIndex = tabPageContainer.TabPages.Count - 1;
            //}
        }

        void SelectedPageChanged(object sender, CommonTabPageChangedEventArgs e)
        {

            if (e.Page != null && isManual)
            {
                IView v = CalcuateCurrentView(e.Page) as IView;
                if (v != null)
                    v.Notify(false);
                ApplicationManager.CurrentBaseControl = v as BaseControl;
                ApplicationFramework.Model.Menu selectMenu = SelectMenuChecked(ApplicationManager.CurrentBaseControl);
                if (selectMenu.IsForceNotify && !isNewCreatPage)
                {
                    v.Notify(true);
                }
                isNewCreatPage = false;
                if (AnesMenuCollection.NavBarContainer != null)
                {
                    SwitchCurrentMenu(selectMenu);
                    //selectMenu.Parent.
                    //if (selectMenu.Parent.SubMenus.Length <= 1)
                    //    ((HorizontalNavBar)ICUMenuCollection.NavBarContainer).Shrink();                        
                    //else
                    //    ((HorizontalNavBar)ICUMenuCollection.NavBarContainer).Expand();
                }
            }

            if (!isManual)
                isManual = true;
        }

        ApplicationFramework.Model.Menu SelectMenuChecked(BaseControl v)
        {
            MenuCollection menuCollection = AnesMenuCollection.CurrentMenuCollection;
            ApplicationFramework.Model.Menu selectMenu = null;
            ApplicationFramework.Model.Menu pareMenu = null;
            for (int i = 0; i < menuCollection.Count; i++)
            {
                if (selectMenu != null)
                {
                    break;
                }

                if (menuCollection[i].IsParent)
                {
                    foreach (ApplicationFramework.Model.Menu menu in menuCollection[i].SubMenus)
                    {
                        if (menu.ModuleType == v.GetType().AssemblyQualifiedName &&
                            (menu.MenuName == v.Title || (!v.GetType().AssemblyQualifiedName.Contains("ChoiceItemEnterFrm") &&
                            !v.GetType().AssemblyQualifiedName.Contains("OperationControl"))))
                        //if (menu.ModuleType == v.GetType().AssemblyQualifiedName && menu.MenuName == v.Title)
                        {
                            if (menu.ModuleType.ToString() == "ICIS.IcuDevekopPlugIn.IcuDevelopPlugIn.AssessmentBaseControl, PublicCommPlugIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                            {
                                if (menu.MenuName != v.Title)
                                {
                                    continue;
                                }
                            }
                            if (menu.Parent != null && menu.Parent.MenuName == "常用功能")
                            {
                                continue;
                            }
                            if (!string.IsNullOrEmpty(menu.LoadResoucesPath) && v.Tag != null)
                            {
                                if (menu.LoadResoucesPath == v.Tag.ToString())
                                {
                                    selectMenu = menu;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            selectMenu = menu;
                            break;
                        }
                    }
                }
                else
                {
                    if (menuCollection[i].ModuleType != null && menuCollection[i].ModuleType == v.GetType().AssemblyQualifiedName)
                    {
                        selectMenu = menuCollection[i];
                        break;
                    }
                }
            }
            if (selectMenu != null && selectMenu.Parent != null)
            {
                pareMenu = selectMenu.Parent;
            }
            else
            {
                pareMenu = selectMenu;
            }
            
            FlowLayoutPanel bar = ApplicationManager.CurrentMenuContainer as FlowLayoutPanel;            
            foreach (IcuMenuButton barItem in bar.Controls)
            {                
                if (barItem == null)
                {
                    continue;
                }
                //if (barItem.Caption.Trim() != "" && pareMenu.MenuName.Contains(barItem.Caption))
                //{
                //    barBtnItem.ButtonStyle = BarButtonStyle.Check;
                //    barBtnItem.Down = true;
                //    barBtnItem.Appearance.ForeColor = Color.Black;
                //}
                //else if (barBtnItem.Down == true)
                //{
                //    barBtnItem.ButtonStyle = BarButtonStyle.Default;
                //    barBtnItem.Down = false;
                //    barBtnItem.Appearance.ForeColor = Color.White;
                //}
            }
            if (!pareMenu.IsLeaf)
            {
                HorizontalNavBar navBar = ApplicationManager.CurrentSubMenuContainer as HorizontalNavBar;
                navBar.ClearItems();
                if (navBar.Tag == null)
                {
                    navBar.ItemClick += new ItemClickEvent(navBar_ItemClick);
                    navBar.Tag = this;
                }
                NavBarItemList list = new NavBarItemList(navBar);
                int index = 0, selectIndex = 0;
                foreach (ApplicationFramework.Model.Menu menu in pareMenu.SubMenus)
                {
                    MedNavBarItem item = new MedNavBarItem(menu.MenuName, menu.GetModuleType());
                    item.Tag = menu;
                    list.Add(item);
                    if (selectMenu == menu)
                    {
                        selectIndex = index;
                    }
                    index++;
                }
                navBar.AddItems(list);
                navBar.SetLabelChecked(selectIndex);
                //navBar.ExpandBar();
            }
            else
            {
                HorizontalNavBar navBar2 = ApplicationManager.CurrentSubMenuContainer as HorizontalNavBar;
                //navBar2.ShrinkBar();
            }
            return selectMenu;
        }

        void navBar_ItemClick(object sender, MedNavBarItem clickItem)
        {
            ApplicationFramework.Model.Menu menu = clickItem.Tag as ApplicationFramework.Model.Menu;
            //if (menu != null)
                //ApplicationManager.ActivateMenu(menu);
        }

        static TabPage FindTabPageByMenu(App.Menu menu)
        {

            CommonTabControl tabPageContainer = ApplicationManager.CurrentViewContainer as CommonTabControl;
            foreach (TabPage tabPage in tabPageContainer.TabPages)
            {
                if (tabPage.Tag == menu)
                {
                    return tabPage;
                }
            }
            return null;
        }

        static TabPage CreatePage(BaseControl control, App.Menu menu)
        {
            if (control == null)
                return null;
            control.Dock = DockStyle.Fill;
            TabPage tabPage = new TabPage();
            tabPage.Tag = menu;
            tabPage.Text = menu.MenuName;
            tabPage.BackColor = Color.FromArgb(244, 244, 244);
            tabPage.Controls.Add(control);
            return tabPage;
        }
        #endregion

        /// <summary>
        /// 手动切换菜单
        /// </summary>
        /// <param name="currentMenu"></param>
        private void SwitchCurrentMenu(ApplicationFramework.Model.Menu currentMenu)
        {
            if (currentMenu == null)
            {
                return;
            }

            //获取当前ViewBuilder
            MenuCollection menuCollection = AnesMenuCollection.CurrentMenuCollection;
            CommonMenuBuilder currentMenuBuilder = menuCollection.MenuBuilder as CommonMenuBuilder;
            if (currentMenuBuilder == null)
            {
                return;
            }

            if (currentMenu.IsLeaf)
            {
                //切换到子菜单对应父菜单
                ApplicationFramework.Model.Menu parent = currentMenu.Parent;                
                currentMenuBuilder.CurrentBarItem = parent.Tag as IcuMenuButton;

                //设置对应子菜单项为选中状态
                if (currentMenuBuilder.CurrentBarItem != null)
                {
                    //构建二级菜单
                    //ApplicationManager.ActivateMenu(parent);
                    HorizontalNavBar navSubBar = ApplicationManager.CurrentSubMenuContainer as HorizontalNavBar;
                    if (navSubBar != null)
                    {
                        //找到当前子菜单项序号和对应的子菜单控件，并选中
                        for (int i = 0; i < parent.SubMenus.Count(); i++)
                        {
                            if (parent.SubMenus[i].MenuName == currentMenu.MenuName)
                            {
                                CommonLabel currentLabel = navSubBar.Controls[0].Controls[i+1] as CommonLabel;
                                if (currentLabel != null)
                                {
                                    currentLabel.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            else if (currentMenu.IsParent)
            {
                //直接切换到对应菜单
                currentMenuBuilder.CurrentBarItem = currentMenu.Tag as IcuMenuButton;
            }
            else
            {
                return;
            }
        }
    }
}
