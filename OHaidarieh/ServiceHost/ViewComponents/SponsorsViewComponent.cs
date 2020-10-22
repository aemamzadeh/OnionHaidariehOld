using _01_HaidariehQuery.Contracts.Sponsers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SponsorsViewComponent:ViewComponent
    {
        private readonly ISponsorQuery _sponsorQuery;

        public SponsorsViewComponent(ISponsorQuery sponsorQuery)
        {
            _sponsorQuery = sponsorQuery;
        }

        public IViewComponentResult Invoke()
        {
            var sopnsers = _sponsorQuery.GetAll();
            return View(sopnsers);
        }
    }
}
