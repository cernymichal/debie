using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Debie.Models.DB {
    public class Feedback {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required, MaxLength(256)]
        public string Email { get; set; }
        [MaxLength(256)]
        public string Subject { get; set; }
        [MaxLength(4096)]
        public string Message { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public bool Search(string query) {
            return
                query is null ||
                Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Email.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                Subject.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}