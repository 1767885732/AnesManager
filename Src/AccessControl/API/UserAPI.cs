using System;
using System.Collections.Generic;
using System.Text;
using Wis.AccessControl.Entity;
using Wis.AccessControl.Provider;

namespace Wis.AccessControl.API
{
    public static class UserAPI
    {

        static AccessControlProvider Provider
        {
            get { return AccessControlProvider.DefaultProvider; }
        }

        public static void CreateUser(User user)
        {
            Provider.CreateUser(user);
        }

        public static IList<User> GetAllUser(string where)
        {
            return Provider.GetAllUser(where);
        }

        public static int DeleteUserByID(string userID)
        {
            return Provider.DeleteUserByID(userID);
        }

        public static int DeleteUserByName(string userName)
        {
            return Provider.DeleteUserByName(userName);
        }

        public static int UpdateUser(User user)
        {
            return Provider.UpdateUser(user);
        }

        public static User GetUserByID(string userID)
        {
            return Provider.GetUserByID(userID);
        }

        public static User GetUserByName(string userName)
        {
            return Provider.GetUserByName(userName);
        }
    }
}
