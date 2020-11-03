using System;
using System.Collections.Generic;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CreateOperationLog
    {
        public int Operation { get;  set; }
        public long OperatorId { get;  set; }
        public string Description { get;  set; }
        public long CeremonyId { get;  set; }

    }
}
