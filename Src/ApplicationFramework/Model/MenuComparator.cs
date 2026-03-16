using System;
using System.Collections.Generic;
using ApplicationFramework.Exception;

namespace ApplicationFramework.Model
{
    public class MenuComparator : IComparer<Menu>
    {
        private MenuComparator() { }

        public static MenuComparator Instance = new MenuComparator();

        #region IComparer<Menu> 成员

        public int Compare(Menu x, Menu y)
        {
            return (x.SortIndex == y.SortIndex ? 0 : x.SortIndex > y.SortIndex ? 1 : -1);
        }

        #endregion
    }
}
