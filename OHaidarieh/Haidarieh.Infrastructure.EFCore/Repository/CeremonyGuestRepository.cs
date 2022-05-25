﻿using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Haidarieh.Application.Contracts.Ceremony;
using Haidarieh.Application.Contracts.CeremonyGuest;
using Haidarieh.Application.Contracts.Guest;
using Haidarieh.Domain.CeremonyGuestAgg;
using Haidarieh.Domain.GuestAgg;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Haidarieh.Infrastructure.EFCore.Repository
{
    public class CeremonyGuestRepository : RepositoryBase<long, CeremonyGuest>, ICeremonyGuestRepository
    {
        private readonly HContext _hContext;

        public CeremonyGuestRepository(HContext hContext) : base(hContext)
        {
            _hContext = hContext;
        }

        public List<CeremonyGuestViewModel> GetCeremonyGuests(long id = 0)
        {
            var query= _hContext.CeremonyGuests.Where(x => x.CeremonyId == id)
                .Select(x => new CeremonyGuestViewModel
            {
                Id = x.Id,
                GuestId = x.GuestId,
                CeremonyId = x.CeremonyId,
                Satisfication = x.Satisfication,
                Guest = x.Guest.FullName,
                GuestPic=x.Guest.Image,
                GuestType= GuestTypes.GetGuestType(x.Guest.GuestType)
                }).ToList();
            //foreach (var item in query)
            //{
            //    item.AllGuests = _hContext.Guests.Select(x => new TelViewModel
            //    {
            //        Id = x.Id,
            //        FullName = x.FullName
            //    }).ToList();
            //}
            if (id != 0)
                return query.Where(x => x.CeremonyId == id).ToList();
            return query;
        }

        public EditCeremonyGuest GetDetail(long Id)
        {
            var result = _hContext.Ceremonies.Include(x => x.CeremonyGuests).ThenInclude(x => x.Guest)
                .Select(x => new EditCeremonyGuest
                {
                    Id=x.Id,
                    //CeremonyId = x.Id,
                    Title = x.Title,
                    //Guest = x.Guest.FullName,
                    CeremonyDate = x.CeremonyDate.ToFarsi(),
                    //GuestId=x.GuestId,
                    //GuestType= GuestTypes.GetGuestType(x.Guest.GuestType),
                    //Satisfication =x.ceSatisfication
                    //Guests = MapCGuests(x.CeremonyGuests)
                }).FirstOrDefault(x => x.Id == Id);
                    //result.AllGuests= _hContext.Guests.Select(x => new TelViewModel { Id = x.Id, FullName = x.FullName }).ToList();
            //foreach (var item in result.Guests)
            //{
            //    item.AllGuests = _hContext.Guests.Select(x => new TelViewModel { Id=x.Id,FullName=x.FullName }).ToList();
            //}

            //JsonSerializer ser = new JsonSerializer();
            //result.AllG = JsonConvert.SerializeObject(result.AllGuests);

            return result;
        }



        //private static List<GuestViewModel> MapGuests(List<CeremonyGuest> ceremonyGuests)
        //{
        //    var guests = new List<GuestViewModel>();
        //    foreach (var item in ceremonyGuests)
        //    {
        //        var gst = new GuestViewModel
        //        {
        //            Id = item.GuestId,
        //            FullName = item.Guest.FullName,
        //            Image = item.Guest.Image
        //        };
        //        guests.Add(gst);
        //    }
        //    return guests;
        //}


        public List<CeremonyViewModel> Search(CeremonyGuestSearchModel searchModel)
        {
            var query = _hContext.Ceremonies.Where(x => x.CeremonyGuests.Count() > 0).Include(x => x.CeremonyGuests).ThenInclude(x => x.Guest)
            .Select(x => new CeremonyViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CeremonyDate = x.CeremonyDate.ToFarsi(),
                CeremonyGuests = MapCGuests(x.CeremonyGuests)
            });

            //if (searchModel.GuestId != 0)
            //    query = query.Where(x => x.CeremonyGuests.GuestId == searchModel.GuestId);

            if (searchModel.CeremonyId != 0)
                query = query.Where(x => x.Id == searchModel.CeremonyId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        private static List<CeremonyGuestViewModel> MapCGuests(List<CeremonyGuest> ceremonyGuests)
        {
            var guests = new List<CeremonyGuestViewModel>();
            foreach (var item in ceremonyGuests)
            {
                var gst = new CeremonyGuestViewModel
                {

                    Id = item.Id,
                    CeremonyId = item.CeremonyId,
                    GuestId = item.GuestId,
                    GuestType = GuestTypes.GetGuestType(item.Guest.GuestType),
                    Guest = item.Guest.FullName,
                    GuestPic = item.Guest.Image,
                    Satisfication = item.Satisfication
                };
                guests.Add(gst);
            }


            return guests;
        }





        public List<CeremonyGuestViewModel> GetGuests()
        {
            return _hContext.CeremonyGuests.Include(x => x.Guest).Select(x => new CeremonyGuestViewModel
            {
                Id = x.Id,
                GuestId = x.Id,
                Guest = x.Guest.FullName,
                GuestPic=x.Guest.Image,
                GuestType = GuestTypes.GetGuestType(x.Guest.GuestType),
                Satisfication = x.Satisfication                
            }).ToList();
        }


        //public Dictionary<long, List<CeremonyGuestViewModel>> Search(CeremonyGuestSearchModel searchModel)
        //{
        //    var query = _hContext.Ceremonies.Include(x => x.CeremonyGuests).ThenInclude(x => x.Guest)
        //        .Select(g => new CeremonyGuestViewModel
        //        {
        //            Id = g.Id,
        //            Ceremony = g.Title,
        //            CeremonyDate = g.CeremonyDate.ToFarsi(),
        //            GuestId = g.CeremonyGuests.GuestId,
        //            GuestType = GuestTypes.GetGuestType(g.Guest.GuestType),
        //            Guest = g.CeremonyGuests.Guest.FullName
        //        }).ToList().GroupBy(g => g.CeremonyId);
        //    return query.ToDictionary(k => k.Key, v => v.ToList());
        //}

        //public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        //{
        //    var result = new List<CeremonyGuestViewModel>();
        //    var ceremonies = _hContext.Ceremonies.Distinct().Include(x => x.CeremonyGuests).ThenInclude(x => x.Guest).Where(x => x.CeremonyGuests.Count() > 0).ToList();
        //    foreach (var cer in ceremonies)
        //    {
        //        var cers = new CeremonyGuestViewModel
        //        {
        //            Id = cer.Id,
        //            Ceremony = cer.Title,
        //            CeremonyDate = cer.CeremonyDate.ToFarsi(),
        //        };
        //        result.Add(cers);
        //        foreach (var guest in cer.CeremonyGuests)
        //        {
        //            var gst = new CeremonyGuestViewModel
        //            {
        //                Id = guest.Id,
        //                CeremonyId = guest.CeremonyId,
        //                GuestId = guest.GuestId,
        //                GuestType = GuestTypes.GetGuestType(guest.Guest.GuestType),
        //                Guest = guest.Guest.FullName
        //            };
        //            result.Add(gst);
        //        }
        //    }
        //    if (searchModel.GuestId != 0)
        //        result = result.Where(x => x.GuestId == searchModel.GuestId).ToList();

        //    if (searchModel.CeremonyId != 0)
        //        result = result.Where(x => x.CeremonyId == searchModel.CeremonyId).ToList();

        //    return result.OrderByDescending(x => x.Id).ToList();


        //public List<CeremonyGuestViewModel> Search(CeremonyGuestSearchModel searchModel)
        //{
        //    var result = new List<CeremonyGuestViewModel>();
        //    var ceremonies = _hContext.Ceremonies.Distinct().Include(x => x.CeremonyGuests).ThenInclude(x => x.Guest).Where(x => x.CeremonyGuests.Count() > 0).ToList();
        //    foreach (var cer in ceremonies)
        //    {
        //        foreach (var guest in cer.CeremonyGuests)
        //        {
        //            var gst = new CeremonyGuestViewModel
        //            {
        //                Id = guest.CeremonyId,
        //                CeremonyId = guest.CeremonyId,
        //                Ceremony = guest.Ceremony.Title,
        //                CeremonyDate = guest.Ceremony.CeremonyDate.ToFarsi(),
        //                GuestId = guest.GuestId,
        //                GuestType = GuestTypes.GetGuestType(guest.Guest.GuestType),
        //                Guest = guest.Guest.FullName
        //            };
        //            result.Add(gst);
        //        }
        //    }
        //    if (searchModel.GuestId != 0)
        //        result = result.Where(x => x.GuestId == searchModel.GuestId).ToList();

        //    if (searchModel.CeremonyId != 0)
        //        result = result.Where(x => x.CeremonyId == searchModel.CeremonyId).ToList();

        //    return result.OrderByDescending(x => x.Id).ToList();


        //var query = _hContext.Ceremonies.Include(x=>x.CeremonyGuests)
        //    .Select(x => new CeremonyGuestViewModel
        //    {
        //        Id = x.Id,
        //        Guests = MapGuests(x.Id),
        //        Ceremony = x.Title,
        //        CeremonyDate = x.CeremonyDate.ToFarsi(),
        //        GuestId = x.GuestId,
        //        GuestType = GuestTypes.GetGuestType(x.Guest.GuestType),
        //        CeremonyId = x.CeremonyId,
        //        Satisfication = x.Satisfication
        //    });

        //if (searchModel.GuestId != 0)
        //    query = query.Where(x => x.GuestId == searchModel.GuestId);

        //if (searchModel.CeremonyId != 0)
        //    query = query.Where(x => x.CeremonyId == searchModel.CeremonyId);

        //return query.OrderByDescending(x => x.Id).ToList();
    }
}

