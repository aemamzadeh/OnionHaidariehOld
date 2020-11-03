using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Domain.CeremonyAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        public List<CeremonyViewModel> GetCeremonies()
        {
            return _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title=x.Title
            }).ToList();
        }

        public List<CeremonyOperationViewModel> GetCeremonyOperationsLog()
        {
            //var result = new List<CeremonyOperationViewModel>();
            var ceremonyList = _hContext.Ceremonies.ToList();
            foreach (var cer in ceremonyList)
            {
                var item = cer.CeremonyOperations.Select(x => new CeremonyOperationViewModel
                {
                    Id = x.Id,
                    CeremonyId = x.CeremonyId,
                    //Ceremony = x.Ceremony.Title,
                    Description = x.Description,
                    Operation = x.Operation,
                    OperationDate = x.OperationDate.ToFarsi(),
                    OperatorId = x.OperatorId
                    
                });
                //result.Add(item);
            }
            return null;
        }

        public EditCeremony GetDetail(long id)
        {
            return _hContext.Ceremonies.Select(x => new EditCeremony()
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDateFa = x.CeremonyDate.ToFarsi(),
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CeremonyViewModel> Search(CeremonySearchModel searchModel)
        {
            var query = _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate.ToFarsi()
            }) ;

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}
