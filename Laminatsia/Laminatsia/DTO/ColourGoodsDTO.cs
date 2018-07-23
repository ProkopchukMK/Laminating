using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class ColourGoodsDTO
    {
        LaminatsiaEntities _entity = new LaminatsiaEntities();
        public int ID { get; set; }
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
        public bool? StatusGoods { get; set; }

        public string AddColourGoods(DateTime dateComing, string profile,
            string city, string dealer, string notes,
            byte counts, string colour, DateTime dateToWork, bool statusProfile, DateTime dateReady)
        {
            ColourGoods newColourGoods = new ColourGoods
            {
                DateComming = dateComing.Date,
                Profile = _entity.Profile.FirstOrDefault(x => x.NameProfile == profile),
                Dealer = _entity.Dealer.FirstOrDefault(x => x.DealerName == dealer),
                Notes = notes,
                Counts = counts,
                ColourProfile = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colour),
                DateToWork = dateToWork.Date,
                StatusProfile = statusProfile,
                DateReady = dateReady.Date
            };
            _entity.ColourGoods.Add(newColourGoods);
            _entity.SaveChanges();
            return "Замовлення збережено до бази даних!";
        }
        public List<ColourGoodsDTO> GetListColourGoods()
        {
            List<ColourGoods> listColourGoods = _entity.ColourGoods.ToList();
            List<ColourGoodsDTO> listColourGoodsDTO = new List<ColourGoodsDTO>(listColourGoods.Count);
            for (int i = 0; i < listColourGoods.Count; i++)
            {
                int id_profile = listColourGoods[i].Profile_ID;
                int id_dealer = listColourGoods[i].Dealer_ID;
                int id_colour = listColourGoods[i].Colour_ID;
                ColourGoodsDTO newcolourGoodsDTO = new ColourGoodsDTO
                {
                    ID = listColourGoods[i].ID,
                    DateComing = listColourGoods[i].DateComming.Date,
                    Profile = _entity.Profile.FirstOrDefault(x => x.ID == id_profile).NameProfile,
                    City = _entity.Dealer.FirstOrDefault(x => x.ID == id_dealer).City,
                    Dealer = _entity.Dealer.FirstOrDefault(x => x.ID == id_dealer).DealerName,
                    Notes = listColourGoods[i].Notes,
                    Counts = (byte)listColourGoods[i].Counts,
                    Colour = _entity.ColourProfile.FirstOrDefault(x => x.ID == id_colour).Colour,
                    DateToWork = listColourGoods[i].DateToWork.Date,
                    StatusProfile = listColourGoods[i].StatusProfile,
                    DateReady = listColourGoods[i].DateReady.Date,
                    StatusGoods = listColourGoods[i].StatusGoods
                };

                listColourGoodsDTO.Add(newcolourGoodsDTO);
            }
            return listColourGoodsDTO;
        }
        //фільтр за датою в замовлення
        public List<ColourGoodsDTO> FilterByDateComing(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.DateReady >= startDate && x.DateReady <= endDate).ToList();
            return newFilterList;
        }
        //фільтр за профілем
        public List<ColourGoodsDTO> FilterByProfile(List<ColourGoodsDTO> enterList, string profile)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.Profile == profile).ToList();
            return newFilterList;
        }
        //фільтр за містом
        public List<ColourGoodsDTO> FilterByCity(List<ColourGoodsDTO> enterList, string city)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.City == city).ToList();
            return newFilterList;
        }
        //фільтр за дилером
        public List<ColourGoodsDTO> FilterByDealer(List<ColourGoodsDTO> enterList, string dealer, string city)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.City == city && x.Dealer == dealer).ToList();
            return newFilterList;
        }
        //фільтр за кольором
        public List<ColourGoodsDTO> FilterByColour(List<ColourGoodsDTO> enterList, string colour)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.Colour == colour).ToList();
            return newFilterList;
        }
        //фільтр за датою в роботі        
        public List<ColourGoodsDTO> FilterByDateToWork(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.DateToWork >= startDate && x.DateToWork <= endDate).ToList();
            return newFilterList;
        }
        //фільтр за статусом профілю
        public List<ColourGoodsDTO> FilterByStatusProfile(List<ColourGoodsDTO> enterList, bool statusProfile)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.StatusProfile == statusProfile).ToList();
            return newFilterList;
        }
        //фільтр за датою готовності
        public List<ColourGoodsDTO> FilterByDateReady(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.DateReady >= startDate && x.DateReady <= endDate).ToList();
            return newFilterList;
        }
        //фільтр за статусу замовлення
        public List<ColourGoodsDTO> FilterByStatusGoods(List<ColourGoodsDTO> enterList, bool statusGoods)
        {
            List<ColourGoodsDTO> newFilterList = enterList.Where(x => x.StatusGoods == statusGoods).ToList();
            return newFilterList;
        }
        public List<ColourGoodsDTO> FilterList(DateTime dateTimePickerFilterDataComing1, DateTime dateTimePickerFilterDataComing2, string comboBoxFilterProfile, string comboBoxFilterCity,
                   string comboBoxFilterDealer, string comboBoxFilterColour, DateTime dateTimePickerFilterDataToWork1, DateTime dateTimePickerFilterDataToWork2, bool comboBoxFilterStatusProfile,
                  DateTime dateTimePickerFilterDateReady1, DateTime dateTimePickerFilterDateReady2, bool comboBoxFilterStatusGoods)
        {
            List<ColourGoodsDTO> filteredList = new List<ColourGoodsDTO>(); 
            if ()
            {

            }
            return new List<ColourGoodsDTO>();
        }
        public List<ColourGoodsDTO> FilterList(string comboBoxFilterProfile, string comboBoxFilterCity,
                   string comboBoxFilterDealer, string comboBoxFilterColour, bool comboBoxFilterStatusProfile, bool comboBoxFilterStatusGoods)
        {

            return new List<ColourGoodsDTO>();
        }
    }
}
