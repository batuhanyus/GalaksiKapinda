using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities.UserTypes;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface IEmployeeService : IService<Employee>
    {
        Employee DoLogin(string email, string password);
    }
}
