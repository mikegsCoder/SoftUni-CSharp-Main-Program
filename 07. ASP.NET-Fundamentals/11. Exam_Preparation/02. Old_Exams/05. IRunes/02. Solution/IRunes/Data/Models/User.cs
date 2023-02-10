using System;
using System.ComponentModel.DataAnnotations;

namespace IRunes.Data.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

