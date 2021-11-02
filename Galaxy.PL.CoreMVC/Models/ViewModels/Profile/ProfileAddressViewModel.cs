using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities.Location;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Counties { get; set; }

        public int SelectedCityID { get; set; }
        /// <summary>
        /// 0=Add, 1=Edit
        /// </summary>
        public byte OpType { get; set; }
    }
}
