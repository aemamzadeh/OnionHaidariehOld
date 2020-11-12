
namespace _01_HaidariehQuery.Contracts.CeremonyGuests
{
    public class CeremonyGuestQueryModel
    {
        public long Id { get; set; }
        public long GuestId { get;  set; }
        public long CeremonyId { get;  set; }
        public string Guest { get; set; }
        public string Ceremony { get; set; }
    }
}
