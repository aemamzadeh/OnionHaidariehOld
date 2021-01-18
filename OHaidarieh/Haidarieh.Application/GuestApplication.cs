using _0_Framework.Application;
using Haidarieh.Application.Contracts.CeremonyGuest;
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
        private readonly IFileUploader _fileUploader;


        public GuestApplication(IGuestRepository guestRepository, IFileUploader fileUploader)
        {
            _guestRepository = guestRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateGuest command)
        {
            var operation = new OperationResult();
            if (_guestRepository.Exist(x => x.FullName == command.FullName))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            
            var slug = command.FullName.Slugify();

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            var ImagePath = $"{ImageFolderName}/{slug}";
            var imageFileName = _fileUploader.Upload(command.Image, ImagePath); 
            
            var guest = new Guest(command.FullName, command.Tel, command.Email, imageFileName, command.ImageAlt,
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

            var slug = command.FullName.Slugify();

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            var ImagePath = $"{ImageFolderName}/{slug}";
            var imageFileName = _fileUploader.Upload(command.Image, ImagePath);

            editItem.Edit(command.FullName, command.Tel, command.Email, imageFileName, command.ImageAlt,
                command.ImageTitle, command.GuestType, command.Coordinator);
            _guestRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditGuest GetDetail(long Id)
        {
            return _guestRepository.GetDetail(Id);
        }

        public List<EditGuest> GetGuestsInfo(List<CeremonyGuestViewModel> guests = null)
        {
            var guestInfoList = new List<EditGuest>();
            foreach (var item in guests)
            {
                var guestInfo = GetDetail(item.GuestId);
                guestInfoList.Add(guestInfo);

            }
            return guestInfoList;
        }


        public List<GuestViewModel> GetGuests(long id=0)
        {
            return _guestRepository.GetGuests();
        }

        public List<GuestViewModel> Search(GuestSearchModel searchModel)
        {
            return _guestRepository.Search(searchModel);
        }
    }
}
