using Hypatia.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.Core.DataAccess
{
    //DDD => Domain Driven Design
    // Hexagonal Arch - Onion Arch

    public interface IRepository<T>
        where T : BaseEntity , new()
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        T GetByID(int entityID);

        //T GetBy(Func<T,bool> expression);

        ICollection<T> GetAll();
        //ICollection<T> GetAll(Func<T, bool> expression = null);
    }
}
