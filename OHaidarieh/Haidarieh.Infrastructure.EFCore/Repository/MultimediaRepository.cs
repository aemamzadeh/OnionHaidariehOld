using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Domain.MultimediaAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class MultimediaRepository : RepositoryBase<long, Multimedia>, IMultimediaRepository
    {
        private readonly HContext _hContext;
        public MultimediaRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditMultimedia GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<MultimediaViewModel> Search(MultimediaSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
