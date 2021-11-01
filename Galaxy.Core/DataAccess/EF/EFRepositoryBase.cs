using Galaxy.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Core.DataAccess.EF
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext
    {
        TContext _context;

        public EFRepositoryBase(TContext context)
        {
            _context = context;
        }

        public int Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        
        public TEntity GetByID(int entityID)
        {
            return _context.Set<TEntity>().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public int Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return _context.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
