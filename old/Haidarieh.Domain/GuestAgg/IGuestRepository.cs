using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.GuestAgg
{
    public interface IGuestRepository
    {
        void Create(Guest entity);
        Guest Get(long Id);
        List<Guest> GetAll();
    }
}
