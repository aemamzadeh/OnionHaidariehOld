using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Contracts.CeremonyGuests;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    class CeremonyQuery : ICeremonyQuery
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
                Id=x.Id,
                Title=x.Title,
                CeremonyDate=x.CeremonyDate,
                Status=x.Status
            }).ToList();
        }

        public List<CeremonyQueryModel> GetCeremoniesWithCeremonyGuests()
        {
            return _hContext.Ceremonies.Include(x => x.CeremonyGuests).ThenInclude(x=>x.Ceremony).Where(x=>x.Status==true).Select(x => new CeremonyQueryModel 
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyGuests=MapCeremonyGuests(x.CeremonyGuests)
            }).ToList();
        }

        private List<CeremonyGuestQueryModel> MapCeremonyGuests(List<CeremonyGuest> ceremonyGuests)
        {
            return _hContext.CeremonyGuests.Where(x => x.Status == true).Select(x=>new CeremonyGuestQueryModel
            {
                Id=x.Id,
                Ceremony=x.Ceremony.Title,
                CeremonyDate=x.CeremonyDate,
                Image=x.Image,
                ImageAlt=x.ImageAlt,
                ImageTitle=x.ImageTitle,
                IsLive=x.IsLive,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Slug=x.Slug,
                Status=x.Status

            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
