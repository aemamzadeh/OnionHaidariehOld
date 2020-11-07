using _0_Framework.Application;
using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Multimedias;
using Haidarieh.Domain.MultimediaAgg;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    public class CeremonyGuestQuery : ICeremonyGuestQuery
    {
        private readonly HContext _hContext;

        public CeremonyGuestQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyGuestQueryModel> GetComing()
        {
            return _hContext.CeremonyGuests.Where(x=> x.Status == true && 
                                                DateTime.Now.Date <= x.CeremonyDate.Date &&
                                                DateTime.Compare(x.CeremonyDate.AddHours(4),DateTime.Now)>0).
                                                Select(x=>new CeremonyGuestQueryModel 
            {
                Id=x.Id,
                Ceremony = x.Ceremony.Title,
                CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                Image = x.Image,
                IsLive = x.IsLive,
                Guest = x.Guest.FullName,
                BannerFile = x.BannerFile,
                Slug=x.Slug
            }).ToList();
        }
        public List<CeremonyGuestQueryModel> GetPast()
        {
            return _hContext.CeremonyGuests.Where(x=>x.Status == true && 
                                                x.CeremonyDate.Date <= DateTime.Now.Date && 
                                                DateTime.Compare(x.CeremonyDate.AddHours(4),DateTime.Now)<0).
                                                Select(x => new CeremonyGuestQueryModel
                                                {
                                                    Id = x.Id,
                                                    Ceremony = x.Ceremony.Title,
                                                    CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                                                    Image = x.Image,
                                                    IsLive = x.IsLive,
                                                    Guest = x.Guest.FullName,
                                                    BannerFile = x.BannerFile,
                                                    Slug = x.Slug
                                                }).ToList();
        }
        public List<CeremonyGuestQueryModel> GetAll()
        {
            return _hContext.CeremonyGuests.Where(x=>x.Status==true).Select(x => new CeremonyGuestQueryModel
            {
                Id = x.Id,
                Ceremony = x.Ceremony.Title,
                CeremonyDateFa = x.CeremonyDate.ToFarsi(),
                Image = x.Image,
                IsLive = x.IsLive,
                Guest = x.Guest.FullName,
                BannerFile = x.BannerFile,
                Slug = x.Slug
            }).ToList();

        }

        public List<CeremonyGuestQueryModel> GetCeremonyGuestWithMultimedias()
        {
            return _hContext.CeremonyGuests.Include(x => x.Ceremony).
                                            Include(x => x.Multimedias).
                                            ThenInclude(x => x.CeremonyGuest).
                                            Where(x => x.Status == true).Select(x => new CeremonyGuestQueryModel
                                            {
                                                Id = x.Id,
                                                Ceremony = x.Ceremony.Title,
                                                CeremonyDateFa=x.CeremonyDate.ToFarsi(),
                                                Guest=x.Guest.FullName,
                                                Slug=x.Slug,
                                                Multimedias = MapMultimedias(x.Multimedias)
                                            }).ToList();
        }

        private static List<MultimediaQueryModel> MapMultimedias(List<Multimedia> multimedias)
        {
            
            return multimedias.Select(x => new MultimediaQueryModel
            {
                Id = x.Id,
                CeremonyGuest = x.CeremonyGuest.Ceremony.Title,
                CeremonyGuestId = x.CeremonyGuestId,
                Title = x.Title,
                FileAddress = x.FileAddress,
                FileAlt = x.FileAlt,
                FileTitle = x.FileTitle
            }).ToList();
        }


        

        public CeremonyGuestQueryModel GetCeremonyGuestWithMultimedias(string slug)
        {
            var ceremonyGuest= _hContext.CeremonyGuests.Include(x => x.Multimedias).
                                            //ThenInclude(x => x.CeremonyGuest).
                                            //ThenInclude(x => x.Ceremony).
                                            Where(x => x.Status == true).Select(x => new CeremonyGuestQueryModel
                                            {
                                                Id = x.Id,
                                                Ceremony = x.Ceremony.Title,
                                                CeremonyDateFa = x.CeremonyDate.Date.ToFarsi(),
                                                Guest = x.Guest.FullName,
                                                Slug = x.Slug,
                                                Multimedias = MapMultimedias(x.Multimedias)
                                            }).FirstOrDefault(x=>x.Slug==slug);
            return ceremonyGuest;
        }
    }
}

