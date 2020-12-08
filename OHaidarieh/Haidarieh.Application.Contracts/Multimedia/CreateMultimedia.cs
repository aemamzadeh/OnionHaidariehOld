using _0_Framework.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Multimedia
{
    public class CreateMultimedia
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile FileAddress { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FileTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FileAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long CeremonyId { get;  set; }
        public string Slug { get; set; }
        public List<CeremonyViewModel> Ceremonies { get; set; }
    }
}