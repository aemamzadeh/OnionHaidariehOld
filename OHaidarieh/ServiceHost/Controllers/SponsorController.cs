using _01_HaidariehQuery.Contracts.Sponsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly ISponsorQuery _sponsorQuery;

        public SponsorController(ISponsorQuery sponsorQuery)
        {
            _sponsorQuery = sponsorQuery;
        }

        [HttpGet]
        public List<SponsorQueryModel> GetSponsors()
        {
            return _sponsorQuery.GetAll();
        }

    }
}
