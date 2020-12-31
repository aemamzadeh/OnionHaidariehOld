using _0_Framework.Application;
using Haidarieh.Application.Contracts.CeremonyGuest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Guest
{
    public interface IGuestApplication
    {
        OperationResult Create(CreateGuest command);
        OperationResult Edit(EditGuest command);
        List<GuestViewModel> Search(GuestSearchModel searchModel);
        EditGuest GetDetail(long Id);
        List<GuestViewModel> GetGuests(long id=0);
        List<EditGuest> GetGuestsInfo(List<CeremonyGuestViewModel> guests = null);
    }
}
