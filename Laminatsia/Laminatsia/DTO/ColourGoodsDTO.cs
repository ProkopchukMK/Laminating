using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class ColourGoodsDTO
    {
        LaminatsiaEntities _entity = new LaminatsiaEntities();

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
                ColourGoodsDTO newcolourGoodsDTO = new ColourGoodsDTO();
                newcolourGoodsDTO.ID = listColourGoods[i].ID;
                newcolourGoodsDTO.DateComing = listColourGoods[0].DateComming;
                int id_profile = listColourGoods[i].Profile_ID;
                newcolourGoodsDTO.Profile = _entity.Profile.FirstOrDefault(x => x.ID == id_profile).NameProfile;
                int id_dealer = listColourGoods[i].Dealer_ID;
                newcolourGoodsDTO.City = _entity.Dealer.FirstOrDefault(x => x.ID == id_dealer).City;
                newcolourGoodsDTO.Dealer = _entity.Dealer.FirstOrDefault(x => x.ID == id_dealer).DealerName;
                newcolourGoodsDTO.Notes = listColourGoods[i].Notes;
                newcolourGoodsDTO.Counts = (byte)listColourGoods[i].Counts;
                int id_colour = listColourGoods[i].Colour_ID;
                newcolourGoodsDTO.Colour = _entity.ColourProfile.FirstOrDefault(x => x.ID == id_colour).Colour;
                newcolourGoodsDTO.DateToWork = listColourGoods[i].DateToWork;
                newcolourGoodsDTO.StatusProfile = listColourGoods[i].StatusProfile;
                newcolourGoodsDTO.DateReady = listColourGoods[i].DateReady;
                newcolourGoodsDTO.StatusGoods = listColourGoods[i].StatusGoods;

                listColourGoodsDTO.Add(newcolourGoodsDTO);
            }
            return listColourGoodsDTO;
        }
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
    }
}
