using _0_Framework.Application;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.MultimediaAgg;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haidarieh.Application
{
    public class MultimediaApplication : IMultimediaApplication
    {
        private readonly IMultimediaRepository _multimediaRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly IFileUploader _fileUploader;

        public MultimediaApplication(IMultimediaRepository multimediaRepository, ICeremonyRepository ceremonyRepository, IFileUploader fileUploader)
        {
            _multimediaRepository = multimediaRepository;
            _ceremonyRepository = ceremonyRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CreateMultimedia command, List<IFormFile> files)
        {
            var operation= new OperationResult();
            if(_multimediaRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var ceremony = _ceremonyRepository.GetDetail(command.CeremonyId);
            foreach (var item in files)
            {
                var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
                var ImagePath = $"{ImageFolderName}/{ceremony.Slug}";
                var imageFileName = _fileUploader.Upload(item, ImagePath);
                var multimedia = new Multimedia(ceremony.Title, imageFileName, command.FileTitle, command.FileAlt, command.CeremonyId);
                _multimediaRepository.Create(multimedia);
            }
               
            _multimediaRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult EditAlbum(EditMultimedia command, List<IFormFile> files)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _multimediaRepository.GetFirst(command.CeremonyId);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            //if(_multimediaRepository.Exist(x=>x.Title==x.Title && x.Id!=command.Id))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            foreach (var item in files)
            {
                var ceremony = _ceremonyRepository.GetDetail(command.CeremonyId);
                var ImageFolderName = Tools.ToFolderName(this.GetType().Name);
                var ImagePath = $"{ImageFolderName}/{ceremony.Slug}";
                var imageFileName = _fileUploader.Upload(item, ImagePath);
                //editItem.EditAlbum(imageFileName, command.CeremonyId);
                var multimedia = new Multimedia(ceremony.Title, imageFileName, command.FileTitle, command.FileAlt, command.CeremonyId);
                _multimediaRepository.Create(multimedia);

            }
            _multimediaRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditMultimedia GetDetail(long Id)
        {
            return _multimediaRepository.GetDetail(Id);
        }

        public OperationResult EditMetadata(EditMultimedia command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _multimediaRepository.GetList(command.CeremonyId);
            if (editItem == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            //if (_multimediaRepository.Exist(x => x.Title == x.Title && x.Id != command.Id))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            foreach (var item in editItem)
            {
                item.EditMetadata(command.Title, command.FileTitle, command.FileAlt, command.CeremonyId);
            }
            _multimediaRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<MultimediaViewModel> GetMultimediasWithCeremony(long id)
        {
            return _multimediaRepository.GetMultimediasWithCeremony(id);
        }

        public List<MultimediaViewModel> Search(MultimediaSearchModel searchModel)
        {
            return _multimediaRepository.Search(searchModel);
        }
    }
}
