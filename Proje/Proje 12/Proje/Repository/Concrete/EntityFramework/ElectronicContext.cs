using Proje.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Repository.Concrete.EntityFramework
{
    public class ElectronicContext:DbContext
    {
        public ElectronicContext(DbContextOptions<ElectronicContext> options):base(options)
        {

        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductAttribute> Attributes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk => new { pk.ProductId, pk.CategoryId });
        }
    }
}
