﻿using _0_Framework.Application;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.Guest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Haidarieh.Application.Contracts.CeremonyGuest
{
    public class CreateCeremonyGuest
    {

        [Range(1,long.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long GuestId { get; set; }
        [Range(1,long.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public long CeremonyId { get;  set; }
        public float Satisfication { get; set; }
        public List<CeremonyViewModel> Ceremonies { get; set; }
        public List<GuestViewModel> Guests { get; set; }

    }
}