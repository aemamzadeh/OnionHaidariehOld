using _01_HaidariehQuery.Contracts.Guests;
using _01_HaidariehQuery.Contracts.Sponsers;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.GuestAgg;
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
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController (IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        [HttpGet]
        public JsonResult GetGuestName()
        {
            var guests = _guestRepository.GetGuests();

            return new JsonResult(guests);
        }

    }
}
