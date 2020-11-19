using System.Collections.Generic;
using Haidarieh.Application;
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
        public SelectList CeremoniesList;
        public SelectList GuestsList;
        private readonly ICeremonyGuestApplication _ceremonyGuestApplication;
        private readonly ICeremonyApplication _ceremonyApplication;
        private readonly IGuestApplication _guestApplication;


        public IndexModel(ICeremonyGuestApplication ceremonyGuestApplication, ICeremonyApplication ceremonyApplication, IGuestApplication guestApplication)
        {
            _ceremonyGuestApplication = ceremonyGuestApplication;
            _ceremonyApplication = ceremonyApplication;
            _guestApplication = guestApplication;
        }

        public void OnGet(CeremonyGuestSearchModel searchModel)
        {
            CeremonyGuests = _ceremonyGuestApplication.Search(searchModel);
            CeremoniesList = new SelectList(_ceremonyApplication.GetCeremonies(), "Id", "Title");
            GuestsList = new SelectList(_guestApplication.GetGuests(), "Id", "FullName");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateCeremonyGuest
            {
                Ceremonies = _ceremonyApplication.GetCeremonies(),
                Guests = _guestApplication.GetGuests()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var ceremonyGuest = _ceremonyGuestApplication.GetDetail(id);
            ceremonyGuest.Guests = _guestApplication.GetGuests();
            ceremonyGuest.Ceremonies = _ceremonyApplication.GetCeremonies();
            return Partial("./Edit", ceremonyGuest);
        }
        public JsonResult OnPostEdit(EditCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
