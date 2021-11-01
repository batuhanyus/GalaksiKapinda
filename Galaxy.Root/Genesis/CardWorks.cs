using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities;

namespace Galaxy.Root.Genesis
{
    class CardWorks
    {
        internal void Run(GalaxyDbContext context)
        {
            CreditCard cc = new();
            cc.CardHolderName = "Marty McFly";
            cc.CardNumber = 1111222233334444;
            cc.CVC = 123;
            cc.ExpireDate = DateTime.Now;
            cc.MemberID = 0;

            context.CreditCards.Add(cc);

            context.SaveChanges();
        }
    }
}
