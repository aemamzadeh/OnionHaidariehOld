using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Multimedia;
using Haidarieh.Domain.MultimediaAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            return _hContext.Multimedias.Where(x => x.CeremonyId == id).Select(x => new EditMultimedia()
            {
                //Id = x.Id,
                Title = x.Title,
                CeremonyId = id,
                FileAlt = x.FileAlt,
                FileTitle = x.FileTitle
            }).FirstOrDefault();
        }
        public List<MultimediaViewModel> Search(MultimediaSearchModel searchModel)
        {

            var query = _hContext.Ceremonies.Include(x => x.Multimedias)
                .Where(x => x.Multimedias.Count() > 0)
                .Select(g => new MultimediaViewModel
            {
                Id = g.Id,
                Title = g.Title,
                CeremonyId = g.Id,
                Ceremony = g.Title,
                FileAddress = g.Image
            }).ToList();

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(g => g.Title.Contains(searchModel.Title)).ToList();

            if (searchModel.CeremonyId != 0)
                query = query.Where(g => g.CeremonyId == searchModel.CeremonyId).ToList();

            return query;



            //var data = _hContext.Ceremonies.FromSqlRaw("SELECT c.Id, c.Title,(select top(1) FileAddress from Tbl_Multimedia mm where mm.ceremonyId = c.Id) as Image " +
            //   "FROM Tbl_Multimedia m, Tbl_Ceremony c  where m.CeremonyId = c.Id group by c.Id, c.Title, c.Id").Select(g => new MultimediaViewModel
            //   {
            //       Id = g.Id,
            //       Title = g.Title,
            //       FileAddress = g.Image
            //   }).ToList();
            //foreach (var item in data)
            //{
            //    Id =item.Id,
            //    Title = g.Title,
            //    FileAddress = g

            //}

            //return data;




            //var query = _hContext.Ceremonies.SqlQuery("").Include(x => x.Multimedias)
            //    .Where(x=>x.Multimedias.Count()>0)
            //    .Select(g => new MultimediaViewModel
            //    {
            //        Id = g.Id,
            //        Title = g.Title,
            //        FileAddress = g.Image
            //    }).ToList();

            //foreach (var item in query)
            //{
            //    foreach (var it in item)
            //    {
            //        var list = new MultimediaViewModel();
            //        list.Id = it.Id;
            //        list.Title = it.Ceremony;
            //        list.CeremonyId = it.CeremonyId;
            //        list.FileAddress = it.FileAddress;
            //        result.Add(list);
            //    }
            //}
            //return query;

            //return query.ToDictionary(k => k.Key, v => v.ToList());


            //var resultlist = _hContext.Ceremonies.FromSqlRaw("SELECT c.Id, c.Title,(select top(1) FileAddress from Tbl_Multimedia mm where mm.ceremonyId = c.Id) as fileAd " +
            //   "FROM Tbl_Multimedia m, Tbl_Ceremony c  where m.CeremonyId = c.Id group by c.Id, c.Title, c.Id")
            //    .Select(g => new MultimediaViewModel 
            //    {
            //        Id = g.Id,
            //        Title = g.Title,
            //        FileAddress =g.
            //    }).AsEnumerable().GroupBy(g => g.CeremonyId).ToList();
            //return resultlist.ToList();

            //var result1 = new List<MultimediaViewModel>();

            //foreach (var item in listg)
            //{
            //    foreach (var it in item)
            //    {
            //        it.
            //    }
            //    var list = new MultimediaViewModel();
            //    //list.Id = item.GetEnumerator(Id);
            //    list.Title = item ;
            //    //list.CeremonyId = cer.CeremonyId;
            //    //list.Ceremony = cer.Ceremony;
            //    //list.FileAddress = cer.FileAddress;
            //    result.Add(list);




            //var listg = from item in querywg
            //            group item by item.Title into grlist
            //            select new { Title = grlist.Key, Id = grlist };
            //select grlist.ToList()   // { grlist.Key,grlist.GetEnumerator( };



            //foreach (var item in listg)
            //{
            //    var list = new MultimediaViewModel();
            //    //list.Id = item.GetEnumerator(Id);
            //    list.Title = item. ;
            //    //list.CeremonyId = cer.CeremonyId;
            //    //list.Ceremony = cer.Ceremony;
            //    //list.FileAddress = cer.FileAddress;
            //    result.Add(list);

            //}
            //return result;


            //                foreach (var cer in item)
            //        {
            //        var list = new MultimediaViewModel();
            //list.Id = cer.Id;
            //            list.Title = cer.Title;
            //            list.CeremonyId = cer.CeremonyId;
            //            list.Ceremony = cer.Ceremony;
            //            list.FileAddress = cer.FileAddress;
            //        result.Add(list);
            //        }



            //var dic = (from c in _hContext.Ceremonies
            //                                 join m in _hContext.Multimedias on c.Id equals m.CeremonyId
            //                                 select new MultimediaViewModel {Id=m.Id, Title=m.Title, CeremonyId= m.CeremonyId, Ceremony=m.Ceremony.Slug, FileAddress=m.FileAddress}).ToList();

            //var x = dic.GroupBy(g => g.CeremonyId).ToList();

            //list = from c in _hContext.Ceremonies
            //       join m in _hContext.Multimedias on c.Id equals m.CeremonyId
            //       group by m.CeremonyId select new { m.Id, m.Title, m.CeremonyId, m.Ceremony.Title, m.FileAddress };

            //if (!string.IsNullOrWhiteSpace(searchModel.Title))
            //    query = query.Where(g => g.Title.Contains(searchModel.Title)).ToList();

            //if (searchModel.CeremonyId != 0)
            //    query = query.Where(g => g.Key == searchModel.CeremonyId).ToList();


            //var query = _hContext.Multimedias.Include(x => x.Ceremony).Select(g => new MultimediaViewModel
            //{
            //    Id = g.Id,
            //    Title = g.Title,
            //    CeremonyId = g.CeremonyId,
            //    Ceremony = g.Ceremony.Title,
            //    FileAddress = g.FileAddress
            //}).ToList();
            //return query;



            //var list = new List<MultimediaViewModel>();

            //var list=from item in query
            //    group item by item.CeremonyId;

            //return query;



            //list = from c in _hContext.Ceremonies
            //       join m in _hContext.Multimedias on c.Id equals m.CeremonyId
            //       group by m.CeremonyId select new { m.Id, m.Title, m.CeremonyId, m.Ceremony.Title, m.FileAddress };


            //var result = (from q in query
            //              group q by q.CeremonyId into g
            //              select new
            //              {
            //                  ceremonyid = g.Key,

            //              }).ToList();



            //        .GroupBy(
            //p => p.PersonId,
            //p => p.car,
            //(key, g) => new { PersonId = key, Cars = g.ToList() });

        }

            public List<MultimediaViewModel> GetMultimediasWithCeremony(long id)
            {
                return _hContext.Multimedias.Where(x => x.CeremonyId == id)
                    .Select(x => new MultimediaViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        FileAddress = x.FileAddress,
                        Ceremony = x.Ceremony.Title,
                        CeremonyId = x.CeremonyId

                    }).ToList();
            }

        public List<Multimedia> GetList(long id)
        {
            return _hContext.Multimedias.Where(x => x.CeremonyId == id).ToList();
        }

        public Multimedia GetFirst(long id)
        {
            return _hContext.Multimedias.FirstOrDefault(x => x.CeremonyId == id);
        }
    }
    }

