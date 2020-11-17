using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class ArticleRepository : DBRepository<Article>, IArticleRepository {
        public ArticleRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Article> GetAll() {
            return _Context.Articles.ToList();
        }
        public override Article GetByID(int id) {
            return _Context.Articles.Find(id);
        }
        public override void Insert(Article article) {
            _Context.Articles.Add(article);
        }
        public override void Delete(Article article) {
            _Context.Articles.Remove(article);
        }
        public override void Update(Article article) {
            _Context.Update(article);
        }
    }
}