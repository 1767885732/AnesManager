using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Com.ICIS.Icu
{

    public partial class WaitFrm : DevExpress.XtraEditors.XtraForm
    {
        public WaitFrm()
        {
            InitializeComponent();
         
            SplashFormCallBackNotifier.Complete += delegate
            {
                
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(CloseForm));
                }
                else
                {
                    CloseForm();
                }
              
            };
         
        }

       
        private void CloseForm()
        {
           
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
            
        }

        private bool _isShowing = false;

        private void WaitFrm_Load(object sender, EventArgs e)
        {
            _isShowing = true;
        }

        public bool IsShowing
        {
            get { return _isShowing; }
        }
    }
    /// <summary>
    /// 等待界面线程帮助类
    /// </summary>
    public class SplashFormCallBackNotifier
    {
        public static event EventHandler Complete;
        /// <summary>
        /// 主线程执行结束，回调等待界面的线程关闭并释放等待界面
        /// </summary>
        public static void DoCallBack()
        {
            if (Complete != null)
                Complete(null, EventArgs.Empty);
        }
    }
}