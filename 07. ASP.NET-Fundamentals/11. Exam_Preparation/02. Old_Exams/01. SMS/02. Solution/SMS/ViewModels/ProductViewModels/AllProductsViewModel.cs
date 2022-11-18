using System.Collections.Generic;

namespace SMS.ViewModels.ProductViewModels
{
    public class AllProductsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
