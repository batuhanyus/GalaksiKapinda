using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Details = new();
        }

        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int PackagerID { get; set; }
        public int DelivererID { get; set; }
        public int AddressID { get; set; }
        public string DelivererName { get; set; }

        public string OrderStatus { get; set; }

        public List<OrderDetails> Details { get; set; }
    }
}
