using _0_Framework.Domain;
using Haidarieh.Application.Contracts.CeremonyGuest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.CeremonyGuestAgg
{
    public interface ICeremonyGuestRepository : IRepository<long, CeremonyGuest>
    {
        EditCeremonyGuest GetDetail(long Id);
        List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel);
        List<CeremonyGuestViewModel> GetCeremonyGuests();
    }
}
