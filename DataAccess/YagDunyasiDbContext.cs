using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class YagDunyasiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=YagDunyasiDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeMark>()
    .HasMany(c => c.Products)
    .WithOne(e => e.TradeMark);

            modelBuilder.Entity<Product>()
    .HasMany(c => c.OrderedProducts)
    .WithOne(e => e.Product);

            modelBuilder.Entity<Order>()
    .HasMany(c => c.OrderedProducts)
    .WithOne(e => e.Order);

            modelBuilder.Entity<User>()
    .HasMany(c => c.Orders)
    .WithOne(e => e.User);

            modelBuilder.Entity<UserStatus>()
    .HasMany(c => c.Users)
    .WithOne(e => e.UserStatus);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<TradeMark> TradeMarks { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
