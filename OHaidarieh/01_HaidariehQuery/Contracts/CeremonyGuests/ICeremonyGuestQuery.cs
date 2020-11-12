using _01_HaidariehQuery.Contracts.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.CeremonyGuests
{
    public interface ICeremonyGuestQuery
    {
        List<CeremonyGuestQueryModel> GetCeremonyGuests();
    }
}
