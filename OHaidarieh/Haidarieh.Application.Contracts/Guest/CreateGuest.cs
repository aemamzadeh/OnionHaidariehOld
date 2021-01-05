using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Guest
{
    public class CreateGuest
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get;  set; }
        public string Tel { get;  set; }
        public string Email { get; set; }
        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Image { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long GuestType { get;  set; }
        public string GuestTypeS { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Coordinator { get;  set; }
    }
}