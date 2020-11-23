using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class ImageRepository : DBRepository<Image>, IImageRepository {
        public ImageRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Image> GetAll() {
            return _Context.Images.ToList();
        }
        public override Image GetByID(params object[] keys) {
            return _Context.Images.Find(keys);
        }
        public override void Insert(Image image) {
            _Context.Images.Add(image);
        }
        public override void Delete(Image image) {
            _Context.Images.Remove(image);
        }
        public override void Update(Image image) {
            _Context.Images.Update(image);
        }
    }
}