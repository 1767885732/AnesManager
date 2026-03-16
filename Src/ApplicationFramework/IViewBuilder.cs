using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ApplicationFramework
{
    /// <summary>
    /// 视图建造器接口
    /// </summary>
    public interface IViewBuilder
    {
        /// <summary>
        /// 构建菜单对应的视图控件
        /// 当点击的菜单是叶子菜单的时候将会调用该方法
        /// 返回的Control将会被传入ShowViewControl方法
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="viewContainer"></param>
        /// <returns></returns>
        Control BuildViewControl(ApplicationFramework.Model.Menu menu);
        /// <summary>
        /// 把视图控件显示到指定的viewControl上
        /// </summary>
        /// <param name="viewControl"></param>
        /// <param name="viewContainer"></param>
        void ShowViewControl(Control viewControl, Control viewContainer);
        /// <summary>
        /// 计算当前的视图
        /// </summary>
        /// <param name="viewControl"></param>
        /// <returns></returns>
        IView CalcuateCurrentView(Control viewControl);
    }
}
