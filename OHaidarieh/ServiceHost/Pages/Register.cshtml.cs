using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IAccountApplication _accountApplication;

        public RegisterModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            if(result.IsSuccedded)
                return RedirectToPage("./Account");
            Message = result.Message;
            return RedirectToPage("./Register");

        }
    }
}
