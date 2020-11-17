using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class ProductRepository : DBRepository<Product>, IProductRepository {
        public ProductRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Product> GetAll() {
            return _Context.Products.ToList();
        }
        public override Product GetByID(int id) {
            return _Context.Products.Find(id);
        }
        public override void Insert(Product product) {
            _Context.Products.Add(product);
        }
        public override void Delete(Product product) {
            _Context.Products.Remove(product);
        }
        public override void Update(Product product) {
            _Context.Update(product);
        }
    }
}