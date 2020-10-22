using _01_HaidariehQuery.Contracts.Members;
using _01_HaidariehQuery.Contracts.Sponsers;
using Haidarieh.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_HaidariehQuery.Query
{
    public class SponsorQuery : ISponsorQuery
    {
        private readonly HContext _hContext;

        public SponsorQuery(HContext hContext)
        {
            _hContext = hContext;
        }
        public List<SponsorQueryModel> GetAll()
        {
            return _hContext.Sponsors.Where(x => x.Status == true).Select(x => new SponsorQueryModel
            {
                Name=x.Name,
                Tel=x.Tel,
                Image=x.Image,
                ImageAlt=x.ImageAlt,
                ImageTitle=x.ImageTitle,
                IsVisible=x.IsVisible,
                Bio=x.Bio,
                Status=x.Status
            }).ToList();
        }
    }
}
