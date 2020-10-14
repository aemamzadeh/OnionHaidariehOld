using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Sponsor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.SponsorAgg
{
    public interface ISponsorRepository : IRepository<long, Sponsor>
    {
        EditSponsor GetDetail(long Id);
        List<SponsorViewModel> Search(SponsorSearchModel searchModel);
    }
}
