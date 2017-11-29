using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using WebMvcPrimoTentativo.DataAccess;
using WebMvcPrimoTentativo.Models;
using System.Collections;

namespace WebMvcPrimoTentativo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IRepository<Teacher>, Repository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc((IRouteBuilder routes) =>
            {
                //routes.MapRoute(
                //    name: "specialadmin",
                //    template: "/authentication/login/superuser/secret");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "inverted",
                //    template: "{action=Index}/{controller=Home}/{id?}");
            });

            app.UseMvc(AddRoutes);
        }

        private void AddRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}"
                    );
        }
    }
}
