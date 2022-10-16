using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Posts Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Post Title")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Content")]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Mark record as deleted")]
       
        public bool IsDeleted { get; set; } = false;
    }
}
