using _0_Framework.Application;
using Haidarieh.Application.Contracts.Ceremony;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public interface ICeremonyGuestApplication
    {
        OperationResult Create(CreateCeremonyGuest command);
        OperationResult Edit(EditCeremonyGuest command);
        //Dictionary<long, List<CeremonyGuestViewModel>> Search(CeremonyGuestSearchModel searchModel);
        List<CeremonyViewModel> Search(CeremonyGuestSearchModel searchModel);
        EditCeremonyGuest GetDetail(long Id);
        List<CeremonyGuestViewModel> GetCeremonyGuests(long id=0);

    }
}
