using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Store
{
    public class StoreItemsViewModel
    {
        public StoreItemsViewModel()
        {
            Products = new();
        }

        public List<ProductViewModel> Products { get; set; }
    }
}
