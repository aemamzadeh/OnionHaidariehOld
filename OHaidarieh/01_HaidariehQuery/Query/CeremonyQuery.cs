using _0_Framework.Application;
using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Multimedias;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.GuestAgg;
using Haidarieh.Domain.MultimediaAgg;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    public class CeremonyQuery : ICeremonyQuery
    {
        private readonly HContext _hContext;

        public CeremonyQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyQueryModel> GetCeremonies()
        {
            return _hContext.Ceremonies.Where(x => x.Status == true).Select(x => new CeremonyQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                Status = x.Status
            }).ToList();
        }

            public List<CeremonyQueryModel> GetComing()
            {
                return _hContext.CeremonyGuests.Include(x => x.Ceremony).
                                                    Where(x=>x.Ceremony.Status==true && 
                                                    DateTime.Now.Date <= x.Ceremony.CeremonyDate.Date &&
                                                    DateTime.Compare(x.Ceremony.CeremonyDate.AddHours(4), DateTime.Now) > 0) 
                                                    .Select(x => new CeremonyQueryModel
                                                    {
                                                        Id = x.Ceremony.Id,
                                                        Title = x.Ceremony.Title,
                                                        CeremonyDateFa = x.Ceremony.CeremonyDate.ToFarsi(),
                                                        CeremonyTime=x.Ceremony.CeremonyDate.ToString("HH:mm"),
                                                        CeremonyDate = x.Ceremony.CeremonyDate,
                                                        Image = x.Ceremony.Image,
                                                        ImageAlt=x.Ceremony.ImageAlt,
                                                        ImageTitle=x.Ceremony.ImageTitle,
                                                        IsLive = x.Ceremony.IsLive,
                                                        BannerFile = x.Ceremony.BannerFile,
                                                        Slug = x.Ceremony.Slug,
                                                        Keywords=x.Ceremony.Keywords,
                                                        MetaDescription=x.Ceremony.MetaDescription
                                                    }).AsNoTracking().Take(3).ToList();
                //query = query.Include(x => x.CeremonyGuests.Where(z => z.CeremonyId == x.Id));
                //return query.ToList();

            }
            public List<CeremonyQueryModel> GetPast()
            {
                var pastlist = _hContext.CeremonyGuests.Include(x => x.Ceremony).
                                                Where(x => x.Ceremony.Status == true &&
                                                x.Ceremony.CeremonyDate.Date <= DateTime.Now.Date &&
                                                DateTime.Compare(x.Ceremony.CeremonyDate.AddHours(4), DateTime.Now) < 0).
                                                Select(x => new CeremonyQueryModel
                                                {
                                                    Id = x.Ceremony.Id,
                                                    Title = x.Ceremony.Title,
                                                    CeremonyDateFa = x.Ceremony.CeremonyDate.ToFarsi(),
                                                    CeremonyDate = x.Ceremony.CeremonyDate,
                                                    Image = x.Ceremony.Image,
                                                    ImageAlt = x.Ceremony.ImageAlt,
                                                    ImageTitle = x.Ceremony.ImageTitle,
                                                    IsLive = x.Ceremony.IsLive,
                                                    BannerFile = x.Ceremony.BannerFile,
                                                    Slug = x.Ceremony.Slug,
                                                    Keywords = x.Ceremony.Keywords,
                                                    MetaDescription = x.Ceremony.MetaDescription
                                                }).AsNoTracking().Distinct().Take(6).ToList();
            return pastlist;
            }
            public List<CeremonyQueryModel> GetAll()
            {
                return _hContext.CeremonyGuests.Where(x => x.Ceremony.Status == true).Select(x => new CeremonyQueryModel
                {
                    Id = x.Id,
                    Title = x.Ceremony.Title,
                    CeremonyDateFa = x.Ceremony.CeremonyDate.ToFarsi(),
                    CeremonyDate = x.Ceremony.CeremonyDate,
                    Image = x.Ceremony.Image,
                    ImageAlt = x.Ceremony.ImageAlt,
                    ImageTitle = x.Ceremony.ImageTitle,
                    IsLive = x.Ceremony.IsLive,
                    BannerFile = x.Ceremony.BannerFile,
                    Slug = x.Ceremony.Slug,
                    Keywords = x.Ceremony.Keywords,
                    MetaDescription = x.Ceremony.MetaDescription
                }).AsNoTracking().ToList();

            }

            public List<CeremonyQueryModel> GetCeremonyWithMultimedias()
            {
                return _hContext.Ceremonies.Include(x => x.Multimedias).
                                                Include(x => x.CeremonyGuests).
                                                ThenInclude(x=>x.Guest).
                                                Where(x => x.Status == true).Select(x => new CeremonyQueryModel
                                                {
                                                    Id = x.Id,
                                                    Title = x.Title,
                                                    CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                                                    CeremonyDate = x.CeremonyDate,
                                                    Image = x.Image,
                                                    ImageAlt = x.ImageAlt,
                                                    ImageTitle = x.ImageTitle,
                                                    IsLive = x.IsLive,
                                                    BannerFile = x.BannerFile,
                                                    Slug = x.Slug,
                                                    Keywords = x.Keywords,
                                                    MetaDescription = x.MetaDescription,
                                                    CeremonyGuests=MapCeremonyGuests(x.CeremonyGuests),
                                                    Multimedias = MapMultimedias(x.Multimedias)
                                                    
                                                }).AsNoTracking().ToList();
            }

            private static List<MultimediaQueryModel> MapMultimedias(List<Multimedia> multimedias)
            {

                return multimedias.Select(x => new MultimediaQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    FileAddress = x.FileAddress,
                    FileAlt = x.FileAlt,
                    FileTitle = x.FileTitle
                }).ToList();
            }

        private static List<CeremonyGuestQueryModel> MapCeremonyGuests(List<CeremonyGuest> ceremonyGuests)
        {

            return ceremonyGuests.Select(x => new CeremonyGuestQueryModel
            {
                Id = x.Id,
                CeremonyId=x.CeremonyId,
                GuestId=x.GuestId,
                Guest=x.Guest.FullName,
                GuestType=GuestTypes.GetGuestType(x.Guest.GuestType)

            }).ToList();
        }

        public CeremonyQueryModel GetCeremonyWithMultimedias(string id)
            {
                var ceremonies = _hContext.Ceremonies.Include(x => x.CeremonyGuests).
                                                ThenInclude(x => x.Guest).
                                                Where(x => x.Status == true).Select(x => new CeremonyQueryModel
                                                {
                                                    Id = x.Id,
                                                    Title = x.Title,
                                                    CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                                                    CeremonyDate = x.CeremonyDate,
                                                    Image = x.Image,
                                                    ImageAlt = x.ImageAlt,
                                                    ImageTitle = x.ImageTitle,
                                                    IsLive = x.IsLive,
                                                    BannerFile = x.BannerFile,
                                                    Slug = x.Slug,
                                                    Keywords = x.Keywords,
                                                    MetaDescription = x.MetaDescription,
                                                    CeremonyGuests = MapCeremonyGuests(x.CeremonyGuests),
                                                    Multimedias = MapMultimedias(x.Multimedias)
                                                }).AsNoTracking().FirstOrDefault(x => x.Slug == id);
                return ceremonies;
            }

            public List<CeremonyQueryModel> Search(string phrase)
            {
            var query = _hContext.Ceremonies.Where(x => x.Status == true).Select(x => new CeremonyQueryModel
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                                    CeremonyDate = x.CeremonyDate,
                                    Image = x.Image,
                                    ImageAlt = x.ImageAlt,
                                    ImageTitle = x.ImageTitle,
                                    IsLive = x.IsLive,
                                    BannerFile = x.BannerFile,
                                    Slug = x.Slug,
                                    Keywords = x.Keywords,
                                    MetaDescription = x.MetaDescription,
                                    CeremonyGuests = MapCeremonyGuests(x.CeremonyGuests),
                                    Multimedias = MapMultimedias(x.Multimedias)
                                }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(phrase))
                query = query.Where(x => x.Title.Contains(phrase));
            var result = query.OrderByDescending(x => x.Id).ToList();
            return result;
            }

        //---------------------
        //public List<CeremonyGuestQueryModel> GetCeremonyGuestWithMultimedias2(string id)
        //{
        //    return _hContext.CeremonyGuests.Include(x => x.Multimedias).
        //                                    ThenInclude(x => x.CeremonyGuest).
        //                                    ThenInclude(x => x.Guest).
        //                                    Where(x => x.Status == true && x.Slug == id).Select(x => new CeremonyGuestQueryModel
        //                                    {
        //                                        Id = x.Id,
        //                                        //Ceremony = x.Ceremony.Title,
        //                                        //CeremonyDateFa = x.CeremonyDate.ToFarsi(),
        //                                        Guest = x.Guest.FullName,
        //                                        Slug = x.Slug,
        //                                        Multimedias = MapMultimedias(x.Multimedias)
        //                                    }).AsNoTracking().ToList();
        //}

        //public List<CeremonyGuestQueryModel> GetCeremonyGuestWithMultimedias2(long id)
        //{
        //    var ceremonyGuest = _hContext.CeremonyGuests.Include(x => x.Guest).
        //                                    Include(x => x.Multimedias).
        //                                    ThenInclude(x => x.CeremonyGuest).
        //                                    ThenInclude(x => x.Ceremony).
        //                                    Where(x => x.Status == true && x.CeremonyId == id).Select(x => new CeremonyGuestQueryModel
        //                                    {
        //                                        Id = x.Id,
        //                                        Ceremony = x.Ceremony.Title,
        //                                        CeremonyDateFa = x.CeremonyDate.Date.ToFarsi(),
        //                                        Guest = x.Guest.FullName,
        //                                        Slug = x.Slug,
        //                                        Multimedias = MapMultimedias(x.Multimedias)
        //                                    }).AsNoTracking().ToList();
        //    return ceremonyGuest;
        //}
    }
    }





