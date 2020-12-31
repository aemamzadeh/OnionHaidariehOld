using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Sponsor;
using Haidarieh.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Sponsors
{
    public class IndexModel : PageModel
    {
        public List<SponsorViewModel> Sponsors;
        public SponsorSearchModel SearchModel;
        private readonly ISponsorApplication _sponsorApplication;

        public IndexModel(ISponsorApplication sponsorApplication)
        {
            _sponsorApplication = sponsorApplication;
        }

        [NeedPermission(HPermissions.ListSponsor)]
        public void OnGet(SponsorSearchModel searchModel)
        {
            Sponsors = _sponsorApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateSponsor());
        }

        [NeedPermission(HPermissions.CreateSponsor)]
        public JsonResult OnPostCreate(CreateSponsor command)
        {
            var result = _sponsorApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var sponsor = _sponsorApplication.GetDetail(id);
            return Partial("./Edit", sponsor);
        }

        [NeedPermission(HPermissions.EditSponsor)]
        public JsonResult OnPostEdit(EditSponsor command)
        {
            var result = _sponsorApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
