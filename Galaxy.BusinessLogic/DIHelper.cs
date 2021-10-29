using Hypatia.BusinessLogic.Abstract;
using Hypatia.BusinessLogic.Concrete;
using Hypatia.DataAccess.Abstract;
using Hypatia.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypatia.BusinessLogic
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
