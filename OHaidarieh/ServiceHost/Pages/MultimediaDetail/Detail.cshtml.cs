using _01_HaidariehQuery.Contracts.Ceremonies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.MultimediaDetail
{
    public class DetailModel : PageModel
    {

        private readonly ICeremonyQuery _ceremonyQuery;

        public CeremonyQueryModel ceremony { get; set; }


        public DetailModel(ICeremonyQuery ceremonyQuery)
        {
            _ceremonyQuery = ceremonyQuery;
        }
        public void OnGet(string Id)
        {
            ceremony=_ceremonyQuery.GetCeremonyWithMultimedias(Id);
        }
    }

}

