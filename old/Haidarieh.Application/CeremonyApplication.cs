using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Domain.CeremonyAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class CeremonyApplication : ICeremonyApplication
    {
        private readonly ICeremonyRepository _ceremonyRepository;
        public CeremonyApplication(ICeremonyRepository ceremonyRepository)
        {
            _ceremonyRepository = ceremonyRepository;
        }

        public OperationResult Create(CreateCeremony command)
        {
            _ceremonyRepository.Create();
        }

        public OperationResult Edit(EditCeremony command)
        {
            throw new NotImplementedException();
        }

        public CeremonyViewModel GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<CeremonyViewModel> Search(CeremonySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
