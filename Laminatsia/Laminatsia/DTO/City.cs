using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laminatsia;

namespace Laminatsia.DTO
{
    public class CityDTO
    {
        public int ID { get; private set; }
        public string CityName { get; set; }

        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddCity(string cityName)
        {
            List<string> cityList = _entity.City.Select(x => x.CityDealer).ToList();
            if (!cityList.Contains(cityName))
            {
                City newCity = new City();
                newCity.CityDealer = cityName;
                _entity.AddToCity(newCity);
                _entity.SaveChanges();
                return "Місто " + cityName + " добавлено!";
            }
            else
            {
                return "Таке місто в базі вже є!";
            }

        }
    }
}
