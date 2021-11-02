using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Cart
{
    public class CardAddressViewModel
    {
        public int MemberID { get; set; }
        public int AddressID { get; set; }
        public List<SelectListItem> Addresses { get; set; }
    }
}
