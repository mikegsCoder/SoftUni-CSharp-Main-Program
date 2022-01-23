using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Users = new HashSet<User>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Range(typeof(decimal), "0.01", " 79228162514264337593543950335")]
        public decimal Size { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
