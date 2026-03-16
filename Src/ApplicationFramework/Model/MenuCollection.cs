using System;
using System.Collections.Generic;
using ApplicationFramework.Exception;

namespace ApplicationFramework.Model
{
    public class MenuCollection : List<Menu>
    {
        public Menu FirstForView { get; set; }
        //internal IViewBuilder ViewBuilder { get; set; }
        public IViewBuilder ViewBuilder { get; set; }
        //internal IMenuBuilder MenuBuilder { get; set; }
        public IMenuBuilder MenuBuilder { get; set; }
        public string AppFlag { get; set; }

        public MenuCollection(string appFlag, IViewBuilder viewBuilder, IMenuBuilder menuBuilder)
        {
            AppFlag = appFlag;
            ViewBuilder = viewBuilder;
            MenuBuilder = menuBuilder;
        }

        public new void Sort()
        {
            foreach (Menu subMenu in this)
            {
                subMenu.SortSubMenus();
            }
            base.Sort();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && ((MenuCollection)obj).AppFlag == AppFlag) 
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return AppFlag.GetHashCode();
        }
    }
}
