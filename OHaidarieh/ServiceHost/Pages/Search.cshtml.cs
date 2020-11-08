using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {

        private readonly ICeremonyGuestQuery _ceremonyGuestQuery;

        public List<CeremonyGuestQueryModel> ceremonyGuest { get; set; }


        public SearchModel(ICeremonyGuestQuery ceremonyGuestQuery)
        {
            _ceremonyGuestQuery = ceremonyGuestQuery;
        }
        public void OnGet(string value)
        {
            ceremonyGuest=_ceremonyGuestQuery.Search(value);
        }

    }

}

