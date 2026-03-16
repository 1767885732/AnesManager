using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.AccessControl.Entity
{
    public enum OperationEnum
    {
        All = 0,
        ReadOnly,
        Add,
        Delete,
        Update,
        Select,
        Visible,
        Enable,
        Execute
    }
}
