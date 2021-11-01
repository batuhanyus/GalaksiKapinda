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
    public class EFCreditCardRepository : EFRepositoryBase<Product, GalaxyDbContext>, IProductRepository
    {
        public EFCreditCardRepository(GalaxyDbContext context) : base(context)
        {
        }
    }
}
