using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    public class ImageController : Controller {
        private readonly IImageRepository _ImageRepo;
        public const int CacheAgeSeconds = 60 * 60 * 24 * 7; // 7 days

        public ImageController(IImageRepository imageRepo) {
            _ImageRepo = imageRepo;
        }

        public IActionResult Get(int id) {
            var image = _ImageRepo.GetByID(id);

            if (image == null)
                return NotFound();

            Response.Headers["Cache-Control"] = $"public,max-age={CacheAgeSeconds}";

            return File(image.Data, image.ContentType);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
