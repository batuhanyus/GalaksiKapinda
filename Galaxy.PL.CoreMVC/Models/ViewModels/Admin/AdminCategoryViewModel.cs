using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Admin
{
    public class AdminCategoryViewModel
    {
        public int CategoryID { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
