using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Domain.CeremonyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class CeremonyRepository : RepositoryBase<long,Ceremony>, ICeremonyRepository
    {
        private readonly HContext _hContext;

        public CeremonyRepository(HContext hContext):base(hContext)
        {
            _hContext = hContext;
        }

        public EditCeremony GetDetail(long id)
        {
            return _hContext.Ceremonies.Select(x => new EditCeremony()
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CeremonyViewModel> Search(CeremonySearchModel searchModel)
        {
            var query = _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
