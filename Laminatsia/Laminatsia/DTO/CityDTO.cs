<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laminatsia;

namespace Laminatsia.DTO
{
    public class CityDTO
    {    
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddCity(string cityName)
        {
            City cityList = _entity.City.FirstOrDefault(x => x.CityDealer == cityName);
            if (cityList == null)
            {
                City newCity = new City();
                newCity.CityDealer = cityName;
                _entity.AddToCity(newCity);
                _entity.SaveChanges();
                return "Місто " + cityName + " добавлено!";
            }
            else
            {
                return "Таке місто в базі вже є! Змінна";
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laminatsia;

namespace Laminatsia.DTO
{
    public class CityDTO
    {    
        private static LaminatsiaEntities _entity = new LaminatsiaEntities();

        public string AddCity(string cityName)
        {
            City cityList = _entity.City.FirstOrDefault(x => x.CityDealer == cityName);
            if (cityList == null)
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
        public static List<string> GetListCity()
        {
            var listCity = _entity.City.Select(x => x.CityDealer.Trim()).ToList<string>();
            listCity.Sort();
            return listCity;
        }
    }
}
>>>>>>> 9d0caf3275578d9ead16e53a95c54c406ba8e39c
