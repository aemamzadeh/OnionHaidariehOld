using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.MemberAgg
{
    public interface IMemberRepository
    {
        void Create(Member entity);
        Member Get(long Id);
        List<Member> GetAll();
    }
}
