using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.Core.Entity
{
    public abstract class BaseEntity /*BaseEntity<T>*/
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
