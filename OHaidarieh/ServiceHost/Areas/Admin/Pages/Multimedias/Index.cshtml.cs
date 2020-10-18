using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haidarieh.Application.Contracts.Multimedia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Multimedias
{ 
    public class IndexModel : PageModel
    {
        public MultimediaSearchModel SearchModel;
        public List<MultimediaViewModel> Multimedias;
        private readonly IMultimediaApplication _multimediaApplication;

        public IndexModel(IMultimediaApplication multimediaApplication)
        {
            _multimediaApplication = multimediaApplication;
        }
        public void OnGet(MultimediaSearchModel searchModel)
        {
            Multimedias=_multimediaApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateMultimedia());
        }
        public JsonResult OnPostCreate(CreateMultimedia command)
        {
            var result = _multimediaApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var multimedia = _multimediaApplication.GetDetail(id);
            return Partial("./Edit", multimedia);
        }
        public JsonResult OnPostEdit(EditMultimedia command)
        {
            var result = _multimediaApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
