using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.CeremonyAgg
{
    interface ICeremonyRepository
    {
        void Create(Ceremony entity);
        Ceremony Get(long Id);
        List<Ceremony> GetAll();


    }
}
