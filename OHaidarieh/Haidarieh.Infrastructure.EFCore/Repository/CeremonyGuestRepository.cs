using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Domain.CeremonyGuestAgg;
using System;
using System.Collections.Generic;
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

        public EditCeremonyGuest GetDetail(long Id)
        {
            return _hContext.CeremonyGuests.Select(x => new EditCeremonyGuest()
            {
                GuestId = x.GuestId,
                CeremonyId = x.CeremonyId,
                CeremonyDate = x.CeremonyDate,
                Satisfication=x.Satisfication,
                IsLive=x.IsLive,
                BannerFile=x.BannerFile,
                Image=x.Image,
                ImageAlt=x.ImageAlt,
                ImageTitle=x.ImageTitle,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Slug=x.Slug
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            return _hContext.CeremonyGuests.Select(x => new CeremonyGuestViewModel()
            {
                GuestId = x.GuestId,
                CeremonyId = x.CeremonyId,
                CeremonyDate = x.CeremonyDate,
                Satisfication = x.Satisfication,
                IsLive = x.IsLive,
                Image = x.Image
            }).ToList();
        }
    }
}
