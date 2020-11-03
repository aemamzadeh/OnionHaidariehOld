using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CeremonyOperationViewModel
    {
        public long Id { get; set; }
        public int Operation { get;  set; }
        public long OperatorId { get;  set; }
        public string OperationDate { get;  set; }
        public string Description { get;  set; }
        public long CeremonyId { get;  set; }
        public string Ceremony { get;  set; }
    }
}
