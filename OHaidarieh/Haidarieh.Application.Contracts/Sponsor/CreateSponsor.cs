using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Sponsor
{
    public class CreateSponsor
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string Tel { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Image { get;  set; }
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