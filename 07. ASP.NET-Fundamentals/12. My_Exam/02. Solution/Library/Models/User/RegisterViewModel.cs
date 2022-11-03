using System.ComponentModel.DataAnnotations;

namespace Library.Models.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The field {0} must be between {2} and {1} characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
