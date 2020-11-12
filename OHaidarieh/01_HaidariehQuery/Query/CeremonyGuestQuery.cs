using _01_HaidariehQuery.Contracts.CeremonyGuests;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace _01_HaidariehQuery.Query
{
    public class CeremonyGuestQuery : ICeremonyGuestQuery
    {
        private readonly HContext _hContext;

        public CeremonyGuestQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyGuestQueryModel> GetCeremonyGuests()
        {
            return _hContext.CeremonyGuests.Select(x => new CeremonyGuestQueryModel
            {
                Id = x.Id,
                CeremonyId = x.CeremonyId,
                GuestId = x.GuestId,
                Guest=x.Guest.FullName,
                Ceremony=x.Ceremony.Title
            }).AsNoTracking().ToList();
        }
    }
}
  