using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Concrete
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }

        public int Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User DoLogin(string email, string password)
        {
            try
            {
                return userRepository.GetAll().Where(a => a.Mail == email && a.Password == password && a.IsActive).Single();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ICollection<User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }

        public ICollection<User> GetAllDeliverers()
        {
            return userRepository.GetAll().Where(a => a.UserType == 2).ToList();
        }

        public User GetByEmail(string email)
        {
            try
            {
                return userRepository.GetAll().Where(a => a.Mail == email).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetByID(int entityID)
        {
            try
            {
                return userRepository.GetAll().Where(a => a.ID == entityID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(User entity)
        {
            if (entity.Name == null || entity.Surname == null)
                return 0;
            if (entity.Password == null)
                return 0;
            if (!ValidationHelper.CheckIfPassWordIsOkay(entity.Password))
                return 0;
            if (!Regex.IsMatch(entity.Mail, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                return 0;
            if (userRepository.GetAll().Where(a => a.Mail == entity.Mail && a.IsActive == true).ToList().Count > 0)
                return 0;

            //Seems like fine.
            try
            {
                return userRepository.Insert(new User()
                {
                    Mail = entity.Mail,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Password = entity.Password,
                    UserType = entity.UserType,
                    IsActive = true,
                    BirthDate = entity.BirthDate,
                    IsMailVerified = true,
                    Phone = entity.Phone
                });

            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool Register(string name, string surname, string email, string password1, string password2)
        {
            if (name == null || surname == null)
                return false;
            if (password1 != password2)
                return false;
            if (!ValidationHelper.CheckIfPassWordIsOkay(password1))
                return false;
            if (!Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                return false;
            if (userRepository.GetAll().Where(a => a.Mail == email && a.IsActive == true).ToList().Count > 0)
                return false;

            //Seems like fine.
            try
            {
                userRepository.Insert(new User()
                {
                    Mail = email,
                    Name = name,
                    Surname = surname,
                    Password = password1,
                    UserType = 1,
                    IsActive = true,
                    IsMailVerified = false,
                    IsPasswordValid = true
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
            if (newEntity.Name == null || newEntity.Surname == null)
                return 0;
            if (newEntity.Password == null || newEntity.Password == string.Empty)
                return 0;
            if (!ValidationHelper.CheckIfPassWordIsOkay(newEntity.Password))
                return 0;

            try
            {
                return userRepository.Update(oldEntity, newEntity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
