
using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Contracts.Guests;
using System.Collections.Generic;

namespace _01_HaidariehQuery.Contracts.CeremonyGuests
{
    public class CeremonyGuestQueryModel
    {
        public long Id { get; set; }
        public long GuestId { get;  set; }
        public long CeremonyId { get;  set; }
        public string GuestType { get; set; }
        public string Ceremony { get; set; }
        public string Guest { get; set; }
    }
}
