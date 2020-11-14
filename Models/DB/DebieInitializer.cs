using System.Linq;

namespace Debie.Models.DB {
    public static class DebieInitializer {
        public static void Initialize(DebieContext context) {
            context.Database.EnsureCreated();

            if (context.Users.Any()) {
                return;
            }

            var users = new User[] {
                new User { ID = 0, Name = "Bruhinski", Password = "SuperTajneHeslo" }
            };

            foreach (var u in users) {
                context.Users.Add(u);
            }

            context.SaveChanges();
        }
    }
}