using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Domain.CeremonyGuestAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class CeremonyGuestRepository : RepositoryBase<long,CeremonyGuest>, ICeremonyGuestRepository
    {
        private readonly HContext _hContext;

        public CeremonyGuestRepository(HContext hContext):base(hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyGuestViewModel> GetCeremonyGuests()
        {
            return _hContext.CeremonyGuests.Select(x => new CeremonyGuestViewModel
            {
                Id=x.Id,
                GuestId=x.GuestId,
                CeremonyId=x.CeremonyId,
                Ceremony=x.Ceremony.Title,
                CeremonyDate=x.CeremonyDate.ToFarsi(),
                Image=x.Image,
                IsLive=x.IsLive,
                Satisfication=x.Satisfication
            }).ToList();
        }

        public EditCeremonyGuest GetDetail(long Id)
        {
            return _hContext.CeremonyGuests.Select(x => new EditCeremonyGuest
            {
                Id=x.Id,
                GuestId = x.GuestId,
                CeremonyId = x.CeremonyId,
                CeremonyDate = x.CeremonyDate.ToString(CultureInfo.InvariantCulture),
                Satisfication=x.Satisfication,
                IsLive=x.IsLive,
                BannerFile=x.BannerFile,
                //Image=x.Image,
                ImageAlt=x.ImageAlt,
                ImageTitle=x.ImageTitle,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Slug=x.Slug,
                
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            var query = _hContext.CeremonyGuests.Include(x=>x.Guest).Include(x=>x.Ceremony)
                .Select(x => new CeremonyGuestViewModel
            {
                Id=x.Id,
                Guest = x.Guest.FullName,
                Ceremony = x.Ceremony.Title,
                GuestId=x.GuestId,
                CeremonyId=x.CeremonyId,
                CeremonyDate = x.CeremonyDate.ToFarsi(),
                Satisfication = x.Satisfication,
                IsLive = x.IsLive,
                Image = x.Image                
            });
            if (searchModel.GuestId!=0)
                query = query.Where(x => x.GuestId==searchModel.GuestId);

            if (searchModel.CeremonyId != 0)
                query = query.Where(x => x.CeremonyId == searchModel.CeremonyId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
