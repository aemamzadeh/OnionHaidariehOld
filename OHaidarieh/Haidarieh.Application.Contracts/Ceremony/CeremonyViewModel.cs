using Haidarieh.Application.Contracts.CeremonyGuest;
using System;
using System.Collections.Generic;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CeremonyViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string CeremonyDate { get; set; }
        public bool IsLive { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public List<CeremonyOperationViewModel> CeremonyOperations { get; set; }
        public List<CeremonyGuestViewModel> CeremonyGuests { get; set; }



    }
}
