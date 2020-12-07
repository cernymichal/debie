using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class CategoryRepository : DBRepository<Category>, ICategoryRepository {
        public CategoryRepository(DebieDBContext context) {
            _Context = context;
        }
        public override List<Category> GetAll() {
            return _Context.Categories.ToList();
        }
        public override Category GetByID(params object[] keys) {
            return _Context.Categories.Find(keys);
        }
        public override void Insert(Category category) {
            _Context.Categories.Add(category);
        }
        public override void Delete(Category category) {
            _Context.Categories.Remove(category);
        }
        public override void Update(Category category) {
            _Context.Categories.Update(category);
        }
    }
}