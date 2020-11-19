using System;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CeremonyGuestViewModel
    {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public long CeremonyId { get; set; }
        public float Satisfication { get; set; }
        public string CeremonyDate { get; set; }
        public string Guest { get; set; }
        public string Ceremony { get; set; }
    }
}