using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public sealed class Member : User
    {
        public bool IsMailVerified { get; set; }
    }
}
