using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.BusinessLogic.Concrete
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }

        public int Delete(Product entity)
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

        public IEnumerable<Product> GetProductsByCategory(int categoryID)
        {
            return productRepository.GetAll().Where(a => a.CategoryID == categoryID).ToList();
        }

        public int Insert(Product entity)
        {
            return productRepository.Insert(entity);
        }

        public int Update(Product oldEntity, Product newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
