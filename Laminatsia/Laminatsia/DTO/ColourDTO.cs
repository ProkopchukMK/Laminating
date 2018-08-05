using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class ColourDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddColour(string colourName)
        {
            ColourProfile colourList = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colourName);
            if (colourList == null)
            {
                ColourProfile newColour = new ColourProfile { Colour = colourName };
                _entity.ColourProfile.Add(newColour);
                _entity.SaveChanges();
                return "Колір " + colourName + " добавлено!";
            }
            else
            {
                return "Такий колір в базі вже є!";
            }
        }
        public string RemoveColour(string colourName)
        {
            try
            {
                ColourProfile removeColour = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colourName);
                if (removeColour != null)
                {
                    _entity.ColourProfile.Remove(removeColour);
                    _entity.SaveChanges();
                    return "Колір " + colourName + " видалено!";
                }
                else
                {
                    return "Такого кольору в базі немає!";
                }
            }
            catch
            {
                return "Спочатку потрібно видалити всі замовлення з таким кольором!";
            }
        }
        public List<string> GetListColour()
        {
            var listColour = _entity.ColourProfile.Select(x => x.Colour.Trim()).ToList<string>();
            listColour.Sort();
            return listColour;
        }
    }
}
