using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Profile
{
    public class ProfileMyInfoViewModel
    {
        public int UserID { get; set; }
        public string EMail { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
