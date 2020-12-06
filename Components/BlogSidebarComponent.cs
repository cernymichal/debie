using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

using Debie.Services.Repositories;
using Debie.Models.DB;

namespace Debie.Components {
    public class BlogSidebarComponent : ViewComponent {
        private readonly ITagRepository _TagRepo;
        public BlogSidebarComponent(ITagRepository tagRepo) {
            _TagRepo = tagRepo;
        }
        public IViewComponentResult Invoke() {
            return View(_TagRepo.GetAll());
        }
    }
}