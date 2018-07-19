﻿using System;
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
    }
}
