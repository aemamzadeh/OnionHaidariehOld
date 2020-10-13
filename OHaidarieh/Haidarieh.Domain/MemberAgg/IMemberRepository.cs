using _0_Framework.Domain;
using Haidarieh.Application.Contracts.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.MemberAgg
{
    public interface IMemberRepository : IRepository<long, Member>
    {
        EditMember GetDetail(long Id);
        List<MemberViewModel> Search(MemberSearchModel searchModel);
    }
}
