using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
                (new Category[] {
                    new Category { Id = 1,Name = "Laptops" },
                    new Category { Id = 2,Name = "PC's" },
                    new Category { Id = 3,Name = "Phones" }
                });
            modelBuilder.Entity<Property>().HasData(
                new Property[] { 
                    new Property { Id = 1, Name = "Basic"},
                    new Property { Id = 2, Name = "Luxury"},
                    new Property { Id = 3, Name = "Student"},
                    new Property { Id = 4, Name = "Family"},
                    new Property { Id = 5, Name = "Office"}
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product[] { 
                    new Product { Id = 1,Name="Samsung L7",Price=456.23M,CategoryId=3,Image="phone.jpg"},
                    new Product { Id = 2,Name="Redmi Note7",Price=325.13M,CategoryId=3,Image="phone.jpg"},
                    new Product { Id = 3,Name="Dell Latitude",Price=1456.23M,CategoryId=1,Image="laptop.jpg"},
                    new Product { Id = 4,Name="Dell Desktop",Price=856.3M,CategoryId=2, Image="laptop.jpg"},
                    new Product { Id = 5,Name="IBook 7",Price=2456.00M,CategoryId=1, Image = "laptop.jpg"},
                    new Product { Id = 6,Name="Ipad12",Price=958.23M,CategoryId=3,Image="tablet.jpg"},
                }
                );
            modelBuilder.Entity($"{nameof(Product)}{nameof(Property)}").HasData
                (
                    new [] { 
                        new {ProductsId=1,PropertiesId=1},
                        new {ProductsId=1,PropertiesId=2},
                        new {ProductsId=1,PropertiesId=3},
                        new {ProductsId=2,PropertiesId=1},
                        new {ProductsId=2,PropertiesId=2},
                        new {ProductsId=2,PropertiesId=3},
                        new {ProductsId=3,PropertiesId=1},
                        new {ProductsId=3,PropertiesId=3},
                        new {ProductsId=4,PropertiesId=1},
                        new {ProductsId=5,PropertiesId=1},
                        new {ProductsId=5,PropertiesId=3},
                        new {ProductsId=6,PropertiesId=1},
                        new {ProductsId=6,PropertiesId=2},
                    }
                );
            //identity seeding
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var admin = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@products.com",
                NormalizedEmail = "ADMIN@PRODUCTS.COM",
                Email = "admin@products.com",
                NormalizedUserName = "ADMIN@PRODUCTS.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Firstname = "Bart",
                Lastname = "Soete",
                DateOfBirth = DateTime.Parse("25/12/1972"),
            };
            var user = new ApplicationUser
            {
                Id = "2",
                UserName = "user@products.com",
                NormalizedEmail = "USER@PRODUCTS.COM",
                Email = "user@products.com",
                NormalizedUserName = "USER@PRODUCTS.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Firstname = "Mileto",
                Lastname = "Di Marco",
                DateOfBirth = DateTime.Parse("25/12/2010"),
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Test123");
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123");
            //seed the roles as claims and add to users
            var userClaims = new IdentityUserClaim<string>[]
            {
                new IdentityUserClaim<string>{Id = 1,UserId = "1",ClaimType = ClaimTypes.Role,ClaimValue = "Admin" },
                new IdentityUserClaim<string>{Id = 2,UserId = "2",ClaimType = ClaimTypes.Role,ClaimValue = "User" },
            };
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
            modelBuilder.Entity<ApplicationUser>().HasData( new ApplicationUser[] { admin, user } );
        }
    }
}
