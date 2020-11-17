using System.Collections.Generic;
using System.Linq;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class TagRepository : DBRepository<Tag>, ITagRepository {
        public TagRepository(DebieDBContext context) {
            _Context = context;
        }
        public override IEnumerable<Tag> GetAll() {
            return _Context.Tags.ToList();
        }
        public override Tag GetByID(int id) {
            return _Context.Tags.Find(id);
        }
        public override void Insert(Tag tag) {
            _Context.Tags.Add(tag);
        }
        public override void Delete(Tag tag) {
            _Context.Tags.Remove(tag);
        }
        public override void Update(Tag tag) {
            _Context.Update(tag);
        }
    }
}