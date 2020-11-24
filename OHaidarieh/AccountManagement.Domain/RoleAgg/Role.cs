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
        public Role(string title)
        {
            Title = title;
            Accounts = new List<Account>();
        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
