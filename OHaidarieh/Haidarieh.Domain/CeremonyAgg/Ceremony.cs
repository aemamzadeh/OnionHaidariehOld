using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.MultimediaAgg;
using System;
using System.Collections.Generic;

namespace Haidarieh.Domain.CeremonyAgg
{
    public class Ceremony:EntityBase
    {
        public string Title { get; private set; }
        public DateTime CeremonyDate { get; private set; }
        public bool IsLive { get; private set; }
        public string BannerFile { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool Status { get; private set; }
        public List<CeremonyGuest> CeremonyGuests { get; private set; }
        public List<CeremonyOperation> CeremonyOperations { get; private set; }
        public List<Multimedia> Multimedias { get; private set; }

        public Ceremony(string title, DateTime ceremonyDate, bool isLive, string bannerFile, string image, string imageAlt, 
            string imageTitle, string keywords, string metaDescription, string slug)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
            IsLive = isLive;
            BannerFile = bannerFile;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            Status = true;
            CeremonyGuests = new List<CeremonyGuest>();
            CeremonyOperations = new List<CeremonyOperation>();
            Multimedias = new List<Multimedia>();
        }

        public void Edit(string title, DateTime ceremonyDate, bool isLive, string bannerFile, string image, string imageAlt,
            string imageTitle, string keywords, string metaDescription, string slug)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
            IsLive = isLive;
            if (!string.IsNullOrWhiteSpace(bannerFile))
                BannerFile = bannerFile;
            if (!string.IsNullOrWhiteSpace(image))
                Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            CeremonyGuests = new List<CeremonyGuest>();
            CeremonyOperations = new List<CeremonyOperation>();
            Multimedias = new List<Multimedia>();
        }
        public void CreateOperationLog(int operation, long operatorId, string description, long ceremonyId)
        {
            var operationRecord = new CeremonyOperation(operation, operatorId, description, ceremonyId);
            CeremonyOperations.Add(operationRecord);
        }

    }
}
