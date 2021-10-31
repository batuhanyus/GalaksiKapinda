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

        //public EFRepositoryBase(TContext context)
        //{
        //    _context = context;
        //}

        public EFRepositoryBase()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<TContext>(ServiceLifetime.Singleton);
            ServiceProvider provider = services.BuildServiceProvider();
            _context = provider.GetService<TContext>();
            //HypatiaDbContext context = new HypatiaDbContext();
        }

        public bool Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public ICollection<TEntity> GetAll()
        {
            //context.Categories
            //context.Products
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int entityID)
        {
            return _context.Set<TEntity>().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public bool Insert(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            return _context.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
