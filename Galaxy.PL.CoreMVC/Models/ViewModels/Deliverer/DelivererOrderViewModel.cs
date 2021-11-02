using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Deliverer
{
    public class DelivererOrderViewModel
    {
        public DelivererOrderViewModel()
        {
            Details = new();
        }

        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int PackagerID { get; set; }
        public int DelivererID { get; set; }
        public int CityID { get; set; }
        public int CountyID { get; set; }
        

        public string OrderStatus { get; set; }

        public List<OrderDetails> Details { get; set; }
        public List<SelectListItem> Deliverers { get; set; }
        public List<SelectListItem> OrderStatuses { get; set; }
    }
}
