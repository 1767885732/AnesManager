using DevExpress.XtraTab;
using Wis.Anes.Controls;
using ApplicationFramework;
using ApplicationFramework.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using App = ApplicationFramework.Model;
using Wis.Anes.Properties;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes.FrameWork
{
    public class CommonMenuBuilder : IMenuBuilder
    {
        public CommonMenuBuilder()
        {

        }

        IcuMenuButton currentBarItem;
        public IcuMenuButton CurrentBarItem
        {
            get { return currentBarItem; }
            set
            {
                OnCurrentItemChanged(value);
            }
        }

        void OnCurrentItemChanged(IcuMenuButton barItem)
        {
            //if (currentBarItem != null)
            //{
            //    currentBarItem.ButtonStyle = BarButtonStyle.Default;
            //    currentBarItem.Down = false;
            //    currentBarItem.Appearance.ForeColor = Color.White;
            //}
            FlowLayoutPanel bar = ApplicationManager.CurrentMenuContainer as FlowLayoutPanel;
            //将当前已点击的一级菜单项设置为未点击
            foreach (Control singleBarItem in bar.Controls)
            {                
                IcuMenuButton barBtnItem = singleBarItem as IcuMenuButton;
                if (barBtnItem == null || !barBtnItem.Selected)
                {
                    continue;
                }
                //barBtnItem.BackGroundImg = Resources.tab_normal; 
                barBtnItem.BackGroundImg = Resources._01;//hjcModify
                barBtnItem.Selected = false;
                barBtnItem.ForeColor = Color.White;//hjcModify 
            }
            //将当前点击的一级菜单项设置为点击状态
            currentBarItem = barItem;
            //currentBarItem.BackGroundImgSelected = Resources.tab_selected;
            currentBarItem.BackGroundImgSelected = Resources._02;//hjc Modify
            currentBarItem.Selected = true;
            currentBarItem.ForeColor = Color.Black;//hjc Modify
            //currentBarItem.PerformClick();
        }

        public void BuildMenus(object menuContainer, MenuCollection menuCollection)
        {
            FlowLayoutPanel bar = menuContainer as FlowLayoutPanel;
            if (bar == null)
                return;
            //bar.Size = new System.Drawing.Size(100, 70);
            //AddBlankItem(bar);
            foreach (App.Menu menu in menuCollection)
            {               
                //if (MedConfiguration.CheckPermissionByName(menu.MenuName))
                //{
                    IcuMenuButton barItem = AddBarButtonItem(bar, menu);
                    //if (menuCollection.FirstForView == menu)
                    if (menuCollection.FirstForView.Parent == menu)
                    {
                        //设置当前一级菜单项，但未构建二级菜单
                        CurrentBarItem = barItem;
                    }
                //}
            }
        }

        IcuMenuButton AddBarButtonItem(FlowLayoutPanel bar, App.Menu menu)
        {
            IcuMenuButton btnItem = new IcuMenuButton(menu.MenuName);
            btnItem.Tag = menu;
            menu.Tag = btnItem;
            btnItem.Caption = GetMenuName(menu.MenuName.Trim());
            btnItem.Click += btnItem_ItemClick;
            //btnItem.BackGroundImg = Resources.tab_normal;
            btnItem.BackGroundImg = Resources._01;
            //btnItem.BackGroundImgSelected = Resources.tab_selected;
            btnItem.BackGroundImgSelected = Resources._02;
            btnItem.CanClose = false;
            btnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            btnItem.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            //btnItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            btnItem.Image = Resources._01;
            //btnItem.Location = new System.Drawing.Point(0, 10);
            btnItem.Margin = new System.Windows.Forms.Padding(0, 10, 2, 0);
            btnItem.Selected = false;
            btnItem.Size = new System.Drawing.Size(135, 70);
            btnItem.Text = btnItem.Caption;

            //btnItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            if (btnItem.ICON == null || btnItem.ICONSelected == null)
            {
                btnItem.ICON = GetToolBarImage(btnItem.Caption);//hjcModify
                btnItem.ICONSelected = GetToolBarSelectedImage(btnItem.Caption);//hjcModify
            }                
            bar.Controls.Add(btnItem);
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
                case "大事件":
                    return Skin.Skin.GetDsjNormalImage();
                case "系统集成":
                    return Skin.Skin.GetEMRNormalImage();
                case "患者操作":
                    return Skin.Skin.GetPatientNormalImage();
                case "常用功能":
                    return Skin.Skin.GetConfigImage();
                case "其它":
                    return Skin.Skin.GetElseNormalImage();
                default:
                    break;
            }
            return null;
        }

        Image GetToolBarSelectedImage(string name)
        {
            switch (name)
            {
                case "大事件":
                    return Skin.Skin.GetDsjSelectedImage();
                case "系统集成":
                    return Skin.Skin.GetEMRSelectedImage();
                case "患者操作":
                    return Skin.Skin.GetPatientSelectedImage();
                case "常用功能":
                    return Skin.Skin.GetConfigSelectedImage();
                case "其它":
                    return Skin.Skin.GetElseSelectedImage();
                default:
                    break;
            }
            return null;
        }

        void btnItem_ItemClick(object sender, EventArgs e)
        {
            IcuMenuButton clickedButton = sender as IcuMenuButton;
            App.Menu menu = clickedButton.Tag as App.Menu;
            //if (currentBarItem == e.Item)
            //    return;
            ApplicationManager.ActivateMenu(menu);
            if (!menu.IsCommand)
                CurrentBarItem = clickedButton;

            if (menu.IsLeaf == true && !menu.IsCommand)
            {
                return;
            }            
        }


        public void BuildSubMenus(object subMenuContainer, App.Menu[] subMenus, App.Menu parentMenu)
        {
            HorizontalNavBar navBar = subMenuContainer as HorizontalNavBar;
            if (navBar == null)
            {
                return;
            }
            navBar.Caption = GetMenuName(parentMenu.MenuName);
            navBar.ClearItems();
            if (navBar.Tag == null)
            {
                navBar.ItemClick += new ItemClickEvent(navBar_ItemClick);
                navBar.Tag = this;
            }
            NavBarItemList list = new NavBarItemList(navBar);
            foreach (App.Menu menu in subMenus)
            {
                MedNavBarItem item = new MedNavBarItem(menu.MenuName, menu.GetModuleType());
                item.Tag = menu;
                list.Add(item);
            }
            navBar.AddItems(list);
        }

        void navBar_ItemClick(object sender, MedNavBarItem clickItem)
        {
            App.Menu menu = clickItem.Tag as App.Menu;
            if (menu != null)
            {
                ApplicationManager.ActivateMenu(menu);
            }
        }                
    }
}
