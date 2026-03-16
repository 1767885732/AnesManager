using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace Wis.Anes.Skin
{
    public class Skin
    {
        public static string SkinName;

        public static EventHandler SkinChanged;
        public static void SetCurrentSkinName(string skinName)
        {
            SkinName = skinName;
            if (SkinChanged != null)
                SkinChanged(null, EventArgs.Empty);

        }
        public string[] GetSkinName()
        {
            string[] name = new string[]
            {
                "ExtendBlue",
                "ExtendDarkBlue"
            };
            return name;
        }
        /// <summary>
        /// 获取logo图片
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetLogoImage()
        {
            //return Resource1.logo4;
            return new Bitmap(1,1);
        }
        /// <summary>
        /// 床位右侧背景
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetRightBedImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.BedBack;
            else if (SkinName == "MySkin_Black")
                return Resource1.BedBack_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.BedBack_green;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.顶部床号背景;
            return Resource1.BedBack;
        }
        /// <summary>
        /// 床位左侧背景
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetLeftBedImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.BedSelectBack;
            else if (SkinName == "MySkin_Black")
                return Resource1.BedBackSelect_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.BedSelectBack_green;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.顶部床号下拉背景;
            return Resource1.BedSelectBack;
        }
        /// <summary>
        /// 医生站主界面4个图上面的文字说明的背景条
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetDoctorFrmSmallTitleImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.doctorFrmSmallTitle;
            else if (SkinName == "MySkin_Black")
                return Resource1.doctorFrmSmallTitle_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.doctorFrmSmallTitle_green;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.doctorFrmSmallTitle_Dark;
            else if (SkinName == "MySkin_Silver1")
                return Resource1.graphTitle;
            return Resource1.doctorFrmSmallTitle;
        }
        /// <summary>
        /// 获取姓名背景
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetNameBackImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.姓名;
            else if (SkinName == "MySkin_Black")
                return Resource1.xingming_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.xingming_Black;
            return Resource1.姓名;
        }
        /// <summary>
        /// 医生站空床图片
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetNoPatBed()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.空床;
            else if (SkinName == "MySkin_Black")
                return Resource1.空床_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.空床_green;
            return Resource1.空床;
        }
        /// <summary>
        /// 医生站已占床位图片
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetHasPatBed()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.hasPatBed;
            else if (SkinName == "MySkin_Black")
                return Resource1.hasPatBed_Black;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.hasPatBed_Dark;
            else if (SkinName == "MySkin_Green")
                return Resource1.hasPatBed_green;
            return Resource1.hasPatBed;
        }
        /// <summary>
        /// 医生站当前床位图片
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetCurrentBed()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.currentBed;
            else if (SkinName == "MySkin_Black")
                return Resource1.currentBed_Black;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.currentBed_Dark;
            else if (SkinName == "MySkin_Green")
                return Resource1.currentBed_green;
            return Resource1.currentBed;
        }
        /// <summary>
        /// 床位占有说明图
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetBedIntroduceImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.BedIntruduce;
            else if (SkinName == "MySkin_Black")
                return Resource1.BedIntruduce_Black;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.BedIntruduce_Dark;
            else if (SkinName == "MySkin_Green")
                return Resource1.BedIntruduce_green;
            return Resource1.BedIntruduce;
        }
        /// <summary>
        /// 护士站主界面出入量格背景小图
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetNruseFrmInOutImage()
        {
            if (SkinName == "MySkin_Black")
                return Resource1.竖背景黑色;
            else if (SkinName == "MySkin_Green")
                return Resource1.竖背景绿色;
            else
                return Resource1.护士站主界面出入量_竖背景;
        }
        /// <summary>
        /// 医生站主界面间隔色刷子
        /// </summary>
        /// <returns></returns>
        public static Brush GetDoctorFrmIntervalBrush()
        {
            if (SkinName == "MySkin_Black")
                return new SolidBrush(Color.FromArgb(224, 224, 224));
            else if (SkinName == "MySkin_Green")
                return new SolidBrush(Color.FromArgb(225, 241, 231));
            else
                return new SolidBrush(Color.FromArgb(0x78DBE4ED));
        }
        /// <summary>
        /// 网格线颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetGridLineColor()
        {
            return Color.FromArgb(102,102,102);
        }
        /// <summary>
        /// dataGridView选中单元格颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetGridSelectColor()
        {
            return Color.FromArgb(183, 182, 204);
        }
        /// <summary>
        /// 医生站出入量背景颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetDoctorFrmInOrOutBackColor()
        {
            if (SkinName == "MySkin_Black")
                return Color.FromArgb(224, 224, 224);
            else if (SkinName == "MySkin_Green")
                return Color.FromArgb(225, 241, 231);
            else
                return System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(228)))), ((int)(((byte)(237)))));
        }

        /// <summary>
        /// 护士站主界面出入量格间隔色
        /// </summary>
        /// <returns></returns>
        public static Brush GetMainFrmInOutIntervalBrush()
        {
            if (SkinName == "MySkin_Black")
                return new SolidBrush(System.Drawing.Color.FromArgb(241, 241, 241));
            else if (SkinName == "MySkin_Green")
                return new SolidBrush(System.Drawing.Color.FromArgb(225, 241, 231));
            else
                return new SolidBrush(System.Drawing.Color.FromArgb(182,197,214));

        }

        /// <summary>
        /// 获取GridView标题色
        /// </summary>
        /// <returns></returns>
        public static Image GetGridViewHeaderImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.标题背景;
            else if (SkinName == "MySkin_Black")
                return Resource1.doctorFrmSmallTitle_Black;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.标题1背景;
            else if (SkinName == "MySkin_Green")
                return Resource1.doctorFrmSmallTitle_green;
            else if (SkinName == "MySkin_Silver1")
                return Resource1.graphTitle;
            return Resource1.标题背景;
        }
        public static Image GetGraphTitleImage()
        {
            if (SkinName == "ExtendBlue")
                return Resource1.graphTitle;
            else if (SkinName == "ExtendDarkBlue")
                return Resource1.graphTitle_Dark;
            else if (SkinName == "MySkin_Black")
                return Resource1.doctorFrmSmallTitle_Black;
            else if (SkinName == "MySkin_Green")
                return Resource1.doctorFrmSmallTitle_green;
            return Resource1.graphTitle;
        }
        /// <summary>
        /// 获取GridView左边标题色
        /// </summary>
        /// <returns></returns>
        public static Color GetGridViewLeftMenu()
        {
            if (SkinName == "ExtendBlue")
                //return Resource1.左侧背景图;
                return System.Drawing.Color.FromArgb(181,197,213);
            else if (SkinName == "MySkin_Black")
                return Color.LightGray;
            else if (SkinName == "ExtendDarkBlue")
                //return Resource1.深色_左侧列表颜色;
                return System.Drawing.Color.FromArgb(181, 197, 213);
            else if (SkinName == "MySkin_Green")
                return System.Drawing.Color.FromArgb(233, 244, 236);
            return System.Drawing.Color.FromArgb(181,197,213);
        }
        /// <summary>
        /// GridView间隔行背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetGridViewAlternateRowColor()
        {
            if (SkinName == "ExtendBlue")
                return System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(235)))));
            else if (SkinName == "MySkin_Black")
                return System.Drawing.Color.FromArgb(224,224,224);
            else if (SkinName == "ExtendDarkBlue")
                return System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            else if (SkinName == "MySkin_Green")
                return System.Drawing.Color.FromArgb(225, 241, 231);
            return System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(226)))), ((int)(((byte)(235)))));
        }
        /// <summary>
        /// GridView选中行背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetGridViewSelectedRowColor()
        {
            return System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(182)))), ((int)(((byte)(204)))));
        }

        public static Color GetGridViewBackColor()
        {
            if (SkinName == "ExtendBlue")
                return System.Drawing.Color.White;
            else if (SkinName == "ExtendDarkBlue")
                return System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(193)))), ((int)(((byte)(239)))));

            return System.Drawing.Color.White;
            
        }

        /// 获取男士床头卡
        /// </summary>
        /// <returns></returns>
        public static Image GetManBedImage()
        {
            return Resource1.man;
        }
        /// <summary>
        /// 获取女士床头卡
        /// </summary>
        /// <returns></returns>
        public static Image GetWomanBedImage()
        {
            return Resource1.women;
        }
        /// <summary>
        /// 获取导航栏左侧背景
        /// </summary>
        /// <returns></returns>
        public static Image GetNavBackgroundImage()
        {
            return Resource1.navBackground;
        }
        /// <summary>
        /// 获取导航栏左侧按钮背景
        /// </summary>
        /// <returns></returns>
        public static Image GetNavNotSelectImage()
        {
            return Resource1.navNotSelect2;
        }
        /// 获取导航栏左侧滑过背景
        /// </summary>
        /// <returns></returns>
        public static Image GetNavEnterImage()
        {
            return Resource1.navEnter2;
        }
        /// 获取导航栏左侧滑过背景(选中状态)
        /// </summary>
        /// <returns></returns>
        public static Image GetNavEnterSelectedImage()
        {
            return Resource1.navEnterSelected2;
        }
        /// <summary>
        /// 获取导航栏左侧按钮选中背景
        /// </summary>
        /// <returns></returns>
        public static Image GetNavSelectImage()
        {
            return Resource1.navSelected2;
        }
        /// <summary>
        /// 获取患者信息图标
        /// </summary>
        /// <returns></returns>
        public static Image GetPatientInfo()
        {
            return Resource1.患者信息;
        }
        /// <summary>
        /// 获取床位管理图标
        /// </summary>
        /// <returns></returns>
        public static Image GetBedManage()
        {
            return Resource1.床位管理;
        }
        /// <summary>
        /// 获取文档管理图标
        /// </summary>
        /// <returns></returns>
        public static Image GetDocManage()
        {
            return Resource1.文档管理;
        }
        /// <summary>
        /// 获取医嘱处理图标
        /// </summary>
        /// <returns></returns>
        public static Image GetOrderExecute()
        {
            return Resource1.医嘱处理;
        }
        /// <summary>
        /// 获取整体护理图标
        /// </summary>
        /// <returns></returns>
        public static Image GetTotalCare()
        {
            return Resource1.整体护理;
        }
        /// <summary>
        /// 获取护理文书图标
        /// </summary>
        /// <returns></returns>
        public static Image GetCareDoc()
        {
            return Resource1.特护单;
        }
        /// <summary>
        /// 获取电子病历图标
        /// </summary>
        /// <returns></returns>
        public static Image GetElectronicRecords()
        {
            return Resource1.电子病历;
        }
        /// <summary>
        /// 获取统计查询图标
        /// </summary>
        /// <returns></returns>
        public static Image GetStatistics()
        {
            return Resource1.统计分析;
        }
        /// <summary>
        /// 获取科室维护图标
        /// </summary>
        /// <returns></returns>
        public static Image GetDeptManage()
        {
            return Resource1.科室管理;
        }
        /// <summary>
        /// 获取系统配置图标
        /// </summary>
        /// <returns></returns>
        public static Image GetConfig()
        {
            return Resource1.系统配置;
        }
        /// <summary>
        /// 获取同步患者图标
        /// </summary>
        /// <returns></returns>
        public static Image GetSysPatient()
        {
            return Resource1.同步患者;
        }
        /// <summary>
        /// 获取锁定系统图标
        /// </summary>
        /// <returns></returns>
        public static Image GetLockScreen()
        {
            return Resource1.锁定系统;
        }
        /// <summary>
        /// 获取数据分析图标
        /// </summary>
        /// <returns></returns>
        public static Image GetDataAnalysis()
        {
            return Resource1.数据分析;
        }
        /// <summary>
        /// 获取患者数据图标
        /// </summary>
        /// <returns></returns>
        public static Image GetPatientData()
        {
            return Resource1.患者数据;
        }
        /// <summary>
        /// 获取评分图标
        /// </summary>
        /// <returns></returns>
        public static Image GetScore()
        {
            return Resource1.评分;
        }
        /// <summary>
        /// 获取感染管理图标
        /// </summary>
        /// <returns></returns>
        public static Image GetInfectionManage()
        {
            return Resource1.感染管理;
        }
        /// <summary>
        /// 获取常用功能图标
        /// </summary>
        /// <returns></returns>
        public static Image GetCommFunc()
        {
            return Resource1.常用功能;
        }
        /// <summary>
        /// 获取重症监护登陆图片
        /// </summary>
        /// <returns></returns>
        public static Image GetNurseLogin()
        {
            return Resource1.重症监护背景;
        }
        /// <summary>
        /// 获取重症监护登陆界面标题
        /// </summary>
        /// <returns></returns>
        public static Image GetNurseLoginTitle()
        {
            return Resource1.重症监护标题;
        }
        /// <summary>
        /// 获取重症辅诊登陆界面标题
        /// </summary>
        /// <returns></returns>
        public static Image GetDoctorLoginTitle()
        {
            return Resource1.重症辅诊标题;
        }
        /// <summary>
        /// 获取护理评估
        /// </summary>
        /// <returns></returns>
        public static Image GetNurseScore()
        {
            return Resource1.护理评分;
        }
        /// <summary>
        /// 获取重症辅诊登陆图片
        /// </summary>
        /// <returns></returns>
        public static Image GetDoctorLogin()
        {
            return Resource1.重症辅诊背景;
        }
        /// <summary>
        /// 获取重症辅诊登陆图片
        /// </summary>
        /// <returns></returns>
        public static Image GetStaticsLogin()
        {
            return Resource1.重症统计查询系统;
        }
        /// <summary>
        /// 获取登陆按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginOk()
        {
            return Resource1.登录1;
        }
        /// <summary>
        /// 获取登陆按钮图片2
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginOk2()
        {
            return Resource1.登录2;
        }
        /// <summary>
        /// 获取登陆按钮图片3
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginOk3()
        {
            return Resource1.登录3;
        }
        /// <summary>
        /// 获取取消按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginCancel()
        {
            return Resource1.取消1;
        }
        /// <summary>
        /// 获取取消按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginCancel2()
        {
            return Resource1.取消2;
        }
        /// <summary>
        /// 获取取消按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetLoginCancel3()
        {
            return Resource1.取消3;
        }

        /// <summary>
        /// 获取最大化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMaxImage1()
        {
            return Resource1.btnMax_Image1;
        }
        /// <summary>
        /// 获取最大化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMaxImage2()
        {
            return Resource1.btnMax_Image2;
        }
        /// <summary>
        /// 获取最大化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMaxImage3()
        {
            return Resource1.btnMax_Image3;
        }

        /// <summary>
        /// 获取最小化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMinImage1()
        {
            return Resource1.btnMin_Image1;
        }
        /// <summary>
        /// 获取最小化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMinImage2()
        {
            return Resource1.btnMin_Image2;
        }
        /// <summary>
        /// 获取最小化按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnMinImage3()
        {
            return Resource1.btnMin_Image3;
        }

        /// <summary>
        /// 获取还原按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnRestoreImage1()
        {
            return Resource1.btnRestore_Image1;
        }
        /// <summary>
        /// 获取还原按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnRestoreImage2()
        {
            return Resource1.btnRestore_Image2;
        }
        /// <summary>
        /// 获取还原按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnRestoreImage3()
        {
            return Resource1.btnRestore_Image3;
        }

        /// <summary>
        /// 获取关闭按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnCloseImage1()
        {
            return Resource1.btnClose_Image1;
        }
        /// <summary>
        /// 获取关闭按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnCloseImage2()
        {
            return Resource1.btnClose_Image2;
        }
        /// <summary>
        /// 获取关闭按钮图片
        /// </summary>
        /// <returns></returns>
        public static Image GetbtnCloseImage3()
        {
            return Resource1.btnClose_Image3;
        }

        /// <summary>
        /// 切换科室图片
        /// </summary>
        /// <returns></returns>
        public static Image ChangeWard()
        {
            return Resource1.切换科室;
        }

        public static Image GetCardBackGroundImage()
        {
            return Resource1.card_background_1x;
        }

        public static Image GetSelectCardBackGroundImage()
        {
            return Resource1.card_background2x;
        }

        public static Image GetFemaleImage()
        {
            return Resource1.avatar_female_1x;
        }

        public static Image GetMaleImage()
        {
            return Resource1.avatar_male_1x;
        }

        public static Image GetMaleImageEx()
        {
            return Resource1.male;
        }

        public static Image GetFemaleImageEx()
        {
            return Resource1.femal_checked;
        }

        public static Image GetYaChuangDImage()
        {
            return Resource1.疮;
        }

        public static Image GetDieDaoDImage()
        {
            return Resource1.跌;
        }

        public static Image GetGeLiDImage()
        {
            return Resource1.隔;
        }

        public static Image GetGuoMinDImage()
        {
            return Resource1.敏;
        }

        public static Image GetXianZhiDImage()
        {
            return Resource1.限;
        }
        public static Image getKongChuangImage()
        {
            return Resource1.空床;
        }
        #region new
        public static Image GetBedNormalImage()
        {
            return Resource1.Bed_normal;
        }

        public static Image GetBedSelectedImage()
        {
            return Resource1.Bed_selected;
        }

        public static Image GetBedManageNormalImage()
        {
            return Resource1.BedManage_normal;
        }

        public static Image GetBedManageSelectedImage()
        {
            return Resource1.BedManage_selected;
        }

        public static Image GetButtonHoverImage()
        {
            return Resource1.button_hover;
        }

        public static Image GetButtonNormalImage()
        {
            return Resource1.button_normal;
        }

        public static Image GetButtonSelectedImage()
        {
            return Resource1.button_selected;
        }

        public static Image GetConfigImage()
        {
            return Resource1.config;
        }

        public static Image GetConfigSelectedImage()
        {
            return Resource1.config_selected;
        }

        public static Image GetDashBoardImage()
        {
            return Resource1.dashboard;
        }

        public static Image GetDashBoardSelectedImage()
        {
            return Resource1.dashboard_selected;
        }

        public static Image GetDossierQueryImage()
        {
            return Resource1.dossierQuery;
        }

        public static Image GetDossierQuerySelectedImage()
        {
            return Resource1.dossierQuery_selected;
        }

        public static Image GetEMRNormalImage()
        {
            return Resource1.EMR_normal;
        }

        public static Image GetEMRSelectedImage()
        {
            return Resource1.EMR_selected;
        }

        public static Image GetLockImage()
        {
            return Resource1._lock;
        }

        public static Image GetLockSelectedImage()
        {
            return Resource1.lock_selected;
        }

        public static Image GetPatientNormalImage()
        {
            return Resource1.Patient_normal;
        }

        public static Image GetPatientSelectedImage()
        {
            return Resource1.Patient_selected;
        }

        public static Image GetPrnNormalImage()
        {
            return Resource1.prn_normal;
        }

        public static Image GetPrnSelectedImage()
        {
            return Resource1.prn_selected;
        }

        public static Image GetZTHLImage()
        {
            return Resource1.zthl;
        }

        public static Image GetZTHLSelectedImage()
        {
            return Resource1.zthl_selected;
        }

        public static Image GetSubTabSelectedImage()
        {
            return Resource1.subTab_selected;
        }

        public static Image GetSubTabSelected1Image()
        {
            return Resource1.subTab_selected1;
        }

        public static Image GetEmptyBedImage()
        {
            return Resource1.user;
        }

        public static Image GetBedCardImage()
        {
            return Resource1.bedCard;
        }

        public static Image GetSelectedBedCardImage()
        {
            return Resource1.bedCard_selected;
        }

        public static Image GetNotSelectedBedCardImage()
        {
            return Resource1.bedCard_notselected;
        }

        public static Image GetDsjNormalImage()
        {
            return Resource1.dsj_normal;
        }

        public static Image GetDsjSelectedImage()
        {
            return Resource1.dsj_selected;
        }

        public static Image GetElseNormalImage()
        {
            return Resource1.else_normal;
        }

        public static Image GetElseSelectedImage()
        {
            return Resource1.else_selected;
        }


        public static Image GetTwoMenuNormalImage()
        {
            return Resource1.TwoNormal;
        }

        public static Image GetTwoMenuSelectedImage()
        {
            return Resource1.TwoSelected;
        }
        #endregion
    }
}
