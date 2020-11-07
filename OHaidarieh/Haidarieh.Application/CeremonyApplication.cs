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
        public Ceremony ceremony { get; set; }
        public CeremonyApplication(ICeremonyRepository ceremonyRepository)
        {
            _ceremonyRepository = ceremonyRepository;
        }

        public OperationResult Create(CreateCeremony command)
        {
            var operation = new OperationResult();
            if (_ceremonyRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
 
            ceremony = new Ceremony(command.Title, command.CeremonyDateFa.ToGeorgianDateTime());
            CreateOperationLog(ceremony.Id, 1);
            _ceremonyRepository.Create(ceremony);   
            _ceremonyRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult CreateOperationLog(long id, int operationType)
        {
            var operation = new OperationResult();
            
            //var ceremony = _ceremonyRepository.Get(id);
            //var cer = new CeremonyOperation(operationType, 78, "Description", id);
            //if (ceremony == null)
            //    return operation.Failed(ApplicationMessages.RecordNotFound);
            ceremony.CreateOperationLog(operationType, 78, "Description", id);
            _ceremonyRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCeremony command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            ceremony=_ceremonyRepository.Get(command.Id);
            if (ceremony == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_ceremonyRepository.Exist(x=>x.Title==command.Title && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            ceremony.Edit(command.Title, command.CeremonyDateFa.ToGeorgianDateTime());
            _ceremonyRepository.SaveChanges();
            CreateOperationLog(ceremony.Id, 2);

            return operation.Succedded();

        }

        public List<CeremonyViewModel> GetCeremonies()
        {
            return _ceremonyRepository.GetCeremonies();
        }

        public List<CeremonyOperationViewModel> GetCeremonyWithOperationsLog()
        {
            return _ceremonyRepository.GetCeremonyWithOperationsLog();
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
