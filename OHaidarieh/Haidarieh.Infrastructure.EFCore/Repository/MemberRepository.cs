using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Member;
using Haidarieh.Domain.MemberAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class MemberRepository : RepositoryBase<long, Member>, IMemberRepository
    {
        private readonly HContext _hContext;
        public MemberRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditMember GetDetail(long Id)
        {
            throw new NotImplementedException();
        }

        public List<MemberViewModel> Search(MemberSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
