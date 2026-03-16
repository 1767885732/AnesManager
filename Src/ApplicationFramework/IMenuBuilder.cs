using System;
using System.Collections.Generic;
using System.Text;
using ApplicationFramework.Model;

namespace ApplicationFramework
{
    public interface IMenuBuilder
    {
        /// <summary>
        /// 构建菜单
        /// </summary>
        /// <param name="menuContainer">菜单容器</param>
        /// <param name="menuCollection">所有菜单集合</param>
        void BuildMenus(object menuContainer, MenuCollection menuCollection);
        /// <summary>
        /// 构建子菜单
        /// 如果点击的菜单是父菜单(含有子菜单),将会调用该方法
        /// </summary>
        /// <param name="subMenuContainer">展示子菜单的容器</param>
        /// <param name="menus">子菜单列表</param>
        void BuildSubMenus(object subMenuContainer, Menu[] subMenus, Menu parentMenu);
    }
}
