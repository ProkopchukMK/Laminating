using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class DealerDTO
    {
        private static LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddDealer(string dealerName)
        {
            Dealer dealerList = _entity.Dealer.FirstOrDefault(x => x.DealerName == dealerName);
            if (dealerList == null)
            {
                Dealer newDealer = new Dealer();
                newDealer.DealerName = dealerName;
                _entity.AddToDealer(newDealer);
                _entity.SaveChanges();
                return "Дилера " + dealerName + " добавлено!";
            }
            else
            {
                return "Такий дилер в базі вже є!";
            }
        }
        public static List<string> GetListDealer()
        {
            var listDealer = _entity.Dealer.Select(x => x.DealerName.Trim()).ToList<string>();
            listDealer.Sort();
            return listDealer;
        }
    }
}
