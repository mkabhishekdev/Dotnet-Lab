using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dBContextOptions) : base(dBContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserStock> UserStocks{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Composite primary key: A UserStock row is uniquely identified by BOTH UserId and StockId together.
            builder.Entity<UserStock>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            //UserStock has one AppUser ,An AppUser has many UserStocks, The link is done using AppUserId
            builder.Entity<UserStock>()
              .HasOne(u => u.AppUser)
              .WithMany(u => u.UserStocks)
              .HasForeignKey(p => p.AppUserId);
              
            builder.Entity<UserStock>()
              .HasOne(u => u.Stock)
              .WithMany(u => u.UserStocks)
              .HasForeignKey(p => p.StockId);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "a80d5b19-48cf-41f9-bcf2-edd5dad211c3", 
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "37a2dda2-48b0-46c9-9403-4d3176d96b12", 
                Name = "User",
                NormalizedName = "USER"
            }
            );
        }

    }
}