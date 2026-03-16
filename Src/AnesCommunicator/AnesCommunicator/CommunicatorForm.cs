using AnesCommunicator.BaseType;
using AnesCommunicator.View;
using DevExpress.XtraEditors;
using MedicalSystem.Message.Common;
using MedicalSystem.Message.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AnesCommunicator
{
    public partial class CommunicatorForm : DevExpress.XtraEditors.XtraForm
    {
        // add by shiyu.duan for 主板本升级 anes-00055 实现各手术间文字通讯
        // 引入系统自带dll音乐播放
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public const int SND_FILENAME = 0x00020000;
        public const int SND_ASYNC = 0x0001;

        #region 对象声明
        /// <summary>
        /// 连接对象，用于连接远程服务器调用服务端接口
        /// </summary>
        public Connection con;
        /// <summary>
        /// 通讯信息类
        /// </summary>
        CommunicatInformations _communicatInformations;
        /// <summary>
        /// 定义委托,防止跨线程错误
        /// </summary>
        delegate void SetCallback();
        /// <summary>
        /// 定义委托,接受消息后触发
        /// </summary>
        public delegate void MessageRecived(object sender, EventArgs e);
        public event MessageRecived AfterMessageRecived;
        /// <summary>
        /// 上线用户列表
        /// </summary>
        List<MessageUser> _msgUserDict;
        /// <summary>
        /// 全部用户列表
        /// </summary>
        DataTable _dtList;

        private string _sendMode = "R";
        /// <summary>
        /// 发送状态 S发送 R接收
        /// </summary>
        public string SendMode
        {
            get
            {
                return _sendMode;
            }
            set
            {
                _sendMode = value;
            }
        }
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="args"></param>
        public CommunicatorForm(string[] args)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SkinProject1).Assembly);
 
            InitializeComponent();

            // 单点登录
            if (args != null && args.Length > 0)
            {
                _communicatInformations = JsonConvert.DeserializeObject<CommunicatInformations>(args[0]);

                // 连接服务器
                ConnectToServer();
            }

        }

        #region 服务器委托方法
        private void DelegateRefreshUserList(List<MessageUser> msgUserList)
        {

        }

        private void DelegateUserUnLineMessage(string userName, string message)
        {
            XtraMessageBox.Show(string.Format("用户【{0}】不在线", userName));
        }

        private void DelegateSendGroupMessage(string sendConnectionId, string sendName, string groupName, string message)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    txtGroupMessageReceive.Text += (string.Format("{0}（{1}）:{2}-{3}\r\n", sendConnectionId, sendName, groupName, message));
                    txtGroupMessageForSend.Text = "";
                    txtGroupMessageForSend.Focus();
                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }
        }

        private void DelegateGetUserList(List<MessageUser> msgUserDict)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                _msgUserDict = msgUserDict;
                SetCallback setCallback = delegate
                {
                    grdLstUsers.DataSource = GetAllList();
                    // 用于本地测试
                    // Test();
                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }

        }

        private void DelegateGetGroupList(List<string> groupList)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    cmbGroupList.Items.Clear();
                    foreach (string item in groupList)
                    {
                        cmbGroupList.Items.Add(item);
                    }
                    if (cmbGroupList.Items.Count > 0)
                    {
                        cmbGroupList.SelectedIndex = 0;
                    }

                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }
        }

        private void DelegateUnLine(string connectionId, string name)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    txtMessageReceive.Text += (string.Format("用户【{0}】（{1}）下线\r\n", name, DateTime.Now.ToString("HH:mm")));
                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }
        }

        private void DelegateOnLine(string connectionId, string name)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    Application.DoEvents();
                    txtMessageReceive.Text += (string.Format("用户【{0}】（{1}）上线\r\n", name, DateTime.Now.ToString("HH:mm")));
                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }
        }

        /// <summary>
        /// 接收/发送消息
        /// </summary>
        /// <param name="sendConnectionId"></param>
        /// <param name="sendName"></param>
        /// <param name="message"></param>
        private void DelegateSendMessage(string sendConnectionId, string sendName, string message)
        {
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    // {0}发送者，{1}当前时间HH：mm，{2}接收者以及对应消息
                    if (tabControlMessage.SelectedTabPage == xtraTabPageNormal)
                    {
                        string tempMessage = string.Format("【{0}】（{1}）：{2}\r\n", sendName, DateTime.Now.ToString("HH:mm"), message);
                        // 紧急消息尝试去json解析
                        if (message.Contains("【紧急】"))
                        {
                            try
                            {
                                OperationInformations operationInformations = JsonConvert.DeserializeObject<OperationInformations>(message);
                                tempMessage = string.Format("【{0}】（{1}）：{2}\r\n",
                                    sendName,
                                    DateTime.Now.ToString("HH:mm"),
                                    string.Format(operationInformations.EmergencyCall.Message,
                                                  operationInformations.EmergencyCall.OperatingRoom));
                            }
                            catch
                            {
 
                            }
                        }
                        txtMessageReceive.Text += tempMessage;
                        // 设置滚动条在最下方 
                        this.txtMessageReceive.SelectionStart = this.txtMessageReceive.Text.Length;
                        this.txtMessageReceive.ScrollToCaret();
                        // 写入聊天记录
                        WriteToChatRecord(tempMessage);
                        txtMessageForSend.Focus();
                    }
                    else if (tabControlMessage.SelectedTabPage == xtraTabPageAnesEvents)
                    {
                        txtGroupMessageReceive.Text += (string.Format("【{0}】（{1}）：{2}\r\n", sendName, DateTime.Now.ToString("HH:mm"), message));
                        txtGroupMessageForSend.Focus();
                    }
                    

                    //接收到消息后触发事件
                    if (SendMode == "R")
                    {
                        if (AfterMessageRecived != null)
                        {
                            AfterMessageRecived(this, new EventArgs());
                        }

                        // 如果内容中含有【紧急】，则触发紧急呼叫处理
                        if (message.Contains("【紧急】"))
                        {
                            PlaySound(Application.StartupPath + @"\Voice\提示音4.wav", 0, SND_ASYNC | SND_FILENAME);

                            EmergencyView emr = new EmergencyView(message);
                            emr.ShowDialog();

                            this.TopMost = true;
                            this.TopMost = false;
                        }
                        else
                        {
                            // 系统系带提示音
                            //System.Media.SystemSounds.Beep.Play();
                            //System.Media.SystemSounds.Asterisk.Play();
                            //System.Media.SystemSounds.Exclamation.Play();
                            //System.Media.SystemSounds.Hand.Play();

                            // 外加音乐
                            PlaySound(Application.StartupPath + @"\Voice\提示音1.wav", 0, SND_ASYNC | SND_FILENAME);
                            //PlaySound(Application.StartupPath + @"\Voice\提示音2.wav", 0, SND_ASYNC | SND_FILENAME);
                            //PlaySound(Application.StartupPath + @"\Voice\提示音3.wav", 0, SND_ASYNC | SND_FILENAME);
                            //PlaySound(Application.StartupPath + @"\Voice\提示音4.wav", 0, SND_ASYNC | SND_FILENAME);
                        }
                    }
                    //发送消息处理
                    else if (SendMode == "S")
                    {
                        // 清空输入框
                        txtMessageForSend.Text = string.Empty;
                        txtGroupMessageForSend.Text = string.Empty;
                    }

                    SendMode = "R";
                }; //实例化委托对象
                this.Invoke(setCallback); //重新调用setCallback函数
            }
        }

        private void DelegateConnectionClosed()
        {
            //XtraMessageBox.Show("与服务端失去连接");
            if (this.InvokeRequired) //控件是否跨线程？如果是，则执行括号里代码
            {
                SetCallback setCallback = delegate
                {
                    this.Text = "消息通讯 - 与服务端失去连接...";
                }; //实例化委托对象

                this.Invoke(setCallback); //重新调用setCallback函数
            }

            if (con.ConnectionStatus)
                con.Close();
        }
        #endregion

        #region 按钮事件（消息）
        /// <summary>
        /// 全员发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.DialogResult.OK == XtraMessageBox.Show("确定后将会向全员发送消息，是否确定？", "提示", MessageBoxButtons.OKCancel))
            {
                SendMode = "S";
                if (con.ConnectionStatus)
                    con.SendALLMessage(txtMessageForSend.Text);
            }
        }

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMode = "S";
            if (con.ConnectionStatus)
                con.SendMessage(_communicatInformations.CurrentCommunicator.CurrentSelectedUser, string.Format("对【{0}】说：{1}", _communicatInformations.CurrentCommunicator.CurrentSelectedUser, txtMessageForSend.Text));
        }

        /// <summary>
        /// 聊天记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChatRecord_Click(object sender, EventArgs e)
        {
            ChatRecordForm chatRecordForm = new ChatRecordForm(_communicatInformations.CurrentCommunicator.CurrentLoginUser);
            chatRecordForm.ShowDialog();
        }

        /// <summary>
        /// 用户列表点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewKind_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            _communicatInformations.CurrentCommunicator.CurrentSelectedUser = e.CellValue.ToString();
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommunicatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                //this.WindowState = FormWindowState.Minimized;
                e.Cancel = true;
                this.Hide();
            }
            else if (con.ConnectionStatus)
                con.Close();
        }

        /// <summary>
        /// 刷新用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshUserList_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
                con.GetUserList();

            GetAllList();
        }

        /// <summary>
        /// 重新连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReconnect_Click(object sender, EventArgs e)
        {
            if (!con.ConnectionStatus)
            {
                ConnectToServer();
            }
            else
            {
                con.Close();
                ConnectToServer();
                //txtMessageReceive.Text += (string.Format("当前用户已在线，无需重连\r\n"));
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMessageForSend_KeyDown(object sender, KeyEventArgs e)
        {
            // 回车直接发消息
            if (e.KeyCode == Keys.Enter)
            {
                SendMode = "S";
                if (con.ConnectionStatus)
                    con.SendMessage(_communicatInformations.CurrentCommunicator.CurrentSelectedUser, string.Format("对【{0}】说:{1}", _communicatInformations.CurrentCommunicator.CurrentSelectedUser, txtMessageForSend.Text));
            }
        }
        #endregion

        #region 按钮事件（讨论组）
        /// <summary>
        /// 创建组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show(string.Format("组名不能为空，请输入讨论组名！"));
                txtGroupName.Focus();
                return;
            }
            if (XtraMessageBox.Show(string.Format("确定要创建名为【{0}】的分组吗？", txtGroupName.Text), "将要创建新的讨论组", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (con.ConnectionStatus)
                {
                    con.CreateGroup(txtGroupName.Text);
                    con.GetGroupList();
                }
            }
        }

        /// <summary>
        /// 刷新组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshGroupList_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
                con.GetGroupList();
        }

        /// <summary>
        /// 加入组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
            {
                con.AddToGroup(cmbGroupList.Text);

                lblCurrentGroup.Text = con.GroupName.Length == 0 ? "暂无" : con.GroupName;
            }
        }

        /// <summary>
        /// 退出组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitGroup_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
            {
                con.ExitGroup();
                lblCurrentGroup.Text = "暂无";
            }
        }

        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
            {
                con.DeleteGroup(cmbGroupList.Text);
            }
        }

        /// <summary>
        /// 发送组消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupSend_Click(object sender, EventArgs e)
        {
            if (con.ConnectionStatus)
                con.SendGroupMessage(txtGroupMessageForSend.Text);
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGroupMessageForSend_KeyDown(object sender, KeyEventArgs e)
        {
            // 回车直接发消息
            if (e.KeyCode == Keys.Enter)
            {
                if (con.ConnectionStatus)
                    con.SendGroupMessage(txtGroupMessageForSend.Text);
            }
        }
        #endregion

        private void tabControlMessage_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tabControlMessage.SelectedTabPage == xtraTabPageNormal)
            {
                if (con.ConnectionStatus)
                {
                    con.GetGroupList();

                    lblCurrentGroup.Text = con.GroupName.Length == 0 ? "暂无" : con.GroupName;
                }
            }
        }

        #region 最小化任务栏图标相关设置
        private void ntfIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void 关闭CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("确定要关闭消息通讯吗？", "将要关闭程序", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        #endregion

        #region 方法
        public void EmergencyCall(string strOperationInformations)
        {
            // 测试
            //strOperationInformations = "{\"OperationInfo\":{\"PatientID\":\"111\",\"VisitID\":\"111\",\"OperID\":\"111\",\"OperationName\":\"111\",\"AnesthesiaMethod\":\"111\"},\"PatientInfo\":{\"Name\":\"111\",\"Sex\":\"111\",\"Age\":\"111\",\"BedNo\":\"111\"}}";
            //_operationInformations = JsonConvert.DeserializeObject<OperationInformations>(strOperationInformations);

            SendMode = "S";
            if (con.ConnectionStatus)
                con.SendALLMessage(strOperationInformations);

        }

        /// <summary>
        /// 设置所有用户列表（外接接口，用于设置全部用户列表内容）
        /// </summary>
        /// <param name="dtList"></param>
        public void SetAllList(DataTable dtList)
        {
            _dtList = dtList;
        }

        /// <summary>
        /// 连接服务端
        /// </summary>
        private void ConnectToServer()
        {
            if (_communicatInformations != null && (_communicatInformations.CurrentCommunicator.CurrentLoginRoomNo != string.Empty || _communicatInformations.CurrentCommunicator.CurrentLoginUser != string.Empty))
            {
                // 连接服务器
                string communicatorName = string.Empty;//用户名，有手术间就用手术间作为用户名，没有就取默认用户名
                if (_communicatInformations.CurrentCommunicator.CurrentLoginRoomNo != string.Empty)
                {
                    communicatorName = "手术间" + _communicatInformations.CurrentCommunicator.CurrentLoginRoomNo;
                    _communicatInformations.CurrentCommunicator.CurrentSelectedUser = communicatorName;
                }
                else
                {
                    communicatorName = _communicatInformations.CurrentCommunicator.CurrentLoginUser;
                _communicatInformations.CurrentCommunicator.CurrentSelectedUser = communicatorName;
                }

                // 创建新的连接
                con = new Connection(communicatorName, _communicatInformations.CurrentCommunicator.ConnectionString);
                con.DelegateSendMessage += DelegateSendMessage;
                con.DelegateConnectionClosed += DelegateConnectionClosed;
                con.DelegateOnLine += DelegateOnLine;
                con.DelegateUnLine += DelegateUnLine;
                con.DelegateGetUserList += DelegateGetUserList;
                con.DelegateGetGroupList += DelegateGetGroupList;
                con.DelegateSendGroupMessage += DelegateSendGroupMessage;
                con.DelegateUserUnLineMessage += DelegateUserUnLineMessage;
                con.Connect();
                this.Text = "消息通讯 -" + con.UserName;
            }
        }

        /// <summary>
        /// 获取所有用户列表（并且用颜色区分是否在线）
        /// </summary>
        private DataTable GetAllList()
        {
            // 没有获取到全部用户的情况，请使用Test()方法进行测试
            if (_dtList == null)
            {
                _dtList = new DataTable();
                _dtList.Columns.Add("ROOM_NO");
                _dtList.Columns.Add("DEPT_CODE");
            }

            // 加入【是否上线】列
            if (!_dtList.Columns.Contains("LOGIN"))
            {
                _dtList.Columns.Add("LOGIN", typeof(bool));
            }

            DataTable dtList = _dtList.Copy();
            // 取消数据库定义的长度限制
            dtList.Columns["ROOM_NO"].MaxLength = -1;
            // 加上【手术间】三个字
            foreach (DataRow dr in dtList.Rows)
            {
                dr["ROOM_NO"] = "手术间" + dr["ROOM_NO"];
            }
            // 上线用户排在前面
            dtList.DefaultView.Sort = "LOGIN DESC";

            // 查看服务端返回在线列表中是否包含
            if (_msgUserDict != null && _msgUserDict.Count != 0)
            {
                foreach (MessageUser item in _msgUserDict)
                {
                    DataRow[] drs = dtList.Select("ROOM_NO = '" + item.UserName + "'");
                    if (drs.Length > 0)
                    {
                        foreach (DataRow dr in drs)
                        {
                            // 若包含，则以在线形式显示
                            dr["LOGIN"] = true;
                        }
                    }
                    else
                    {   // 若不包含，则新增一个用户
                        DataRow dr = dtList.NewRow();
                        dr["ROOM_NO"] = item.UserName;
                        dr["LOGIN"] = true;
                        dr["DEPT_CODE"] = " ";
                        dtList.Rows.Add(dr);
                    }
                }
            }

            return dtList;
        }

        /// <summary>
        /// 设置未上线的用户背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewKind_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.ForeColor = Color.Gray;
        }

        /// <summary>
        /// 设置选中者的颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewKind_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (gridViewKind.GetDataRow(e.RowHandle) == gridViewKind.GetFocusedDataRow())
            {
                e.Appearance.BackColor = Color.Blue;
                _communicatInformations.CurrentCommunicator.CurrentSelectedUser = gridViewKind.GetDataRow(e.RowHandle)[0].ToString();
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        private void Test()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ROOM_NO");
            dt.Columns.Add("LOGIN", typeof(bool));

            for (int i = 1; i < 11; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ROOM_NO"] = "手术间" + i.ToString();
                dr["LOGIN"] = false;
                dt.Rows.Add(dr);
            }

            grdLstUsers.DataSource = dt;

            if (_msgUserDict != null && _msgUserDict.Count != 0)
            {
                foreach (MessageUser item in _msgUserDict)
                {
                    DataRow[] drs = dt.Select("ROOM_NO = '手术间" + item.UserName + "'");
                    foreach (DataRow dr in drs)
                    {
                        dr["LOGIN"] = true;
                    }
                }
            }
        }

        /// <summary>
        /// 写入本地聊天记录
        /// </summary>
        /// <param name="chatRecord"></param>
        private void WriteToChatRecord(string chatRecord)
        {
            if (!Directory.Exists(Application.StartupPath + @"\ChatRecord\"))
            {
                Directory.CreateDirectory(@"ChatRecord\");
            }

            FileStream sw = new FileStream(Application.StartupPath + string.Format(@"\ChatRecord\{0}{1}.txt", _communicatInformations.CurrentCommunicator.CurrentLoginUser, DateTime.Now.ToString("yyyyMMdd")), FileMode.Append);
            byte[] byteArr = System.Text.Encoding.UTF8.GetBytes(chatRecord);

            sw.Write(byteArr, 0, byteArr.Length); //fs就是你的流
            sw.Close();
        }
        #endregion

    }
}
