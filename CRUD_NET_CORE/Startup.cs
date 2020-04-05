using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_CORE_SENA.Models.Business;
using CRUD_NET_CORE.Models.Abstract;
using CRUD_NET_CORE.Models.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CRUD_NET_CORE
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
            services.AddControllersWithViews();
            var conexion = Configuration["ConnectionStrings:conexion_sqlServer"]; //la conexion string que se encuentra en appsettings.json 

            services.AddDbContext<DbContextPrueba>(options =>
            options.UseSqlServer(conexion)); //asignamos la conexion a nuestro DbcontextPrueba
            services.AddScoped<IEmpleadoBusiness, EmpleadoBusiness>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
