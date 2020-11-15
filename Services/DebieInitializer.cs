using System.Linq;
using Debie.Models.DB;

namespace Debie.Services {
    public static class DebieInitializer {
        public static void Initialize(DebieContext context) {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Products.Any()) {
                return;
            }

            var products = new Product[] {
                new Product { Name = "Product1", Price = 99.99F },
                new Product { Name = "Product2", Price = 49.99F },
                new Product { Name = "Product3", Price = 199.99F },
                new Product { Name = "Product4", Price = 19.99F },
                new Product { Name = "Product5", Price = 29.99F }
            };

            foreach (var u in products) {
                context.Products.Add(u);
            }

            context.SaveChanges();
        }
    }
}