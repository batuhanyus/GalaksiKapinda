using Galaxy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int categoryID);
    }
}
