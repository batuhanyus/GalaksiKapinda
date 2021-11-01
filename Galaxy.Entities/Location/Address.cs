using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities.Location
{
    public sealed class Address : BaseEntity
    {
        public int MemberID { get; set; }
        public City City { get; set; }
        public County County { get; set; }        
        public string AdressDetails { get; set; }
        public string AdressNotes { get; set; }
    }
}
