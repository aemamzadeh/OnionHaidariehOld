using _0_Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haidarieh.Configuration.Permissions
{
    public class HPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Ceremony", new List<PermissionDto>
                    {
                        new PermissionDto(10,"ListCeremony"),
                        new PermissionDto(11,"SearchCeremony"),
                        new PermissionDto(12,"CreateCeremony"),
                        new PermissionDto(13,"EditCeremony"),
                    }
                },
                {
                    "CeremonyGuest", new List<PermissionDto>
                    {
                        new PermissionDto(20,"ListCeremonyGuest"),
                        new PermissionDto(21,"SearchCeremonyGuest"),
                        new PermissionDto(22,"CreateCeremonyGuest"),
                        new PermissionDto(23,"EditCeremonyGuest"),
                    }
                },
                {
                    "Guest", new List<PermissionDto>
                    {
                        new PermissionDto(30,"ListGuest"),
                        new PermissionDto(31,"SearchGuest"),
                        new PermissionDto(32,"CreateGuest"),
                        new PermissionDto(33,"EditGuest"),
                    }
                },
            };
        }
    }
}

