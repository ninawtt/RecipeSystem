using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSystem.Models
{
    // a class allows us to connect to the database
    // each database needs its own context(ApplicationDbContext)
    // this class is a bridging class connecting EFProductRepository and EntityFramework which connects the database
    // EFProductRepository <-> ApplicationDbContext <-> EntityFramework <-> Database
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { } // calling DbContext's constructor (Parent's constructor)
        
        public DbSet<Recipe> Recipes { get; set; } // the name of table: Recipes

        public DbSet<Image> Images { get; set; } // the name of table: Images

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Images);
            //modelBuilder.Entity<Recipe>()
            //    .HasMany(r => r.Images)
            //    .WithOne();

        }
    }
}
