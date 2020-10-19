namespace Haidarieh.Application.Contracts.Multimedia
{
    public class MultimediaViewModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public string FileAddress { get;  set; }
        public long CeremonyGuestId { get;  set; }
        public string CeremonyGuest { get; set; }

    }
}