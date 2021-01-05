using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Debie.Models.DB;

namespace Debie.Services.Repositories.DB {
    public class FeedbackRepository : DBRepository<Feedback>, IFeedbackRepository {
        public FeedbackRepository(DebieDBContext context) {
            _Context = context;
        }
        public override List<Feedback> GetAll() {
            return _Context.Feedback.ToList();
        }
        public override Feedback GetByID(params object[] keys) {
            return _Context.Feedback.Find(keys);
        }
        public override void Insert(Feedback feedback) {
            _Context.Feedback.Add(feedback);
        }
        public override void Delete(Feedback feedback) {
            _Context.Feedback.Remove(feedback);
        }
        public override void Update(Feedback feedback) {
            _Context.Feedback.Update(feedback);
        }
    }
}