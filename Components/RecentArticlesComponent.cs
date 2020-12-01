using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models.DB;

namespace Debie.Components {
    public class RecentArticlesComponent : ViewComponent {
        private readonly IArticleRepository _ArticleRepo;
        public RecentArticlesComponent(IArticleRepository articleRepo) {
            _ArticleRepo = articleRepo;
        }
        public IViewComponentResult Invoke(int count) {
            var articles = _ArticleRepo.GetAll().ToList();
            articles.Sort((a1, a2) => a1.Created.CompareTo(a2.Created));

            return View(articles.GetRange(0, count));
        }
    }
}