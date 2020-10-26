﻿using _01_HaidariehQuery.Contracts.Multimedias;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_HaidariehQuery.Contracts.CeremonyGuests
{
    public interface ICeremonyGuestQuery
    {
        List<CeremonyGuestQueryModel> GetComing();
        List<CeremonyGuestQueryModel> GetPast();
        List<CeremonyGuestQueryModel> GetAll();
        List<CeremonyGuestQueryModel> GetCeremonyGuestWithMultimedias();
        public CeremonyGuestQueryModel GetCeremonyGuestWithMultimedias(string slug);



    }
}