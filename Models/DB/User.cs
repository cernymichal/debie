using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Debie.Models.DB {
    public class User {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(256), Required]
        public string Username { get; set; }
        [MaxLength(256), Required]
        public byte[] Password { get; set; }
        [Required]
        public DateTime LastChanged { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Article> Articles { get; set; }
    }
}