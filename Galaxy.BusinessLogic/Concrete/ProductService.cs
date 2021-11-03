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
            throw new NotImplementedException();
        }

        public ICollection<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetByID(int entityID)
        {
            try
            {
                return productRepository.GetByID(entityID);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryID)
        {
            return productRepository.GetAll().Where(a => a.CategoryID == categoryID).ToList();
        }

        public int Insert(Product entity)
        {
            //Validation
            if (productRepository.GetAll().Where(a => a.Name == entity.Name && a.IsActive).ToList().Count > 0)
                return 0;
            if (entity.CategoryID == 0)
                return 0;
            if (entity.Name == null || entity.Name == string.Empty)
                return 0;

            try
            {
                return productRepository.Insert(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Product oldEntity, Product newEntity)
        {
            //Validation
            if (productRepository.GetAll().Where(a => a.Name == newEntity.Name && a.IsActive).ToList().Count > 0)
                return 0;
            if (newEntity.CategoryID == 0)
                return 0;


            try
            {
                return productRepository.Update(oldEntity, newEntity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
