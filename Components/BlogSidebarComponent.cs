using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models;

namespace Debie.Components {
    public class BlogSidebarComponent : ViewComponent {
        private readonly ITagRepository _TagRepo;
        public BlogSidebarComponent(ITagRepository tagRepo) {
            _TagRepo = tagRepo;
        }
        public IViewComponentResult Invoke(ArticleSearch search) {
            ViewBag.Tags = _TagRepo.GetAll();

            return View(search);
        }
    }
}