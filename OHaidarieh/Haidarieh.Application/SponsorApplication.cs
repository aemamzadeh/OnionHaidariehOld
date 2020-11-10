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
        private readonly IFileUploader _fileUploader;

        public SponsorApplication(ISponsorRepository sponsorRepository, IFileUploader fileUploader)
        {
            _sponsorRepository = sponsorRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateSponsor command)
        {
            var operation = new OperationResult();
            if (_sponsorRepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            var ImagePath = $"{ImageFolderName}/{command.Name}";
            var imageFileName = _fileUploader.Upload(command.Image, ImagePath);

            var sponsor = new Sponsor(command.Name, command.Tel, imageFileName, command.ImageAlt, 
                command.ImageTitle, command.IsVisible, command.Bio);
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
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_sponsorRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
            var ImagePath = $"{ImageFolderName}/{command.Name}";
            var imageFileName = _fileUploader.Upload(command.Image, ImagePath);

            editItem.Edit(command.Name, command.Tel, imageFileName, command.ImageAlt, command.ImageTitle, command.IsVisible, command.Bio);
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
