using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Model
{
    public sealed class Order: BaseEntity
    {
        public Order()
        {
            OrderContents = new();
        }

        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int PackagerID { get; set; }
        public int DelivererID { get; set; }

        //Contents
        public Dictionary<Product, int> OrderContents { get; set; } //TODO: This may change according to DB.
                                                                    //Maybe we even don't need to hold it in db.
                                                                    //Another thing to consider is implementing a seperate
                                                                    //OrderDetails table to track the information, same as NORTHWND.

        //Status
        public string OrderStatus { get; set; }
    }
}
