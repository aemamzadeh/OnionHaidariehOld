using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Register(RegisterAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult Login(Login command);
        void Logout();
        OperationResult ChangePassword(ChangePassword command);
        EditAccount GetDetail(long Id);
        ChangePassword GetDetailPassword(long Id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);

        
    }
}
