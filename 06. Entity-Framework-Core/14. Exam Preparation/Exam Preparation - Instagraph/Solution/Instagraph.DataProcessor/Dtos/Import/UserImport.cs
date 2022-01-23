using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor.Dtos.Import
{
    public class UserImport
    {
        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }
}
