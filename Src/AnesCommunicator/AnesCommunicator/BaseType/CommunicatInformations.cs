using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnesCommunicator.BaseType
{
    /// <summary>
    /// 通讯信息类
    /// </summary>
    public class CommunicatInformations
    {
        public CurrentCommunicator CurrentCommunicator { get; set; }
        //public EmergencyCall EmergencyCall { get; set; }
    }

    /// <summary>
    /// 当前通讯信息
    /// </summary>
    public class CurrentCommunicator
    {
        /// <summary>
        /// 当前选中的用户
        /// </summary>
        public string CurrentSelectedUser { get; set; }
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public string CurrentLoginUser { get; set; }
        /// <summary>
        /// 当前登录用户手术间
        /// </summary>
        public string CurrentLoginRoomNo { get; set; }
        /// <summary>
        /// 当前登录连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 当前登录连接状态，已连接True，未连接False
        /// </summary>
        public string ConnectionStatus { get; set; }
    }
}
