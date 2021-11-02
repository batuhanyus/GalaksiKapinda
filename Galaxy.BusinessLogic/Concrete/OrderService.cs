using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
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
            return orderRepository.GetAll().ToList();
        }

        public Order GetByID(int entityID)
        {
            return orderRepository.GetAll().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public ICollection<Order> GetOrdersByUser(int userID)
        {
            return orderRepository.GetAll().Where(a => a.MemberID == userID).ToList();
        }

        public int Insert(Order entity)
        {
            return orderRepository.Insert(entity);
        }

        public int Update(Order oldEntity, Order newEntity)
{
            return orderRepository.Update(oldEntity, newEntity);
        }
    }
}
