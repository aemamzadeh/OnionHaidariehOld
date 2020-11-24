using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        EditAccount GetDetail(long Id);
        ChangePassword GetDetailPassword(long Id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);


    }
}
