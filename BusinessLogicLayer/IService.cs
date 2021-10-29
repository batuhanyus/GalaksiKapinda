using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
	public interface IService<T>
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetByID(int id);
		List<T> GetAll();
	}
}
