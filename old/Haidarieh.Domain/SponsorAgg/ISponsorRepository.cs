using Haidarieh.Domain.CeremonyAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Domain.SponsorAgg
{
    public interface ISponsorRepository
    {
        void Create(Sponsor entity);
        Sponsor Get(long Id);
        List<Sponsor> GetAll();
    }
}
