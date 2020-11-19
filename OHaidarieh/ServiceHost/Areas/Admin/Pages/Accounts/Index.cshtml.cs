using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList RoleList;
        private readonly IAccountApplication _accountApplication;
        private readonly IFileUploader _fileUploader;


        public IndexModel(IAccountApplication accountApplication, IFileUploader fileUploader)
        {
            _accountApplication = accountApplication;
            _fileUploader = fileUploader;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
            Accounts = _accountApplication.Search(searchModel);
            //RoleList = new SelectList(_accountApplication.GetAccounts(),"Id","Role");
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateAccount());
        }
        public JsonResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetail(id);
            return Partial("Edit", account);
        }
        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
