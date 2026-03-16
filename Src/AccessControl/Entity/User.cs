using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.API;

namespace Wis.AccessControl.Entity
{
    public class User : ExtendInfo
    {
        public User(string id) 
        {
            this._id = id;
        }

        public User()
        {
            this._id = Guid.NewGuid().ToString();
        }

        private void CopyExtendInfo(IDictionary<string, string> extendInfo)
        {
            if (extendInfo != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in extendInfo)
                {
                    ExtendInfoDict.Add(keyValuePair);
                }
            }
        }
        string _id;
        public string ID { get { return _id; } }
        public string Name  {  get;  set;  }
        public string Password { get;  set; }
        IList<Role> _roles;
        public IList<Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = RoleAPI.GetAssignedRolesByUserID(this.ID);
                }
                return _roles;
            }
        }
    }
}
