using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models.DB;

namespace Debie.Components {
    public class RecentArticlesComponent : ViewComponent {
        private readonly IArticleRepository _ArticleRepo;
        public RecentArticlesComponent(IArticleRepository articleRepo) {
            _ArticleRepo = articleRepo;
        }
        public IViewComponentResult Invoke(int count, bool small = false) {
            var articles = _ArticleRepo.GetAll();
            articles.Sort((a1, a2) => a1.Created.CompareTo(a2.Created));
            articles = articles.GetRange(0, Math.Min(count, articles.Count));

            if (small)
                return View("Small", articles);

            return View(articles);
        }
    }
}