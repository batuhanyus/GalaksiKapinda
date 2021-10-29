using Hypatia.BusinessLogic.Abstract;
using Hypatia.DataAccess.Abstract;
using Hypatia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.BusinessLogic.Concrete
{
    class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }

        public bool Delete(Product entity)
        {
            return productRepository.Delete(entity);
        }

        public ICollection<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetByID(int entityID)
        {
            return productRepository.GetByID(entityID);
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            return productRepository.GetAll().Where(a => a.CategoryID == categoryID).ToList();
        }

        public bool Insert(Product entity)
        {
            return productRepository.Insert(entity);
        }

        public bool Update(Product entity)
        {
            return productRepository.Update(entity);
        }
    }
}
