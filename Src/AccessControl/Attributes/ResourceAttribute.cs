using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;

namespace Wis.AccessControl.Attributes
{
    public class ResourceAttribute: System.Attribute
    {
        public ResourceType Type { get; set; }
        public string Name { get; set; }
    }
}
