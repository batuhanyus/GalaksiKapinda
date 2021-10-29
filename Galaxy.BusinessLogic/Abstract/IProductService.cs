using Hypatia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.BusinessLogic.Abstract
{
    interface IProductService : IService<Product>
    {
        List<Product> GetProductsByCategory(int categoryID);
    }
}
