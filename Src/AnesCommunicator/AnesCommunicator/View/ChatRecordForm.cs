using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnesCommunicator.View
{
    /// <summary>
    /// 聊天记录窗体
    /// </summary>
    public partial class ChatRecordForm : DevExpress.XtraEditors.XtraForm
    {
        string _userName;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName"></param>
        public ChatRecordForm(string userName)
        {
            _userName = userName;
            InitializeComponent();
        }

        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatRecordForm_Load(object sender, EventArgs e)
        {
            GetChatRecord();
        }

        /// <summary>
        /// 日期搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            GetChatRecord();
        }

        /// <summary>
        /// 获取聊天记录
        /// </summary>
        private void GetChatRecord()
        {
            txtMessageRecord.Text = string.Empty;
            if (!Directory.Exists(Application.StartupPath + @"\ChatRecord\"))
            {
                Directory.CreateDirectory(@"ChatRecord\");
            }

            try
            {
                string path = Application.StartupPath + string.Format(@"\ChatRecord\{0}{1}.txt", _userName, dtpDate.Value.ToString("yyyyMMdd"));
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    txtMessageRecord.Text += line + "\r\n";
                }
                lblAlarm.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblAlarm.Text = dtpDate.Value.ToString("yyyy-MM-dd") + "无消息记录！";
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 前一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
        }

        /// <summary>
        /// 后一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
        }

        private int currentIndex = 0;
        private string searchKey;
        private bool isFound = false;

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFilter.Text!= string.Empty)
            {
                searchKey = txtFilter.Text.Trim();

                currentIndex = txtMessageRecord.Find(searchKey, currentIndex, RichTextBoxFinds.None);

                if (currentIndex == -1)
                {
                    if (isFound)//表示如果曾经找到过
                    {
                        lblAlarm.Text = "注意：已经搜索到文件最底部！";
                    }
                    else
                    {
                        lblAlarm.Text = "注意：没有搜索到关于[" + searchKey + "]的任何内容！";
                    }
                    currentIndex = 0;//重置索引
                    isFound = false; //重置标志位
                }
                else
                {
                    this.txtMessageRecord.Select(currentIndex, searchKey.Length);
                    currentIndex += searchKey.Length;
                    isFound = true;
                }
            }
            else if (txtFilter.Text.Length == 0)
            {
                lblAlarm.Text = "请在左侧输入搜索内容！";
            }
        }
    }
}
