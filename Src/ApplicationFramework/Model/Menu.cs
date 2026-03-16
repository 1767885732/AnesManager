using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace ApplicationFramework.Model
{
    public class Menu: IComparable<Menu>
    {
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public Menu Parent { get; set; }
        public int SortIndex { get; set; }
        public string Args { get; set; }

        
        /// <summary>
        /// 评估单配置器文档路径
        /// </summary>
        public string LoadResoucesPath { get; set; }

        public bool HasSiblings
        {
            get
            {
                if (Parent == null)
                    return false;
                else if (Parent._subMenuList.Count > 1)
                    return true;
                else
                    return false;
            }
        }

        public bool IsTopMenu
        {
            get
            {
                return (Parent == null);
            }
        }

        public bool IsParent
        {
            get { return !IsLeaf; }
        }

        public bool IsLeaf
        {
            get { return _subMenuList.Count == 0; }
        }

        List<Menu> _subMenuList = new List<Menu>();
        /// <summary>
        /// 这里返回的是一个使用保护性拷贝是因为,
        /// 我不希望外部代码可以直接操作这个子菜单列表
        /// </summary>
        public Menu[] SubMenus
        {
            get { return _subMenuList.ToArray(); }
        }

        public void SortSubMenus()
        {
            foreach (Menu menu in _subMenuList)
            {
                menu.SortSubMenus();
                //_subMenuList.Sort();
            }
            _subMenuList.Sort(MenuComparator.Instance);
        }

        public void AddMenu(Menu menu)
        {
            _subMenuList.Add(menu);
        }

        public void AddMenu(string menuName, string type)
        {
            _subMenuList.Add(new Menu { MenuName = menuName, ModuleType = type, Parent = this });
        }

        public void AddMenu(string menuName, string type,string filePath)
        {
            _subMenuList.Add(new Menu { MenuName = menuName, ModuleType = type, Parent = this, LoadResoucesPath = filePath });
        }

        public void RemoveMenu(Menu menu)
        {
            _subMenuList.Remove(menu);
        }

        public void RemoveMenuAt(int index)
        {
            _subMenuList.RemoveAt(index);
        }
        /// <summary>
        /// 是否在加载菜单至界面时就创建菜单下挂载的对应模块
        /// 如果为true,表示该菜单下的挂载的模块将在构建菜单时候一并构建,
        /// 并无论NeedCache是否为true,该菜单下的模块都将缓存起来.
        /// </summary>
        public bool IsCreateOnLoad { get; set; }
        /// <summary>
        /// 是否需要缓存,当IsCreateOnLoad为true,无论NeedCache是否为true,该菜单下的模块都将缓存起来.
        /// </summary>
        public bool NeedCache { get; set; }
        public string ModuleType { get; set; }

        IView _moduleView;

        public IView ModuleView
        {
            get
            {
                return _moduleView;
            }
            set
            {
                if (value != null)
                {
                    _moduleView = value;
                    ModuleType = string.Format("{0}, {1}", _moduleView.GetType().FullName, _moduleView.GetType().Assembly.FullName);
                }
            }
        }
        Type type;
        public Type GetModuleType()
        {
            if (string.IsNullOrEmpty(ModuleType))
                return null;
            if (type == null)
                type = Type.GetType(ModuleType, true);
            return type;
        }

        public IView Load()
        {
            if (GetModuleType() != null)
            {
                return Activator.CreateInstance(GetModuleType()) as IView;
            }
            return null;
        }
        public IView Load(params object[] args)
        {
            if (GetModuleType() != null)
            {
                return Activator.CreateInstance(GetModuleType(), args) as IView;
            }
            return null;
        }
        public bool IsCommand { get; set; }
        public string CommandString { get; set; }
        public object Tag { get; set; }
        public Image Image { get; set; }
        public bool IsFirstMenu { get; set; }
        public bool IsForceNotify { get; set; }

        public override bool Equals(object obj)
        {

            if (obj == this)
                return true;
            if (!(obj is Menu))
                return false;
            if (obj.GetType() != GetType())
                return false;
            if (((Menu)obj).MenuID != MenuID)
                return false;
            if (((Menu)obj).MenuName != MenuName)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            int result = 17;
            if (MenuID != null)
                result += 31 * result + MenuID.GetHashCode();
            if (MenuName != null)
                result += 31 * result + MenuName.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            return MenuName;
        }


        public int CompareTo(Menu other)
        {
            return MenuComparator.Instance.Compare(this, other);
        }
    }
}
