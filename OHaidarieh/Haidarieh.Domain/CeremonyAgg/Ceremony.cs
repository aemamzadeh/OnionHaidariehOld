using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyGuestAgg;
using System;
using System.Collections.Generic;

namespace Haidarieh.Domain.CeremonyAgg
{
    public class Ceremony:EntityBase
    {
        public string Title { get; private set; }
        public DateTime CeremonyDate { get; private set; }
        public bool Status { get; private set; }
        public List<CeremonyGuest> CeremonyGuests { get; private set; }
        public List<CeremonyOperation> CeremonyOperations { get; private set; }

        public Ceremony(string title, DateTime ceremonyDate)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
            Status = true;
            CeremonyGuests = new List<CeremonyGuest>();
            CeremonyOperations = new List<CeremonyOperation>();
        }

        public void Edit(string title, DateTime ceremonyDate)
        {
            Title = title;
            CeremonyDate = ceremonyDate;
        }
        public void CreateOperationLog(int operation, long operatorId, string description, long ceremonyId)
        {
            var operationRecord = new CeremonyOperation(operation, operatorId, description, ceremonyId);
            CeremonyOperations.Add(operationRecord);
        }

    }
}
