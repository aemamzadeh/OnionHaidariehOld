using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haidarieh.Application.Contracts.Guest
{
    public class GuestTypes
    {
        public const string Reader = "1";
        public const string Lecturer = "2";
        public const string Singer = "3";
        public const string Executor = "4";

        public static string GetGuestType(long id)
        {
            switch (id)
            {
                case 1:
                    return "قاری";
                case 2:
                    return "خطیب";
                case 3:
                    return "مداح";
                case 4:
                    return "مجری";
                default:
                    return "";
            }
        }

    }
}
