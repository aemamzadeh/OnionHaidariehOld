using System.Collections.Generic;
using System.Linq;
using _0_Framework.Infrastructure;
using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Query;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Configuration.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Multimedias
{ 
    public class IndexModel : PageModel
    {
        public MultimediaSearchModel SearchModel;
        //public IEnumerable<IGrouping<long, MultimediaViewModel>> Multimedias;
        public List<MultimediaViewModel> Multimedias { get; set; }
        public SelectList Ceremonies;
        private readonly IMultimediaApplication _multimediaApplication;
        private readonly ICeremonyApplication _ceremonyApplication;

        public IndexModel(IMultimediaApplication multimediaApplication, ICeremonyApplication ceremonyApplication)
        {
            _multimediaApplication = multimediaApplication;
            _ceremonyApplication = ceremonyApplication;
        }

        [NeedPermission(HPermissions.ListMultimedia)]
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

        [NeedPermission(HPermissions.CreateMultimedia)]
        public JsonResult OnPostCreate(CreateMultimedia createcommand,List<IFormFile> FileAddress)
        {
            var result = _multimediaApplication.Create(createcommand, FileAddress);
            return new JsonResult(result);
        }
        public IActionResult OnGetEditMetadata(long id)
        {
            var multimedia = _multimediaApplication.GetDetail(id);
            multimedia.Ceremonies = _ceremonyApplication.GetCeremonies();
            return Partial("./EditMetadata", multimedia);
        }

        public IActionResult OnGetEditAlbum(long id)
        {
            var multimedia = _multimediaApplication.GetDetail(id);
            multimedia.Ceremonies = _ceremonyApplication.GetCeremonies();
            return Partial("./EditAlbum", multimedia);
        }

        [NeedPermission(HPermissions.EditMultimedia)]
        public JsonResult OnPostEditMetadata(EditMultimedia command)
        {
            var result = _multimediaApplication.EditMetadata(command);
            return new JsonResult(result);
        }

        [NeedPermission(HPermissions.EditMultimedia)]
        public JsonResult OnPostEditAlbum(EditMultimedia command, List<IFormFile> FileAddress)
        {
            var result = _multimediaApplication.EditAlbum(command, FileAddress);
            return new JsonResult(result);
        }
        public IActionResult OnGetShow(long ceremonyid)
        {
            var multimedias = _multimediaApplication.GetMultimediasWithCeremony(ceremonyid);
            return Partial("Show", multimedias);
        }
    }
}
