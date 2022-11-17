using Microsoft.EntityFrameworkCore;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.ViewModels.CartViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public CartAllProductsViewModel AddProduct(string productId, string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            var product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            { }

            CartAllProductsViewModel model = new CartAllProductsViewModel()
            {
                Products = user
                .Cart
                .Products
                .Select(p => new CartProductViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                })
            };

            return model;
        }
    }
}
