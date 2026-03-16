using System;
using System.Configuration;

namespace Wis.AccessControl.Configuration
{
    public sealed class AccessControlSettingSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultProvider", IsRequired = true)]
        public string DefaultProvider
        {
            get
            {
                return this["defaultProvider"].ToString();
            }
        }

        [ConfigurationProperty("providers", IsRequired = true)]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return this["providers"] as ProviderSettingsCollection;
            }
        }

        [ConfigurationProperty("userSettings")]
        public UserSettings UserSettings
        {
            get
            {
                return this["userSettings"] as UserSettings;
            }
        }
        [ConfigurationProperty("roleSettings")]
        public RoleSettings RoleSettings
        {
            get
            {
                return this["roleSettings"] as RoleSettings;
            }
        }
        [ConfigurationProperty("resourceSettings")]
        public ResourceSettings ResourceSettings
        {
            get
            {
                return this["resourceSettings"] as ResourceSettings;
            }
        }
        [ConfigurationProperty("permissionSettings")]
        public PermissionSettings PermissionSettings
        {
            get
            {
                return this["permissionSettings"] as PermissionSettings;
            }
        }

    }
}
