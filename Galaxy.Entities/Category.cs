using Galaxy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
