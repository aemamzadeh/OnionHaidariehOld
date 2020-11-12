using _01_HaidariehQuery.Contracts.Ceremonies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {

        private readonly ICeremonyQuery _ceremonyQuery;

        public List<CeremonyQueryModel> ceremony { get; set; }


        public SearchModel(ICeremonyQuery ceremonyQuery)
        {
            _ceremonyQuery = ceremonyQuery;
        }
        public void OnGet(string value)
        {
            ceremony=_ceremonyQuery.Search(value);
        }

    }

}

