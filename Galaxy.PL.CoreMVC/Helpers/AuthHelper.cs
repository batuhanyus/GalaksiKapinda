using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.PL.CoreMVC.Helpers
{
    public static class AuthHelper
    {
        public static bool CanAccess(int userRole,int[] allowedRoles)
        {
            if (allowedRoles.Contains(userRole))
                return true;
            else
                return false;
        }
    }
}
