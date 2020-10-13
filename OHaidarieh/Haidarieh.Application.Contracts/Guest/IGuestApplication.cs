using _0_Framework.Application;
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
    }
}
