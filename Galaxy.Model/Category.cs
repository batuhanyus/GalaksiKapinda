using Galaxy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Model
{
    public class Category : BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
