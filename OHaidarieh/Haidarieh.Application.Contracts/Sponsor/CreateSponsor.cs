using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Sponsor
{
    public class CreateSponsor
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Tel { get;  set; }
        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Image { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public bool IsVisible { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Bio { get;  set; }
    }
}