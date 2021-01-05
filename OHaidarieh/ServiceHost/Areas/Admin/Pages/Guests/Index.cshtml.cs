using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Guests
{
    public class IndexModel : PageModel
    {
        private readonly IGuestApplication _guestApplication;
        public List<GuestViewModel> Guests;
        public GuestSearchModel SearchModel;

        public IndexModel(IGuestApplication guestApplication)
        {
            _guestApplication = guestApplication;
        }

        [NeedPermission(HPermissions.ListGuest)]
        public void OnGet(GuestSearchModel searchModel)
        {
            Guests = _guestApplication.Search(searchModel);
            
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateGuest());
        }
        
        [NeedPermission(HPermissions.CreateGuest)]
        public JsonResult OnPostCreate(CreateGuest command)
        {
            var result = _guestApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var guest = _guestApplication.GetDetail(id);
            return Partial("./Edit", guest);
        }

        [NeedPermission(HPermissions.EditGuest)]
        public JsonResult OnPostEdit(EditGuest command)
        {
            var result = _guestApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
