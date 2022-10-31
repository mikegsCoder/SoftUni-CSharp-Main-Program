using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "The field is required!")]
        [Range(0.00, 10.00)]
        public string Rating { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();

        public int GenreId { get; set; }
    }
}
