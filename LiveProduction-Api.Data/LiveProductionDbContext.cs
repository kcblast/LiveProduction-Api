using LiveProduction_Api.Core.Models;
using LiveProduction_Api.Core.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveProduction_Api.Data
{
    public class LiveProductionDbContext : DbContext
    {
        public LiveProductionDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Update> Updated { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Stock> Stocks  { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
            .HasKey(x => new { x.ProductId, x.OrderId });
        }
    }
    
}
