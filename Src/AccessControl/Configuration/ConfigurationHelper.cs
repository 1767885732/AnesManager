using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Wis.AccessControl.Configuration
{
    public static class ConfigurationHelper
    {
        private static UserSettings _userSettings;
        static RoleSettings _roleSettings;
        static ResourceSettings _resourceSettings;
        static PermissionSettings _permissionSettings;

        static ConfigurationHelper()
        {
            AccessControlSettingSection section = ConfigurationManager.GetSection("accessControlSettings") as AccessControlSettingSection;
            _userSettings = section.UserSettings;
            _roleSettings = section.RoleSettings;
            _resourceSettings = section.ResourceSettings;
            _permissionSettings = section.PermissionSettings;
        }

        public static UserSettings UserSettings
        {
            get { return _userSettings; }
        }
        public static RoleSettings RoleSettings
        {
            get { return _roleSettings; }
        }
        public static PermissionSettings PermissionSettings
        {
            get { return _permissionSettings; }
        }
        public static ResourceSettings ResourceSettings
        {
            get { return _resourceSettings; }
        }
    }
}
