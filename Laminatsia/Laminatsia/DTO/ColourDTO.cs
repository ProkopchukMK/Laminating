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
                ColourProfile newColour = new ColourProfile();
                newColour.Colour = colourName;
                _entity.AddToColourProfile(newColour);
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
            ColourProfile removeColour = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colourName);
            if (removeColour != null)
            {
                _entity.DeleteObject(removeColour);
                _entity.SaveChanges();
                return "Колір " + colourName + " видалено!";
            }
            else
            {
                return "Такого кольору в базі немає!";
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
