using ECom_db.Base;
using ECom_db.Base.Auth;
using ECom_db.Context;
using ECom_db.Entities;
using ECom_db.Entities.Identity;
using ECom_db.Repos;
using ECom_db.Repos.AuthRepos;
using Ecom_lib.Base;
using Ecom_lib.Exceptions;
using Ecom_lib.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using ECom_db.Base.Paymants;
using ECom_db.Repos.Paymants;

namespace ECom_db.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionDb(this IServiceCollection services , IConfiguration config) 
        {
            
            services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(config.GetConnectionString("MyCon"),
            sqlOption => 
            {
                sqlOption.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                sqlOption.EnableRetryOnFailure();
            }),
            ServiceLifetime.Scoped);
            services.AddScoped<IGenralRepo<Category>,GenralRepo<Category>>();
            services.AddScoped<IGenralRepo<Product>, GenralRepo<Product>>();
            services.AddScoped(typeof(IAppLogger<>),typeof(SerilogAppAdaptor<>));

            services.AddDefaultIdentity<AppUser>(Option =>
            {
                Option.SignIn.RequireConfirmedPhoneNumber = true;
                Option.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                Option.Password.RequireDigit = true;
                Option.Password.RequireLowercase = true;
                Option.Password.RequireUppercase = true;
                Option.Password.RequireNonAlphanumeric = true;
                Option.Password.RequiredLength = 8;

            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(Option =>
            {
                Option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                Option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Option =>
            {
                Option.SaveToken = true;
                Option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });
            services.AddScoped<IRoleManegment,RoleManagment>();
            services.AddScoped<ITokenManegment, TokenManagement>();
            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<IPaymentMethodsRepo,PaymentMethodsRepo>();
            services.AddScoped<ICart, CartRepo>();

                return services;
        }
        public static IApplicationBuilder AddMiddleWareDb(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExHandlingMiddleware>();
            return app;
        }
    }
            
    
}
