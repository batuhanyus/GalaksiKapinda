using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;
using Galaxy.Entities.Location;

namespace Galaxy.Entities
{
    public sealed class Order: BaseEntity
    {
        public int MemberID { get; set; }
        public int PackagerID { get; set; }
        public int DelivererID { get; set; }
        public int AddressID { get; set; }

        public string OrderStatus { get; set; }
    }
}
