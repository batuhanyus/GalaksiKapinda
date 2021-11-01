using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities.Location;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Profile
{
    public class ProfileAddressViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public int CountyID { get; set; }
        public string AdressDetails { get; set; }
        public string AdressNotes { get; set; }
    }
}
