namespace Haidarieh.Application.Contracts.Sponsor
{
    public class CreateSponsor
    {
        public string Name { get;  set; }
        public string Tel { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public bool IsVisible { get;  set; }
        public string Bio { get;  set; }
    }
}