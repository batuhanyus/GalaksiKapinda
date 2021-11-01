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
            services.AddScoped<IAddressRepository, EFAddressRepository>();
            services.AddScoped<ICityRepository, EFCityRepository>();
            services.AddScoped<ICountyRepository, EFCountyRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<IOrderDetailsRepository, EFOrderDetailsRepository>();
            services.AddScoped<IMailVerificationRepository, EFMailVerificationRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountyService, CountyService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IMailVerificationService, MailVerificationService>();



            return services;
        }
    }
}
