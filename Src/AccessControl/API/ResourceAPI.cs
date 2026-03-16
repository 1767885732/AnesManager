using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using Wis.AccessControl.Provider;

namespace Wis.AccessControl.API
{
    public static class ResourceAPI
    {
        static AccessControlProvider Provider
        {
            get { return AccessControlProvider.DefaultProvider; }
        }

        public static void CreateResource(Resource resource)
        {
            Provider.CreateResource(resource);
        }

        public static int DeleteResourceByID(string resourceID)
        {
            return Provider.DeleteResourceByID(resourceID);
        }


        public static int DeleteChildByParentID(string resourceID)
        {
            return Provider.DeleteChildByParentID(resourceID);
        }

        public static int UpdateResource(Resource resource)
        {
            return Provider.UpdateResource(resource);
        }

        public static IList<Resource> GetAllResource()
        {
            return Provider.GetAllResource();
        }

        public static IList<Resource> GetAllResourceByAppFlag(string appFlag)
        {
            return Provider.GetAllResourceByAppFlag(appFlag);
        }

        public static IList<Resource> GetResourcesByUserID(string userID)
        {
            return Provider.GetResourcesByUserID(userID);
        }

        public static IList<Resource> GetResourcesByUserID(string userID, string appFlag)
        {
            return Provider.GetResourcesByUserID(userID, appFlag);
        }

        public static IList<Resource> GetResourcesByRoleID(string roleID)
        {
            return Provider.GetResourcesByRoleID(roleID);
        }

        public static Resource GetResourceByID(string resourceID)
        {
            return Provider.GetResourceByID(resourceID);
        }
    }
}
