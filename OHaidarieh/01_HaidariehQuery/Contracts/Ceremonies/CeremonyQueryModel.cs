using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Ceremonies
{
    public class CeremonyQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CeremonyDate { get; set; }
        public string CeremonyTime { get; set; }
        public string CeremonyDateFa { get; set; }
        public bool IsLive { get; set; }
        public bool Status { get; set; }
        public string BannerFile { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public List<MultimediaQueryModel> Multimedias { get; set; }
        public List<CeremonyGuestQueryModel> CeremonyGuests { get; set; }

    }
}
