﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities;
using Galaxy.Entities.Location;
namespace Galaxy.BusinessLogic.Abstract
{
    public interface IOrderService : IService<Order> 
    {
        ICollection<Order> GetOrdersByUser(int userID);
        ICollection<Order> GetOrdersByDelivererID(int userID);
    }
}
