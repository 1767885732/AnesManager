using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.API;

namespace Wis.AccessControl.Entity
{
    [Serializable]
    public class Resource : ExtendInfo
    {
        public Resource(string id) { this._id = id; }
        public Resource() { this._id = Guid.NewGuid().ToString(); }
        string _id;
        public string ID { get { return _id;} }
        public string Name { get; set; }
        public string ResourceIdentifier { get; set; }
        public string AppFlag { get; set; }
        public ResourceType ResourceType { get; set; }
        public string ParentID { get; set; }
        Resource _parent;
        public Resource Parent
        {
            get
            {
                if (_parent == null)
                {
                    if (string.IsNullOrEmpty(ParentID))
                        return null;
                    _parent = ResourceAPI.GetResourceByID(this.ParentID);
                }
                return _parent;
            }
            set
            {
                if(value == null) 
                    return;
                _parent = value;
                this.ParentID  = value.ID;
                ResourceAPI.UpdateResource(this);
            }
        }
        public int SortIndex { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != this.GetType()) return false;
            return (((Resource)obj)._id == this._id);
        }
        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
