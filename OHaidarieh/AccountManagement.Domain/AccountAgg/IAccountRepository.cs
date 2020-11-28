using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository:IRepository<long,Account>
    {
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        EditAccount GetDetail(long Id);
        Account GetAccount(string Username);
        ChangePassword GetDetailPassword(long Id);

    }
}
