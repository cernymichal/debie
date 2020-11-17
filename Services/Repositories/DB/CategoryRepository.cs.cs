using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class CategoryRepository : DBRepository<Category>, ICategoryRepository {
        public CategoryRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Category> GetAll() {
            return _Context.Categories.ToList();
        }
        public override Category GetByID(int id) {
            return _Context.Categories.Find(id);
        }
        public override void Insert(Category category) {
            _Context.Categories.Add(category);
        }
        public override void Delete(Category category) {
            _Context.Categories.Remove(category);
        }
        public override void Update(Category category) {
            _Context.Update(category);
        }
    }
}