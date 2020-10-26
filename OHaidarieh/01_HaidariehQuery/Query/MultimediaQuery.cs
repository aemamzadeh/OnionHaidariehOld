using _01_HaidariehQuery.Contracts.CeremonyGuests;
using _01_HaidariehQuery.Contracts.Multimedias;
using Haidarieh.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    public class MultimediaQuery : IMultimediaQuery
    {
        private readonly HContext _hContext;

        public MultimediaQuery(HContext hContext)
        {
            _hContext = hContext;
        }

        //public List<MultimediaQueryModel> GetDetail(string Id)
        //{
        //    return _hContext.Multimedias.Where(x=>x.CeremonyGuest.Slug==Id).Select(x => new MultimediaQueryModel
        //    {
        //        Id=x.Id,
        //        Title=x.Title,
        //        CeremonyGuest=x.CeremonyGuest.Ceremony.Title,
        //        CeremonyGuestId=x.CeremonyGuestId,
        //        CeremonyDate=x.CeremonyGuest.CeremonyDate,
        //        FileAddress=x.FileAddress,
        //        FileAlt=x.FileAlt,
        //        FileTitle=x.FileTitle,
        //        Slug=x.CeremonyGuest.Slug,
        //        Status=x.Status

        //    }).ToList();
        //}
    }
}
