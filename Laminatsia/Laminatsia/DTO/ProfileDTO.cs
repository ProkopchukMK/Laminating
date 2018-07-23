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
                _entity.AddToProfile(newProfile);
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
            Profile removeProfile = _entity.Profile.FirstOrDefault(x => x.NameProfile == profileName);
            if (removeProfile != null)
            {
                _entity.DeleteObject(removeProfile);
                _entity.SaveChanges();
                return "Профіль " + profileName + " видалено!";
            }
            else
            {
                return "Такого профілю в базі немає!";
            }
        }
        public List<string> GetListProfile()
        {
            //List<string> listProfile = _entity.Profile.Select(x => x.NameProfile.Trim()).ToList<string>();
            List<string> listProfile = new List<string>();
            listProfile.Sort();
            return listProfile;
        }
    }
}
