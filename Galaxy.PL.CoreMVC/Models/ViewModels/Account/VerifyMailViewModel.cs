using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Account
{
    public class VerifyMailViewModel
    {
        public string EMail { get; set; }
        public string Code { get; set; }
    }
}
