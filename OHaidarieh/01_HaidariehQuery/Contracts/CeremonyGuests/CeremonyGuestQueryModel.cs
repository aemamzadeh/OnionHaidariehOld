using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.CeremonyGuests
{
    public class CeremonyGuestQueryModel
    {
        public long Id { get; set; }
        public long GuestId { get;  set; }
        public long CeremonyId { get;  set; }
        public DateTime CeremonyDate { get;  set; }
        public bool IsLive { get;  set; }
        public string BannerFile { get;  set; }
        public bool Status { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }
        public string Guest { get; set; }
        public string Ceremony { get; set; }
    }
}
