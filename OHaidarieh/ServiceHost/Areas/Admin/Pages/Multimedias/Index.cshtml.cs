using System.Collections.Generic;
using Haidarieh.Application.Contracts.Ceremony;
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
        public SelectList Ceremonies;
        private readonly IMultimediaApplication _multimediaApplication;
        private readonly ICeremonyApplication _ceremonyApplication;

        public IndexModel(IMultimediaApplication multimediaApplication, ICeremonyApplication ceremonyApplication)
        {
            _multimediaApplication = multimediaApplication;
            _ceremonyApplication = ceremonyApplication;
        }
        public void OnGet(MultimediaSearchModel searchModel)
        {
            Multimedias=_multimediaApplication.Search(searchModel);
            Ceremonies = new SelectList(_ceremonyApplication.GetCeremonies(),"Id","Title");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateMultimedia
            {
                Ceremonies = _ceremonyApplication.GetCeremonies()
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
            multimedia.Ceremonies = _ceremonyApplication.GetCeremonies();
            return Partial("./Edit", multimedia);
        }
        public JsonResult OnPostEdit(EditMultimedia command)
        {
            var result = _multimediaApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
