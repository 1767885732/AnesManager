using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Wis.Anes.Framework.Properties;

namespace Wis.Anes.Framework.Controls
{
    /// <summary>
    /// 项目点击事件
    /// </summary>
    public delegate void ItemClickEvent(object sender, MedNavBarItem clickItem);
    public partial class NavBar : UserControl, INavBar
    {
        NavBarItemList _itemList = new NavBarItemList();
        private int selectedIndex = -1;

        public NavBarItemList ItemList
        {
            get
            {
                return _itemList;
            }
        }

        public NavBar()
        {
            InitializeComponent();
            this.navBarItemContainer.BackgroundImage = Skin.Skin.GetNavBackgroundImage();
            this.navBarItemContainer.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public NavBar(NavBarItemList navBarItemList)
        {
            InitializeComponent();
            this.navBarItemContainer.BackgroundImage = Skin.Skin.GetNavBackgroundImage();
            this.navBarItemContainer.BackgroundImageLayout = ImageLayout.Stretch;
            _itemList = navBarItemList;
            _itemList.NavBar = this;
            RenderControl();
        }        

        /// <summary>
        /// 自画列头事件
        /// </summary>
        [Category("Action"), Description("项目点击事件")]
        public event ItemClickEvent ItemClick;

        public NavBar AddItem(MedNavBarItem item)
        {
            item.NavBar = this;
            _itemList.Add(item);
            RenderControl();
            return this;
        }

        public NavBar AddItem(string name, Type itemType)
        {
            MedNavBarItem item = new MedNavBarItem(name, itemType);
            return AddItem(item);
        }

        public NavBar AddItems(NavBarItemList navBarItems)
        {
            foreach (MedNavBarItem item in navBarItems)
            {
                _itemList.Add(item);
            }
            RenderControl();
            return this;
        }

        public void ClearItems()
        {
            _itemList.Clear();
            RenderControl();
        }

        private void RenderControl()
        {
            navBarItemContainer.Controls.Clear();
            if (_itemList.Count == 0)
            {
                selectedIndex = -1;
                return;
            }
            for (int itemIndex = 0; itemIndex < _itemList.Count; itemIndex++)
            {
                Label itemlabel = CreateItemLabel(itemIndex);
                navBarItemContainer.Controls.Add(itemlabel);
            }
        }

        private Label CreateItemLabel(int itemIndex)
        {
            Label itemlabel = new Label();
            itemlabel.Tag = _itemList[itemIndex];
            itemlabel.AutoSize = false;
            itemlabel.Text = "           " + _itemList[itemIndex].Name;            
            itemlabel.ForeColor = Color.White;
            itemlabel.TextAlign = ContentAlignment.MiddleLeft;
            itemlabel.Size = new System.Drawing.Size(150, 36);
            itemlabel.BackColor = Color.Transparent;
            //为什么不行啊...

            //itemlabel.Margin = new Padding(0, 0, 0,100);
            //itemlabel.Padding = new Padding(0, 0, 0, 20);
            itemlabel.Location = new Point(-5, (itemIndex + 1) * 37 - 10);
            itemlabel.Image = Skin.Skin.GetNavNotSelectImage();
            itemlabel.ImageAlign = ContentAlignment.MiddleLeft;
            itemlabel.Click += new EventHandler(ItemLabelClick);
            itemlabel.MouseEnter += new EventHandler(itemlabel_MouseEnter);
            itemlabel.MouseLeave += new EventHandler(itemlabel_MouseLeave);
            itemlabel.MouseDown += new MouseEventHandler(itemlabel_MouseDown);
            _itemList[itemIndex].Index = itemIndex;
            _itemList[itemIndex].NavBar = this;
            return itemlabel;
        }

        private void itemlabel_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).Image = Skin.Skin.GetNavSelectImage();
        }

        private void itemlabel_MouseLeave(object sender, EventArgs e)
        {
            if (selectedIndex == ((MedNavBarItem)((Label)sender).Tag).Index)
            {
                ((Label)sender).Image = Skin.Skin.GetNavSelectImage();
            }
            else
            {
                ((Label)sender).Image = Skin.Skin.GetNavNotSelectImage();
            }
        }

        private void itemlabel_MouseEnter(object sender, EventArgs e)
        {
            if (selectedIndex == ((MedNavBarItem)((Label)sender).Tag).Index)
            {
                ((Label)sender).Image = Skin.Skin.GetNavEnterSelectedImage();
            }
            else
            {
                ((Label)sender).Image = Skin.Skin.GetNavEnterImage();
            }
        }

        private void ItemLabelClick(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
                (navBarItemContainer.Controls[selectedIndex] as Label).Image = Skin.Skin.GetNavNotSelectImage();
            Label currentLabel = sender as Label;
            currentLabel.Image = Skin.Skin.GetNavSelectImage();
            currentLabel.ImageAlign = ContentAlignment.MiddleLeft;
            MedNavBarItem item = currentLabel.Tag as MedNavBarItem;
            selectedIndex = item.Index;
            if (ItemClick != null)
            {
                ItemClick(this, item);
            }
        }

        public void SetLabelChecked(int index)
        {
            Label currentLabel = navBarItemContainer.Controls[index] as Label;
            currentLabel.Image = Skin.Skin.GetNavSelectImage();
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
                Label lbl = navBarItemContainer.Controls[item.Index] as Label;
                ItemLabelClick(lbl, null);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Tag.ToString() == "<")
            {
                Shrink();
            }
            else
            {
                Expand();
            }
        }

        public void Expand()
        {
            this.Width = 150;
            label3.Tag = "<";
            //label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(153)))), ((int)(((byte)(210)))));
            label3.Image = Resources.收缩;
            navBarItemContainer.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
        }

        public void Shrink()
        {
            this.Width = 8;
            label3.Tag = ">";
            navBarItemContainer.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            this.BackColor = Color.White;
            //label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(226))))); ;
            label3.Image = Resources.展开;
        }

        public void ExpandBar()
        {
            if (label3.Tag.ToString() == ">")
            {
                Expand();
            }
        }

        public void ShrinkBar()
        {
            if (label3.Tag.ToString() == "<")
            {
                Shrink();
            }
        }

        private void NavBar_SizeChanged(object sender, EventArgs e)
        {
            navBarItemContainer.Width = this.Width - 3;
            label3.Location = new Point(label3.Location.X, (this.Height - 37) / 2);
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

    }

    public class MedNavBarItem
    {
        public MedNavBarItem() { }
        public MedNavBarItem(string name, Type itemType)
        {
            Name = name;
            ItemType = itemType;
        }

        public MedNavBarItem(string name, Control ctl)
        {
            Name = name;
            BaseControl = ctl;
        }

        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        Type _itemType;
        public Type ItemType
        {
            get
            {
                return _itemType;
            }
            set
            {
                _itemType = value;
            }
        }

        public INavBar NavBar { get; set; }

        int _index;
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }
        public Control BaseControl;

        public object Tag;
    }

    public interface INavBar
    {

    }

    public class NavBarItemList : List<MedNavBarItem>
    {
        public NavBarItemList() { }
        public NavBarItemList(INavBar navBar)
        {
            this.NavBar = navBar;
        }

        public INavBar NavBar { get; set; }

        public NavBarItemList Add(string name, Type itemType)
        {
            Add(new MedNavBarItem(name, itemType));
            return this;
        }

        public NavBarItemList Add(string name, Control ctl)
        {
            Add(new MedNavBarItem(name, ctl));
            return this;
        }
    }
}
