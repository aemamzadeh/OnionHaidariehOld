using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Ceremonies
{
    public interface ICeremonyQuery
    {
        List<CeremonyQueryModel> GetCeremonies();
        List<CeremonyQueryModel> GetCeremoniesWithCeremonyGuests();
    }
}
