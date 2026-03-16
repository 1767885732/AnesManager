using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Wis.AccessControl.Configuration
{
    public sealed class ExtendInfoItem : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"].ToString();
            }
        }

        [ConfigurationProperty("dbType")]
        public string DbType
        {
            get
            {
                return this["dbType"].ToString();
            }
        }

        [ConfigurationProperty("description")]
        public string Description
        {
            get
            {
                return this["description"].ToString();
            }
        }
    }
}
