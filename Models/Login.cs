using System.ComponentModel.DataAnnotations;

namespace Debie.Models {
    public class Login {
        [Required, MaxLength(256)]
        public string Username { get; set; }
        [Required, MaxLength(256)]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
