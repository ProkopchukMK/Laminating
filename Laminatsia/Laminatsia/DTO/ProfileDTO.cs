﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
   public class ProfileDTO
    {
        private LaminatsiaEntities _entity = new LaminatsiaEntities();
        public string AddProfile(string profileName)
        {
            Profile profileList = _entity.Profile.FirstOrDefault(x => x.NameProfile == profileName);
            if (profileList == null)
            {
                Profile newProfile = new Profile();
                newProfile.NameProfile = profileName;
                _entity.AddToProfile(newProfile);
                _entity.SaveChanges();
                return "Профіль " + profileName + " добавлено!";
            }
            else
            {
                return "Такий профіль в базі вже є!";
            }
        }
    }
}
