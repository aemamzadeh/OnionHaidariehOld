using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Pages.MultimediaDetail
{
    public class DetailModel : PageModel
    {

        private readonly ICeremonyGuestQuery _ceremonyGuestQuery;

        public CeremonyGuestQueryModel ceremonyGuest { get; set; }


        public DetailModel(ICeremonyGuestQuery ceremonyGuestQuery)
        {
            _ceremonyGuestQuery = ceremonyGuestQuery;
        }
        public void OnGet(string Id)
        {
            ceremonyGuest=_ceremonyGuestQuery.GetCeremonyGuestWithMultimedias(Id);
        }
    }

}

