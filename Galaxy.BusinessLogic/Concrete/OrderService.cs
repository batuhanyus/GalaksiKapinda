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
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;

        public OrderService(IOrderRepository repository)
        {
            orderRepository = repository;
        }

        public int Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrdersByUser(int userID)
        {
            return orderRepository.GetAll().Where(a => a.MemberID == userID).ToList();
        }

        public int Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
