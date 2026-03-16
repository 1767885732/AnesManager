/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：Program.cs
// 文件功能描述：Program
// 创建标识：XXX-2008-10-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wis.Anes.Framework;
using Wis.Anes;
using Wis.Anes.Framework.Controls;
using System.Threading;
using DevExpress.LookAndFeel;
using Wis.Anes.FrameWork;
using Medicalsystem.Docare.Updater.Connection;

namespace AnesManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DevHandlerLib.DevHandler.CloseDevWindowKeepRunning();
            ExtendApplicationContext.Current.ProgramArgs = args;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SkinProject1).Assembly);
            //UserLookAndFeel.Default.SetSkinStyle("Office 2013 White");//皮肤主题
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            string appId = "ANESPERSONAL";
            //2026-1-30 刘超  临时调试取消自动更新
           //AutoUpdater.Run(appId);

            //系统当前进程
            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemBeforeLogin;
            LoginAnes loginForm = new LoginAnes();
            
            DialogResult dialogResult = loginForm.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemLoginErr;
                Application.Exit();
                return;
            }
            ExtendApplicationContext.Current.SystemCurrentProcess = ProgramProcess.SystemLoginOK;
            
            //splashForm.TopMost = true;
            //SplashForm splashForm = new SplashForm();
            //System.Threading.ThreadPool.QueueUserWorkItem(delegate
            //{

            //    splashForm.ShowDialog();
               
            //});
         
            Thread t = new Thread(new ThreadStart(ShowSplashForm));
            t.Name = "ShowSplashFormThread";
            t.IsBackground = true;
            t.Start();

            //Application.Run(new MainForm());
            ApplicationManager.OpenDialogForm("NursesStation", null, typeof(ShellFrm));
        }
        private static void ShowSplashForm()
        {
            Thread tt = Thread.CurrentThread;
            SplashForm splashForm = new SplashForm();
            splashForm.ExecuteThread = tt;
            splashForm.ShowDialog();
        }
       
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            ExceptionHandler.Handle(ex);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception.StackTrace != null && e.Exception.StackTrace.Contains("DevExpress.XtraGrid.Views.Grid.Handler.GridHandler.OnKeyDown(KeyEventArgs e)"))
            {
                //ExceptionHandler.Handle(e.Exception,false);
            }
            else
            {


                    ExceptionHandler.Handle(e.Exception);


            }
        }
    }
}
