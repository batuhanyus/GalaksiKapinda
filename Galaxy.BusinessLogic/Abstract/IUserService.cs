using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface IUserService : IService<User>
    {
        User DoLogin(string email, string password);
        bool CheckPassword(string password);
    }
}
