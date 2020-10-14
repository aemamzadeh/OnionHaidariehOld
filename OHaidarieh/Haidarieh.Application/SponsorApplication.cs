using _0_Framework.Application;
using Haidarieh.Application.Contracts.Sponsor;
using Haidarieh.Domain.SponsorAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class SponsorApplication : ISponsorApplication
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorApplication(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }
        public OperationResult Create(CreateSponsor command)
        {
            var operation = new OperationResult();
            if (_sponsorRepository.Exist(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");

            var sponsor = new Sponsor(command.Name, command.Tel, command.Image, command.ImageAlt, command.ImageTitle, command.IsVisible, command.Bio);
            _sponsorRepository.Create(sponsor);
            _sponsorRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSponsor command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _sponsorRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed("رکورد وجود ندارد.");
            if (_sponsorRepository.Exist(x => x.Name == x.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");
            editItem.Edit(command.Name, command.Tel, command.Image, command.ImageAlt, command.ImageTitle, command.IsVisible, command.Bio);
            _sponsorRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditSponsor GetDetail(long Id)
        {
            return _sponsorRepository.GetDetail(Id);
        }

        public List<SponsorViewModel> Search(SponsorSearchModel searchModel)
        {
            return _sponsorRepository.Search(searchModel);
        }
    }
}
