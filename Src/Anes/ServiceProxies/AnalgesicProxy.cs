using System;
using System.Collections.Generic;
using System.Text;
using Wis.Anes.Interface;
using Wis.Anes.BusinessComponent;

namespace Wis.Anes.ServiceProxies
{
   public class AnalgesicProxy
    {
       IAnalgesic _analgesic = new AnalgesicBC();

       public void Test()
       {
           _analgesic.Test();
       }
    }
}
