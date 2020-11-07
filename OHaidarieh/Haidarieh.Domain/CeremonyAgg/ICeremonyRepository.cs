using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Ceremony;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Haidarieh.Domain.CeremonyAgg
{
    public interface ICeremonyRepository : IRepository<long,Ceremony>
    {
        List<CeremonyViewModel> GetCeremonies();
        EditCeremony GetDetail(long id);
        List<CeremonyViewModel> Search(CeremonySearchModel searchModel);
        List<CeremonyOperationViewModel> GetCeremonyWithOperationsLog();
    }
}
