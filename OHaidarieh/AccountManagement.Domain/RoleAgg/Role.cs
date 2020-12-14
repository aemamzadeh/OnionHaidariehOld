using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:EntityBase
    {
        public string Title { get; private set; }
        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public Role()
        {
        }

        public Role(string title, List<Permission> permissions)
        {
            Title = title;
            Accounts = new List<Account>();
            Permissions = permissions;
        }
        public void Edit(string title, List<Permission> permissions)
        {
            Title = title;
            Permissions = permissions;

        }
    }
}
