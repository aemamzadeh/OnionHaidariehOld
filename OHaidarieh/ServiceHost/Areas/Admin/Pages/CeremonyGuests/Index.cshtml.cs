using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Guest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.CeremonyGuests
{
    public class IndexModel : PageModel
    {
        public CeremonyGuestSearchModel SearchModel;
        public List<CeremonyGuestViewModel> CeremonyGuests;
        public SelectList Ceremonies;
        public SelectList Guests;
        private readonly ICeremonyGuestApplication _ceremonyGuestApplication;
        private readonly ICeremonyApplication _ceremonyApplication;
        private readonly IGuestApplication _guestApplication;


        public IndexModel(ICeremonyGuestApplication ceremonyGuestApplication,ICeremonyApplication ceremonyApplication, IGuestApplication guestApplication)
        {
            _ceremonyGuestApplication = ceremonyGuestApplication;
            _ceremonyApplication = ceremonyApplication;
            _guestApplication = guestApplication;
        }

        public void OnGet(CeremonyGuestSearchModel searchModel)
        {
            Ceremonies = new SelectList(_ceremonyApplication.GetCeremonies(),"Id","Title");
            CeremonyGuests = _ceremonyGuestApplication.Search(searchModel);
            Guests = new SelectList(_guestApplication.GetGuests(), "Id", "FullName");
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
