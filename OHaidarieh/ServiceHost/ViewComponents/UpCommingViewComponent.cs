using _01_HaidariehQuery.Contracts.CeremonyGuests;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class UpCommingViewComponent:ViewComponent
    {
        private readonly ICeremonyGuestQuery _ceremonyGuestQuery;

        public UpCommingViewComponent(ICeremonyGuestQuery ceremonyGuestQuery)
        {
            _ceremonyGuestQuery = ceremonyGuestQuery;
        }

        public IViewComponentResult Invoke()
        {
            var comingevents = _ceremonyGuestQuery.GetComing();
            return View(comingevents);
        }

    }
}
