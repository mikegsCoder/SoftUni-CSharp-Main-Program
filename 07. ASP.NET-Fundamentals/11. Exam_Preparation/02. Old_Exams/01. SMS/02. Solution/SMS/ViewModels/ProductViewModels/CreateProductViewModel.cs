using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
