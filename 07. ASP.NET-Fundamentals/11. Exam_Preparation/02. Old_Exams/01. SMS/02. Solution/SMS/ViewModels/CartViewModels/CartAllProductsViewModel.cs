using System.Collections.Generic;

namespace SMS.ViewModels.CartViewModels
{
    public class CartAllProductsViewModel
    {
        public IEnumerable<CartProductViewModel> Products { get; set; }
    }
}
