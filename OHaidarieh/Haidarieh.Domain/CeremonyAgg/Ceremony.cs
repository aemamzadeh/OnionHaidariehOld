using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyGuestAgg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Haidarieh.Domain.CeremonyAgg
{
    public class Ceremony:EntityBase
    {
        public string Title { get; private set; }
        public DateTime CeremonyDate { get; private set; }
        public bool Status { get; private set; }
        public List<CeremonyGuest> CeremonyGuests { get; private set; }



        public Ceremony(string title,DateTime ceremonyDate)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
            Status = true;
            CeremonyGuests = new List<CeremonyGuest>();
        }

        public void Edit(string title, DateTime ceremonyDate)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
        }

    }
}
