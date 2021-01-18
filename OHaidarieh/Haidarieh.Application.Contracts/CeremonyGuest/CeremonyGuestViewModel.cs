using Haidarieh.Application.Contracts.Guest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CeremonyGuestViewModel
    {
        public long Id { get; set; }
        public long GuestId { get; set; }
        public long CeremonyId { get; set; }
        public int Satisfication { get; set; }
        public string CeremonyDate { get; set; }
        public string Guest { get; set; }
        public string GuestPic { get; set; }
        public string GuestType { get; set; }
        public long GuestTypeL { get; set; }
        public string Ceremony { get; set; }
    }
}