using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class Employee : User
    {
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
    }
}
