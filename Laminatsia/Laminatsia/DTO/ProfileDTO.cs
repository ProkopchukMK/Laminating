using System;
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
                Profile newProfile = new Profile{NameProfile = profileName };
                _entity.Profile.Add(newProfile);
                _entity.SaveChanges();
                return "Профіль " + profileName + " добавлено!";
            }
            else
            {
                return "Такий профіль в базі вже є!";
            }
        }
        public string RemoveProfile(string profileName)
        {
            try
            {
                Profile removeProfile = _entity.Profile.FirstOrDefault(x => x.NameProfile == profileName);
                if (removeProfile != null)
                {
                    _entity.Profile.Remove(removeProfile);
                    _entity.SaveChanges();
                    return "Профіль " + profileName + " видалено!";
                }
                else
                {
                    return "Такого профілю в базі немає!";
                }
            }
            catch
            {
                return "Спочатку потрібно видалити всі замовлення з цим профілем!";
            }
        }
        public List<string> GetListProfile()
        {
            var listProfile = _entity.ViewGetAllProfiles.Select(x => x.NameProfile).ToList<string>();
            return listProfile;
        }
    }
}
