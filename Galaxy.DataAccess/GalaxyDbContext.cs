using Galaxy.Entities;
using Galaxy.Entities.Location;
using Galaxy.Entities.UserTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.DataAccess
{
    public class GalaxyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Member> Members { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<MailVerification> MailVerifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GalaxyDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A helping class to implement data-associated ruled.
            new DbRules().ImplementDataRules(ref modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
