using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Multimedia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.MultimediaAgg
{
    public interface IMultimediaRepository : IRepository<long, Multimedia>
    {
        EditMultimedia GetDetail(long Id);
        List<MultimediaViewModel> Search(MultimediaSearchModel searchModel);
    }
}
