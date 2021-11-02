using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Galaxy.Entities.UserTypes;

namespace Galaxy.BusinessLogic.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeerepository;

        public EmployeeService(IEmployeeRepository repository)
        {
            employeerepository = repository;
        }

        public bool CheckPassword(string password)
        {
            throw new NotImplementedException();
        }

        public int Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee DoLogin(string email, string password)
        {
            //TODO: Encrypt password.
            return employeerepository.GetAll().Where(a => a.Mail == email && a.Password == password).SingleOrDefault();
        }

        public ICollection<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseUser GetBaseUser(int userID)
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int entityID)
        {
            return employeerepository.GetByID(entityID);
        }

        public int Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Update(BaseUser oldEntity, BaseUser newEntity)
        {
            Employee old = GetByID(oldEntity.ID);
            Employee young = GetByID(oldEntity.ID);

            young.IsPasswordValid = true;
            young.Password = newEntity.Password;
            young.Name = newEntity.Name;
            young.Surname = newEntity.Surname;

            return employeerepository.Update(old, young);
        }

        public int Update(Employee oldEntity, Employee newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
