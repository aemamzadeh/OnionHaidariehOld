using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Domain.CeremonyAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet(CeremonySearchModel searchModel)
        {
            Ceremonies=_ceremonyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCeremony());
        }

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
        public JsonResult OnPostEdit(EditCeremony command)
        {
            var result = _ceremonyApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog()
        {
            var logs = _ceremonyApplication.GetCeremonyWithOperationsLog();
            return Partial("OperationLog", logs);
        }
    }
}
