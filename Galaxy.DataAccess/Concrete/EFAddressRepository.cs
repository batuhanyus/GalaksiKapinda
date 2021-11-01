using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.DataAccess.EF;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;
using Galaxy.Entities.Location;

namespace Galaxy.DataAccess.Concrete
{
    public class EFAddressRepository : EFRepositoryBase<Address, GalaxyDbContext>, IAddressRepository
    {
        public EFAddressRepository(GalaxyDbContext context) : base(context)
        {
        }
    }
}
