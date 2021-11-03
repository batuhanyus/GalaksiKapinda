using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Packager
{
    public class PackagerOrderViewModel
    {
        public PackagerOrderViewModel()
        {
            Details = new();
        }

        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int PackagerID { get; set; }
        public int DelivererID { get; set; }
        public int AddressID { get; set; }

        public string OrderStatus { get; set; }

        public List<OrderDetails> Details { get; set; }
        public List<SelectListItem> Deliverers { get; set; }
        public List<SelectListItem> OrderStatuses { get; set; }
    }
}
