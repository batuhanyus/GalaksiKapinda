using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.CoreMVC.Models.ViewModels.Store
{
    public class StoreCategoriesViewModel
    {
        public StoreCategoriesViewModel()
        {
            Categories = new();
        }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
