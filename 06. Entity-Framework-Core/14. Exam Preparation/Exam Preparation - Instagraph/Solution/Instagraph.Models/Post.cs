using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Instagraph.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Caption { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
