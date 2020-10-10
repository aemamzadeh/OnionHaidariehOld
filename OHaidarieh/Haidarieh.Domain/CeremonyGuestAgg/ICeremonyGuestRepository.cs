using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.CeremonyGuestAgg
{
    public interface ICeremonyGuestRepository
    {
        void Create(CeremonyGuest entity);
        CeremonyGuest Get(long Id);
        List<CeremonyGuest> GetAll();
    }
}
