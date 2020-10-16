namespace Haidarieh.Application.Contracts.Sponsor
{
    public class SponsorViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Tel { get;  set; }
        public string Image { get;  set; }
        public bool IsVisible { get;  set; }
        public string Bio { get;  set; }
    }
}