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

            if (_ceremonyGuestRepository.Exist(x=>x.GuestId==command.GuestId))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");

            var ceremonyGuest = new CeremonyGuest(command.GuestId,command.CeremonyId, command.CeremonyDate, command.Satisfication,
                command.IsLive, command.BannerFile, command.Image, command.ImageAlt, command.ImageTitle, command.Keywords,
                       command.MetaDescription, command.Slug);

            _ceremonyGuestRepository.Create(ceremonyGuest);
            return operation.Succedded();
        }

        public OperationResult Edit(EditCeremonyGuest command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            throw new NotImplementedException();
        }

        public EditCeremonyGuest GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
