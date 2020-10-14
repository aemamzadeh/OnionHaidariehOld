using _0_Framework.Application;
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
            var operation = new OperationResult();
            if (_ceremonyRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");

            var ceremony = new Ceremony(command.Title, command.CeremonyDate);
            _ceremonyRepository.Create(ceremony);
            _ceremonyRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCeremony command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem=_ceremonyRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed("رکورد وجود ندارد");

            if(_ceremonyRepository.Exist(x=>x.Title==command.Title && x.Id!=command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");

            editItem.Edit(command.Title, command.Status, command.CeremonyDate);
            _ceremonyRepository.SaveChanges();

            return operation.Succedded();

        }

        public EditCeremony GetDetail(long Id)
        {
            return _ceremonyRepository.GetDetail(Id);
        }

        public List<CeremonyViewModel> Search(CeremonySearchModel searchModel)
        {
            return _ceremonyRepository.Search(searchModel);
        }
    }
}
