using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Sponsers
{
    public interface ISponsorQuery
    {
        List<SponsorQueryModel> GetAll();
    }
}
