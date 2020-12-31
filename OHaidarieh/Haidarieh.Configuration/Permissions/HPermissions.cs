using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haidarieh.Configuration.Permissions
{
    public static class HPermissions
    {
        //Ceremony
        public const int ListCeremony = 10;
        public const int SearchCeremony = 11;
        public const int CreateCeremony = 12;
        public const int EditCeremony = 13;
        public const int LogCeremony = 14;


        //CeremonyGuest
        public const int ListCeremonyGuest = 20;
        public const int SearchCeremonyGuest = 21;
        public const int CreateCeremonyGuest = 22;
        public const int EditCeremonyGuest = 23;

        //Guest
        public const int ListGuest = 30;
        public const int SearchGuest = 31;
        public const int CreateGuest = 32;
        public const int EditGuest = 33;

        //Member
        public const int ListMember = 40;
        public const int SearchMember = 41;
        public const int CreateMember = 42;
        public const int EditMember = 43;

        //Multimedia
        public const int ListMultimedia = 50;
        public const int SearchMultimedia = 51;
        public const int CreateMultimedia = 52;
        public const int EditMultimedia = 53;

        //Sponsor
        public const int ListSponsor = 60;
        public const int SearchSponsor = 61;
        public const int CreateSponsor = 62;
        public const int EditSponsor = 63;
    }
}
