using _0_Framework.Application;
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

        public CeremonyGuestApplication(ICeremonyGuestRepository ceremonyGuestRepository)
        {
            _ceremonyGuestRepository = ceremonyGuestRepository;
        }

        public OperationResult Create(CreateCeremonyGuest command)
        {
            var operation = new OperationResult();

            if (_ceremonyGuestRepository.Exist(x=>x.GuestId==command.GuestId && x.CeremonyId == command.CeremonyId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var ceremonyGuest = new CeremonyGuest(command.GuestId,command.CeremonyId, command.CeremonyDate, command.Satisfication,
                command.IsLive, command.BannerFile, command.Image, command.ImageAlt, command.ImageTitle, command.Keywords,
                       command.MetaDescription, slug);

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
            if (_ceremonyGuestRepository.Exist(x => x.CeremonyId == command.CeremonyId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            editItem.Edit(command.GuestId, command.CeremonyId, command.CeremonyDate, command.Satisfication,
                command.IsLive, command.BannerFile, command.Image, command.ImageAlt, command.ImageTitle, command.Keywords,
                       command.MetaDescription, command.Slug);
            _ceremonyGuestRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<CeremonyGuestViewModel> GetCeremonyGuests()
        {
            return _ceremonyGuestRepository.GetCeremonyGuests();
        }

        public EditCeremonyGuest GetDetail(long Id)
        {
            return _ceremonyGuestRepository.GetDetail(Id);
        }

        public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            return _ceremonyGuestRepository.Search(searchModel);
        }
    }
}
