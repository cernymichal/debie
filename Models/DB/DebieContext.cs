using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Debie.Models.DB {
    public class DebieContext : DbContext {
        public DebieContext(DbContextOptions<DebieContext> options)
            : base(options) {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProducts");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImages");
            modelBuilder.Entity<Size>().ToTable("Sizes");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            modelBuilder.Entity<ProductImage>()
                .HasKey(pi => new { pi.ProductID, pi.ImageID });

            modelBuilder.Entity<Size>()
                .HasKey(s => new { s.ProductID, s.Label });

            modelBuilder.Entity<Article>()
                .HasOne(a => a.User)
                .WithMany(u => u.Articles);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Image)
                .WithOne()
                .HasForeignKey<Article>(a => a.ImageID);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.BillingAddress)
                .WithOne()
                .HasForeignKey<Order>(o => o.BillingAddressID);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithOne(a => a.Order)
                .HasForeignKey<Order>(o => o.ShippingAddressID);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Image)
                .WithOne();
        }
    }
}