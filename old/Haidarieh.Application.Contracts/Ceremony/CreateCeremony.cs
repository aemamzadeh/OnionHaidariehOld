using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CreateCeremony
    {
        public string Title { get;  set; }
        public DateTime CeremonyDate { get;  set; }
        public bool Status { get;  set; }
    }
}
