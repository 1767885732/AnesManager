using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;

namespace Wis.Anes.Utilities
{
    public partial class LoadMask : Form
    {

        private LoadMask()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 使用计数器，
        /// 每调用一次Show加一，
        /// 调用Close时减一，当计数器等于0时，关闭窗口
        /// </summary>
        static volatile int counter;
        static LoadMask mask ;
        static object syncObj = new object();

        /// <summary>
        ///  显示进度条
        /// </summary>
        public static void Show()
        {
            if (counter == 0)
            {
                //这个++必须在调用线程开始前调用，确保线程开始前就完成++操作。
                counter++;
                Thread thread = new Thread(new ThreadStart(ShowMask));
                thread.Priority = ThreadPriority.Highest;
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                //这个++也是必须的，每调用一次Show函数Counter必须加一
                counter++;
            }
        }


        private static void ShowMask()
        {
            if (counter > 0)
            {
                if (mask == null)
                {
                    lock (syncObj)
                    {
                        if (mask == null)
                        {
                            mask = new LoadMask();
                            mask.ShowDialog();                            
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 隐藏进度条
        /// </summary>
        public static void Hide()
        {
            CloseMask();
        }

        private static void CloseMask()
        {
            //只在大于零的时候减一
            if (counter > 0)
                counter--;
            if (counter == 0)
            {
                if (mask != null)
                {
                    mask.DialogResult = DialogResult.OK;
                    mask = null;
                    return;
                }
            }
        }

        private void LoadMask_Load(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                DialogResult = DialogResult.OK;
                mask = null;
                return;
            }
        }

    }
}