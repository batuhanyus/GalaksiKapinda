using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.BusinessLogic
{
    public static class DIHelper
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
