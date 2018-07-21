using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laminatsia.DTO
{
    public class ColourGoodsDTO
    {
        LaminatsiaEntities _entity = new LaminatsiaEntities();
        
        //private DateTime dateComing;
        //private string profile;
        //private string city;
        //private string dealer;
        //private string notes;
        //private byte counts;
        //private string colour;
        //private DateTime dateToWork;
        //private bool statusProfile;
        //private DateTime dateReady;
        public void AddColourGoods(DateTime dateComing, string profile, 
            string city, string dealer, string notes,
            byte counts, string colour, DateTime dateToWork, bool statusProfile, DateTime dateReady)
        {
            ColourGoods newColourGoods = new ColourGoods
            {
                DateComming = dateComing.Date,
                Profile = _entity.Profile.FirstOrDefault(x => x.NameProfile == profile),
                Dealer = _entity.Dealer.FirstOrDefault(x => x.DealerName == dealer),
                Notes = notes,
                Counts = counts,
                ColourProfile = _entity.ColourProfile.FirstOrDefault(x => x.Colour == colour),
                DateToWork = dateToWork,
                StatusProfile = statusProfile,
                DateReady = dateReady
            };
            _entity.AddToColourGoods(newColourGoods);
            _entity.SaveChanges();            
        }       
        public DateTime DateComing
        {
            //get { return _entity.ColourGoods.FirstOrDefault(x => x.DateComming == dateComing).DateComming; }
            get;
            set;
        }
        public string Profile
        {
            get;
            set;
        }
        public string City {
            get;
            set;
        }
        public string Dealer {
            get;
            set;
        }
        public string Notes {
            get;
            set;
        }
        public byte Counts {
            get;
            set;
        }
        public string Colour {
            get;
            set;
        }
        public DateTime DateToWork {
            get;
            set;
        }
        public bool StatusProfile {
            get;
            set;
        }
        public DateTime DateReady {
            get;
            set;
        }
        
    }
}
