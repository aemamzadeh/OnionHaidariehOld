using Microsoft.AspNetCore.Mvc;
using _01_HaidariehQuery.Contracts.CeremonyGuests;

namespace ServiceHost.ViewComponents
{
    public class BannersViewComponent: ViewComponent
    {
        private readonly ICeremonyGuestQuery _ceremonyGuestQuery;

        public BannersViewComponent(ICeremonyGuestQuery ceremonyGuestQuery)
        {
            _ceremonyGuestQuery = ceremonyGuestQuery;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _ceremonyGuestQuery.GetComing();
            return View(banner);
        }

    }
}
