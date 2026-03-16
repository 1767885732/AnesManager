/*----------------------------------------------------------------
// 北京拓扑工厂科技发展有限公司
// 文件名：SplashScreen.cs
// 文件功能描述：等待界面
// 创建标识：XXX-2008-10-23
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Wis.Anes.Framework.Configurations;

namespace Wis.Anes
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.Controls.Remove(this.panel1);
            this.pictureBox1.Controls.Add(panel1);
            //this.WindowState = FormWindowState.Maximized;

            Control.CheckForIllegalCrossThreadCalls = false;
            SplashFormHelper.HideFormEventHandler += new EventHandler(SplashFormHelper_HideFormEventHandler);
            SplashFormHelper.MessageNotifyHandler += new EventHandler(SplashFormHelper_MessageNotifyHandler);


        }


        public delegate void SetTextDelegate(string text);
        public delegate void SetStyleDelegate(string style);




        public Thread ExecuteThread = null;
        void SplashFormHelper_HideFormEventHandler(object sender, EventArgs e)
        {

            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;

            timer1.Stop();
            timer1.Dispose();

            //if (ExecuteThread != null)
            //{
            //    try
            //    {
            //        try
            //        {

            //            //ExecuteThread.Abort();
            //        }
            //        catch (ThreadAbortException ex)
            //        {

            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //        finally//还是会被抛出异常
            //        {
            //            ExecuteThread.Join();
            //        }
            //    }
            //    catch (Exception ex)
            //    {


            //    }
            //    finally
            //    {

            //    }

            //}




        }

        void SplashFormHelper_MessageNotifyHandler(object sender, EventArgs e)
        {
            string msg = "";
            if (sender != null)
            {
                msg = sender.ToString();
            }


            if (lbMsg.InvokeRequired)
            {
                if (!msg.ToLower().Equals("topmost") && msg != "")
                {
                    //lbMsg.Text = msg;

                    lbMsg.Invoke(new SetTextDelegate(SetTextMsg), msg);
                }
                else
                {
                    this.Invoke(new SetStyleDelegate(SetStyleMsg), msg);

                }
            }


        }
        private void SplashForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = ApplicationConfiguration.GetSkinImage("Loading.jpg");
            pictureBox1.Image = ApplicationConfiguration.GetSkinImage("qidongzhong.png");

            panel1.Width = Width / 4;
            panel1.Left = Width / 2 -30;
            panel1.Top = (Height) / 2 + 60;

            //panel1.Left = (Width - panel1.Width) / 2;
            //panel1.Top = (Height - panel1.Height) / 2 + 160;

        }

        public void SetTextMsg(string msg)
        {
            lbMsg.Text = msg;
        }
        public void SetStyleMsg(string msg)
        {
            if (msg.ToLower().Equals("topmost"))
            {
                this.TopMost = true;
            }
        }
        private void MessageLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }

    public class SplashFormHelper
    {
        public static void HideSplashForm()
        {
            if (HideFormEventHandler != null)
                HideFormEventHandler(null, EventArgs.Empty);
        }

        public static event EventHandler HideFormEventHandler;
        public static event EventHandler MessageNotifyHandler;
        public static void MessageNotify(string msg)
        {


            if (MessageNotifyHandler != null)
                MessageNotifyHandler(msg, EventArgs.Empty);

        }
    }

    public class MessageEventArgs : EventArgs
    {
        public string MessageEvent;

    }
}


