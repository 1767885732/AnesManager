using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Base
{
    public class ApplicationConfiguration
    {

        public static string MessageServerUrl
        {
            get
            {
                string key = "MessageServerUrl";
                string text = ConfigurationManager.AppSettings[key];

                if (!string.IsNullOrEmpty(text))
                {
                    return text;
                }
                else
                {
                    return "localhost:9999";
                }
            }
        }
    }
}
