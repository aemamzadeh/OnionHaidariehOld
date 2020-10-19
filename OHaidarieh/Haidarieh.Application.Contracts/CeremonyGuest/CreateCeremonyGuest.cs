using _0_Framework.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.Guest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CreateCeremonyGuest
    {
        public long GuestId { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long CeremonyId { get;  set; }
        public DateTime CeremonyDate { get;  set; }
        public float Satisfication { get;  set; }
        public bool IsLive { get;  set; }
        public string BannerFile { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Image { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get;  set; }
        public List<CeremonyViewModel> CeremoniesM { get; set; }
        public List<GuestViewModel> GuestsM { get; set; }

    }
}