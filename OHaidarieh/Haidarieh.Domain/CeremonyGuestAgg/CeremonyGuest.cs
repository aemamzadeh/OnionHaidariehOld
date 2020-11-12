using _0_Framework.Domain;
using Haidarieh.Domain.CeremonyAgg;
using Haidarieh.Domain.GuestAgg;


namespace Haidarieh.Domain.CeremonyGuestAgg 
{

    public class CeremonyGuest : EntityBase
    {
        public long GuestId { get; private set; }
        public long CeremonyId { get; private set; }
        public float Satisfication { get; private set; }
        public Guest Guest { get;  private set; }
        public Ceremony Ceremony { get;  private set; }

        public CeremonyGuest(long guestId, long ceremonyId, float satisfication)
        {
            GuestId = guestId;
            CeremonyId = ceremonyId;
            Satisfication = satisfication;

        }

        public void Edit(long guestId, long ceremonyId, float satisfication)
        {
            GuestId = guestId;
            CeremonyId = ceremonyId;
            Satisfication = satisfication;
        }
    }
}
