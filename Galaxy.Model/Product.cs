using Galaxy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Model
{
    public sealed class Product : BaseEntity
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } //TODO: Which type??
        public bool IsActive { get; set; }
    }
}
