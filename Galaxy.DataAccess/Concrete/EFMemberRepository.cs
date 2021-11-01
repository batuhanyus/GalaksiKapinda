using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.DataAccess;
using Galaxy.Core.DataAccess.EF;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities.UserTypes;

namespace Galaxy.DataAccess.Concrete
{
    public class EFMemberRepository : EFRepositoryBase<Member, GalaxyDbContext>, IMemberRepository
    {
        public EFMemberRepository(GalaxyDbContext context) : base(context)
        {
        }
    }
}
