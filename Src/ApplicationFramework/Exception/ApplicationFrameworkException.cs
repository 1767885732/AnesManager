using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationFramework.Exception
{
    public class ApplicationFrameworkException : System.Exception
    {
        public ApplicationFrameworkException(string msg) : base(msg) { }
    }
}
