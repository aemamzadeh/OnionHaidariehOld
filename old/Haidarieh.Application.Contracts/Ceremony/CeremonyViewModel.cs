using System;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CeremonyViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CeremonyDate { get; set; }
    }
}
