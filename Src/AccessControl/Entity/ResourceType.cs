using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.AccessControl.Entity
{
    [Serializable]
    public enum ResourceType
    {
        Menu = 1,
        Module,
        Control,
        Data,
        Command
    }
}
