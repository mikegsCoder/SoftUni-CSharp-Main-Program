using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength (64)]
        public string Password { get; set; }

        [Required]
        [StringLength(36)]
        public string CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
    }
}
