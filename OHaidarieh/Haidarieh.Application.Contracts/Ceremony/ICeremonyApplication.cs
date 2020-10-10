using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public interface ICeremonyApplication
    {
        void Create(CreateCeremony command);
        void Edit(EditCeremony command);
        List<CeremonyViewModel> Search(CeremonySearchModel searchModel);
        CeremonyViewModel GetDetail(long Id);

    }
}
