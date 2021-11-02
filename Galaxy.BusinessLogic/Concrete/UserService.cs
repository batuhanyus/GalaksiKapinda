using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public User GetByEmail(string email)
        {
            return userrepository.GetAll().Where(a => a.Mail == email).SingleOrDefault();
        }

        public User GetByID(int entityID)
        {
            return userrepository.GetAll().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public int Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Register(string name, string surname, string email, string password1, string password2)
        {
            if (name == null || surname == null)
                return false;
            if (password1 != password2)
                return false;
            if (!password1.Any(char.IsUpper))
                return false;
            if (!password1.Any(char.IsNumber))
                return false;
            if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                return false;
            if (userrepository.GetAll().Where(a => a.Mail == email).ToList().Count > 0)
                return false;

            //Seems like fine.
            try
            {
                userrepository.Insert(new User()
                {
                    Mail = email,
                    Name = name,
                    Surname = surname,
                    Password = password1.HashString(),
                    UserType = 0
                });
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public int Update(User oldEntity, User newEntity)
        {
            return userrepository.Update(oldEntity, newEntity);
        }
    }
}
