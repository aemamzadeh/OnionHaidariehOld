using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_HaidariehQuery.Contracts.Multimedias;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Pages.MultimediaDetail
{
    public class DetailModel : PageModel
    {

        private readonly IMultimediaQuery _multimediaQuery;
        public List<MultimediaQueryModel> multimedias { get; set; }
        public MultimediaQueryModel multimedia { get; set; }



        public DetailModel(IMultimediaQuery multimediaQuery)
        {
            _multimediaQuery = multimediaQuery;
        }
        public void OnGet(long Id)
        {
            multimedias = _multimediaQuery.GetDetail(Id);
            multimedia = _multimediaQuery.GetDetail(Id).First();
        }
    }

}

