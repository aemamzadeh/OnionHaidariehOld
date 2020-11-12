using _01_HaidariehQuery.Contracts.Ceremonies;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class UpCommingViewComponent:ViewComponent
    {
        private readonly ICeremonyQuery _ceremonyQuery;

        public UpCommingViewComponent(ICeremonyQuery ceremonyQuery)
        {
            _ceremonyQuery = ceremonyQuery;
        }

        public IViewComponentResult Invoke()
        {
            var comingevents = _ceremonyQuery.GetComing();
            return View(comingevents);
        }

    }
}
