using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CreditCard
    {
        public int CreditCardID { get; set; }
        public int UserID { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireDate { get; set; } //TODO: Maybe a better solution for AA/YY
        public short CVC { get; set; }
        public string CardHolderName { get; set; }
    }
}
