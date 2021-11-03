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
            //Validation
            if (entity.OrderID == 0)
                return 0;
            if (entity.ProductID == 0)
                return 0;
            if (entity.Quantity == 0)
                return 0;

            return orderDetailsRepository.Insert(entity);
        }

        public int Update(OrderDetails oldEntity, OrderDetails newEntity)
        {
            //Validation
            if (newEntity.OrderID == 0)
                return 0;
            if (newEntity.ProductID == 0)
                return 0;
            if (newEntity.Quantity == 0)
                return 0;

            throw new NotImplementedException();
        }
    }
}
