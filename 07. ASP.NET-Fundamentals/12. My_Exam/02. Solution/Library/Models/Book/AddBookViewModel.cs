using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Book
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string Author { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [Range(0.00, 10.00)]
        public string Rating { get; set; } = null!;

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int CategoryId { get; set; }
    }
}
