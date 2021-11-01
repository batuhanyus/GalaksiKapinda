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

        public int Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee DoLogin(string email, string password)
        {
            //TODO: Encrypt password.
            return employeerepository.GetAll().Where(a => a.Mail == email && a.Password==password).SingleOrDefault();
        }

        public ICollection<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public int Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
