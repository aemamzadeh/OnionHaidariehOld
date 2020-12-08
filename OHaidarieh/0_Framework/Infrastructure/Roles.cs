using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string User = "1";
        public const string Admin = "2";
        public const string Engineer = "3";

        public static string GetRole(long id)
        {
            switch (id)
	        {
                case 1:
                    return "کاربر";
                case 2:
                    return "مدیرسیستم";
                case 3:
                    return "کارشناس سیستم";
                default:
                    return "";
            }
        }
   }
}
