using _0_Framework.Application;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Domain.MultimediaAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application
{
    public class MultimediaApplication : IMultimediaApplication
    {
        private readonly IMultimediaRepository _multimediaRepository;

        public MultimediaApplication(IMultimediaRepository multimediaRepository)
        {
            _multimediaRepository = multimediaRepository;
        }
        public OperationResult Create(CreateMultimedia command)
        {
            var operation= new OperationResult();
            if(_multimediaRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");
            var multimedia = new Multimedia(command.Title, command.FileAddress, command.FileTitle, command.FileAlt);
            _multimediaRepository.Create(multimedia);
            _multimediaRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditMultimedia command)
        {
            var operation = new OperationResult();
            operation.IsSuccedded = false;
            var editItem = _multimediaRepository.Get(command.Id);
            if (editItem == null)
                return operation.Failed("رکورد وجود ندارد.");
            if(_multimediaRepository.Exist(x=>x.Title==x.Title && x.Id!=command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجدد تلاش نمایید.");
            editItem.Edit(command.Title, command.FileAddress, command.FileTitle, command.FileAlt);
            _multimediaRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditMultimedia GetDetail(long Id)
        {
            return _multimediaRepository.GetDetail(Id);
        }

        public List<MultimediaViewModel> Search(MultimediaSearchModel searchModel)
        {
            return _multimediaRepository.Search(searchModel);
        }
    }
}
