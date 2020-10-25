using _01_HaidariehQuery.Contracts.Ceremonies;
using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Multimedias;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.MultimediaAgg;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    class CeremonyQuery : ICeremonyQuery
    {
        private readonly HContext _hContext;

        public CeremonyQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyQueryModel> GetCeremonies()
        {
            return _hContext.Ceremonies.Where(x => x.Status == true).Select(x => new CeremonyQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate,
                Status = x.Status
            }).ToList();
        }

    }   
}
