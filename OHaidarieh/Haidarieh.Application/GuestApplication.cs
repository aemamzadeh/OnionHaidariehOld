using _0_Framework.Application;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Domain.GuestAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class GuestApplication : IGuestApplication
    {
        private readonly IGuestRepository _guestRepository;

        public GuestApplication(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public OperationResult Create(CreateGuest command)
        {
            var operation = new OperationResult();
            if (_guestRepository.Exist(x => x.FullName == command.FullName))
                return operation.Failed(ApplicationMessages.DuplicatedRecord); 
            var guest = new Guest(command.FullName, command.Tel, command.Image, command.ImageAlt,
                command.ImageTitle, command.GuestType, command.Coordinator);
            _guestRepository.Create(guest);
            _guestRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditGuest command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _guestRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if(_guestRepository.Exist(x=>x.FullName==command.FullName && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            editItem.Edit(command.FullName, command.Tel, command.Image, command.ImageAlt,
                command.ImageTitle, command.GuestType, command.Coordinator);
            _guestRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditGuest GetDetail(long Id)
        {
            return _guestRepository.GetDetail(Id);
        }

        public List<GuestViewModel> GetGuests()
        {
            return _guestRepository.GetGuests();
        }

        public List<GuestViewModel> Search(GuestSearchModel searchModel)
        {
            return _guestRepository.Search(searchModel);
        }
    }
}
