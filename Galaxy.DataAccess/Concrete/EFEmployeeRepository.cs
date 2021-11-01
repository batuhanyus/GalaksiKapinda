using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.DataAccess.EF;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities.UserTypes;

namespace Galaxy.DataAccess.Concrete
{
    public class EFEmployeeRepository : EFRepositoryBase<Employee, GalaxyDbContext>, IEmployeeRepository
    {
        public EFEmployeeRepository(GalaxyDbContext context) : base(context)
        {
        }
    }
}
