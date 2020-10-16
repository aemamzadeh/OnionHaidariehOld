﻿using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Haidarieh.Application.Contracts.Multimedia
{
    public class CreateMultimedia
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FileAddress { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FileTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FileAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public long CeremonyGuestId { get;  set; }
    }
}