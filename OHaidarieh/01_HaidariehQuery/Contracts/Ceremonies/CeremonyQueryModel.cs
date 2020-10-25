using _01_HaidariehQuery.Contracts.CeremonyGuests;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Ceremonies
{
    public class CeremonyQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CeremonyDate { get; set; }
        public bool Status { get; set; }
    }
}
