using Microsoft.AspNetCore.Mvc;
using _01_HaidariehQuery.Contracts.Ceremonies;

namespace ServiceHost.ViewComponents
{
    public class BannersViewComponent: ViewComponent
    {
        private readonly ICeremonyQuery _ceremonyQuery;

        public BannersViewComponent(ICeremonyQuery ceremonyQuery)
        {
            _ceremonyQuery = ceremonyQuery;
        }

        public IViewComponentResult Invoke()
        {
            var banner = _ceremonyQuery.GetComing();
            return View(banner);
        }

    }
}
