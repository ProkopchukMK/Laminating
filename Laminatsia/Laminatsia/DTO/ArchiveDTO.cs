using System;
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
        public List<ArchiveDTO> GetAllListArchive()
        {
            List<Archive> listAllArchive = _entity.Archive.Where(x => x.ID != 0).ToList();
            List<ArchiveDTO> listArchiveDTO = new List<ArchiveDTO>(listAllArchive.Count);
            for (int i = 0; i < listAllArchive.Count; i++)
            {
                ArchiveDTO newArchiveDTO = new ArchiveDTO
                {
                    ID_ColourGoods = listAllArchive[i].ID_ColourGoods,
                    DateComing = listAllArchive[i].DateComing.Date,
                    Profile = listAllArchive[i].Profile,
                    City = listAllArchive[i].City,
                    Dealer = listAllArchive[i].Dealer,
                    Notes = listAllArchive[i].Notes,
                    Counts = (byte)listAllArchive[i].Counts,
                    Colour = listAllArchive[i].Colour,
                    DateToWork = listAllArchive[i].DateToWork.Date,
                    StatusProfile = listAllArchive[i].StatusProfile,
                    DateReady = listAllArchive[i].DateReady.Date,
                    StatusGoods = listAllArchive[i].StatusGoods == "В РОБОТІ" ? true : false,
                    UserName = listAllArchive[i].UserName,
                    DateOperatsia = listAllArchive[i].DataTimeChange,
                    Action = listAllArchive[i].Action
                };
                listArchiveDTO.Add(newArchiveDTO);
            }
            return listArchiveDTO.OrderByDescending(x => x.DateOperatsia).ToList();
        }
        public List<ArchiveDTO> GetListArchiveDisting()
        {
            List<int> listIDArchive = _entity.Archive.Select(x => x.ID_ColourGoods).Distinct().ToList();
            List<ArchiveDTO> listArchive = new List<ArchiveDTO>();
            List<ArchiveDTO> listArchiveDTO = new List<ArchiveDTO>(listIDArchive.Count);
            for (int i = 0; i < listIDArchive.Count; i++)
            {
                listArchive.Add( this.GetByIDColourGoods(listIDArchive[i]));
            }
            return listArchive.OrderByDescending(x => x.DateOperatsia).ToList();
        }
        public ArchiveDTO GetByIDColourGoods(int id)
        {
            var colourGoods = _entity.Archive.FirstOrDefault(x => x.ID_ColourGoods == id);
            ArchiveDTO archiveDTO = new ArchiveDTO();
            archiveDTO.ID_ColourGoods = colourGoods.ID_ColourGoods;
            archiveDTO.DateComing = colourGoods.DateComing.Date;
            archiveDTO.Profile = colourGoods.Profile;
            archiveDTO.City = colourGoods.City;
            archiveDTO.Dealer = colourGoods.Dealer;
            archiveDTO.Notes = colourGoods.Notes;
            archiveDTO.Counts = (byte)colourGoods.Counts;
            archiveDTO.Colour = colourGoods.Colour;
            archiveDTO.DateToWork = colourGoods.DateToWork.Date;
            archiveDTO.StatusProfile = colourGoods.StatusProfile;
            archiveDTO.DateReady = colourGoods.DateReady.Date;
            archiveDTO.StatusGoods = colourGoods.StatusGoods == "В РОБОТІ" ? true : false;
            archiveDTO.UserName = colourGoods.UserName;
            archiveDTO.DateOperatsia = colourGoods.DataTimeChange;
            archiveDTO.Action = colourGoods.Action;
            return archiveDTO;
        }
        public List<ArchiveDTO> FilterArchive(List<ArchiveDTO> filterList, object profile, object city, object dealer, object colour, object userName)
        {
            if (profile != null)
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
        public List<ArchiveDTO> FilterByIDColourGoods(List<ArchiveDTO> enterList, int id)
        {
            return enterList.Where(x => x.ID_ColourGoods == id).ToList();
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
