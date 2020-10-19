using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Multimedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Multimedias
{ 
    public class IndexModel : PageModel
    {
        public MultimediaSearchModel SearchModel;
        public List<MultimediaViewModel> Multimedias;
        public SelectList CeremonyGuests;
        private readonly IMultimediaApplication _multimediaApplication;
        private readonly ICeremonyGuestApplication _ceremonyGuestApplication;

        public IndexModel(IMultimediaApplication multimediaApplication, ICeremonyGuestApplication ceremonyGuestApplication)
        {
            _multimediaApplication = multimediaApplication;
            _ceremonyGuestApplication = ceremonyGuestApplication;
        }
        public void OnGet(MultimediaSearchModel searchModel)
        {
            Multimedias=_multimediaApplication.Search(searchModel);
            CeremonyGuests = new SelectList(_ceremonyGuestApplication.GetCeremonyGuests(),"Id","Ceremony");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateMultimedia
            {
                CeremonyGuests = _ceremonyGuestApplication.GetCeremonyGuests()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateMultimedia command)
        {
            var result = _multimediaApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var multimedia = _multimediaApplication.GetDetail(id);
            multimedia.CeremonyGuests = _ceremonyGuestApplication.GetCeremonyGuests();
            return Partial("./Edit", multimedia);
        }
        public JsonResult OnPostEdit(EditMultimedia command)
        {
            var result = _multimediaApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
