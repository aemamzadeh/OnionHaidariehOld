using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.Sponsers
{
    public class SponsorQueryModel
    {
        public string Name { get;  set; }
        public string Tel { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public bool Status { get;  set; }
        public bool IsVisible { get;  set; }
        public string Bio { get;  set; }
    }
}
