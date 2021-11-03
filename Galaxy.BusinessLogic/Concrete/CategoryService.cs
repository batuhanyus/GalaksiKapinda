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
            if (categoryRepository.GetAll().Where(a => a.Name == entity.Name && a.IsActive).ToList().Count > 0)
                return 0;
            if (entity.Name == null || entity.Name == string.Empty)
                return 0;


            return categoryRepository.Insert(entity);
        }

        public int Update(Category oldEntity, Category newEntity)
        {
            if (categoryRepository.GetAll().Where(a => a.Name == newEntity.Name && a.IsActive).ToList().Count > 0)
                return 0;
            if (newEntity.Name == null || newEntity.Name == string.Empty)
                return 0;

            return categoryRepository.Update(oldEntity, newEntity);
        }
    }
}
