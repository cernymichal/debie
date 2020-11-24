using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services {
    public class DebieDBContext : DbContext {
        public DebieDBContext(DbContextOptions<DebieDBContext> options)
            : base(options) {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProducts");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImages");
            modelBuilder.Entity<Size>().ToTable("Sizes");
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            modelBuilder.Entity<Size>()
                .HasKey(s => new { s.ProductID, s.Label });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Article>()
                .HasOne(a => a.User)
                .WithMany(u => u.Articles);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Image)
                .WithOne()
                .HasForeignKey<Article>(a => a.ImageID);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Tags)
                .WithMany(t => t.Articles);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products);

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey("ProductID");

            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Image)
                .WithOne();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.MainProductImage);
        }
    }
}