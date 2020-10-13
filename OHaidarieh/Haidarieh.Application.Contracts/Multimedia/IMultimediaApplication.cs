using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Multimedia
{
    public interface IMultimediaApplication
    {
        OperationResult Create(CreateMultimedia command);
        OperationResult Edit(EditMultimedia command);
        List<MultimediaViewModel> Search(MultimediaSearchModel searchModel);
        EditMultimedia GetDetail(long Id);
    }
}
