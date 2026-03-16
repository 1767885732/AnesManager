using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Wis.Anes.Framework.Controls
{
    public class MedPopupForm: Form
    {

        #region 属性

        /// <summary>
        /// 钩子引发的关闭事件
        /// </summary>
        public HookClosedEventHandle HookClosed = null;
        private bool _active = false;
        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
            }
        }
        
        #endregion

        #region 构造方法

        public MedPopupForm() : base()
        {
            base.FormBorderStyle = FormBorderStyle.None;
            base.TopMost = true;
            base.ShowInTaskbar = false;
        }

        #endregion

        #region 方法

        protected override void  OnLoad(EventArgs e)
        {
 	         base.OnLoad(e);
             //RegistHook();
         }

        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    UnRegistHook();
        //}

        public void Popup(int x, int y,Control control)
        {
            SetControl(control);
            //control.MouseLeave += new System.EventHandler(this.MedPopupForm_MouseLeave);
            control.LostFocus += new System.EventHandler(this.MedPopupForm_MouseLeave);
            this.Opacity = 0;
            this.Show();
            this.Location = new Point(x, y);
            this.Opacity = 10;
        }

        private void SetControl(Control control)
        {
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        #endregion

        #region 钩子相关
        //private void RegistHook()
        //{
        //    if (hHook == 0)
        //    {
        //        MyProcedure = new HookProc(this.MouseHookProc);
        //        //这里挂节钩子
        //        hHook = SetWindowsHookEx(WH_MOUSE_LL, MyProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
        //        if (hHook == 0)
        //        {
        //        }
        //    }
        //}

        //private void UnRegistHook()
        //{
        //    bool ret = UnhookWindowsHookEx(hHook);
        //    if (ret == false)
        //    {
        //    }
        //    hHook = 0;
        //}

        /// <summary>
        /// 钩子触发事件
        /// </summary>
        /// <param name="nCode">事件代码</param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        //private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
        //    if (nCode < 0)
        //    {
        //        return CallNextHookEx(hHook, nCode, wParam, lParam);
        //    }
        //    else
        //    {
        //        if ((wParam.ToInt32() == WM_LBUTTONDOWN) || (wParam.ToInt32() == WM_RBUTTONDOWN) || (wParam.ToInt32() == WM_MBUTTONDOWN))
        //        {
        //            Rectangle rect = new Rectangle(this.Left, this.Top, this.Width, this.Height);
        //            if (!rect.Contains(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y))
        //            {
        //                this.Close();
        //                if (HookClosed != null) HookClosed(new Point(MyMouseHookStruct.pt.x,MyMouseHookStruct.pt.y));
        //            }
        //        }
        //        return CallNextHookEx(hHook, nCode, wParam, lParam);
        //    }
        //}

        #endregion

        #region 定义段

        [StructLayout(LayoutKind.Sequential)]
        private class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        private class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        private delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void HookClosedEventHandle(Point mousePoint);
        //定义钩子句柄
        private static int hHook = 0;
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;
        //定义钩子类型
        private const int WH_MOUSE_LL = 14;
        private HookProc MyProcedure;
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MedPopupForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MedPopupForm";
            this.ResumeLayout(false);

        }

        private void MedPopupForm_MouseLeave(object sender, EventArgs e)
        {
            if (Active)
            {
                this.Close();
            }
            
        }

    }
}
