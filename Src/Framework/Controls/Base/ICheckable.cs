using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.Framework.Controls.Base
{
    public interface ICheckable
    {
        string InputNeededMessage
        {
            get;
            set;
        }

        bool IsInputNeeded
        {
            get;
        }

        bool IsValid
        {
            get;
        }
    }
}
