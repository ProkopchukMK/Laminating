using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class DealerDTO
    {
        private  LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddDealer(string cityName, string dealerName)
        {
            Dealer dealerList = _entity.Dealer.FirstOrDefault(x => x.DealerName == dealerName);
            if (dealerList == null)
            {
                Dealer newDealer = new Dealer();
                newDealer.DealerName = dealerName;
                newDealer.City = cityName;
                _entity.AddToDealer(newDealer);
                _entity.SaveChanges();
                return "Дилера " + dealerName + " добавлено!";
            }
            else
            {
                return "Такий дилер в базі вже є!";
            }
        }
        public string RemoveDealer(string cityDealer, string dealerName)
        {
            Dealer removeDealer = _entity.Dealer.FirstOrDefault(x => x.DealerName == dealerName && x.City == cityDealer);
            _entity.DeleteObject(removeDealer);
            _entity.SaveChanges();
                return "Дилера видаленно!";
        }
        public List<string> GetListDealer()
        {
            var listDealer = _entity.Dealer.Select(x => x.DealerName).ToList<string>();
            listDealer.Sort();
            return listDealer;
        }
        public List<string> GetListDealerByCity(string cityName)
        {
            var listDealer = _entity.Dealer.Where(x => x.City.Trim() == cityName.Trim()).Select(c => c.DealerName.Trim()).ToList();
            listDealer.Sort();
            return listDealer;
        }
    }
}
