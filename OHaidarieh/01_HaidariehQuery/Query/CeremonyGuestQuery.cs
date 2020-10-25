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
                CeremonyDate = x.CeremonyDate,
                Image = x.Image,
                IsLive = x.IsLive,
                Guest = x.Guest.FullName,
                BannerFile = x.BannerFile
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
                                                    CeremonyDate = x.CeremonyDate,
                                                    Image = x.Image,
                                                    IsLive = x.IsLive,
                                                    Guest = x.Guest.FullName,
                                                    BannerFile = x.BannerFile
                                                }).ToList();
        }
        public List<CeremonyGuestQueryModel> GetAll()
        {
            return _hContext.CeremonyGuests.Where(x=>x.Status==true).Select(x => new CeremonyGuestQueryModel
            {
                Id = x.Id,
                Ceremony = x.Ceremony.Title,
                CeremonyDate = x.CeremonyDate,
                Image = x.Image,
                IsLive = x.IsLive,
                Guest = x.Guest.FullName,
                BannerFile = x.BannerFile
            }).ToList();

        }

        public List<CeremonyGuestQueryModel> GetCeremonyGuestWithMultimedias()
        {
            return _hContext.CeremonyGuests.Include(x => x.Ceremony).Include(x => x.Multimedias).
                                            ThenInclude(x => x.CeremonyGuest).
                                            Where(x => x.Status == true).Select(x => new CeremonyGuestQueryModel
                                            {
                                                Id = x.Id,
                                                Ceremony = x.Ceremony.Title,
                                                Multimedias = MapMultimedias(x.Multimedias)
                                            }).ToList();
        }

        private List<MultimediaQueryModel> MapMultimedias(List<Multimedia> multimedias)
        {
            var result = new List<MultimediaQueryModel>();
            foreach (var multimedia in multimedias)
            {
                var item = new MultimediaQueryModel
                {
                    Id = multimedia.Id,
                    CeremonyGuest = multimedia.CeremonyGuest.Ceremony.Title,
                    CeremonyGuestId = multimedia.CeremonyGuestId,
                    Title = multimedia.Title,
                    FileAddress = multimedia.FileAddress,
                    FileAlt = multimedia.FileAlt,
                    FileTitle = multimedia.FileTitle
                };
                result.Add(item);
            }

            return result;
        }
    }
}

