using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.AccessControl.Entity
{
    public class Role : ExtendInfo
    {
        public Role(string id) { this._id = id; }
        public Role() { this._id = Guid.NewGuid().ToString(); }
        string _id;
        public string ID { get { return _id; } }
        public string Name { get; set; }
        public string AppFlag { get; set; }
        public string Description { get; set; }
    }
}
