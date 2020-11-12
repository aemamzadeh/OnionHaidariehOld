using _01_HaidariehQuery.Contracts.Ceremonies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class PastEventsViewComponent:ViewComponent
    {
        private readonly ICeremonyQuery _ceremonyQuery;

        public PastEventsViewComponent(ICeremonyQuery ceremonyQuery)
        {
            _ceremonyQuery = ceremonyQuery;
        }
        public IViewComponentResult Invoke()
        {
            var pastevents = _ceremonyQuery.GetPast();
            return View(pastevents);
        }
    }
}
