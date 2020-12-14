using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public EditRole command;
        public List<SelectListItem> Permissions=new List<SelectListItem>();
        private readonly IEnumerable<IPermissionExposer> _exposers;
        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }
        public void OnGet(long id)
        {
            command = _roleApplication.GetDetail(id);
            var permissions = new List<PermissionDto>();
            foreach (var exposer in _exposers)
            {
                var exposedPermission = exposer.Expose();
                foreach (var (key,value) in exposedPermission)
                {
                    permissions.AddRange(value);
                    var group = new SelectListGroup()
                    {
                        Name = key
                    };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group=  group
                        };
                        if (command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;
                        Permissions.Add(item);
                    }
                }
            }
        }
        public IActionResult OnPost(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
