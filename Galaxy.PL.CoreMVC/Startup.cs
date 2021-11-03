using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.BusinessLogic;
using Galaxy.Root;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Galaxy.PL.CoreMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.DoDependencyInjections();

            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.Cookie.Name = "galaxy";
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            //Genesis
            Galaxy.Root.Genesis.Genesis g = new();
            //g.SeedTheGalaxy();

            /*Migration ve Update sonrası oluşan GalaxyDB'yi 42. satırı aktive ederek doldurabilirsiniz.
             * Mail işlemleri için ProtonMail: 
             * oylesineyaratilmishesap@protonmail.com
             * Sifre: OylesinePassword
             * MailGun diye free birşey kullandım. Bazenleri biraz yavaşlayabiliyor. 10 dakikayı bulduğu oldu.
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}");
            });
        }
    }
}