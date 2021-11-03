using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.BusinessLogic
{
    public static class ValidationHelper
    {
        public static bool CheckIfPassWordIsOkay(string password)
        {
            if (!password.Any(char.IsUpper))
                return false;
            if (!password.Any(char.IsNumber))
                return false;

            return true;
        }
    }
}
