using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    public class AppIdentityDbContext : IdentityDbContext
    {
        // Constructor
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { } // calling IdentityDbContext's constructor (Parent's constructor)
    }
}
