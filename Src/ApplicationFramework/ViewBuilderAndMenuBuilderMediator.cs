using System;
using System.Collections.Generic;
using System.Text;
using ApplicationFramework;
using App=ApplicationFramework.Model;
using ApplicationFramework.Model;
using System.Windows.Forms;

namespace ApplicationFramework
{
    class ViewBuilderAndMenuBuilderMediator
    {

        Dictionary<App.Menu, Control> _menuCacher = new Dictionary<App.Menu, Control>();
        public event Action<App.Menu> MenuActivated;
        IMenuBuilder _menuBuilder;
        IViewBuilder _viewBuilder;
        public ViewBuilderAndMenuBuilderMediator(IMenuBuilder menuBuilder, IViewBuilder viewBuilder)
        {
            _menuBuilder = menuBuilder;
            _viewBuilder = viewBuilder;
        }

        internal void ActivateMenu<TWatchData>(App.Menu menu)
        {
            if (menu == null)
                return;
            if (!menu.IsCommand)
                ApplicationManager<TWatchData>.CurrentMenu = menu;

            if (menu.IsLeaf)
            {
                //if (menu.ModuleView != null)
                //    menu.ModuleView.IsFirstLoading = true;
                //Control viewControl = GetOrBuildViewControl(menu);
                //ShowView<TWatchData>(viewControl);
                //if (menu.ModuleView != null)
                //    menu.ModuleView.IsFirstLoading = false;
            }
            else
            {
                _menuBuilder.BuildSubMenus(ApplicationManager<TWatchData>.CurrentSubMenuContainer, menu.SubMenus, menu);
            }

            MenuActivated?.Invoke(menu);
        }

        internal void ShowView<TWatchData>(Control viewControl)
        {
            if (viewControl == null)
                return;
            _viewBuilder.ShowViewControl(viewControl, ApplicationManager<TWatchData>.CurrentViewContainer);
            ApplicationManager<TWatchData>.CurrentView = _viewBuilder.CalcuateCurrentView(viewControl);
        }

        private Control GetOrBuildViewControl(App.Menu menu)
        {
            Control viewControl;
            if (menu.NeedCache || menu.IsCreateOnLoad)
            {
                if (!_menuCacher.TryGetValue(menu, out viewControl))
                {
                    viewControl = _viewBuilder.BuildViewControl(menu);
                    _menuCacher[menu] = viewControl;
                }
            }
            else
            {
                viewControl = _viewBuilder.BuildViewControl(menu);
            }
            return viewControl;
        }

        internal void PrepareBuild(MenuCollection menuCollection)
        {
            foreach (App.Menu menu in menuCollection)
            {
                if (menu.IsCreateOnLoad)
                {
                    _menuCacher[menu] = _viewBuilder.BuildViewControl(menu);
                }
            }
        }

        internal void RemoveDelegate()
        {
            if (MenuActivated == null)
                return;

            foreach (Delegate d in MenuActivated.GetInvocationList())
            {
                MenuActivated -= d as Action<App.Menu>;
            }
        }
    }
}
