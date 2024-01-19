using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityService.Model;
using DBContext.Base;
using Microsoft.EntityFrameworkCore.Storage;
using DBContext.FluentAPI;

namespace DBContext
{
    public class ProductMSWriteAPIContext : DbContext, IUnitOfWork
    {
        public ProductMSWriteAPIContext(DbContextOptions<ProductMSWriteAPIContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public IDbContextTransaction GetTransaction()
        {
            return this.Database.BeginTransaction();
        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<ProductImage> ProductsImages { get; set; } = default!;
        public DbSet<Text> Texts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BRAND
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            //CATEGORY
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //IMAGE
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            //PRODUCT
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //TEXT
            modelBuilder.ApplyConfiguration(new TextConfiguration());

        }
    }
}
    
