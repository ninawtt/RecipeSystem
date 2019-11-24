using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        // ensure the database is populated with data
        // the parameter will be sent from the startup (we call this method in startup)
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // create the user
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            // create the admin user; to find if the adminUser exists or not
            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            // create user, update user, delete user, find user are all async 
            // when we use async, we need to use await keyword
            // if we use async inside a method, the method should also be async

            // if the user is not exist
            if (user == null)
            {
                user = new IdentityUser(adminUser);
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
