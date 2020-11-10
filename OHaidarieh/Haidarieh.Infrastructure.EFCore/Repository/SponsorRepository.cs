using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Sponsor;
using Haidarieh.Domain.SponsorAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class SponsorRepository : RepositoryBase<long, Sponsor>, ISponsorRepository
    {
        private readonly HContext _hContext;

        public SponsorRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditSponsor GetDetail(long id)
        {
            return _hContext.Sponsors.Select(x => new EditSponsor()
            {
                Id = x.Id,
                Name = x.Name,
                Tel = x.Tel,
                Bio = x.Bio,
                IsVisible = x.IsVisible,
                //Image = x.Image,
                ImageAlt = x.ImageAlt,
                ImageTitle = x.ImageTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SponsorViewModel> Search(SponsorSearchModel searchModel)
        {
            var query = _hContext.Sponsors.Select(x => new SponsorViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Tel = x.Tel,
                Bio = x.Bio,
                IsVisible = x.IsVisible,
                Image = x.Image
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
