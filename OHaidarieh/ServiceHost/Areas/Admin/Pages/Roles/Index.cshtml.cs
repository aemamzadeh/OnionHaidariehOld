using System.Collections.Generic;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Roles
{
    public class IndexModel : PageModel
    {
        public List<RoleViewModel> Roles;
        public SelectList RoleList;
        private readonly IRoleApplication _roleApplication;


        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.GetRoles();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("Create", new CreateRole());
        }
        public JsonResult OnPostCreate(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var role = _roleApplication.GetDetail(id);
            return Partial("Edit", role);
        }
        public JsonResult OnPostEdit(EditRole command)
        {
            var result = _roleApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
