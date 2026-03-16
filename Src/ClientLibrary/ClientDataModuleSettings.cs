using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.Anes.ClientLibrary
{
    public class ClientDataModuleSettings : ConfigurationSection
    {
        [ConfigurationProperty("callType", IsRequired = true)]
        public string CallType
        {
            get
            {
                return this["callType"] as string;
            }
            set
            {
                this["callType"] = value;
            }
        }
        [ConfigurationProperty("interFaceIP", IsRequired = true)]
        public string InterFaceIP
        {
            get
            {
                return this["interFaceIP"] as string;
            }
            set
            {
                this["interFaceIP"] = value;
            }
        }
        [ConfigurationProperty("remotingUrl", IsRequired = true)]
        public string RemotingUrl
        {
            get
            {
                return this["remotingUrl"] as string;
            }
            set
            {
                this["remotingUrl"] = value;
            }
        }
        [ConfigurationProperty("ClentID", IsRequired = true)]
        public string ClentID
        {
            get
            {
                return this["ClentID"] as string;
            }
            set
            {
                this["ClentID"] = value;
            }
        }
        [ConfigurationProperty("HospitalID", IsRequired = true)]
        public string HospitalID
        {
            get
            {
                return this["HospitalID"] as string;
            }
            set
            {
                this["HospitalID"] = value;
            }
        }
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get
            {
                return this["type"] as string;
            }
            set
            {
                this["type"] = value;
            }
        }
        [ConfigurationProperty("port", IsRequired = true)]
        public string Port
        {
            get
            {
                return this["port"] as string;
            }
            set
            {
                this["port"] = value;
            }
        }

        public static ClientDataModuleSettings GetSection()
        {
            return (ClientDataModuleSettings)ConfigurationManager.GetSection("clientDataModule");
        }
    }
}
