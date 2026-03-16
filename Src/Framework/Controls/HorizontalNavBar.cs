using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    public partial class HorizontalNavBar : UserControl, INavBar
    {
        private int selectedIndex = -1;

        public string Caption { get; set; }

        public NavBarItemList ItemList { get; } = new NavBarItemList();

        public HorizontalNavBar()
        {
            InitializeComponent();
            //this.navBarItemContainer.BackgroundImage = Skin.Skin.GetSubTabSelected1Image();
            this.navBarItemContainer.BackColor = Color.FromArgb(243, 245, 255); // Color.FromArgb(228, 234, 255);
            //this.navBarItemContainer.BackColor = Color.FromArgb(243, 245, 255);

            this.navBarItemContainer.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public HorizontalNavBar(NavBarItemList navBarItemList):this()
        {
            ItemList = navBarItemList;
            ItemList.NavBar = this;
            RenderControl();
        }

        /// <summary>
        /// 自画列头事件
        /// </summary>
        [Category("Action"), Description("项目点击事件")]
        public event ItemClickEvent ItemClick;

        public HorizontalNavBar AddItem(MedNavBarItem item)
        {
            item.NavBar = this;
            ItemList.Add(item);
            RenderControl();
            return this;
        }

        public HorizontalNavBar AddItem(string name, Type itemType)
        {
            MedNavBarItem item = new MedNavBarItem(name, itemType);
            return AddItem(item);
        }

        public HorizontalNavBar AddItems(NavBarItemList navBarItems)
        {
            foreach (MedNavBarItem item in navBarItems)
            {
                ItemList.Add(item);
            }
            RenderControl();
            navBarItemContainer.Refresh();
            return this;
        }

        public void ClearItems()
        {
            ItemList.Clear();
            RenderControl();
        }

        private void RenderControl()
        {
            navBarItemContainer.Controls.Clear();
            if (ItemList.Count == 0)
            {
                selectedIndex = -1;
                return;
            }

            //添加一个大标题
            Label header = new Label();
            header.AutoSize = false;
            header.Text = "  " + Caption;
            header.ForeColor = Color.FromArgb(52, 90, 237);
            header.TextAlign = ContentAlignment.MiddleCenter;
            header.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            header.Size = new System.Drawing.Size(90, 45);
            header.Location = new Point(0, 0);
            navBarItemContainer.Controls.Add(header);

            for (int itemIndex = 0; itemIndex < ItemList.Count; itemIndex++)
            {
                CommonLabel itemlabel = CreateItemLabel(itemIndex);
                if (itemIndex == ItemList.Count - 1)
                {
                    itemlabel.Size = new Size(115, 45);
                }
                navBarItemContainer.Controls.Add(itemlabel);
            }
        }

        private CommonLabel CreateItemLabel(int itemIndex)
        {
            CommonLabel itemlabel = new CommonLabel();
            itemlabel.Tag = ItemList[itemIndex];
            itemlabel.AutoSize = false;
            itemlabel.Text = ItemList[itemIndex].Name;
            itemlabel.ForeColor = Color.FromArgb(52, 90, 237);// 
            itemlabel.Size = new System.Drawing.Size(120, 45);
            itemlabel.Click += new EventHandler(ItemLabelClick);
            itemlabel.BackGroundImg =  Skin.Skin.GetTwoMenuNormalImage();
            itemlabel.BackGroundImgSelected = Skin.Skin.GetTwoMenuSelectedImage();
            itemlabel.Image = Skin.Skin.GetTwoMenuNormalImage();
            itemlabel.MouseEnter += new EventHandler(itemlabel_MouseEnter);
            itemlabel.MouseLeave += new EventHandler(itemlabel_MouseLeave);
            ItemList[itemIndex].Index = itemIndex;
            ItemList[itemIndex].NavBar = this;
            return itemlabel;
        }

        private void itemlabel_MouseLeave(object sender, EventArgs e)
        {
            if (selectedIndex == ((MedNavBarItem)((CommonLabel)sender).Tag).Index)
            {
                //((Label)sender).Image = Skin.Skin.GetNavSelectImage();
            }
            else
            {
                //((Label)sender).Image = Skin.Skin.GetNavNotSelectImage();
            }
        }

        private void itemlabel_MouseEnter(object sender, EventArgs e)
        {
            if (selectedIndex == ((MedNavBarItem)((CommonLabel)sender).Tag).Index)
            {
                //((Label)sender).Image = Skin.Skin.GetNavEnterSelectedImage();
            }
            else
            {
                //((Label)sender).Image = Skin.Skin.GetNavEnterImage();
            }
        }

        private void ItemLabelClick(object sender, EventArgs e)
        {
            //if (selectedIndex != -1)
            //(navBarItemContainer.Controls[selectedIndex] as Label).Image = Skin.Skin.GetNavNotSelectImage();
            CommonLabel currentLabel = sender as CommonLabel;
            currentLabel.Selected = true;
            //currentLabel.Image = Skin.Skin.GetNavSelectImage();
            //currentLabel.ImageAlign = ContentAlignment.MiddleLeft;
            MedNavBarItem item = currentLabel.Tag as MedNavBarItem;
            selectedIndex = item.Index;
            if (ItemClick != null)
            {
                ItemClick(this, item);
            }
        }

        public void SetLabelChecked(int index)
        {
            CommonLabel currentLabel = navBarItemContainer.Controls[index+1] as CommonLabel;
            //currentLabel.Image = Skin.Skin.GetNavSelectImage();
            currentLabel.Selected = true;
            currentLabel.ImageAlign = ContentAlignment.MiddleLeft;
            MedNavBarItem item = currentLabel.Tag as MedNavBarItem;
            selectedIndex = item.Index;
        }

        public void FireClickNavBarItem(MedNavBarItem item)
        {
            if (item == null)
                return;
            if (item.Index < 0 || item.Index > (navBarItemContainer.Controls.Count - 1))
                return;
            if (navBarItemContainer.Controls.Count > 0)
            {
                CommonLabel lbl = navBarItemContainer.Controls[item.Index+1] as CommonLabel;
                ItemLabelClick(lbl, null);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// 设置所有控件为未选择状态
        /// </summary>
        public void SetItemsUnSelected()
        {
            for (int i = 1; i < navBarItemContainer.Controls.Count; i++)
            {
                CommonLabel item = navBarItemContainer.Controls[i] as CommonLabel;
                if (item != null)
                {
                    item.Selected = false;
                }                
            }            
        }
    }
}

