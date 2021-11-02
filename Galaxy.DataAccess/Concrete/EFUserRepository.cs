using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.DataAccess.EF;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;

namespace Galaxy.DataAccess.Concrete
{
    public class EFUserRepository : EFRepositoryBase<User, GalaxyDbContext>, IUserRepository
    {
        public EFUserRepository(GalaxyDbContext context) : base(context)
        {
        }
    }
}
