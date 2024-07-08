using AumentaTestBack.Models;
using Microsoft.EntityFrameworkCore;

namespace AumentaTestBack.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
             
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchasesProducts { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Book", Price = 12.49f, IsTaxesFree = true},
                new Product { Id = 2, Name = "Music CD", Price = 14.99f, IsTaxesFree = false  },
                new Product { Id = 3, Name = "Chocolate bar", Price = 0.85f, IsTaxesFree = true  }
            );

            modelBuilder.Entity<PurchaseProduct>().HasKey(p => new {p.PurchaseId, p.ProductId});
        }
    }
}
