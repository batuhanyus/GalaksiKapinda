using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
	public class CategoryBLL : IService<Category>
	{
		IRepository<Category> categoryRepository;

		public CategoryBLL(IRepository<Category> repository)
		{
			categoryRepository = repository;
		}

		public void Add(Category entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Category entity)
		{
			throw new NotImplementedException();
		}

		public Category GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Category> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(Category entity)
		{
			throw new NotImplementedException();
		}
	}
}
