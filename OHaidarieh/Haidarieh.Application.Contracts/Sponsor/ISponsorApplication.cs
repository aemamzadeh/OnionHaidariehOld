using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Sponsor
{
    public interface ISponsorApplication
    {
        OperationResult Create(CreateSponsor command);
        OperationResult Edit(EditSponsor command);
        List<SponsorViewModel> Search(SponsorSearchModel searchModel);
        EditSponsor GetDetail(long Id);
    }
}
