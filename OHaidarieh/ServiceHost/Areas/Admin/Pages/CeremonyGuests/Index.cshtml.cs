using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web.Helpers;
//using System.Web.Mvc;
using _0_Framework.Application.Email;
using _0_Framework.Infrastructure;
using Haidarieh.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Configuration.Permissions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Admin.Pages.CeremonyGuests
{
    public class IndexModel : PageModel
    {
        public CeremonyGuestSearchModel SearchModel;
        public List<CeremonyGuestViewModel> cg;
        public List<TelViewModel> guests;
        public List<CeremonyViewModel> CeremonyGuests;
        public EditCeremonyGuest ceremonyGuest;
        public List<CeremonyGuestViewModel> ceremonyGuestGrid;
        public SelectList CeremoniesList;
        public SelectList GuestsList;
        private readonly ICeremonyGuestApplication _ceremonyGuestApplication;
        private readonly ICeremonyApplication _ceremonyApplication;
        private readonly IGuestApplication _guestApplication;
        private readonly IEmailService _emailService;

        public static IList<CeremonyGuestViewModel> guestsg;



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

        //public IActionResult OnGetRead(long Id)
        //{
        //    ceremonyGuest = _ceremonyGuestApplication.GetDetail(Id);
        //    [DataSourceRequest] DataSourceRequest request 
        //    return new JsonResult(ceremonyGuest.ToDataSourceResult(request));


        //}
        public IActionResult OnGetCreate()
        {
            var command = new CreateCeremonyGuest
            {
                Ceremonies = _ceremonyApplication.GetCeremonies()
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

        public IActionResult OnGetEdit(long ceremonyId)
        {
            
            ceremonyGuest = _ceremonyGuestApplication.GetDetail(ceremonyId);
            ceremonyGuest.CeremonyId = ceremonyId;

            //var guestlist = ceremonyGuest.Guests;

            //cg = _ceremonyGuestApplication.GetCeremonyGuests(ceremonyId);
            //ViewData["cguests"] = cg;

            //ceremonyGuest = _ceremonyGuestApplication.GetDetail(5);

            //if (guestsg == null)
            //{
            //    guestsg = new List<EditCeremonyGuest>();

            //    //foreach (var item in ceremonyGuest.Guests)
            //    //{
            //        Enumerable.Range(0, 1).ToList().ForEach(i => guestsg.Add(new EditCeremonyGuest
            //        {
            //            CeremonyId=ceremonyGuest.CeremonyId,
            //            CeremonyDate = ceremonyGuest.CeremonyDate,
            //            Guests = ceremonyGuest.Guests

            //        }));

            //}
            //}

            //var agst = ceremonyGuest.AllGuests;
            //var allgst = ceremonyGuest.AllGuests;
            //JsonSerializer ser = new JsonSerializer();
            //var jsonallgst = JsonConvert.SerializeObject(allgst);
            //ViewData["guests"] = jsonallgst;

            //var data = _guestApplication.GetGuests();
            //var viewModel = new EditCeremonyGuest();
            //var serializer = new JsonSerializer();
            //var viewModeljson = JsonConvert.SerializeObject(data);




            //ceremonyGuest.Guests = _guestApplication.GetGuests();
            //ceremonyGuest.Ceremonies = _ceremonyApplication.GetCeremonies();
            //ViewData["guests"] = JsonConvert.SerializeObject(data);
            //return new JsonResult(Partial("./Edit", ceremonyGuest));
            return Partial("./Edit", ceremonyGuest);
            
        }

        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request, long ceremonyId)
        {

            ceremonyGuestGrid = _ceremonyGuestApplication.GetCeremonyGuests(ceremonyId);

            guestsg = new List<CeremonyGuestViewModel>();

            foreach (var item in ceremonyGuestGrid)
            {
                Enumerable.Range(0, 1).ToList().ForEach(i => guestsg.Add(new CeremonyGuestViewModel
                {
                    Id = item.Id,
                    GuestId = item.GuestId,
                    Guest = item.Guest,
                    GuestType = item.GuestType,
                    GuestPic = item.GuestPic,
                    Satisfication = item.Satisfication
                }));

            }
            //}

            DataSourceResult result = guestsg.ToDataSourceResult(request);
            return new JsonResult(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });


            //return new JsonResult(guestsg.ToDataSourceResult(request));
        }

        [NeedPermission(HPermissions.EditCeremonyGuest)]
        public JsonResult OnPostEditGuest(List<EditCeremonyGuest> command)
        {
            var result = _ceremonyGuestApplication.Edit(command);
            return new JsonResult(result);
        }
        //public JsonResult OnGetEditGuests()
        //{
        //    return new JsonResult(ceremonyGuest.Guests);
        //}
        public JsonResult OnGetGuestName()
        {
            var guests = _guestApplication.GetGuests();

            return new JsonResult(guests);
        }
        public JsonResult OnPostUpdate([DataSourceRequest] DataSourceRequest request, EditCeremonyGuest guest)
        {
            guestsg.Where(x => x.GuestId == guest.GuestId).Select(x => guest);

            return new JsonResult(new[] { guest }.ToDataSourceResult(request, ModelState));
        }
    }
}