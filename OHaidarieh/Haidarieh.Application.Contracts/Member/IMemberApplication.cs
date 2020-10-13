using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Member
{
    public interface IMemberApplication
    {
        OperationResult Create(CreateMember command);
        OperationResult Edit(EditMember command);
        List<MemberViewModel> Search(MemberSearchModel searchModel);
        EditMember GetDetail(long Id);
    }
}
