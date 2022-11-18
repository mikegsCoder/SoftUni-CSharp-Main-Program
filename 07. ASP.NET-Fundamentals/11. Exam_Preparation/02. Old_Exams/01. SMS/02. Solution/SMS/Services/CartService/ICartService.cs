using SMS.ViewModels.CartViewModels;

namespace SMS.Services.CartService
{
    public interface ICartService
    {
        CartAllProductsViewModel AddProduct(string productId, string userId);

        CartAllProductsViewModel GetProducts(string userId);

        void BuyProducts(string userId);
    }
}
