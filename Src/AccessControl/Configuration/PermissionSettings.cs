using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.AccessControl.Configuration
{
    public sealed class PermissionSettings : ConfigurationElement
    {
        [ConfigurationProperty("extendInfos")]
        public ExtendInfoCollection ExtendInfos
        {
            get { return this["extendInfos"] as ExtendInfoCollection; }
        }
    }
}
