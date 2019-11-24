using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeSystem.Models;

namespace RecipeSystem
{
    public class Startup
    {
        // public property, this will store the configuration info from appsettings
        public IConfiguration Configuration { get; } // MVC will create a concrete class to this automatically

        // constructor
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // connecting database to the connection string which we configure in appsettings and already store in Configuration property.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeSystemRecipes:ConnectionString"]));

            // to tell AppIdentityDbContext where our database is 
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeSystemIdentity:ConnectionString"]));

            // add Identity service to our application
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>() // to say where is the data stored
                .AddDefaultTokenProviders();

            services.AddTransient<IRecipeRepository, EFRecipeRepository>();

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
            app.UseAuthentication(); // enable the application to use authenitcation that we configured inside "configureServices"; see AccountController constructor, due to this code, it will pass the parameters into the constructor

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

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
