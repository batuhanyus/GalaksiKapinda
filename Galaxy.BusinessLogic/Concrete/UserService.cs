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
    public class UserService : IUserService
    {
        IUserRepository userrepository;

        public UserService(IUserRepository repository)
        {
            userrepository = repository;
        }

        public bool CheckPassword(string password)
        {
            throw new NotImplementedException();
        }

        public int Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User DoLogin(string email, string password)
        {
            //TODO: Encrypt password.
            return userrepository.GetAll().Where(a => a.Mail == email && a.Password == password).SingleOrDefault();
        }

        public ICollection<User> GetAll()
        {
            return userrepository.GetAll().ToList();
        }

        public ICollection<User> GetAllDeliverers()
        {
            return userrepository.GetAll().Where(a => a.UserType == 1).ToList();
        }

        public User GetByID(int entityID)
        {
            return userrepository.GetAll().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public int Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public int Update(User oldEntity, User newEntity)
{
            return userrepository.Update(oldEntity, newEntity);
        }
    }
}
