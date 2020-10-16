using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Guest
{
    public class CreateGuest
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FullName { get;  set; }
        public string Tel { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Image { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ImageTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string GuestType { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Coordinator { get;  set; }
    }
}