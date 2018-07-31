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
        public bool StatusGoods { get; set; }

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
        public List<ColourGoodsDTO> UdateColourGoods(int id,DateTime dateComing,string profile,string city,string dealer,string notes,byte counts,string colour,DateTime dateToWork,bool statusProfile,DateTime dateReady)
        {
            ColourGoods editColourGoods = _entity.ColourGoods.FirstOrDefault(x => x.ID == id);
            editColourGoods.DateComming = dateComing.Date;
            editColourGoods.Profile_ID = _entity.Profile.FirstOrDefault(x => x.NameProfile == profile).ID;
            editColourGoods.Dealer_ID = _entity.Dealer.FirstOrDefault(x => x.City == city && x.DealerName == dealer).ID;
            editColourGoods.Notes = notes;
            editColourGoods.Counts = counts;
            editColourGoods.Colour_ID = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colour).ID;
            editColourGoods.DateToWork = dateToWork.Date;
            editColourGoods.StatusProfile = statusProfile;
            editColourGoods.DateReady = dateReady.Date;            
            _entity.SaveChanges();
            return this.GetListColourGoods();
        }
        public bool UpdateStatusGood(int id, bool editStatusGoods)
        {
            ColourGoods editColourGoods = _entity.ColourGoods.Find(id);
            if (editStatusGoods == editColourGoods.StatusGoods)
            {
                //Змін немає, дані на зберігаємо
                return false;
            }
            else
            {
                editColourGoods.StatusGoods = editStatusGoods;  //ПЕРЕВОДИМО В ЗНАЧЕННЯ  - В РОБОТІ
                _entity.SaveChanges();  // ЗБЕРІГАЄМО РЕЗУЛЬТАТ
                return true;
            }
        }
        public bool UpdateStatusProfile(int id, bool editStatusProfile)
        {
            ColourGoods editColourGoods = _entity.ColourGoods.Find(id);
            if (editStatusProfile == editColourGoods.StatusProfile)
            {
                //Змін немає, дані на зберігаємо
                return false;
            }
            else
            {
                editColourGoods.StatusProfile = editStatusProfile;  //ПЕРЕВОДИМО В ЗНАЧЕННЯ  - В РОБОТІ
                _entity.SaveChanges();  // ЗБЕРІГАЄМО РЕЗУЛЬТАТ
                return true;
            }
        }

        public List<ColourGoodsDTO> GetListColourGoods()
        {
            List<ColourGoods> listColourGoods = _entity.ColourGoods.Where(x => x.ID != 0).ToList();
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
            return listColourGoodsDTO.OrderByDescending(x => x.DateComing).ToList();
        }
        public ColourGoodsDTO GetColourGoodsByID(int id)
        {
            ColourGoods selectColourGoods = _entity.ColourGoods.FirstOrDefault(x => x.ID == id);
            if (selectColourGoods == null) { return null; }
            else
            {
                ColourGoodsDTO colourGoodsDTO = new ColourGoodsDTO
                {
                    ID = selectColourGoods.ID,
                    DateComing = selectColourGoods.DateComming.Date,
                    Profile = _entity.Profile.FirstOrDefault(x => x.ID == selectColourGoods.Profile_ID).NameProfile,
                    City = _entity.Dealer.FirstOrDefault(x => x.ID == selectColourGoods.Dealer_ID).City,
                    Dealer = _entity.Dealer.FirstOrDefault(x => x.ID == selectColourGoods.Dealer_ID).DealerName,
                    Notes = selectColourGoods.Notes,
                    Counts = (byte)selectColourGoods.Counts,
                    Colour = _entity.ColourProfile.FirstOrDefault(x => x.ID == selectColourGoods.Colour_ID).Colour,
                    DateToWork = selectColourGoods.DateToWork.Date,
                    StatusProfile = selectColourGoods.StatusProfile,
                    DateReady = selectColourGoods.DateReady.Date,
                    StatusGoods = selectColourGoods.StatusGoods
                };
                return colourGoodsDTO;
            }
        }
        #region фільтр датагрідвью

        //фільтр за датою в замовлення
        public List<ColourGoodsDTO> FilterByDateComing(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            if (startDate == null && endDate == null)
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.DateReady >= startDate && x.DateReady <= endDate).ToList();
                return enterList;
            }
        }
        //фільтр за профілем
        public List<ColourGoodsDTO> FilterByProfile(List<ColourGoodsDTO> enterList, string profile)
        {
            if (profile == "")
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.Profile == profile).ToList();
                return enterList;
            }
        }
        //фільтр за містом
        public List<ColourGoodsDTO> FilterByCity(List<ColourGoodsDTO> enterList, string city)
        {
            if (city == "")
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.City == city).ToList();
                return enterList;
            }
        }
        //фільтр за дилером
        public List<ColourGoodsDTO> FilterByDealer(List<ColourGoodsDTO> enterList, string dealer, string city)
        {
            if (dealer == "" && city == "")
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.City == city && x.Dealer == dealer).ToList();
                return enterList;
            }
        }
        //фільтр за кольором
        public List<ColourGoodsDTO> FilterByColour(List<ColourGoodsDTO> enterList, string colour)
        {
            if (colour == "")
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.Colour == colour).ToList();
                return enterList;
            }
        }
        //фільтр за датою в роботі        
        public List<ColourGoodsDTO> FilterByDateToWork(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            if (startDate == null && endDate == null)
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.DateToWork >= startDate && x.DateToWork <= endDate).ToList();
                return enterList;
            }
        }
        //фільтр за статусом профілю
        public List<ColourGoodsDTO> FilterByStatusProfile(List<ColourGoodsDTO> enterList, bool? statusProfile)
        {
            if (statusProfile == null)
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.StatusProfile == statusProfile).ToList();
                return enterList;
            }
        }
        //фільтр за датою готовності
        public List<ColourGoodsDTO> FilterByDateReady(List<ColourGoodsDTO> enterList, DateTime startDate, DateTime endDate)
        {
            if (startDate == null && endDate == null)
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.DateReady >= startDate && x.DateReady <= endDate).ToList();
                return enterList;
            }
        }
        //фільтр за статусу замовлення
        public List<ColourGoodsDTO> FilterByStatusGoods(List<ColourGoodsDTO> enterList, bool? statusGoods)
        {
            if (statusGoods == null)
            {
                return enterList;
            }
            else
            {
                enterList = enterList.Where(x => x.StatusGoods == statusGoods).ToList();
                return enterList;
            }
        }
        public List<ColourGoodsDTO> FilterList(
            bool checkboxDateComing, DateTime dateTimePickerFilterDataComing1, DateTime dateTimePickerFilterDataComing2,
            object comboBoxFilterProfile, object comboBoxFilterCity, object comboBoxFilterDealer, object comboBoxFilterColour,
            bool checkboxDataToWork, DateTime dateTimePickerFilterDataToWork1, DateTime dateTimePickerFilterDataToWork2,
            bool? comboBoxFilterStatusProfile,
            bool checkboxDateReady, DateTime dateTimePickerFilterDateReady1, DateTime dateTimePickerFilterDateReady2,
            bool? comboBoxFilterStatusGoods)
        {
            List<ColourGoodsDTO> filteredList = this.GetListColourGoods();
            if (checkboxDateComing)
            {
                filteredList = this.FilterByDateComing(filteredList, dateTimePickerFilterDataComing1.Date, dateTimePickerFilterDataComing2.Date);
            }
            filteredList = this.FilterByProfile(filteredList, (string)comboBoxFilterProfile ?? "");
            if (comboBoxFilterDealer == null)
            {
                filteredList = this.FilterByCity(filteredList, (string)comboBoxFilterCity ?? "");
            }
            else
            {
                filteredList = this.FilterByDealer(filteredList, (string)comboBoxFilterDealer ?? "", (string)comboBoxFilterCity ?? "");
            }
            filteredList = this.FilterByColour(filteredList, (string)comboBoxFilterColour ?? "");
            if (checkboxDataToWork)
            {
                filteredList = this.FilterByDateToWork(filteredList, dateTimePickerFilterDataToWork1, dateTimePickerFilterDataToWork2);
            }

            filteredList = this.FilterByStatusProfile(filteredList, comboBoxFilterStatusProfile);
            if (checkboxDateReady)
            {
                filteredList = this.FilterByDateReady(filteredList, dateTimePickerFilterDateReady1, dateTimePickerFilterDateReady2);
            }

            filteredList = this.FilterByStatusGoods(filteredList, comboBoxFilterStatusGoods);
            return filteredList;
        }
        #endregion
    }
}
