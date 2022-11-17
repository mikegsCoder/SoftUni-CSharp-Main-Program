using SMS.Data.Models;
using SMS.ViewModels.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.CartService
{
    public interface ICartService
    {
        CartAllProductsViewModel AddProduct(string productId, string userId);
    }
}
