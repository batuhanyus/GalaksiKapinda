using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities;

namespace Galaxy.Root.Genesis
{
    class ProductWorks
    {
        public void Run(GalaxyDbContext context)
        {
            Category c1 = new Category()
            {
                Name = "Category 1"
            };

            Category c2 = new Category()
            {
                Name = "Category 2"
            };

            Product p1 = new Product()
            {
                CategoryID = 1,
                Category = c1,
                Name = "Product 1",
                Description = "Product 1 Description",
                Price = 5m,
                DiscountedPrice = 4.99m,
                IsActive = true
            };

            Product p2 = new Product()
            {
                CategoryID = 1,
                Category = c1,
                Name = "Product 2",
                Description = "Product 2 Description",
                Price = 15m,
                DiscountedPrice = 14.99m,
                IsActive = true
            };

            Product p3 = new Product()
            {
                CategoryID = 2,
                Category = c2,
                Name = "Product 3",
                Description = "Product 3 Description",
                Price = 100m,
                DiscountedPrice = 99.99m,
                IsActive = true
            };

            context.Categories.Add(c1);
            context.Categories.Add(c2);

            context.Products.Add(p1);
            context.Products.Add(p2);
            context.Products.Add(p3);

            context.SaveChanges();
        }
    }
}
