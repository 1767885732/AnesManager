using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Wis.Anes.Framework.Controls.Base;
using ApplicationFramework.Model;
using ApplicationFramework;

namespace Wis.Anes.FrameWork
{
    public class ApplicationManager
    {
        public const string ICU_DOCTOR = "ICU_DOCTOR";
        public const string ICU_DOCTOR_MAIN = "ICU_DOCTOR_MAIN";
        public const string ICU_NURSE = "ICU_NURSE";
        public const string ICU_NURSE_MAIN = "ICU_NURSE_MAIN";

        static Dictionary<string, IRender> renderCacher = new Dictionary<string, IRender>();

        private ApplicationManager() { }

        public static ApplicationFramework.Model.Menu CurrentMenu
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentMenu;
            }
            set
            {
                ApplicationManager<DataRow>.CurrentMenu = value;
            }
        }
        private static bool applictionEixtFlag;
        public static bool ApplictionEixtFlag
        {
            get
            {
                return applictionEixtFlag;
            }
            set
            {
                applictionEixtFlag = value;
            }
        }

        public static string CurrentAppFlag
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentAppFlag;
            }
        }

        public static event Action<ApplicationFramework.Model.Menu> CurrentMenuActivated
        {

            add
            {
                ApplicationManager<DataRow>.CurrentMenuActivated += value;
            }

            remove
            {
                ApplicationManager<DataRow>.CurrentMenuActivated -= value;
            }
        }


        public static Control CurrentViewContainer
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentViewContainer;
            }
        }

        public static object CurrentMenuContainer
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentMenuManager.MenuContainer;
            }
        }

        public static Control CurrentSubMenuContainer
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentSubMenuContainer as Control;
            }
        }

        public static DataRow CurrentPatient
        {
            get
            {
                return ApplicationManager<DataRow>.CurrentData;
            }
            set
            {
                ApplicationManager<DataRow>.CurrentData = value;
            }
        }

        public static BaseControl CurrentBaseControl
        {
            get
            {
                return ApplicationManager <DataRow>.CurrentView as BaseControl;
            }

            set
            {
                ApplicationManager<DataRow>.CurrentView = value;
            }
        }
       
        internal static void OpenDialogForm(string appFlag, DataRow patientRow, Type type)
        {
            ApplicationManager<DataRow>.OpenDialogForm(appFlag, patientRow, type);
        }       

        internal static void Init(MenuCollection menuCollection, Control viewContainer, object menuContainer, object subMenuContaine)
        {
            ApplicationManager<DataRow>.Init(menuCollection, viewContainer, menuContainer, subMenuContaine);
        }

        public static void RegisterRender(string renderName, IRender render)
        {
            if (renderName == null)
                throw new ArgumentNullException("renderName");
            if (render == null)
                throw new ArgumentNullException("render");
            renderCacher[renderName] = render;
        }

        public static void UnregisterRender(string renderName)
        {
            if (renderCacher.ContainsKey(renderName))
            {
                renderCacher.Remove(renderName);
            }
        }

        public static void DoRender(string renderName, object data)
        {
            IRender render;
            if(renderCacher.TryGetValue(renderName, out render))
            {
                render.Rendering(data);
            }
            else
            {
                throw new ArgumentOutOfRangeException("renderName", "没有找到对应的Render");
            }
        }

        internal static void ActivateMenu(ApplicationFramework.Model.Menu menu)
        {
            ApplicationManager<DataRow>.ActivateMenu(menu);
        }


    }
}
