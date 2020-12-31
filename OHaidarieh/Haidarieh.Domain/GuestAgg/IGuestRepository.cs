using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Guest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.GuestAgg
{
    public interface IGuestRepository : IRepository<long, Guest>
    {
        EditGuest GetDetail(long Id);
        List<GuestViewModel> Search(GuestSearchModel searchModel);
        List<GuestViewModel> GetGuests(long id=0);
    }
}
