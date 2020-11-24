using System.Collections.Generic;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        private readonly IFileUploader _fileUploader;


        public IndexModel(IAccountApplication accountApplication, IFileUploader fileUploader, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
            _fileUploader = fileUploader;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Accounts = _accountApplication.Search(searchModel);
            Roles = new SelectList(_roleApplication.GetRoles(),"Id","Title");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateAccount
            {
                Roles = _roleApplication.GetRoles()
            };
            return Partial("Create", command);
        }
        public JsonResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetail(id);
            account.Roles = _roleApplication.GetRoles();

            return Partial("Edit", account);
        }
        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetChangePassword(long id)
        {
            var account = _accountApplication.GetDetailPassword(id);

            return Partial("ChangePassword", account);
        }
        public JsonResult OnPostChangePassword(ChangePassword command)
         {
            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);
        }
    }
}
