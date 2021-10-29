using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Store
{
    public class StoreMainViewModel
    {
        public StoreMainViewModel()
        {
            StoreCategoriesViewModel = new();
            StoreItemsViewModel = new();
        }

        public decimal CartTotal { get; set; }

        public StoreCategoriesViewModel StoreCategoriesViewModel { get; set; }
        public StoreItemsViewModel StoreItemsViewModel { get; set; }
    }
}
