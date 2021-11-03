using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Entities;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Profile
{
    public class ProfileCreditCardViewModel
    {
        public int ID { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public short CVC { get; set; }
        public string CardHolderName { get; set; }
    }
}
