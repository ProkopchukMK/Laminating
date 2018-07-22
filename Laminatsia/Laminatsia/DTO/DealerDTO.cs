using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class DealerDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddDealer(string city, string dealerName)
        {
            Dealer dealerList = _entity.Dealer.FirstOrDefault(x => x.City == city && x.DealerName == dealerName);
            if (dealerList == null)
            {
                Dealer newDealer = new Dealer { DealerName = dealerName, City = city };
                _entity.Dealer.Add(newDealer);
                _entity.SaveChanges();
                return "Дилера " + city + " " + dealerName + " добавлено!";
            }
            else
            {
                return "Такий дилер в базі вже є!";
            }
        }
        public string RemoveDealer(string cityDealer, string dealerName)
        {
            Dealer removeDealer = _entity.Dealer.FirstOrDefault(x => x.City == cityDealer && x.DealerName == dealerName);
            _entity.Dealer.Remove(removeDealer);
            _entity.SaveChanges();
            return "Дилера видаленно!";
        }
        public List<string> GetListDealer()
        {
            var listDealer = _entity.Dealer.Select(x => x.DealerName).ToList<string>();
            listDealer = listDealer.Distinct().ToList();
            listDealer.Sort();
            return listDealer;
        }
        public List<string> GetListCity()
        {
            var listCity = _entity.Dealer.Select(x => x.City).ToList<string>();
            listCity = listCity.Distinct().ToList();
            listCity.Sort();
            return listCity;
        }
        public List<string> GetListDealerByCity(string cityName)
        {
            var listDealer = _entity.Dealer.Where(x => x.City.Trim() == cityName.Trim()).Select(c => c.DealerName.Trim()).ToList();
            listDealer.Sort();
            return listDealer;
        }
    }
}
