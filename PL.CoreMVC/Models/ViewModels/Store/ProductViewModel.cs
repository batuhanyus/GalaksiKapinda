using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.CoreMVC.Models.ViewModels.Store
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal FinalPrice { get; set; } //Shows discounted price if applicable.
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
