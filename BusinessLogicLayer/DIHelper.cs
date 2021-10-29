using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DIHelper
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Category>, CategoryDAL>();
            services.AddSingleton<IRepository<Product>, ProductDAL>();

            return services;
        }
    }
}
