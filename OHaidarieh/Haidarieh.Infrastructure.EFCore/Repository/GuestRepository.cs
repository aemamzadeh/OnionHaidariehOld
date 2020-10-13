using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Domain.GuestAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class GuestRepository : RepositoryBase<long, Guest>, IGuestRepository
    {
        private readonly HContext _hContext;
        public GuestRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditGuest GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<GuestViewModel> Search(GuestSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
