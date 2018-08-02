﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class ArchiveDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();

        public int ID_ColourGoods { get; set; }
        public DateTime DateComing { get; set; }
        public string Profile { get; set; }
        public string City { get; set; }
        public string Dealer { get; set; }
        public string Notes { get; set; }
        public byte Counts { get; set; }
        public string Colour { get; set; }
        public DateTime DateToWork { get; set; }
        public bool StatusProfile { get; set; }
        public DateTime DateReady { get; set; }
        public bool StatusGoods { get; set; }

        public string UserName { get; set; }
        public string Action { get; set; }
        public DateTime DateOperatsia { get; set; }

        public void AddToArchive(
            int id, DateTime dateComing, string profile, string city, string dealer, string notes, byte counts,
            string colour, DateTime dateToWork, bool statusProfile, DateTime dateReady, bool statusGoods, string userName, string action)
        {
            Archive addToArchive = new Archive();

            addToArchive.ID_ColourGoods = id;
            addToArchive.DateComing = dateComing.Date;
               addToArchive.Profile = profile;
            addToArchive.City = city;
            addToArchive.Dealer = dealer;
            addToArchive.Notes = notes;
            addToArchive.Counts = counts;
            addToArchive.Colour = colour;
            addToArchive.DateToWork = dateToWork.Date;
            addToArchive.StatusProfile = statusProfile;
            addToArchive.DateReady = dateReady.Date;
            addToArchive.StatusGoods = statusGoods == true ? "В РОБОТІ" : "НЕ В РОБОТІ";
            addToArchive.UserName = userName;
            addToArchive.Action = action;
            addToArchive.DataTimeChange = DateTime.Now;

            _entity.Archive.Add(addToArchive);
            _entity.SaveChanges();
        }
        public List<ArchiveDTO> GetListArchive()
        {
            List<Archive> listColourGoods = _entity.Archive.Where(x => x.ID != 0).ToList();
            List<ArchiveDTO> listColourGoodsDTO = new List<ArchiveDTO>(listColourGoods.Count);
            for (int i = 0; i < listColourGoods.Count; i++)
            {
                ArchiveDTO newArchiveDTO = new ArchiveDTO
                {
                    ID_ColourGoods = listColourGoods[i].ID_ColourGoods,
                    DateComing = listColourGoods[i].DateComing.Date,
                    Profile = listColourGoods[i].Profile,
                    City = listColourGoods[i].City,
                    Dealer = listColourGoods[i].Dealer,
                    Notes = listColourGoods[i].Notes,
                    Counts = (byte)listColourGoods[i].Counts,
                    Colour = listColourGoods[i].Colour,
                    DateToWork = listColourGoods[i].DateToWork.Date,
                    StatusProfile = listColourGoods[i].StatusProfile,
                    DateReady = listColourGoods[i].DateReady.Date,
                    StatusGoods = listColourGoods[i].StatusGoods == "В РОБОТІ" ? true : false,
                    UserName = listColourGoods[i].UserName,
                    DateOperatsia = listColourGoods[i].DataTimeChange,
                    Action = listColourGoods[i].Action
                };
                listColourGoodsDTO.Add(newArchiveDTO);
            }
            return listColourGoodsDTO.OrderByDescending(x => x.DateOperatsia).ToList();
        }
        public List<ArchiveDTO> FilterArchive(object profile, object city, object dealer, object colour, object userName)
        {
            var filterList = this.GetListArchive();
            if(profile != null)
            {
                filterList = this.FilterByProfile(filterList, profile.ToString());
            }
            if (city != null)
            {
                filterList = this.FilterByCity(filterList, city.ToString());
            }
            if (dealer != null)
            {
                filterList = this.FilterByDealer(filterList, dealer.ToString());
            }
            if (colour != null)
            {
                filterList = this.FilterByColour(filterList, colour.ToString());
            }
            if (userName != null)
            {
                filterList = this.FilterByUser(filterList, userName.ToString());
            }
            return filterList;
        }
        public List<ArchiveDTO> FilterByProfile(List<ArchiveDTO> enterList, string profile)
        {
            return enterList.Where(x => x.Profile == profile).ToList();
        }
        public List<ArchiveDTO> FilterByCity(List<ArchiveDTO> enterList, string city)
        {
            return enterList.Where(x => x.City == city).ToList();
        }
        public List<ArchiveDTO> FilterByDealer(List<ArchiveDTO> enterList, string dealer)
        {
            return enterList.Where(x => x.Dealer == dealer).ToList();
        }
        public List<ArchiveDTO> FilterByColour(List<ArchiveDTO> enterList, string colour)
        {
            return enterList.Where(x => x.Colour == colour).ToList();
        }
        public List<ArchiveDTO> FilterByUser(List<ArchiveDTO> enterList, string userName)
        {
            return enterList.Where(x => x.UserName == userName).ToList();
        }
    }
}
