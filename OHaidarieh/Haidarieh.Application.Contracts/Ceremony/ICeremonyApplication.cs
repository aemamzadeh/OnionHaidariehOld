using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public interface ICeremonyApplication
    {
        OperationResult Create(CreateCeremony command);
        OperationResult Edit(EditCeremony command);
        OperationResult CreateOperationLog(long Id,int OperationType);
        List<CeremonyViewModel> Search(CeremonySearchModel searchModel);
        EditCeremony GetDetail(long Id);
        List<CeremonyViewModel> GetCeremonies();
        List<CeremonyOperationViewModel> GetCeremonyWithOperationsLog();

    }
}
