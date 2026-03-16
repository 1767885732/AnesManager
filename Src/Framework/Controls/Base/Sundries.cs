/*----------------------------------------------------------------
      // Copyright (C) 2005 北京拓扑工厂科技发展有限公司
      // 文件名：Sundries.cs
      // 文件功能描述：杂项
      //
      // 
      // 创建标识：XXX-2007-12-01
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Data;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using Wis.Anes.Framework.Views;
using Wis.Anes.Framework.Utilities;
using System.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace Wis.Anes.Framework.Controls.Base
{
    public class Sundries
    {
        /// <summary>
        /// 标题常量
        /// </summary>
        public const string CAPTION = " 手术麻醉临床信息系统";

        private static SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
        private static string Key = "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*Mike2008h%(HilJ$lhj!y6&(*jkP87jH7";
        private static long _startTime = -1;
        private static long _stopTime = -1;
        private static long _freq;

        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private static byte[] GetLegalKey()
        {
            string sTemp = Key;
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private static byte[] GetLegalIV()
        {
            string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er5Mike20087HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        public static string Decrypto(string Source)
        {
            try
            {
                byte[] bytIn = Convert.FromBase64String(Source);
                MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                string result = sr.ReadToEnd();
                if (result.EndsWith("mike2008"))
                {
                    return result.Remove(result.Length - 8);
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                return Source;
            }
        }

        /// <summary>
        /// 运行Dos命令并得到结果
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string RunCmd(string command)
        {
            //實例一個Process類，啟動一個獨立進程
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：

            p.StartInfo.FileName = "cmd.exe";           //設定程序名
            p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數
            p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
            p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
            p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
            p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口

            p.Start();   //啟動

            //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
            //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機

            return p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果
        }

        /// <summary>
        /// 运行EXE文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="paramList">参数数组</param>
        /// <returns></returns>
        public static void RunExe(string fileName, string paramList)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = fileName;             //設定程序名
            p.StartInfo.Arguments = paramList;    //設定程式執行參數
            p.Start();
        }

        /// <summary>
        /// HL7专用Log
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="type"></param>
        /// <param name="src"></param>
        /// <param name="detail"></param>
        /// <param name="org"></param>
        public static void Log(string mes, string type, string src, string detail, string org)
        {
            // Create an EventLog instance and assign its source.
            //EventLog myLog = new EventLog();
            //myLog.Source = "麻醉系统接口";

            StringBuilder str = new StringBuilder();
            str.Append(mes);
            str.Append(",");
            str.Append(type);
            str.Append(",");
            str.Append(src);
            str.Append(",");
            str.Append(detail);
            str.Append(",");
            str.Append(org);

            // Write an informational entry to the event log.    
            //myLog.WriteEntry(str.ToString(), EventLogEntryType.Information);

            try
            {
                Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketClient.Connect("127.0.0.1", 1211);
                //Socket socketClient1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //socketClient1.Connect("127.0.0.1", 9431);
                byte[] buffer = Encoding.UTF8.GetBytes(str.ToString());
                socketClient.Send(buffer);
                //socketClient1.Send(buffer);
                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Close();
                //socketClient1.Shutdown(SocketShutdown.Both);
                //socketClient1.Close();
            }
            catch
            {
            }
            FileStream fs = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("yyyyMMdd") + "Log.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            str.Insert(0, ",");
            str.Insert(0, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.WriteLine(str.ToString());
            sw.Flush();
            sw.Close();
            sw.Dispose();
            fs.Dispose();
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text)
        {
            return MessageBox(text, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, int displaySeconds)
        {
            return MessageBox(text, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, displaySeconds);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, MessageBoxIcon icon)
        {
            return MessageBox(text, CAPTION, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox(text, caption, buttons, icon, MessageBoxDefaultButton.Button1, 0);
        }

        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="text">提示文本</param>
        /// <param name="caption">标题</param>
        /// <param name="buttons">按钮</param>
        /// <param name="icon">图标</param>
        /// <returns>对话框选择结果</returns>
        public static DialogResult MessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, int displaySeconds)
        {
            return MessageBoxForm.Show(text, caption, buttons, icon, displaySeconds);
        }

        ///// <summary>
        ///// 简单输入(选择)框
        ///// </summary>
        ///// <param name="text">提示内容</param>
        ///// <param name="caption">框标题</param>
        ///// <param name="initValue">初始值</param>
        ///// <returns>输入选择结果</returns>
        //public static object SingleInputSelect(string text, string caption, object initValue)
        //{
        //    return new Com.ICIS.Common.Controls.MessageBoxForm().SingleInputSelect(text, caption, initValue);
        //}

        //public struct InputStruct
        //{
        //    public string Text;
        //    public string Caption;
        //    public object InitValue;
        //    public string InputFormat;
        //}

        /// <summary>
        /// 复合输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用或者*号表示文本框为密码输入</param>
        /// <returns>输入选择结果</returns>
        public static object[] MultiInputSelect(InputStruct[] inputParameters)
        {
            InputStruct[] inputP = new InputStruct[inputParameters.Length];
            for (int i = 0; i < inputParameters.Length; i++)
            {
                inputP[i].Text = inputParameters[i].Text;
                inputP[i].Caption = inputParameters[i].Caption;
                inputP[i].InputFormat = inputParameters[i].InputFormat;
                inputP[i].InitValue = inputParameters[i].InitValue;
            }
            return new MessageBoxForm().MultiInputSelect(inputP);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, string caption, object initValue, string inputFormat)
        {
            return new MessageBoxForm().SingleInputSelect(text, caption, initValue, inputFormat);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="caption">框标题</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <param name="isCompleted">是否本频次结束</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, string caption, object initValue, string inputFormat, bool isCompleted)
        {
            return new MessageBoxFormEx().SingleInputSelect(text, caption, initValue, inputFormat, isCompleted);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="initValue">初始值</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, object initValue)
        {
            return new MessageBoxForm().SingleInputSelect(text, CAPTION, initValue);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, object initValue, string inputFormat)
        {
            return SingleInputSelect(text, CAPTION, initValue, inputFormat);
        }

        /// <summary>
        /// 简单输入(选择)框
        /// </summary>
        /// <param name="text">提示内容</param>
        /// <param name="initValue">初始值</param>
        /// <param name="inputFormat">输入格式-日期输入时使用</param>
        /// <param name="isoneCompleted">是否本频次结束</param>
        /// <returns>输入选择结果</returns>
        public static object SingleInputSelect(string text, object initValue, string inputFormat, bool isoneCompleted)
        {
            return SingleInputSelect(text, CAPTION, initValue, inputFormat, isoneCompleted);
        }

        /// <summary>
        /// 显示客户对话框
        /// </summary>
        /// <param name="control">客户添加控件</param>
        /// <param name="caption">标题</param>
        public static void ShowCustomDialog(Control control, string caption)
        {
            BaseFrm frm = new BaseFrm();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Width = Screen.PrimaryScreen.Bounds.Width - 20;
            frm.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            frm.ShowInTaskbar = false;
            frm.Left = 20;
            frm.Top = 5;
            frm.Text = caption;
            Panel panelBottom = new Panel();
            MedButtonEx buttonOK = new MedButtonEx();
            buttonOK.Text = "确定";
            buttonOK.ForeColor = System.Drawing.Color.Black;
            buttonOK.Top = 8;
            buttonOK.DialogResult = DialogResult.OK;
            panelBottom.Height = 40;
            panelBottom.Left = 5;
            panelBottom.Controls.Add(buttonOK);
            panelBottom.Resize +=
                new EventHandler(
                    delegate (object sender, EventArgs e)
                    {
                        buttonOK.Left = (panelBottom.Width - buttonOK.Width) / 2;
                    }
                );
            frm.Controls.Add(panelBottom);
            if (control != null)
            {
                frm.Controls.Add(control);
                control.Left = 5;
                control.Top = 30;
            }
            frm.Resize +=
                new EventHandler(
                    delegate (object sender, EventArgs e)
                    {
                        panelBottom.Top = frm.Height - panelBottom.Height - 5;
                        panelBottom.Width = frm.Width - 10;
                        if (control != null)
                        {
                            control.Width = frm.Width - 10;
                            control.Height = panelBottom.Top - control.Top;
                        }
                    }
                );
            frm.ShowDialog();
        }

        /// <summary>
        /// 显示客户对话框
        /// </summary>
        /// <param name="sourceTable">数据源</param>
        /// <param name="caption">标题</param>
        public static void ShowCustomDialog(System.Data.DataTable sourceTable, string caption)
        {
            MedDataGridView gridView = new MedDataGridView();
            gridView.ReadOnly = true;
            gridView.RowHeadersVisible = false;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridView.AllowUserToAddRows = false;
            gridView.AllowUserToDeleteRows = false;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            gridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 154, 82);
            gridView.DataSource = sourceTable;
            ShowCustomDialog(gridView, caption);
        }

        private static RegistryKey RegistryForceOpenSubKey(RegistryKey registryKey, string key, bool writable)
        {
            RegistryKey result = registryKey.OpenSubKey(key, writable);
            if (result == null)
            {
                result = registryKey.CreateSubKey(key);
            }
            return result;
        }

        /// <summary>
        /// 锁定/解锁Ctrl+Alt+Del组合按键
        /// </summary>
        /// <param name="Locked"></param>
        public static void TaskMgrCtrl(bool Locked)
        {
            int intValue = ((Locked) ? -1 : 0);

            string key = @"software\microsoft\windows\currentversion\policies\";

            RegistryForceOpenSubKey(Registry.CurrentUser, key + "system", true).SetValue("DisableTaskMgr", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoLogoff", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoClose", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "system", true).SetValue("DisableLockWorkstation", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "system", true).SetValue("DisableChangePassword", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoViewContextMenu", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoChangeStartMenu", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoRun", intValue);
            RegistryForceOpenSubKey(Registry.CurrentUser, key + "Explorer", true).SetValue("NoSetTaskbar", intValue);
        }

        /// <summary>
        /// 计时开始
        /// </summary>
        public static void TimeStart()
        {
            _startTime = 0;
            _stopTime = 0;
            if (WinAPI.QueryPerformanceFrequency(out _freq) == false)
            {
                //   不支持高精度计时   
                return;
            }
            Thread.Sleep(0);
            WinAPI.QueryPerformanceCounter(out _startTime);
        }

        // 计时结果 单位秒
        public static double TimeResult()
        {
            if (_startTime == -1)
            {
                return -1;
            }
            WinAPI.QueryPerformanceCounter(out _stopTime);
            return (double)(_stopTime - _startTime) / (double)_freq;
        }

        /// <summary>
        /// 转数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns>结果</returns>
        public static object PraseDouble(DataRow dataRow, string columnName)
        {
            object result = dataRow[columnName];
            if ((result != null) && (result.ToString() != ""))
            {
                result = double.Parse(result.ToString());
            }
            return result;
        }
        /// <summary>
        /// 转字符串
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns>结果</returns>
        public static object PraseString(DataRow dataRow, string columnName)
        {
            object result = dataRow[columnName];
            if (result != null)
            {
                result = result.ToString();
                if (((string)result).StartsWith(PrintCell.LINESPLITCHAR))
                {
                    result = ((string)result).Substring(1);
                }
            }
            return result;
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="birthdayDate">出生日期</param>
        /// <returns>结果</returns>
        public static int CalcAge(DateTime birthdayDate)
        {
            DateTime curDate = DateTime.Now;
            return curDate.Year - birthdayDate.Year - (((curDate.Month < birthdayDate.Month) || ((curDate.Month == birthdayDate.Month) && (curDate.Day < birthdayDate.Day))) ? 1 : 0);
        }


        public static string CalcAge_Detail(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty;                         // 年龄的字符串表示
            int intYear = 0;                                    // 岁
            int intMonth = 0;                                    // 月
            int intDay = 0;                                    // 天

            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;

            // 格式化年龄输出
            if (intYear > 6)
            {
                strAge = intYear.ToString() + "岁";
            }

            else if (intYear > 0 && intYear <= 6)
            {
                strAge = intYear.ToString() + "岁" + intMonth.ToString() + "月" + intDay.ToString() + "天";
            }

            else if (intYear < 1)
            {
                if (intMonth > 0)
                {
                    strAge = intMonth.ToString() + "月" + intDay.ToString() + "天";
                }
                else
                {
                    strAge = intDay.ToString() + "天";
                }
            }

            return strAge;
        }


        /// <summary>
        /// 计算年龄(南平92医院)
        /// </summary>
        /// <param name="birthdayDate">出生日期</param>
        /// <returns>结果</returns>
        public static string CalcAgeNanPing92(DateTime birthdayDate)
        {
            try
            {
                //2010-08-23
                //≤28天（或1月以内） 按天 
                //1岁以内 按几月几天 
                //12周岁以内 按几岁几月（月份按四舍五入）
                DateTime curDate = DateTime.Now;
                int nYear = curDate.Year - birthdayDate.Year;
                int nMonth = curDate.Month - birthdayDate.Month;
                int nDay = curDate.Day - birthdayDate.Day;

                int nDaysAMonth = 0;
                int nMonthJudge = 0;
                int nYearJudge = 0;
                if (nDay < 0)
                {
                    nYearJudge = curDate.Year;
                    nMonthJudge = curDate.Month - 1;
                    if (nMonthJudge == 0)
                    {
                        nMonthJudge = 12;
                        nYearJudge -= 1;
                    }
                }
                else
                {
                    nYearJudge = curDate.Year;
                    nMonthJudge = curDate.Month;
                }

                switch (nMonthJudge)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        nDaysAMonth = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        nDaysAMonth = 30;
                        break;
                    default:
                        nDaysAMonth = ((nYearJudge % 4 == 0) ? 29 : 28);
                        break;
                }

                if (nDay < 0)
                {
                    nMonth -= 1;
                    nDay += nDaysAMonth;
                }
                if (nMonth < 0)
                {
                    nYear -= 1;
                    nMonth += 12;
                }

                //年龄计算是负的话，返回""
                if (nYear < 0 || nMonth < 0 || nDay < 0)
                {
                    return "";
                }

                //≤28天（或1月以内） 按天 
                if (nYear == 0 && nMonth == 0)
                {
                    return nDay + "天";
                }
                //1岁以内 按几月几天
                else if (nYear == 0)
                {
                    string sReturn = "";
                    sReturn += nMonth + "月";
                    if (nDay > 0)
                    {
                        sReturn += nDay + "天";
                    }
                    return sReturn;
                }
                //12周岁以内 按几岁几月（月份按四舍五入）
                else if (nYear < 12)
                {
                    string sReturn = "";
                    sReturn += nYear + "岁";

                    //四舍五入计算用
                    if ((double)nDay / nDaysAMonth >= 0.5)
                    {
                        nMonth += 1;
                    }

                    if (nMonth > 0)
                    {
                        sReturn += nMonth + "月";
                    }
                    return sReturn;

                }
                else
                {
                    return nYear + "岁";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="birthdayDate"></param>
        /// <returns>*岁*个月</returns>
        public static string CalculateAge(DateTime birthdayDate, DateTime today)
        {
            double a = (DateTime.Now - birthdayDate).TotalDays;
            double aYear = Math.Floor(a / 365);
            double C = a % 365;
            double aMonth = Math.Floor(C / 30);
            double aDay = Math.Floor(C % 30);
            if (aYear < 1)
            {
                return aMonth.ToString() + "个月";//+ aDay.ToString() + "天";   
            }
            else
            {
                return aYear.ToString() + "岁  ";// + aMonth.ToString() + "个月   " + aDay.ToString() + "天";
            }
        }

        public static void BindLookUpEdit(LookUpEdit lookUpEdit, string valueMember, string displayMember, DataTable dataSource, string viewFieldName, string viewCaption)
        {
            lookUpEdit.Properties.ValueMember = valueMember;
            lookUpEdit.Properties.DisplayMember = displayMember;
            lookUpEdit.Properties.DataSource = dataSource;

            LookUpColumnInfoCollection colCollection1 = lookUpEdit.Properties.Columns;
            colCollection1.Clear();
            colCollection1.Add(new LookUpColumnInfo(viewFieldName, viewCaption));

            lookUpEdit.ItemIndex = 0;

            lookUpEdit.Properties.NullText = string.Empty;
        }

        public static bool SaveTable(
            DataTable table,
            BindingSource bs,
            GridView gv,
            IDictionary<string, string> requiredFieldsDict,
            Action<DataTable> saveDataFun,
            ref bool dataChanged,
        SimpleButton btnSave)
        {
            if (table == null)
                return false;

            bs.EndEdit();
            bs.CurrencyManager.EndCurrentEdit();

            gv.ClearColumnErrors();

            //必填验证
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                foreach (KeyValuePair<string, string> item in requiredFieldsDict)
                {
                    string text = gv.GetRowCellDisplayText(i, item.Key);

                    if (string.IsNullOrEmpty(text))
                    {
                        gv.FocusedRowHandle = i;
                        gv.SelectCell(i, gv.Columns[item.Key]);
                        gv.SetColumnError(gv.Columns[item.Key], item.Value);

                        return false;
                    }
                }
            }

            //保存
            saveDataFun(table);

            dataChanged = false;

            table.AcceptChanges();

            btnSave.Enabled = false;

            Sundries.MessageBox("保存成功！");

            return true;
        }

        public static bool DeleteTable(
            DataTable table,
            BindingSource bs,
            GridView gv,
            Action<DataRow> deleteDataFun,
            ref bool dataChanged,
            SimpleButton btnSave)
        {
            if (bs.Current != null)
            {
                if (XtraMessageBox.Show("你确定要删除选中的项吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bs.EndEdit();

                    DataRow removeRow = (bs.Current as DataRowView).Row;

                    //删除
                    deleteDataFun(removeRow);

                    table.Rows.Remove(removeRow);

                    dataChanged = false;

                    foreach (DataRow row in table.Select())
                    {
                        if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                            dataChanged = true;
                    }

                    btnSave.Enabled = dataChanged;

                    Sundries.MessageBox("删除成功！");

                    return true;
                }
            }

            return false;
        }
        public static string CalcAgeOfXd1(DateTime birthday, DateTime calcDateTime)
        {
            string ageStr = string.Empty;

            TimeSpan ts = calcDateTime - birthday;

            if (birthday > calcDateTime)
            {
                ageStr = "生日小于所选日期";
            }
            else if (birthday.AddMonths(1) < calcDateTime)
            {
                ageStr = Math.Ceiling(ts.TotalDays) + "天";
            }
            else if (birthday.AddYears(1) < calcDateTime)
            {
                for (int months = 2; months < 12; months++)
                {
                    if (birthday.AddMonths(months) <= calcDateTime
                        && birthday.AddMonths(months + 1) > calcDateTime)
                    {
                        ageStr = months + "个月";
                        break;
                    }
                }
                ageStr += ts.Days + "天";
            }
            else if (birthday.AddYears(6) < calcDateTime)
            {
                for (int year = 2; year < 6; year++)
                {
                    if (birthday.AddYears(year) <= calcDateTime
                        && birthday.AddYears(year + 1) > calcDateTime)
                    {
                        ageStr = year + "岁";
                        break;
                    }
                }

                for (int months = 2; months < 12; months++)
                {
                    if (birthday.AddMonths(months) <= calcDateTime
                        && birthday.AddMonths(months + 1) > calcDateTime)
                    {
                        ageStr = months + "个月";
                        break;
                    }
                }

                ageStr += ts.Days + "天";
            }
            else
            {
                if (birthday.AddYears(calcDateTime.Year - birthday.Year) < calcDateTime)
                {
                    ageStr = (calcDateTime.Year - birthday.Year - 1) + "岁";
                }
                else
                {
                    ageStr = (calcDateTime.Year - birthday.Year) + "岁";
                }
            }

            return ageStr;
        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        public static string Encrypto(string Source)
        {
            byte[] bt = UTF8Encoding.UTF8.GetBytes(Source);//UTF8需要对Text的引用
            MD5CryptoServiceProvider objMD5;
            objMD5 = new MD5CryptoServiceProvider();
            byte[] output = objMD5.ComputeHash(bt);

            string[] password = BitConverter.ToString(output).Split(new char[] { '-' });
            string returnValue = "";
            for (int index = 0; index < password.Length; index++)
                returnValue += password[index];
            returnValue = returnValue.ToUpper();
            return returnValue;
        }

        public static string EncodeWithString(Stream stream)
        {
            byte[] binaryData = FileHelper.StreamToBytes(stream);
            return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
        }

        public static string EncodeWithString(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            string result = EncodeWithString(fs);
            fs.Close();
            return result;
        }

        public static string EncodeString(string source)
        {
            byte[] binaryData = StringHelper.Str2Arr(source);
            return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
        }

        public static string DecodeString(string base64String)
        {
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(base64String);
            return StringHelper.Arr2Str(binaryData);
        }

        public static Stream DecodeWithString(string base64String)
        {
            byte[] binaryData;
            binaryData = System.Convert.FromBase64String(base64String);
            Stream stream = new MemoryStream(binaryData);
            return stream;
        }
    }
}
