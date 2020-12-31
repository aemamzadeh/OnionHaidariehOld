using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Member;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Members
{
    public class IndexModel : PageModel
    {
        public MemberSearchModel SearchModel;
        public List<MemberViewModel> Members;
        private readonly IMemberApplication _memberApplication;

        public IndexModel(IMemberApplication memberApplication)
        {
            _memberApplication = memberApplication;
        }

        [NeedPermission(HPermissions.ListMember)]
        public void OnGet(MemberSearchModel searchModel)
        {
            Members = _memberApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateMember());
        }

        [NeedPermission(HPermissions.CreateMember)]
        public JsonResult OnPostCreate(CreateMember command)
        {
            var result = _memberApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var member = _memberApplication.GetDetail(id);
            return Partial("./Edit", member);
        }

        [NeedPermission(HPermissions.EditMember)]
        public JsonResult OnPostEdit(EditMember command)
        {
            var result = _memberApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
