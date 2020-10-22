using _01_HaidariehQuery.Contracts.CeremonyGuests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class PastEventsViewComponent:ViewComponent
    {
        private readonly ICeremonyGuestQuery _ceremonyGuestQuery;

        public PastEventsViewComponent(ICeremonyGuestQuery ceremonyGuestQuery)
        {
            _ceremonyGuestQuery = ceremonyGuestQuery;
        }
        public IViewComponentResult Invoke()
        {
            var pastevents = _ceremonyGuestQuery.GetPast();
            return View(pastevents);
        }
    }
}
