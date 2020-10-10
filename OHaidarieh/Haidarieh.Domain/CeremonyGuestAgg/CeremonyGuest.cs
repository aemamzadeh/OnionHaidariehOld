using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.GuestAgg;
using Haidarieh.Domain.MultimediaAgg;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace Haidarieh.Domain.CeremonyGuestAgg 
{

    public class CeremonyGuest : EntityBase
    {
        public long GuestId { get; private set; }
        public DateTime CeremonyDate { get; private set; }
        public float Satisfication { get; private set; }
        public bool IsLive { get; private set; }
        public string BannerFile { get; private set; }
        public bool Status { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public Guest Guest { get;  set; }
        public Ceremony Ceremony { get;  set; }
        public List<Multimedia> Multimedias { get;  set; }

        public CeremonyGuest(long guestId, DateTime ceremonyDate, float satisfication, bool isLive, 
            string bannerFile, string image, string imageAlt, string imageTitle, string keywords, 
            string metaDescription, string slug)
        {
            GuestId = guestId;
            CeremonyDate = ceremonyDate;
            Satisfication = satisfication;
            IsLive = isLive;
            BannerFile = bannerFile;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Status = true;
            Multimedias = new List<Multimedia>();
        }
        public void Edit(long guestId, DateTime ceremonyDate, float satisfication, bool isLive,
            string bannerFile, string image, string imageAlt, string imageTitle, string keywords,
            string metaDescription, string slug)
        {
            GuestId = guestId;
            CeremonyDate = ceremonyDate;
            Satisfication = satisfication;
            IsLive = isLive;
            BannerFile = bannerFile;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Status = true;
            Multimedias = new List<Multimedia>();
        }
    }
}
