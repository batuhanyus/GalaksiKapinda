using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities.Location
{
    public sealed class County : BaseEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
    }
}
