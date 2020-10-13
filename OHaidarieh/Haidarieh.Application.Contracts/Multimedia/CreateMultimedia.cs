namespace Haidarieh.Application.Contracts.Multimedia
{
    public class CreateMultimedia
    {
        public string Title { get;  set; }
        public string FileAddress { get;  set; }
        public string FileTitle { get;  set; }
        public string FileAlt { get;  set; }
        public long CeremonyGuestId { get;  set; }
    }
}