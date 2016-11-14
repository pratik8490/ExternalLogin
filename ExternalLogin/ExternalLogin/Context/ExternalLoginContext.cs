using ExternalLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalLogin.Context
{
    public class ExternalLoginContext
    {
        public static string AccessToken { get; set; }
        public static string UserName { get; set; }
        public static Boolean IsLoggedIn { get; set; }
        public static UserInfoViewModel UserInfo { get; set; }

        public static void Clear()
        {
            UserInfo = new UserInfoViewModel();
            UserName = string.Empty;
            IsLoggedIn = false;
        }
    }
}
