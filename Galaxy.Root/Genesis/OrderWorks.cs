using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities;

namespace Galaxy.Root.Genesis
{
    class OrderWorks
    {
        internal void Run(GalaxyDbContext context)
        {
            Order o1 = new();
            o1.MemberID = 1;
            o1.City = context.Cities.First();
            o1.County = context.Counties.First();
            o1.DelivererID = 3;
            o1.PackagerID = 2;
            o1.OrderStatus = "Preparing";

            OrderDetails od1 = new();
            od1.OrderID = 1;
            od1.ProductID = 1;
            od1.Quantity = 5;
            od1.Price = 5m;
            od1.DiscountAmount = 0;

            OrderDetails od2 = new();
            od2.OrderID = 1;
            od2.ProductID = 2;
            od2.Quantity = 1;
            od2.Price = 15m;
            od2.DiscountAmount = 0;

            context.Orders.Add(o1);
            context.SaveChanges();

            context.OrderDetails.Add(od1);
            context.SaveChanges();
            context.OrderDetails.Add(od2);
            context.SaveChanges();
        }
    }
}
