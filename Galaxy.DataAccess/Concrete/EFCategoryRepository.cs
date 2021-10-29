using Hypatia.Core.DataAccess;
using Hypatia.DataAccess.Abstract;
using Hypatia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.DataAccess.Concrete
{
    public class EFCategoryRepository : EFRepositoryBase<Category,HypatiaDbContext> ,ICategoryRepository
    {
    }
}
