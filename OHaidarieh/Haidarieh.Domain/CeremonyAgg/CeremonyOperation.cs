using System;

namespace Haidarieh.Domain.CeremonyAgg
{
    public class CeremonyOperation
    {
        public long Id { get; private set; }
        public int Operation { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public string Description { get; private set; }
        public long CeremonyId { get; private set; }
        public Ceremony Ceremony { get; private set; }


        public CeremonyOperation(int operation, long operatorId, string description,long ceremonyId)
        {
            Operation = operation;
            OperatorId = operatorId;
            Description = description;
            OperationDate = DateTime.Now;
            CeremonyId = ceremonyId;
        }

    }
}
