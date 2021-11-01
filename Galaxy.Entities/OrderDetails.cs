using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities
{
    public sealed class OrderDetails : BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
