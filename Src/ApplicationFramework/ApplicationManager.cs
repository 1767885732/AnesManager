using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ApplicationFramework.Model;
namespace ApplicationFramework
{
    public static class ApplicationManager<TWacthData> 
    {

        public static object CurrentMenuContainer
        {
            get
            {
                return CurrentMenuManager.MenuContainer;
            }
        }

        public static object CurrentSubMenuContainer
        {
            get
            {
                return CurrentMenuManager.SubMenuContainer;
            }
        }
        public static Control CurrentViewContainer
        {
            get
            {
                return CurrentMenuManager.ViewContainer;
            }
        }

        static Stack<MenuManager<TWacthData>> _menuManagerStack = new Stack<MenuManager<TWacthData>>();

        public static MenuManager<TWacthData> CurrentMenuManager
        {
            get
            {
                if (_menuManagerStack.Count > 0)
                {
                    return _menuManagerStack.Peek();
                }
                return null;
            }
        }

        public static string CurrentAppFlag
        {
            get
            {
                if (CurrentMenuManager != null)
                    return CurrentMenuManager.AppFlag;
                return null;

            }
        }

        public static ApplicationFramework.Model.Menu CurrentMenu
        {
            get
            {
                return CurrentMenuManager.CurrentMenu;
            }
            set
            {
                CurrentMenuManager.CurrentMenu = value;
            }
        }

        public static IView CurrentView
        {

            get
            {
                return CurrentMenuManager.CurrentView;
            }

            set
            {
                CurrentMenuManager.CurrentView = value;
            }

        }


        public static void ActivateMenu(ApplicationFramework.Model.Menu menu)
        {
            CurrentMenuManager.ViewBuilderAndMenuBuilderMediator.ActivateMenu<TWacthData>(menu);
        }

        public static void ShowView(Control viewControl)
        {
            CurrentMenuManager.ViewBuilderAndMenuBuilderMediator.ShowView<TWacthData>(viewControl);
        }

        public static event Action<ApplicationFramework.Model.Menu> CurrentMenuActivated
        {
            add
            {
                CurrentMenuManager.ViewBuilderAndMenuBuilderMediator.MenuActivated += value;
            }

            remove
            {
                CurrentMenuManager.ViewBuilderAndMenuBuilderMediator.MenuActivated -= value;
            }
        }

        public static TWacthData CurrentData
        {
            get
            {
                if (CurrentMenuManager != null)
                    return CurrentMenuManager.CurrentData;
                return default(TWacthData);
            }
            set
            {
                if (CurrentMenuManager != null)
                    CurrentMenuManager.CurrentData = value;
            }
        }

        public static void OpenForm(string appFlag, TWacthData currentData,Type frmType)
        {
            _OpenForm(appFlag, currentData,frmType, false);
        }

        public static void OpenDialogForm(string appFlag, TWacthData currentData, Type frmType)
        {
            _OpenForm(appFlag,currentData, frmType, true);
        }

        private static void _OpenForm(string appFlag, TWacthData currentData, Type frmType, bool isShowDialog)
        {
            MenuManager<TWacthData> menuManager = new MenuManager<TWacthData>(appFlag);
            menuManager.CurrentData = currentData;
            _menuManagerStack.Push(menuManager);
            Form frm = Activator.CreateInstance(frmType) as Form;
            frm.FormClosed += frm_FormClosed;
            if (isShowDialog)
                frm.ShowDialog();
            else
                frm.Show();
            
        }

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= frm_FormClosed;
            //MenuManager<TWacthData> menuManager = _menuManagerStack.Pop();
            //menuManager.ViewBuilderAndMenuBuilderMediator.RemoveDelegate();
            //menuManager = null;
            GC.Collect();
        }

        public static void Init(MenuCollection menuCollection, Control viewContainer, object menuContainer, object subMenuContainer)
        {
            if (CurrentMenuManager == null)
                throw new InvalidOperationException("当前无MenuManager(菜单管理器), 请先执行OpenForm或OpenDialogForm,初始化菜单管理器");
            CurrentMenuManager.Init(menuCollection, viewContainer, menuContainer, subMenuContainer);
        }


    }
}
