using System.Collections.Generic;
using _0_Framework.Application.Email;
using _0_Framework.Infrastructure;
using Haidarieh.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Configuration.Permissions;
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
        private readonly IEmailService _emailService;


        public IndexModel(ICeremonyGuestApplication ceremonyGuestApplication, ICeremonyApplication ceremonyApplication, IGuestApplication guestApplication, IEmailService emailService)
        {
            _ceremonyGuestApplication = ceremonyGuestApplication;
            _ceremonyApplication = ceremonyApplication;
            _guestApplication = guestApplication;
            _emailService = emailService;
        }

        [NeedPermission(HPermissions.ListCeremonyGuest)]
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

        [NeedPermission(HPermissions.CreateCeremonyGuest)]
        public JsonResult OnPostCreate(CreateCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Create(command);
            var ceremony = _ceremonyApplication.GetDetail(command.CeremonyId);
            var guests = _ceremonyGuestApplication.GetCeremonyGuests(command.CeremonyId);
            var guestInfo = _guestApplication.GetGuestsInfo(guests);
            foreach (var item in guestInfo)
            {
                _emailService.SendEmail(ceremony.Title, " جناب آقای دعوتنامه شرکت در در مراسم", item.Email);
            }

            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var ceremonyGuest = _ceremonyGuestApplication.GetDetail(id);
            ceremonyGuest.Guests = _guestApplication.GetGuests(id);
            ceremonyGuest.Ceremonies = _ceremonyApplication.GetCeremonies();
            return Partial("./Edit", ceremonyGuest);
        }

        [NeedPermission(HPermissions.EditCeremonyGuest)]
        public JsonResult OnPostEdit(EditCeremonyGuest command)
        {
            var result = _ceremonyGuestApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
