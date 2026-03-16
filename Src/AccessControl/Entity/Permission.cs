using System;
using Wis.AccessControl.API;

namespace Wis.AccessControl.Entity
{
    public class Permission : ExtendInfo
    {
        public Permission(string id) { _id = id; }
        public Permission() { _id = Guid.NewGuid().ToString(); }
        string _id;
        public string ID { get { return _id; } }
        public string Name { get; set; }
        public string ResourceID { get; set; }
        public string AppFlag { get; set; }
        Resource _resource;
        public Resource Resource
        {
            get
            {
                if (_resource == null)
                {
                  _resource =  ResourceAPI.GetResourceByID(ResourceID);
                }
                return _resource;
            }
        }
        public OperationEnum Operation { get; set; }
        public bool Allowed { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != GetType()) return false;
            return (_id == ((Permission)obj).ID);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
