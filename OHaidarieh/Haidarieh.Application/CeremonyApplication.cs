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
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
 
            var ceremony = new Ceremony(command.Title, command.CeremonyDateFa.ToGeorgianDateTime());
            
            _ceremonyRepository.Create(ceremony);           
            _ceremonyRepository.SaveChanges();
            CreateOperationLog(ceremony.Id, 1);
            return operation.Succedded();

        }

        public OperationResult CreateOperationLog(long id, int operationType)
        {
            var operation = new OperationResult();

            //var cer = new CeremonyOperation(command.Operation, command.OperatorId, command.Description, cid);
            var ceremony = _ceremonyRepository.Get(id);
            if (ceremony == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            ceremony.CreateOperationLog(operationType, 7, "جدید جهت برگزاری مراسم", id);
            _ceremonyRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCeremony command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem=_ceremonyRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_ceremonyRepository.Exist(x=>x.Title==command.Title && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            editItem.Edit(command.Title, command.CeremonyDate);
            _ceremonyRepository.SaveChanges();
            CreateOperationLog(command.Id, 2);

            return operation.Succedded();

        }

        public List<CeremonyViewModel> GetCeremonies()
        {
            return _ceremonyRepository.GetCeremonies();
        }

        public List<CeremonyOperationViewModel> GetCeremonyOperationsLog()
        {
            return _ceremonyRepository.GetCeremonyOperationsLog();
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
