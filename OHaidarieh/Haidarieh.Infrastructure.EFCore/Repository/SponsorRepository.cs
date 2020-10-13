using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Sponsor;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.SponsorAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class SponsorRepository : RepositoryBase<long, Sponsor>, ISponsorRepository
    {
        private readonly HContext _hContext;

        public SponsorRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditSponsor GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<SponsorViewModel> Search(SponsorSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
