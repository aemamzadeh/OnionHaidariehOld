using _01_HaidariehQuery.Contracts.CeremonyGuests;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Guests
{
    public class GuestQueryModel
    {
        public string FullName { get;  set; }
        public string Tel { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public string GuestType { get;  set; }
        public string Coordinator { get;  set; }
        public bool Status { get;  set; }
        public List<CeremonyGuestQueryModel> CeremonyGuests { get; set; }

    }
}
