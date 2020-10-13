namespace Haidarieh.Application.Contracts.Guest
{
    public class CreateGuest
    {
        public string FullName { get;  set; }
        public string Tel { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public string GuestType { get;  set; }
        public string Coordinator { get;  set; }
    }
}