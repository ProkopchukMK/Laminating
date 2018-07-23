using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laminatsia;

namespace Laminatsia.DTO
{
    public class CityDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public int ID { get; set; }
        public string City { get; set; }
        public CityDTO(){}
        public CityDTO(int id, string city)
        {
            this.ID = id;
            this.City = city;
        } 
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
        public string RemoveCity(string cityName)
        {
            City removecity = _entity.City.FirstOrDefault(x => x.CityDealer == cityName);
            if (removecity == null)
            {
                _entity.DeleteObject(removecity);
                _entity.SaveChanges();
                return "Місто " + removecity + " видалено!";
            }
            else
            {
                return "Такого міста в базі немає!";
            }
        }
        public List<string> GetListCity()
        {
            //List<string> listCity = _entity.City.Select(x => x.CityDealer).ToList();            
            List<string> listCity = new List<string>();
            listCity.Sort();                        
            return listCity;
        }
    }
}
