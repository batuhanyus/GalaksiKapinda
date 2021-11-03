using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities
{
    public sealed class CreditCard : BaseEntity
    {
        public int MemberID { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpireDate { get; set; } 
        public short CVC { get; set; }
        public string CardHolderName { get; set; }
    }
}
