using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class AddPostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "The field is required!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The field {0} must be between {2} and {1} symbols.")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "The field is required!")]
        [StringLength(1500, MinimumLength = 30, ErrorMessage = "The field {0} must be between {2} and {1} symbols.")]
        public string Content { get; set; }
    }
}
