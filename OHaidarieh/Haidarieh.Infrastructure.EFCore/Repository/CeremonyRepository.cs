using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Domain.CeremonyAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class CeremonyRepository : RepositoryBase<long, Ceremony>, ICeremonyRepository
    {
        private readonly HContext _hContext;

        public CeremonyRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyViewModel> GetCeremonies()
        {
            return _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }

        public List<CeremonyViewModel> GetCeremonyWithOperationsLog2()
        {
            return _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate.ToFarsi(),
                CeremonyOperations = GetCeremonyOperationsLog(x.CeremonyOperations)
            }).AsNoTracking().ToList();
        }

        public List<CeremonyOperationViewModel> GetCeremonyWithOperationsLog()
        {
            var result = new List<CeremonyOperationViewModel>();
            var ceremonies = _hContext.Ceremonies.ToList();
            foreach (var cer in ceremonies)
            {
                foreach (var op in cer.CeremonyOperations)
                {
                    var ops = new CeremonyOperationViewModel
                    {
                        Id = op.Id,
                        CeremonyId = op.CeremonyId,
                        Ceremony = op.Ceremony.Title,
                        Description = op.Description,
                        Operation = op.Operation,
                        OperationDate = op.OperationDate.ToFarsi(),
                        OperatorId = op.OperatorId
                    };
                    result.Add(ops);
                }
            }

            return result;
        }



        protected static List<CeremonyOperationViewModel> GetCeremonyOperationsLog(List<CeremonyOperation> ceremonyOperations)
        {
            var result = new List<CeremonyOperationViewModel>();
            foreach (var ceremonyOperation in ceremonyOperations)
            {
                var Item = new CeremonyOperationViewModel
                {
                    Id = ceremonyOperation.Id,
                    CeremonyId = ceremonyOperation.CeremonyId,
                    Ceremony = ceremonyOperation.Ceremony.Title,
                    Description = ceremonyOperation.Description,
                    Operation = ceremonyOperation.Operation,
                    OperationDate = ceremonyOperation.OperationDate.ToFarsi(),
                    OperatorId = ceremonyOperation.OperatorId
                };
                result.Add(Item);
            }
            return result;
        }

        public EditCeremony GetDetail(long id)
        {
            //CultureInfo provider = CultureInfo.InvariantCulture;

            return _hContext.Ceremonies.Select(x => new EditCeremony()
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDateFa=x.CeremonyDate.ToString(CultureInfo.InvariantCulture)
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CeremonyViewModel> Search(CeremonySearchModel searchModel)
        {
            var query = _hContext.Ceremonies.Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            return query.OrderByDescending(x => x.Id).ToList();
        }

    }
}
