using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Entities.UserTypes
{
    public class BaseEmployee : BaseUser
    {
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
    }
}
