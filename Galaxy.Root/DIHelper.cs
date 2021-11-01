using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.BusinessLogic.Concrete;
using Galaxy.DataAccess;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Galaxy.Root
{
    public static class DIHelper
    {
        public static IServiceCollection DoDependencyInjections(this IServiceCollection services)
        {
            services.AddDbContext<GalaxyDbContext>(ServiceLifetime.Singleton);

            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICreditCardRepository, EFCreditCardRepository>();
            services.AddScoped<IMemberRepository, EFMemberRepository>();
            services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IEmployeeService, EmployeeService>();



            return services;
        }
    }
}
