using Galaxy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Core.DataAccess
{
    public interface IRepository<T>
        where T : BaseEntity, new()
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        T GetByID(int entityID);
        //T GetBy(Func<T, int> expression); TODO: Make it happen.
        ICollection<T> GetAll();
    }
}
