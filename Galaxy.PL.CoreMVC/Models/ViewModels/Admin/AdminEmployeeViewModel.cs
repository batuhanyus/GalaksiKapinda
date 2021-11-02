using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Models.ViewModels.Admin
{
    public class AdminEmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        /// <summary>
        /// 0=Member 1=Deliverer, 2=Packager, 3=Admin
        /// </summary>
        public int UserType { get; set; }
        public bool IsMailVerified { get; set; }
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
        public bool IsPasswordValid { get; set; }
    }
}
