using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities.UserTypes;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface IMemberService : IService<Member>
    {
        Member DoLogin(string email, string password);
        bool CheckPassword(string password);
        BaseUser GetBaseUser(int userID);
    }
}
