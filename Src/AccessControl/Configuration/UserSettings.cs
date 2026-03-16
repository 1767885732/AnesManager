using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.AccessControl.Configuration
{
    public sealed class UserSettings : ConfigurationElement
    {
        [ConfigurationProperty("tableName", IsRequired = true)]
        public string TableName
        {
            get { return this["tableName"].ToString(); }
        }

        [ConfigurationProperty("userIDColumnName", IsRequired = true)]
        public string UserIDColumnName
        {
            get { return this["userIDColumnName"].ToString(); }
        }

        [ConfigurationProperty("userNameColumnName", IsRequired = true)]
        public string UserNameColumnName
        {
            get { return this["userNameColumnName"].ToString(); }
        }

        [ConfigurationProperty("userPasswordColumnName", IsRequired = true)]
        public string UserPasswordColumnName
        {
            get { return this["userPasswordColumnName"].ToString(); }
        }

        [ConfigurationProperty("extendInfos")]
        public ExtendInfoCollection ExtendInfos
        {
            get { return this["extendInfos"] as ExtendInfoCollection; }
        }
    }
}
