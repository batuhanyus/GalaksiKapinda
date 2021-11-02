using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Concrete
{
    public class OrderDetailsService : IOrderDetailsService
    {
        IOrderDetailsRepository orderDetailsRepository;

        public OrderDetailsService(IOrderDetailsRepository repository)
        {
            orderDetailsRepository = repository;
        }

        public int Delete(OrderDetails entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderDetails> GetOrderDetailsByOrderID(int orderID)
        {
            return orderDetailsRepository.GetAll().Where(a => a.OrderID == orderID).ToList();
        }

        public int Insert(OrderDetails entity)
        {
            return orderDetailsRepository.Insert(entity);
        }

        public int Update(OrderDetails oldEntity, OrderDetails newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
