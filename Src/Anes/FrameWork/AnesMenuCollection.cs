using System;
using System.Collections.Generic;
using System.Text;
using ApplicationFramework.Model;
using ApplicationFramework;
using System.Reflection;
using System.Data;
using System.IO;
using Wis.Anes.Framework.Controls;
using Wis.Anes.Framework.Controls.Base;
using Wis.Anes.Framework.Configurations;
using Wis.Anes.Framework;
using Wis.Anes.Views;
using ApplicationFramework.Model;

namespace Wis.Anes.FrameWork
{
    public class AnesMenuCollection
    {
        public static INavBar NavBarContainer;
        private const string SPECIAL_CARE = "SpecialCare";
        private static DataTable _configDataTable = new DataTable("ConfigDataTable");

        static MenuCollection _nurseMenuCollection;        

        public static MenuCollection GetNurseMenuCollection()
        {
            if (_nurseMenuCollection == null)
            {                
                _nurseMenuCollection = new MenuCollection(ApplicationManager.CurrentAppFlag, new CommonViewBuilder(), new CommonMenuBuilder());
                //if (ApplicationManager.CurrentPatient == null)
                //{
                //    Sundries.MessageBox("当前没有患者在科，请先去床位管理将病人入科！");
                //}
                #region 大事件
                Menu menuBigEvent = new Menu();
                menuBigEvent.MenuName = "大事件";
                Menu menuMayao = new Menu();
                menuMayao.MenuName = "麻药";
                menuBigEvent.AddMenu("麻药", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuYongyao = new Menu();
                menuYongyao.MenuName = "用药";
                menuBigEvent.AddMenu("用药", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShijian = new Menu();
                menuShijian.MenuName = "事件";
                menuBigEvent.AddMenu("事件", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShuyang = new Menu();
                menuShuyang.MenuName = "输氧";
                menuBigEvent.AddMenu("输氧", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuChaguan = new Menu();
                menuChaguan.MenuName = "插管";
                menuBigEvent.AddMenu("插管", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuBaguan = new Menu();
                menuBaguan.MenuName = "拔管";
                menuBigEvent.AddMenu("拔管", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShuye = new Menu();
                menuShuye.MenuName = "输液";
                menuBigEvent.AddMenu("输液", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShuxue = new Menu();
                menuShuxue.MenuName = "输血";
                menuBigEvent.AddMenu("输血", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuHuxi = new Menu();
                menuHuxi.MenuName = "呼吸";
                menuBigEvent.AddMenu("呼吸", typeof(FloatFrm).AssemblyQualifiedName);
                AddToMenuCollection(_nurseMenuCollection, menuBigEvent);
                #endregion              

                #region 系统集成
                Menu menuSystemLink = new Menu();
                menuSystemLink.MenuName = "系统集成";
                Menu menuJianyan = new Menu();
                menuJianyan.MenuName = "检验信息";
                menuSystemLink.AddMenu("检验信息", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuJiancha = new Menu();
                menuJianyan.MenuName = "检查结果";
                menuSystemLink.AddMenu("检查结果", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuYizhu = new Menu();
                menuJianyan.MenuName = "医嘱信息";
                menuSystemLink.AddMenu("医嘱信息", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuBingli = new Menu();
                menuJianyan.MenuName = "病历病程";
                menuSystemLink.AddMenu("病历病程", typeof(FloatFrm).AssemblyQualifiedName);
                AddToMenuCollection(_nurseMenuCollection, menuSystemLink);
                #endregion

                #region 患者操作
                Menu menuPatientOperation = new Menu();
                menuPatientOperation.MenuName = "患者操作";
                Menu menuJianhu = new Menu();
                menuJianhu.MenuName = "设备采集";
                menuPatientOperation.AddMenu("设备采集", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuXinxi = new Menu();
                menuXinxi.MenuName = "手术信息";
                menuPatientOperation.AddMenu("手术信息", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuXueqi = new Menu();
                menuXueqi.MenuName = "血气分析";
                menuPatientOperation.AddMenu("血气分析", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuChuanci = new Menu();
                menuChuanci.MenuName = "穿刺管理";
                menuPatientOperation.AddMenu("穿刺管理", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShuzhong = new Menu();
                menuShuzhong.MenuName = "术中登记";
                menuPatientOperation.AddMenu("术中登记", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuJiaoban = new Menu();
                menuJiaoban.MenuName = "手术交班";
                menuPatientOperation.AddMenu("手术交班", typeof(FloatFrm).AssemblyQualifiedName);
                AddToMenuCollection(_nurseMenuCollection, menuPatientOperation);
                #endregion

                #region 常用功能
                Menu menuCommonFunction = new Menu();
                menuCommonFunction.MenuName = "常用功能";
                Menu menuSuoding = new Menu();
                menuSuoding.MenuName = "锁定系统";
                menuCommonFunction.AddMenu("锁定系统", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuXueliu = new Menu();
                menuXueliu.MenuName = "血流动力";
                menuCommonFunction.AddMenu("血流动力", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuZidian = new Menu();
                menuZidian.MenuName = "字典";
                menuCommonFunction.AddMenu("字典", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuMuban = new Menu();
                menuMuban.MenuName = "模板管理";
                menuCommonFunction.AddMenu("模板管理", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuMazuiQicai = new Menu();
                menuMazuiQicai.MenuName = "麻醉器材";
                menuCommonFunction.AddMenu("麻醉器材", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuShoushuQicai = new Menu();
                menuShoushuQicai.MenuName = "手术器材";
                menuCommonFunction.AddMenu("手术器材", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuQixie = new Menu();
                menuQixie.MenuName = "器械管理";
                menuCommonFunction.AddMenu("器械管理", typeof(FloatFrm).AssemblyQualifiedName);


                Menu menumzzj = new Menu();
                menumzzj.MenuName = "麻醉总结";
                menuCommonFunction.AddMenu("麻醉总结", typeof(FloatFrm).AssemblyQualifiedName);
                AddToMenuCollection(_nurseMenuCollection, menuCommonFunction);
                #endregion

                #region 其它
                Menu menuOthers = new Menu();
                menuOthers.MenuName = "其它";
                Menu menuXitongPeizhi = new Menu();
                menuXitongPeizhi.MenuName = "系统配置";
                menuOthers.AddMenu("系统配置", typeof(FloatFrm).AssemblyQualifiedName);

                Menu menuGuanyu = new Menu();
                menuGuanyu.MenuName = "关于";
                menuOthers.AddMenu("关于", typeof(FloatFrm).AssemblyQualifiedName);
                AddToMenuCollection(_nurseMenuCollection, menuOthers);
                #endregion

                _nurseMenuCollection.FirstForView = menuMayao;
            }
            return _nurseMenuCollection;
        }        

        public static void AddToMenuCollection(MenuCollection menuCollection, Menu menu)
        {
            if (menu.IsLeaf && !menu.IsCommand && string.IsNullOrEmpty(menu.ModuleType))
                return;
            menuCollection.Add(menu);
        }     
        
        public static void AddToNurseMenuCollection(Menu menu)
        {
            if (_nurseMenuCollection != null)
            {
                AddToMenuCollection(_nurseMenuCollection, menu);
            }            
        }

        public static void SetNurseMenuCollectionFirstView(Menu menu = null)
        {
            if (_nurseMenuCollection != null)
            {
                if (menu != null)
                {
                    _nurseMenuCollection.FirstForView = menu;
                }
                else
                {
                    //默认取第一个submenu
                    foreach (Menu item in _nurseMenuCollection)
                    {
                        if (item.SubMenus != null && item.SubMenus.Length > 0)
                        {
                            _nurseMenuCollection.FirstForView = item.SubMenus[0];
                            return;
                        }
                    }                    
                }
            }            
        }

        private static void CheckPermissionThenAddTo(string title, Type type, string path, Menu menu)
        {
            if (MedConfiguration.CheckPermission(type.FullName))
            {
                menu.AddMenu(title, type.AssemblyQualifiedName, path);
            }
        }                

        public static MenuCollection CurrentMenuCollection
        {
            get
            {
                return GetNurseMenuCollection();
            }
        }

        private static bool CheckPermissionThenAddTo(string title, Type type, Menu menu)
        {
            if (MedConfiguration.CheckPermission(type.FullName))
            {
                menu.AddMenu(title, type.AssemblyQualifiedName);
                return true;
            }

            return false;
        }

        private static bool CheckPermissionThenAddTo(string title, Type type, Menu menu, bool isForceReflash)
        {
            if (MedConfiguration.CheckPermission(type.FullName))
            {
                Menu newMenu = new Menu();
                newMenu.MenuName = title;
                newMenu.ModuleType = type.AssemblyQualifiedName;
                newMenu.IsForceNotify = isForceReflash;
                newMenu.Parent = menu;
                menu.AddMenu(newMenu);
                return true;
            }
            return false;
        }

        private static bool AddToMenu(string title, Type type, Menu menu, bool isForceReflash)
        {
            Menu newMenu = new Menu();
            newMenu.MenuName = title;
            newMenu.ModuleType = type.AssemblyQualifiedName;
            newMenu.IsForceNotify = isForceReflash;
            newMenu.Parent = menu;
            menu.AddMenu(newMenu);
            return true;
        }

        public static void ClearMenu()
        {
            _nurseMenuCollection = new MenuCollection(ApplicationManager.CurrentAppFlag, new CommonViewBuilder(), new CommonMenuBuilder());
        }
    }
}
