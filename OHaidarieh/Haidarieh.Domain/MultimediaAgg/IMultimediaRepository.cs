using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haidarieh.Domain.MultimediaAgg
{
    public interface IMultimediaRepository : IRepository<long, Multimedia>
    {
        EditMultimedia GetDetail(long Id);
        List<Multimedia> GetList(long Id);
        Multimedia GetFirst(long Id);
        List<MultimediaViewModel> Search(MultimediaSearchModel searchModel);
        //IEnumerable<IGrouping<long, MultimediaViewModel>> Search(MultimediaSearchModel searchModel);
        //Dictionary<long, List<MultimediaViewModel>> Search(MultimediaSearchModel searchModel);
        List<MultimediaViewModel> GetMultimediasWithCeremony(long id);

    }
}
