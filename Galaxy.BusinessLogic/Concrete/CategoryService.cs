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
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }

        public int Delete(Category entity)
        {
            return categoryRepository.Delete(entity);
        }

        public ICollection<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetByID(int entityID)
        {
            return categoryRepository.GetByID(entityID);
        }

        public int Insert(Category entity)
        {
            //try
            //{
            //    if (entity.Name == null)
            //    {
            //        throw new NotNullNameException("Ad boş geçilemez");
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return categoryRepository.Insert(entity);
        }

        public int Update(Category oldEntity, Category newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
