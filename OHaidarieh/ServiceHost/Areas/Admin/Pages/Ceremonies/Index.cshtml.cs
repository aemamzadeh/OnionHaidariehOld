using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Query;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Configuration.Permissions;
using Haidarieh.Domain.CeremonyAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Ceremonies
{
    public class IndexModel : PageModel
    {
        private readonly ICeremonyApplication _ceremonyApplication;
        public List<CeremonyViewModel> Ceremonies;
        public CeremonySearchModel SearchModel;

        public IndexModel(ICeremonyApplication ceremonyApplication)
        {
            _ceremonyApplication = ceremonyApplication;
        }

        [NeedPermission(HPermissions.ListCeremony)]
        public void OnGet(CeremonySearchModel searchModel)
        {
            Ceremonies=_ceremonyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCeremony());
        }

        [NeedPermission(HPermissions.CreateCeremony)]
        public JsonResult OnPostCreate(CreateCeremony command)
        {
            var result = _ceremonyApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var ceremony = _ceremonyApplication.GetDetail(id);
            return Partial("Edit", ceremony);
        }
    
        [NeedPermission(HPermissions.EditCeremony)]
        public JsonResult OnPostEdit(EditCeremony command)
        {
            var result = _ceremonyApplication.Edit(command);
            return new JsonResult(result);
        }

        [NeedPermission(HPermissions.LogCeremony)]
        public IActionResult OnGetLog()
        {
            var logs = _ceremonyApplication.GetCeremonyWithOperationsLog();
            return Partial("OperationLog", logs);
        }

    }
}
