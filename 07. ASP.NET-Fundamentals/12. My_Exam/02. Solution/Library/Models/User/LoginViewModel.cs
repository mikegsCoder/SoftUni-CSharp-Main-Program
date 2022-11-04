using System.ComponentModel.DataAnnotations;

namespace Library.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The field is required!")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "The field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
