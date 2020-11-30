using System.Collections.Generic;

namespace Debie.Models {
    public class Crumb {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Title { get; set; }
        public IDictionary<string, string> Values { get; set; }

        public Crumb(string controller, string action, string title, IDictionary<string, string> values = null) {
            Controller = controller;
            Action = action;
            Title = title;
            Values = values;
        }
    }
}