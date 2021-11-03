using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                Name = "Lightsabers",
                IsActive = true,
            };

            Category c2 = new Category()
            {
                Name = "Ships",
                IsActive = true
            };

            Product p1 = new Product()
            {
                CategoryID = 1,
                Name = "Purple Lightsaber",
                Description = "Feel the power of purpie purple then look like Mace Windu.",
                Price = 5m,
                DiscountedPrice = 4.99m,
                IsActive = true,
                ImagePath = "~/Media/Products/purplesaber.png"
            };

            Product p2 = new Product()
            {
                CategoryID = 2,
                Name = "X-Wing",
                Description = "It's better, stronger, danger-er!",
                Price = 15m,
                DiscountedPrice = 14.99m,
                IsActive = true,
                ImagePath = "~/Media/Products/xwing.png"
            };

            Product p3 = new Product()
            {
                CategoryID = 2,
                Name = "TIE Fighter",
                Description = "Valuable salvage -wroom-",
                Price = 100m,
                DiscountedPrice = 99.99m,
                IsActive = true,
                ImagePath = "~/Media/Products/tie.png"
            };

            context.Categories.Add(c1);
            context.SaveChanges();
            context.Categories.Add(c2);
            context.SaveChanges();

            context.Products.Add(p1);
            context.SaveChanges();
            context.Products.Add(p2);
            context.SaveChanges();
            context.Products.Add(p3);
            context.SaveChanges();

        }
    }
}
