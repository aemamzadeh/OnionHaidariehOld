using _0_Framework.Application;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Multimedia;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Haidarieh.Application.Contracts.Ceremony
{
    public class CreateCeremony
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
        public string CeremonyDate { get; set; }
        public bool IsLive { get;  set; }
        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile BannerFile { get; set; }
        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        public List<CeremonyGuestViewModel> CeremonyGuests { get;  set; }
        public List<MultimediaViewModel> Multimedias { get;  set; }

    }
}
