using _0_Framework.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Domain.CeremonyGuestAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class CeremonyGuestApplication : ICeremonyGuestApplication
    {
        private readonly ICeremonyGuestRepository _ceremonyGuestRepository;
        private readonly IFileUploader _fileUploader;
        public CeremonyGuestApplication(ICeremonyGuestRepository ceremonyGuestRepository, IFileUploader fileUploader)
        {
            _ceremonyGuestRepository = ceremonyGuestRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateCeremonyGuest command)
        {
            var operation = new OperationResult();

            if (_ceremonyGuestRepository.Exist(x=>x.GuestId==command.GuestId && x.CeremonyId == command.CeremonyId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var ceremonyGuest = new CeremonyGuest(command.GuestId,command.CeremonyId,command.Satisfication);

            _ceremonyGuestRepository.Create(ceremonyGuest);
            _ceremonyGuestRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCeremonyGuest command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _ceremonyGuestRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_ceremonyGuestRepository.Exist(x => x.GuestId == command.GuestId && x.CeremonyId == command.CeremonyId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            editItem.Edit(command.GuestId, command.CeremonyId, command.Satisfication);
            _ceremonyGuestRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<CeremonyGuestViewModel> GetCeremonyGuests(long id=0)
        {
            return _ceremonyGuestRepository.GetCeremonyGuests(id);
        }

        public EditCeremonyGuest GetDetail(long Id)
        {
            return _ceremonyGuestRepository.GetDetail(Id);
        }

        public List<CeremonyViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            return _ceremonyGuestRepository.Search(searchModel);
        }
    }
}
