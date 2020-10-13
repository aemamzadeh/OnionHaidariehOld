using System;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CreateCeremonyGuest
    {
        public long GuestId { get;  set; }
        public long CeremonyId { get;  set; }
        public DateTime CeremonyDate { get;  set; }
        public float Satisfication { get;  set; }
        public bool IsLive { get;  set; }
        public string BannerFile { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string Slug { get;  set; }
    }
}