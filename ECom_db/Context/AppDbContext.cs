using ECom_db.Entities;
using ECom_db.Entities.Identity;
using ECom_db.Entities.Payment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "7834acea-66dc-4e5c-8531-1bcaf27509e7",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "a6cd60e6-f32c-4906-9d6f-98e7fa8396b5",
                    Name = "User",
                    NormalizedName = "USER"
                });


            builder.Entity<PaymentMethod>()
                .HasData(
                new PaymentMethod
                {
                    Id = Guid.Parse("8407dbca-85ad-4a6d-be75-5e2d3c877f21"),
                    Name = "Cash",
                },
                new PaymentMethod
                {
                    Id = Guid.Parse("0b8bc078-de4f-4430-9614-ab6237a83e62"),
                    Name = "Visa Card"
                });
        }

    }


        
}
