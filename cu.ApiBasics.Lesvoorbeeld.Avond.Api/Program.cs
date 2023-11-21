using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Repositories;
using cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Data;
using cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Linq;
using System;

namespace Pri.Drinks.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Db service
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDatabase")));
            //register Identityservice
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(
                options =>
                {
                    //only for development/testing purposes
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 4;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedAccount = false;
                }
                )
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //add JWT token authentication
            builder.Services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => options.TokenValidationParameters = new
                TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
                ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigninKey"]))
            });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            //add authorization policies
            builder.Services.AddAuthorization(options =>
            {
                //define policies here
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("User",policy => policy.RequireAssertion(
                    context =>
                    {
                        //perform needed checks
                        //superadmin = User + Admin
                        if (context.User.HasClaim(ClaimTypes.Role, "User")
                        || context.User.HasClaim(ClaimTypes.Role, "Admin")
                        ) 
                        {
                            return true;
                        }
                        return false;
                    }
                    ));
                options.AddPolicy("18+", policy =>
                policy.RequireAssertion(context =>
                {
                    //check the user's birthdate
                    var userBirthDateClaim = context.User
                        .Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.DateOfBirth));
                    if(userBirthDateClaim == null )
                    {
                        return false;
                    }
                    var userBirthDate = DateTime.Parse(userBirthDateClaim.Value);
                    if(DateTime.Now.Year - userBirthDate.Year >= 18)
                        return true;
                    return false;
                }));
            });
            //register the repository service
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            //services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}