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
    class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }

        public bool Delete(Category entity)
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

        public bool Insert(Category entity)
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

        public bool Update(Category entity)
        {
            return categoryRepository.Update(entity);
        }
    }
}
