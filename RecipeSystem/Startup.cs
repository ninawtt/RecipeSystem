using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // to the static files inside wwwroot folder
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                // default, when run the application for the first time
                // The site route (domain) ex: http://google.com
                routes.MapRoute(
                   name: null,
                   template: "",
                   defaults: new { controller = "Home", action = "Index"}
                   );

                // ViewRecipe Route URL
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/Recipe{recipeID:int}",
                    defaults: new { controller = "Home", action = "ViewRecipe"}
                    );

                // regular route mechanism
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            app.UseMvcWithDefaultRoute();

        }
    }
}
