using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Profile
{
    public class ProfileMainViewModel
    {
        public string ContentType { get; set; }
        public ProfileMyInfoViewModel MyInfoViewModel { get; set; }
        public List<ProfileOrderViewModel> OrderViewModels { get; set; }
        public List<ProfileAddressViewModel> AddressViewModels { get; set; }
        public List<ProfileCreditCardViewModel> CreditCardViewModels { get; set; }

    }
}
