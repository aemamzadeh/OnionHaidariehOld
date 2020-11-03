using _0_Framework.Application;
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
        public DateTime CeremonyDate { get;  set; }
        public string CeremonyDateFa { get; set; }

    }
}
