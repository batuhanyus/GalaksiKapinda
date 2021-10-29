using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.BusinessLogic
{
    public interface IService<T>
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetByID(int entityID);

        ICollection<T> GetAll();
    }
}
