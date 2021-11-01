using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Entities.UserTypes
{
    public sealed class Employee : BaseUser
    {
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
        /// <summary>
        /// 0=Deliverer, 1=Packager, 2=Admin
        /// </summary>
        public int EmployeeType { get; set; } 
    }
}
