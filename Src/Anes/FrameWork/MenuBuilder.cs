using System;
using ApplicationFramework;
using ApplicationFramework.Model;
using DevExpress.XtraBars;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using App = ApplicationFramework.Model;
using DevExpress.XtraTab;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework.Controls;

namespace Wis.Anes.FrameWork
{
    class MenuBuilder : IMenuBuilder
    {

        BarButtonItem currentBarItem;
        public BarButtonItem CurrentBarItem
        {
            get { return currentBarItem; }
            set
            {
                OnCurrentItemChanged(value);
            }
        }

        void OnCurrentItemChanged(BarButtonItem barItem)
        {
            //if (currentBarItem != null)
            //{
            //    currentBarItem.ButtonStyle = BarButtonStyle.Default;
            //    currentBarItem.Down = false;
            //    currentBarItem.Appearance.ForeColor = Color.White;
            //}
            DevExpress.XtraBars.Bar bar = ApplicationManager.CurrentMenuContainer as DevExpress.XtraBars.Bar;
            foreach (DevExpress.XtraBars.BarItem singleBarItem in bar.Manager.Items)
            {
                BarButtonItem barBtnItem = singleBarItem as BarButtonItem;
                if (barBtnItem == null || !barBtnItem.Down)
                {
                    continue;
                }
                barBtnItem.ButtonStyle = BarButtonStyle.Default;
                barBtnItem.Down = false;
                barBtnItem.Appearance.ForeColor = Color.White;
            }

            currentBarItem = barItem;
            currentBarItem.ButtonStyle = BarButtonStyle.Check;
            currentBarItem.Down = true;
            currentBarItem.Appearance.ForeColor = Color.Black;
        }

        public MenuBuilder()
        {
        }

        public void BuildMenus(object menuContainer, MenuCollection menuCollection)
        {
            DevExpress.XtraBars.Bar bar = menuContainer as DevExpress.XtraBars.Bar;
            if (bar == null)
                return;
            bar.BarItemVertIndent = 7;
            bar.BarItemHorzIndent = 6;
            AddBlankItem(bar);
            foreach (App.Menu menu in menuCollection)
            {
                if (MedConfiguration.CheckPermissionByName(menu.MenuName))
                {
                    BarButtonItem barItem = AddBarButtonItem(bar, menu);
                    if (menuCollection.FirstForView == menu)
                    {
                        CurrentBarItem = barItem;
                    }
                }
            }
        }

        BarStaticItem AddBlankItem(DevExpress.XtraBars.Bar bar)
        {
            BarStaticItem blank = new BarStaticItem();
            blank.Caption = "                                      ";
            blank.TextAlignment = System.Drawing.StringAlignment.Near;
            blank.Name = "blank";
            bar.Manager.Items.Add(blank);
            bar.AddItem(blank);
            return blank;
        }

        BarButtonItem AddBarButtonItem(DevExpress.XtraBars.Bar bar, App.Menu menu)
        {
            BarButtonItem btnItem = new BarButtonItem(bar.Manager, menu.MenuName);
            btnItem.Tag = menu;
            menu.Tag = btnItem;
            btnItem.Caption = GetMenuName(menu.MenuName.Trim());
            btnItem.Appearance.ForeColor = Color.White;
            btnItem.Appearance.Font = new Font("微软雅黑",9F, FontStyle.Bold);
            btnItem.Appearance.Options.UseForeColor = true;
            btnItem.ItemClick += btnItem_ItemClick;
            btnItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            if (btnItem.Glyph == null)
                btnItem.Glyph = GetToolBarImage(btnItem.Caption);
            bar.AddItem(btnItem);
            //bar.LinksPersistInfo.Add(new LinkPersistInfo(BarLinkUserDefines.PaintStyle, btnItem, BarItemPaintStyle.CaptionGlyph));
            return btnItem;
        }

        string GetMenuName(string name)
        {
            int index = name.IndexOf('(');
            if (index == -1)
            {
                return name;
            }
            else
            {
                return name.Substring(0, index);
            }
        }

