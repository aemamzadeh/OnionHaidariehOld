using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long,Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }

        public Account GetAccount(string Username)
        {
            return _accountContext.Accounts.FirstOrDefault(x=>x.Username == Username);
        }
        
        public EditAccount GetDetail(long Id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount
            {
                Id=x.Id,
                Fname=x.Fname,
                Lname=x.Lname,
                Mobile=x.Mobile,
                RoleId=x.RoleId,
                Username=x.Username

            }).FirstOrDefault(x => x.Id == Id);
        }

        public ChangePassword GetDetailPassword(long Id)
        {
            return _accountContext.Accounts.Select(x => new ChangePassword
            {
                Id = x.Id,
                Fname = x.Fname,
                Lname = x.Lname,
                Password=x.Password,
                Username = x.Username

            }).FirstOrDefault(x => x.Id == Id);
        }
        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _accountContext.Accounts
                .Include(x=>x.Role)
                .Select(x => new AccountViewModel
            {
                Id=x.Id,
                Fname=x.Fname,
                Lname=x.Lname,
                Mobile=x.Mobile,
                Username=x.Username,
                ProfilePhoto=x.ProfilePhoto,
                Role = x.Role.Title,
                RoleId = x.RoleId
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Fname))
                query = query.Where(x => x.Fname.Contains(searchModel.Fname));
            if (!string.IsNullOrWhiteSpace(searchModel.Lname))
                query = query.Where(x => x.Lname.Contains(searchModel.Lname));
            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));
            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));
            if (searchModel.RoleId>0)
                query = query.Where(x => x.RoleId==searchModel.RoleId);
            return query.OrderByDescending(x=>x.Id).ToList();

        }
    }
}
