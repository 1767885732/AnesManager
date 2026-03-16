using System;
using System.Collections.Generic;
using ApplicationFramework;
using ApplicationFramework.Model;
using System.Windows.Forms;
using ApplicationFramework.Exception;

namespace ApplicationFramework
{
    /// <summary>
    /// 菜单管理类
    /// </summary>
    public class MenuManager<TWacthData> 
    {

        internal MenuManager(string appFlag)
        {
            AppFlag = appFlag;
        }

        public string AppFlag { get; private set; }
        public Control ViewContainer { get; private set; }
        public object MenuContainer { get; private set; }
        public MenuCollection MenuCollections { get; private set; }
        public object SubMenuContainer { get; private set; }
        internal ViewBuilderAndMenuBuilderMediator ViewBuilderAndMenuBuilderMediator { get; private set; }

        TWacthData _currentData;
        public TWacthData CurrentData
        {
            get
            {
                return _currentData;
            }
            set
            {

                _currentData = value;
                OnPatientChanged();
            }
        }

        void OnPatientChanged()
        {
            if (CurrentMenu != null && CurrentMenu.ModuleView != null)
            {
                CurrentMenu.ModuleView.Notify(false);
            }
        }

        ApplicationFramework.Model.Menu _currentMenu;
        public ApplicationFramework.Model.Menu CurrentMenu 
        {
            get { return _currentMenu; }
            set
            {
                _currentMenu = value;
                //if (_currentMenu != null && _currentMenu.ModuleView != null)
                //    _currentMenu.ModuleView.Notify();
            }
        }

        public IView CurrentView
        {
            get
            {
                if (CurrentMenu != null && CurrentMenu.ModuleView != null)
                    return CurrentMenu.ModuleView;
                return null;
            }

            set
            {
                if (CurrentMenu != null)
                {
                    SetCurrentMenu(MenuCollections.ToArray(), value.GetType().AssemblyQualifiedName);
                    CurrentMenu.ModuleView = value;
                    if (CurrentMenu.ModuleView != null)
                    {
                        if (!CurrentMenu.ModuleView.IsFirstLoading)
                        {
                            CurrentMenu.ModuleView.Notify(CurrentMenu.IsForceNotify);
                        }
                    }
                }
            }
        }

        private void SetCurrentMenu(ApplicationFramework.Model.Menu[] collections,string type)
        {
            foreach (ApplicationFramework.Model.Menu menu in collections)
            {
                if (menu.ModuleType == type)
                {
                    CurrentMenu = menu;
                    return;
                }
                else if (menu.SubMenus != null)
                {
                    SetCurrentMenu(menu.SubMenus, type);
                }
            }
        }

        internal void Init(MenuCollection menuCollection, Control viewContainer, object menuContainer, object subMenuContainer)
        {            
            VerifyArguments(menuCollection, viewContainer, menuContainer, subMenuContainer);
            ViewContainer = viewContainer;
            MenuContainer = menuContainer;
            MenuCollections = menuCollection;
            SubMenuContainer = subMenuContainer;
            ViewBuilderAndMenuBuilderMediator = new ViewBuilderAndMenuBuilderMediator(menuCollection.MenuBuilder, menuCollection.ViewBuilder);
            menuCollection.MenuBuilder.BuildMenus(menuContainer, menuCollection);
            ViewBuilderAndMenuBuilderMediator.PrepareBuild(menuCollection);            
            ViewBuilderAndMenuBuilderMediator.ActivateMenu<TWacthData>(menuCollection.FirstForView);
        }

        private static void VerifyArguments(MenuCollection menuCollection, Control viewContainer, object menuContainer, object subMenuContainer)
        {
            if (menuCollection == null)
                throw new ArgumentNullException("menuCollection");
            if (viewContainer == null)
                throw new ArgumentNullException("viewContainer");
            if (menuContainer == null)
                throw new ArgumentNullException("menuContainer");
            if (subMenuContainer == null)
                throw new ArgumentNullException("subMenuContainer");
            if (menuCollection.MenuBuilder == null)
                throw new ApplicationFrameworkException("MenuBuilder为空，无法构建菜单。");
            if (menuCollection.ViewBuilder == null)
                throw new ApplicationFrameworkException("ViewBuilder为空，无法构建视图。");
        }        
    }
}
