using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public interface IRepository<T>
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetByID(int id);
		List<T> GetAll();
	}
}
