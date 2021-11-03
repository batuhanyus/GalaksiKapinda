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
        ICollection<User> GetAllDeliverers();
        bool Register(string name, string surname, string email, string password1, string password2);
        User GetByEmail(string email);
    }
}
