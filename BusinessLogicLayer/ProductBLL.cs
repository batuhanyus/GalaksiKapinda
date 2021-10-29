using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
	public class ProductBLL : IService<Product>
	{
		IRepository<Product> productRepository;

		public ProductBLL(IRepository<Product> repository)
		{
			productRepository = repository;
		}

		public void Add(Product entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Product entity)
		{
			throw new NotImplementedException();
		}

		public Product GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}
