using _0_Framework.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Haidarieh.Domain.CeremonyAgg
{
    public class Sponsor: EntityBase
    {
        public string Name { get; private set; }
        public string Tel { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public bool Status { get; private set; }
        public bool IsVisible { get; private set; }
        public string Bio { get; private set; }

        public Sponsor(string name, string tel, string image, string imageAlt, 
            string imageTitle, bool isVisible, string bio)
        {
            Name = name;
            Tel = tel;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Status = true;
            IsVisible = isVisible;
            Bio = bio;
        }
        public void Edit(string name, string tel, string image, string imageAlt,
            string imageTitle, bool isVisible, string bio)
        {
            Name = name;
            Tel = tel;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Status = true;
            IsVisible = isVisible;
            Bio = bio;
        }
    }
}