        Image GetToolBarImage(string name)
        {
            switch (name)
            {
                case "患者信息":                
                    return Skin.Skin.GetPatientInfo();
                case "床位管理":
                    return Skin.Skin.GetBedManage();
                case "医嘱处理":
                case "诊治分析":
                case "ICU信息库":
                    return Skin.Skin.GetOrderExecute();
                case "整体护理":
                    return Skin.Skin.GetTotalCare();
                case "护理文书":
                case "病案查询":
                    return Skin.Skin.GetCareDoc();
                case "电子病历":
                case "护理计划":   
                    return Skin.Skin.GetElectronicRecords();
                case "统计查询":
                case "查询统计":
                    return Skin.Skin.GetStatistics();
                case "科室维护":
                case "科室管理":
                    return Skin.Skin.GetDeptManage();
                case "系统配置":
                    return Skin.Skin.GetConfig();
                case "同步患者":
                    return Skin.Skin.GetSysPatient();
                case "切换科室":
                    return Skin.Skin.ChangeWard();
                case "锁定系统":
                    return Skin.Skin.GetLockScreen();
                case "数据分析":
                case "病情总览":
                    return Skin.Skin.GetDataAnalysis();
                case "床头卡信息":
                case "床位概览":
                    return Skin.Skin.GetDataAnalysis();
                case "感染管理":
                case "导管护理":
                    return Skin.Skin.GetInfectionManage();
                case "患者数据":
                case "疗效分析":
                    return Skin.Skin.GetPatientData();
                case "重症评分":
                    return Skin.Skin.GetScore();
                case "护理评估":
                case "检查列表":
                case "质控统计":
                    return Skin.Skin.GetNurseScore();
                case "常用功能":
                    return Skin.Skin.GetCommFunc();
                case "文档管理":
                case "知识库":
                    return Skin.Skin.GetDocManage();
                default:
                    break;
            }
            return null;
        }

        void btnItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            App.Menu menu = e.Item.Tag as App.Menu;
            //if (currentBarItem == e.Item)
            //    return;
            //ApplicationManager.ActivateMenu(menu);
            if (!menu.IsCommand)
                CurrentBarItem = e.Item as BarButtonItem;

            if (menu.IsLeaf == true && !menu.IsCommand)
            {
                NavBar navBar = ApplicationManager.CurrentSubMenuContainer as NavBar;
                //navBar.ShrinkBar();
                return;
            }

            //模拟按下界面按钮
            bool bFind = false;
            int nFindIndex = 0;
            for (int i = ((XtraTabControl)ApplicationManager.CurrentViewContainer).TabPages.Count - 1; i >= 0; i--)
            {
                XtraTabPage tabPage = ((XtraTabControl)ApplicationManager.CurrentViewContainer).TabPages[i];
                for (int j = 0; j < menu.SubMenus.Length; j++)
                {
                    if (tabPage.Tag == menu.SubMenus[j])
                    {
                        bFind = true;
                        nFindIndex = j;
                        break;
                    }
                }
                if (bFind)
                {
                    break;
                }
            }

            NavBar navSubBar = ApplicationManager.CurrentSubMenuContainer as NavBar;
            if (navSubBar.ItemList.Count > 0)
            {
                navSubBar.FireClickNavBarItem(navSubBar.ItemList[nFindIndex]);
            }
        }


        public void BuildSubMenus(object subMenuContainer, ApplicationFramework.Model.Menu[] subMenus, ApplicationFramework.Model.Menu parentMenu)
        {
            NavBar navBar = subMenuContainer as NavBar;

            navBar.ClearItems();
            if (navBar.Tag == null)
            {
                navBar.ItemClick += new ItemClickEvent(navBar_ItemClick);
                navBar.Tag = this;
            }
            NavBarItemList list = new NavBarItemList(navBar);
            foreach (ApplicationFramework.Model.Menu menu in subMenus)
            {
                MedNavBarItem item = new MedNavBarItem(menu.MenuName, menu.GetModuleType());
                item.Tag = menu;
                list.Add(item);
            }
            navBar.AddItems(list);
            navBar.ExpandBar();
        }

        void navBar_ItemClick(object sender, MedNavBarItem clickItem)
        {
            ApplicationFramework.Model.Menu menu = clickItem.Tag as ApplicationFramework.Model.Menu;
            //if(menu != null)
                //ApplicationManager.ActivateMenu(menu);
        }

    }
}
