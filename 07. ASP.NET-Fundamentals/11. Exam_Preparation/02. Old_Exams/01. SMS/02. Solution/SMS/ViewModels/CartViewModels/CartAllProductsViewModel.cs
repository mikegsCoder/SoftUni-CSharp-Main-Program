using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModels.CartViewModels
{
    public class CartAllProductsViewModel
    {
        public IEnumerable<CartProductViewModel> Products { get; set; }
    }
}
