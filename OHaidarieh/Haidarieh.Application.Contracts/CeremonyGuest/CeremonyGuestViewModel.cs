using System;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CeremonyGuestViewModel
    {
        public long GuestId { get; set; }
        public long CeremonyId { get; set; }
        public DateTime CeremonyDate { get; set; }
        public float Satisfication { get; set; }
        public bool IsLive { get; set; }
        public string Image { get; set; }
    }
}