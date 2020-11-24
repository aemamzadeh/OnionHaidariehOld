using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        List<RoleViewModel> GetRoles();
        EditRole GetDetail(long id);
    }
}
