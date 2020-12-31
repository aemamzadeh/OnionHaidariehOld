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
                        new PermissionDto(HPermissions.ListCeremony,"ListCeremony"),
                        new PermissionDto(HPermissions.SearchCeremony,"SearchCeremony"),
                        new PermissionDto(HPermissions.CreateCeremony,"CreateCeremony"),
                        new PermissionDto(HPermissions.EditCeremony,"EditCeremony"),
                        new PermissionDto(HPermissions.LogCeremony,"LogCeremony"),

                    }
                },
                {
                    "CeremonyGuest", new List<PermissionDto>
                    {
                        new PermissionDto(HPermissions.ListCeremonyGuest,"ListCeremonyGuest"),
                        new PermissionDto(HPermissions.SearchCeremonyGuest,"SearchCeremonyGuest"),
                        new PermissionDto(HPermissions.CreateCeremonyGuest,"CreateCeremonyGuest"),
                        new PermissionDto(HPermissions.EditCeremonyGuest,"EditCeremonyGuest"),
                    }
                },
                {
                    "Guest", new List<PermissionDto>
                    {
                        new PermissionDto(HPermissions.ListGuest,"ListGuest"),
                        new PermissionDto(HPermissions.SearchGuest,"SearchGuest"),
                        new PermissionDto(HPermissions.CreateGuest,"CreateGuest"),
                        new PermissionDto(HPermissions.EditGuest,"EditGuest"),
                    }
                },
                {
                    "Member", new List<PermissionDto>
                    {
                        new PermissionDto(HPermissions.ListMember,"ListMember"),
                        new PermissionDto(HPermissions.SearchMember,"SearchMember"),
                        new PermissionDto(HPermissions.CreateMember,"CreateMember"),
                        new PermissionDto(HPermissions.EditMember,"EditMember"),
                    }
                },
                {
                    "Multimedia", new List<PermissionDto>
                    {
                        new PermissionDto(HPermissions.ListMultimedia,"ListMultimedia"),
                        new PermissionDto(HPermissions.SearchMultimedia,"SearchMultimedia"),
                        new PermissionDto(HPermissions.CreateMultimedia,"CreateMultimedia"),
                        new PermissionDto(HPermissions.EditMultimedia,"EditMultimedia"),
                    }
                },
                {
                    "Sponsor", new List<PermissionDto>
                    {
                        new PermissionDto(HPermissions.ListSponsor,"ListSponsor"),
                        new PermissionDto(HPermissions.SearchSponsor,"SearchSponsor"),
                        new PermissionDto(HPermissions.CreateSponsor,"CreateSponsor"),
                        new PermissionDto(HPermissions.EditSponsor,"EditSponsor"),
                    }
                },
            };
        }
    }
}

