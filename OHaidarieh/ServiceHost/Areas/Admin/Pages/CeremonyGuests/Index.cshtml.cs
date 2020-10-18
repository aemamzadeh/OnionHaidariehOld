using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.CeremonyGuests
{
    public class IndexModel : PageModel
    {
        public CeremonyGuestSearchModel SearchModel;
        public List<CeremonyGuestViewModel> CeremonyGuests;
        private readonly ICeremonyGuestApplication _ceremonyGuestApplication;

        public IndexModel(ICeremonyGuestApplication ceremonyGuestApplication)
        {
            _ceremonyGuestApplication = ceremonyGuestApplication;
        }

        public void OnGet(CeremonyGuestSearchModel searchModel)
        {
            CeremonyGuests = _ceremonyGuestApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCeremonyGuest());
        }
        public JsonResult OnPostCreate(CreateCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var ceremonyGuest = _ceremonyGuestApplication.GetDetail(id);
            return Partial("./Edit", ceremonyGuest);
        }
        public JsonResult OnPostEdit(EditCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
