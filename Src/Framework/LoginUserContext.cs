using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework
{
    /// <summary>
    /// 登陆用户信息
    /// </summary>
    public class LoginUserContext
    {

        private bool _isManager = false;
        private string _loginName = string.Empty;
        private string _userID = string.Empty;
        private string _userName = string.Empty;
        private string _deptID = string.Empty;
        private string _hisUserID = string.Empty;

        public bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; }
        }
        
        /// <summary>
        /// 登陆名
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        /// <summary>
        /// 用户GUID
        /// </summary>
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _pwd;
        /// <summary>
        /// 密码
        /// </summary>
        public string PWD
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        public string PWDBase64
        {
            get;
            set;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// 登陆用户在HISUserID
        /// </summary>
        public string HisUserID
        {
            get { return _hisUserID; }
            set { _hisUserID = value; }
        }

        /// <summary>
        /// 登陆用户部门
        /// </summary>
        public string DeptID
        {
            get { return _deptID; }
            set { _deptID = value; }
        }
    }
}
