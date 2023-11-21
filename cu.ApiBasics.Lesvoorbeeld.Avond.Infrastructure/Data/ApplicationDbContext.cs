using cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data.Seeding;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder.Seed(modelBuilder);
            modelBuilder.Entity<Product>().Property(p => p.Price)
                .HasColumnType("money");
            base.OnModelCreating(modelBuilder);
        }
    }
}
