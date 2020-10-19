﻿using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Domain.MultimediaAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class MultimediaRepository : RepositoryBase<long, Multimedia>, IMultimediaRepository
    {
        private readonly HContext _hContext;
        public MultimediaRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }
        public EditMultimedia GetDetail(long id)
        {
            return _hContext.Multimedias.Select(x => new EditMultimedia()
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyGuestId = x.CeremonyGuestId,
                FileAddress = x.FileAddress,
                FileAlt = x.FileAlt,
                FileTitle = x.FileTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<MultimediaViewModel> Search(MultimediaSearchModel searchModel)
        {
            var query = _hContext.Multimedias.Include(x=>x.CeremonyGuest).Select(x => new MultimediaViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyGuestId=x.CeremonyGuestId,
                CeremonyGuest = x.CeremonyGuest.Ceremony.Title,
                FileAddress = x.FileAddress
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CeremonyGuestId!=0)
                query = query.Where(x => x.CeremonyGuestId==searchModel.CeremonyGuestId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
